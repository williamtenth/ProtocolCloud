using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.IService;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using System.Data.Objects.DataClasses;
using TS15.DAL.gestion_cliente;
using TS15.DAL.abstractDAL;

namespace TS15.DAL.gestion_transformador
{
    public class DAOTransformador : DAOGenerico, IGestionable
    {
        private DAOCliente DAOObjectCliente;

        public DAOTransformador()
        {
            DAOObjectCliente = new DAOCliente();
        }

        public List<EntityObject> Consultar()
        {
            List<EntityObject> lstTransformadores = SingletonDatos.Contexto.tfr_transformador.OrderByDescending(p => p.id)
                .ToList().Cast<EntityObject>().ToList();
            return lstTransformadores;
        }

        public void Actualizar(EntityObject entidad)
        {
            SingletonDatos.Contexto.SaveChanges();
        }

        public void Eliminar(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
        }

        public void Crear(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            tfr_transformador transformadorEntity = entidad as tfr_transformador;
            contexto.tfr_transformador.AddObject(transformadorEntity);
            contexto.SaveChanges();
        }

        public EntityObject ConsultarXId(int id)
        {
            return SingletonDatos.Contexto.tfr_transformador.Where(p => p.id == id).SingleOrDefault();
        }

        public EntityObject ConsultarClienteXTrafoId(int trafo_id, dbTS15Entities contexto, RawError error)
        {
            vw_transformador_cliente vw = contexto.vw_transformador_cliente.Where(p => p.transformador_id == trafo_id).SingleOrDefault();
            if (vw != null)
            {
                cli_cliente cliente = (cli_cliente)DAOObjectCliente.ConsultarXId(vw.id);
                return cliente != null ? cliente : new cli_cliente();
            }
            else
            {
                return null;
            }
        }

        public int RetirarTranfoDeCliente(int trafo_id, dbTS15Entities contexto, RawError error)
        {
            vw_transformador_cliente vw = contexto.vw_transformador_cliente.Where(p => p.transformador_id == trafo_id).SingleOrDefault();
            try
            {
                contexto.vw_transformador_cliente.DeleteObject(vw);
                return 0;
            }
            catch (NullReferenceException)
            {
                return 1;
            }
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
            tfr_transformador transformadorObject = entidad as tfr_transformador;
            SingletonDatos.Contexto.tfr_transformador.AddObject(transformadorObject);
            SingletonDatos.Contexto.SaveChanges();
            return true;
        }

        public List<tfr_transformador> ConsultarTransformadoresFabricante()
        {
            return SingletonDatos.Contexto.tfr_transformador.ToList();
        }

        public bool ValidarAsignacionCliente(int pIdTransformador)
        {
            bool esAsignado = false;
            int contador = SingletonDatos.Contexto.tfr_transf_has_cliente.Where(p => p.transformador_id == pIdTransformador).ToList().Count;

            if (contador > 0)
                esAsignado = true;

            return esAsignado;
        }

        public bool ValidarAsignacionSolicitud(int idTransformador)
        {
            bool esAsignado = false;
            int contador = SingletonDatos.Contexto.cli_pedido.Where(p => p.transformador_id == idTransformador && p.estado == 1).ToList().Count;

            if (contador > 0)
                esAsignado = true;

            return esAsignado;
        }

        public void IngresarEnBodega(tfr_bodega bodegaObject)
        {
            SingletonDatos.Contexto.tfr_bodega.AddObject(bodegaObject);
            SingletonDatos.Contexto.SaveChanges();
        }

        public vw_transformador_fabricante ConsultarTransformadorFabricante(int idTransformador)
        {
            return SingletonDatos.Contexto.vw_transformador_fabricante.Where(p => p.IdTransformador == idTransformador).SingleOrDefault();
        }

        public tfr_bodega ConsultarTransformadorBodega(int pIdTransformador)
        {
            if (SingletonDatos.Contexto.tfr_bodega.Where(p => p.transformador_id == pIdTransformador).ToList().Count > 0)
                return SingletonDatos.Contexto.tfr_bodega.Where(p => p.transformador_id == pIdTransformador).SingleOrDefault();

            else
                return null;
        }

        public void AsignarBodegaEntrega(tfr_bodega bodegaObject)
        {
            SingletonDatos.Contexto.SaveChanges();
        }

        public void EliminarEnBodega(tfr_bodega bodegaObject)
        {
            SingletonDatos.Contexto.tfr_bodega.DeleteObject(bodegaObject);
            SingletonDatos.Contexto.SaveChanges();
        }
    }
}
