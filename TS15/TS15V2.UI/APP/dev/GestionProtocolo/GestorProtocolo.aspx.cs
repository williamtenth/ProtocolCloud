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
            CargarListas();
            ActivarControles(true);
        }

        public void CargarListas()
        {

        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Consultar(object sender, EventArgs e)
        {

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
                EnviarAModalMsj(MsjConfirmacion, "Confirmación", "Se ha terminado el proceso de pruebas");
            else
                EnviarAModalMsj(MsjConfirmacion, "Error", "Error al terminar proceso, verifique si todos las pruebas tiene resultado (Exitosa/No Exitosa)");
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
                pnlBotonera.Visible = true;
                // Pedido no tiene proceso asignado
                if (_gestorProceso.Proceso != null && _gestorProceso.Proceso.id != null)
                {
                    // Existe un proceso creado previo, se puede consultar, terminar o eliminar.
                    if (_gestorProceso.Proceso.estado == VariablesGlobales.ESTADO_ACTIVO)
                    {
                        // Si el proceso tiene estado ACTIVO
                        pnlEditar.Visible = true;
                        pnlCrear.Visible = false;
                    }
                    else
                        pnlBotonera.Visible = false;
                }
                else
                {
                    // No existe un proceso creado previo
                    pnlEditar.Visible = false;
                    pnlCrear.Visible = true;
                }
            }
            else
                // Se oculta la botonera
                pnlBotonera.Visible = false;
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

        protected void gvPruebas_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvPruebas_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = gvPruebas.SelectedRow;

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