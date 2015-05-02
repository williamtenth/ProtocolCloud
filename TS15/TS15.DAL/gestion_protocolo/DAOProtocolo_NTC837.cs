﻿using System;
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
    public class DAOProtocolo_NTC837 : DAOGenerico, IGestionable, IProbable
    {

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        public EntityObject ConsultarXId(int id)
        {
            pro_ntc837 resultado = SingletonDatos.Contexto.pro_ntc837.Where(p => p.id == id).SingleOrDefault();
            return resultado != null ? resultado : null;
        }

        public bool Modificar(EntityObject prueba)
        {
            pro_ntc837 _entidad = (pro_ntc837) prueba;
            pro_ntc837 entidad = (pro_ntc837)ConsultarXId(_entidad.id);
            
            if (entidad != null && _entidad != null)
            {
                // Encabezado
                entidad.bt_at_t = _entidad.bt_at_t;
                entidad.at_bt_t = _entidad.at_bt_t;
                entidad.tension = _entidad.tension;
                entidad.frecuencia = _entidad.frecuencia;
                entidad.tiempo = _entidad.tiempo;

                entidad.resultado = _entidad.resultado;
                entidad.fecha = DateTime.Now;
                // Detalle Corto Circuito
                                
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
            pro_ntc837 resultado = (pro_ntc837)ConsultarXId((entidad as pro_ntc837).id);

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
            pro_ntc837 resultado = SingletonDatos.Contexto.pro_ntc837
                .Where(r => r.transformador_id == transformador.id).OrderByDescending(p => p.id).SingleOrDefault();
            return resultado != null ? resultado : new pro_ntc837();
        }
    }
}
