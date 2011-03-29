using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.Common;
using System.IO;

namespace Ubicacion
{
    public struct Entidad // representa un estado o municipio o parroquia
    {
        public string id;
        public string descripcion;
    }

    /* Clase que consulta la BD */
    public class Ubicacion
    {
        private SqlCeConnection conn = null;
        private SqlCeCommand cmd;

        public ArrayList ConsultarEstados()
        {
            string sdf_path;
            SqlCeEngine engine;
            ArrayList list = new ArrayList();
            Entidad aux;
            try
            {
                sdf_path = "Data Source = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\ubicacion.sdf;Persist Security Info=False;";
                engine = new SqlCeEngine(sdf_path);

                conn = new SqlCeConnection(sdf_path);
                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT cod_estado, estado FROM entidad_federal";

                SqlCeDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    aux.id = rdr.GetString(0);
                    aux.descripcion = rdr.GetString(1);
                    list.Add(aux);
                }
 
            }
            catch (SqlCeException e)
            {
                e.ToString();
                //ShowErrors(e);
            }

            return list;
        }

        public ArrayList ConsultarMunicipios( string id )
        {
            string sdf_path;
            SqlCeEngine engine;
            ArrayList list = new ArrayList();
            Entidad aux;
            try
            {
                sdf_path = "Data Source = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\ubicacion.sdf;Persist Security Info=False;";
                engine = new SqlCeEngine(sdf_path);

                conn = new SqlCeConnection(sdf_path);
                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT cod_municipio, municipio FROM municipio WHERE cod_estado = '"+id+"'";
                cmd.ExecuteNonQuery();
               
                SqlCeDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    aux.id = rdr.GetString(0);
                    aux.descripcion = rdr.GetString(1);
                    list.Add(aux);
                }

            }
            catch (SqlCeException e)
            {
                e.ToString();
                //ShowErrors(e);
            }

            return list;
        }

        public ArrayList ConsultarParroquias( string id )
        {
            string sdf_path;
            SqlCeEngine engine;
            ArrayList list = new ArrayList();
            Entidad aux;
            try
            {
                sdf_path = "Data Source = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\ubicacion.sdf;Persist Security Info=False;";
                engine = new SqlCeEngine(sdf_path);

                conn = new SqlCeConnection(sdf_path);
                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT cod_parroquia, parroquia FROM parroquia WHERE (cod_municipio = '"+id+"')";
                cmd.ExecuteNonQuery();
                
                SqlCeDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    aux.id = rdr.GetString(0);
                    aux.descripcion = rdr.GetString(1);
                    list.Add(aux);
                }

            }
            catch (SqlCeException e)
            {
                e.ToString();
                //ShowErrors(e);
            }

            return list;
        }


    }
}
