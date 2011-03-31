using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HTTPexample
{
    public partial class FMenu : Form
    {

        public FMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FConsultarSenal().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FRegistrarSenal().Show();
            this.Hide();
        }
    }
}