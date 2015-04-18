using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;
using TS15.Common.RawObjects;

namespace TS15.Common.IService
{
    public interface IGestionable
    {
        //void Actualizar(EntityObject entidad, dbTS15Entities contexto, RawError error);
        //void Eliminar(EntityObject entidad, dbTS15Entities contexto, RawError error);
        //void Crear(EntityObject entidad, dbTS15Entities contexto, RawError error);
        EntityObject ConsultarXId(int id);
        Boolean Modificar(EntityObject entidad);
        Boolean Eliminar(EntityObject entidad);
        Boolean Crear(EntityObject entidad);
        List<EntityObject> Consultar();
    }
}
