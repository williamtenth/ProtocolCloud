///////////////////////////////////////////////////////////
//  DAOProtocolo_NTC1465.cs
//  Implementation of the Class DAOProtocolo_NTC1465
//  Generated by Enterprise Architect
//  Created on:      25-abr.-2015 11:08:10 a. m.
//  Original author: william_cuadros
///////////////////////////////////////////////////////////

using TS15.Common.Generated;
using TS15.Common.IService;
using TS15.DAL.abstractDAL;
using System.Data.Objects.DataClasses;
using System.Collections.Generic;
using System.Linq;
using System;
using TS15.Common.util;

namespace TS15.DAL.gestion_protocolo
{
    public class DAOProtocoloNTC1465 : DAOGenerico, IGestionable, IProbable
    {
        private string nombrePrueba;
        public DAOProtocoloNTC1465()
        {
            nombrePrueba = VariablesGlobales.PRUEBA_NTC1465;
        }

        /// <summary>
        /// Esta funci�n desbloquea los campos del formulario y habilita los botones.
        /// </summary>
        /// <param name="entidad"></param>
        public bool Modificar(EntityObject entidad)
        {
            pro_ntc1465 resultado = (pro_ntc1465)ConsultarXId((entidad as pro_ntc1465).id);

            if (resultado != null && entidad != null)
            {
                resultado.ruptura = (entidad as pro_ntc1465).ruptura;
                resultado.resultado = (entidad as pro_ntc1465).resultado;
                resultado.tipaislante = (entidad as pro_ntc1465).tipaislante;
                resultado.refaislante = (entidad as pro_ntc1465).refaislante;
                resultado.metaislante = (entidad as pro_ntc1465).metaislante;
                // Fecha
                resultado.fecha = DateTime.Now;
                SingletonDatos.Contexto.SaveChanges();
                return true;
            }

            return false;
        }

        /// 
        /// <param name="entidad"></param>
        public bool Terminar(EntityObject entidad)
        {
            pro_ntc1465 resultado = (pro_ntc1465)ConsultarXId((entidad as pro_ntc1465).id);

            if (resultado != null && entidad != null)
            {
                resultado.estado = 2;
                SingletonDatos.Contexto.SaveChanges();
                return true;
            }

            return false;
        }

        public List<EntityObject> Consultar()
        {

            return null;
        }

        /// 
        /// <param name="prueba"></param>
        public EntityObject ObtenerUltimaPrueba(tfr_transformador transformador)
        {
            pro_ntc1465 resultado = SingletonDatos.Contexto.pro_ntc1465
                .Where(r => r.transformador_id == transformador.id).OrderByDescending(p => p.id).SingleOrDefault();
            return resultado != null ? resultado : null;
        }

        /// 
        /// <param name="id"></param>
        public EntityObject ConsultarXId(int id)
        {
            pro_ntc1465 resultado = SingletonDatos.Contexto.pro_ntc1465.Where(p => p.id == id).SingleOrDefault();
            return resultado;
        }

        /// 
        /// <param name="entidad"></param>
        public bool Crear(EntityObject entidad)
        {
            SingletonDatos.Contexto.pro_ntc1465.AddObject(entidad as pro_ntc1465);
            if (SingletonDatos.Contexto.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        /// 
        /// <param name="entidad"></param>
        public bool Eliminar(EntityObject entidad)
        {

            return false;
        }



        public pro_elementoprueba ObtenerPruebasXProceso(int proceso)
        {
            pro_ntc1465 prueba = SingletonDatos.Contexto.pro_ntc1465.Where(p => p.proceso_id == proceso).First();
            if (prueba != null)
            {
                pro_elementoprueba elemento = new pro_elementoprueba(nombrePrueba, prueba.fecha, prueba.resultado, prueba.estado, prueba);
                return elemento;
            }
            return null;
        }
    }//end DAOProtocolo_NTC1465

}//end namespace gestion_protocolo