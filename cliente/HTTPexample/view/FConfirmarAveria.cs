using System;
using System.Web;
using System.Windows.Forms;
using System.Collections;
using Transito;

namespace RSTmobile.controller
{
    public partial class FConfirmarAveria : Form
    {
        private Averia averia;

        public FConfirmarAveria()
        {
            InitializeComponent();
        }

        public void SetAveria(Averia averia)
        {
            this.averia = averia;
            
            Transito.Senal senales = Transito.Senal.GetInstance();

            labelSenal.Text = averia.GetSenal().GetIDSenal();
            labelMotivo.Text = senales.ConsultarMotivo(averia.GetIDMotivo());
            labelFecha.Text = averia.GetFechaAveria();
            labelObservaciones.Text = averia.GetObservaciones();

        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            string vars;
            string path;
            rst.Usuario user;
            HTTP.EnlaceHTTP enlace;
            
            enlace = new HTTP.EnlaceHTTP();
            user = rst.Usuario.GetInstance();
            path = "RSTmobile/servidor/controller/MobileSenalController.php";

            averia.GetSenal().SetIDAveria("S");
            averia.GetSenal().SetIDEstado(2);

            vars = "id_op=3" +
                   "&id_senal=" + averia.GetSenal().GetID() +
                   "&fechaAveria=" + HttpUtility.UrlEncode(averia.GetFechaAveria()) +
                   "&loginRegistro=" + user.GetLogin() +
                   "&idMotivo=" + "" + averia.GetIDMotivo() +
                   "&observaciones=" + HttpUtility.UrlEncode(labelObservaciones.Text) +
                   "&estado=" + averia.GetSenal().GetIDEstado() +
                   "&averia=" + averia.GetSenal().GetIDAveria();
            
            try
            {
                enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, user.GetServer(), path);
                MessageBox.Show("Averia registrada exitosamente");
                RSTmobile.controller.RSTApp rstapp = RSTmobile.controller.RSTApp.GetInstance();
                FMenu fmenu = rstapp.GetMenu();
                fmenu.Show();
                this.Hide();
            }
            catch //(WebException)
            {
                MessageBox.Show("Conexión fallida con el servidor. Verifique la red inalámbrica e intente de nuevo");
            }
        }
    }
}