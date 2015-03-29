using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL;
using System.Data.Objects.DataClasses;

namespace TS15.UI.APP.systems.Gestion_Cliente
{
    public partial class Detalle_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Request.QueryString["IdCliente"] != null && Request.QueryString["OP"] != null)
                CargarDatosCliente();
        }

        private void CargarDatosCliente()
        {
            int idCliente = Convert.ToInt32(Request.QueryString["IdCliente"]);
            string OP = Request.QueryString["OP"];

            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            BOCliente clienteBO = new BOCliente();

            EntityObject objectCliente = clienteBO.ConsultarXId(idCliente, contexto, error);
            cli_cliente EntityCliente = objectCliente as cli_cliente;

            //ASIGNAR EL VALOR DE LOS CAMPOS
            hfIdCliente.Value = EntityCliente.id.ToString();
            txtNombre.Text = EntityCliente.nombre;
            //txtTipDoc.Text = 
            txtNumDoc.Text = EntityCliente.numdocumento;
            txtDireccion.Text = EntityCliente.direccion;
            txtTelefono.Text = EntityCliente.telefono;

            if (OP == "V")
            {
                txtDireccion.Enabled = false;
                txtDireccion.ReadOnly = true;
                txtTelefono.Enabled = false;
                txtTelefono.ReadOnly = true;
                btnGuardar.Visible = false;
            }

            else if (OP == "E")
            {
                txtDireccion.Enabled = true;
                txtDireccion.ReadOnly = false;
                txtTelefono.Enabled = true;
                txtTelefono.ReadOnly = false;
                btnGuardar.Visible = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //ACTUALIZA LA TABLA CLI_CLIENTE
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            BOCliente clienteBO = new BOCliente();

            EntityObject objectCliente = clienteBO.ConsultarXId(Convert.ToInt32(hfIdCliente.Value), contexto, error);
            cli_cliente EntityCliente = objectCliente as cli_cliente;

            EntityCliente.direccion = txtDireccion.Text.Trim();
            EntityCliente.telefono = txtTelefono.Text.Trim();

            objectCliente = EntityCliente as EntityObject;
            clienteBO.Actualizar(objectCliente, contexto, error);

            Response.Redirect("~/APP/systems/Gestion Cliente/Detalle Cliente.aspx?IdCliente=" + hfIdCliente.Value + "&OP=V");
        }
    }
}