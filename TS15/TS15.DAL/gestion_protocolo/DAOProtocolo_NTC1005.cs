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
    public class DAOProtocolo_NTC1005 : DAOGenerico, IGestionable, IProbable
    {

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        public EntityObject ConsultarXId(int id)
        {
            pro_ntc1005 resultado = SingletonDatos.Contexto.pro_ntc1005.Where(p => p.id == id).SingleOrDefault();
            return resultado != null ? resultado : null;
        }

        public bool Modificar(EntityObject entidad)
        {
            pro_ntc1005 _entidad = (pro_ntc1005) entidad;
            pro_ntc1005 resultado = (pro_ntc1005)ConsultarXId(_entidad.id);
            
            if (resultado != null && _entidad != null)
            {
                // Encabezado
                resultado.icc = _entidad.icc;
                resultado.ucc = _entidad.ucc;
                resultado.resultado = _entidad.resultado;
                resultado.fecha = DateTime.Now;
                // Detalle Corto Circuito
                resultado.perdidas24 = _entidad.perdidas24;
                resultado.perdidas85 = _entidad.perdidas85;
                resultado.garantiazada85 = _entidad.garantiazada85;
                resultado.i2r24 = _entidad.i2r24;
                resultado.i2r85 = _entidad.i2r85;
                resultado.i2r85garantia = _entidad.i2r85garantia;
                resultado.impedancia24 = _entidad.impedancia24;
                resultado.impedancia85 = _entidad.impedancia85;
                resultado.impedancia85gar = _entidad.impedancia85gar;
                resultado.regulacion = _entidad.regulacion;
                resultado.eficiencia = _entidad.eficiencia;
                                
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

        public bool Terminar(EntityObject entidad)
        {
            pro_ntc1005 resultado = (pro_ntc1005)ConsultarXId((entidad as pro_ntc1005).id);

            if (resultado != null && entidad != null)
            {
                resultado.estado = 2;
                SingletonDatos.Contexto.SaveChanges();
                return true;
            }

            return false;
        }

        public EntityObject ObtenerUltimaPrueba(tfr_transformador transformador)
        {
            pro_ntc1005 resultado = SingletonDatos.Contexto.pro_ntc1005
                .Where(r => r.transformador_id == transformador.id).OrderByDescending(p => p.id).SingleOrDefault();
            return resultado != null ? resultado : new pro_ntc1005();
        }
    }
}
