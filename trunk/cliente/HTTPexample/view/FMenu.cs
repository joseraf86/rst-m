using System;
using System.Windows.Forms;
using RSTmobile.controller;

namespace RSTmobile.view
{
    public partial class FMenu : Form
    {

        public FMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSTApp rst = RSTApp.GetInstance();
            FConsultarSenal fcsenal = rst.GetConsultarSenal();
            fcsenal.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RSTApp rst = RSTApp.GetInstance();
            FRegistrarSenal frsenal = rst.GetRegistrarSenal();
            frsenal.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = null;
            str.GetType();
        }
    }
}