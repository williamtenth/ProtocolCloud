using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.DAL;

namespace TS15.BL
{
    public class BOTransformador : IGestionable
    {

        public List<EntityObject> Consultar(dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
