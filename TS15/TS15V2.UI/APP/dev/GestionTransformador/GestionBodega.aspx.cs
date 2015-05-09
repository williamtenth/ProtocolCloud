using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.BL.gestion_transformador;
using TS15.Common.Generated;
using TS15.Common.util;
using TS15.BL;
using TS15V2.UI.APP.abstractUI;
using TS15.BL.gestion_cliente;

namespace TS15V2.UI.APP.dev.GestionTransformador
{
    public partial class GestionBodega : UIGenericoPagina
    {
        private BOTransformador _BOTransformador;
        private BOParametrica _BOParametrica;
        private BOPedido _BOPedido;

        public GestionBodega()
        {
            _BOTransformador = new BOTransformador();
            _BOParametrica = new BOParametrica();
            _BOPedido = new BOPedido();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ucBusquedaTransformador.ValidationGroupControles(string.Empty, false);
                CargarListasBodega();
            }

        }

        private void CargarListasBodega()
        {
            CargarTipoBodega();
        }

        private void CargarTipoBodega()
        {
            this.ddlTipoBodega.DataSource = _BOParametrica.ConsultarParametros("tipbodega");
            this.ddlTipoBodega.DataValueField = "consecutivo";
            this.ddlTipoBodega.DataTextField = "valor";
            this.ddlTipoBodega.DataBind();
        }

        protected void ucBusquedaTransformador_TransformadorChange(object sender, EventArgs e)
        {
            int idTransformador = Convert.ToInt32(ucBusquedaTransformador.IdTransformador);
            tfr_bodega bodegaObject = _BOTransformador.ConsultarTransformadorBodega(idTransformador);

            if (bodegaObject != null)
            {
                this.txtFechaIngreso.Text = bodegaObject.fecentrada.ToShortDateString();

                if (bodegaObject.tipbodega == "EN")
                {
                    this.ddlTipoBodega.SelectedValue = "1";
                    this.btnBodegaEntrega.Visible = true;

                    this.btnEntregarCliente.Visible = false;
                }

                else if (bodegaObject.tipbodega == "SA")
                {
                    this.ddlTipoBodega.SelectedValue = "2";
                    this.btnEntregarCliente.Visible = true;

                    this.btnBodegaEntrega.Visible = false;
                }

                this.btnBodegaEntrada.Visible = false;
            }

            else
            {
                this.txtFechaIngreso.Text = string.Empty;
                this.ddlTipoBodega.SelectedValue = "-1";
                this.btnBodegaEntrada.Visible = true;
            }
        }

        protected void ddlTipoBodega_DataBound(object sender, EventArgs e)
        {
            ddlTipoBodega.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void btnBodegaEntrada_Click(object sender, EventArgs e)
        {
            int idTransformador = Convert.ToInt32(ucBusquedaTransformador.IdTransformador);
            //tfr_bodega bodegaObject = _BOTransformador.ConsultarTransformadorBodega(idTransformador);
            tfr_bodega bodegaObject = new tfr_bodega();
            bodegaObject.fecentrada = DateTime.Now;
            bodegaObject.transformador_id = idTransformador;
            bodegaObject.tipbodega = "EN";

            string errorMsj = string.Empty;

            _BOTransformador.EnviarBodegaEntrada(bodegaObject, out errorMsj);

            if (string.IsNullOrEmpty(errorMsj))
                EnviarAModalMsj(ucMsjModal, "Ingresar Bodega Entrada", "Se asignado el transformador exitosamente a la bodega de entrada");
            else
                EnviarAModalMsj(ucMsjModal, "Ingresar Bodega Entrada", errorMsj);

        }

        protected void btnBodegaEntrega_Click(object sender, EventArgs e)
        {
            int idTransformador = Convert.ToInt32(ucBusquedaTransformador.IdTransformador);
            tfr_transformador transformadorObject = _BOTransformador.ConsultarXId(idTransformador) as tfr_transformador;
            string errorMsj = string.Empty;

            _BOTransformador.EnviarBodegaEntrega(transformadorObject, out errorMsj);

            if (string.IsNullOrEmpty(errorMsj))
                EnviarAModalMsj(ucMsjModal, "Ingresar Bodega Entrega", "Se asignado el transformador exitosamente a la bodega de entrega");
            else
                EnviarAModalMsj(ucMsjModal, "Ingresar Bodega Entrega", errorMsj);
        }

        protected void btnEntregarCliente_Click(object sender, EventArgs e)
        {
            int idTransformador = Convert.ToInt32(ucBusquedaTransformador.IdTransformador);
            tfr_bodega bodegaObject = _BOTransformador.ConsultarTransformadorBodega(idTransformador);
            _BOTransformador.EliminarEnBodega(bodegaObject);

            EnviarAModalMsj(ucMsjModal, "Entregar a Cliente", "El transformador ha sido descargado, está disponible para entregar a cliente");
        }
    }
}