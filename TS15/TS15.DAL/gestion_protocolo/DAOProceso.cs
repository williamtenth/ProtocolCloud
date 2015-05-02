using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.DAL.abstractDAL;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;
using TS15.Common.IService;

namespace TS15.DAL.gestion_protocolo
{
    public class DAOProceso : DAOGenerico, IGestionable
    {

        public bool Crear(EntityObject entidad)
        {
            pro_proceso procesoObject = entidad as pro_proceso;
            SingletonDatos.Contexto.pro_proceso.AddObject(procesoObject);
            SingletonDatos.Contexto.SaveChanges();
            return true;
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

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        public pro_proceso ObternerProcesoXPedido(int pedido)
        {
            return null;
        }

        
    }
}
