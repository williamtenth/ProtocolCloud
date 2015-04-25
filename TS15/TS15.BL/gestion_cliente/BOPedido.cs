using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.BL.abstractBL;
using TS15.Common.IService;
using TS15.DAL.gestion_cliente;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;
using TS15.BL.gestion_transformador;
using TS15.BL.gestion_protocolo;

namespace TS15.BL.gestion_cliente
{
    public class BOPedido : BOGenerico, IGestionable
    {
        private BOOrdenTrabajo _ordenTrabajoBO;
        private BOProceso _procesoBO;
        private BOTransformador _transformadorBO;

        public BOPedido()
        {
            GenericoDAO = new DAOPedido();
            _ordenTrabajoBO = new BOOrdenTrabajo();
            _procesoBO = new BOProceso();
            _transformadorBO = new BOTransformador();
        }

        public bool CrearPedidoSuministro(cli_pedido pedidoObject)
        {
            bool bitProceso = true;

            //CREA EL PEDIDO
            pedidoObject.consecutivo = ObtenerConsecutivo();
            Crear(pedidoObject);

            for (int i = 0; i < pedidoObject.cantidad; i++)
            {
                //CREA LA ORDEN DE TRABAJO
                tfr_ordentrabajo ordenTrabajoObject = new tfr_ordentrabajo();
                ordenTrabajoObject.pedido_id = pedidoObject.id;
                ordenTrabajoObject.consecutivo = _ordenTrabajoBO.ObtenerConsecutivo();
                ordenTrabajoObject.fechacreacion = DateTime.Now;
                ordenTrabajoObject.estado = 1; //Estado Activo
                _ordenTrabajoBO.Crear(ordenTrabajoObject);

                //INGRESA AL PROCESO DE PRUEBAS
                pro_proceso procesoObject = new pro_proceso();
                procesoObject.pedido_id = pedidoObject.id;
                procesoObject.tipprocesop = 1; //Proceso de pruebas preliminares.
                procesoObject.fecha = DateTime.Now;
                procesoObject.estado = 1; //Estado Activo
                _procesoBO.Crear(procesoObject);
            }

            return bitProceso;
        }

        private int ObtenerConsecutivo()
        {
            int maximo = 1;

            if (Consultar().Count > 0)
                maximo = ((DAOPedido)GenericoDAO).ObtenerConsecutivo();

            return maximo;
        }

        public EntityObject ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public bool Crear(EntityObject entidad)
        {
            return ((DAOPedido)GenericoDAO).Crear(entidad);
        }

        public List<EntityObject> Consultar()
        {
            return ((DAOPedido)GenericoDAO).Consultar().Cast<EntityObject>().ToList();
        }

        public void CrearProcesoPruebasPreeliminares(cli_pedido pedidoObject)
        {
            //CREA EL PEDIDO
            pedidoObject.consecutivo = ObtenerConsecutivo();
            Crear(pedidoObject);

            //INGRESA AL PROCESO DE PRUEBAS
            pro_proceso procesoObject = new pro_proceso();
            procesoObject.pedido_id = pedidoObject.id;
            procesoObject.tipprocesop = 1; //Proceso de pruebas preliminares.
            procesoObject.fecha = DateTime.Now;
            procesoObject.estado = 1; //Estado Activo
            _procesoBO.Crear(procesoObject);
        }
    }
}
