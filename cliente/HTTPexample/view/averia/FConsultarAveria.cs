﻿using System;
using System.Windows.Forms;
using RSTmobile.controller;
using Transito;

namespace RSTmobile.view
{
    public partial class FConsultarAveria : Form
    {
        private Averia averia;

        public FConsultarAveria()
        {
            InitializeComponent();
        }

        public void SetAveria( Averia averia ) {
            this.averia = averia;
            labelFecha.Text = averia.GetFechaAveria();
            labelMotivo.Text = averia.GetMotivo();
            textBoxObservaciones.Text = averia.GetObservaciones();
        }

        private void textBoxObservaciones_TextChanged(object sender, EventArgs e)
        {
            averia.SetObservaciones(textBoxObservaciones.Text);
        }

        private void buttonReparar_Click(object sender, EventArgs e)
        {
            FRepararAveria fraveria = new FRepararAveria();
            fraveria.SetAveria(averia);
            fraveria.Show();
            this.Hide();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            RSTApp rstapp = RSTApp.GetInstance();
            FSenal fsenal = rstapp.GetSenal();
            fsenal.Show();
            this.Hide();
        }

    }
}