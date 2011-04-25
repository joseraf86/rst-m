using System;
using System.Collections;
using System.Windows.Forms;
using RSTmobile.view;
using Transito;

namespace RSTmobile
{
    public partial class FAveria : Form
    {
        private ArrayList listaMotivos;
        private Averia averia;
        private Senal senales;

        public FAveria()
        {
            InitializeComponent();
        }

        public void SetAveria(Averia averia)
        {
            this.averia = averia;
            //MessageBox.Show("id: "+averia.GetSenal().GetID());
        }

        private void FAveria_Load(object sender, EventArgs e)
        {
            senales = Senal.GetInstance();
            listaMotivos = senales.ConsultarMotivos();
            foreach (Indicador data in listaMotivos)
            {
                this.comboMotivos.Items.Add(data.descripcion);
            }
            comboMotivos.SelectedIndex = 0;
            averia.SetFechaAveria(fechaAveria.Value.ToString("dd/MM/yyyy"));
        }

        private void comboMotivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Indicador aux;
            if (listaMotivos == null)
            {
                listaMotivos = senales.ConsultarMotivos();
            }
            aux = (Indicador)listaMotivos[comboMotivos.SelectedIndex];
            averia.SetMotivo(aux.id, aux.descripcion);
        }

        private void fechaAveria_ValueChanged(object sender, EventArgs e)
        {
            averia.SetFechaAveria(fechaAveria.Value.ToString("dd/MM/yyyy"));
        }

        private void observaciones_TextChanged(object sender, EventArgs e)
        {
            averia.SetObservaciones(observaciones.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSTmobile.controller.RSTApp rstapp = RSTmobile.controller.RSTApp.GetInstance();
            FMenu fmenu = rstapp.GetMenu();
            fmenu.Show();
            this.Hide();
        }

        private void botonNotificar_Click(object sender, EventArgs e)
        {
            FConfirmarAveria fcaveria = new FConfirmarAveria();
            fcaveria.SetAveria(averia);
            fcaveria.Show();
            this.Hide();
        }

    }
}