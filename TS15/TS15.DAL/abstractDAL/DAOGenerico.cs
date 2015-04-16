using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;

namespace TS15.DAL.abstractDAL
{
    public abstract class DAOGenerico
    {
        private DAOSingleton _singletonDatos = DAOSingleton.GetInstance();

        public DAOSingleton SingletonDatos
        {
            get { return _singletonDatos; }
            set { _singletonDatos = value; }
        }

        public DAOGenerico()
        {
            
        }

        
    }
}
