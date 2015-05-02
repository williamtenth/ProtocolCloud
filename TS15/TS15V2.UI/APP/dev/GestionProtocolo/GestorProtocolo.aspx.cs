using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15V2.UI.APP.abstractUI;
using TS15.Common.Generated;
using TS15.Common.util;

namespace TS15V2.UI.APP.dev.GestionProtocolo
{
    public partial class GestorProtocolo : UIGenericoPagina, IGestionable, ITerminable
    {

        private cli_pedido _pedido;
        private GestorProceso _gestorProceso;
        private int _valorBusqueda;

        public GestorProtocolo()
        {
            _gestorProceso = new GestorProceso();
        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Page_Load(object sender, EventArgs e)
        {
            CargarListas();
        }

        public void CargarListas()
        {

        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Consultar(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                _gestorProceso.ConsultarProceso(_valorBusqueda);
                // Mostar botonera
                ActivarControles(true);

            }
            else
            {
                ActivarControles(false);
            }
        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Terminar(object sender, EventArgs e)
        {
            if (Session[VariablesGlobales.SESION_PROCESO_PRUEBA] != null)
                _gestorProceso.Proceso = (pro_proceso)Session[VariablesGlobales.SESION_PROCESO_PRUEBA];
            _
            
        }

        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Crear(object sender, EventArgs e)
        {

        }

        /// 
        /// <param name="activar"></param>
        public void ActivarControles(bool activar)
        {
            // se muestra la botonera
            if (activar != true)
            {
                pnlBotonera.Visible = true;
                // Pedido no tiene proceso asignado
                if (_gestorProceso.Proceso != null)
                // Existe un proceso creado previo, se puede consultar, terminar o eliminar.
                {
                    pnlEditar.Visible = true;
                }
                else
                // No existe un proceso creado previo
                {
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
            if (_valorBusqueda != null && !_valorBusqueda.Equals(""))
            {
                return true;
            }
            else
            {
                EnviarAModalMsj(MsjConfirmacion, "Error", "Ingrese un valor para realizar la búsqueda");
                return false;
            }
        }
    }
}