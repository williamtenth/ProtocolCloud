using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS15.Common.Generated;
using TS15.Common.RawObjects;

namespace TS15V2.UI.APP.abstractUI
{
    public class UISingleton
    {
        private static UISingleton _singletonControlador = null;
        private RawError _error;

        public RawError Error
        {
            get { return _error; }
            set { _error = value; }
        }

        private UISingleton()
        {
            _error = new RawError();
        }

        /// <summary>
        /// Retorna un Singleton_Controller si no se ha creado
        /// </summary>
        /// <returns></returns>
        public static UISingleton GetInstance()
        {
            if (_singletonControlador == null)
                _singletonControlador = new UISingleton();

            return _singletonControlador;
        }


    }
}