using System;
using System.Linq;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using System.Data.Common;
using System.IO;

namespace Transito
{
    public struct Indicador // representa un Tipo o una Categoria o una Señal
    {
        public string id;
        public string descripcion;
    }

    public class Senal
    {
        private SqlCeConnection conn = null;
        private SqlCeCommand cmd;

        public ArrayList ConsultarSenales( string id_tipo_sen,  string id_categ_sen)
        {
            string sdf_path;
            SqlCeEngine engine;
            ArrayList list = new ArrayList();
            Indicador aux;
            try
            {
                sdf_path = "Data Source = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\db_rst.sdf;Persist Security Info=False;";
                engine = new SqlCeEngine(sdf_path);

                conn = new SqlCeConnection(sdf_path);
                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT id_senal_tra, descripcion FROM rst_senal_tra " +
                    "WHERE id_categ_sen=" + id_categ_sen + " and id_tipo_sen="+id_tipo_sen;

                SqlCeDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    aux.id = "" + rdr.GetDecimal(0);
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

        public ArrayList ConsultarCategorias( string id )
        {
            string sdf_path;
            SqlCeEngine engine;
            ArrayList list = new ArrayList();
            Indicador aux;
            try
            {
                sdf_path = "Data Source = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\db_rst.sdf;Persist Security Info=False;";
                engine = new SqlCeEngine(sdf_path);

                conn = new SqlCeConnection(sdf_path);
                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT id_categ_sen, descripcion FROM rst_categ_sen "+
                    "WHERE id_tipo_sen = " + id + "";
                cmd.ExecuteNonQuery();

                SqlCeDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    aux.id = "" + rdr.GetDecimal(0);
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

        public ArrayList ConsultarTipos()
        {
            string sdf_path;
            SqlCeEngine engine;
            ArrayList list = new ArrayList();
            Indicador aux;
            //int entero;
            try
            {
                sdf_path = "Data Source = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\db_rst.sdf;Persist Security Info=False;";
                engine = new SqlCeEngine(sdf_path);

                conn = new SqlCeConnection(sdf_path);
                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT id_tipo_sen, descripcion FROM rst_tipo_sen";
                cmd.ExecuteNonQuery();

                SqlCeDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    aux.id = "" + rdr.GetDecimal(0);
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


        /* Consultar señales de transito por tipo, categoria, señal, estado, municipio, parroquia y coordenadas */
        public string ConsultarSenalesPor(string idTipo,
                                             string idCategoria,
                                             string idSenal,
                                             string codEstado,
                                             string codMunicipio,
                                             string codParroquia)
        {
            HTTP.EnlaceHTTP enlace;
            string vars = "";
            rst.Usuario user = rst.Usuario.GetInstance();
            string path = "rst-m/controller/MobileSenalController.php";

            enlace = new HTTP.EnlaceHTTP();
            vars = "id_tipo_sen=" + idTipo +
                   "&id_categ_sen=" + idCategoria + 
                   "&id_senal_tra=" + idSenal + 
                   "&averia=N" + 
                   "&cod_estado=" + codEstado + 
                   "&cod_municipio=" + codMunicipio +
                   "&cod_parroquia=" + codParroquia;

            try
            {
                enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, user.GetServer(), path);
                return "Señal consultada";

            }
            catch //(WebException)
            {
                return "Conexión fallida con el servidor. Verifique la red inalámbrica e intente de nuevo";
            }
        }

    }
}
