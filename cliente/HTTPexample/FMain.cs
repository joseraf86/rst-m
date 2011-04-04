using System;
using System.Net;
using System.Windows.Forms;
using System.IO;

namespace RSTmobile
{

    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rst.Usuario user = rst.Usuario.GetInstance();
            HTTP.EnlaceHTTP enlace;
            HTTP.Cifrado cifrado;
            string domainName = "";
            string path = "rst-m/controller/SessionController.php";
            string login = "";
            string password = "";
            string respuesta = "";
            string vars = "";
            string hashedDID = "";
            string hashedPassword = "";
            Stream stream;
            StreamReader reader;

            cifrado = new HTTP.Cifrado();
            enlace = new HTTP.EnlaceHTTP();
            domainName = textBox1.Text;
            login = textBox2.Text;
            password = textBox3.Text;
            user.SetServer(domainName);
            hashedDID = user.GetDID();
            hashedPassword = cifrado.MD5(password);
            vars = "login=" + login + "&password=" + hashedPassword + "&did=" + hashedDID;

            try
            {
                stream = enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, domainName, path);
                reader = new StreamReader(stream);
                respuesta = reader.ReadToEnd();
                reader.Close();
                
                if (respuesta == "OK")
                {
                    user.SetLogin(login);
                    user.SetPassword(hashedPassword);
                    new FMenu().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Datos incorrectos. Intente de nuevo");
                }
    
            }
            catch (WebException)
            {
                MessageBox.Show("Conexión fallida con el servidor. Verifique la red inalámbrica e intente de nuevo ");
            }
            finally
            {
                //postData.Close();
                //reader.Close();
            }
        }

    }
}