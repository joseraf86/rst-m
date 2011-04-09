using System;
using System.Windows.Forms;

namespace RSTmobile
{
    public partial class FRegistrarSenal : Form
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
    
        public FRegistrarSenal()
        {
            InitializeComponent();
        }
        
        private void FRegistrarSenal_Load(object sender, EventArgs e)
        {
            ubicacion = Ubicacion.Ubicacion.GetInstance();
            transito    = Transito.Senal.GetInstance();
            listaEstados = ubicacion.GetEstados();
            listaTipoSen = transito.GetTipos();

            foreach (Ubicacion.Entidad edo in listaEstados)
            {
                this.comboEntidad.Items.Add(edo.descripcion);
            }

            foreach (Transito.Indicador edo in listaTipoSen)
            {
                this.comboTipo.Items.Add(edo.descripcion);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FMenu().Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            Transito.Indicador aux;
            
            comboCategorias.Items.Clear();
            comboSenales.Items.Clear();
            selectedIndex = comboTipo.SelectedIndex;
            aux = (Transito.Indicador)listaTipoSen[selectedIndex];
            idTipoSenalActual = aux.id;
            listaCategSen = transito.GetCategorias(idTipoSenalActual);

            foreach (Transito.Indicador data in listaCategSen)
            {
                this.comboCategorias.Items.Add(data.descripcion);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            Transito.Indicador aux;

            comboSenales.Items.Clear();
            selectedIndex = comboCategorias.SelectedIndex;
            if (listaCategSen != null)
            {
                aux = (Transito.Indicador)listaCategSen[selectedIndex];
                idCategSenalActual = aux.id;
                listaSenalesTra = transito.GetSenales(idTipoSenalActual, idCategSenalActual);

                foreach (Transito.Indicador data in listaSenalesTra)
                {
                    this.comboSenales.Items.Add(data.descripcion);
                }
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMunicipios.Items.Clear();
            comboParroquias.Items.Clear();
            int selectedIndex = 0;
            Ubicacion.Entidad aux;
            Ubicacion.Ubicacion datos;
            selectedIndex = comboEntidad.SelectedIndex;
            aux     = (Ubicacion.Entidad) listaEstados[selectedIndex];
            datos = Ubicacion.Ubicacion.GetInstance();
            listaMunicipios = datos.GetMunicipios(aux.id);

            foreach (Ubicacion.Entidad data in listaMunicipios)
            {
                this.comboMunicipios.Items.Add(data.descripcion);
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboParroquias.Items.Clear();
            int selectedIndex = 0;
            Ubicacion.Entidad aux;
            Ubicacion.Ubicacion datos;

            if (listaMunicipios != null) {
                selectedIndex = comboMunicipios.SelectedIndex;
                aux = (Ubicacion.Entidad)listaMunicipios[selectedIndex];
                datos = Ubicacion.Ubicacion.GetInstance();
                listaParroquias = datos.GetParroquias(aux.id);

                foreach (Ubicacion.Entidad data in listaParroquias)
                {
                    this.comboParroquias.Items.Add(data.descripcion);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ubicacion.Entidad edo;
            Ubicacion.Entidad mun;
            Ubicacion.Entidad par;
            // Datos obtenidos del form3
            string login = "";
            string observaciones  = "";
            string codEstado = "";
            string codMunicipio = "";
            string codParroquia = "";
            string idTipoSen = "";
            string idCategSen = "";
            string idSenalTra = "";
            string idStatusSen = "";
            string coordX = "";
            string coordY = "";
            string idEstadSen = "";
            string vars;
            int statusSen      = 0;
            rst.Usuario user;
            string domainName;
            string path = "RSTmobile/servidor/controller/MobileSenalController.php";
            HTTP.EnlaceHTTP enlace = new HTTP.EnlaceHTTP();

            if (comboBox6.SelectedItem != null && comboBox7.SelectedItem != null && comboEntidad.SelectedItem != null && 
                comboMunicipios.SelectedItem != null && comboParroquias.SelectedItem != null)
            {
                user = rst.Usuario.GetInstance();
                login = user.GetLogin();
                domainName = user.GetServer();
                statusSen = comboBox7.SelectedIndex;
                edo = (Ubicacion.Entidad)listaEstados[comboEntidad.SelectedIndex];
                mun = (Ubicacion.Entidad)listaMunicipios[comboMunicipios.SelectedIndex];
                par = (Ubicacion.Entidad)listaParroquias[comboParroquias.SelectedIndex];
                coordX = "10.4873291";
                coordY = "-66.8151324";
                idTipoSen = idTipoSenalActual;
                idCategSen = idCategSenalActual;
                idSenalTra = idSenalTransitoActual;
                idEstadSen = "" + comboBox6.SelectedIndex + 1;
                observaciones = textBox3.Text;

                if (statusSen == 0)
                    idStatusSen = "A";
                else
                    idStatusSen = "I";

                codEstado = edo.id;
                codMunicipio = mun.id;
                codParroquia = par.id;

                if (coordX != "" && coordY != "" && idTipoSen != "" && idCategSen != "" && idSenalTra != "" &&
                    idEstadSen != "" && codEstado != "" && codMunicipio != "" &&
                    ((codParroquia == "" && codEstado == "DF") || (codParroquia != "" && codEstado != "DF")) ) 
                {
                    vars = "id_op=2&coord_x=" + coordX + "&coord_y=" + coordY + "&id_tipo_sen=" + idTipoSen +
                        "&id_categ_sen=" + idCategSen + "&id_senal_tra=" + idSenalTra + "&id_estad_sen=" + idEstadSen +
                        "&id_status_sen=" + idStatusSen + "&averia=N&cod_estado=" + codEstado + "&cod_municipio=" + codMunicipio +
                        "&cod_parroquia=" + codParroquia + "&login=" + login + "&observaciones=" + observaciones;

                    try
                    {
                        enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, domainName, path);
                        MessageBox.Show("Señal registrada exitosamente");

                    }
                    catch //(WebException)
                    {
                        MessageBox.Show("Conexión fallida con el servidor. Verifique la red inalámbrica e intente de nuevo");
                    }

                    new FMenu().Show();
                    this.Hide();
                }
                return;
            }
            
            MessageBox.Show("Son obligatorios todos los campos");
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transito.Indicador aux = (Transito.Indicador)listaSenalesTra[comboSenales.SelectedIndex];
            idSenalTransitoActual = aux.id;
        }

    }
}