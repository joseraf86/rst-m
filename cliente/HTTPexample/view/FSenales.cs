using System.Windows.Forms;
using System.Collections;
using System;

namespace RSTmobile.controller
{
    public partial class FSenales : Form
    {
        private ArrayList senales;
        private Button buttonSenal;
            
        public FSenales()
        {
            InitializeComponent();
        }

        public void SetSenales(ArrayList senales)
        {
            int i = 0;
            int tam = 24;
            this.senales = senales;
            this.SuspendLayout();
            foreach (Transito.SenalTransito senal in senales)
            {
                buttonSenal = new Button();
                buttonSenal.Location = new System.Drawing.Point(16, 50+i*tam);
                buttonSenal.Name = "l_"+i;
                buttonSenal.Size = new System.Drawing.Size(128, 16);
                buttonSenal.TabIndex = 0;
                buttonSenal.Text = senal.GetCodParroquia();
                //label.Font.Style = System.Drawing.FontStyle.Underline;
                buttonSenal.Click += new System.EventHandler(label_Click);
                // Add the control to the form.
                panel1.Controls.Add(buttonSenal);
                i++;

               // MessageBox.Show(senal.GetCodParroquia());
            }
            this.ResumeLayout(false);

        }

        private void label_Click(object sender, System.EventArgs e)
        {
            int index;
            Button boton = (Button)sender;
            index = Convert.ToInt32( boton.Name.Split('_')[1] );
            Transito.SenalTransito senal;
            senal = (Transito.SenalTransito)senales[index];
            
            RSTmobile.controller.RSTApp rst = RSTmobile.controller.RSTApp.GetInstance();
            FSenal fsenal = rst.GetSenal();
            fsenal.SetSenal(senal);
            fsenal.Show();
            this.Hide();

        }

        private void botonVolver_Click(object sender, System.EventArgs e)
        {
            RSTmobile.controller.RSTApp rst = RSTmobile.controller.RSTApp.GetInstance();
            FConsultarSenal fcsenal = rst.GetConsultarSenal();
            fcsenal.Show();
            this.Hide();
        }

    }


}