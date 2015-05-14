using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.BL.gestion_cliente;
using TS15V2.UI.APP.abstractUI;
using TS15.BL.gestion_transformador;
using TS15.Common.Generated;
using TS15V2.UI.APP.util;
using TS15.Common.util;

namespace TS15V2.UI.APP.dev.GestionTransformador
{
    public partial class GestionarInfoTransformador : UIGenericoPagina
    {
        private BOTransformador _BOTransformadorObject;
        private BOCliente _BOClienteObject;

        public GestionarInfoTransformador()
        {
            _BOTransformadorObject = new BOTransformador();
            _BOClienteObject = new BOCliente();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucBusquedaCliente.ValidationGroupControles(string.Empty, false);
                ucBusquedaCliente.ActivarControlesBusqueda();
                //CargarListasCliente();
                CargarListas();
                //ConsultarHistorial();
            }
        }

        private void ConsultarHistorial()
        {
            if (!string.IsNullOrEmpty(ucBusquedaTransformador.IdTransformador))
            {
                int idTransformador = Convert.ToInt32(ucBusquedaTransformador.IdTransformador);
                gvSolicitudesTransformador.DataSource = _BOTransformadorObject.ConsultarSolicitudes(idTransformador);
                gvSolicitudesTransformador.DataBind();
            }
        }

        private void CargarListas()
        {
            CargarFabricante();
            CargarSerieAT();
            CargarSerieBT();
            CargarCapacidad();
            CargarFase();
            CargarAislamiento();
            CargarRefrigeracion();
            CargarGrupoConexion();
        }

        private void CargarValoresPorDefecto()
        {
            this.txtAltura.Text = "1000";
            this.txtAltura.Enabled = false;
            this.txtAltura.ReadOnly = true;

            this.txtTempDevanado.Text = "65";
            this.txtTempDevanado.Enabled = false;
            this.txtTempDevanado.ReadOnly = true;

            this.txtNumDerivaciones.Text = "5";
            this.txtNumDerivaciones.Enabled = false;
            this.txtNumDerivaciones.ReadOnly = true;

            this.ddlSerieAT.SelectedIndex = this.ddlSerieAT.Items.IndexOf(this.ddlSerieAT.Items.FindByText("Voltaje hasta 15kv"));
            this.ddlSerieAT.Enabled = false;

            this.ddlSerieBT.SelectedIndex = this.ddlSerieBT.Items.IndexOf(this.ddlSerieBT.Items.FindByText("Voltaje hasta 1,2kv"));
            this.ddlSerieBT.Enabled = false;

            this.ddlFase.SelectedIndex = this.ddlFase.Items.IndexOf(this.ddlFase.Items.FindByText("Trifásico"));
            this.ddlFase.Enabled = false;

            this.ddlAislamiento.SelectedIndex = this.ddlAislamiento.Items.IndexOf(this.ddlAislamiento.Items.FindByText("O"));
            this.ddlAislamiento.Enabled = false;

            this.ddlRefrigeracion.SelectedIndex = this.ddlRefrigeracion.Items.IndexOf(this.ddlRefrigeracion.Items.FindByText("N"));
            this.ddlRefrigeracion.Enabled = false;

            this.ddlGrupoConexion.SelectedIndex = this.ddlGrupoConexion.Items.IndexOf(this.ddlGrupoConexion.Items.FindByText("DyN5"));
            this.ddlGrupoConexion.Enabled = false;
        }

        private void CargarFabricante()
        {
            this.ddlFabricante.DataSource = _BOClienteObject.ConsultarFabricantes();
            this.ddlFabricante.DataValueField = "id";
            this.ddlFabricante.DataTextField = "nombre";
            this.ddlFabricante.DataBind();
        }

        private void CargarSerieAT()
        {
            this.ddlSerieAT.DataSource = Parametros.ConsultarParametros("tfrtenserie");
            this.ddlSerieAT.DataValueField = "consecutivo";
            this.ddlSerieAT.DataTextField = "valor";
            this.ddlSerieAT.DataBind();
        }

        private void CargarSerieBT()
        {
            this.ddlSerieBT.DataSource = Parametros.ConsultarParametros("tfrtenserie");
            this.ddlSerieBT.DataValueField = "consecutivo";
            this.ddlSerieBT.DataTextField = "valor";
            this.ddlSerieBT.DataBind();
        }

        private void CargarCapacidad()
        {
            this.ddlCapacidad.DataSource = Parametros.ConsultarParametros("tfrcapacidad");
            this.ddlCapacidad.DataValueField = "consecutivo";
            this.ddlCapacidad.DataTextField = "valor";
            this.ddlCapacidad.DataBind();
        }

        private void CargarFase()
        {
            this.ddlFase.DataSource = Parametros.ConsultarParametros("tfrfase");
            this.ddlFase.DataValueField = "consecutivo";
            this.ddlFase.DataTextField = "valor";
            this.ddlFase.DataBind();
        }

        private void CargarAislamiento()
        {
            this.ddlAislamiento.DataSource = Parametros.ConsultarParametros("trfaislamiento");
            this.ddlAislamiento.DataValueField = "consecutivo";
            this.ddlAislamiento.DataTextField = "valor";
            this.ddlAislamiento.DataBind();
        }

        private void CargarRefrigeracion()
        {
            this.ddlRefrigeracion.DataSource = Parametros.ConsultarParametros("trfrefrigeracion");
            this.ddlRefrigeracion.DataValueField = "consecutivo";
            this.ddlRefrigeracion.DataTextField = "valor";
            this.ddlRefrigeracion.DataBind();
        }

        private void CargarGrupoConexion()
        {
            this.ddlGrupoConexion.DataSource = Parametros.ConsultarParametros("trfgrpconex");
            this.ddlGrupoConexion.DataValueField = "consecutivo";
            this.ddlGrupoConexion.DataTextField = "valor";
            this.ddlGrupoConexion.DataBind();
        }

        protected void ddlFabricante_DataBound(object sender, EventArgs e)
        {
            ddlFabricante.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }

        protected void ddlSerieAT_DataBound(object sender, EventArgs e)
        {
            ddlSerieAT.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }

        protected void ddlSerieBT_DataBound(object sender, EventArgs e)
        {
            ddlSerieBT.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }

        protected void ddlCapacidad_DataBound(object sender, EventArgs e)
        {
            ddlCapacidad.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }

        protected void ddlFase_DataBound(object sender, EventArgs e)
        {
            ddlFase.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }

        protected void ddlGrupoConexion_DataBound(object sender, EventArgs e)
        {
            ddlGrupoConexion.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }

        private void ObtenerValores(tfr_transformador transformadorEntity)
        {
            transformadorEntity.numserie = this.txtNumSerie.Text.Trim();
            transformadorEntity.fabricante_id = Convert.ToInt32(this.ddlFabricante.SelectedValue);
            transformadorEntity.altura = this.txtAltura.Text.Trim();
            transformadorEntity.tfrtenserieAT = Convert.ToByte(this.ddlSerieAT.SelectedValue);
            transformadorEntity.tfrtenserieBT = Convert.ToByte(this.ddlSerieBT.SelectedValue);
            transformadorEntity.tfrcapacidad = Convert.ToByte(this.ddlCapacidad.SelectedValue);
            transformadorEntity.trffase = Convert.ToByte(this.ddlFase.SelectedValue);
            transformadorEntity.fecfabricacion = Convert.ToDateTime(this.txtFechaFabricacion.Text.Trim());
            transformadorEntity.tempdevanado = this.txtTempDevanado.Text.Trim();
            transformadorEntity.trfaislamiento = Convert.ToByte(this.ddlAislamiento.SelectedValue);
            transformadorEntity.frecuencia = Convert.ToInt64(this.txtFrecuencia.Text.Trim());
            transformadorEntity.trfrefrigeracion = Convert.ToByte(this.ddlRefrigeracion.SelectedValue);
            transformadorEntity.volentrada = Convert.ToDecimal(this.txtVoltajeEntrada.Text.Trim());
            transformadorEntity.volsalida = Convert.ToDecimal(this.txtVoltajeSalida.Text.Trim());
            transformadorEntity.volentrada_der = Convert.ToDecimal(this.txtVoltajeEntDerivada.Text.Trim());
            transformadorEntity.volsalida_der = Convert.ToDecimal(this.txtVoltajeSalDerivada.Text.Trim());
            transformadorEntity.derivaciones = Convert.ToInt32(this.txtNumDerivaciones.Text);
            transformadorEntity.trfgrpconex = Convert.ToByte(this.ddlGrupoConexion.SelectedValue);
        }

        protected void ddlAislamiento_DataBound(object sender, EventArgs e)
        {
            this.ddlAislamiento.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlRefrigeracion_DataBound(object sender, EventArgs e)
        {
            this.ddlRefrigeracion.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        private void ActivarControlesTransformador()
        {
            //this.ddlFabricante.Enabled = estado;
            //this.txtNumSerie.Enabled = estado;
            //this.txtAltura.Enabled = estado;
            //this.ddlSerieAT.Enabled = estado;
            //this.ddlSerieBT.Enabled = estado;
            //this.ddlCapacidad.Enabled = estado;
            //this.ddlFase.Enabled = estado;
            //this.txtFechaFabricacion.Enabled = estado;
            //this.txtTempDevanado.Enabled = estado;
            //this.ddlAislamiento.Enabled = estado;
            //this.txtFrecuencia.Enabled = estado;
            //this.ddlRefrigeracion.Enabled = estado;

            this.txtVoltajeEntrada.Enabled = true;
            this.txtVoltajeSalida.Enabled = true;
            this.txtVoltajeEntDerivada.Enabled = true;
            this.txtVoltajeSalDerivada.Enabled = true;
            this.txtNumDerivaciones.Enabled = true;

            //this.ddlGrupoConexion.Enabled = estado;
        }

        private void DesactivarControlesTransformador()
        {
            this.ddlFabricante.Enabled = false;
            this.txtNumSerie.Enabled = false;
            this.txtAltura.Enabled = false;
            this.ddlSerieAT.Enabled = false;
            this.ddlSerieBT.Enabled = false;
            this.ddlCapacidad.Enabled = false;
            this.ddlFase.Enabled = false;
            this.txtFechaFabricacion.Enabled = false;
            this.txtTempDevanado.Enabled = false;
            this.ddlAislamiento.Enabled = false;
            this.txtFrecuencia.Enabled = false;
            this.ddlRefrigeracion.Enabled = false;

            this.txtVoltajeEntrada.Enabled = false;
            this.txtVoltajeSalida.Enabled = false;
            this.txtVoltajeEntDerivada.Enabled = false;
            this.txtVoltajeSalDerivada.Enabled = false;
            this.txtNumDerivaciones.Enabled = false;

            this.ddlGrupoConexion.Enabled = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            tfr_transformador transformadorEntity = _BOTransformadorObject.ConsultarXId(Convert.ToInt32(this.hfIdTransformador.Value)) as tfr_transformador;

            ObtenerValores(transformadorEntity);
            _BOTransformadorObject.Actualizar(transformadorEntity);
            this.hfIdTransformador.Value = transformadorEntity.id.ToString();
            EnviarAModalMsj(ModalMsj1, "Transformador", "Se ha modificado correctamente el transformador");

            DesactivarControlesTransformador();
            this.btnGuardar.Visible = false;
            this.btnModificar.Visible = true;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ActivarControlesTransformador();

            btnGuardar.Visible = true;
            btnModificar.Visible = false;
        }

        protected void ucBusquedaCliente_ClienteChange(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucBusquedaCliente.IdCliente))
            {
                ucBusquedaTransformador.Visible = true;
                ucBusquedaTransformador.ActivarControlesBusqueda();
                ucBusquedaTransformador.ValidationGroupControles(string.Empty, false);
            }
        }

        protected void ucBusquedaTransformador_TransformadorChange(object sender, EventArgs e)
        {
            tfr_transformador transformadador = Session[VariablesGlobales.SESSION_TRANSFORMADOR] as tfr_transformador;
            this.pnlTabs.Visible = true;
            this.btnGuardar.Visible = false;

            AsignarDatosTransformador(transformadador);
            DesactivarControlesTransformador();
            ConsultarHistorial();
        }

        private void AsignarDatosTransformador(tfr_transformador transformadador)
        {
            this.ddlFabricante.SelectedValue = transformadador.fabricante_id.ToString();
            this.hfIdTransformador.Value = transformadador.id.ToString();
            this.txtNumSerie.Text = transformadador.numserie;
            this.txtAltura.Text = transformadador.altura;
            this.ddlSerieAT.SelectedValue = transformadador.tfrtenserieAT.ToString();
            this.ddlSerieBT.SelectedValue = transformadador.tfrtenserieBT.ToString();
            this.ddlCapacidad.SelectedValue = transformadador.tfrcapacidad.ToString();
            this.ddlFase.SelectedValue = transformadador.trffase.ToString();
            this.txtFechaFabricacion.Text = Convert.ToDateTime(transformadador.fecfabricacion).ToShortDateString();
            this.txtTempDevanado.Text = transformadador.tempdevanado;
            this.ddlAislamiento.SelectedValue = transformadador.trfaislamiento.ToString();
            this.txtFrecuencia.Text = transformadador.frecuencia.ToString();
            this.ddlRefrigeracion.SelectedValue = transformadador.trfrefrigeracion.ToString();
            this.txtVoltajeEntrada.Text = transformadador.volentrada.ToString();
            this.txtVoltajeSalida.Text = transformadador.volsalida.ToString();
            this.txtVoltajeEntDerivada.Text = transformadador.volentrada_der.ToString();
            this.txtVoltajeSalDerivada.Text = transformadador.volsalida_der.ToString();
            this.txtNumDerivaciones.Text = transformadador.derivaciones.ToString();
            this.ddlGrupoConexion.SelectedValue = transformadador.trfgrpconex.ToString();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            DesactivarControlesTransformador();
        }
    }
}