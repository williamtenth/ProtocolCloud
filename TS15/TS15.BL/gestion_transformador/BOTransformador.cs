using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.DAL;
using TS15.BL.abstractBL;
using TS15.DAL.gestion_transformador;
using TS15.BL.gestion_cliente;
using TS15.Common;
using TS15.DAL.gestion_cliente;

namespace TS15.BL.gestion_transformador
{
    public class BOTransformador : BOGenerico, IGestionable
    {
        private DAOPedido _DAOPedido;

        public BOTransformador()
        {
            GenericoDAO = new DAOTransformador();
            _DAOPedido = new DAOPedido();
        }

        public List<EntityObject> Consultar()
        {
            DAOTransformador transformadorDAO = new DAOTransformador();
            return transformadorDAO.Consultar();
        }

        public void Actualizar(EntityObject entidad)
        {
            ((DAOTransformador)GenericoDAO).Actualizar(entidad);
        }

        public void Eliminar(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
        }

        public void Crear(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            DAOTransformador transformadorDAO = new DAOTransformador();
            transformadorDAO.Crear(entidad, contexto, error);
        }

        public EntityObject ConsultarXId(int id)
        {
            DAOTransformador transformadorDAO = new DAOTransformador();
            return transformadorDAO.ConsultarXId(id);
        }

        /// <summary>
        /// Este método permite obtener el cliente que tiene asignado el transformador seleccionado.
        /// *Consulta en la vista vw_transformador_cliente
        /// </summary>
        /// <param name="trafo_id">Identificador del transformador</param>
        /// <param name="contexto">Contexto</param>
        /// <param name="error">Error</param>
        /// <returns>Objeto de tipo cliente, si no tiene asignado un cliente retorna un objeto nulo</returns>
        public EntityObject ConsultarClienteXTrafoId(int trafo_id, dbTS15Entities contexto, RawError error)
        {
            DAOTransformador transformadorDAO = new DAOTransformador();
            return transformadorDAO.ConsultarClienteXTrafoId(trafo_id, contexto, error);
        }

        /// <summary>
        /// Este método elimina de la tabla "tfr_transf_has_cliente" la tupla que contenga el transformador seleccionado.
        /// </summary>
        /// <param name="trafo_id">Identificador del transformador</param>
        /// <param name="contexto">contexto</param>
        /// <param name="error">error</param>
        /// <returns>
        /// <b>- 0 se elimina exitosamente la relación transformador - cliente<b>
        /// <b>- 1 no exite la relación transformador - cliente<b>
        /// </returns>
        public int RetirarTranfoDeCliente(int trafo_id, dbTS15Entities contexto, RawError error)
        {
            DAOTransformador transformadorDAO = new DAOTransformador();
            return transformadorDAO.RetirarTranfoDeCliente(trafo_id, contexto, error);
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
            return ((DAOTransformador)GenericoDAO).Crear(entidad);
        }

        public List<tfr_transformador> ConsultarTransformadoresFabricante()
        {
            return ((DAOTransformador)GenericoDAO).ConsultarTransformadoresFabricante();
        }

        public bool EsAsignadoCliente(string pIdTransformador)
        {
            int idTransformador = Convert.ToInt32(pIdTransformador);
            return ((DAOTransformador)GenericoDAO).ValidarAsignacionCliente(idTransformador);
        }

        public bool EsAsignadoSolicitud(string pIdTransformador)
        {
            int idTransformador = Convert.ToInt32(pIdTransformador);
            return ((DAOTransformador)GenericoDAO).ValidarAsignacionSolicitud(idTransformador);
        }


        /// <summary>
        /// Ingresa el transformador en la bodega 
        /// </summary>
        /// <param name="bodegaObject"></param>
        internal void IngresarEnBodega(tfr_bodega bodegaObject)
        {
            ((DAOTransformador)GenericoDAO).IngresarEnBodega(bodegaObject);
        }

        public vw_transformador_fabricante ConsultarTransformadorFabricante(int idTransformador)
        {
            return ((DAOTransformador)GenericoDAO).ConsultarTransformadorFabricante(idTransformador);
        }

        public tfr_bodega ConsultarTransformadorBodega(int pIdTransformador)
        {
            return ((DAOTransformador)GenericoDAO).ConsultarTransformadorBodega(pIdTransformador);
        }

        public void EnviarBodegaEntrada(tfr_bodega bodegaObject, out string mensaje)
        {
            //valida si el transformador seleccionado no posee una solicitud tipo servicio
            mensaje = string.Empty;
            int tipoSolicitud = Convert.ToInt32(Enums.TipoSolicitud.Servicio);
            int contSolServicio = _DAOPedido.ConsultarSolitcitudes(bodegaObject.transformador_id, tipoSolicitud).Count;

            if (contSolServicio > 0)
                mensaje = "No se puede enviar a la bodega de entrada, por favor crear solicitud de servicio";

            else
                IngresarEnBodega(bodegaObject);
        }

        public void EnviarBodegaEntrega(tfr_transformador transformadorObject, out string errorMsj)
        {
            //valida si el transformador seleccionado no ha sido aprobado
            errorMsj = string.Empty;

            bool bitEstado = Convert.ToBoolean(_DAOPedido.ConsultarXIdTransformador(transformadorObject.id).aprobado);

            if (bitEstado)
                errorMsj = "No se puede enviar a la bodega de entrega, el transformador no ha sido aprobado";
            else
            {
                tfr_bodega bodegaObject = ConsultarTransformadorBodega(transformadorObject.id);
                bodegaObject.tipbodega = "";
                AsignarBodegaEntrega(bodegaObject);
            }
        }

        private void AsignarBodegaEntrega(tfr_bodega bodegaObject)
        {
            ((DAOTransformador)GenericoDAO).AsignarBodegaEntrega(bodegaObject);
        }

        public void EliminarEnBodega(tfr_bodega bodegaObject)
        {
            ((DAOTransformador)GenericoDAO).EliminarEnBodega(bodegaObject);
        }

        public List<vw_solicitudes_transformador> ConsultarSolicitudes(int pIdTransformador)
        {
            return ((DAOTransformador)GenericoDAO).ConsultarSolicitudes(pIdTransformador);
        }
    }
}
