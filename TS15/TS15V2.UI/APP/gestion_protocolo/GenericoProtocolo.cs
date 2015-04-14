using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15V2.UI.APP.abstractUI;
using TS15.Common.Generated;

namespace TS15V2.UI.APP.gestion_protocolo
{
    public abstract class GenericoProtocolo : UIGenericoPagina
    {
        private pro_proceso _proceso;
        private tfr_transformador _transformador;

        public GenericoProtocolo()
        { 
        }

        public pro_proceso Proceso
        {
            get { return _proceso; }
            set { _proceso = value; }
        }

        public tfr_transformador Transformador
        {
            get { return _transformador; }
            set { _transformador = value; }
        }
    }
}