using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL.gestion_cliente;
using System.Data.Objects.DataClasses;
using TS15.BL;
using TS15V2.UI.APP.util;
using TS15V2.UI.APP.abstractUI;

namespace TS15V2.UI.APP.dev.GestionCliente
{
    public partial class BusquedaCliente : UIGenericoPagina
    {
        public BusquedaCliente()
        { }

        protected void Page_Load(object sender, EventArgs e)
        {
            //MembershipUser user = Membership.GetUser(true);
            //BOCliente clienteBO = new BOCliente();
            //string[] userRoles = Roles.GetRolesForUser(user.UserName);

            if (!Page.IsPostBack)
                CargarListas();
        }

        private void CargarListas()
        {
            CargarTipoDocumento();
        }

        private void CargarTipoDocumento()
        {
            ddlTipDocumento.DataSource = util.Parametros.ConsultarParametros("tipdoc");
            ddlTipDocumento.DataValueField = "consecutivo";
            ddlTipDocumento.DataTextField = "valor";
            ddlTipDocumento.DataBind();
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

            gvClientes.DataSource = clienteBO.Consultar();
            gvClientes.DataBind();

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

        protected void gvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.TableSection = TableRowSection.TableHeader;
        }
    }
}