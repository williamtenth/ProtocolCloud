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
    public partial class ProtocoloNTC1005 : GenericoProtocolo
    {
        // Datos
        private pro_ntc1005 _prueba;
        private BOProtocolo_NTC1005 _BOntc1005Object;

        // Constructores

        public ProtocoloNTC1005()
        {
            _BOntc1005Object = new BOProtocolo_NTC1005();
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
            // Carga lista de resultados
            this.lbResultado.DataSource = ListaParResultados;
            this.lbResultado.DataValueField = "consecutivo";
            this.lbResultado.DataTextField = "valor";
            this.lbResultado.DataBind();

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
                _prueba = (pro_ntc1005)Session[VariablesGlobales.PRUEBA_SELECCIONADA];
                CargarEntidad();
                ActivarControles(true);
            }
            else
            {
                _prueba = new pro_ntc1005();
                _prueba.fecha = new DateTime();
            }
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
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC1005] != null)
                _prueba = (pro_ntc1005)Session[VariablesGlobales.SESION_PRUEBA_NTC1005];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc1005Object.Terminar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC1005] = _prueba;

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

        public void CargarEntidad()
        {
            if (_prueba != null)
            {
                // Encabezado
                this.txtIcc.Text = Convert.ToString(_prueba.icc);
                this.txtUcc.Text = Convert.ToString(_prueba.ucc);
                this.lbResultado.SelectedValue = _prueba.resultado != null ? Convert.ToString(_prueba.resultado) : "-1";
                //this.lbResultado.SelectedValue = Convert.ToString(_prueba.resultado);
                // Detalle Perdidas
                this.txtPerdidas24.Text = Convert.ToString(_prueba.perdidas24);
                this.txtPerdidas85.Text = Convert.ToString(_prueba.perdidas85);
                this.txtPerdidasGarantizadas.Text = Convert.ToString(_prueba.garantiazada85);
                // Detalle I2R
                this.txtI2R24.Text = Convert.ToString(_prueba.i2r24);
                this.txtI2R85.Text = Convert.ToString(_prueba.i2r85);
                this.txtI2RGarantizadas.Text = Convert.ToString(_prueba.i2r85garantia);
                // Detalle Impedancia
                this.txtImpedancia24.Text = Convert.ToString(_prueba.impedancia24);
                this.txtImpedancia85.Text = Convert.ToString(_prueba.impedancia85);
                this.txtImpedanciaGarantizadas.Text = Convert.ToString(_prueba.impedancia85gar);
                // Detalle Eficiencia
                this.txtEficiencia.Text = Convert.ToString(_prueba.eficiencia);
                this.txtEfiFP.Text = Convert.ToString(_prueba.pf_eficiencia);
                this.txtRegulacion.Text = Convert.ToString(_prueba.regulacion);
                this.txtRegFP.Text = Convert.ToString(_prueba.pf_regulacion);

                Session[VariablesGlobales.SESION_PRUEBA_NTC1005] = _prueba;
            }
        }

        private void ActualizarEntidad()
        {
            // Encabezado
            _prueba.icc = UtilNumeros.StringToDecimal(txtIcc.Text);
            _prueba.ucc = UtilNumeros.StringToDecimal(txtIcc.Text);
            _prueba.perdidas24 = UtilNumeros.StringToDecimal(txtPerdidas24.Text);
            _prueba.perdidas85 = UtilNumeros.StringToDecimal(txtPerdidas85.Text);
            _prueba.garantiazada85 = UtilNumeros.StringToDecimal(txtPerdidasGarantizadas.Text);
            _prueba.i2r24 = UtilNumeros.StringToDecimal(txtI2R24.Text);
            _prueba.i2r85 = UtilNumeros.StringToDecimal(txtI2R85.Text);
            _prueba.i2r85garantia = UtilNumeros.StringToDecimal(txtI2RGarantizadas.Text);
            _prueba.impedancia24 = UtilNumeros.StringToDecimal(txtImpedancia24.Text);
            _prueba.impedancia85 = UtilNumeros.StringToDecimal(txtImpedancia85.Text);
            _prueba.impedancia85gar = UtilNumeros.StringToDecimal(txtImpedanciaGarantizadas.Text);
            _prueba.eficiencia = UtilNumeros.StringToDecimal(txtEficiencia.Text);
            _prueba.pf_eficiencia = UtilNumeros.StringToDecimal(txtEfiFP.Text);
            _prueba.regulacion = UtilNumeros.StringToDecimal(txtRegulacion.Text);
            _prueba.pf_regulacion = UtilNumeros.StringToDecimal(txtRegFP.Text);


            _prueba.resultado = UtilNumeros.StringToBytes(lbResultado.SelectedValue);
            // Detalle resistencia

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
            // Encabezado
            this.txtUcc.Enabled = valorEnable;
            this.txtIcc.Enabled = valorEnable;
            this.lbResultado.Enabled = valorEnable;
            // Detalle Perdidas
            this.txtPerdidas24.Enabled = valorEnable;
            this.txtPerdidas85.Enabled = valorEnable;
            this.txtPerdidasGarantizadas.Enabled = valorEnable;
            // Detalle I2R
            this.txtI2R24.Enabled = valorEnable;
            this.txtI2R85.Enabled = valorEnable;
            this.txtI2RGarantizadas.Enabled = valorEnable;
            // Detalle Impedancia
            this.txtImpedancia24.Enabled = valorEnable;
            this.txtImpedancia85.Enabled = valorEnable;
            this.txtImpedanciaGarantizadas.Enabled = valorEnable;
            // Detalle Eficiencia
            this.txtEficiencia.Enabled = valorEnable;
            this.txtEfiFP.Enabled = valorEnable;
            this.txtRegulacion.Enabled = valorEnable;
            this.txtRegFP.Enabled = valorEnable;

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
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC1005] != null)
                _prueba = (pro_ntc1005)Session[VariablesGlobales.SESION_PRUEBA_NTC1005];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc1005Object.Modificar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC1005] = _prueba;

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
                && this.txtIcc.Text != null && !this.txtIcc.Text.Equals("")
                && this.txtUcc.Text != null && !this.txtUcc.Text.Equals("")
                && this.txtPerdidas24.Text != null && !this.txtPerdidas24.Text.Equals("")
                && this.txtPerdidas85.Text != null && !this.txtPerdidas85.Text.Equals("")
                && this.txtPerdidasGarantizadas.Text != null && !this.txtPerdidasGarantizadas.Text.Equals("")
                && this.txtI2R24.Text != null && !this.txtI2R24.Text.Equals("")
                && this.txtI2R85.Text != null && !this.txtI2R85.Text.Equals("")
                && this.txtI2RGarantizadas.Text != null && !this.txtI2RGarantizadas.Text.Equals("")
                && this.txtImpedancia24.Text != null && !this.txtImpedancia24.Text.Equals("")
                && this.txtImpedancia85.Text != null && !this.txtImpedancia85.Text.Equals("")
                && this.txtImpedanciaGarantizadas.Text != null && !this.txtImpedanciaGarantizadas.Text.Equals("")
                && this.txtEficiencia.Text != null && !this.txtEficiencia.Text.Equals("")
                && this.txtEfiFP.Text != null && !this.txtEfiFP.Text.Equals("")
                && this.txtRegulacion.Text != null && !this.txtRegulacion.Text.Equals("")
                && this.txtRegFP.Text != null && !this.txtRegFP.Text.Equals(""))
                return true;
            return false;
        }

        protected void IniciarComponenteLista(object sender, EventArgs e)
        {
            if (sender == lbResultado)
                lbResultado.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }
    }
}