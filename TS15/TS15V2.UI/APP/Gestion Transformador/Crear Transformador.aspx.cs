using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL;

namespace TS15.UI.APP.systems.Gestion_Transformador
{
    public partial class Crear_Transformador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarListas();
        }

        private void CargarListas()
        {
            CargarFabricante();
            CargarSerieAT();
            CargarSerieBT();
            CargarCapacidad();
            CargarFase();
            CargarGrupoConexion();
        }




        private void CargarFabricante()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            ddlCapacidad.DataSource = BOCliente.ConsultarFabricantes(contexto, error);
            ddlCapacidad.DataValueField = "id";
            ddlCapacidad.DataTextField = "nombre";
            ddlCapacidad.DataBind();
        }

        private void CargarSerieAT()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            ddlCapacidad.DataSource = BOParametrica.ConsultarParametros("tfrtenserie", contexto, error);
            ddlCapacidad.DataValueField = "consecutivo";
            ddlCapacidad.DataTextField = "valor";
            ddlCapacidad.DataBind();
        }

        private void CargarSerieBT()
        {
        }

        private void CargarCapacidad()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();

            ddlCapacidad.DataSource = BOParametrica.ConsultarParametros("tfrcapacidad", contexto, error);
            ddlCapacidad.DataValueField = "consecutivo";
            ddlCapacidad.DataTextField = "valor";
            ddlCapacidad.DataBind();
        }

        private void CargarFase()
        {
        }

        private void CargarGrupoConexion()
        {
        }

        protected void ddlFabricante_DataBound(object sender, EventArgs e)
        {
            ddlFabricante.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }

        protected void ddlSerieAT_DataBound(object sender, EventArgs e)
        {
            ddlSerieAT.Items.Insert(0, new ListItem("Seleccione...", "-1"));
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

        protected void ddlGrupoConexion_DataBound(object sender, EventArgs e)
        {
            ddlGrupoConexion.Items.Insert(0, new ListItem("Seleccione...", "-1"));
        }
    }
}