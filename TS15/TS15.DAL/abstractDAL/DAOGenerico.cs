using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
