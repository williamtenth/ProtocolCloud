using System;
using System.Collections.Generic;
using System.Linq;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.DAL.abstractDAL;

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

        public static cli_cliente ConsultarXId(int id, dbTS15Entities contexto, RawError error)
        {
            dbTS15Entities _contexto = new dbTS15Entities();
            RawError _error = new RawError();
            try
            {
                return contexto.cli_cliente.Where(p => p.id == id).SingleOrDefault();
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public static void Actualizar(cli_cliente entityCliente, dbTS15Entities contexto, RawError error)
        {
            try
            {
                contexto.SaveChanges();
            }

            catch (Exception ex)
            {

            }
        }

        public static cli_cliente BuscarCliente(string pTipoDocumento, string pNumDocumento, dbTS15Entities contexto, RawError error)
        {
            try
            {
                if (contexto.cli_cliente.Where(p => p.numdocumento == pNumDocumento).ToList().Count > 0)
                    return contexto.cli_cliente.Where(p => p.numdocumento == pNumDocumento).SingleOrDefault();
                else
                    return null;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<cli_cliente> ConsultarFabricantes(dbTS15Entities contexto, RawError error)
        {
            try
            {
                return contexto.cli_cliente.Where(p => p.tiptercero == 2 || p.tiptercero == 3).ToList();
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public VW_CLI_USUARIO ConsultarClienteUser(Guid userId)
        {
            return SingletonDatos.Contexto.VW_CLI_USUARIO.Where(p => p.UserId == userId).SingleOrDefault();
        }
    }
}
