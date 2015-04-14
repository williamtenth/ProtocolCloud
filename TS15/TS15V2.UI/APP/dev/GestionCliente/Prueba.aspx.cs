using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15V2.UI.APP.util;
using TS15V2.UI.APP.abstractUI;

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
            ddlTipDocumento.DataSource = TS15V2.UI.APP.util.Parametros.ConsultarParametros("tipdoc");
            ddlTipDocumento.DataValueField = "consecutivo";
            ddlTipDocumento.DataTextField = "descripcion";
            ddlTipDocumento.DataBind();
        }

        protected void ddlTipDocumento_DataBound(object sender, EventArgs e)
        {

        }
    }
}