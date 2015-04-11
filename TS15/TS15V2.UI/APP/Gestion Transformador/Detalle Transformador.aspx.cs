using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL;
using TS15.BL.gestion_transformador;

namespace TS15.UI.APP.systems.Gestion_Transformador
{
    public partial class Detalle_Transformador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && Request.QueryString["idTransformador"] != null)
                CargarCliente(Request.QueryString["idTransformador"].ToString());
        }

        private void CargarCliente(string pIdTransformador)
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            BOTransformador transformadorBO = new BOTransformador();
            int idTransformador = Convert.ToInt32(pIdTransformador);
            tfr_transformador transformadorEntity = transformadorBO.ConsultarXId(idTransformador, contexto, error) as tfr_transformador;
        }
    }
}