using System;
using System.Windows.Forms;

namespace RSTmobile
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