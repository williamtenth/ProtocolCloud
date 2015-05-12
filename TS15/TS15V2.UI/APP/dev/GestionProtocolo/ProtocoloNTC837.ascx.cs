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
    public partial class ProtocoloNTC837 : GenericoProtocolo, IGestionable, ITerminable
    {

        // Datos
        private pro_ntc837 _prueba;
        private BOProtocolo_NTC837 _BOntc837Object;

        // Constructores

        public ProtocoloNTC837()
        {
            _BOntc837Object = new BOProtocolo_NTC837();
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
                _prueba = (pro_ntc837)Session[VariablesGlobales.PRUEBA_SELECCIONADA];
                CargarEntidad();
                ActivarControles(false);
            }
            else
            {
                _prueba = new pro_ntc837();
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
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC837] != null)
                _prueba = (pro_ntc837)Session[VariablesGlobales.SESION_PRUEBA_NTC837];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc837Object.Terminar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC837] = _prueba;

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
                this.txtBt_at_t.Text = Convert.ToString(_prueba.bt_at_t);
                this.txtAt_bt_t.Text = Convert.ToString(_prueba.at_bt_t);
                this.txtTension.Text = Convert.ToString(_prueba.tension);
                this.txtFrecuencia.Text = Convert.ToString(_prueba.frecuencia);
                this.txtTiempo.Text = Convert.ToString(_prueba.tiempo);
                this.lbResultado.SelectedValue = _prueba.resultado != null ? Convert.ToString(_prueba.resultado) : "-1";

                Session[VariablesGlobales.SESION_PRUEBA_NTC837] = _prueba;
            }
        }

        private void ActualizarEntidad()
        {
            // Encabezado
            _prueba.bt_at_t = UtilNumeros.StringToDecimal(txtBt_at_t.Text);
            _prueba.at_bt_t = UtilNumeros.StringToDecimal(txtAt_bt_t.Text);
            _prueba.tension = UtilNumeros.StringToDecimal(txtTension.Text);
            _prueba.frecuencia = UtilNumeros.StringToDecimal(txtFrecuencia.Text);
            _prueba.tiempo = UtilNumeros.StringToDecimal(txtTiempo.Text);

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
            this.txtBt_at_t.Enabled = valorEnable;
            this.txtAt_bt_t.Enabled = valorEnable;
            this.txtTension.Enabled = valorEnable;
            this.txtFrecuencia.Enabled = valorEnable;
            this.txtTiempo.Enabled = valorEnable;

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
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC837] != null)
                _prueba = (pro_ntc837)Session[VariablesGlobales.SESION_PRUEBA_NTC837];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc837Object.Modificar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC837] = _prueba;

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
                && this.txtBt_at_t.Text != null && !this.txtBt_at_t.Text.Equals("")
                && this.txtAt_bt_t.Text != null && !this.txtAt_bt_t.Text.Equals("")
                && this.txtTension.Text != null && !this.txtTension.Text.Equals("")
                && this.txtFrecuencia.Text != null && !this.txtFrecuencia.Text.Equals("")
                && this.txtTiempo.Text != null && !this.txtTiempo.Text.Equals(""))
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