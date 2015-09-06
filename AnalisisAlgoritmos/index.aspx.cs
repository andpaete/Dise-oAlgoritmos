using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnalisisAlgoritmos.Clases;
using System.Data;
using System.Diagnostics;

namespace AnalisisAlgoritmos
{
    public partial class index : System.Web.UI.Page
    {

        #region "Variables Globales"

            private  long cant_numeros;
            private Nodo nRaiz = null;
            private int pos = 0;

        #endregion

        #region "Enumeradores Nodo"
            public enum Rama
            {
                rIzq,
                rDer
            };

        #endregion

        #region "Eventos"

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    cargardllRango();
                }
            }

            private void cargardllRango()
            {
                ddlRango.DataSource = InsertarRegistros.obtenerRangos();
                ddlRango.DataTextField = "valorFinal";
                ddlRango.DataValueField = "id_rango";
                ddlRango.DataBind();
            }

            protected void btnCargar_Click(object sender, EventArgs e)
            {
                if (this.fuCarga.HasFile)
                {
                    if (!System.IO.Directory.Exists(Server.MapPath("~/Cargas")))
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Cargas"));
                    }
                    this.fuCarga.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Cargas"), this.fuCarga.FileName));
                    cant_numeros = long.Parse(ddlRango.SelectedItem.Text);
                    cargarNumeros(System.IO.Path.Combine(Server.MapPath("~/Cargas"), this.fuCarga.FileName));
                }
            }

        #endregion

        #region "Metodos"

            private void cargarNumeros(string path)
            {
                long[] arrayNumeros = new long[cant_numeros];
                System.IO.StreamReader stReader = new System.IO.StreamReader(path);
                int i = 0;
                while (!stReader.EndOfStream && i < arrayNumeros.Length)
                {
                    arrayNumeros[i++] = long.Parse(stReader.ReadLine());
                }
                stReader.Close();
                nRaiz = null;
                pos = 0;
                metodosOrdenamiento(arrayNumeros);
            }

            private void metodosOrdenamiento(long[] arrayNumeros)
            {
                burbujaSimple(arrayNumeros);
                burbujaMejorado(arrayNumeros);
                insercion(arrayNumeros);
                seleccion(arrayNumeros);
                shell(arrayNumeros);
                ArbolBinarioBusqueda(arrayNumeros);
            }

            private void burbujaSimple(long[] arrayNumeros)
            {
                long[] array = new long[cant_numeros];
                arrayNumeros.CopyTo(array, 0);
                Process proceso = Process.GetCurrentProcess();
                System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
                long aux = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - 1; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            aux = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = aux;
                        }
                    }
                }
                InsertarRegistros.insertarRegistros(1, int.Parse(ddlRango.SelectedValue), proceso.TotalProcessorTime.TotalMilliseconds, (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
            }

            private void burbujaMejorado(long[] arrayNumeros)
            {
                long[] array = new long[cant_numeros];
                arrayNumeros.CopyTo(array, 0);
                Process proceso = Process.GetCurrentProcess();
                System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
                long aux = 0;
                for (int i = 1; i < array.Length; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (array[i] < array[j])
                        {
                            aux = array[j];
                            array[j] = array[i];
                            array[i] = aux;
                        }
                    }
                }
                InsertarRegistros.insertarRegistros(2, int.Parse(ddlRango.SelectedValue), proceso.TotalProcessorTime.TotalMilliseconds, (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
            }

            private void insercion(long[] arrayNumeros)
            {
                long[] array = new long[cant_numeros];
                arrayNumeros.CopyTo(array, 0);
                Process proceso = Process.GetCurrentProcess();
                System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
                for (int i = 1; i < array.Length; i++)
                {
                    long aux = array[i];
                    int j = i - 1;
                    while (j >= 0 && array[j] > aux)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j + 1] = aux;
                }
                InsertarRegistros.insertarRegistros(3, int.Parse(ddlRango.SelectedValue), proceso.TotalProcessorTime.TotalMilliseconds, (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
            }

            private void seleccion(long[] arrayNumeros)
            {
                long[] array = new long[cant_numeros];
                arrayNumeros.CopyTo(array, 0);
                Process proceso = Process.GetCurrentProcess();
                System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
                long aux = 0;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    long p = i;
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[j] < array[p])
                        {
                            p = j;
                        }
                    }
                    if (p != i)
                    {
                        aux = array[p];
                        array[p] = array[i];
                        array[i] = aux;
                    }
                }
                InsertarRegistros.insertarRegistros(4, int.Parse(ddlRango.SelectedValue), proceso.TotalProcessorTime.TotalMilliseconds, (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
            }

            private void shell(long[] arrayNumeros)
            {
                long[] array = new long[cant_numeros];
                arrayNumeros.CopyTo(array, 0);
                Process proceso = Process.GetCurrentProcess();
                System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
                int i = array.Length / 2;
                long aux = 0;
                int k = 0;
                while (i >= 1)
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        aux = array[j];
                        k = j - i;
                        while (k >= 0 && array[k] > aux)
                        {
                            array[k + i] = array[k];
                            k -= i;
                        }
                        array[k + i] = aux;
                    }
                    i /= 2;
                }
                InsertarRegistros.insertarRegistros(5, int.Parse(ddlRango.SelectedValue), proceso.TotalProcessorTime.TotalMilliseconds, (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
            }

            private void ArbolBinarioBusqueda(long[] arrayNumeros)
            {
                long[] array = new long[cant_numeros];
                arrayNumeros.CopyTo(array, 0);
                Process proceso = Process.GetCurrentProcess();
                System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
                foreach (int a in array)
                {
                    insertarNodo(nRaiz, null, a, 0);
                }
                inOrden(nRaiz, array);
                InsertarRegistros.insertarRegistros(6, int.Parse(ddlRango.SelectedValue), proceso.TotalProcessorTime.TotalMilliseconds, (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
            }

            /// <summary>
            /// Permite Insertar los valores al arbol binario
            /// </summary>
            /// <param name="a">Hoja que se inserta en el arbol</param>
            /// <param name="padre">Raiz de la hoja a insertar</param>
            /// <param name="valor">Valor de la hoja</param>
            /// <param name="rama">Direccion de la nueva rama que contiene la nueva hoja del arbol</param>
            public void insertarNodo(Nodo a, Nodo padre, long valor, Rama rama)
            {
                if (a == null) // Si es una nueva rama
                {
                    a = new Nodo(valor);
                    if (nRaiz == null) // Si es la primer rama del arbol
                    {
                        nRaiz = a; // Se Asigna la raiz principal
                    }
                    else
                    {
                        if (rama == Rama.rDer) // Si la rama se genera por la derecha de la Raiz
                        {
                            padre.nDer = a; // Se asigna el nodo nuevo como hijo de la raiz a la derecha
                        }
                        else if (rama == Rama.rIzq) // Si la rama se genera por la izquierda de la raiz
                        {
                            padre.nIzq = a; // Se asigna el nodo nuevo como hijo de la raiz a la izquierda
                        }
                    }
                }
                else
                {
                    if (valor < a.dato) // Si el dato es menor que el valor de la raiz
                    {
                        insertarNodo(a.nIzq, a, valor, Rama.rIzq);
                    }
                    else if (valor > a.dato) // Si el dato es mayor que el valor de la raiz
                    {
                        insertarNodo(a.nDer, a, valor, Rama.rDer);
                    }
                    else
                    {
                        Console.WriteLine("Dato Repetido");
                    }
                }
            }

            public void inOrden(Nodo a, long[] array)
            {
                if (a != null)
                {
                    inOrden(a.nIzq, array);
                    array[pos++] = a.dato;
                    inOrden(a.nDer, array);
                }
            }

        #endregion

    }
}