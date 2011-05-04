using System;
using System.Collections;
using System.Data.SqlServerCe;
using RST;
using System.Windows.Forms;

namespace Transito
{
    public struct Indicador // representa un Tipo o una Categoria o una Señal
    {
        public string id;
        public string descripcion;
    }

    public class SenalTransito
    {
        private int id;

        private string x;
        private string y;

        private Celda tipo;
        private Celda categoria;
        private Celda senal;

        private Celda estado;
        private Celda estatus;

        private Celda entidad;
        private Celda municipio;
        private Celda parroquia;

        private string observaciones;
        private string idAveria;

        public SenalTransito()
        {
            tipo.id = "";
            categoria.id = "";
            senal.id = "";

            estado.id = "";
            estatus.id = "";

            entidad.id = "";
            municipio.id = "";
            parroquia.id = "";

            idAveria = "";
        }

        //********** SETTERS ***********
        public void SetID(int id)
        {
            this.id = id;
        }

        public void SetX(string x)
        {
            this.x = x;
        }

        public void SetY(string y)
        {
            this.y = y;
        }
        public void SetTipo( string idTipo, string descripcion )
        {
            tipo.id = idTipo;
            tipo.descripcion = descripcion;
        }

        public void SetCategoria(string idCategoria, string descripcion)
        {
            categoria.id = idCategoria;
            categoria.descripcion = descripcion;
        }

        public void SetSenal(string idSenal, string descripcion )
        {
            senal.id = idSenal;
            senal.descripcion = descripcion;
        }

        public void SetEstado(string idEstado, string descripcion)
        {
            estado.id = idEstado;
            estado.descripcion = descripcion;
        }

        public void SetEstatus(string idEstatus, string descripcion )
        {
            estatus.id = idEstatus;
            estatus.descripcion = descripcion;
        }

        public void SetEntidad(string codEstado, string descripcion )
        {
            entidad.id = codEstado;
            entidad.descripcion = descripcion;
        }

        public void SetMunicipio(string codMunicipio, string descripcion)
        {
            municipio.id = codMunicipio;
            municipio.descripcion = descripcion;
        }

        public void SetParroquia(string codParroquia, string descripcion)
        {
            parroquia.id = codParroquia;
            parroquia.descripcion = descripcion;
        }

        public void SetObservaciones(string observaciones)
        {
            this.observaciones = observaciones;
        }

        public void SetIDAveria(string idAveria)
        {
            this.idAveria = idAveria;
        }

        //********** GETTERS ***********
        public int GetID()
        {
            return this.id;
        }
        public string GetX()
        {
            return this.x;
        }
        public string GetY()
        {
            return this.y;
        }
        public string GetIDTipo()
        {
            return this.tipo.id;
        }
        public string GetDescripcionTipo()
        {
            return this.tipo.descripcion;
        }
        public string GetIDCategoria()
        {
            return this.categoria.id;
        }
        public string GetDescripcionCategoria()
        {
            return this.categoria.descripcion;
        }
        public string GetIDSenal()
        {
            return senal.id;
        }

        public string GetSenal()
        {
            return senal.descripcion;
        }

        public string GetIDEstado()
        {
            return estado.id;
        }

        public string GetDescEstado()
        {
            return estado.descripcion;
        }

        public string GetIDEstatus()
        {
            return estatus.id;
        }

        public string GetDescripcionEstatus()
        {
            return estatus.descripcion;
        }

        public string GetCodEstado()
        {
            return entidad.id;
        }
        public string GetEntidad()
        {
            return entidad.descripcion;
        }
        public string GetCodMunicipio()
        {
            return municipio.id;
        }
        public string GetMunicipio()
        {
            return municipio.descripcion;
        }
        public string GetCodParroquia()
        {
            return parroquia.id;
        }
        public string GetParroquia()
        {
            return parroquia.descripcion;
        }
        public string GetObservaciones()
        {
            return observaciones;
        }
        public string GetIDAveria()
        {
            return this.idAveria;
        }
        public override string ToString()
        {
            string str = "";
            str += "( " + id;

            str += ", " + x;
            str += ", " + y;

            str += ", " + tipo.id;
            str += ", " + categoria.id;
            str += ", " + senal.id;

            str += ", " + estado.id;
            str += ", " + estatus.id;

            str += ", " + entidad.id;
            str += ", " + municipio.id;
            str += ", " + parroquia.id;

            str += ", " + idAveria;
            str += ")";
            return str;
        }

    }

    public class Senal
    {
        public static int CUALQUIER_TIPO = 100000;
        public static int CUALQUIER_CATEGORIA = 10000;
        public static int CUALQUIER_SENAL = 1000;
        public static int CUALQUIER_ENTIDAD = 100;
        public static int CUALQUIER_MUNICIPIO = 10;
        public static int CUALQUIER_PARROQUIA = 1;

        private SqlCeConnection conn = null;
        private SqlCeCommand cmd;
        private ArrayList listaTipoSenal;
        private ArrayList listaCategoria;
        private ArrayList listaSenales;
        private string idTipo;
        private string idCategoria;
        private static Senal instance;

        public static Senal GetInstance()
        {
            if (instance == null)
            {
                instance = new Senal();
            }
            return instance;
        }

        private Senal()
        {
        }

        public ArrayList GetTipos()
        {
            if (listaTipoSenal == null)
            // Consultar Tipo de Señales 
            {
                listaTipoSenal = ConsultarTipos();
            }
            return listaTipoSenal;
        }

        public ArrayList GetCategorias( string idTipo )
        {
            if (listaCategoria == null)
            // Consultar Tipo de Señales 
            {
                listaCategoria = this.ConsultarCategorias(idTipo);
            }
            else
            {
                if (this.idTipo != idTipo)
                {
                    this.idTipo = idTipo;
                    this.idCategoria = "";    
                    listaCategoria = this.ConsultarCategorias(idTipo);
                }
            }

            return listaCategoria;
        }

        public ArrayList GetSenales ( string idTipo, string idCategoria )
        {
            if (listaSenales == null)
            // Consultar Tipo de Señales 
            {
                listaSenales = this.ConsultarSenales(idTipo, idCategoria);
            }
            else
            {
                if (this.idTipo != idTipo || this.idCategoria != idCategoria)
                {
                    this.idTipo = idTipo;
                    this.idCategoria = idCategoria;
                    listaSenales = this.ConsultarSenales(idTipo, idCategoria);
                }

            }
            return listaSenales;
        }

        public ArrayList ConsultarSenales( string id_tipo_sen,  string id_categ_sen)
        {
            string sdf_path;
            SqlCeEngine engine;
            ArrayList list = new ArrayList();
            Indicador aux;
            SqlCeDataReader rdr;
            try
            {
                sdf_path = "Data Source = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\db_rst.sdf;Persist Security Info=False;";
                engine = new SqlCeEngine(sdf_path);

                conn = new SqlCeConnection(sdf_path);
                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT id_senal_tra, descripcion FROM rst_senal_tra " +
                    "WHERE id_categ_sen=" + id_categ_sen + " and id_tipo_sen="+id_tipo_sen;

                rdr = cmd.ExecuteReader();
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
            catch (TypeLoadException)
            {

            }
            return list;
        }

        public ArrayList ConsultarCategorias( string id )
        {
            string sdf_path;
            SqlCeEngine engine;
            ArrayList list = new ArrayList();
            Indicador aux;
            SqlCeDataReader rdr;
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

                rdr = cmd.ExecuteReader();
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
            catch (TypeLoadException)
            {

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
            catch (TypeLoadException)
            {
 
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

        public ArrayList ConsultarMotivos() {
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

                cmd.CommandText = "SELECT id_motiv_ave, descripcion FROM rst_motiv_ave";
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

        public string ConsultarMotivo( string id )
        {
            string sdf_path;
            string queryResult = "";
            SqlCeEngine engine;


            try
            {
                sdf_path = "Data Source = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\db_rst.sdf;Persist Security Info=False;";
                engine = new SqlCeEngine(sdf_path);

                conn = new SqlCeConnection(sdf_path);
                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT descripcion FROM rst_motiv_ave WHERE id_motiv_ave=" + id;
                cmd.ExecuteNonQuery();

                SqlCeDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    queryResult = rdr.GetString(0);
                }

            }
            catch (SqlCeException e)
            {
                e.ToString();
                //ShowErrors(e);
            }

            return queryResult;
        }

        public ArrayList ConsultarEstados()
        {
            string sdf_path;
            SqlCeEngine engine;
            SqlCeDataReader rdr;

            ArrayList list = new ArrayList();
            Celda aux;

            try
            {
                sdf_path = "Data Source = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\db_rst.sdf;Persist Security Info=False;";
                engine = new SqlCeEngine(sdf_path);
                conn = new SqlCeConnection(sdf_path);
                conn.Open();

                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT id_estad_sen, descripcion FROM rst_estad_sen";
                cmd.ExecuteNonQuery();
                rdr = cmd.ExecuteReader();

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

          /*  foreach (Celda cel in list){
                MessageBox.Show("id "+cel.id+" descripcion "+cel.descripcion);
            }*/
            return list;
        }

        public ArrayList ConsultarLosStatus()
        {
            string sdf_path;
            SqlCeEngine engine;
            ArrayList list = new ArrayList();
            Celda aux;
            try
            {
                sdf_path = "Data Source = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\db_rst.sdf;Persist Security Info=False;";
                engine = new SqlCeEngine(sdf_path);

                conn = new SqlCeConnection(sdf_path);
                conn.Open();
                cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT id_status, descripcion FROM estatus";
                cmd.ExecuteNonQuery();

                SqlCeDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    aux.id = "" + rdr.GetString(0);
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
