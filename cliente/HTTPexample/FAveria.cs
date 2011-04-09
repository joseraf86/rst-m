using System;
using System.Collections;
using System.Windows.Forms;
using System.Web;

namespace RSTmobile
{
    public partial class FAveria : Form
    {
        private Transito.SenalTransito senal;
        private ArrayList listaMotivos;
        private Transito.Averia averia;

        public FAveria()
        {
            InitializeComponent();
        }

        public void SetSenal(Transito.SenalTransito senal)
        {
            this.senal = senal;
            averia = new Transito.Averia();
        }

        private void FAveria_Load(object sender, EventArgs e)
        {
            Transito.Senal senales;

            senales = Transito.Senal.GetInstance();
            listaMotivos = senales.ConsultarMotivo();
            foreach (Transito.Indicador data in listaMotivos)
            {
                this.comboMotivos.Items.Add(data.descripcion);
            }
            comboMotivos.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RSTmobile.view.RSTApp rstapp = RSTmobile.view.RSTApp.GetInstance();
            FMenu fmenu = rstapp.GetMenu();
            fmenu.Show();
            this.Hide();
        }

        private void fechaAveria_ValueChanged(object sender, EventArgs e)
        {
            averia.SetFechaAveria(fechaAveria.Value.ToShortDateString());
        }

        private void botonNotificar_Click(object sender, EventArgs e)
        {
            string vars;
            string path;
            rst.Usuario user;
            HTTP.EnlaceHTTP enlace;
            string fecha = HttpUtility.UrlEncode(averia.GetFechaAveria());

            MessageBox.Show(fecha);

            enlace = new HTTP.EnlaceHTTP();
            user = rst.Usuario.GetInstance();
            path = "RSTmobile/servidor/controller/MobileSenalController.php";
            vars = "id_op=3" +
                   "&id_senal=" + senal.GetID() +
                   "&fechaAveria=" + HttpUtility.UrlEncode(averia.GetFechaAveria()) +
                   "&loginRegistro=" + user.GetLogin() +
                   "&idMotivo=" + "" + averia.GetIDMotivo() +
                   "&observaciones=" + HttpUtility.UrlEncode(observaciones.Text);
            // "&loginReparacion=" + "&fechaReparacion" +"&idStatus" +
            try
            {
                enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, user.GetServer(), path);
                MessageBox.Show("Averia registrada exitosamente");
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

        private void comboMotivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transito.Indicador aux;
            if (listaMotivos != null)
            {
                aux = (Transito.Indicador)listaMotivos[comboMotivos.SelectedIndex];
                averia.SetIDMotivo(aux.id);
            }
            else
                MessageBox.Show("Opps... ocurrio un error en la lista de motivos");
        }

        
    }
}