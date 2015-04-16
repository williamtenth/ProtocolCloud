using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.Generated;
using System.Data.Objects.DataClasses;

namespace TS15.Common.IService
{
    public interface IProbable
    {
        Boolean Terminar(EntityObject entidad);
        EntityObject obtenerUltimaPrueba(tfr_transformador transformador);

    }
}
