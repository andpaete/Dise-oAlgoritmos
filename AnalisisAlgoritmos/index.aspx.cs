using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnalisisAlgoritmos.Enumeradores;
using System.Data;
using System.Diagnostics;
using AnalisisAlgoritmos.Clases;

namespace AnalisisAlgoritmos
{
    public partial class index : System.Web.UI.Page
    {

        #region "Variables Globales"

        private long cant_numeros;
        private Nodo nRaiz = null;
        private int pos = 0;
        private long[] arrayNumeros;

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
            arrayNumeros = new long[cant_numeros];
            System.IO.StreamReader stReader = new System.IO.StreamReader(path);
            int i = 0;
            while (!stReader.EndOfStream && i < arrayNumeros.Length)
            {
                arrayNumeros[i++] = long.Parse(stReader.ReadLine());
            }
            stReader.Close();
            nRaiz = null;
            pos = 0;
            metodosOrdenamiento();
        }

        private void metodosOrdenamiento()
        {
            switch (int.Parse(rlBtn.SelectedValue))
            {
                case 1:
                    burbujaSimple();
                    break;
                case 2:
                    burbujaMejorado();
                    break;
                case 3:
                    insercion();
                    break;
                case 4:
                    seleccion();
                    break;
                case 5:
                    shell();
                    break;
                case 6:
                    ArbolBinarioBusqueda();
                    break;
            }
        }

        private void burbujaSimple()
        {
            Process proceso = Process.GetCurrentProcess();
            System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
            DateTime currentTime = DateTime.Now;
            long aux = 0;
            for (int i = 1; i < arrayNumeros.Length; i++)
            {
                for (int j = 0; j < arrayNumeros.Length - 1; j++)
                {
                    if (arrayNumeros[j] > arrayNumeros[j + 1])
                    {
                        aux = arrayNumeros[j];
                        arrayNumeros[j] = arrayNumeros[j + 1];
                        arrayNumeros[j + 1] = aux;
                    }
                }
            }
            DateTime finalTime = DateTime.Now;
            InsertarRegistros.insertarRegistros(Algoritmo.BurbujaSimple, int.Parse(ddlRango.SelectedValue), finalTime.Subtract(currentTime).TotalSeconds, 
                (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
        }

        private void burbujaMejorado()
        {
            Process proceso = Process.GetCurrentProcess();
            System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
            DateTime currentTime = DateTime.Now;
            long aux = 0;
            for (int i = 1; i < arrayNumeros.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arrayNumeros[i] < arrayNumeros[j])
                    {
                        aux = arrayNumeros[j];
                        arrayNumeros[j] = arrayNumeros[i];
                        arrayNumeros[i] = aux;
                    }
                }
            }
            DateTime finalTime = DateTime.Now;
            InsertarRegistros.insertarRegistros(Algoritmo.BurbujaMejorada, int.Parse(ddlRango.SelectedValue), finalTime.Subtract(currentTime).TotalSeconds,
                (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
        }

        private void insercion()
        {
            Process proceso = Process.GetCurrentProcess();
            System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
            DateTime currentTime = DateTime.Now;
            for (int i = 1; i < arrayNumeros.Length; i++)
            {
                long aux = arrayNumeros[i];
                int j = i - 1;
                while (j >= 0 && arrayNumeros[j] > aux)
                {
                    arrayNumeros[j + 1] = arrayNumeros[j];
                    j--;
                }
                arrayNumeros[j + 1] = aux;
            }
            DateTime finalTime = DateTime.Now;
            InsertarRegistros.insertarRegistros(Algoritmo.Insercion, int.Parse(ddlRango.SelectedValue), finalTime.Subtract(currentTime).TotalSeconds, 
                (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
        }

        private void seleccion()
        {
            Process proceso = Process.GetCurrentProcess();
            System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
            DateTime currentTime = DateTime.Now;
            long aux = 0;
            for (int i = 0; i < arrayNumeros.Length - 1; i++)
            {
                long p = i;
                for (int j = i + 1; j < arrayNumeros.Length; j++)
                {
                    if (arrayNumeros[j] < arrayNumeros[p])
                    {
                        p = j;
                    }
                }
                if (p != i)
                {
                    aux = arrayNumeros[p];
                    arrayNumeros[p] = arrayNumeros[i];
                    arrayNumeros[i] = aux;
                }
            }
            DateTime finalTime = DateTime.Now;
            InsertarRegistros.insertarRegistros(Algoritmo.Seleccion, int.Parse(ddlRango.SelectedValue), finalTime.Subtract(currentTime).TotalSeconds,
                (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
        }

        private void shell()
        {
            Process proceso = Process.GetCurrentProcess();
            System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
            DateTime currentTime = DateTime.Now;
            int i = arrayNumeros.Length / 2;
            long aux = 0;
            int k = 0;
            while (i >= 1)
            {
                for (int j = i; j < arrayNumeros.Length; j++)
                {
                    aux = arrayNumeros[j];
                    k = j - i;
                    while (k >= 0 && arrayNumeros[k] > aux)
                    {
                        arrayNumeros[k + i] = arrayNumeros[k];
                        k -= i;
                    }
                    arrayNumeros[k + i] = aux;
                }
                i /= 2;
            }
            DateTime finalTime = DateTime.Now;
            InsertarRegistros.insertarRegistros(Algoritmo.Shell, int.Parse(ddlRango.SelectedValue), finalTime.Subtract(currentTime).TotalSeconds,
                (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
        }

        private void ArbolBinarioBusqueda()
        { 
            Process proceso = Process.GetCurrentProcess();
            System.TimeSpan lifeInterval = (DateTime.Now - proceso.StartTime);
            DateTime currentTime = DateTime.Now;
            foreach (int a in arrayNumeros)
            {
                insertarNodo(nRaiz, null, a, 0);
            }
            inOrden(nRaiz);
            DateTime finalTime = DateTime.Now;
            InsertarRegistros.insertarRegistros(Algoritmo.ArbolBinario, int.Parse(ddlRango.SelectedValue), finalTime.Subtract(currentTime).TotalSeconds, 
                (proceso.TotalProcessorTime.TotalMilliseconds / lifeInterval.TotalMilliseconds) * 100, 0.63, (proceso.TotalProcessorTime.TotalMilliseconds / 100));
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

        public void inOrden(Nodo a)
        {
            if (a != null)
            {
                inOrden(a.nIzq);
                arrayNumeros[pos++] = a.dato;
                inOrden(a.nDer);
            }
        }

        #endregion

    }
}