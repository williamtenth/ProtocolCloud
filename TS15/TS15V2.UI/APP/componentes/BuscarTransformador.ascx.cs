using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL.Gestion_Cliente;
using TS15.BL.Gestion_Transformador;
using System.Web.Security;
using System.Web.Configuration;

namespace TS15V2.UI.APP.componentes
{
    public partial class BuscarTransformador : System.Web.UI.UserControl
    {
        private void ValidarRoles()
        {
            MembershipUser user = Membership.GetUser(true);
            string[] roles = Roles.GetRolesForUser(user.UserName);

            if (roles.Contains(WebConfigurationManager.AppSettings["ResponsableCliente"]) || roles.Contains(WebConfigurationManager.AppSettings["ResponsableTransformador"]) || roles.Contains(WebConfigurationManager.AppSettings["ResponsableProtocolo"]))
                ActivarControles();

            else if (roles.Contains(WebConfigurationManager.AppSettings["Cliente"]))
                ActivarControles();
        }

        private void ActivarControles()
        {
            this.ddlFabricante.Enabled = true;
            this.txtNumSerie.Enabled = true;
            this.txtNumSerie.ReadOnly = false;
            this.btnBuscarTranformador.Enabled = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarListas();
        }

        private void CargarListas()
        {
            CargarFabricante();
        }

        private void CargarFabricante()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            BOCliente clienteBO = new BOCliente();

            this.ddlFabricante.DataSource = clienteBO.ConsultarFabricantes(contexto, error);
            this.ddlFabricante.DataValueField = "id";
            this.ddlFabricante.DataTextField = "nombre";
            this.ddlFabricante.DataBind();
        }

        protected void ddlFabricante_DataBound(object sender, EventArgs e)
        {
            this.ddlFabricante.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void btnBuscarTranformador_Click(object sender, EventArgs e)
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            BOTransformador transformadorBO = new BOTransformador();
            string idCliente = ucBusquedaCliente.IdCliente;

            if (!string.IsNullOrEmpty(idCliente))
            {
                gvTransformadores.DataSource = transformadorBO.ConsultarTransformadoresCliente(idCliente, contexto, error);
                gvTransformadores.DataBind();
                mpeTransformador.Show();
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
    }
}