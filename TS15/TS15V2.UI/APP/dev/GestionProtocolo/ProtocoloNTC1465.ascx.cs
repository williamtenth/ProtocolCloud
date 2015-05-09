using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.BL.gestion_protocolo;
using TS15.Common.Generated;
using TS15V2.UI.APP.abstractUI;
using TS15V2.UI.APP.util;
using TS15.Common.util;

namespace TS15V2.UI.APP.dev.GestionProtocolo
{
    public partial class ProtocoloNTC1465C : GenericoProtocoloComponente, IGestionable, ITerminable
    {

        // Datos
        private pro_ntc1465 _prueba;
        private BOProtocolo_NTC1465 _BOntc1465Object;
        private List<gen_parametrica> _listTipAislante;
        private List<gen_parametrica> _listReferencia;
        private List<gen_parametrica> _listMétodo;

        // Constructores

        public ProtocoloNTC1465C()
        {
            _BOntc1465Object = new BOProtocolo_NTC1465();
        }

        // Métodos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarListas();
                CargarPrueba();

                // Se oculta la botonera si la prueba tiene resultado
                if (_prueba != null && _prueba.estado != null && _prueba.estado.Equals(VariablesGlobales.ESTADO_TERMINADO))
                    pnlBotonera.Visible = false;
            }
        }

        public void CargarListas()
        {
            // carga lista tipo aislante
            _listTipAislante = Parametros.ConsultarParametros("tipaislante");
            this.lbLiquidoAislante.DataSource = _listTipAislante;
            this.lbLiquidoAislante.DataValueField = "consecutivo";
            this.lbLiquidoAislante.DataTextField = "valor";
            this.lbLiquidoAislante.DataBind();
            // carga lista tipo referencia aislante
            _listReferencia = Parametros.ConsultarParametros("refaislante");
            this.lbReferencia.DataSource = _listReferencia;
            this.lbReferencia.DataValueField = "consecutivo";
            this.lbReferencia.DataTextField = "valor";
            this.lbReferencia.DataBind();
            // carga lista método aislante
            _listMétodo = Parametros.ConsultarParametros("metaislante");
            this.lbMetodo.DataSource = _listMétodo;
            this.lbMetodo.DataValueField = "consecutivo";
            this.lbMetodo.DataTextField = "valor";
            this.lbMetodo.DataBind();
            // Carga lista de resultados
            this.lbResultado.DataSource = ListaParResultados;
            this.lbResultado.DataValueField = "consecutivo";
            this.lbResultado.DataTextField = "valor";
            this.lbResultado.DataBind();
            //this.lbResultado.Items.Insert(0, new ListItem("--Seleccione--", "-1"));

        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Crear(object sender, EventArgs e)
        {

        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Terminar(object sender, EventArgs e)
        {
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC1465] != null)
                _prueba = (pro_ntc1465)Session[VariablesGlobales.SESION_PRUEBA_NTC1465];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc1465Object.Terminar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC1465] = _prueba;

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

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Eliminar(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Este método carga la última prueba del transformador.
        /// </summary>
        public override void CargarPrueba()
        {
            CargarSesion();
            CargarListas();
            if (Pedido != null && Transformador != null && Proceso != null)
            {
                _prueba = (pro_ntc1465)Session[VariablesGlobales.PRUEBA_SELECCIONADA];
                CargarEntidad();
                ActivarControles(false);
            }
            else
            {
                _prueba = new pro_ntc1465();
                _prueba.fecha = new DateTime();
            }
        }

        public void CargarEntidad()
        {
            if (_prueba != null)
            {
                this.lbLiquidoAislante.SelectedValue = _prueba.tipaislante != null ? Convert.ToString(_prueba.tipaislante) : "1";
                this.lbReferencia.SelectedValue = _prueba.refaislante != null ? Convert.ToString(_prueba.refaislante)  : "1";
                this.txtRuptura.Text = Convert.ToString(_prueba.ruptura);
                this.lbMetodo.SelectedValue = _prueba.metaislante != null ? Convert.ToString(_prueba.metaislante) : "1";
                this.lbResultado.SelectedValue = _prueba.resultado != null ? Convert.ToString(_prueba.resultado) : "-1";

                Session[VariablesGlobales.SESION_PRUEBA_NTC1465] = _prueba;
            }
        }

        private void ActualizarEntidad()
        {
            _prueba.tipaislante = UtilNumeros.StringToBytes(lbLiquidoAislante.SelectedValue);
            _prueba.refaislante = UtilNumeros.StringToBytes(lbReferencia.SelectedValue);
            _prueba.ruptura = UtilNumeros.StringToDecimal(txtRuptura.Text);
            _prueba.metaislante = UtilNumeros.StringToBytes(lbMetodo.SelectedValue);
            _prueba.resultado = UtilNumeros.StringToBytes(lbResultado.SelectedValue);
        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Modificar(object sender, EventArgs e)
        {
            ActivarControles(true);
        }

        /// 
        /// <param name="valorEnable"></param>
        public void ActivarControles(bool valorEnable)
        {
            this.txtRuptura.Enabled = valorEnable;
            this.lbResultado.Enabled = valorEnable;

            // Se oculta la botonera si la prueba tiene resultado
            if (_prueba != null && _prueba.estado != null && _prueba.estado.Equals(VariablesGlobales.ESTADO_TERMINADO))
                pnlBotonera.Visible = false;
            pnlInicial.Visible = !valorEnable;
            pnlGuardar.Visible = valorEnable;
        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Guardar(object sender, EventArgs e)
        {
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC1465] != null)
                _prueba = (pro_ntc1465)Session[VariablesGlobales.SESION_PRUEBA_NTC1465];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc1465Object.Modificar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC1465] = _prueba;

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

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cancelar(object sender, EventArgs e)
        {
            ActivarControles(false);
            CargarPrueba();
        }

        /// <summary>
        /// Permite validar los campos obligatorios del formulario.
        /// </summary>
        public bool ValidarCampos()
        {
            if (this.lbResultado.SelectedValue != "-1"
                && this.txtRuptura.Text != null && !this.txtRuptura.Text.Equals(""))
                return true;
            return false;
        }

        protected void IniciarComponenteLista(object sender, EventArgs e)
        {
            if (sender == lbResultado)
                lbResultado.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
            if (sender == lbLiquidoAislante)
                lbLiquidoAislante.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
            if (sender == lbMetodo)
                lbMetodo.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
            if (sender == lbReferencia)
                lbReferencia.Items.Insert(0, new ListItem("--Seleccione--", "-1"));

        }
    }
}