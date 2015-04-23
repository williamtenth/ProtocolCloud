using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.BL.gestion_protocolo;
using TS15V2.UI.APP.util;
using util;

namespace TS15V2.UI.APP.dev.GestionProtocolo
{
    public partial class ProtocoloNTC3396 : GenericoProtocolo
    {
        // Datos
        private List<gen_parametrica> _listaColores;
        private BOProtocolo_NTC3396 _BOntc3396Object;
        private pro_ntc3396 _prueba;

        // Constructores
        public ProtocoloNTC3396()
        {
            _BOntc3396Object = new BOProtocolo_NTC3396();

        }

        // Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TextBox1.Text = Transformador.numserie;
                CargarListas();
                CargarPrueba();
            }
        }

        // Métodos

        /// <summary>
        /// Este método carga las listas:
        /// -  los valores de resultado de una prueba.
        /// </summary>
        public void CargarListas()
        {
            _listaColores = Parametros.ConsultarParametros("trfcolor");
            // carga lista colores
            this.lbColor.DataSource = _listaColores;
            this.lbColor.DataValueField = "valor";
            this.lbColor.DataTextField = "valor";
            this.lbColor.DataBind();
            // carga lista salina Ambiente 1
            this.lbSalina1.DataSource = ListaParResultados;
            this.lbSalina1.DataValueField = "consecutivo";
            this.lbSalina1.DataTextField = "valor";
            this.lbSalina1.DataBind();
            // carga lista salina Ambiente 2
            this.lbSalina2.DataSource = ListaParResultados;
            this.lbSalina2.DataValueField = "consecutivo";
            this.lbSalina2.DataTextField = "valor";
            this.lbSalina2.DataBind();
            // carga lista impacto
            this.lbImpacto.DataSource = ListaParResultados;
            this.lbImpacto.DataValueField = "consecutivo";
            this.lbImpacto.DataTextField = "valor";
            this.lbImpacto.DataBind();
            // carga lista espesor Ambiente 1
            this.lbEspesor1.DataSource = ListaParResultados;
            this.lbEspesor1.DataValueField = "consecutivo";
            this.lbEspesor1.DataTextField = "valor";
            this.lbEspesor1.DataBind();
            // carga lista espesor Ambiente 1
            this.lbEspesor2.DataSource = ListaParResultados;
            this.lbEspesor2.DataValueField = "consecutivo";
            this.lbEspesor2.DataTextField = "valor";
            this.lbEspesor2.DataBind();
        }


        public void Modificar(object sender, EventArgs e)
        {
            ActivarControles(true);

        }

        public void Guardar(object sender, EventArgs e)
        {
            //_prueba.espesorvalor = UtilNumeros.StringToDecimal(txtEspesor.Text);
            //_prueba.adherencia = UtilNumeros.StringToDecimal(txtAdherencia.Text);

            if (Session[VariablesGlobales.SESION_PRUEBA_NTC3396] != null)
                _prueba = (pro_ntc3396)Session[VariablesGlobales.SESION_PRUEBA_NTC3396];

            if (_prueba != null)
            {
                ActualizarEntidad();
                _BOntc3396Object.Modificar(_prueba);
                ActivarControles(false);
            }
        }

        public void Cancelar(object sender, EventArgs e)
        {
            ActivarControles(false);
        }

        public void Terminar(object sender, EventArgs e)
        {
            if (!_BOntc3396Object.Terminar(_prueba))
                Console.Out.Write("Error al Terminar Prueba");
        }

        public void ActivarControles(Boolean valorEnable)
        {
            this.lbEspesor1.Enabled = valorEnable;
            this.lbEspesor2.Enabled = valorEnable;
            this.lbImpacto.Enabled = valorEnable;
            this.lbSalina1.Enabled = valorEnable;
            this.lbSalina2.Enabled = valorEnable;
            this.txtAdherencia.Enabled = valorEnable;
            this.txtEspesor.Enabled = valorEnable;
            pnlInicial.Visible = !valorEnable;
            pnlGuardar.Visible = valorEnable;
        }

        public override void CargarPrueba()
        {
            if (Transformador != null)
            {
                _prueba = (pro_ntc3396)_BOntc3396Object.ObtenerUltimaPrueba(Transformador);
                CargarEntidad();
            }
            else
            {
                _prueba = new pro_ntc3396();
                _prueba.fecha = new DateTime();
            }
        }

        public void CargarEntidad()
        {
            if (_prueba != null)
            {
                this.lbColor.SelectedValue = _prueba.color;
                this.lbEspesor1.SelectedValue = Convert.ToString(_prueba.espesor1);
                this.lbEspesor2.SelectedValue = Convert.ToString(_prueba.espesor2);
                this.lbImpacto.SelectedValue = Convert.ToString(_prueba.impacto);
                this.lbSalina1.SelectedValue = Convert.ToString(_prueba.salina1);
                this.lbSalina2.SelectedValue = Convert.ToString(_prueba.salina2);
                this.txtAdherencia.Text = Convert.ToString(_prueba.adherencia);
                this.txtEspesor.Text = Convert.ToString(_prueba.espesorvalor);

                Session[VariablesGlobales.SESION_PRUEBA_NTC3396] = _prueba;
            }
        }

        public void ActualizarEntidad()
        {
            _prueba.espesor1 = UtilNumeros.StringToBytes(lbEspesor1.SelectedValue);
            _prueba.espesor2 = UtilNumeros.StringToBytes(lbEspesor2.SelectedValue);
            _prueba.impacto = UtilNumeros.StringToBytes(lbImpacto.SelectedValue);
            _prueba.salina1 = UtilNumeros.StringToBytes(lbSalina1.SelectedValue);
            _prueba.salina2 = UtilNumeros.StringToBytes(lbSalina2.SelectedValue);
            _prueba.espesorvalor = UtilNumeros.StringToDecimal(txtEspesor.Text);
            _prueba.adherencia = UtilNumeros.StringToDecimal(txtAdherencia.Text);

        }

        protected void iniciarComponenteLista(object sender, EventArgs e)
        {
            if (sender == lbEspesor1)
                lbEspesor1.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
            if (sender == lbEspesor2)
                lbEspesor2.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
            if (sender == lbImpacto)
                lbImpacto.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
            if (sender == lbSalina1)
                lbSalina1.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
            if (sender == lbSalina2)
                lbSalina2.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }
    }
}