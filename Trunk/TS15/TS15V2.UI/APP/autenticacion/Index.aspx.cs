using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TS15.UI.APP
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //VALIDA SI EL USUARIO ESTA AUTENTICADO y EN SESION
                ValidarAutenticacion();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        private void ValidarAutenticacion()
        {
            if (Session["usuario"] != null)
            {
                Response.Redirect("~/APP/systems/Home.aspx");
            }
        }
    }
}