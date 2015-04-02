using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL;
using TS15.BL.Gestion_Cliente;
using System.Web.Security;
using TS15.Common;

namespace TS15.UI.APP.systems.Gestion_Transformador
{
    public partial class Busqueda_Transformador : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ValidarRoles();
        }

        private void ValidarRoles()
        {
            MembershipUser user = Membership.GetUser(true);
            string[] userRoles = Roles.GetRolesForUser(user.UserName);

            if (userRoles.Count() == 0)
                Response.Redirect("~/APP/AccesoDenegado.aspx");

            else if (Roles.FindUsersInRole(Enums.Roles.Cliente.ToString(), user.UserName).Count() > 0)
                ddlFabricante.Enabled = false;

            //else if(Roles.FindUsersInRole(Enums.Roles.ResponsableCliente.ToString(), user.UserName).Count() > 0)

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarListas();
        }

        private void CargarListas()
        {
            CargarFabricantes();
        }

        private void CargarFabricantes()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            ddlFabricante.DataSource = BOCliente.ConsultarFabricantes(contexto, error);
            ddlFabricante.DataValueField = "id";
            ddlFabricante.DataTextField = "nombre";
            ddlFabricante.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();


            gvTransformadores.DataSource = BOCliente.ConsultarFabricantes(contexto, error);
            gvTransformadores.DataBind();

            mpeTransformadores.Show();
        }

        protected void ddlFabricante_DataBound(object sender, EventArgs e)
        {
            this.ddlFabricante.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void gvTransformadores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';this.style.textDecoration='underline';");
                e.Row.Attributes["OnMouseOut"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Click para seleccionar";
                e.Row.Attributes["OnClick"] = Page.ClientScript.GetPostBackClientHyperlink(gvTransformadores, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvTransformadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idCliente = gvTransformadores.DataKeys[gvTransformadores.SelectedRow.RowIndex].Values[0].ToString();
            string nombreCliente = gvTransformadores.DataKeys[gvTransformadores.SelectedRow.RowIndex].Values[1].ToString();

            //this.hfIdCliente.Value = idCliente;
            //this.lblNombreCliente.Text = nombreCliente;
            //this.pnlMsj.CssClass = "alert alert-success";
            //this.pnlMsj.Visible = true;

            //CargarTipoSolicitud();
            //this.pnlTipoSolicitud.Visible = true;
        }
    }
}