using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatalayeConexion;
using System.Data;

namespace AnalisisAlgoritmos.Clases
{
    public static class InsertarRegistros
    {
        public static void insertarRegistros(int id_algoritmo,int id_rango,double tiempo_real_cpu, double tiempo_cpu,double tiempo_e_s,double porcentaje_cpu_wall)
        {
            try
            {
                Conexion c = new Conexion();
                c.NombreStoredProcedure = "sp_insertRegistro";
                c.AddLista("@id_algoritmo", id_algoritmo);
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

        public static DataTable obtenerRangos(){
            try
            {
                Conexion c = new Conexion();
                c.NombreStoredProcedure = "sp_rango";
                return c.ejecutarStoredProcedure();
            }catch(Exception ex){
                throw ex;
            }
        }
    }
}