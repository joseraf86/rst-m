using System;
using System.IO;
using System.Net;
using System.Web;
using System.Windows.Forms;
using RSTmobile.controller;
using Transito;

namespace RSTmobile.view
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
            averiaReparada.SetMotivo( averia.GetIDMotivo(), averia.GetMotivo() );
            averiaReparada.SetIDStatus(averia.GetIDStatus());
            averiaReparada.SetFechaAveria(averia.GetFechaAveria());
            //averiaReparada.SetFechaReparacion(pickerFecha.Value.ToString("dd/MM/yyyy"));
            averiaReparada.SetLoginRegistro(averia.GetLoginRegistro());
            averiaReparada.SetLoginReparacion(user.GetLogin());
            averiaReparada.SetObservaciones(averia.GetObservaciones());
            averiaReparada.SetRutaIMG1(averia.GetRutaIMG1());
            averiaReparada.SetRutaIMG2(averia.GetRutaIMG2());
            averiaReparada.SetRutaIMG3(averia.GetRutaIMG3());
        }

        private void FRepararAveria_Load(object sender, EventArgs e)
        {
            textBoxObservaciones.Text = averiaReparada.GetObservaciones();
            pickerFecha.MinDate = Convert.ToDateTime(averiaReparada.GetFechaAveria());
            averiaReparada.SetFechaReparacion(pickerFecha.Value.ToString("dd/MM/yyyy"));
            //MessageBox.Show(averiaReparada.GetFechaReparacion());
        }

        private void pickerFecha_ValueChanged(object sender, EventArgs e)
        {
            averiaReparada.SetFechaReparacion(pickerFecha.Value.ToString("dd/MM/yyyy"));
        }

        private void textBoxObservaciones_TextChanged(object sender, EventArgs e)
        {
            averiaReparada.SetObservaciones(textBoxObservaciones.Text);
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            RSTApp rstapp = RSTApp.GetInstance();
            FSenal fsenal = rstapp.GetSenal();
            fsenal.Show();
            this.Dispose();
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
                
                vars = "id_op=4" +
                       "&id_averia=" + averiaReparada.GetID() +
                       "&id_senal=" + averiaReparada.GetSenal().GetID() +
                       "&fecha=" + HttpUtility.UrlEncode(averiaReparada.GetFechaReparacion()) +
                       "&login=" + user.GetLogin() +
                       "&observaciones=" + HttpUtility.UrlEncode(averiaReparada.GetObservaciones());

                try
                {
                    stream = enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, user.GetServer(), path);
                    MessageBox.Show("Averia reparada exitosamente");

                    RSTApp rstapp = RSTApp.GetInstance();
                    FSenal fsenal = rstapp.GetSenal();
                    fsenal.Show();
                    this.Dispose();

                }
                catch (WebException) {
                    MessageBox.Show("Asegúrese de estar en un lugar con buena señal e intente de nuevo");
                }
        }

    }
}