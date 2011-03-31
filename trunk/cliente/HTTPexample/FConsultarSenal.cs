﻿using System;
using System.Windows.Forms;

namespace RSTmobile
{
    public partial class FConsultarSenal : Form
    {
        private string idTipoSenalActual;
        private string idCategSenalActual;
        private string idSenalTransitoActual;
        private Ubicacion.Ubicacion ubicacion;
        private Transito.Senal transito;
        private System.Collections.ArrayList listaEstados;
        private System.Collections.ArrayList listaMunicipios;
        private System.Collections.ArrayList listaParroquias;
        private System.Collections.ArrayList listaSenalesTra;
        private System.Collections.ArrayList listaCategSen;
        private System.Collections.ArrayList listaTipoSen;

        public FConsultarSenal()
        {
            InitializeComponent();
        }

        private void FConsultarSenal_Load(object sender, EventArgs e)
        {
            ubicacion = new Ubicacion.Ubicacion();
            transito = new Transito.Senal();
            listaEstados = ubicacion.ConsultarEstados();
            listaTipoSen = transito.ConsultarTipos();

            foreach (Ubicacion.Entidad edo in listaEstados)
            {
                this.comboEstado.Items.Add(edo.descripcion);
            }

            foreach (Transito.Indicador edo in listaTipoSen)
            {
                this.comboTipo.Items.Add(edo.descripcion);
            }
            comboTipo.SelectedIndex = 0;
            comboCategoria.SelectedIndex = 0;
            comboSenal.SelectedIndex = 0;
            comboEstado.SelectedIndex = 0;
            comboMunicipio.SelectedIndex = 0;
            comboParroquia.SelectedIndex = 0;
        }

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            Transito.Indicador aux;

            comboCategoria.Items.Clear();
            comboSenal.Items.Clear();
            comboCategoria.Items.Add("TODOS");
            comboSenal.Items.Add("TODOS");
            comboCategoria.SelectedIndex = 0;
            comboSenal.SelectedIndex = 0;
            selectedIndex = comboTipo.SelectedIndex;
            if (selectedIndex != 0)
            {
                // listaTipoSen no contiene opcion TODOS => selectedIndex - 1
                aux = (Transito.Indicador)listaTipoSen[selectedIndex - 1];
                idTipoSenalActual = aux.id;
                listaCategSen = transito.ConsultarCategorias(idTipoSenalActual);

                foreach (Transito.Indicador data in listaCategSen)
                {
                    this.comboCategoria.Items.Add(data.descripcion);
                }
            }
            else
            {
                idTipoSenalActual = "";
            }
        }

        private void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            Transito.Indicador aux;

            comboSenal.Items.Clear();
            comboSenal.Items.Add("TODOS");
            comboSenal.SelectedIndex = 0;
            if (listaCategSen != null && idTipoSenalActual != "")
            {
                selectedIndex = comboCategoria.SelectedIndex;
                if (selectedIndex != 0)
                {
                    aux = (Transito.Indicador)listaCategSen[selectedIndex - 1];
                    idCategSenalActual = aux.id;
                    listaSenalesTra = transito.ConsultarSenales(idTipoSenalActual, idCategSenalActual);

                    foreach (Transito.Indicador data in listaSenalesTra)
                    {
                        this.comboSenal.Items.Add(data.descripcion);
                    }
                    return;
                }
            }
            idCategSenalActual = "";
        }

        private void comboSenal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transito.Indicador aux;
            if (listaSenalesTra != null)
            {
                if (comboSenal.SelectedIndex != 0)
                {
                    aux = (Transito.Indicador)listaSenalesTra[comboSenal.SelectedIndex-1];
                    idSenalTransitoActual = aux.id;
                    return;
                }
            }
            idSenalTransitoActual = "";

        }

        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMunicipio.Items.Clear();
            comboParroquia.Items.Clear();
            comboParroquia.Items.Add("TODOS");
            comboMunicipio.Items.Add("TODOS");
            comboMunicipio.SelectedIndex = 0;
            comboParroquia.SelectedIndex = 0;
            int selectedIndex = 0;
            Ubicacion.Entidad aux;
            Ubicacion.Ubicacion datos;
            selectedIndex = comboEstado.SelectedIndex;
            if (selectedIndex != 0)
            {
                aux = (Ubicacion.Entidad)listaEstados[selectedIndex-1];
                datos = new Ubicacion.Ubicacion();
                listaMunicipios = datos.ConsultarMunicipios(aux.id);

                foreach (Ubicacion.Entidad data in listaMunicipios)
                {
                    this.comboMunicipio.Items.Add(data.descripcion);
                }
            }
        }

        private void comboMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            Ubicacion.Entidad aux;
            Ubicacion.Ubicacion datos;

            comboParroquia.Items.Clear();
            comboParroquia.Items.Add("TODOS");
            comboParroquia.SelectedIndex = 0;
            if (listaMunicipios != null)
            {
                selectedIndex = comboMunicipio.SelectedIndex;
                if (selectedIndex != 0)
                {
                    aux = (Ubicacion.Entidad)listaMunicipios[selectedIndex-1];
                    datos = new Ubicacion.Ubicacion();
                    listaParroquias = datos.ConsultarParroquias(aux.id);

                    foreach (Ubicacion.Entidad data in listaParroquias)
                    {
                        this.comboParroquia.Items.Add(data.descripcion);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ubicacion.Entidad edo;
            Ubicacion.Entidad mun;
            Ubicacion.Entidad par;
            // Datos obtenidos del form3
            string login = "";
            string codEstado = "";
            string codMunicipio = "";
            string codParroquia = "";
            string idTipoSen = "";
            string idCategSen = "";
            string idSenalTra = "";
            //string vars;
            rst.Usuario user;
            string domainName;
            //string path = "rst-m/controller/MobileSenalController.php";
            //HTTP.EnlaceHTTP enlace = new HTTP.EnlaceHTTP();


            user = rst.Usuario.GetInstance();
            login = user.GetLogin();
            domainName = user.GetServer();

            if (comboEstado.SelectedIndex != 0)
            {
                edo = (Ubicacion.Entidad)listaEstados[comboEstado.SelectedIndex-1];
                codEstado = edo.id;
                if (listaMunicipios != null && comboMunicipio.SelectedIndex != 0)
                {
                    mun = (Ubicacion.Entidad)listaMunicipios[comboMunicipio.SelectedIndex-1];
                    codMunicipio = mun.id;
                    if (listaParroquias != null && comboParroquia.SelectedIndex != 0)
                    {
                        par = (Ubicacion.Entidad)listaParroquias[comboParroquia.SelectedIndex-1];
                        codParroquia = par.id;
                    }
                }
            }
            idTipoSen = idTipoSenalActual;
            idCategSen = idCategSenalActual;
            idSenalTra = idSenalTransitoActual;

            MessageBox.Show(codEstado + " " + codMunicipio + " " + codParroquia + " " + idTipoSen + " " + idCategSen + " " + idSenalTra);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FMenu().Show();
            this.Hide();
        }

    }
}