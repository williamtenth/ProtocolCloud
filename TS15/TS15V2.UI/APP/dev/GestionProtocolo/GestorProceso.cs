///////////////////////////////////////////////////////////
//  GestorProceso.cs
//  Implementation of the Class GestorProceso
//  Generated by Enterprise Architect
//  Created on:      02-may.-2015 10:16:16 a. m.
//  Original author: william_cuadros
///////////////////////////////////////////////////////////




using TS15.Common.Generated;
using System.Collections.Generic;
using TS15.Common.IService;
using TS15.BL.gestion_protocolo;
using System.Data.Objects.DataClasses;
using TS15.Common.util;
namespace TS15V2.UI.APP.dev.GestionProtocolo
{
    public class GestorProceso
    {

        private pro_proceso _proceso;
        private EntityObject[] _listaPruebas;
        private pro_elementoprueba[] _listaElementos;
        private BOProceso _BOProcesoObject;
        private BOProtocolo_NTC1005 _BOntc1005Object;
        private BOProtocolo_NTC1031 _BOntc1031Object;
        private BOProtocolo_NTC1465 _BOntc1465Object;
        private BOProtocolo_NTC3396 _BOntc3396Object;
        private BOProtocolo_NTC375 _BOntc375Object;
        private BOProtocolo_NTC471 _BOntc471Object;
        private BOProtocolo_NTC837 _BOntc837Object;

        ~GestorProceso()
        {

        }

        public GestorProceso()
        {
            _BOProcesoObject = new BOProceso();
            _BOntc1005Object = new BOProtocolo_NTC1005();
            _BOntc1031Object = new BOProtocolo_NTC1031();
            _BOntc1465Object = new BOProtocolo_NTC1465();
            _BOntc3396Object = new BOProtocolo_NTC3396();
            _BOntc375Object = new BOProtocolo_NTC375();
            _BOntc471Object = new BOProtocolo_NTC471();
            _BOntc837Object = new BOProtocolo_NTC837();
            _listaPruebas = new EntityObject[7];
            _listaElementos = new pro_elementoprueba[7];
        }

        /// 
        /// <param name="transformador"></param>
        /// <param name="pedido"></param>
        public bool CrearProceso(int pedido, byte tipoProceso)
        {
            pro_proceso nuevo = new pro_proceso();
            nuevo.pedido_id = pedido;
            nuevo.tipprocesop = tipoProceso;
            if (_BOProcesoObject.Crear(nuevo))
            {
                ConsultarProceso(pedido);
                return true;
            }
            return false;
        }

        /// 
        /// <param name="pedido"></param>
        public bool ConsultarProceso(int pedido)
        {
            _proceso = _BOProcesoObject.ObternerProcesoXPedido(pedido);

            if (_proceso != null)
            {
                GenerarElementos();
                return true;
            }

            return false;
        }

        private void GenerarElementos()
        {
            // ntc 1005
            _listaElementos[0] = _BOntc1005Object.ObternerPruebasXProceso(_proceso.id);
            // ntc 1031
            _listaElementos[1] = _BOntc1031Object.ObternerPruebasXProceso(_proceso.id);
            // ntc 1465
            _listaElementos[2] = _BOntc1465Object.ObternerPruebasXProceso(_proceso.id);
            // ntc 3396
            _listaElementos[3] = _BOntc3396Object.ObternerPruebasXProceso(_proceso.id);
            // ntc 375
            _listaElementos[4] = _BOntc375Object.ObternerPruebasXProceso(_proceso.id);
            // ntc 471
            _listaElementos[5] = _BOntc471Object.ObternerPruebasXProceso(_proceso.id);
            // ntc 837
            _listaElementos[6] = _BOntc837Object.ObternerPruebasXProceso(_proceso.id);

        }

        private bool ValidarProceso()
        {
            int resultado = 0;
            int estado = 0;
            
            foreach (pro_elementoprueba elemento in _listaElementos)
            {
                if (elemento.Resultado.Equals(VariablesGlobales.RESULTADO_PRUEBAS_EXITOSA_LABEL))
                    resultado++;
                if (elemento.Estado.Equals(VariablesGlobales.ESTADO_TERMINADO_LABEL)) 
                    estado++;
            }

            if (estado == _listaElementos.Length)
            {
                // Si el valor de resultado es igual al tama�o del arreglo, el resultado del proceso es exitoso.
                _proceso.resultado = resultado == _listaElementos.Length ? VariablesGlobales.RESULTADO_PRUEBAS_EXITOSA : VariablesGlobales.RESULTADO_PRUEBAS_NO_EXITOSA;

                //if (_proceso.resultado.Equals(VariablesGlobales.RESULTADO_PRUEBAS_NO_EXITOSA))
                //{
                //    _proceso.cli_pedido.estado = VariablesGlobales.ESTADO_TERMINADO;
                //    _BOProcesoObject.Modificar(_proceso.cli_pedido);
                //    cli_pedido pedido = new cli_pedido();
                //    pedido.tipsolicitud = VariablesGlobales.CLI_TIPO_SOLICITUD_REPARACION;
                //    pedido.cliente_id = _proceso.cli_pedido.cliente_id;
                //    pedido.fechasolicitud = new System.DateTime();
                //    pedido.transformador_id = 

                //}
                
                return true;
            }
            else
                return false;
        }

        public bool Terminar()
        {
            if(ValidarProceso())
                return _BOProcesoObject.Terminar(_proceso);
            return false;
        }

        // Set Get
        public pro_proceso Proceso
        {
            get { return _proceso; }
            set { _proceso = value; }
        }

        public pro_elementoprueba[] ListaElementos
        {
            get { return _listaElementos; }
            set { _listaElementos = value; }
        }

    }//end GestorProceso

}//end namespace gestion_protocolo