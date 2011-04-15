using System;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Net;
using System.Collections;

namespace RSTmobile
{
    public partial class FConsultarSenal : Form
    {
        private string idTipoSenalActual;
        private string idCategSenalActual;
        private string idSenalTransitoActual;
        private string codEstado;
        private string codMunicipio;
        private string codParroquia;
        private Ubicacion.Ubicacion ubicacion;
        private Transito.Senal transito;
        private ArrayList listaEstados;
        private ArrayList listaMunicipios;
        private ArrayList listaParroquias;
        private ArrayList listaSenalesTra;
        private ArrayList listaCategSen;
        private ArrayList listaTipoSen;
        
        public FConsultarSenal()
        {
            InitializeComponent();
            idTipoSenalActual = "";
            idCategSenalActual = "";
            idSenalTransitoActual = "";
            codEstado = "";
            codMunicipio = "";
            codParroquia = "";
            ubicacion = Ubicacion.Ubicacion.GetInstance();
            transito = Transito.Senal.GetInstance();
        }

        private void FConsultarSenal_Load(object sender, EventArgs e)
        {
            listaEstados = ubicacion.GetEstados();
            listaTipoSen = transito.GetTipos();

            foreach (Ubicacion.Entidad edo in listaEstados)
            {
                this.comboEntidad.Items.Add(edo.descripcion);
            }

            foreach (Transito.Indicador edo in listaTipoSen)
            {
                this.comboTipo.Items.Add(edo.descripcion);
            }
            // En los comboboxes se coloca la opción TODOS como predeterminada 
            comboTipo.SelectedIndex = 0;
            comboEntidad.SelectedIndex = 0;
            
        }

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            Transito.Indicador aux;

            comboCategoria.Items.Clear();
            comboSenal.Items.Clear();
            comboCategoria.Items.Add("TODOS");
            comboSenal.Items.Add("TODOS");
            comboCategoria.SelectedIndex = 0;
            comboSenal.SelectedIndex = 0;
            idCategSenalActual = "";
            idSenalTransitoActual = "";

            selectedIndex = comboTipo.SelectedIndex;
            if (selectedIndex != 0) 
            {
                // comboTipo NO esta en la opcion TODOS
                // listaTipoSen no contiene opcion TODOS => selectedIndex - 1
                aux = (Transito.Indicador)listaTipoSen[selectedIndex - 1];
                idTipoSenalActual = aux.id;
                listaCategSen = transito.GetCategorias(idTipoSenalActual);

                foreach (Transito.Indicador data in listaCategSen)
                {
                    this.comboCategoria.Items.Add(data.descripcion);
                }
            }
            else
            {
                // comboTipo esta en la opcion TODOS
                idTipoSenalActual = "";
            }
        }

        private void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            Transito.Indicador aux;

            comboSenal.Items.Clear();
            comboSenal.Items.Add("TODOS");
            comboSenal.SelectedIndex = 0;
            idSenalTransitoActual = "";
           
            if (!idTipoSenalActual.Equals(""))
            {
                if (listaCategSen == null)
                    listaCategSen = transito.GetCategorias(idTipoSenalActual);
            
                selectedIndex = comboCategoria.SelectedIndex;
                 if (selectedIndex != 0)
                {
                    aux = (Transito.Indicador)listaCategSen[selectedIndex - 1];
                    idCategSenalActual = aux.id;
                    listaSenalesTra = transito.GetSenales(idTipoSenalActual, idCategSenalActual);

                    foreach (Transito.Indicador data in listaSenalesTra)
                    {
                        this.comboSenal.Items.Add(data.descripcion);
                    }
                    return;
                }
                else
                    idCategSenalActual = "";
            } 
            
        }

        private void comboSenal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transito.Indicador aux;
            transito = Transito.Senal.GetInstance();

            if ( !idTipoSenalActual.Equals("") && !idCategSenalActual.Equals("") ) {

                if (listaSenalesTra == null)
                    listaSenalesTra = transito.GetSenales(idTipoSenalActual, idCategSenalActual);

                if (comboSenal.SelectedIndex != 0)
                {
                    aux = (Transito.Indicador)listaSenalesTra[comboSenal.SelectedIndex-1];
                    idSenalTransitoActual = aux.id;
                    return;
                }
            }
            idSenalTransitoActual = "";
        }

        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            Ubicacion.Entidad aux;

            comboMunicipio.Items.Clear();
            comboParroquia.Items.Clear();
            comboParroquia.Items.Add("TODOS");
            comboMunicipio.Items.Add("TODOS");
            comboMunicipio.SelectedIndex = 0;
            comboParroquia.SelectedIndex = 0;
            codMunicipio = "";
            codParroquia = "";

            if (listaEstados == null)
                listaEstados = ubicacion.GetEstados();

            selectedIndex = comboEntidad.SelectedIndex;
            if (selectedIndex != 0)
            {
                aux = (Ubicacion.Entidad)listaEstados[selectedIndex-1];
                codEstado = aux.id;
                listaMunicipios = ubicacion.GetMunicipios(codEstado);

                foreach (Ubicacion.Entidad data in listaMunicipios)
                {
                    this.comboMunicipio.Items.Add(data.descripcion);
                }
            }
            else
            {
                codEstado = "";
            }
        }

        private void comboMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int selectedIndex = 0;
            Ubicacion.Entidad aux;

            comboParroquia.Items.Clear();
            comboParroquia.Items.Add("TODOS");
            comboParroquia.SelectedIndex = 0;
            codParroquia = "";

            if (!codEstado.Equals(""))
            {
                if (listaMunicipios == null)
                    listaMunicipios = ubicacion.GetMunicipios(codEstado);

                selectedIndex = comboMunicipio.SelectedIndex;

                if (selectedIndex != 0)
                {
                    aux = (Ubicacion.Entidad)listaMunicipios[selectedIndex - 1];
                    codMunicipio = aux.id;
                    listaParroquias = ubicacion.GetParroquias(codMunicipio);

                    foreach (Ubicacion.Entidad data in listaParroquias)
                    {
                        this.comboParroquia.Items.Add(data.descripcion);
                    }
                }
                else
                    codMunicipio = "";
            }
            
        }

        private void comboParroquia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex;
            Ubicacion.Entidad aux;

            if (!codEstado.Equals("") && !codMunicipio.Equals(""))
            {
                if (listaParroquias == null)
                    listaParroquias = ubicacion.GetParroquias(codMunicipio);

                selectedIndex = comboParroquia.SelectedIndex;

                if (selectedIndex != 0)
                {
                    aux = (Ubicacion.Entidad)listaParroquias[selectedIndex - 1];
                    codParroquia = aux.id;
                }
                else
                    codParroquia = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vars;
            rst.Usuario user;
            string domainName;
            string path = "RSTmobile/servidor/controller/MobileSenalController.php";
            Stream stream;
            string currentNode = "";
            HTTP.EnlaceHTTP enlace = new HTTP.EnlaceHTTP();
            XmlTextReader xmlReader;

            user = rst.Usuario.GetInstance();
            domainName = user.GetServer();

            //MessageBox.Show(codEstado + " " + codMunicipio + " " + codParroquia + " " + idTipoSen + " " + idCategSen + " " + idSenalTra);

            vars = "id_op=1&id_tipo_sen=" + idTipoSenalActual +
                   "&id_categ_sen=" + idCategSenalActual +
                   "&id_senal_tra=" + idSenalTransitoActual +
                   "&cod_estado=" + codEstado +
                   "&cod_municipio=" + codMunicipio +
                   "&cod_parroquia=" + codParroquia +
                   "&login=" + user.GetLogin();

            Transito.SenalTransito senal = null;
            ArrayList senales = new ArrayList();
            try
            {
                stream = enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, domainName, path);
                if (stream != null)
                {
                    xmlReader = new XmlTextReader(stream);

                    while (xmlReader.Read())
                    {
                        switch (xmlReader.NodeType)
                        {
                            case XmlNodeType.Element:
                                // i.e. <rst>
                                currentNode = xmlReader.LocalName;
                                if (currentNode == "senal")
                                {
                                    senal = new Transito.SenalTransito();
                                    senal.SetID(Convert.ToInt32(xmlReader.GetAttribute(0)));
                                }
                                break;
                            case XmlNodeType.EndElement:
                                // i.e. </rst>
                                currentNode = xmlReader.LocalName;
                                if (currentNode == "senal")
                                {
                                    //MessageBox.Show(senal.ToString());
                                    senales.Add(senal);
                                }
                                break;
                            case XmlNodeType.Text:
                                switch (currentNode)
                                {
                                    case "rst":
                                        break;
                                    case "senal":
                                        break;
                                    case "x"://Convert.ToDouble
                                        senal.SetX(xmlReader.Value);
                                        break;
                                    case "y":
                                        senal.SetY(xmlReader.Value);
                                        break;
                                    case "tipo"://Convert.ToInt32(
                                        senal.SetIDTipo(xmlReader.Value);
                                        break;
                                    case "categoria":
                                        senal.SetIDCategoria(xmlReader.Value);
                                        break;
                                    case "descripcion":
                                        senal.SetIDSenal(xmlReader.Value);
                                        break;
                                    case "estado":
                                        senal.SetIDEstado(Convert.ToInt32(xmlReader.Value.ToString()));
                                        break;
                                    case "estatus":
                                        senal.SetIDEstatus(xmlReader.Value.ToString());
                                        break;
                                    case "entidad":
                                        senal.SetCodEstado(xmlReader.Value.ToString());
                                        break;
                                    case "municipio":
                                        senal.SetCodMunicipio(xmlReader.Value.ToString());
                                        break;
                                    case "parroquia":
                                        senal.SetCodParroquia(xmlReader.Value.ToString());
                                        break;
                                    case "averia":
                                        senal.SetIDAveria(xmlReader.Value.ToString());
                                        break;
                                    case "observaciones":
                                        senal.SetObservaciones(xmlReader.Value.ToString());
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    if (senales.Count > 0)
                    {
                        view.FSenales fsenales = new RSTmobile.view.FSenales();
                        view.RSTApp rstapp = view.RSTApp.GetInstance();
                        rstapp.SetSenales(fsenales);
                        fsenales.SetSenales(senales);
                        fsenales.Show();
                        this.Hide();
                    }
                    else 
                        MessageBox.Show("No se encontraron señales con las opciones especificadas");
    
                    /*
                    if (senal != null)
                    {
                        view.RSTApp rstapp = view.RSTApp.GetInstance();
                        FSenal fsenal = rstapp.GetSenal();
                        fsenal.SetSenal(senal);
                        fsenal.Show();
                        this.Hide();
                    }
                     */
                    //    MessageBox.Show("No se encontraron señales");

                }

            }
            catch (FormatException)
            {
                MessageBox.Show("El formato del XML recibido no es valido");

                RSTmobile.view.RSTApp rstapp = RSTmobile.view.RSTApp.GetInstance();
                FMenu fmenu = rstapp.GetMenu();
                fmenu.Show();
                this.Hide();
            }
            catch (WebException)
            {
                MessageBox.Show("Asegúrese de estar en un lugar con buena señal e intente de nuevo");
            }

        }

        private void boVolver_Click(object sender, EventArgs e)
        {
            RSTmobile.view.RSTApp rstapp = RSTmobile.view.RSTApp.GetInstance();
            FMenu fmenu = rstapp.GetMenu();
            fmenu.Show();
            this.Hide();
        }

        private void botonReset_Click(object sender, EventArgs e)
        {
            comboTipo.Items.Clear();
            comboCategoria.Items.Clear();
            comboSenal.Items.Clear();
            comboTipo.Items.Add("TODOS");
            comboCategoria.Items.Add("TODOS");
            comboSenal.Items.Add("TODOS");
            
            comboEntidad.Items.Clear();
            comboMunicipio.Items.Clear();
            comboParroquia.Items.Clear();
            comboEntidad.Items.Add("TODOS");
            comboMunicipio.Items.Add("TODOS");
            comboParroquia.Items.Add("TODOS");


            listaEstados = ubicacion.GetEstados();
            listaTipoSen = transito.GetTipos();

            foreach (Ubicacion.Entidad edo in listaEstados)
            {
                this.comboEntidad.Items.Add(edo.descripcion);
            }

            foreach (Transito.Indicador edo in listaTipoSen)
            {
                this.comboTipo.Items.Add(edo.descripcion);
            }


            comboTipo.SelectedIndex = 0;
            comboCategoria.SelectedIndex = 0;
            comboSenal.SelectedIndex = 0;

            comboEntidad.SelectedIndex = 0;
            comboMunicipio.SelectedIndex = 0;
            comboParroquia.SelectedIndex = 0;
        }

        private void label4_ParentChanged(object sender, EventArgs e)
        {

        }

    }
}