using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.DAL;

namespace TS15.BL.Gestion_Transformador
{
    public class BOTransformador : IGestionable
    {

        public List<EntityObject> Consultar(dbTS15Entities contexto, RawError error)
        {
            DAOTransformador transformadorDAO = new DAOTransformador();
            return transformadorDAO.Consultar(contexto, error);
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

        public EntityObject ConsultarXId(int id, dbTS15Entities contexto, RawError error)
        {
            DAOTransformador transformadorDAO = new DAOTransformador();
            return transformadorDAO.ConsultarXId(id, contexto, error);
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
    }
}
