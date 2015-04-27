///////////////////////////////////////////////////////////
//  BOProtocolo_NTC1465.cs
//  Implementation of the Class BOProtocolo_NTC1465
//  Generated by Enterprise Architect
//  Created on:      25-abr.-2015 11:08:37 a. m.
//  Original author: william_cuadros
///////////////////////////////////////////////////////////




using TS15.Common.Generated;
using TS15.BL.abstractBL;
using TS15.Common.IService;
using TS15.DAL.gestion_protocolo;
using System.Data.Objects.DataClasses;
using System.Collections.Generic;

namespace TS15.BL.gestion_protocolo
{
    public class BOProtocolo_NTC375 : BOGenerico, IGestionable, IProbable
    {

        public BOProtocolo_NTC375()
        {
            GenericoDAO = new DAOProtocolo_NTC375();
        }

        /// <summary>
        /// Esta funci�n desbloquea los campos del formulario y habilita los botones.
        /// </summary>
        /// <param name="entidad"></param>
        public bool Modificar(EntityObject entidad)
        {

            return ((DAOProtocolo_NTC375)GenericoDAO).Modificar(entidad);
        }

        /// 
        /// <param name="entidad"></param>
        public bool Terminar(EntityObject entidad)
        {

            return ((DAOProtocolo_NTC375)GenericoDAO).Terminar(entidad);
        }

        public List<EntityObject> Consultar()
        {

            return null;
        }

        /// 
        /// <param name="prueba"></param>
        public EntityObject ObtenerUltimaPrueba(tfr_transformador transformador)
        {
            return ((DAOProtocolo_NTC375)GenericoDAO).ObtenerUltimaPrueba(transformador);
        }

        /// 
        /// <param name="id"></param>
        public EntityObject ConsultarXId(int id)
        {

            return null;
        }

        /// 
        /// <param name="entidad"></param>
        public bool Crear(EntityObject entidad)
        {

            return false;
        }

        /// 
        /// <param name="entidad"></param>
        public bool Eliminar(EntityObject entidad)
        {

            return false;
        }

    }//end BOProtocolo_NTC1465

}//end namespace gestion_protocolo