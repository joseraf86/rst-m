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
    public partial class FConfirmarSenal : Form
    {
        private Transito.SenalTransito senal;

        public FConfirmarSenal()
        {
            InitializeComponent();
        }

        public void SetSenal(Transito.SenalTransito senal)
        {
            this.senal = senal;

            labelCoordX.Text = senal.GetX();
            labelCoordY.Text = senal.GetY();

            labelTipo.Text = senal.GetIDTipo();
            labelCategoria.Text = senal.GetIDCategoria();
            labelSenal.Text = senal.GetIDSenal();

            labelEstado.Text = "" + senal.GetIDEstado();
            labelEstatus.Text = senal.GetIDEstatus();

            labelEntidad.Text = senal.GetCodEstado();
            labelMunicio.Text = senal.GetCodMunicipio();
            labelParroquia.Text = senal.GetCodParroquia();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            RSTApp app = RSTApp.GetInstance();
            FSenal fsenal = app.GetSenal();
            fsenal.Show();
        }

        private void botonActualizar_Click(object sender, EventArgs e)
        {
            string vars;
            HTTP.EnlaceHTTP enlace;
            rst.Usuario user;

            string path = "RSTmobile/servidor/controller/MobileSenalController.php";

            user = rst.Usuario.GetInstance();
            enlace = new HTTP.EnlaceHTTP();
 
            vars = "id_op=4&coord_x=" + senal.GetX() + "&coord_y=" + senal.GetY() + "&id_tipo_sen=" + senal.GetIDTipo() +
                   "&id_categ_sen=" + senal.GetIDCategoria() + "&id_senal_tra=" + senal.GetIDSenal() + 
                   "&id_estad_sen=" + senal.GetIDEstado() +
                   "&id_status_sen=" + senal.GetIDEstatus() + "&averia=N&cod_estado=" + senal.GetCodEstado() + 
                   "&cod_municipio=" + senal.GetCodMunicipio() + "&cod_parroquia=" + senal.GetCodParroquia() +
                   "&login=" + user.GetLogin();
                   //+ "&observaciones=" + observaciones;

            try
            {
                enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, user.GetServer(), path);
                MessageBox.Show("Señal actualizada exitosamente");

                RSTmobile.view.RSTApp rstapp = RSTmobile.view.RSTApp.GetInstance();
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