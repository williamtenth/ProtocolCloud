﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.DAL;
using TS15.BL.abstractBL;

namespace TS15.BL
{
    public class BOParametrica : BOGenerico, IGestionable
    {

        public BOParametrica()
        {
            GenericoDAO = new DAOParametrica();
        }

        public List<gen_parametrica> ConsultarParametros(string tipo)
        {
            return ((DAOParametrica)GenericoDAO).ConsultarParametros(tipo);
        }

        public static List<gen_parametrica> ConsultarParametrosSuministro(string tipo, dbTS15Entities contexto, RawError error)
        {
            return DAOParametrica.ConsultarParametrosSuministro(tipo, contexto, error);
        }

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        public void Actualizar(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
        }

        public void Crear(EntityObject entidad, dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
        }

        public EntityObject ConsultarXId(int id, dbTS15Entities contexto, RawError error)
        {
            throw new NotImplementedException();
        }

        public static List<gen_parametrica> ConsultarTipoSolictudSS(string tipo, dbTS15Entities contexto, RawError error)
        {
            return DAOParametrica.ConsultarTipoSolictudSS(tipo, contexto, error);
        }



        public bool Modificar(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public bool Crear(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public EntityObject ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
