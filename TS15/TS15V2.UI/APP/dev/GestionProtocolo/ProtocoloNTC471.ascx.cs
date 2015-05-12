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
using System.Collections;
using TS15.Common.util;

namespace TS15V2.UI.APP.dev.GestionProtocolo
{
    public partial class ProtocoloNTC471 : GenericoProtocolo, IGestionable, ITerminable
    {

        // Datos
        private pro_ntc471 _prueba;
        private List<pro_ntc471_has_relacion> _listPruebaDetalle;
        private BOProtocolo_NTC471 _BOntc471Object;

        // Constructores

        public ProtocoloNTC471()
        {
            _BOntc471Object = new BOProtocolo_NTC471();
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
                _prueba = (pro_ntc471)Session[VariablesGlobales.PRUEBA_SELECCIONADA];
                object[] pruebaDetalle = _BOntc471Object.ObtenerPruebaDetalle(_prueba);
                //_prueba = (pro_ntc471)_BOntc471Object.ObtenerUltimaPrueba(Transformador);
                if (pruebaDetalle != null)
                {
                    _listPruebaDetalle = (List<pro_ntc471_has_relacion>)pruebaDetalle[1];
                    CargarEntidad();
                    ActivarControles(false);
                }
                
            }
            else
            {
                _prueba = new pro_ntc471();
                _listPruebaDetalle = new List<pro_ntc471_has_relacion>();
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
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC471] != null)
                _prueba = (pro_ntc471)Session[VariablesGlobales.SESION_PRUEBA_NTC471];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc471Object.Terminar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC471] = _prueba;

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
                this.txtRelacion.Text = Convert.ToString(_prueba.relacion);
                this.txtFaseFase.Text = Convert.ToString(_prueba.fase_fase);
                this.txtFaseNeutro.Text = Convert.ToString(_prueba.fase_neutro);
                this.txtPolaridad.Text = Convert.ToString(_prueba.polaridad);
                this.txtGrupoConexion.Text = Convert.ToString(Transformador.trfgrpconex);
                this.lbResultado.SelectedValue = _prueba.resultado != null ? Convert.ToString(_prueba.resultado) : "-1";
                // Detalle relación
                
                Session[VariablesGlobales.SESION_PRUEBA_NTC471] = _prueba;

                CargarDetalle();
            }
        }

        private void CargarDetalle() {
            Session[VariablesGlobales.SESION_PRUEBA_NTC471_DETALLE] = _listPruebaDetalle;
        }

        private void ActualizarEntidad()
        {
            // Encabezado
            _prueba.relacion = txtRelacion.Text;
            _prueba.fase_fase = txtFaseFase.Text;
            _prueba.fase_neutro = txtFaseNeutro.Text;
            _prueba.polaridad = txtPolaridad.Text;
           
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
            this.txtRelacion.Enabled = valorEnable;
            this.txtFaseFase.Enabled = valorEnable;
            this.txtFaseNeutro.Enabled = valorEnable;
            this.txtPolaridad.Enabled = valorEnable;
            
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
            if (Session[VariablesGlobales.SESION_PRUEBA_NTC471] != null)
                _prueba = (pro_ntc471)Session[VariablesGlobales.SESION_PRUEBA_NTC471];

            if (ValidarCampos())
            {
                if (_prueba != null)
                {
                    ActualizarEntidad();

                    if (_BOntc471Object.Modificar(_prueba))
                    {
                        Session[VariablesGlobales.SESION_PRUEBA_NTC471] = _prueba;

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
                && this.txtRelacion.Text != null && !this.txtRelacion.Text.Equals("")
                && this.txtFaseFase.Text != null && !this.txtFaseFase.Text.Equals("")
                && this.txtFaseNeutro.Text != null && !this.txtFaseNeutro.Text.Equals("")
                && this.txtPolaridad.Text != null && !this.txtPolaridad.Text.Equals("")
                )
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