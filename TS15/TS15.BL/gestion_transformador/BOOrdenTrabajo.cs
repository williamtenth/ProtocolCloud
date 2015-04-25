using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.BL.abstractBL;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.DAL.gestion_transformador;

namespace TS15.BL.gestion_transformador
{
    public class BOOrdenTrabajo : BOGenerico, IGestionable
    {
        public BOOrdenTrabajo()
        {
            GenericoDAO = new DAOOrdenTrabajo();
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
            return ((DAOOrdenTrabajo)GenericoDAO).Crear(entidad);
        }

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        internal int ObtenerConsecutivo()
        {
            int maximo = 1;

            if (Consultar().Count > 0)
                maximo = ((DAOOrdenTrabajo)GenericoDAO).ObtenerConsecutivo();

            return maximo;
        }
    }
}
