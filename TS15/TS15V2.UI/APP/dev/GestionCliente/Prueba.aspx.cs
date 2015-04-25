using System;
using System.Web.UI;
using TS15V2.UI.APP.abstractUI;
using TS15V2.UI.APP.componentes;

namespace TS15V2.UI.APP.dev.GestionCliente
{
    public partial class Prueba : UIGenericoPagina
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarControl();

        }

        private void CargarControl()
        {
            //ddlTipDocumento.DataSource = TS15V2.UI.APP.util.Parametros.ConsultarParametros("tipdoc");
            //ddlTipDocumento.DataValueField = "consecutivo";
            //ddlTipDocumento.DataTextField = "descripcion";
            //ddlTipDocumento.DataBind();
        }

        protected void ddlTipDocumento_DataBound(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //ModalMsj1.TituloModal = "Prueba Titulo";
            //ModalMsj1.MensajeModal = "Este es un menjaje de prueba";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
            EnviarAModalMsj(ModalMsj1, "Prueba Titulo", "Este es un mensaje de prueba");
        }

        public void EnviarAModalMsj(ModalMsj modalMsj, String titulo, String mensaje)
        {
            modalMsj.TituloModal = titulo;
            modalMsj.MensajeModal = mensaje;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
        
    }
}