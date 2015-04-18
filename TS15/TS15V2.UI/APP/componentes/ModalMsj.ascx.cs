using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TS15V2.UI.APP.componentes
{
    public partial class ModalMsj : System.Web.UI.UserControl
    {
        private string _tituloModal;

        public string TituloModal
        {
            get { return this.lblTitulo.Text; }
            set { this.lblTitulo.Text = value; }
        }

        private string _mensajeModal;

        public string MensajeModal
        {
            get { return this.lblMensaje.Text; }
            set { this.lblMensaje.Text = value; }
        }
    }
}