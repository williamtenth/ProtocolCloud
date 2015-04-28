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
    public class DAOProtocolo_NTC1031 : DAOGenerico, IGestionable, IProbable
    {

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        public EntityObject ConsultarXId(int id)
        {
            pro_ntc1031 resultado = SingletonDatos.Contexto.pro_ntc1031.Where(p => p.id == id).SingleOrDefault();
            return resultado != null ? resultado : null;
        }

        public bool Modificar(EntityObject entidad)
        {
            pro_ntc1031 _entidad = (pro_ntc1031) entidad;
            pro_ntc1031 resultado = (pro_ntc1031)ConsultarXId(_entidad.id);
            
            if (resultado != null && _entidad != null)
            {
                // Encabezado
                resultado.ix = _entidad.ix;
                resultado.i2 = _entidad.i2;
                resultado.i3 = _entidad.i3;
                resultado.promedio = _entidad.promedio;
                resultado.garantia = _entidad.garantia;
                resultado.po_medida = _entidad.po_medida;
                resultado.po_garantizado = _entidad.po_garantizado;
                // Fecha de modificación
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
            throw new NotImplementedException();
        }

        public bool Terminar(EntityObject entidad)
        {
            pro_ntc1031 resultado = (pro_ntc1031)ConsultarXId((entidad as pro_ntc1031).id);

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
            pro_ntc1031 resultado = SingletonDatos.Contexto.pro_ntc1031
                .Where(r => r.transformador_id == transformador.id).OrderByDescending(p => p.id).SingleOrDefault();
            return resultado != null ? resultado : new pro_ntc1031();
        }
    }
}
