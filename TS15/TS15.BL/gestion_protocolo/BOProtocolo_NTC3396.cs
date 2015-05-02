using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.BL.abstractBL;
using TS15.Common.IService;
using TS15.Common.Generated;
using TS15.DAL.gestion_protocolo;
using System.Data.Objects.DataClasses;

namespace TS15.BL.gestion_protocolo
{
    public class BOProtocolo_NTC3396 : BOGenerico, IGestionable, IProbable
    {
        // Constructores
        public BOProtocolo_NTC3396()
        {
            GenericoDAO = new DAOProtocolo_NTC3396();
        }


        // Métodos
        public List<System.Data.Objects.DataClasses.EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        public bool Modificar(System.Data.Objects.DataClasses.EntityObject entidad)
        {
            return ((DAOProtocolo_NTC3396)GenericoDAO).Modificar((pro_ntc3396)entidad);
        }

        public bool Eliminar(System.Data.Objects.DataClasses.EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public bool Crear(System.Data.Objects.DataClasses.EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public bool Terminar(EntityObject entidad)
        {
            // Valida: si todos los resultados fueron exitosos, el resultado de la prueba es exitoso, si no el resultado de la prueba en No exitoso.
            pro_ntc3396 prueba = (pro_ntc3396)entidad;
            if (prueba.salina1 == 1 && prueba.salina2 == 1 && prueba.impacto == 1 && prueba.espesor1 == 1
                && prueba.espesor2 == 1 && prueba.adherencia == 1)
                ((pro_ntc3396)entidad).resultado = 1;
            else
                ((pro_ntc3396)entidad).resultado = 2;
            return ((DAOProtocolo_NTC3396)GenericoDAO).Terminar(entidad);

        }

        public EntityObject ConsultarXId(int id)
        {
            pro_ntc3396 resultado = (pro_ntc3396)((DAOProtocolo_NTC3396)GenericoDAO).ConsultarXId(id);
            return resultado != null ? resultado : new pro_ntc3396();
        }

        public EntityObject ObtenerUltimaPrueba(tfr_transformador transformador)
        {
            pro_ntc3396 resultado = (pro_ntc3396)((DAOProtocolo_NTC3396)GenericoDAO).ObtenerUltimaPrueba(transformador);
            return resultado != null ? resultado : new pro_ntc3396();
        }


        public pro_elementoprueba ObternerPruebasXProceso(int proceso)
        {
            return ((DAOProtocolo_NTC3396)GenericoDAO).ObternerPruebasXProceso(proceso);
        }
    }
}
