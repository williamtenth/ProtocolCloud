using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.DAL.abstractDAL;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;

namespace TS15.DAL.gestion_protocolo
{
    public class DAOProceso : DAOGenerico
    {

        public bool Crear(EntityObject entidad)
        {
            pro_proceso procesoObject = entidad as pro_proceso;
            SingletonDatos.Contexto.AddTopro_proceso(procesoObject);

            return true;
        }
    }
}
