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

        public EntityObject ConsultarXId(int id)
        {
            tfr_ordentrabajo resultado = SingletonDatos.Contexto.tfr_ordentrabajo.Where(p => p.id == id).SingleOrDefault();
            return resultado != null ? resultado : null;
        }

        public tfr_ordentrabajo ConsultarXPedido(int pedido)
        {
            tfr_ordentrabajo resultado = SingletonDatos.Contexto.tfr_ordentrabajo.Where(p => p.pedido_id == pedido).SingleOrDefault();
            return resultado != null ? resultado : null;
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

        public bool Modificar(EntityObject entidad) {
            tfr_ordentrabajo resultado = (tfr_ordentrabajo)ConsultarXId((int)(entidad as tfr_ordentrabajo).id);
            tfr_ordentrabajo _entidad = (tfr_ordentrabajo)entidad;
            
            if (resultado != null && _entidad != null)
            {
                // Encabezado
                resultado.estado = _entidad.estado;
                
                // Persistencia
                SingletonDatos.Contexto.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
