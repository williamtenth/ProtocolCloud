using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.BL.abstractBL;
using TS15.Common.IService;
using TS15.DAL.gestion_transformador;
using System.Data.Objects.DataClasses;
using TS15.DAL.gestion_protocolo;

namespace TS15.BL.gestion_protocolo
{
    public class BOProceso : BOGenerico, IGestionable
    {

        public BOProceso()
        {
            GenericoDAO = new DAOProceso();
        }

        public EntityObject ConsultarXId(int id)
        {
            throw new NotImplementedException();
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
            return ((DAOProceso)GenericoDAO).Crear(entidad);
        }

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }
    }
}
