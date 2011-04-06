using System;
using System.Windows.Forms;
using System.Collections;

namespace RSTmobile
{
    public partial class FSenal : Form
    {
        private Transito.SenalTransito senal;
        private ArrayList listaSenalesTra;
        private ArrayList listaCategSen;
        private ArrayList listaTipoSen;
        private ArrayList listaEstados;
        private ArrayList listaMunicipios;
        private ArrayList listaParroquias;
        private int tipoActual;

        public FSenal()
        {
            InitializeComponent();
        }

        public void SetSenal(Transito.SenalTransito senal) {
            this.senal = senal;
            Ubicacion.Ubicacion ubicacion;
            Transito.Senal senales;
            int i = 0;

            ubicacion = Ubicacion.Ubicacion.GetInstance();
            senales = Transito.Senal.GetInstance();
            listaEstados = ubicacion.GetEstados();
            listaMunicipios = ubicacion.GetMunicipios(senal.GetCodEstado());
            listaParroquias = ubicacion.GetParroquias(senal.GetCodMunicipio());
            listaTipoSen = senales.GetTipoSenal();
            listaCategSen = senales.GetCategoriaSenal(""+senal.GetIDTipo());
            listaSenalesTra = senales.GetSenales(""+senal.GetIDTipo(), ""+senal.GetIDCategoria());
            foreach (Transito.Indicador aux in listaSenalesTra)
            {
                comboSenal.Items.Add(aux.descripcion);
                if (aux.id.Equals(""+senal.GetIDSenal()))
                    comboSenal.SelectedIndex = i;
                i++;
            }
            i = 0;
            foreach (Transito.Indicador aux in listaCategSen)
            {
                comboCategoria.Items.Add(aux.descripcion);
                if (aux.id.Equals("" + senal.GetIDCategoria()))
                    comboCategoria.SelectedIndex = i;
                i++;
            }
            i = 0;
            foreach (Transito.Indicador aux in listaTipoSen)
            {
                comboTipo.Items.Add(aux.descripcion);
                if (aux.id.Equals("" + senal.GetIDTipo()))
                {
                    tipoActual = i;
                    comboTipo.SelectedIndex = i;
                }  
                i++;
            }
            i = 0;
            foreach (Ubicacion.Entidad aux in listaEstados)
            {
                comboEntidad.Items.Add(aux.descripcion);
                if (aux.id.Equals(senal.GetCodEstado()))
                    comboEntidad.SelectedIndex = i;
                i++;
            }
            i = 0;
            foreach (Ubicacion.Entidad aux in listaMunicipios)
            {
                comboMunicipio.Items.Add(aux.descripcion);
                if (aux.id.Equals(senal.GetCodMunicipio()))
                    comboMunicipio.SelectedIndex = i;
                i++;
            }
            i = 0;
            foreach (Ubicacion.Entidad aux in listaParroquias)
            {
                comboParroquia.Items.Add(aux.descripcion);
                if (aux.id.Equals(senal.GetCodParroquia()))
                    comboParroquia.SelectedIndex = i;
                i++;
            }

                textBoxX.Text = "" + senal.GetX();
                textBoxY.Text = "" + senal.GetY();
                comboEstado.Items.Add("BUEN ESTADO");
                comboEstado.Items.Add("REGULAR");
                comboEstado.Items.Add("MAL ESTADO");
                comboEstado.SelectedIndex = senal.GetIDEstado() - 1;

                comboEstatus.Items.Add("ACTIVO");
                comboEstatus.Items.Add("INACTIVO");
                comboEstatus.SelectedIndex = 0;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            RSTmobile.view.RSTApp rst = RSTmobile.view.RSTApp.GetInstance();
            FConsultarSenal fcsenal = rst.GetConsultarSenal();
            fcsenal.Show();
            this.Hide();
        }

        private void comboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMunicipio.Items.Clear();
            comboParroquia.Items.Clear();
            int selectedIndex = 0;
            int i = 0;
            Ubicacion.Entidad aux;
            Ubicacion.Ubicacion ubicacion;

            ubicacion = Ubicacion.Ubicacion.GetInstance();            
            selectedIndex = comboEntidad.SelectedIndex;
            listaEstados = ubicacion.GetEstados();
            aux = (Ubicacion.Entidad)listaEstados[selectedIndex];

            listaMunicipios = ubicacion.GetMunicipios(aux.id);

            foreach (Ubicacion.Entidad data in listaMunicipios)
            {
                this.comboMunicipio.Items.Add(data.descripcion);
                //if (("" + senal.GetCodMunicipio()).Equals(data.id))
                //    comboEntidad.SelectedIndex = i;
                i++;
            }

        }

        private void comboMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboParroquia.Items.Clear();
            int selectedIndex = 0;
            string codEstado;
            Ubicacion.Entidad aux;
            Ubicacion.Ubicacion ubicacion;

            ubicacion = Ubicacion.Ubicacion.GetInstance();
            aux = (Ubicacion.Entidad)listaEstados[comboEntidad.SelectedIndex];
            codEstado = aux.id;
            listaMunicipios = ubicacion.GetMunicipios(codEstado);
            selectedIndex = comboMunicipio.SelectedIndex;
            aux = (Ubicacion.Entidad)listaMunicipios[selectedIndex];
                
            listaParroquias = ubicacion.GetParroquias(aux.id);

            foreach (Ubicacion.Entidad data in listaParroquias)
            {
                this.comboParroquia.Items.Add(data.descripcion);
            }
        }

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transito.Indicador aux;
            Transito.Senal senales;
            int i = 0;

            senales = Transito.Senal.GetInstance();
            comboCategoria.Items.Clear();
            comboSenal.Items.Clear();
            tipoActual = comboTipo.SelectedIndex;
            listaTipoSen = senales.GetTipoSenal();
            aux = (Transito.Indicador)listaTipoSen[tipoActual];
            listaCategSen = senales.GetCategoriaSenal(aux.id);
            
            foreach ( Transito.Indicador data in listaCategSen)
            {
                comboCategoria.Items.Add(data.descripcion);
                if ( ("" + senal.GetIDCategoria()).Equals(data.id) )
                {
                    comboCategoria.SelectedIndex = i;
                }
                i++;
            }
        }

        private void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transito.Indicador aux, aux2;
            Transito.Senal senales;
            int i = 0;
            
            comboSenal.Items.Clear();
            senales = Transito.Senal.GetInstance();
            listaTipoSen = senales.GetTipoSenal();
            aux     = (Transito.Indicador)listaTipoSen[tipoActual];
            listaCategSen = senales.GetCategoriaSenal(aux.id);
            aux2    = (Transito.Indicador)listaCategSen[comboCategoria.SelectedIndex];

            listaSenalesTra = senales.GetSenales(aux.id, aux2.id);
            
            foreach (Transito.Indicador data in listaSenalesTra)
            {
                comboSenal.Items.Add(data.descripcion);
                if (("" + senal.GetIDSenal()).Equals(data.id) )
                {
                    comboSenal.SelectedIndex = i;
                }
                i++;
            }
        }

        private void botonAveria_Click(object sender, EventArgs e)
        {
            FAveria faveria = new FAveria();
            faveria.SetSenal(senal);
            faveria.Show();
            this.Hide();
        }

    }
}