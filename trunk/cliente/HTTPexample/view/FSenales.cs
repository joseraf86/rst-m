using System.Windows.Forms;
using System.Collections;
using System;

namespace RSTmobile.view
{
    public partial class FSenales : Form
    {
        private ArrayList senales;
        //private ArrayList labelsSenales;
        private Button label;
            
        public FSenales()
        {
            InitializeComponent();
            //labelsSenales = new ArrayList();
        }

        public void SetSenales(ArrayList senales)
        {
            int i = 0;
            int tam = 24;
            this.senales = senales;
            this.SuspendLayout();
            foreach (Transito.SenalTransito senal in senales)
            {
                label = new Button();
                label.Location = new System.Drawing.Point(16, 50+i*tam);
                label.Name = "l_"+i;
                label.Size = new System.Drawing.Size(128, 16);
                label.TabIndex = 0;
                label.Text = senal.GetCodParroquia();
                //label.Font.Style = System.Drawing.FontStyle.Underline;
                label.Click += new System.EventHandler(label_Click);
                // Add the control to the form.
                panel1.Controls.Add(label);
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
            
            RSTmobile.view.RSTApp rst = RSTmobile.view.RSTApp.GetInstance();
            FSenal fsenal = rst.GetSenal();
            fsenal.SetSenal(senal);
            fsenal.Show();
            this.Hide();

        }

        private void botonVolver_Click(object sender, System.EventArgs e)
        {
            RSTmobile.view.RSTApp rst = RSTmobile.view.RSTApp.GetInstance();
            FConsultarSenal fcsenal = rst.GetConsultarSenal();
            fcsenal.Show();
            this.Hide();
        }

    }


}