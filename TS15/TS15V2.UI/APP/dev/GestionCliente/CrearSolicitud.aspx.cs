using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Configuration;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL;
using TS15.BL.gestion_cliente;

namespace TS15V2.UI.APP.dev.GestionCliente
{
    public partial class CrearSolicitud : System.Web.UI.Page
    {
        override protected void OnInit(EventArgs e)
        {
            //ValidarUsuario();
        }

        private void ValidarUsuario()
        {
            //MembershipUser user = Membership.GetUser(true);
            //string[] roles = Roles.GetRolesForUser(user.UserName);

            //if (!roles.Contains(WebConfigurationManager.AppSettings["ResponsableCliente"]))
            //    Response.Redirect("~/APP/AccesoDenegado.aspx");
        }

        //private void InitializeComponent()
        //{
        //    this.Load += new System.EventHandler(this.Page_Load);

        //}

        protected void OnPatientChange(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(ucBusquedaCliente.IdCliente))
            //    pnlServicio.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //ucBusquedaCliente.OnPatientChange += new EventHandler(OnPatientChange);
            if (!Page.IsPostBack)
                CargarListas();
        }

        private void CargarTipoSolicitud()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            ddlTipoSolicitud.DataSource = BOParametrica.ConsultarTipoSolictudSS("tipsolicitud", contexto, error);
            ddlTipoSolicitud.DataValueField = "consecutivo";
            ddlTipoSolicitud.DataTextField = "valor";
            ddlTipoSolicitud.DataBind();
        }

        private void CargarListas()
        {
            CargarTipoDocumento();
            CargarFabricante();
            CargarTipoSolicitud();
        }

        private void CargarTipoDocumento()
        {
            //dbTS15Entities contexto = new dbTS15Entities();
            //RawError error = new RawError();
            //ddlTipDocumento.DataSource = BOParametrica.ConsultarParametros("tipdoc", contexto, error);

            //if (!error.Error)
            //{
            //    ddlTipDocumento.DataValueField = "tipo";
            //    ddlTipDocumento.DataTextField = "descripcion";
            //    ddlTipDocumento.DataBind();
            //}
        }

        //protected void ddlTipDocumento_DataBound(object sender, EventArgs e)
        //{
        //    ddlTipDocumento.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        //}

        protected void ddlTipoSolicitud_DataBound(object sender, EventArgs e)
        {
            ddlTipoSolicitud.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlTipoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoSolicitud.SelectedValue == "1")
            {
                this.pnlServicio.Visible = true;
                this.btnCrearSolicitud.Visible = true;
                this.btnCancelar.Visible = true;
            }
            else if (ddlTipoSolicitud.SelectedValue == "2")
            {
                this.pnlServicio.Visible = false;
                this.btnCrearSolicitud.Visible = true;
                this.btnCancelar.Visible = true;
            }
            else
            {
                this.pnlServicio.Visible = false;
                this.btnCrearSolicitud.Visible = false;
                this.btnCancelar.Visible = false;
            }
        }

        private void CargarFabricante()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            BOCliente clienteBO = new BOCliente();

            //ddlFabricante.DataSource = clienteBO.ConsultarFabricantes(contexto, error);
            //ddlFabricante.DataValueField = "id";
            //ddlFabricante.DataTextField = "nombre";
            //ddlFabricante.DataBind();
        }

        protected void ddlTipoTransformador_DataBound(object sender, EventArgs e)
        {
            //ddlTipoTransformador.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlCapacidad_DataBound(object sender, EventArgs e)
        {
            //ddlCapacidad.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlFabricante_DataBound(object sender, EventArgs e)
        {
            //ddlFabricante.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCrearSolicitud_Click(object sender, EventArgs e)
        {

        }

        //protected void btnBuscar_Click(object sender, EventArgs e)
        //{
        //    dbTS15Entities contexto = new dbTS15Entities();
        //    RawError error = new RawError();
        //    BOCliente clienteBO = new BOCliente();

        //    gvClientes.DataSource = clienteBO.Consultar(contexto, error);
        //    gvClientes.DataBind();
        //    mpeCaficultor.Show();
        //}

        //protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //}

        //protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}

        //protected void gvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';this.style.textDecoration='underline';");
        //        e.Row.Attributes["OnMouseOut"] = "this.style.textDecoration='none';";
        //        e.Row.ToolTip = "Click para seleccionar";
        //        e.Row.Attributes["OnClick"] = Page.ClientScript.GetPostBackClientHyperlink(gvClientes, "Select$" + e.Row.RowIndex);
        //    }
        //}

        //protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string idCliente = gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[0].ToString();
        //    string nombreCliente = gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[1].ToString();

        //    this.hfIdCliente.Value = idCliente;
        //    this.lblNombreCliente.Text = nombreCliente;
        //    this.pnlMsj.CssClass = "alert alert-success";
        //    this.pnlMsj.Visible = true;

        //    CargarTipoSolicitud();
        //    this.pnlTipoSolicitud.Visible = true;
        //}
    }
}