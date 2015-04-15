using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.DAL.abstractDAL;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;

namespace TS15.DAL.gestion_protocolo
{
    public class DAOProtocolo_NTC3396 : DAOGenerico, IGestionable, ITerminable
    {

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

        public bool Modificar(pro_ntc3396 entidad)
        {
            pro_ntc3396 resultado = ConsultarXId(entidad.id);
            
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
                return true;
            }
            
            return false;
        }

        public bool Eliminar(System.Data.Objects.DataClasses.EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public bool Crear(System.Data.Objects.DataClasses.EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public bool Terminar(int resultado)
        {
            throw new NotImplementedException();
        }


        public pro_ntc3396 ConsultarXId(int id)
        {
            pro_ntc3396 resultado = SingletonDatos.Contexto.pro_ntc3396.Where(p => p.id == id).SingleOrDefault();
            return resultado != null ? resultado : null;
        }





        public bool Modificar(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        EntityObject IGestionable.ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
