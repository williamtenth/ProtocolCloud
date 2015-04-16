using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.DAL.abstractDAL;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;

namespace TS15.BL.abstractBL
{
    public abstract class BOGenerico
    {
        private DAOGenerico _genericoDAO;

        public DAOGenerico GenericoDAO
        {
            get { return _genericoDAO; }
            set { _genericoDAO = value; }
        }

        public abstract EntityObject obtenerUltimaPrueba(tfr_transformador transformador);
    }
}
