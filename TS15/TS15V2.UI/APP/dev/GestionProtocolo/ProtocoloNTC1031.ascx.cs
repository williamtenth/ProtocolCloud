﻿using System;
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
    public partial class ProtocoloNTC1031C : GenericoProtocoloComponente, IGestionable, ITerminable
    {

        // Datos
        private pro_ntc1031 _prueba;
        private BOProtocolo_NTC1031 _BOntc1031Object;
        private List<gen_parametrica> _listMatFabric;

        // Constructores

        public ProtocoloNTC1031C()
        {
            _BOntc1031Object = new BOProtocolo_NTC1031();
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
            _listMatFabric = Parametros.ConsultarParametros("tipaislante");
            //this.lbLiquidoAislante.DataSource = _listMatFabric;
            //this.lbLiquidoAislante.DataValueField = "consecutivo";
            //this.lbLiquidoAislante.DataTextField = "valor";
            //this.lbLiquidoAislante.DataBind();
            // Carga lista de resultados
            this.lbResultado.DataSource = ListaParResultados;
            this.lbResultado.DataValueField = "consecutivo";
            this.lbResultado.DataTextField = "valor";
            this.lbResultado.DataBind();
            //this.lbResultado.Items.Insert(0, new ListItem("--Seleccione--", "-1"));

        }

        /// <summary>
        /// Este método carga la última prueba del transformador.
        /// </summary>
        public override void CargarPrueba()
        {
            CargarListas();
            CargarSesion();
            if (Pedido != null && Transformador != null && Proceso != null)
            {
                _prueba = (pro_ntc1031)Session[VariablesGlobales.PRUEBA_SELECCIONADA];
                CargarEntidad();
                ActivarControles(true);
            }
            else
            {
                _prueba = new pro_ntc1031();
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
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC1031] != null)
                _prueba = (pro_ntc1031)Session[VariablesGlobales.SESION_PRUEBA_NTC1031];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc1031Object.Terminar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC1031] = _prueba;

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
                this.txtTension.Text = Convert.ToString(Transformador.volsalida);
                this.txtIx.Text = Convert.ToString(_prueba.ix);
                this.txtI2.Text = Convert.ToString(_prueba.i2);
                this.txtI3.Text = Convert.ToString(_prueba.i3);
                this.txtPromedio.Text = Convert.ToString(_prueba.promedio);
                this.txtGarantia.Text = Convert.ToString(_prueba.garantia);
                this.txtPoMedida.Text = Convert.ToString(_prueba.po_medida);
                this.txtPoGarantizado.Text = Convert.ToString(_prueba.po_garantizado);
                this.lbResultado.SelectedValue = _prueba.resultado != null ? Convert.ToString(_prueba.resultado) : "-1";
                // Detalle resistencia

                Session[VariablesGlobales.SESION_PRUEBA_NTC1031] = _prueba;
            }
        }

        private void ActualizarEntidad()
        {
            // Encabezado
            _prueba.ix = UtilNumeros.StringToDecimal(txtIx.Text);
            _prueba.i2 = UtilNumeros.StringToDecimal(txtI2.Text);
            _prueba.i3 = UtilNumeros.StringToDecimal(txtI3.Text);
            _prueba.promedio = UtilNumeros.StringToDecimal(txtPromedio.Text);
            _prueba.garantia = UtilNumeros.StringToDecimal(txtGarantia.Text);
            _prueba.po_medida = UtilNumeros.StringToDecimal(txtPoMedida.Text);
            _prueba.po_garantizado = UtilNumeros.StringToDecimal(txtPoGarantizado.Text);
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
            this.txtIx.Enabled = valorEnable;
            this.txtI2.Enabled = valorEnable;
            this.txtI3.Enabled = valorEnable;
            this.txtPromedio.Enabled = valorEnable;
            this.txtGarantia.Enabled = valorEnable;
            this.txtPoMedida.Enabled = valorEnable;
            this.txtPoGarantizado.Enabled = valorEnable;
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
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC1031] != null)
                _prueba = (pro_ntc1031)Session[VariablesGlobales.SESION_PRUEBA_NTC1031];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc1031Object.Modificar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC1031] = _prueba;

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
                && this.txtIx.Text != null && !this.txtIx.Text.Equals("")
                && this.txtI2.Text != null && !this.txtI2.Text.Equals("")
                && this.txtI3.Text != null && !this.txtI3.Text.Equals("")
                && this.txtPromedio.Text != null && !this.txtPromedio.Text.Equals("")
                && this.txtGarantia.Text != null && !this.txtGarantia.Text.Equals("")
                && this.txtPoMedida.Text != null && !this.txtPoMedida.Text.Equals("")
                && this.txtPoGarantizado.Text != null && !this.txtPoGarantizado.Text.Equals(""))
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