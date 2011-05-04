using System;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.IO;
using RSTmobile.controller;
using System.Xml;
using Transito;
using RST;

namespace RSTmobile.view
{
    public partial class FSenal : Form
    {
        private SenalTransito senalXML;
        private SenalTransito stActual;
        private ArrayList listaSenalesTra;
        private ArrayList listaCategSen;
        private ArrayList listaTiposSen;
        private ArrayList listaEntidad;
        private ArrayList listaMunicipios;
        private ArrayList listaParroquias;
        private ArrayList listaEstados;
        private ArrayList listaStatus;
        private Ubicacion.Ubicacion ubicacion;
        private Senal senales;

        public FSenal()
        {
            InitializeComponent();
            ubicacion = Ubicacion.Ubicacion.GetInstance();
            senales = Senal.GetInstance();
            stActual = new SenalTransito();
            init();
        }

        public void init()
        {

            listaEntidad = ubicacion.GetEstados();
            listaTiposSen = senales.GetTipos();

            comboTipo.Items.Clear();
            comboCategoria.Items.Clear();
            comboSenal.Items.Clear();
            comboEntidad.Items.Clear();
            comboMunicipio.Items.Clear();
            comboParroquia.Items.Clear();
            comboEstado.Items.Clear();
            comboEstatus.Items.Clear();

            comboTipo.Items.Add("SELECCIONE");
            comboCategoria.Items.Add("SELECCIONE");
            comboSenal.Items.Add("SELECCIONE");
            comboEntidad.Items.Add("SELECCIONE");
            comboMunicipio.Items.Add("SELECCIONE");
            comboParroquia.Items.Add("SELECCIONE");

            comboTipo.SelectedIndex = 0;
            comboCategoria.SelectedIndex = 0;
            comboSenal.SelectedIndex = 0;
            comboEntidad.SelectedIndex = 0;
            comboMunicipio.SelectedIndex = 0;
            comboParroquia.SelectedIndex = 0;

            foreach (Transito.Indicador aux in listaTiposSen)
            {
                comboTipo.Items.Add(aux.descripcion);
            }
            foreach (Ubicacion.Entidad aux in listaEntidad)
            {
                comboEntidad.Items.Add(aux.descripcion);
            }
        }

        public void SetSenal(SenalTransito senal)
        {

            int i = 0; //j = 0;

            senalXML = senal;
            stActual = new SenalTransito();
            stActual.SetX(senal.GetX());
            stActual.SetY(senal.GetY());
            stActual.SetID(senal.GetID());
            stActual.SetIDAveria(senal.GetIDAveria());
            stActual.SetObservaciones(senal.GetObservaciones());

            // Preparar listas segun valores del xml
            listaCategSen = senales.GetCategorias(senalXML.GetIDTipo());
            listaSenalesTra = senales.GetSenales(senalXML.GetIDTipo(), senalXML.GetIDCategoria());
            listaMunicipios = ubicacion.GetMunicipios(senalXML.GetCodEstado());
            listaParroquias = ubicacion.GetParroquias(senalXML.GetCodMunicipio());
            listaEstados = senales.ConsultarEstados();
            foreach (Celda cel in listaEstados)
            {
                 //MessageBox.Show("id "+cel.id+" descripcion "+cel.descripcion);
                 comboEstado.Items.Add(cel.descripcion);
                 if (cel.id.Equals(senalXML.GetIDEstado()))
                 {
                     comboEstado.SelectedIndex = i;
                     stActual.SetEstado(cel.id, cel.descripcion);

                 }
             }
            listaStatus = senales.ConsultarLosStatus();
            
            // cargas valores en componentes
            textBoxX.Text = senalXML.GetX();
            textBoxY.Text = senalXML.GetY();

            i = 1;
            foreach (Transito.Indicador aux in listaTiposSen)
            {
                if (aux.id.Equals(senalXML.GetIDTipo()))
                {
                    comboTipo.SelectedIndex = i;
                    stActual.SetTipo(aux.id, aux.descripcion);
                }
                i++;
            }
            i = 1;
            foreach (Transito.Indicador aux in listaCategSen)
            {
                comboCategoria.Items.Add(aux.descripcion);
                if (aux.id.Equals(senalXML.GetIDCategoria()))
                {
                    comboCategoria.SelectedIndex = i;
                    stActual.SetCategoria(aux.id, aux.descripcion);
                }
                i++;
            }
            i = 1;
            foreach (Transito.Indicador aux in listaSenalesTra)
            {
                comboSenal.Items.Add(aux.descripcion);
                if (aux.id.Equals(senalXML.GetIDSenal()))
                {
                    comboSenal.SelectedIndex = i;
                    stActual.SetSenal(aux.id, aux.descripcion);
                }
                i++;
            }
            i = 1;
            foreach (Ubicacion.Entidad aux in listaEntidad)
            {
                if (aux.id.Equals(senalXML.GetCodEstado()))
                {
                    comboEntidad.SelectedIndex = i;
                    stActual.SetEntidad(aux.id, aux.descripcion);
                }
                i++;
            }
            i = 1;
            foreach (Ubicacion.Entidad aux in listaMunicipios)
            {
                comboMunicipio.Items.Add(aux.descripcion);
                if (aux.id.Equals(senalXML.GetCodMunicipio()))
                {
                    comboMunicipio.SelectedIndex = i;
                    stActual.SetMunicipio(aux.id, aux.descripcion);
                }
                i++;
            }
            i = 1;
            foreach (Ubicacion.Entidad aux in listaParroquias)
            {
                comboParroquia.Items.Add(aux.descripcion);
                if (aux.id.Equals(senalXML.GetCodParroquia()))
                {
                    comboParroquia.SelectedIndex = i;
                    stActual.SetParroquia(aux.id, aux.descripcion);
                }
                i++;
            }
            i = 0;
                foreach (Celda aux in listaStatus)
                {
                    comboEstatus.Items.Add(aux.descripcion);
                    if (aux.id.Equals(senalXML.GetIDEstatus()))
                    {
                        comboEstatus.SelectedIndex = i; 
                        stActual.SetEstatus(aux.id, aux.descripcion);
                        
                    }
                    i++;
                }
           i = 0;
            /*
                foreach (Celda aux in listaEstados)
                {
                    comboEstado.Items.Add(aux.descripcion);
                    if (aux.id.Equals(senalXML.GetIDEstado()))
                    {
                        comboEstado.SelectedIndex = i;
                        stActual.SetEstado(aux.id, aux.descripcion);
                    }
                    i++;
                }
              */
          
            textBoxObservaciones.Text = senalXML.GetObservaciones();
        }

        //****************** Metodos Manejadores de Eventos **************************//

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transito.Indicador aux;
            int selectedIndex;
            string idTipo = "";
            string descTipo = "";

            selectedIndex = comboTipo.SelectedIndex;
            listaTiposSen = senales.GetTipos();

            if (selectedIndex != 0)
            {
                // la seleccion en el combo fue diferente de SELECCIONE
                // busco el id tipo en la lista
                aux = (Transito.Indicador)listaTiposSen[selectedIndex - 1];
                idTipo = aux.id;
                descTipo = aux.descripcion;
            }

            if (!stActual.GetIDTipo().Equals(idTipo))
            {
                // el valor de este combo ha sido modificado

                stActual.SetTipo(idTipo, descTipo);
                stActual.SetCategoria("", "");
                stActual.SetSenal("", "");
                comboCategoria.Items.Clear();
                comboSenal.Items.Clear();
                comboCategoria.Items.Add("SELECCIONE");
                comboSenal.Items.Add("SELECCIONE");
                comboCategoria.SelectedIndex = 0;
                comboSenal.SelectedIndex = 0;

                if (!idTipo.Equals(""))
                {
                    listaCategSen = senales.GetCategorias(idTipo);
                    foreach (Transito.Indicador data in listaCategSen)
                    {
                        comboCategoria.Items.Add(data.descripcion);
                    }
                }
            }
        }

        private void comboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transito.Indicador aux;
            int selectedIndex;
            string idCategoria = "";
            string descCategoria = "";

            selectedIndex = comboCategoria.SelectedIndex;
            if (selectedIndex != 0)
            {
                aux = (Transito.Indicador)listaCategSen[selectedIndex - 1];
                idCategoria = aux.id;
                descCategoria = aux.descripcion;
            }

            if (!stActual.Equals(idCategoria))
            {

                stActual.SetCategoria(idCategoria, descCategoria);
                stActual.SetSenal("", "");

                comboSenal.Items.Clear();
                comboSenal.Items.Add("SELECCIONE");
                comboSenal.SelectedIndex = 0;

                if (!idCategoria.Equals(""))
                {
                    listaSenalesTra = senales.GetSenales(stActual.GetIDTipo(), idCategoria);
                    foreach (Transito.Indicador data in listaSenalesTra)
                    {
                        comboSenal.Items.Add(data.descripcion);
                    }
                }
            }
        }

        private void comboSenal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transito.Indicador aux;
            int selectedIndex;
            string idSenal = "";
            string descSenal = "";

            selectedIndex = comboSenal.SelectedIndex;
            if (selectedIndex != 0)
            {
                //listaSenalesTra = senales.GetSenales(tipoActual, categoriaActual);
                aux = (Transito.Indicador)listaSenalesTra[selectedIndex - 1];
                idSenal = aux.id;
                descSenal = aux.descripcion;
            }

            if (!stActual.GetIDSenal().Equals(idSenal))
            {
                stActual.SetSenal(idSenal, descSenal);
            }

        }

        private void comboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ubicacion.Entidad aux;
            int selectedIndex;
            string codEntidad = "";
            string descEntidad = "";

            selectedIndex = comboEntidad.SelectedIndex;
            if (selectedIndex != 0)
            {
                listaEstados = ubicacion.GetEstados();
                aux = (Ubicacion.Entidad)listaEstados[selectedIndex - 1];
                codEntidad = aux.id;
                descEntidad = aux.descripcion;
            }

            if (!stActual.GetCodEstado().Equals(codEntidad))
            {
                stActual.SetEntidad(codEntidad, descEntidad);
                stActual.SetMunicipio("", "");
                stActual.SetParroquia("", "");

                comboMunicipio.Items.Clear();
                comboParroquia.Items.Clear();
                comboMunicipio.Items.Add("SELECCIONE");
                comboParroquia.Items.Add("SELECCIONE");
                comboMunicipio.SelectedIndex = 0;
                comboParroquia.SelectedIndex = 0;

                if (!codEntidad.Equals(""))
                {
                    listaMunicipios = ubicacion.GetMunicipios(codEntidad);

                    foreach (Ubicacion.Entidad data in listaMunicipios)
                    {
                        comboMunicipio.Items.Add(data.descripcion);
                    }
                }
            }
        }

        private void comboMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            Ubicacion.Entidad aux;
            string codMunicipio = "";
            string descMunicipio = "";

            selectedIndex = comboMunicipio.SelectedIndex;
            if (selectedIndex != 0)
            {
                aux = (Ubicacion.Entidad)listaMunicipios[selectedIndex - 1];
                codMunicipio = aux.id;
                descMunicipio = aux.descripcion;
            }

            if (!stActual.GetCodMunicipio().Equals(codMunicipio))
            {
                stActual.SetMunicipio(codMunicipio, descMunicipio);
                stActual.SetParroquia("", "");

                comboParroquia.Items.Clear();
                comboParroquia.Items.Add("SELECCIONE");
                comboParroquia.SelectedIndex = 0;

                if (!codMunicipio.Equals(""))
                {
                    listaParroquias = ubicacion.GetParroquias(codMunicipio);
                    foreach (Ubicacion.Entidad data in listaParroquias)
                    {
                        comboParroquia.Items.Add(data.descripcion);
                    }
                }
            }
        }

        private void comboParroquia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ubicacion.Entidad aux;
            int selectedIndex;
            string codParroquia = "";
            string descParroquia = "";

            selectedIndex = comboParroquia.SelectedIndex;
            if (selectedIndex != 0)
            {
                aux = (Ubicacion.Entidad)listaParroquias[selectedIndex - 1];
                codParroquia = aux.id;
                descParroquia = aux.descripcion;
            }
            stActual.SetParroquia(codParroquia, descParroquia);
        }

        private void textBoxObservaciones_TextChanged(object sender, EventArgs e)
        {
            stActual.SetObservaciones(textBoxObservaciones.Text);
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            stActual.SetX(textBoxX.Text);
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            stActual.SetY(textBoxY.Text);
        }

        // Botones

        private void botonAveria_Click(object sender, EventArgs e)
        {


        }

        private void boVolver_Click(object sender, EventArgs e)
        {
            RSTmobile.controller.RSTApp rst = RSTmobile.controller.RSTApp.GetInstance();
            FSenales fsenales = rst.GetSenales();
            fsenales.Show();
            this.Hide();
        }

        private void botonReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea deshacer los cambios realizados?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                init();
                SetSenal(senalXML);
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            if (!stActual.GetIDTipo().Equals("") && !stActual.GetIDCategoria().Equals("") &&
                !stActual.GetIDSenal().Equals("") &&
                !stActual.GetCodEstado().Equals("") && !stActual.GetCodMunicipio().Equals("") &&
                !stActual.GetCodParroquia().Equals(""))
            {
                FConfirmarSenal fconfirmar = new FConfirmarSenal();
                fconfirmar.SetSenal(stActual);
                fconfirmar.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios");
            }
        }

        private void botonNotificar_Click(object sender, EventArgs e)
        {
            Transito.Averia averia = null;
            if (stActual.GetIDAveria().Equals("S"))
            {
                //Solicitar al controlador (en el servidor) la averia segun Id de la señal
                string vars = "";
                rst.Usuario user;
                string path = "RSTmobile/servidor/controller/MobileAveriaController.php";
                Stream stream = null;
                HTTP.EnlaceHTTP enlace;
                XmlTextReader xmlReader = null;
                string currentNode = "";

                user = rst.Usuario.GetInstance();
                enlace = new HTTP.EnlaceHTTP();

                vars = "id_op=1&id_senal=" + stActual.GetID() +
                       "&login=" + user.GetLogin();

                try
                {
                    stream = enlace.Transferir(vars, HTTP.EnlaceHTTP.POST, user.GetServer(), path);
                    // Nota no puede utilizarse otro reader ademas de xmlreader, ya que este ultimo deja de funcionar
                    //reader = new StreamReader(stream);
                    //xml = reader.ReadToEnd();
                    //MessageBox.Show("Averia consultada: " + xml);
                    //reader.Close(); 
                    ////%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                    if (stream != null)
                    {
                        xmlReader = new XmlTextReader(stream);
                        xmlReader.WhitespaceHandling = WhitespaceHandling.None;
                        while (xmlReader.Read())
                        {
                            switch (xmlReader.NodeType)
                            {
                                case XmlNodeType.Element:
                                    // e.g. <rst>
                                    currentNode = xmlReader.LocalName;
                                    if (currentNode == "averia")
                                    {
                                        averia = new Transito.Averia(stActual);
                                        averia.SetID(xmlReader.GetAttribute(0));
                                    }
                                    break;
                                case XmlNodeType.EndElement:
                                    // e.g. </rst>
                                    currentNode = xmlReader.LocalName;
                                    if (currentNode == "averia")
                                    {
                                        //MessageBox.Show(senal.ToString());
                                        //senales.Add(senal);
                                    }
                                    break;
                                case XmlNodeType.Text:
                                    switch (currentNode)
                                    {
                                        case "rst":
                                            break;
                                        case "averia":
                                            break;
                                        case "senal":
                                            averia.SetSenal(stActual);
                                            break;
                                        case "motivo":
                                            string aux = xmlReader.Value.ToString();
                                            averia.SetMotivo(aux, senales.ConsultarMotivo(aux));
                                            break;
                                        case "fecha":
                                            averia.SetFechaAveria(xmlReader.Value.ToString());
                                            break;
                                        case "login":
                                            averia.SetLoginRegistro(xmlReader.Value.ToString());
                                            break;
                                        case "observaciones":
                                            averia.SetObservaciones(xmlReader.Value.ToString());
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    /////////

                }
                catch (WebException)
                {
                    MessageBox.Show("Asegúrese de estar en un lugar con buena señal e intente de nuevo");
                }
                catch (XmlException)
                {
                    // xml mal formado
                    MessageBox.Show("Los datos de la averia fueron dañados en la transmisión. Intente de nuevo");
                }
                catch (Exception)
                {
                    MessageBox.Show("Intente de nuevo");
                }
                finally
                {
                    if (stream != null)
                        stream.Close();
                    if (xmlReader != null)
                        xmlReader.Close();
                }
                if (averia != null)
                {
                    FConsultarAveria fcaveria = new FConsultarAveria();
                    fcaveria.SetAveria(averia);
                    fcaveria.Show();
                    this.Hide();
                    return;
                }
                
            }
            else
            {
                //confirmar si se desea registrar una averia nueva para esta señal
                if (MessageBox.Show("¿Desea notificar una averia nueva para esta señal?", "Alerta",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                       == DialogResult.Yes)
                {
                    //stActual.setIDAveria("S");
                    averia = new Transito.Averia(stActual);
                    FAveria faveria = new FAveria();
                    faveria.SetAveria(averia);
                    faveria.Show();
                    this.Hide();

                }
            }
        }

    }
}