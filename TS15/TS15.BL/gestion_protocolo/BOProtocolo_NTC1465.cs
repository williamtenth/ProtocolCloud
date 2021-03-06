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
    public class BOProtocolo_NTC1465 : BOGenerico, IGestionable, IProbable
    {



        ~BOProtocolo_NTC1465()
        {

        }

        public BOProtocolo_NTC1465()
        {
            GenericoDAO = new DAOProtocoloNTC1465();
        }

        /// <summary>
        /// Esta funci�n desbloquea los campos del formulario y habilita los botones.
        /// </summary>
        /// <param name="entidad"></param>
        public bool Modificar(EntityObject entidad)
        {

            return ((DAOProtocoloNTC1465)GenericoDAO).Modificar(entidad);
        }

        /// 
        /// <param name="entidad"></param>
        public bool Terminar(EntityObject entidad)
        {

            return ((DAOProtocoloNTC1465)GenericoDAO).Terminar(entidad);
        }

        public List<EntityObject> Consultar()
        {

            return null;
        }

        /// 
        /// <param name="prueba"></param>
        public EntityObject ObtenerUltimaPrueba(tfr_transformador transformador)
        {
            return ((DAOProtocoloNTC1465)GenericoDAO).ObtenerUltimaPrueba(transformador);
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

            pro_ntc1465 prueba = (pro_ntc1465)entidad;
            prueba.metaislante = 1;
            prueba.refaislante = 1;
            prueba.tipaislante = 1;

            return ((DAOProtocoloNTC1465)GenericoDAO).Crear(entidad);
        }

        /// 
        /// <param name="entidad"></param>
        public bool Eliminar(EntityObject entidad)
        {

            return false;
        }



        public pro_elementoprueba ObtenerPruebasXProceso(int proceso)
        {
            return ((DAOProtocoloNTC1465)GenericoDAO).ObtenerPruebasXProceso(proceso);
        }
    }//end BOProtocolo_NTC1465

}//end namespace gestion_protocolo