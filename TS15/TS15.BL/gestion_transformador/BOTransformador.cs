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

namespace TS15.BL.gestion_transformador
{
    public class BOTransformador : BOGenerico, IGestionable
    {
        public BOTransformador()
        {
            GenericoDAO = new DAOTransformador();
        }

        public List<EntityObject> Consultar()
        {
            DAOTransformador transformadorDAO = new DAOTransformador();
            return transformadorDAO.Consultar();
        }

        public void Actualizar(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
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

        public List<vw_transformador_fabricante> ConsultarTransformadoresCliente(int idCliente)
        {
            return ((DAOTransformador)GenericoDAO).ConsultarTransformadoresCliente(idCliente);
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
            throw new NotImplementedException();
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
    }
}
