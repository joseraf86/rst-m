using System;
using System.Windows.Forms;
using Transito;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;

namespace RSTmobile.controller
{
    public partial class FRepararAveria : Form
    {
        private Averia averia;
        private Averia averiaReparada;

        public FRepararAveria()
        {
            InitializeComponent();
        }

        public void SetAveria( Averia averia ) {
            this.averia = averia;

            rst.Usuario user = rst.Usuario.GetInstance();
            averiaReparada = new Averia(averia.GetSenal());
            averiaReparada.SetID( averia.GetID() );
            averiaReparada.SetIDMotivo(averia.GetIDMotivo());
            averiaReparada.SetIDStatus(averia.GetIDStatus());
            averiaReparada.SetFechaAveria(averia.GetFechaAveria());
            averiaReparada.SetFechaReparacion(pickerFecha.Value.ToString("dd/MM/yyyy"));
            averiaReparada.SetLoginRegistro(averia.GetLoginRegistro());
            averiaReparada.SetLoginReparacion(user.GetLogin());
            averiaReparada.SetObservaciones(averia.GetObservaciones());
            averiaReparada.SetRutaIMG1(averia.GetRutaIMG1());
            averiaReparada.SetRutaIMG2(averia.GetRutaIMG2());
            averiaReparada.SetRutaIMG3(averia.GetRutaIMG3());

            textBoxObservaciones.Text = averiaReparada.GetObservaciones();
            pickerFecha.MinDate = Convert.ToDateTime(averiaReparada.GetFechaAveria());
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {

            RSTApp rstapp = RSTApp.GetInstance();
            //rstapp.GetAveria();
            FMenu menu = rstapp.GetMenu();
            menu.Show();
            this.Hide();
        }

        private void buttonReparar_Click(object sender, EventArgs e)
        {       
                string vars = "";
                rst.Usuario user;
                string path = "RSTmobile/servidor/controller/MobileAveriaController.php";
                Stream stream = null;
                HTTP.EnlaceHTTP enlace;                

                user = rst.Usuario.GetInstance();
                enlace = new HTTP.EnlaceHTTP(); 

                vars = "id_op=5&id_averia=" + averia.GetID() +
                       "&login=" + user.GetLogin();

                try
                {
                    stream = enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, user.GetServer(), path);
                }
                catch (WebException) {
                    MessageBox.Show("Asegúrese de estar en un lugar con buena señal e intente de nuevo");
                }
        }

        private void pickerFecha_ValueChanged(object sender, EventArgs e)
        {
            averiaReparada.SetFechaReparacion(pickerFecha.Value.ToString("dd/MM/yyyy"));
        }

        private void textBoxObservaciones_TextChanged(object sender, EventArgs e)
        {
            averiaReparada.SetObservaciones(HttpUtility.UrlEncode(textBoxObservaciones.Text));
            textBoxObservaciones.Text = averiaReparada.GetObservaciones();
        }

    }
}