using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL;
using TS15.BL.Gestion_Cliente;

namespace TS15.UI.APP.componentes
{
    public partial class BuscarCliente : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.Page.IsPostBack)
                CargarTipoDocumento();
        }

        private void CargarTipoDocumento()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            ddlTipDocumento.DataSource = BOParametrica.ConsultarParametros("tipdoc", contexto, error);

            if (!error.Error)
            {
                ddlTipDocumento.DataValueField = "tipo";
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
            mpeCaficultor.Show();
        }

        protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}