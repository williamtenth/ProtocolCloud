using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS15.Common.Generated;
using TS15.Common.RawObjects;

namespace TS15.DAL.abstractDAL
{
    public class DAOSingleton
    {
        private static DAOSingleton _singletonDatos;
        private dbTS15Entities _contexto;

        public dbTS15Entities Contexto
        {
            get { return _contexto; }
            set { _contexto = value; }
        }

        private DAOSingleton()
        {
            _contexto = new dbTS15Entities();
        }

        /// <summary>
        /// Retorna un Singleton_Controller si no se ha creado
        /// </summary>
        /// <returns></returns>
        public static DAOSingleton GetInstance()
        {
            if (_singletonDatos == null)
                _singletonDatos = new DAOSingleton();

            return _singletonDatos;
        }


    }
}