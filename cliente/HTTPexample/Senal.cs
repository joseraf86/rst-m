﻿using System;
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

    public class SenalTransito
    {
        private int id;

        private string x;
        private string y;

        private string idTipo;
        private string idCategoria;
        private string idSenal;

        private int idEstado;
        private string idEstatus;

        private string codEstado;
        private string codMunicipio;
        private string codParroquia;

        private string idAveria;

        //********** SETTERS ***********
        public void setID(int id)
        {
            this.id = id;
        }
        public void setX(string x)
        {
            this.x = x;
        }
        public void setY(string y)
        {
            this.y = y;
        }
        public void setIDTipo(string idTipo)
        {
            this.idTipo = idTipo;
        }
        public void setIDCategoria(string idCategoria)
        {
            this.idCategoria = idCategoria;
        }
        public void setIDSenal(string idSenal)
        {
            this.idSenal = idSenal;
        }
        public void setIDEstado(int idEstado)
        {
            this.idEstado = idEstado;
        }
        public void setIDEstatus(string idEstatus)
        {
            this.idEstatus = idEstatus;
        }
        public void setCodEstado(string codEstado)
        {
            this.codEstado = codEstado;
        }
        public void setCodMunicipio(string codMunicipio)
        {
            this.codMunicipio = codMunicipio;
        }
        public void setCodParroquia(string codParroquia)
        {
            this.codParroquia = codParroquia;
        }
        public void setIDAveria(string idAveria)
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
            return this.idTipo;
        }
        public string GetIDCategoria()
        {
            return this.idCategoria;
        }
        public string GetIDSenal()
        {
            return this.idSenal;
        }
        public int GetIDEstado()
        {
            return this.idEstado;
        }
        public string getIDEstatus()
        {
            return this.idEstatus;
        }
        public string GetCodEstado()
        {
            return this.codEstado;
        }
        public string GetCodMunicipio()
        {
            return this.codMunicipio;
        }
        public string GetCodParroquia()
        {
            return this.codParroquia;
        }
        public override string ToString()
        {
            string str = "";
            str += "( " + id;

            str += ", " + x;
            str += ", " + y;

            str += ", " + idTipo;
            str += ", " + idCategoria;
            str += ", " + idSenal;

            str += ", " + idEstado;
            str += ", " + idEstatus;

            str += ", " + codEstado;
            str += ", " + codMunicipio;
            str += ", " + codParroquia;

            str += ", " + idAveria;
            str += ")";
            return str;
        }
    }

    public class Senal
    {
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

        public ArrayList GetTipoSenal()
        {
            if (listaTipoSenal == null)
            // Consultar Tipo de Señales 
            {
                listaTipoSenal = ConsultarTipos();
            }
            return listaTipoSenal;
        }

        public ArrayList GetCategoriaSenal( string idTipo )
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

        public ArrayList ConsultarMotivo() {
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

    }
}
