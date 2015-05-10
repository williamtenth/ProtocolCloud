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
    public class DAOProtocolo_NTC471 : DAOGenerico, IGestionable, IProbable
    {
        private String nombrePrueba;

        public DAOProtocolo_NTC471()
        {
            nombrePrueba = VariablesGlobales.PRUEBA_NTC471;
        }

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        public EntityObject ConsultarXId(int id)
        {
            pro_ntc471 resultado = SingletonDatos.Contexto.pro_ntc471.Where(p => p.id == id).SingleOrDefault();
            return resultado != null ? resultado : null;
        }

        public bool Modificar(EntityObject entidad)
        {
            pro_ntc471 _entidad = (pro_ntc471)entidad;
            pro_ntc471 resultado = (pro_ntc471)ConsultarXId(_entidad.id);

            if (resultado != null && _entidad != null)
            {
                // Encabezado
                resultado.resultado = _entidad.resultado;
                resultado.relacion = _entidad.relacion;
                resultado.fase_fase = _entidad.fase_fase;
                resultado.fase_neutro = _entidad.fase_neutro;
                resultado.polaridad = _entidad.polaridad;
                resultado.resultado = _entidad.resultado;
                resultado.fecha = DateTime.Now;
                
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
            SingletonDatos.Contexto.pro_ntc471.AddObject(entidad as pro_ntc471);
            if (SingletonDatos.Contexto.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Terminar(EntityObject entidad)
        {
            pro_ntc471 resultado = (pro_ntc471)ConsultarXId((entidad as pro_ntc471).id);

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
            pro_ntc471 resultado = SingletonDatos.Contexto.pro_ntc471
                .Where(r => r.transformador_id == transformador.id).OrderByDescending(p => p.id).SingleOrDefault();
            return resultado != null ? resultado : new pro_ntc471();
        }

        public pro_elementoprueba ObtenerPruebasXProceso(int proceso)
        {
            pro_ntc471 prueba = SingletonDatos.Contexto.pro_ntc471.Where(p => p.proceso_id == proceso).First();
            if (prueba != null)
            {
                pro_elementoprueba elemento = new pro_elementoprueba(nombrePrueba, prueba.fecha, prueba.resultado, prueba.estado, prueba);
                return elemento;
            }
            return null;
        }
    }
}
