using System;
using System.Collections;
using System.Windows.Forms;

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

        private void button1_Click(object sender, EventArgs e)
        {
            RSTmobile.view.RSTApp rstapp = RSTmobile.view.RSTApp.GetInstance();
            FMenu fmenu = rstapp.GetMenu();
            fmenu.Show();
            this.Hide();
        }

        public void SetSenal(Transito.SenalTransito senal)
        {
            this.senal = senal;
            averia = new Transito.Averia();
        }

        private void botonNotificar_Click(object sender, EventArgs e)
        {
            string vars;
            
            rst.Usuario user;
            user = rst.Usuario.GetInstance();
            //observaciones.Text
            vars = "id_op=3" +
                   "&id_senal=" + senal.GetID() +
                   "&fechaAveria=" + fechaAveria.Value.ToString() +
                   "&loginRegistro=" + user.GetLogin() +
                   "&idMotivo=" + "" + averia.GetIDMotivo() +
                   "&observaciones=" + "";
            // "&loginReparacion=" + "&fechaReparacion" +"&idStatus" +
            MessageBox.Show(fechaAveria.Value.ToString());
            try
            {
                //enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, user.GetServer(), path);
                //MessageBox.Show("Averia registrada exitosamente");
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