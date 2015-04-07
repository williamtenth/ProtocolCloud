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
using TS15.BL.Gestion_Cliente;

namespace TS15.UI.APP.componentes
{
    public partial class BuscarCliente : System.Web.UI.UserControl
    {
        public event EventHandler OnPatientChange;

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
                ddlTipDocumento.DataValueField = "consecutivo";
                ddlTipDocumento.DataTextField = "descripcion";
                ddlTipDocumento.DataBind();
            }
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