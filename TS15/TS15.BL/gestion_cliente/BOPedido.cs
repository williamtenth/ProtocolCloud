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
using TS15.Common;
using TS15.DAL.gestion_transformador;

namespace TS15.BL.gestion_cliente
{
    public class BOPedido : BOGenerico, IGestionable
    {
        private BOOrdenTrabajo _BOOrdenTrabajo;
        private BOProceso _BOProceso;
        private DAOTransformador _DAOTransformador;
        private BOCliente _BOCliente;

        public BOPedido()
        {
            GenericoDAO = new DAOPedido();
            _BOOrdenTrabajo = new BOOrdenTrabajo();
            _BOProceso = new BOProceso();
            _DAOTransformador = new DAOTransformador();
            _BOCliente = new BOCliente();
        }

        public bool CrearPedidoSuministro(cli_pedido pedidoObject)
        {
            bool bitProceso = true;

            //CREAR EL TRANSFORMADOR
            tfr_transformador transformadorObject = new tfr_transformador();
            transformadorObject.numserie = DateTime.Now.Ticks.ToString();
            transformadorObject.fabricante_id = 7; //ID DE LA EMPRESA FABRICANTE
            transformadorObject.altura = "1000";
            transformadorObject.tfrestado = 1; //GEN PARAMETRICA TFRESTADO = 1
            transformadorObject.tfrtenserieAT = 1;
            transformadorObject.tfrtenserieBT = 2;
            transformadorObject.tfrcapacidad = pedidoObject.capacidad;
            transformadorObject.trffase = 3;
            transformadorObject.fecfabricacion = DateTime.Now;
            transformadorObject.tempdevanado = "65";
            transformadorObject.trfaislamiento = 1;
            transformadorObject.frecuencia = 60;
            transformadorObject.volentrada = pedidoObject.volentrada;
            transformadorObject.volsalida = pedidoObject.volsalida;
            transformadorObject.derivaciones = 5;
            transformadorObject.trfgrpconex = 1;
            _DAOTransformador.Crear(transformadorObject);

            //ASIGNA EL TRANSFORMADOR AL CLIENTE
            tfr_transf_has_cliente transfClienteObject = new tfr_transf_has_cliente();
            transfClienteObject.cliente_id = Convert.ToInt32(pedidoObject.cliente_id);
            transfClienteObject.transformador_id = transformadorObject.id;
            transfClienteObject.fechaasignacion = DateTime.Now;
            _BOCliente.AsignarTransformador(transfClienteObject);

            //CREA EL PEDIDO
            pedidoObject.transformador_id = transformadorObject.id;
            pedidoObject.consecutivo = ((DAOPedido)GenericoDAO).ObtenerConsecutivo();
            Crear(pedidoObject);

            //CREA LA ORDEN DE TRABAJO
            tfr_ordentrabajo ordenTrabajoObject = new tfr_ordentrabajo();
            ordenTrabajoObject.pedido_id = pedidoObject.id;
            ordenTrabajoObject.consecutivo = _BOOrdenTrabajo.ObtenerConsecutivo();
            ordenTrabajoObject.fechacreacion = DateTime.Now;
            ordenTrabajoObject.estado = 1; //Estado Activo
            _BOOrdenTrabajo.Crear(ordenTrabajoObject);

            //INGRESA AL PROCESO DE PRUEBAS
            pro_proceso procesoObject = new pro_proceso();
            procesoObject.pedido_id = pedidoObject.id;
            procesoObject.tipprocesop = 1; //Proceso de pruebas preliminares.
            procesoObject.fecha = DateTime.Now;
            procesoObject.estado = 1; //Estado Activo
            _BOProceso.Crear(procesoObject);

            //INGRESA EL TRANSFORMADOR A LA BODEGA
            tfr_bodega bodegaObject = new tfr_bodega();
            bodegaObject.transformador_id = transformadorObject.id;
            bodegaObject.tipbodega = "EN";
            bodegaObject.fecentrada = DateTime.Now;
            bodegaObject.pedido_id = pedidoObject.id;
            _DAOTransformador.IngresarEnBodega(bodegaObject);

            return bitProceso;
        }

        private int ObtenerConsecutivo()
        {
            int maximo = 1;

            if (Consultar().Count > 0)
                maximo = ((DAOPedido)GenericoDAO).ObtenerConsecutivo();

            return maximo;
        }

        public EntityObject ConsultarXId(int idSolicitud)
        {
            return ((DAOPedido)GenericoDAO).ConsultarXId(idSolicitud);
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
            _BOProceso.Crear(procesoObject);

            //INGRESA EL TRANSFORMADOR A LA BODEGA CON TIPO 'EN'
            tfr_bodega bodegaObject = new tfr_bodega();
            bodegaObject.transformador_id = Convert.ToInt32(pedidoObject.transformador_id);
            bodegaObject.tipbodega = "EN"; //TIPO BODEGA DE ENTRADA
            bodegaObject.fecentrada = DateTime.Now;
            _DAOTransformador.IngresarEnBodega(bodegaObject);

            //ASIGNA EL TRANSFORMADOR AL CLIENTE
            tfr_transf_has_cliente transfClienteObject = new tfr_transf_has_cliente();
            transfClienteObject.cliente_id = Convert.ToInt32(pedidoObject.cliente_id);
            transfClienteObject.transformador_id = bodegaObject.transformador_id;
            transfClienteObject.fechaasignacion = DateTime.Now;

            _BOCliente.AsignarTransformador(transfClienteObject);
        }

        public void Actualizar(cli_pedido pedidoObject)
        {
            ((DAOPedido)GenericoDAO).Actualizar(pedidoObject);
        }

        internal List<cli_pedido> ConsultarSolitcitudes(int pIdTransformador, int tipoSolicitud)
        {
            return ((DAOPedido)GenericoDAO).ConsultarSolitcitudes(pIdTransformador, tipoSolicitud);
        }

        public cli_pedido ConsultarXIdTransformador(int idTransformador)
        {
            return ((DAOPedido)GenericoDAO).ConsultarXIdTransformador(idTransformador);
        }
    }
}
