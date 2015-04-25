using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.DAL.abstractDAL;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;

namespace TS15.DAL.gestion_transformador
{
    public class DAOOrdenTrabajo : DAOGenerico
    {

        public bool Crear(EntityObject entidad)
        {
            tfr_ordentrabajo ordenTrabajoObject = entidad as tfr_ordentrabajo;
            SingletonDatos.Contexto.AddTotfr_ordentrabajo(ordenTrabajoObject);
            SingletonDatos.Contexto.SaveChanges();

            return true;
        }

        public int ObtenerConsecutivo()
        {
            var a = (from p in SingletonDatos.Contexto.tfr_ordentrabajo
                     select p.consecutivo).Max();

            return Convert.ToInt32(a) + 1;
        }

        public List<EntityObject> Consultar()
        {
            return SingletonDatos.Contexto.tfr_ordentrabajo.ToList().Cast<EntityObject>().ToList();
        }
    }
}
