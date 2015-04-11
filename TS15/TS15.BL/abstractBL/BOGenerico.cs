using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.DAL.abstractDAL;

namespace TS15.BL.abstractBL
{
    public abstract class BOGenerico
    {
        private DAOGenerico genericoDAO;

        public DAOGenerico GenericoDAO
        {
            get { return genericoDAO; }
            set { genericoDAO = value; }
        }
    }
}
