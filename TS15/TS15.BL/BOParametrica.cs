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
    public class BOParametrica : IGestionable
    {
        public static List<gen_parametrica> ConsultarParametros(string tipo, dbTS15Entities contexto, RawError error)
        {
            return DAOParametrica.ConsultarParametros(tipo, contexto, error);
        }

        public static List<gen_parametrica> ConsultarParametrosSuministro(string tipo, dbTS15Entities contexto, RawError error)
        {
            return DAOParametrica.ConsultarParametrosSuministro(tipo, contexto, error);
        }

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

        public static List<gen_parametrica> ConsultarTipoSolictudSS(string tipo, dbTS15Entities contexto, RawError error)
        {
            return DAOParametrica.ConsultarTipoSolictudSS(tipo, contexto, error);
        }
    }
}
