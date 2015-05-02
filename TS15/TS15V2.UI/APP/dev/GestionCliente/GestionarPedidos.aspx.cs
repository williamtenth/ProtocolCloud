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
        private BOCliente _BOCliente;

        public GestionarPedidos()
        {
            _BOCliente = new BOCliente();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucBusquedaCliente.ValidationGroupControles(string.Empty, false);
            }
        }

        protected void ucBusquedaCliente_PatientChange(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ucBusquedaCliente.IdCliente))
                pnlGrilla.Visible = true;
        }

        private void ConsultarSolicitudes()
        {
            if (!string.IsNullOrEmpty(ucBusquedaCliente.IdCliente))
            {
                int idCliente = Convert.ToInt32(ucBusquedaCliente.IdCliente);
                gvSolicitudesCliente.DataSource = _BOCliente.ConsultarPedidosSolicitudCliente(idCliente);
                gvSolicitudesCliente.DataBind();
            }
        }

        private void Page_LoadComplete(object sender, EventArgs e)
        {
            ConsultarSolicitudes();
        }

        protected void gvSolicitudesCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}