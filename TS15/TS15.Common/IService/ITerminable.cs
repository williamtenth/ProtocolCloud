using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.Generated;

namespace TS15.Common.IService
{
    public interface ITerminable
    {
        Boolean Terminar(dbTS15Entities entidad);
    }
}
