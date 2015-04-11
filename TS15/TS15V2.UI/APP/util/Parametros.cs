using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS15.Common.Generated;
using TS15.BL;
using TS15.Common.RawObjects;

namespace TS15V2.UI.APP.util
{
    public class Parametros
    {
        public static List<gen_parametrica> ConsultarParametros(string pTipo)
        {
            BOParametrica parametricaBO = new BOParametrica();
            return parametricaBO.ConsultarParametros(pTipo);
        }
    }
}