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

        public List<EntityObject> Consultar()
        {
            List<EntityObject> lstTransformadores = SingletonDatos.Contexto.tfr_transformador.ToList().Cast<EntityObject>().ToList();
            return lstTransformadores;
        }

        public void Actualizar(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
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

        public EntityObject ConsultarXId(int id, dbTS15Entities contexto, RawError error)
        {
            return contexto.tfr_transformador.Where(p => p.id == id).SingleOrDefault();
        }

        public EntityObject ConsultarClienteXTrafoId(int trafo_id, dbTS15Entities contexto, RawError error)
        {
            vw_transformador_cliente vw = contexto.vw_transformador_cliente.Where(p => p.transformador_id == trafo_id).SingleOrDefault();
            if (vw != null)
            {
                cli_cliente cliente = (cli_cliente) DAOCliente.ConsultarXId(vw.id, contexto, error);
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
            catch(NullReferenceException)
            {
                return 1;
            }
        }

    }
}
