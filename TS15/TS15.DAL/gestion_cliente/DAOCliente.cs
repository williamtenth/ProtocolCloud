using System;
using System.Collections.Generic;
using System.Linq;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.DAL.abstractDAL;
using System.Data.Objects.DataClasses;

namespace TS15.DAL.gestion_cliente
{
    public class DAOCliente : DAOGenerico
    {
        public List<cli_cliente> ConsultarClientes()
        {
            try
            {
                return SingletonDatos.Contexto.cli_cliente.ToList();
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public EntityObject ConsultarXId(int idCliente)
        {
            return SingletonDatos.Contexto.cli_cliente.Where(p => p.id == idCliente).SingleOrDefault();
        }

        public void Actualizar(cli_cliente entityCliente)
        {
            try
            {
                SingletonDatos.Contexto.SaveChanges();
            }

            catch (Exception ex)
            {

            }
        }

        public cli_cliente BuscarCliente(string pTipoDocumento, string pNumDocumento)
        {
            try
            {
                if (SingletonDatos.Contexto.cli_cliente.Where(p => p.numdocumento == pNumDocumento).ToList().Count > 0)
                    return SingletonDatos.Contexto.cli_cliente.Where(p => p.numdocumento == pNumDocumento).SingleOrDefault();
                else
                    return null;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<cli_cliente> ConsultarFabricantes()
        {
            try
            {
                return SingletonDatos.Contexto.cli_cliente.Where(p => p.tiptercero == 2 || p.tiptercero == 3).ToList();
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public vw_cli_usuario ConsultarClienteUser(Guid userId)
        {
            return SingletonDatos.Contexto.vw_cli_usuario.Where(p => p.UserId == userId).SingleOrDefault();
        }

        public object ConsultarPedidosCliente(int intIdCliente)
        {
            //return SingletonDatos.Contexto.
            return null;
        }
    }
}
