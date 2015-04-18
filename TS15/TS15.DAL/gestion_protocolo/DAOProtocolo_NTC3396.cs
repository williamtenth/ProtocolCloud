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
    public class DAOProtocolo_NTC3396 : DAOGenerico, IGestionable, IProbable
    {

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        public void Actualizar(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public EntityObject ConsultarXId(int id)
        {
            pro_ntc3396 resultado = SingletonDatos.Contexto.pro_ntc3396.Where(p => p.id == id).SingleOrDefault();
            return resultado != null ? resultado : null;
        }

        public bool Modificar(pro_ntc3396 entidad)
        {
            pro_ntc3396 resultado = (pro_ntc3396)ConsultarXId(entidad.id);
            
            if (resultado != null && entidad != null)
            {
                resultado.color = entidad.color;
                resultado.salina1 = entidad.salina1;
                resultado.salina2 = entidad.salina2;
                resultado.impacto = entidad.impacto;
                resultado.espesor1 = entidad.espesor1;
                resultado.espesor2 = entidad.espesor2;
                resultado.adherencia = entidad.adherencia;
                resultado.fecha = new DateTime();
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
            pro_ntc3396 resultado = (pro_ntc3396)ConsultarXId((entidad as pro_ntc3396).id);

            if (resultado != null && entidad != null)
            {
                resultado.estado = 2;
                SingletonDatos.Contexto.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Modificar(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public EntityObject ObtenerUltimaPrueba(tfr_transformador transformador)
        {
            pro_ntc3396 resultado = SingletonDatos.Contexto.pro_ntc3396
                .Where(r => r.transformador_id == transformador.id).OrderByDescending(p => p.id).SingleOrDefault();
            return resultado != null ? resultado : new pro_ntc3396();
        }
    }
}
