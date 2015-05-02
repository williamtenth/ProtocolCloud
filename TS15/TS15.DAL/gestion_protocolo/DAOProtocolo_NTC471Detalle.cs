using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.DAL.abstractDAL;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;
using TS15.Common.RawObjects;

namespace TS15.DAL.gestion_protocolo
{
    public class DAOProtocolo_NTC471Detalle : DAOGenerico
    {

        public pro_ntc471_has_relacion ConsultarXId(Decimal id)
        {
            pro_ntc471_has_relacion resultado = SingletonDatos.Contexto.pro_ntc471_has_relacion.Where(p => p.id == id).SingleOrDefault();
            return resultado != null ? resultado : null;
        }

        public List<pro_ntc471_has_relacion> ConsultarListaXIdPrueba(int pruebaId)
        {
            List<pro_ntc471_has_relacion> listaDetalle = SingletonDatos.Contexto.pro_ntc471_has_relacion.Where(p => p.ntc471_id == pruebaId).ToList();
            return listaDetalle;
        }

        public bool Modificar(List<pro_ntc471_has_relacion> listaDetalle)
        {
            foreach(pro_ntc471_has_relacion detalle in listaDetalle)
            {
                if (Modificar(detalle) != true)
                    return false;
            }

            return true;
        }

        public bool Modificar(pro_ntc471_has_relacion detalle)
        {
            pro_ntc471_has_relacion _entidad = detalle;
            pro_ntc471_has_relacion entidad = ConsultarXId(detalle.id);

            if (entidad != null && _entidad != null)
            {
                // Encabezado
                entidad.tension = _entidad.tension;
                entidad.fase_u = _entidad.fase_u;
                entidad.fase_v = _entidad.fase_v;
                entidad.fase_w = _entidad.fase_w;
                entidad.nominal = _entidad.nominal;
                entidad.minima = _entidad.minima;
                entidad.maxima = _entidad.maxima;

                SingletonDatos.Contexto.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Eliminar(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public bool Crear(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

    }
}
