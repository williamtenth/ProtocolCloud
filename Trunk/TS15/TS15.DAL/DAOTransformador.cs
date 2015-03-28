using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.IService;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using System.Data.Objects.DataClasses;

namespace TS15.DAL
{
    public class DAOTransformador : IGestionable
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
            throw new NotImplementedException();
        }

        public EntityObject ConsultarXId(int id, dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
        }
    }
}
