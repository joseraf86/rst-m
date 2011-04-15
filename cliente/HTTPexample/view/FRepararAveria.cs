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
    public partial class FRepararAveria : Form
    {
        public FRepararAveria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSTApp rstapp = RSTApp.GetInstance();
            FMenu menu = rstapp.GetMenu();
            menu.Show();
            this.Hide();
        }
    }
}