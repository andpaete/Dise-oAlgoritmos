using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatalayeConexion;
using System.Data;
using AnalisisAlgoritmos.Enumeradores;

namespace AnalisisAlgoritmos.Clases
{
    public static class InsertarRegistros
    {
        /// <summary>
        /// Guarda las estadisticas de tiempo de ejecucion de los algoritmos
        /// </summary>
        /// <param name="id_algoritmo">Id del algoritmo que se ejecuto</param>
        /// <param name="id_rango">cantidad de registros que seleyeron</param>
        /// <param name="tiempo_real_cpu">Tiempo en segundos que tardo en ejecutarce el algoritmo</param>
        /// <param name="tiempo_cpu">Tiempo de CPU que gasto el algoritmo en su ejecucion</param>
        /// <param name="tiempo_e_s">Tiempo de escritura y lectura del disco duro</param>
        /// <param name="porcentaje_cpu_wall">Tiempo de CPU del algoritmo en ejecucion divido entre 100</param>
        public static void insertarRegistros(Algoritmo idAlgoritmo, int id_rango, double tiempo_real_cpu, long tiempo_cpu, double tiempo_e_s, double porcentaje_cpu_wall)
        {
            try
            {
                Conexion c = new Conexion();
                c.NombreStoredProcedure = "sp_insertRegistro";
                c.AddLista("@id_algoritmo", (int)idAlgoritmo);
                c.AddLista("@id_rango", id_rango);
                c.AddLista("@tiempo_cpu_real", tiempo_real_cpu);
                c.AddLista("@tiempo_cpu", tiempo_cpu);
                c.AddLista("@tiempo_e_s", tiempo_e_s);
                c.AddLista("@porcentaje_cpu_wall", porcentaje_cpu_wall);
                c.ejecutarStoredProcedure();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable obtenerRangos()
        {
            try
            {
                Conexion c = new Conexion();
                c.NombreStoredProcedure = "sp_rango";
                return c.ejecutarStoredProcedure();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}