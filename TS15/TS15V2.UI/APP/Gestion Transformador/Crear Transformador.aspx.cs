using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL;

namespace TS15.UI.APP.systems.Gestion_Transformador
{
    public partial class Crear_Transformador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarListas();
                CargarValoresPorDefecto();
            }
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

        private void CargarFabricante()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            this.ddlFabricante.DataSource = BOCliente.ConsultarFabricantes(contexto, error);
            this.ddlFabricante.DataValueField = "id";
            this.ddlFabricante.DataTextField = "nombre";
            this.ddlFabricante.DataBind();
        }

        private void CargarSerieAT()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            this.ddlSerieAT.DataSource = BOParametrica.ConsultarParametros("tfrtenserie", contexto, error);
            this.ddlSerieAT.DataValueField = "consecutivo";
            this.ddlSerieAT.DataTextField = "valor";
            this.ddlSerieAT.DataBind();
        }

        private void CargarSerieBT()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            this.ddlSerieBT.DataSource = BOParametrica.ConsultarParametros("tfrtenserie", contexto, error);
            this.ddlSerieBT.DataValueField = "consecutivo";
            this.ddlSerieBT.DataTextField = "valor";
            this.ddlSerieBT.DataBind();
        }

        private void CargarCapacidad()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            this.ddlCapacidad.DataSource = BOParametrica.ConsultarParametros("tfrcapacidad", contexto, error);
            this.ddlCapacidad.DataValueField = "consecutivo";
            this.ddlCapacidad.DataTextField = "valor";
            this.ddlCapacidad.DataBind();
        }

        private void CargarFase()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            this.ddlFase.DataSource = BOParametrica.ConsultarParametros("tfrfase", contexto, error);
            this.ddlFase.DataValueField = "consecutivo";
            this.ddlFase.DataTextField = "valor";
            this.ddlFase.DataBind();
        }

        private void CargarAislamiento()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            this.ddlAislamiento.DataSource = BOParametrica.ConsultarParametros("trfaislamiento", contexto, error);
            this.ddlAislamiento.DataValueField = "consecutivo";
            this.ddlAislamiento.DataTextField = "valor";
            this.ddlAislamiento.DataBind();
        }

        private void CargarRefrigeracion()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            this.ddlRefrigeracion.DataSource = BOParametrica.ConsultarParametros("trfrefrigeracion", contexto, error);
            this.ddlRefrigeracion.DataValueField = "consecutivo";
            this.ddlRefrigeracion.DataTextField = "valor";
            this.ddlRefrigeracion.DataBind();
        }

        private void CargarGrupoConexion()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            this.ddlGrupoConexion.DataSource = BOParametrica.ConsultarParametros("trfgrpconex", contexto, error);
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            tfr_transformador transformadorEntity = new tfr_transformador();
            ObtenerValores(transformadorEntity);

            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            BOTransformador transformadorBO = new BOTransformador();
            transformadorBO.Crear(transformadorEntity, contexto, error);
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
    }
}