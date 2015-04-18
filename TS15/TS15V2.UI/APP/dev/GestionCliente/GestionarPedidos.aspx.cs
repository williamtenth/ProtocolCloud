using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15V2.UI.APP.abstractUI;
using TS15.BL.gestion_cliente;

namespace TS15V2.UI.APP.dev.GestionCliente
{
    public partial class GestionarPedidos : UIGenericoPagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarPedidosCliente();
        }

        private void CargarPedidosCliente()
        {
            Int32 intIdCliente = 0;
            BOCliente clienteBO = new BOCliente();
            gvPedidosCliente.DataSource = clienteBO.ConsultarPedidosCliente(intIdCliente);
        }
    }
}