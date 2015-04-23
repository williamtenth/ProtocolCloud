﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.Generated;
using TS15.DAL;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.Common.RawObjects;
using TS15.DAL.gestion_cliente;
using TS15.DAL.abstractDAL;
using TS15.BL.abstractBL;

namespace TS15.BL.gestion_cliente
{
    public class BOCliente : BOGenerico, IGestionable
    {
        public BOCliente()
        {
            GenericoDAO = new DAOCliente();
        }

        public List<EntityObject> Consultar()
        {
            List<cli_cliente> lstEntityCliente = ((DAOCliente)GenericoDAO).ConsultarClientes();
            List<EntityObject> lstEntityObjects = lstEntityCliente.Cast<EntityObject>().ToList();
            return lstEntityObjects;
        }

        public void Actualizar(EntityObject entidad)
        {
            cli_cliente entityCliente = entidad as cli_cliente;
            ((DAOCliente)GenericoDAO).Actualizar(entityCliente);
        }

        public void Eliminar(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
        }

        public void Crear(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este método permite realizar la búsqueda de un cliente por Id.
        /// </summary>
        /// <param name="cliente_id">Identificador del cliente</param>
        /// <param name="contexto">contexto</param>
        /// <param name="error">error</param>
        /// <returns>El objeto Cliente, si no hay resultado se retorna un objeto vacío</returns>
        public EntityObject ConsultarXId(int idCliente)
        {
            return ((DAOCliente)GenericoDAO).ConsultarXId(idCliente);
        }

        public cli_cliente BuscarCliente(string pTipoDocumento, string pNumDocumento)
        {
            return ((DAOCliente)GenericoDAO).BuscarCliente(pTipoDocumento, pNumDocumento);
        }

        public List<cli_cliente> ConsultarFabricantes()
        {
            return ((DAOCliente)GenericoDAO).ConsultarFabricantes();
        }

        public vw_cli_usuario ConsultarClienteUser(Guid userId)
        {
            return ((DAOCliente)GenericoDAO).ConsultarClienteUser(userId);
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
            throw new NotImplementedException();
        }

        public object ConsultarPedidosCliente(int intIdCliente)
        {
            return ((DAOCliente)GenericoDAO).ConsultarPedidosCliente(intIdCliente);
        }
    }
}