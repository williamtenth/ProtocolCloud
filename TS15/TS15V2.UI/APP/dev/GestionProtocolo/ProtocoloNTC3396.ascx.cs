using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.BL.gestion_protocolo;
using TS15V2.UI.APP.abstractUI;
using TS15V2.UI.APP.util;
using TS15.Common.util;

namespace TS15V2.UI.APP.dev.GestionProtocolo
{
    public partial class ProtocoloNTC3396C : GenericoProtocoloComponente, IGestionable, ITerminable
    {
        // Datos
        private List<gen_parametrica> _listaColores;
        private BOProtocolo_NTC3396 _BOntc3396Object;
        private pro_ntc3396 _prueba;

        // Constructores
        public ProtocoloNTC3396C()
        {
            _BOntc3396Object = new BOProtocolo_NTC3396();

        }

        // Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarListas();
                CargarPrueba();

                // Se oculta la botonera si la prueba tiene resultado
                if (_prueba != null && _prueba.resultado != null)
                    pnlBotonera.Visible = false;
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
            this.lbColor.DataValueField = "consecutivo";
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

        /// <summary>
        /// Es método permite modificar la entidad, pero no modifica el resultado total, este se calcula cuando se termina la prueba.
        /// </summary>
        public void Modificar(object sender, EventArgs e)
        {
            ActivarControles(true);
        }

        public void Guardar(object sender, EventArgs e)
        {
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC3396] != null)
                _prueba = (pro_ntc3396)Session[VariablesGlobales.SESION_PRUEBA_NTC3396];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc3396Object.Modificar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC3396] = _prueba;

                        ActivarControles(false);
                        EnviarAModalMsj(MsjConfirmacion, "Confirmación", "Se ha modificado exitosamente la prueba");
                    }
                    else 
                    {
                        EnviarAModalMsj(MsjConfirmacion, "Error", "Error al modificar prueba");
                    }
                }
            }
            else
            {
                EnviarAModalMsj(MsjConfirmacion, "Error", "No se puede guardar campos vacíos");
            }

        }

        private bool ValidarCampos()
        {
            if (this.lbSalina1.SelectedValue != "-1" && this.lbSalina2.SelectedValue != "-1" && this.lbImpacto.SelectedValue != "-1"
                && this.lbEspesor1.SelectedValue != "-1" && this.lbEspesor2.SelectedValue != "-1"
                && this.txtAdherencia.Text != null && !this.txtAdherencia.Text.Equals("")
                && this.txtEspesor.Text != null && !this.txtEspesor.Text.Equals(""))
                return true;
            return false;
        }

        public void Cancelar(object sender, EventArgs e)
        {
            ActivarControles(false);
            CargarPrueba();
        }

        public void Terminar(object sender, EventArgs e)
        {
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC3396] != null)
                _prueba = (pro_ntc3396)Session[VariablesGlobales.SESION_PRUEBA_NTC3396];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    //ActualizarEntidad();

                    if (_BOntc3396Object.Terminar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC3396] = _prueba;

                        pnlBotonera.Visible = false;
                        EnviarAModalMsj(MsjConfirmacion, "Confirmación", "Esta prueba se ha terminado, solo se puede consultar nuevamente");
                    }
                    else
                    {
                        EnviarAModalMsj(MsjConfirmacion, "Error", "Error al terminar prueba");
                    }
                }
            }
            else
            {
                EnviarAModalMsj(MsjConfirmacion, "Error", "No se puede guardar campos vacíos");
            }

        }

        public override void CargarPrueba()
        {
            CargarSesion();
            CargarListas();
            if (Pedido != null && Transformador != null && Proceso != null)
            {
                _prueba = (pro_ntc3396)Session[VariablesGlobales.PRUEBA_SELECCIONADA];
                CargarEntidad();
                ActivarControles(false);
            }
            else
            {
                _prueba = new pro_ntc3396();
                _prueba.fecha = new DateTime();
            }
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

            // Se oculta la botonera si la prueba tiene resultado
            if (_prueba != null && _prueba.estado != null && _prueba.estado.Equals(VariablesGlobales.ESTADO_TERMINADO))
                pnlBotonera.Visible = false;
            pnlInicial.Visible = !valorEnable;
            pnlGuardar.Visible = valorEnable;
        }

        public void CargarEntidad()
        {
            if (_prueba != null)
            {
                this.lbColor.SelectedValue = "1";
                this.lbEspesor1.SelectedValue =_prueba.espesor1 != null ? Convert.ToString(_prueba.espesor1) : "-1";
                this.lbEspesor2.SelectedValue = _prueba.espesor2 != null ? Convert.ToString(_prueba.espesor2) : "-1";
                this.lbImpacto.SelectedValue = _prueba.impacto != null ? Convert.ToString(_prueba.impacto) : "-1";
                this.lbSalina1.SelectedValue = _prueba.salina1 != null ? Convert.ToString(_prueba.salina1) : "-1";
                this.lbSalina2.SelectedValue = _prueba.salina2 != null ? Convert.ToString(_prueba.salina2) : "-1";
                this.txtAdherencia.Text = Convert.ToString(_prueba.adherencia);
                this.txtEspesor.Text = Convert.ToString(_prueba.espesorvalor);

                Session[VariablesGlobales.SESION_PRUEBA_NTC3396] = _prueba;
            }
        }

        public void ActualizarEntidad()
        {
            _prueba.color = lbColor.SelectedValue;
            _prueba.espesor1 = UtilNumeros.StringToBytes(lbEspesor1.SelectedValue);
            _prueba.espesor2 = UtilNumeros.StringToBytes(lbEspesor2.SelectedValue);
            _prueba.impacto = UtilNumeros.StringToBytes(lbImpacto.SelectedValue);
            _prueba.salina1 = UtilNumeros.StringToBytes(lbSalina1.SelectedValue);
            _prueba.salina2 = UtilNumeros.StringToBytes(lbSalina2.SelectedValue);
            _prueba.espesorvalor = UtilNumeros.StringToDecimal(txtEspesor.Text);
            _prueba.adherencia = UtilNumeros.StringToDecimal(txtAdherencia.Text);

        }

        protected void IniciarComponenteLista(object sender, EventArgs e)
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

        public void Crear(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}