using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.DAL.abstractDAL;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.Common.util;

namespace TS15.DAL.gestion_protocolo
{
    public class DAOProtocolo_NTC375 : DAOGenerico, IGestionable, IProbable
    {
        private String nombrePrueba;

        public DAOProtocolo_NTC375()
        {
            nombrePrueba = VariablesGlobales.PRUEBA_NTC375;
        }

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        public EntityObject ConsultarXId(int id)
        {
            pro_ntc375 resultado = SingletonDatos.Contexto.pro_ntc375.Where(p => p.id == id).SingleOrDefault();
            return resultado != null ? resultado : null;
        }

        public bool Modificar(EntityObject entidad)
        {
            pro_ntc375 _entidad = (pro_ntc375)entidad;
            pro_ntc375 resultado = (pro_ntc375)ConsultarXId(_entidad.id);

            if (resultado != null && _entidad != null)
            {
                // Encabezado
                resultado.tiempolectura = _entidad.tiempolectura;
                resultado.tension = _entidad.tension;
                resultado.at_t = _entidad.at_t;
                resultado.bt_t = _entidad.bt_t;
                resultado.at_bt_t = _entidad.at_bt_t;
                resultado.resultado = _entidad.resultado;
                resultado.fecha = DateTime.Now;
                // Detalle Resistencia
                resultado.resistencia_uv = _entidad.resistencia_uv;
                resultado.resistencia_vw = _entidad.resistencia_vw;
                resultado.resistencia_wv = _entidad.resistencia_wv;
                resultado.resistencia2_uv = _entidad.resistencia2_uv;
                resultado.resistencia2_vw = _entidad.resistencia2_vw;
                resultado.resistencia2_wv = _entidad.resistencia2_wv;
                // Detalle Promedio
                resultado.resistencia_promedio = _entidad.resistencia_promedio;
                resultado.resistencia2_promedio = _entidad.resistencia2_promedio;
                // Detalle Material
                resultado.matedevanado = _entidad.matedevanado;
                resultado.metadevanado2 = _entidad.metadevanado2;

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
            SingletonDatos.Contexto.pro_ntc375.AddObject(entidad as pro_ntc375);
            if (SingletonDatos.Contexto.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Terminar(EntityObject entidad)
        {
            pro_ntc375 resultado = (pro_ntc375)ConsultarXId((entidad as pro_ntc375).id);

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
            pro_ntc375 resultado = SingletonDatos.Contexto.pro_ntc375
                .Where(r => r.transformador_id == transformador.id).OrderByDescending(p => p.id).SingleOrDefault();
            return resultado != null ? resultado : new pro_ntc375();
        }

        public pro_elementoprueba ObternerPruebasXProceso(int proceso)
        {
            pro_ntc375 prueba = SingletonDatos.Contexto.pro_ntc375.Where(p => p.proceso_id == proceso).First();
            if (prueba != null)
            {
                pro_elementoprueba elemento = new pro_elementoprueba(nombrePrueba, prueba.fecha, prueba.resultado, prueba);
                return elemento;
            }
            return null;
        }
    }
}
