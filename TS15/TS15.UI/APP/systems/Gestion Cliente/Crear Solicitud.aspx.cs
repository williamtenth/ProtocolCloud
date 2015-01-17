using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL;
using System.Data.Objects.DataClasses;

namespace TS15.UI.APP.systems.Gestion_Cliente
{
    public partial class Crear_Solicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarListas();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            pnlMsj.Visible = false;
            lblNombreCliente.Text = string.Empty;

            BOCliente clienteBO = new BOCliente();
            cli_cliente entityCliente = clienteBO.BuscarCliente(ddlTipDocumento.SelectedValue, txtNumDoc.Text.Trim(), contexto, error);

            if (entityCliente != null)
            {
                lblNombreCliente.Text = entityCliente.nombre;
                hfIdCliente.Value = entityCliente.id.ToString();
                CargarTipoSolicitud();
            }
            else
                pnlMsj.Visible = true;
        }

        private void CargarTipoSolicitud()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            ddlTipoSolicitud.DataSource = BOParametrica.ConsultarParametros("tipsuministro", contexto, error);
            ddlTipoSolicitud.DataBind();
        }

        private void CargarListas()
        {
            CargarTipoDocumento();
        }

        private void CargarTipoDocumento()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            ddlTipDocumento.DataSource = BOParametrica.ConsultarParametros("tipdoc", contexto, error);

            if (!error.Error)
            {
                ddlTipDocumento.DataValueField = "tipo";
                ddlTipDocumento.DataTextField = "descripcion";
                ddlTipDocumento.DataBind();
            }
        }

        protected void ddlTipDocumento_DataBound(object sender, EventArgs e)
        {
            ddlTipDocumento.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlTipoSolicitud_DataBound(object sender, EventArgs e)
        {
            ddlTipoSolicitud.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlTipoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoSolicitud.SelectedValue == "1")
            {
                pnlServicio.Visible = true;
                pnlSuministro.Visible = false;
            }
            else if (ddlTipoSolicitud.SelectedValue == "2")
            {
                CargarFabricante();
                pnlServicio.Visible = false;
                pnlSuministro.Visible = true;
            }
            else
            {
                pnlServicio.Visible = false;
                pnlSuministro.Visible = false;
            }
        }

        private void CargarFabricante()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            ddlFabricante.DataSource = BOCliente.ConsultarFabricantes(contexto, error);
            ddlFabricante.DataValueField = "id";
            ddlFabricante.DataTextField = "nombre";
            ddlFabricante.DataBind();
        }

        protected void ddlTipoTransformador_DataBound(object sender, EventArgs e)
        {
            ddlTipoTransformador.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlCapacidad_DataBound(object sender, EventArgs e)
        {
            ddlCapacidad.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlFabricante_DataBound(object sender, EventArgs e)
        {
            ddlFabricante.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }
    }
}