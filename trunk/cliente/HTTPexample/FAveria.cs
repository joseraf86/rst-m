using System;
using System.Collections;
using System.Windows.Forms;

namespace RSTmobile
{
    public partial class FAveria : Form
    {
        private Transito.SenalTransito senal;

        public FAveria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FMenu().Show();
            this.Hide();
        }

        public void SetSenal(Transito.SenalTransito senal)
        {
            this.senal = senal;
        }

        private void botonNotificar_Click(object sender, EventArgs e)
        {
            string vars;
            Transito.Averia averia;
            rst.Usuario user;
            user = rst.Usuario.GetInstance();

            averia = new Transito.Averia();

            vars = "id_op=3&id_senal=" + senal.GetID() +
                   "&fechaAveria=" + "&fechaRegistro=" + "&loginRegistro=" + user.GetLogin() +
                   "&loginReparacion=" + "&fechaReparacion" + "&idMotivo" + "&idStatus" +
                   "&observaciones";

            try
            {
                //enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, user.GetServer(), path);
                MessageBox.Show("Averia registrada exitosamente");

                new FMenu().Show();
                this.Hide();
            }
            catch //(WebException)
            {
                MessageBox.Show("Conexión fallida con el servidor. Verifique la red inalámbrica e intente de nuevo");
            }

        }

        private void FAveria_Load(object sender, EventArgs e)
        {
            Transito.Senal senales;
            ArrayList listaMotivos;
            senales = Transito.Senal.GetInstance();
            listaMotivos = senales.ConsultarMotivo();
            foreach (Transito.Indicador data in listaMotivos)
            {
                this.comboMotivos.Items.Add(data.descripcion);
            }
            comboMotivos.SelectedIndex = 0;
            
        }
    }
}