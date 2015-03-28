using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TS15.UI.APP.systems.Gestion_Transformador
{
    public partial class Busqueda_Transformador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            mpeTransformadores.Show();
        }

        protected void ddlFabricante_DataBound(object sender, EventArgs e)
        {
            this.ddlFabricante.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void gvTransformadores_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvTransformadores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}