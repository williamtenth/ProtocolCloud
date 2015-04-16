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
    class BOProtocolo_NTC3396 : BOGenerico, IGestionable, ITerminable
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

        public void Actualizar(System.Data.Objects.DataClasses.EntityObject entidad, Common.Generated.dbTS15Entities contexto, Common.RawObjects.RawError error)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(System.Data.Objects.DataClasses.EntityObject entidad, Common.Generated.dbTS15Entities contexto, Common.RawObjects.RawError error)
        {
            throw new NotImplementedException();
        }

        public void Crear(System.Data.Objects.DataClasses.EntityObject entidad, Common.Generated.dbTS15Entities contexto, Common.RawObjects.RawError error)
        {
            throw new NotImplementedException();
        }

        public System.Data.Objects.DataClasses.EntityObject ConsultarXId(int id, Common.Generated.dbTS15Entities contexto, Common.RawObjects.RawError error)
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

        public bool Terminar(pro_ntc3396 entidad)
        {
            // Valida que el resultado fuera exitosa.
            if (entidad.salina1 == 1 && entidad.salina2 == 1 && entidad.impacto == 1 && entidad.espesor1 == 1
                && entidad.espesor2 == 1 && entidad.adherencia == 1)
            {
                return ((DAOProtocolo_NTC3396)GenericoDAO).Terminar(entidad);
            }
            return false;
            
        }

        public System.Data.Objects.DataClasses.EntityObject ConsultarXId(int id)
        {
            pro_ntc3396 resultado = (pro_ntc3396)((DAOProtocolo_NTC3396)GenericoDAO).ConsultarXId(id);
            return resultado != null ? resultado : new pro_ntc3396();
        }

        public override EntityObject obtenerUltimaPrueba(tfr_transformador transformador)
        {
            pro_ntc3396 resultado = (pro_ntc3396)((DAOProtocolo_NTC3396)GenericoDAO).obtenerUltimaPrueba(transformador);
            return resultado != null ? resultado : new pro_ntc3396();
        }
    }
}
