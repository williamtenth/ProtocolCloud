using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Configuration;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL;
using TS15.BL.gestion_cliente;
using TS15V2.UI.APP.util;
using TS15V2.UI.APP.abstractUI;
using TS15.BL.gestion_transformador;
using TS15.Common.util;

namespace TS15V2.UI.APP.dev.GestionCliente
{
    public partial class CrearSolicitud : UIGenericoPagina
    {
        private BOPedido _pedidoBO;
        private BOTransformador _transformadorBO;

        public CrearSolicitud()
        {
            _pedidoBO = new BOPedido();
            _transformadorBO = new BOTransformador();
        }

        protected void OnPatientChange(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(ucBusquedaCliente.IdCliente))
            //    pnlServicio.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //ucBusquedaCliente.OnPatientChange += new EventHandler(OnPatientChange);
            if (!Page.IsPostBack)
            {
                CargarListas();
                ucBusquedaCliente.ValidationGroupControles("vgCrearSolicitud", true);
            }
        }

        private void CargarTipoSolicitud()
        {
            BOParametrica parametricaBO = new BOParametrica();
            ddlTipoSolicitud.DataSource = parametricaBO.ConsultarTipoSolictudSS("tipsolicitud");
            ddlTipoSolicitud.DataValueField = "consecutivo";
            ddlTipoSolicitud.DataTextField = "valor";
            ddlTipoSolicitud.DataBind();
        }

        private void CargarListas()
        {
            CargarTipoSolicitud();
            CargarCapacidadTransformador();
        }

        private void CargarCapacidadTransformador()
        {
            this.ddlCapacidad.DataSource = Parametros.ConsultarParametros("tfrcapacidad");
            this.ddlCapacidad.DataValueField = "consecutivo";
            this.ddlCapacidad.DataTextField = "valor";
            this.ddlCapacidad.DataBind();
        }

        protected void ddlTipoSolicitud_DataBound(object sender, EventArgs e)
        {
            ddlTipoSolicitud.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlTipoSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoSolicitud.SelectedValue == "1")
            {
                ucBusquedaTransformador.Visible = true;
                ucBusquedaCliente.ValidationGroupControles(string.Empty, false);
                ucBusquedaTransformador.ValidationGroupControles("vgCrearSolicitud", true);
                OcultarControlesSuministro();
            }

            else if (ddlTipoSolicitud.SelectedValue == "2")
            {
                ucBusquedaTransformador.Visible = false;
                ucBusquedaCliente.ValidationGroupControles("vgCrearSolicitud", true);
                ucBusquedaTransformador.ValidationGroupControles(string.Empty, false);
                MostrarControlesSuministro();
            }

            else
            {
                ucBusquedaTransformador.Visible = false;
                ucBusquedaCliente.ValidationGroupControles("vgCrearSolicitud", true);
                ucBusquedaTransformador.ValidationGroupControles(string.Empty, false);
            }
        }

        private void MostrarControlesSuministro()
        {
            pnlCapacidad.Visible = true;
            pnlVolEntrada.Visible = true;
            pnlVolSalida.Visible = true;
        }

        private void OcultarControlesSuministro()
        {
            pnlCapacidad.Visible = false;
            pnlVolEntrada.Visible = false;
            pnlVolSalida.Visible = false;
        }

        protected void ddlTipoTransformador_DataBound(object sender, EventArgs e)
        {
            //ddlTipoTransformador.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlCapacidad_DataBound(object sender, EventArgs e)
        {
            ddlCapacidad.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void ddlFabricante_DataBound(object sender, EventArgs e)
        {
            //ddlFabricante.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCrearSolicitud_Click(object sender, EventArgs e)
        {
            if (ddlTipoSolicitud.SelectedValue == "1")
                CrearProcesoPruebasPreeliminares();

            else if (ddlTipoSolicitud.SelectedValue == "2")
                CrearPedidoSuministro();
        }

        private void LimpiarCampos()
        {
            this.ucBusquedaCliente.LimpiarCampos();
            this.ucBusquedaTransformador.LimpiarCampos();

            this.ucBusquedaTransformador.Visible = false;
            this.pnlCapacidad.Visible = false;
            this.pnlVolEntrada.Visible = false;
            this.pnlVolSalida.Visible = false;

            this.ddlTipoSolicitud.SelectedValue = "-1";
            this.ddlCapacidad.SelectedValue = "-1";
            this.txtVolEntrada.Text = string.Empty;
            this.txtVolSalida.Text = string.Empty;
        }

        private void CrearProcesoPruebasPreeliminares()
        {
            if (!string.IsNullOrEmpty(ucBusquedaCliente.IdCliente) && !string.IsNullOrEmpty(ucBusquedaTransformador.IdTransformador))
            {
                string idTransformador = ucBusquedaTransformador.IdTransformador;
                if (!_transformadorBO.EsAsignadoCliente(idTransformador))
                {
                    if (!_transformadorBO.EsAsignadoSolicitud(idTransformador))
                    {
                        cli_pedido pedidoObject = new cli_pedido();
                        pedidoObject.fechasolicitud = DateTime.Now;
                        pedidoObject.tipsolicitud = UtilNumeros.StringToBytes(this.ddlTipoSolicitud.SelectedValue);
                        pedidoObject.tiptransformador = 1; //TIPO DE TRANSFORMADOR 'DISTRIBUCION'
                        //pedidoObject.aprobado = true;
                        pedidoObject.estado = 1; //ESTADO ACTIVO DEL PEDIDO
                        pedidoObject.cliente_id = Convert.ToInt32(ucBusquedaCliente.IdCliente);
                        pedidoObject.transformador_id = Convert.ToInt32(ucBusquedaTransformador.IdTransformador);

                        _pedidoBO.CrearProcesoPruebasPreeliminares(pedidoObject);

                        EnviarAModalMsj(ModalMsj1, "Solicitud", "Se ha creado la solicitud correctamente <b>No. Solicitud: " + pedidoObject.id + "</b>");
                        LimpiarCampos();
                    }
                    else
                        EnviarAModalMsj(ModalMsj1, "Error", "No se puede seleccionar transformador, tiene solicitud activa");
                }
                else
                    EnviarAModalMsj(ModalMsj1, "Error", "No se puede seleccionar transformador, ya está asignado a otro cliente, por favor ir a la asignación de transformadores y retirar transformador");
            }
            else
                EnviarAModalMsj(ModalMsj1, "Error", "Por favor seleccione el cliente y/o transformador");
        }

        private void CrearPedidoSuministro()
        {
            cli_pedido pedidoObject = new cli_pedido();
            pedidoObject.fechasolicitud = DateTime.Now;
            pedidoObject.tipsolicitud = UtilNumeros.StringToBytes(this.ddlTipoSolicitud.SelectedValue);
            pedidoObject.cantidad = 1;//SOLO SE PUEDE CREAR UN TRANSFORMADOR;
            pedidoObject.tiptransformador = 1; //TIPO DE TRANSFORMADOR 'DISTRIBUCION'
            pedidoObject.capacidad = UtilNumeros.StringToBytes(this.ddlCapacidad.SelectedValue);
            pedidoObject.volentrada = Convert.ToDecimal(this.txtVolEntrada.Text.Trim());
            pedidoObject.volsalida = Convert.ToDecimal(this.txtVolSalida.Text.Trim());
            pedidoObject.aprobado = true;
            pedidoObject.estado = 1; //ESTADO ACTIVO DEL PEDIDO
            pedidoObject.cliente_id = Convert.ToInt32(ucBusquedaCliente.IdCliente);

            _pedidoBO.CrearPedidoSuministro(pedidoObject);

            EnviarAModalMsj(ModalMsj1, "Solicitud", "Se ha creado el pedido correctamente");
            LimpiarCampos();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            bool estado = true;
            EnableControles(estado);
        }

        private void EnableControles(bool estado)
        {

        }

        //protected void btnBuscar_Click(object sender, EventArgs e)
        //{
        //    dbTS15Entities contexto = new dbTS15Entities();
        //    RawError error = new RawError();
        //    BOCliente clienteBO = new BOCliente();

        //    gvClientes.DataSource = clienteBO.Consultar(contexto, error);
        //    gvClientes.DataBind();
        //    mpeCaficultor.Show();
        //}

        //protected void gvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{

        //}

        //protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}

        //protected void gvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';this.style.textDecoration='underline';");
        //        e.Row.Attributes["OnMouseOut"] = "this.style.textDecoration='none';";
        //        e.Row.ToolTip = "Click para seleccionar";
        //        e.Row.Attributes["OnClick"] = Page.ClientScript.GetPostBackClientHyperlink(gvClientes, "Select$" + e.Row.RowIndex);
        //    }
        //}

        //protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string idCliente = gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[0].ToString();
        //    string nombreCliente = gvClientes.DataKeys[gvClientes.SelectedRow.RowIndex].Values[1].ToString();

        //    this.hfIdCliente.Value = idCliente;
        //    this.lblNombreCliente.Text = nombreCliente;
        //    this.pnlMsj.CssClass = "alert alert-success";
        //    this.pnlMsj.Visible = true;

        //    CargarTipoSolicitud();
        //    this.pnlTipoSolicitud.Visible = true;
        //}
    }
}