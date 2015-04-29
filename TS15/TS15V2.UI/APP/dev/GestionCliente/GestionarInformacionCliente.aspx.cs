using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15V2.UI.APP.abstractUI;
using TS15.Common.Generated;
using TS15V2.UI.APP.util;
using util;
using TS15.BL.gestion_cliente;
using TS15.UI.APP.componentes;

namespace TS15V2.UI.APP.dev.GestionCliente
{
    public partial class GestionarInformacionCliente : UIGenericoPagina
    {
        private BOCliente _BOCliente;

        public GestionarInformacionCliente()
        {
            _BOCliente = new BOCliente();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucBusquedaCliente.ValidationGroupControles(string.Empty, false);
                CargarListasCliente();
                ConsultarHistorial();
            }
        }

        protected void ucBusquedaCliente_PatientChange(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucBusquedaCliente.IdCliente))
                pnlTabs.Visible = true;
        }

        private void Page_LoadComplete(object sender, EventArgs e)
        {
            ConsultarHistorial();
        }

        private void ConsultarHistorial()
        {
            if (!string.IsNullOrEmpty(ucBusquedaCliente.IdCliente))
            {
                int idCliente = Convert.ToInt32(ucBusquedaCliente.IdCliente);
                gvTransformadoresCliente.DataSource = _BOCliente.ConsultarTransformadoresAsignados(idCliente);
                gvTransformadoresCliente.DataBind();
            }
        }

        private void CargarListasCliente()
        {
            CargarTipoDocumento();
            CargarTipoCliente();
        }

        private void CargarTipoCliente()
        {
            this.ddlTipoDocumento.DataSource = Parametros.ConsultarParametros("tipdoc");
            this.ddlTipoDocumento.DataValueField = "consecutivo";
            this.ddlTipoDocumento.DataTextField = "descripcion";
            this.ddlTipoDocumento.DataBind();
        }

        private void CargarTipoDocumento()
        {
            this.ddlTipoCliente.DataSource = Parametros.ConsultarParametros("tiptercero");
            this.ddlTipoCliente.DataValueField = "consecutivo";
            this.ddlTipoCliente.DataTextField = "descripcion";
            this.ddlTipoCliente.DataBind();
        }

        private void ValidarCliente()
        {
            if (!string.IsNullOrEmpty(ucBusquedaCliente.IdCliente))
            {
                cli_cliente clienteObject = (cli_cliente)Session[VariablesGlobales.SESION_CLIENTE];

                this.ddlTipoDocumento.SelectedValue = clienteObject.tipdoc.ToString();
                this.txtNumeroDocumento.Text = clienteObject.numdocumento;
                this.txtDireccion.Text = clienteObject.direccion;
                this.txtTelefono.Text = clienteObject.telefono;
                this.hfIdCliente.Value = clienteObject.id.ToString();
                this.ddlTipoCliente.SelectedValue = clienteObject.tiptercero.ToString();
            }

            else
            {
                this.ddlTipoDocumento.SelectedValue = "-1";
                this.txtNumeroDocumento.Text = string.Empty;
                this.txtDireccion.Text = string.Empty;
                this.txtTelefono.Text = string.Empty;
                this.hfIdCliente.Value = string.Empty;
                this.ddlTipoCliente.SelectedValue = "-1";
            }
        }

        protected void btnCrearCliente_Click(object sender, EventArgs e)
        {
            ActivarControlesCliente();
        }

        private void ActivarControlesCliente()
        {
            this.ddlTipoDocumento.Enabled = true;
            this.txtNumeroDocumento.Enabled = true;
            this.txtNombre.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.ddlTipoCliente.Enabled = true;

            btnCrearCliente.Visible = false;
            btnEliminarCliente.Visible = false;
            btnModificarCliente.Visible = false;

            btnGuardarCliente.Visible = true;
            btnCancelar.Visible = true;

        }

        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {
            ModificarCliente();
        }

        private void ModificarCliente()
        {
            cli_cliente clienteObject = (cli_cliente)Session[VariablesGlobales.SESION_CLIENTE];
            this.hfIdCliente.Value = ucBusquedaCliente.IdCliente;

            this.txtNombre.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.txtTelefono.Enabled = true;

            this.txtNombre.Text = clienteObject.nombre;
            this.txtNumeroDocumento.Text = clienteObject.numdocumento;
            this.txtDireccion.Text = clienteObject.direccion;
            this.txtTelefono.Text = clienteObject.telefono;

            this.ddlTipoDocumento.SelectedValue = clienteObject.tipdoc.ToString();
            this.ddlTipoCliente.SelectedValue = clienteObject.tiptercero.ToString();

            this.btnCrearCliente.Visible = false;
            this.btnModificarCliente.Visible = false;
            this.btnEliminarCliente.Visible = false;

            this.btnGuardarCliente.Visible = true;
            this.btnCancelar.Visible = true;
        }

        protected void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            EnviarAModalMsj(ModalMsj1, "Error", "No se puede eliminar cliente, verificar transformadores asignados y ordenes de fabricación/reparación/mantenimiento");
        }

        protected void ddlTipoDocumento_DataBound(object sender, EventArgs e)
        {
            ddlTipoDocumento.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            cli_cliente clienteObject;

            if (string.IsNullOrEmpty(hfIdCliente.Value))
            {
                clienteObject = new cli_cliente();
                clienteObject.nombre = txtNombre.Text.Trim();
                clienteObject.tipdoc = UtilNumeros.StringToBytes(ddlTipoDocumento.SelectedValue);
                clienteObject.numdocumento = txtNumeroDocumento.Text.Trim();
                clienteObject.direccion = txtDireccion.Text.Trim();
                clienteObject.telefono = txtTelefono.Text.Trim();
                clienteObject.tiptercero = Convert.ToInt32(ddlTipoCliente.SelectedValue);

                if (!_BOCliente.ExisteCliente(clienteObject))
                {
                    EnviarAModalMsj(ModalMsj1, string.Empty, "Se ha creado exitosamente el cliente.");
                    _BOCliente.Crear(clienteObject);
                }

                else
                    EnviarAModalMsj(ModalMsj1, "Error", "No se puede crear, Cliente ya existe");
            }
            else
            {
                clienteObject = (cli_cliente)Session[VariablesGlobales.SESION_CLIENTE];
                clienteObject.nombre = this.txtNombre.Text;
                clienteObject.direccion = this.txtDireccion.Text;
                clienteObject.telefono = this.txtTelefono.Text;

                _BOCliente.Actualizar(clienteObject);

                EnviarAModalMsj(ModalMsj1, string.Empty, "Se ha modificado exitosamente cliente");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/APP/dev/GestionCliente/GestionarInformacionCliente.aspx");
        }

        private void DesactivarControlesCliente()
        {
            this.ddlTipoDocumento.Enabled = false;
            this.txtNumeroDocumento.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtTelefono.Enabled = false;
            this.ddlTipoCliente.Enabled = false;

            btnCrearCliente.Visible = true;
            btnEliminarCliente.Visible = true;
            btnModificarCliente.Visible = true;

            btnGuardarCliente.Visible = false;
            btnCancelar.Visible = false;

            this.hfIdCliente.Value = string.Empty;
        }

        protected void ddlTipoCliente_DataBound(object sender, EventArgs e)
        {
            ddlTipoCliente.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }
    }
}