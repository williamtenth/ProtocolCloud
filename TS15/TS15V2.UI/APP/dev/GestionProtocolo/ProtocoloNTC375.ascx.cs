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
    public partial class ProtocoloNTC375 : GenericoProtocolo, IGestionable, ITerminable
    {

        // Datos
        private pro_ntc375 _prueba;
        private BOProtocolo_NTC375 _BOntc375Object;
        private List<gen_parametrica> _listMatFabric;

        // Constructores

        public ProtocoloNTC375()
        {
            _BOntc375Object = new BOProtocolo_NTC375();
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
            CargarSesion();
            CargarListas();
            if (Pedido != null && Transformador != null && Proceso != null)
            {
                _prueba = (pro_ntc375)Session[VariablesGlobales.PRUEBA_SELECCIONADA];
                CargarEntidad();
                ActivarControles(false);
            }
            else
            {
                _prueba = new pro_ntc375();
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
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC375] != null)
                _prueba = (pro_ntc375)Session[VariablesGlobales.SESION_PRUEBA_NTC375];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc375Object.Terminar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC375] = _prueba;

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
                this.txtTiempo.Text = Convert.ToString(_prueba.tiempolectura);
                this.txtTension.Text = Convert.ToString(_prueba.tension);
                this.txtAT_T.Text = Convert.ToString(_prueba.at_t);
                this.txtBT_T.Text = Convert.ToString(_prueba.bt_t);
                this.txtAT_BT_T.Text = Convert.ToString(_prueba.at_bt_t);
                this.lbResultado.SelectedValue = _prueba.resultado != null ? Convert.ToString(_prueba.resultado) : "-1";
                // Detalle resistencia

                Session[VariablesGlobales.SESION_PRUEBA_NTC375] = _prueba;
            }
        }

        private void ActualizarEntidad()
        {
            // Encabezado
            _prueba.tiempolectura = UtilNumeros.StringToBytes(txtTiempo.Text);
            _prueba.tension = UtilNumeros.StringToBytes(txtTension.Text);
            _prueba.at_t = UtilNumeros.StringToDecimal(txtAT_T.Text);
            _prueba.bt_t = UtilNumeros.StringToBytes(txtBT_T.Text);
            _prueba.at_bt_t = UtilNumeros.StringToBytes(txtAT_BT_T.Text);
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
            this.txtTiempo.Enabled = valorEnable;
            this.txtTension.Enabled = valorEnable;
            this.txtAT_T.Enabled = valorEnable;
            this.txtBT_T.Enabled = valorEnable;
            this.txtAT_BT_T.Enabled = valorEnable;
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
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC375] != null)
                _prueba = (pro_ntc375)Session[VariablesGlobales.SESION_PRUEBA_NTC375];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc375Object.Modificar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC375] = _prueba;

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
                && this.txtTiempo.Text != null && !this.txtTiempo.Text.Equals("")
                && this.txtTension.Text != null && !this.txtTension.Text.Equals("")
                && this.txtAT_T.Text != null && !this.txtAT_T.Text.Equals("")
                && this.txtBT_T.Text != null && !this.txtBT_T.Text.Equals("")
                && this.txtAT_BT_T.Text != null && !this.txtAT_BT_T.Text.Equals(""))
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