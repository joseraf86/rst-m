using System;
using System.Collections;
using System.Windows.Forms;
using System.Web;

namespace RSTmobile
{
    public partial class FAveria : Form
    {
        //private Transito.SenalTransito senal;
        private ArrayList listaMotivos;
        private Transito.Averia averia;
        private Transito.Senal senales;

        public FAveria()
        {
            InitializeComponent();
        }

        public void SetAveria(Transito.Averia averia)
        {
            this.averia = averia;
        }

        private void FAveria_Load(object sender, EventArgs e)
        {
            senales = Transito.Senal.GetInstance();
            listaMotivos = senales.ConsultarMotivos();
            foreach (Transito.Indicador data in listaMotivos)
            {
                this.comboMotivos.Items.Add(data.descripcion);
            }
            comboMotivos.SelectedIndex = 0;
            averia.SetFechaAveria(fechaAveria.Value.ToString("dd/MM/yyyy"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSTmobile.controller.RSTApp rstapp = RSTmobile.controller.RSTApp.GetInstance();
            FMenu fmenu = rstapp.GetMenu();
            fmenu.Show();
            this.Hide();
        }

        private void fechaAveria_ValueChanged(object sender, EventArgs e)
        {
            averia.SetFechaAveria(fechaAveria.Value.ToString("dd/MM/yyyy"));
        }

        private void botonNotificar_Click(object sender, EventArgs e)
        {
            controller.FConfirmarAveria fcaveria = new RSTmobile.controller.FConfirmarAveria();
            fcaveria.SetAveria(averia);
            fcaveria.Show();
            this.Hide();
        }

        private void comboMotivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transito.Indicador aux;
            if (listaMotivos != null)
            {
                aux = (Transito.Indicador)listaMotivos[comboMotivos.SelectedIndex];
                averia.SetIDMotivo(aux.id);
            }
            else
                MessageBox.Show("Opps... ocurrio un error en la lista de motivos");
        }

        private void observaciones_TextChanged(object sender, EventArgs e)
        {
            averia.SetObservaciones(observaciones.Text);
        }
        
    }
}