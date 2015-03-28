using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TS15.UI.APP.systems.Gestion_Cliente
{
    public partial class Crear_Pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarListas();
        }

        private void CargarListas()
        {
            CargarFabricante();
            CargarSerieBT();
            CargarCapacidad();
            CargarFase();
        }


        private void CargarFabricante()
        {

        }

        private void CargarSerieBT()
        {
        }

        private void CargarCapacidad()
        {
        }

        private void CargarFase()
        {
        }

        protected void ddlFabricante_DataBound(object sender, EventArgs e)
        {
            ddlFabricante.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }

        protected void ddlSerieBT_DataBound(object sender, EventArgs e)
        {
            ddlSerieBT.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }

        protected void ddlCapacidad_DataBound(object sender, EventArgs e)
        {
            ddlCapacidad.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }

        protected void ddlFase_DataBound(object sender, EventArgs e)
        {
            ddlFase.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }
    }
}