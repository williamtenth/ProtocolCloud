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
        public void GenerarProceso(tfr_transformador transformador, cli_pedido pedido)
        {

        }

        /// 
        /// <param name="pedido"></param>
        public void ConsultarProceso(int pedido)
        {
            _proceso = _BOProcesoObject.ObternerProcesoXPedido(pedido);

            if (_proceso != null)
            {
                GenerarElementos();
            }
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

        private void GenerarPruebas()
        {

        }

        public void Terminar()
        {
            _BOProcesoObject.Modificar(_proceso);
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