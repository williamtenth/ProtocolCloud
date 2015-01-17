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
    public partial class Busqueda_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarListas();
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

        static gen_parametrica PersonToEmployee(EntityObject person)
        {
            return person as gen_parametrica;
        }

        protected void ddlTipDocumento_DataBound(object sender, EventArgs e)
        {
            ddlTipDocumento.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            BOCliente clienteBO = new BOCliente();

            gvClientes.DataSource = clienteBO.Consultar(contexto, error);
            gvClientes.DataBind();

        }

        protected void ddlTipDocumento_DataBound1(object sender, EventArgs e)
        {
            ddlTipDocumento.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int intId;
            if (e.CommandName == "Ver")
            {
                GridViewRow rowSelect = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                intId = Convert.ToInt32(gvClientes.DataKeys[rowSelect.RowIndex].Values[0].ToString());

                Response.Redirect("~/APP/systems/Gestion Cliente/Detalle Cliente.aspx?IdCliente=" + intId.ToString() + "&OP=V");
            }

            else if (e.CommandName == "Editar")
            {
                GridViewRow rowSelect = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                intId = Convert.ToInt32(gvClientes.DataKeys[rowSelect.RowIndex].Values[0].ToString());

                Response.Redirect("~/APP/systems/Gestion Cliente/Detalle Cliente.aspx?IdCliente=" + intId.ToString() + "&OP=E");
            }

            else if (e.CommandName == "Eliminar")
            {
                GridViewRow rowSelect = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                intId = Convert.ToInt32(gvClientes.DataKeys[rowSelect.RowIndex].Values[0].ToString());
            }
        }
    }
}