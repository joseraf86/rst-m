using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RSTmobile.view
{
    public partial class FConsultarAveria : Form
    {
        private Transito.Averia averia;

        public FConsultarAveria()
        {
            InitializeComponent();
        }

        public void SetAveria(Transito.Averia averia) {
            this.averia = averia;
            labelFecha.Text = averia.GetFechaAveria();
            labelMotivo.Text = averia.GetIDMotivo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRepararAveria fraveria = new FRepararAveria();
            fraveria.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSTApp rstapp = RSTApp.GetInstance();
            FSenal fsenal = rstapp.GetSenal();
            fsenal.Show();
            this.Hide();
        }

    }
}