using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15V2.UI.APP.abstractUI;
using TS15.BL.gestion_cliente;

namespace TS15V2.UI.APP.dev.GestionUsuarios
{
    public partial class GestionarCuentas : UIGenericoPagina
    {
        private BOCliente _BOCliente;

        public GestionarCuentas()
        {
            _BOCliente = new BOCliente();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarListasGestionUsuarios();
        }

        private void CargarListasGestionUsuarios()
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            this.ddlCliente.DataSource = _BOCliente.Consultar();
            this.ddlCliente.DataTextField = "nombre";
            this.ddlCliente.DataValueField = "id";
            this.ddlCliente.DataBind();
        }

        protected void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {

        }

        protected void ddlCliente_DataBound(object sender, EventArgs e)
        {
            this.ddlCliente.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }
    }
}