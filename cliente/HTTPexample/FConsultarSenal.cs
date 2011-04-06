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
            ubicacion = Ubicacion.Ubicacion.GetInstance();
            transito = Transito.Senal.GetInstance();
        }

        private void FConsultarSenal_Load(object sender, EventArgs e)
        {
            listaEstados = ubicacion.GetEstados();
            listaTipoSen = transito.GetTipoSenal();

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
            //comboCategoria.SelectedIndex = 0;
            //comboSenal.SelectedIndex = 0;
            comboEntidad.SelectedIndex = 0;
            //comboMunicipio.SelectedIndex = 0;
            //comboParroquia.SelectedIndex = 0;

            
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
                listaCategSen = transito.GetCategoriaSenal(idTipoSenalActual);

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
                    listaCategSen = transito.GetCategoriaSenal(idTipoSenalActual);
            
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
            
            selectedIndex = comboEntidad.SelectedIndex;

            if (listaEstados == null)
                listaEstados = ubicacion.GetEstados();
            
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
            
            if (!codEstado.Equals(""))
            {
                if (listaMunicipios == null)
                    listaMunicipios = ubicacion.GetMunicipios(codEstado);

                selectedIndex = comboMunicipio.SelectedIndex;

                if (selectedIndex != 0)
                {
                    aux = (Ubicacion.Entidad)listaMunicipios[selectedIndex - 1];
                    listaParroquias = ubicacion.GetParroquias(aux.id);

                    foreach (Ubicacion.Entidad data in listaParroquias)
                    {
                        this.comboParroquia.Items.Add(data.descripcion);
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ubicacion.Entidad edo;
            Ubicacion.Entidad mun;
            Ubicacion.Entidad par;
            // Datos obtenidos del form3
            string login = "";
            string codMunicipio = "";
            string codParroquia = "";
            string idTipoSen = "";
            string idCategSen = "";
            string idSenalTra = "";
            string vars;
            rst.Usuario user;
            string domainName;
            string path = "RSTmobile/servidor/controller/MobileSenalController.php";
            Stream stream;
            //string xml = "";
            string currentNode = "";
            HTTP.EnlaceHTTP enlace = new HTTP.EnlaceHTTP();

            user = rst.Usuario.GetInstance();
            login = user.GetLogin();
            domainName = user.GetServer();

            if (comboEntidad.SelectedIndex != 0)
            {
                edo = (Ubicacion.Entidad)listaEstados[comboEntidad.SelectedIndex-1];
                codEstado = edo.id;
                if (listaMunicipios != null && comboMunicipio.SelectedIndex != 0)
                {
                    mun = (Ubicacion.Entidad)listaMunicipios[comboMunicipio.SelectedIndex-1];
                    codMunicipio = mun.id;
                    if (listaParroquias != null && comboParroquia.SelectedIndex != 0)
                    {
                        par = (Ubicacion.Entidad)listaParroquias[comboParroquia.SelectedIndex-1];
                        codParroquia = par.id;
                    }
                }
            }
            idTipoSen = idTipoSenalActual;
            idCategSen = idCategSenalActual;
            idSenalTra = idSenalTransitoActual;

            XmlTextReader xmlReader;

            //MessageBox.Show(codEstado + " " + codMunicipio + " " + codParroquia + " " + idTipoSen + " " + idCategSen + " " + idSenalTra);

            //if (idTipoSen != "" && idCategSen != "" && idSenalTra != "" && codEstado != "" && codMunicipio != "" &&
            //   ((codParroquia == "" && codEstado == "DF") || (codParroquia != "" && codEstado != "DF")) ) 
            //    {
                    vars = "id_op=1&id_tipo_sen=" + idTipoSen +
                        "&id_categ_sen=" + idCategSen + "&id_senal_tra=" + idSenalTra +
                        "&cod_estado=" + codEstado + "&cod_municipio=" + codMunicipio +
                        "&cod_parroquia=" + codParroquia + "&login="+login;
                    
                    Transito.SenalTransito senal = new Transito.SenalTransito();
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
                                            senal.setID(Convert.ToInt32(xmlReader.GetAttribute(0)));
                                        }
                                        break;
                                    case XmlNodeType.EndElement:
                                        // i.e. </rst>
                                        break;
                                    case XmlNodeType.Text:
                                        switch (currentNode)
                                        {
                                            case "rst":
                                                break;
                                            case "senal":
                                                break;
                                            case "x"://Convert.ToDouble
                                                senal.setX(xmlReader.Value);
                                                break;
                                            case "y":
                                                senal.setY(xmlReader.Value);
                                                break;
                                            case "tipo"://Convert.ToInt32(
                                                senal.setIDTipo(xmlReader.Value);
                                                break;
                                            case "categoria":
                                                senal.setIDCategoria(xmlReader.Value);
                                                break;
                                            case "descripcion":
                                                senal.setIDSenal(xmlReader.Value);
                                                break;
                                            case "estado":
                                                senal.setIDEstado(Convert.ToInt32(xmlReader.Value.ToString()));
                                                break;
                                            case "estatus":
                                                senal.setIDEstatus(xmlReader.Value.ToString());
                                                break;
                                            case "entidad":
                                                senal.setCodEstado(xmlReader.Value.ToString());
                                                break;
                                            case "municipio":
                                                senal.setCodMunicipio(xmlReader.Value.ToString());
                                                break;
                                            case "parroquia":
                                                senal.setCodParroquia(xmlReader.Value.ToString());
                                                break;
                                            case "averia":
                                                senal.setIDAveria(xmlReader.Value.ToString());
                                                break;
                                            default:
                                                break;
                                        } 
                                        break;
                                    default:
                                        //xml += "" + xmlReader.NodeType;
                                        break;
                                }
                            }
                            
                            FSenal fsenal = new FSenal();
                            fsenal.SetSenal(senal);
                            fsenal.Show();
                            this.Hide();
                            
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
                        MessageBox.Show("Asegurese de estar en un lugar con buena señal e intente de nuevo");
                    }
                    
              //  }
              //  return;
            }
           
        

        private void button2_Click(object sender, EventArgs e)
        {
            RSTmobile.view.RSTApp rstapp = RSTmobile.view.RSTApp.GetInstance();
            FMenu fmenu = rstapp.GetMenu();
            fmenu.Show();
            this.Hide();
        }

    }
}