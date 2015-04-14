using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL;
using AjaxControlToolkit;
using TS15.BL.gestion_cliente;
using System.Web.Security;
using TS15.Common;
using System.Web.Configuration;
using TS15V2.UI.APP.util;
using TS15V2.UI.APP.abstractUI;

namespace TS15.UI.APP.componentes
{
    public partial class BuscarCliente : UIGenericoComponente
    {
        public event EventHandler OnPatientChange;

        //private void ValidarRoles()
        //{
        //    MembershipUser user = Membership.GetUser(true);
        //    string[] roles = Roles.GetRolesForUser(user.UserName);

        //    if (roles.Contains(WebConfigurationManager.AppSettings["ResponsableCliente"]))
        //        ActivarControles();

        //    else if (roles.Contains(WebConfigurationManager.AppSettings["Cliente"]))
        //    {
        //        ActivarControles();
        //        CargarCliente();
        //    }

        //    else
        //    {
        //        this.hfIdCliente.Value = string.Empty;
        //        this.lblNombreCliente.Text = "No se puede realizar la busqueda de clientes, por favor valide sus permisos.";
        //        this.pnlMsj.CssClass = "alert alert-error";
        //        this.pnlMsj.Visible = true;
        //    }
        //}

        //private void ActivarControles()
        //{
        //    this.ddlTipDocumento.Enabled = true;
        //    this.txtNumDoc.Enabled = true;
        //    this.txtNumDoc.ReadOnly = false;
        //    this.btnBuscar.Enabled = true;
        //}

        private void CargarCliente()
        {

            VW_CLI_USUARIO cliente = ValidadorCliente.ValidarCliente(SingletonControlador.Error);

            this.ddlTipDocumento.SelectedValue = cliente.tipdoc.ToString();
            this.txtNumDoc.Text = cliente.numdocumento;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarListas();
                //ValidarRoles();
            }
        }

        private void CargarListas()
        {
            CargarTipoDocumento();
        }

        private void CargarTipoDocumento()
        {
            ddlTipDocumento.DataSource = TS15V2.UI.APP.util.Parametros.ConsultarParametros("tipdoc");
            ddlTipDocumento.DataValueField = "consecutivo";
            ddlTipDocumento.DataTextField = "descripcion";
            ddlTipDocumento.DataBind();
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
            mpeClientes.Show();
        }

        protected void gvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';this.style.textDecoration='underline';");
                e.Row.Attributes["OnMouseOut"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Click para seleccionar";
                e.Row.Attributes["OnClick"] = Page.ClientScript.GetPostBackClientHyperlink(gvClientes, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idCliente = gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[0].ToString();
            string nombreCliente = gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[1].ToString();
            string tipDocumento = gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[2].ToString();
            string numDocumento = gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[3].ToString();

            this.hfIdCliente.Value = idCliente;
            this.lblNombreCliente.Text = nombreCliente;
            this.pnlMsj.CssClass = "alert alert-success";
            this.pnlMsj.Visible = true;

            this.ddlTipDocumento.SelectedValue = tipDocumento;
            this.txtNumDoc.Text = numDocumento;

            if (this.OnPatientChange != null) this.OnPatientChange(sender, e);
        }

        public string IdCliente
        {
            get { return hfIdCliente.Value; }
        }
    }
}