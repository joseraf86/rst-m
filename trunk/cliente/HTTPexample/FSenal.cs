using System;
using System.Windows.Forms;
using System.Collections;

namespace RSTmobile
{
    public partial class FSenal : Form
    {
        private Transito.SenalTransito senalXML;
        private Transito.SenalTransito stActual;
        private ArrayList listaSenalesTra;
        private ArrayList listaCategSen;
        private ArrayList listaTiposSen;
        private ArrayList listaEstados;
        private ArrayList listaMunicipios;
        private ArrayList listaParroquias;
        private string entidadActual;
        private string municipioActual;
        private string parroquiaActual;
        private Ubicacion.Ubicacion ubicacion;
        private Transito.Senal senales;

        public FSenal()
        {
            InitializeComponent();
            ubicacion = Ubicacion.Ubicacion.GetInstance();
            senales = Transito.Senal.GetInstance();
            stActual = new Transito.SenalTransito();
            init();

        }

        public void init() {
            
            //Valores iniciales por defecto SELECCIONE
            entidadActual = "";
            municipioActual = "";
            parroquiaActual = "";
            
            listaEstados = ubicacion.GetEstados();
            listaTiposSen = senales.GetTipos();

            comboTipo.Items.Clear();
            comboCategoria.Items.Clear();
            comboSenal.Items.Clear();
            comboEntidad.Items.Clear();
            comboMunicipio.Items.Clear();
            comboParroquia.Items.Clear();

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
            foreach (Ubicacion.Entidad aux in listaEstados)
            {
                comboEntidad.Items.Add(aux.descripcion);
            }
        }

        public void SetSenal(Transito.SenalTransito senal) {
            senalXML = senal;
            stActual = new Transito.SenalTransito();
            stActual.SetID(senal.GetID());
            stActual.SetIDTipo(senal.GetIDTipo());
            stActual.SetIDCategoria(senal.GetIDCategoria());
            stActual.SetIDSenal(senal.GetIDSenal());
            stActual.SetIDEstado(senal.GetIDEstado());
            stActual.SetIDEstatus(senal.GetIDEstatus());
            stActual.SetCodEstado(senal.GetCodEstado());
            stActual.SetCodMunicipio(senal.GetCodMunicipio());
            stActual.SetCodParroquia(senal.GetCodParroquia());
            int i = 0;

            //init();

            // Preparar listas segun valores del xml
            listaCategSen = senales.GetCategorias(senalXML.GetIDTipo());
            listaSenalesTra = senales.GetSenales(senalXML.GetIDTipo(), senalXML.GetIDCategoria());
            listaMunicipios = ubicacion.GetMunicipios(senalXML.GetCodEstado());
            listaParroquias = ubicacion.GetParroquias(senalXML.GetCodMunicipio());
            
            // cargas valores de las listas en los comboxes
                i = 1;
                foreach (Transito.Indicador aux in listaTiposSen)
                {
                    // Selecciona el valor dado en el xml
                    if (aux.id.Equals(senalXML.GetIDTipo()))
                    {
                        comboTipo.SelectedIndex = i;
                    }
                    i++;
                }
                i = 1;
                foreach (Transito.Indicador aux in listaCategSen)
                {
                    comboCategoria.Items.Add(aux.descripcion);
                    if (aux.id.Equals(senalXML.GetIDCategoria()))
                        comboCategoria.SelectedIndex = i;
                    i++;
                }
                i = 1;
                foreach (Transito.Indicador aux in listaSenalesTra)
                {
                    comboSenal.Items.Add(aux.descripcion);
                    if (aux.id.Equals(senalXML.GetIDSenal()))
                        comboSenal.SelectedIndex = i;
                    i++;
                }
                i = 1;
                foreach (Ubicacion.Entidad aux in listaEstados)
                {
                    if (aux.id.Equals(senalXML.GetCodEstado()))
                    {
                        comboEntidad.SelectedIndex = i;
                    }
                    i++;
                }
                i = 1;
                municipioActual = senalXML.GetCodMunicipio();
                foreach (Ubicacion.Entidad aux in listaMunicipios)
                {
                    comboMunicipio.Items.Add(aux.descripcion);
                    if (aux.id.Equals(senalXML.GetCodMunicipio()))
                    {
                        comboMunicipio.SelectedIndex = i;
                        MessageBox.Show("" + i);
                    }
                    i++;
                }
                i = 1;
                parroquiaActual = senalXML.GetCodParroquia();
                foreach (Ubicacion.Entidad aux in listaParroquias)
                {
                    comboParroquia.Items.Add(aux.descripcion);
                    if (aux.id.Equals(parroquiaActual))
                        comboParroquia.SelectedIndex = i;
                    i++;
                }

                textBoxX.Text = senalXML.GetX();
                textBoxY.Text = senalXML.GetY();
                comboEstado.Items.Add("BUEN ESTADO");
                comboEstado.Items.Add("REGULAR");
                comboEstado.Items.Add("MAL ESTADO");
                comboEstado.SelectedIndex = senalXML.GetIDEstado() - 1;

                comboEstatus.Items.Add("ACTIVO");
                comboEstatus.Items.Add("INACTIVO");
                comboEstatus.SelectedIndex = 0;
            
        }
        
//****************** Metodos Manejadores de Eventos **************************//

        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transito.Indicador aux;
            int selectedIndex;
            string idTipo = "";

            selectedIndex = comboTipo.SelectedIndex;
            listaTiposSen = senales.GetTipos();

            if (selectedIndex != 0)
            {
                // la seleccion en el combo fue diferente de SELECCIONE
                // busco el id tipo en la lista
                aux = (Transito.Indicador)listaTiposSen[selectedIndex - 1];
                idTipo = aux.id;
            }

            if( !stActual.GetIDTipo().Equals(idTipo) ) {
                // el valor de este combo ha sido modificado

                stActual.SetIDTipo(idTipo);
                stActual.SetIDCategoria("");
                stActual.SetIDSenal("");
                
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

            selectedIndex = comboCategoria.SelectedIndex;
            if (selectedIndex != 0)
            {
                    aux = (Transito.Indicador)listaCategSen[selectedIndex - 1];
                    idCategoria = aux.id;
            }
            
            if (!stActual.Equals(idCategoria)){

                stActual.SetIDCategoria(idCategoria);
                stActual.SetIDSenal("");
                
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

            selectedIndex = comboSenal.SelectedIndex;
            if (selectedIndex != 0)
                {
                    //listaSenalesTra = senales.GetSenales(tipoActual, categoriaActual);
                    aux = (Transito.Indicador)listaSenalesTra[selectedIndex - 1];
                    idSenal = aux.id;
                }

            if (!stActual.GetIDSenal().Equals(idSenal))
            {
                stActual.SetIDSenal(idSenal);
            }

        }


        private void comboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ubicacion.Entidad aux;
            int selectedIndex;

            selectedIndex = comboEntidad.SelectedIndex;
            if (selectedIndex != 0) {
                listaEstados = ubicacion.GetEstados();
                aux = (Ubicacion.Entidad)listaEstados[selectedIndex-1];
                entidadActual = aux.id;
            }

            if ( !stActual.GetCodEstado().Equals(entidadActual) )
            {
                stActual.SetCodEstado(entidadActual);
                stActual.SetCodMunicipio("");
                stActual.SetCodParroquia("");

                comboMunicipio.Items.Clear();
                comboParroquia.Items.Clear();
                comboMunicipio.Items.Add("SELECCIONE");
                comboParroquia.Items.Add("SELECCIONE");
                comboMunicipio.SelectedIndex = 0;
                comboParroquia.SelectedIndex = 0;
                municipioActual = "";
                parroquiaActual = "";

                if (!entidadActual.Equals(""))
                {
                    listaMunicipios = ubicacion.GetMunicipios(entidadActual);

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
            
            selectedIndex = comboMunicipio.SelectedIndex;
            if (selectedIndex != 0)
            {
                aux = (Ubicacion.Entidad)listaMunicipios[selectedIndex - 1];
                municipioActual = aux.id;
            }

            if (!stActual.GetCodMunicipio().Equals(municipioActual))
            {
                stActual.SetCodMunicipio(municipioActual);
                stActual.SetCodParroquia("");

                comboParroquia.Items.Clear();
                comboParroquia.Items.Add("SELECCIONE");
                comboParroquia.SelectedIndex = 0;
                parroquiaActual = "";

                if (!municipioActual.Equals(""))
                {
                    listaParroquias = ubicacion.GetParroquias(municipioActual);
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

            selectedIndex = comboParroquia.SelectedIndex;
            if (selectedIndex != 0)
            {
                aux = (Ubicacion.Entidad)listaParroquias[selectedIndex - 1];
                parroquiaActual = aux.id;
            }

            if (!parroquiaActual.Equals(""))
            {
                stActual.SetCodParroquia(parroquiaActual);
            }
        }


        private void botonAveria_Click(object sender, EventArgs e)
        {
            FAveria faveria = new FAveria();
            faveria.SetSenal(stActual);
            faveria.Show();
            this.Hide();
        }

        private void boVolver_Click(object sender, EventArgs e)
        {
            RSTmobile.view.RSTApp rst = RSTmobile.view.RSTApp.GetInstance();
            FConsultarSenal fcsenal = rst.GetConsultarSenal();
            fcsenal.Show();
            this.Hide();
        }

        private void botonReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea deshacer los cambios realizados?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                init();
                SetSenal(senalXML);
            }
        }

    }
}