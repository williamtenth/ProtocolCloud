using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS15.Common.Generated;
using TS15.Common.RawObjects;

namespace TS15V2.UI.APP.util
{
    public class SingletonControlador
    {
        private static SingletonControlador _singletonControlador = null;
        private RawError _error;

        public RawError Error
        {
            get { return _error; }
            set { _error = value; }
        }

        private SingletonControlador()
        {
            _error = new RawError();
        }

        /// <summary>
        /// Retorna un Singleton_Controller si no se ha creado
        /// </summary>
        /// <returns></returns>
        public static SingletonControlador GetInstance()
        {
            if (_singletonControlador == null)
                _singletonControlador = new SingletonControlador();

            return _singletonControlador;
        }


    }
}