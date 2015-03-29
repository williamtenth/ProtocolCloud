using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.Generated;
using TS15.DAL;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.Common.RawObjects;

namespace TS15.BL
{
    public class BOCliente : IGestionable
    {
        public List<EntityObject> Consultar(dbTS15Entities contexto, RawError error)
        {
            List<cli_cliente> lstEntityCliente = DAOCliente.ConsultarClientes(contexto, error);
            List<EntityObject> lstEntityObjects = lstEntityCliente.Cast<EntityObject>().ToList();
            return lstEntityObjects;
        }

        public void Actualizar(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            cli_cliente entityCliente = entidad as cli_cliente;
            DAOCliente.Actualizar(entityCliente, contexto, error);
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
            cli_cliente entityCliente = DAOCliente.ConsultarXId(id, contexto, error);
            return entityCliente as EntityObject;
        }

        public cli_cliente BuscarCliente(string pTipoDocumento, string pNumDocumento, dbTS15Entities contexto, RawError error)
        {
            return DAOCliente.BuscarCliente(pTipoDocumento, pNumDocumento, contexto, error);
        }

        public static List<cli_cliente> ConsultarFabricantes(dbTS15Entities contexto, RawError error)
        {
            return DAOCliente.ConsultarFabricantes(contexto, error);
        }
    }
}