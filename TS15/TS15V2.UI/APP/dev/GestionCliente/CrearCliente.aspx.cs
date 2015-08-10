using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.BL.gestion_cliente;
using TS15.Common.Generated;
using TS15V2.UI.APP.abstractUI;

namespace TS15V2.UI.APP.dev.GestionCliente
{
    public partial class CrearCliente : UIGenericoPagina
    {
        private BOCliente _BOCliente;
        public CrearCliente()
        {
            _BOCliente = new BOCliente();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarListas();
        }

        private void CargarListas()
        {
            CargarTipoDocumento();
            CargarTipoCliente();
        }

        private void CargarTipoCliente()
        {
            this.ddlTipoCliente.DataSource = util.Parametros.ConsultarParametros("tiptercero");
            this.ddlTipoCliente.DataValueField = "consecutivo";
            this.ddlTipoCliente.DataTextField = "valor";
            this.ddlTipoCliente.DataBind();
        }

        private void CargarTipoDocumento()
        {
            this.ddlTipDocumento.DataSource = util.Parametros.ConsultarParametros("tipdoc");
            this.ddlTipDocumento.DataValueField = "consecutivo";
            this.ddlTipDocumento.DataTextField = "valor";
            this.ddlTipDocumento.DataBind();
        }

        protected void ddlTipDocumento_DataBound(object sender, EventArgs e)
        {
            ddlTipDocumento.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlTipoCliente_DataBound(object sender, EventArgs e)
        {
            ddlTipoCliente.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void btnCrearCliente_Click(object sender, EventArgs e)
        {
            cli_cliente clienteObj = new cli_cliente();
            clienteObj.nombre = this.txtNombreCliente.Text.Trim();
            clienteObj.tipdoc = Convert.ToByte(this.ddlTipDocumento.SelectedValue);
            clienteObj.numdocumento = this.txtNumDoc.Text.Trim();
            clienteObj.direccion = this.txtDireccion.Text.Trim();
            clienteObj.telefono = this.txtTelefono.Text.Trim();
            clienteObj.tiptercero = Convert.ToInt32(this.ddlTipoCliente.SelectedValue);

            if (_BOCliente.Crear(clienteObj))
            {
                EnviarAModalMsj(ModalMsj1, "Cliente", "Se ha creado correctamente el cliente: <b>" + clienteObj.nombre + "</b>");
                LimpiarCampos();
            }
            else
                EnviarAModalMsj(ModalMsj1, "Cliente", "Ocurrio un error al crear el cliente, si el error persiste consulte con el administrador del sistema.");

        }

        private void LimpiarCampos()
        {
            this.txtNombreCliente.Text = string.Empty;
            this.ddlTipDocumento.SelectedValue = "-1";
            this.txtNumDoc.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.ddlTipoCliente.SelectedValue = "-1";
        }
    }
}