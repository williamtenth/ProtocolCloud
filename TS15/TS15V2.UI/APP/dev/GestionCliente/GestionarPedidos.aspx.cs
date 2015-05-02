using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15V2.UI.APP.abstractUI;
using TS15.BL.gestion_cliente;
using TS15.BL;
using TS15.Common.Generated;
using util;
using TS15.BL.gestion_transformador;

namespace TS15V2.UI.APP.dev.GestionCliente
{
    public partial class GestionarPedidos : UIGenericoPagina
    {
        private BOCliente _BOCliente;
        private BOParametrica _BOParametrica;
        private BOPedido _BOPedido;
        private BOTransformador _BOTransformador;

        public GestionarPedidos()
        {
            _BOCliente = new BOCliente();
            _BOParametrica = new BOParametrica();
            _BOPedido = new BOPedido();
            _BOTransformador = new BOTransformador();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucBusquedaCliente.ValidationGroupControles(string.Empty, false);
                CargarListasPedidos();
            }
        }

        private void CargarListasPedidos()
        {
            CargarCapacidad();
        }

        protected void ucBusquedaCliente_ClienteChange(object sender, EventArgs e)
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

        protected void btnModificarSolicitud_Click(object sender, EventArgs e)
        {
            string tipoSolicitud = hfTipoSolicitud.Value;

            if (tipoSolicitud == "2")
            {
                this.txtCantidad.Enabled = true;
                this.ddlCapacidad.Enabled = true;
                this.txtVolEntrada.Enabled = true;
                this.txtVolSalida.Enabled = true;
            }

            else if (tipoSolicitud == "1")
            {
                this.txtFabricante.Enabled = true;
                this.txtNumeroSerie.Enabled = true;
            }

            else if (tipoSolicitud == "3" || tipoSolicitud == "4")
            {
                this.pnlCantidad.Visible = false;
                this.pnlCapacidad.Visible = false;
                this.pnlFabricante.Visible = false;
                this.pnlNumeroSerie.Visible = false;
                this.pnlVolEntrada.Visible = false;
                this.pnlVolSalida.Visible = false;

                this.btnModificarSolicitud.Visible = false;
                this.btnEliminarSolicitud.Visible = false;
                this.btnBuscarSolicitud.Visible = false;

                this.pnlAprobado.Visible = true;
            }

            btnGuardar.Visible = true;
            btnCancelar.Visible = true;
        }

        protected void btnEliminarSolicitud_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarSolicitud_Click(object sender, EventArgs e)
        {

        }

        protected void gvSolicitudesCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvSolicitudesCliente.SelectedRow;
            string tipoSolicitud = gvSolicitudesCliente.DataKeys[row.RowIndex].Values[0].ToString();
            int idSolicitud = Convert.ToInt32(gvSolicitudesCliente.DataKeys[row.RowIndex].Values[1].ToString());

            cli_pedido pedidoObject = _BOPedido.ConsultarXId(idSolicitud) as cli_pedido;

            bool bitAprobado;

            if (pedidoObject.aprobado != null)
            {
                bitAprobado = Convert.ToBoolean(pedidoObject.aprobado);

                if (bitAprobado)
                    rblAprobado.SelectedValue = "1";
                else
                    rblAprobado.SelectedValue = "0";
            }

            if (tipoSolicitud == "2")
            {
                this.txtCantidad.Text = pedidoObject.cantidad.ToString();
                this.ddlCapacidad.SelectedValue = pedidoObject.capacidad.ToString();
                this.txtVolEntrada.Text = pedidoObject.volentrada.ToString();
                this.txtVolSalida.Text = pedidoObject.volsalida.ToString();

                this.txtCantidad.Visible = true;
                this.ddlCapacidad.Visible = true;
                this.txtVolEntrada.Visible = true;
                this.txtVolSalida.Visible = true;

                this.pnlCantidad.Visible = true;
                this.pnlCapacidad.Visible = true;
                this.pnlVolEntrada.Visible = true;
                this.pnlVolSalida.Visible = true;

                this.pnlFabricante.Visible = false;
                this.pnlNumeroSerie.Visible = false;
            }

            else
            {
                int idTransformador = Convert.ToInt32(gvSolicitudesCliente.DataKeys[row.RowIndex].Values[2].ToString());
                vw_transformador_fabricante transFabricanteObj = _BOTransformador.ConsultarTransformadorFabricante(idTransformador);

                this.txtFabricante.Text = transFabricanteObj.nombre;
                this.txtNumeroSerie.Text = transFabricanteObj.numserie;
                this.ddlCapacidad.SelectedValue = transFabricanteObj.tfrcapacidad.ToString();
                this.txtVolEntrada.Text = transFabricanteObj.volentrada.ToString();
                this.txtVolSalida.Text = transFabricanteObj.volsalida.ToString();

                this.txtFabricante.Visible = true;
                this.txtNumeroSerie.Visible = true;
                this.ddlCapacidad.Visible = true;
                this.txtVolEntrada.Visible = true;
                this.txtVolSalida.Visible = true;

                this.pnlCantidad.Visible = false;
                this.pnlCapacidad.Visible = true;
                this.pnlVolEntrada.Visible = true;
                this.pnlVolSalida.Visible = true;

                this.pnlFabricante.Visible = true;
                this.pnlNumeroSerie.Visible = true;
            }

            this.hfIdPedido.Value = pedidoObject.id.ToString();
            this.hfTipoSolicitud.Value = pedidoObject.tipsolicitud.ToString();
            this.pnlControles.Visible = true;
        }

        private void CargarCapacidad()
        {
            this.ddlCapacidad.DataSource = _BOParametrica.ConsultarParametros("tfrcapacidad");
            this.ddlCapacidad.DataValueField = "consecutivo";
            this.ddlCapacidad.DataTextField = "descripcion";
            this.ddlCapacidad.DataBind();
        }

        protected void ddlCapacidad_DataBound(object sender, EventArgs e)
        {
            ddlCapacidad.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}