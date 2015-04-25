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
        //public event EventHandler OnPatientChange;
        private cli_cliente _cliente;
        private BOCliente _clienteBO;

        public BuscarCliente()
        {
            _clienteBO = new BOCliente();
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

        private void ActivarControles()
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

            _cliente = (cli_cliente)_clienteBO.ConsultarXId(vw_cli_usuario.cliente_id);

            //CARGA EL CLIENTE EN LA SESION
            Session["Cliente"] = _cliente;
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
            this.txtCliente.Text = nombreCliente;
            this.pnlCliente.Visible = true;

            //this.lblNombreCliente.Text = nombreCliente;
            //this.pnlMsj.CssClass = "alert alert-success";
            //this.pnlContentMsj.Visible = true;

            this.ddlTipDocumento.SelectedValue = tipDocumento;
            this.txtNumDoc.Text = numDocumento;

            //if (this.OnPatientChange != null) this.OnPatientChange(sender, e);
        }

        public string IdCliente
        {
            get { return hfIdCliente.Value; }
        }

        public void ValidationGroupControles(string validationGroup)
        {
            this.rfv_ddlTipDocumento.ValidationGroup = validationGroup;
            this.rfv_txtCliente.ValidationGroup = validationGroup;
        }
    }
}