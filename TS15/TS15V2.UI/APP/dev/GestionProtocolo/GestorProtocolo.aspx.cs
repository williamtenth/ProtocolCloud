using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15V2.UI.APP.abstractUI;
using TS15.Common.Generated;
using TS15.Common.util;
using TS15.BL.gestion_cliente;
using TS15.BL.gestion_transformador;
using System.Data.Objects.DataClasses;

namespace TS15V2.UI.APP.dev.GestionProtocolo
{
    public partial class GestorProtocolo : UIGenericoPagina, IGestionable, ITerminable
    {

        private cli_pedido _pedido;
        private tfr_transformador _transformador;
        private GestorProceso _gestorProceso;
        private int _valorBusqueda;
        private BOPedido _BOPedidoObject;
        private BOTransformador _BOTransformadorObject;
        private BOCliente _BOClienteObject;

        public GestorProtocolo()
        {
            _gestorProceso = new GestorProceso();
            _BOPedidoObject = new BOPedido();
            _BOTransformadorObject = new BOTransformador();
            _BOClienteObject = new BOCliente();
        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarListas();
                CargarSesion();
                ActivarControles(true);
                //LimpiarVariables();
                
            }
        }

        private void LimpiarVariables()
        {
            Session.Remove(VariablesGlobales.PRUEBA_SELECCIONADA);
        }

        public void CargarListas()
        {

        }

        protected void CargarSesion()
        {
            _pedido = (cli_pedido)Session[VariablesGlobales.SESION_CLIENTE_PEDIDO];
            _transformador = (tfr_transformador)Session[VariablesGlobales.SESSION_TRANSFORMADOR];
        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Consultar(object sender, EventArgs e)
        {
            int index = Convert.ToInt32((e as GridViewCommandEventArgs).CommandArgument);

            GridViewRow row = gvPruebas.Rows[index];
            EntityObject pruebaSeleccionada = gvPruebas.DataKeys[row.RowIndex].Values[0] as EntityObject;
            string etiquetaPrueba = (gvPruebas.DataKeys[row.RowIndex].Values[1] as string);
            Session[VariablesGlobales.PRUEBA_SELECCIONADA] = pruebaSeleccionada;

            if (etiquetaPrueba.Equals(VariablesGlobales.PRUEBA_NTC1005))
                MostrarControl(0);
            if (etiquetaPrueba.Equals(VariablesGlobales.PRUEBA_NTC1031))
                MostrarControl(1);
            if (etiquetaPrueba.Equals(VariablesGlobales.PRUEBA_NTC1465))
                MostrarControl(2);
            if (etiquetaPrueba.Equals(VariablesGlobales.PRUEBA_NTC3396))
                MostrarControl(3);
            if (etiquetaPrueba.Equals(VariablesGlobales.PRUEBA_NTC375))
                MostrarControl(4);
            if (etiquetaPrueba.Equals(VariablesGlobales.PRUEBA_NTC471))
                MostrarControl(5);
            if (etiquetaPrueba.Equals(VariablesGlobales.PRUEBA_NTC837))
                MostrarControl(6);
        }

        private void MostrarControl(int valor)
        {
            Control[] listaControl = { ucProtocoloNTC1005, ucProtocoloNTC1031, ucProtocoloNTC1465, ucProtocoloNTC3396, ucProtocoloNTC375, ucProtocoloNTC471, ucProtocoloNTC837 };
            int i = 0;

            foreach (Control control in listaControl)
            {
                control.Visible = false;
                if (i == valor)
                {
                    control.Visible = true;
                    ((GenericoProtocolo)control).CargarPrueba();
                }
                i++;
            }


        }

        private void MostrarControl(Control control)
        {
            if (Session[VariablesGlobales.SESION_ID_COMPONENTE] != null)
                ((Control)Session[VariablesGlobales.SESION_ID_COMPONENTE]).Visible = false;

            control.Visible = true;
            Session[VariablesGlobales.SESION_ID_COMPONENTE] = control;
        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Terminar(object sender, EventArgs e)
        {
            // Se traer valores desde la sesion
            if (Session[VariablesGlobales.SESION_PROCESO_PRUEBA] != null)
                _gestorProceso.Proceso = (pro_proceso)Session[VariablesGlobales.SESION_PROCESO_PRUEBA];

            if (Session[VariablesGlobales.SESION_PROCESO_LISTA_PRUEBAS] != null)
                _gestorProceso.ListaElementos = Session[VariablesGlobales.SESION_PROCESO_LISTA_PRUEBAS] as pro_elementoprueba[];

            if (_gestorProceso.Proceso != null && _gestorProceso.Terminar() && _gestorProceso.ListaElementos != null)
            {
                EnviarAModalMsj(MsjConfirmacion, "Confirmación", "Se ha terminado el proceso de pruebas");
                ActivarControles(false);
                Session[VariablesGlobales.SESION_PROCESO_PRUEBA] = null;
                Session[VariablesGlobales.SESION_PROCESO_LISTA_PRUEBAS] = null;
                Session[VariablesGlobales.SESION_PRUEBA_NTC1005] = null;
                Session[VariablesGlobales.SESION_PRUEBA_NTC1031] = null;
                Session[VariablesGlobales.SESION_PRUEBA_NTC3396] = null;
                Session[VariablesGlobales.SESION_PRUEBA_NTC375] = null;
                Session[VariablesGlobales.SESION_PRUEBA_NTC471] = null;
                Session[VariablesGlobales.SESION_PRUEBA_NTC471_DETALLE] = null;
                Session[VariablesGlobales.SESION_PRUEBA_NTC837] = null;
                Session[VariablesGlobales.SESION_PRUEBA_NTC1465] = null;
                Response.Redirect("~/APP/dev/GestionProtocolo/GestorProtocolo.aspx");

            }
            else
                EnviarAModalMsj(MsjConfirmacion, "Error", "Error al terminar proceso, verifique si todos las pruebas estén cerradas con resultado (Exitosa/No Exitosa)");
        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Crear(object sender, EventArgs e)
        {
            if (Session[VariablesGlobales.SESION_CLIENTE_PEDIDO] != null)
            {
                _pedido = (cli_pedido)Session[VariablesGlobales.SESION_CLIENTE_PEDIDO];
                _gestorProceso.CrearProceso((int)_pedido.id, VariablesGlobales.TIPO_PROCESO_PROTOCOLO);
            }
        }

        /// 
        /// <param name="activar"></param>
        public void ActivarControles(bool activar)
        {
            // se muestra la botonera
            if (activar)
            {
                //pnlBotonera.Visible = true;
                btnTerminar.Visible = true;
                btnCrear.Visible = true;

                // Pedido no tiene proceso asignado
                if (_gestorProceso.Proceso != null && _gestorProceso.Proceso.id != null)
                {
                    // Existe un proceso creado previo, se puede consultar, terminar o eliminar.
                    if (_gestorProceso.Proceso.estado == VariablesGlobales.ESTADO_ACTIVO)
                    {
                        // Si el proceso tiene estado ACTIVO
                        btnTerminar.Visible = true;
                        btnCrear.Visible = false;

                        //pnlEditar.Visible = true;
                        //pnlCrear.Visible = false;
                    }
                    else
                    {
                        btnTerminar.Visible = false;
                        btnCrear.Visible = false;

                        //pnlBotonera.Visible = false;
                    }
                }
                else
                {
                    // No existe un proceso creado previo
                    btnTerminar.Visible = false;
                    btnCrear.Visible = true;

                    //pnlEditar.Visible = false;
                    //pnlCrear.Visible = true;
                }
            }
            else
            {
                // Se oculta la botonera
                btnTerminar.Visible = true;
                btnCrear.Visible = true;

                //pnlBotonera.Visible = false;
            }
        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Buscar(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                _valorBusqueda = UtilNumeros.StringToInt(txtSolicitud.Text);
                if (_gestorProceso.ConsultarProceso(_valorBusqueda))
                {
                    // Proceso a sesion
                    Session[VariablesGlobales.SESION_PROCESO_PRUEBA] = _gestorProceso.Proceso;
                    Session[VariablesGlobales.SESION_PROCESO_LISTA_PRUEBAS] = _gestorProceso.ListaElementos;
                    // Pedido a sesion                    
                    _pedido = (cli_pedido)_BOPedidoObject.ConsultarXId((int)_gestorProceso.Proceso.pedido_id);
                    Session[VariablesGlobales.SESION_CLIENTE_PEDIDO] = _pedido;
                    // Transformador a sesion
                    _transformador = _pedido.tfr_transformador;
                    Session[VariablesGlobales.SESSION_TRANSFORMADOR] = _transformador;
                    // Mostar botonera
                    ActivarControles(true);
                    CargarEntidad();
                }
                else
                {
                    EnviarAModalMsj(MsjConfirmacion, "Error", "No existe proceso de pruebas para el pedido ingresado");
                }
            }
            else
            {
                ActivarControles(false);
            }
        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Eliminar(object sender, EventArgs e)
        {

        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Modificar(object sender, EventArgs e)
        {

        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Guardar(object sender, EventArgs e)
        {

        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cancelar(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Permite validar los campos obligatorios del formulario.
        /// </summary>
        public bool ValidarCampos()
        {
            if (!_valorBusqueda.Equals(""))
            {
                return true;
            }
            else
            {
                EnviarAModalMsj(MsjConfirmacion, "Error", "Ingrese un valor para realizar la búsqueda");
                return false;
            }
        }

        protected void SeleccionarPrueba(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow row = gvPruebas.Rows[index];
            EntityObject tipoSolicitud = gvPruebas.DataKeys[row.RowIndex].Values[0] as EntityObject;
            Session[VariablesGlobales.PRUEBA_SELECCIONADA] = tipoSolicitud;
        }

        protected void gvPruebas_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            SeleccionarPrueba(sender, e);

        }

        protected void CargarEntidad()
        {
            txtFabricante.Text = (_BOClienteObject.ConsultarXId((int)_transformador.fabricante_id) as cli_cliente).nombre;
            txtNumSerie.Text = _transformador.numserie;
            txtResultado.Text = UtilParametros.ValidarResultado(_gestorProceso.Proceso.resultado);
            // Lista de pruebas
            gvPruebas.DataSource = _gestorProceso.ListaElementos;
            gvPruebas.DataBind();
        }

        protected void ActualizarEntidad()
        {

        }
    }
}