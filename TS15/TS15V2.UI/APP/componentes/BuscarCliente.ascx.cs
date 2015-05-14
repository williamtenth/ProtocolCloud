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
using TS15.Common.util;

namespace TS15.UI.APP.componentes
{
    public partial class BuscarCliente : UIGenericoComponente
    {
        public event EventHandler ClienteChange;

        private cli_cliente _clienteObject;
        private BOCliente _BOCliente;

        public BuscarCliente()
        {
            _BOCliente = new BOCliente();
        }

        private void ValidarRoles()
        {

            if (ValidadorRol.ContieneRol(ValidadorRol.ROL_CLIENTE))
            {
                ActivarControles();
                CargarCliente();
            }

            if (ValidadorRol.ContieneRol(ValidadorRol.ROL_RESPONSABLECLIENTE))
            {
                ActivarControles();
                Session["Cliente"] = null;
            }

            else
            {
                this.hfIdCliente.Value = string.Empty;
                this.txtCliente.Text = string.Empty;
                this.pnlCliente.Visible = false;
                Session.Remove("Cliente");
            }
        }

        public void ActivarControlesBusqueda()
        {
            this.ddlTipDocumento.Enabled = true;
            this.txtNumDoc.Enabled = true;
            this.txtNumDoc.ReadOnly = false;
            this.btnBuscar.Enabled = true;
        }

        private void CargarCliente()
        {

            vw_cli_usuario vw_cli_usuario = ValidadorCliente.ValidarCliente(SingletonControlador.Error);

            this.ddlTipDocumento.SelectedValue = vw_cli_usuario.tipdoc.ToString();
            this.txtNumDoc.Text = vw_cli_usuario.numdocumento;
            this.hfIdCliente.Value = vw_cli_usuario.cliente_id.ToString();

            _clienteObject = (cli_cliente)_BOCliente.ConsultarXId(vw_cli_usuario.cliente_id);

            //CARGA EL CLIENTE EN LA SESION
            Session["Cliente"] = _clienteObject;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["Cliente"] = null;
                CargarListas();
                ValidarRoles();
            }
        }

        private void CargarListas()
        {
            CargarTipoDocumento();
        }

        private void CargarTipoDocumento()
        {
            ddlTipDocumento.DataSource = Parametros.ConsultarParametros("tipdoc");
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
            ConsultarClientes();
        }

        private void ConsultarClientes()
        {

            gvClientes.DataSource = _BOCliente.Consultar();
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
            int idCliente = Convert.ToInt32(gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[0].ToString());
            string nombreCliente = gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[1].ToString();
            string tipDocumento = gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[2].ToString();
            string numDocumento = gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[3].ToString();

            this.hfIdCliente.Value = idCliente.ToString();
            this.txtCliente.Text = nombreCliente;
            this.pnlCliente.Visible = true;

            //this.lblNombreCliente.Text = nombreCliente;
            //this.pnlMsj.CssClass = "alert alert-success";
            //this.pnlContentMsj.Visible = true;

            this.ddlTipDocumento.SelectedValue = tipDocumento;
            this.txtNumDoc.Text = numDocumento;

            // Delegate the event to the caller
            if (this.ClienteChange != null) this.ClienteChange(sender, e);

            cli_cliente clienteObject = _BOCliente.ConsultarXId(idCliente) as cli_cliente;
            Session[VariablesGlobales.SESION_CLIENTE] = clienteObject;
        }

        public string IdCliente
        {
            get { return hfIdCliente.Value; }
        }

        public void ValidationGroupControles(string validationGroup, bool enabled)
        {
            this.rfv_ddlTipDocumento.ValidationGroup = validationGroup;
            this.rfv_txtCliente.ValidationGroup = validationGroup;
            this.rfv_txtNumDoc.ValidationGroup = validationGroup;

            this.rfv_ddlTipDocumento.Enabled = enabled;
            this.rfv_txtCliente.Enabled = enabled;
            this.rfv_txtNumDoc.Enabled = enabled;

        }

        protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClientes.PageIndex = e.NewPageIndex;
            ConsultarClientes();
        }

        internal void LimpiarCampos()
        {
            this.ddlTipDocumento.SelectedValue = "-1";
            this.txtNumDoc.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.hfIdCliente.Value = string.Empty;
        }
    }
}