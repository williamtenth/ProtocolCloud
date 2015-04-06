using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL.Gestion_Cliente;
using TS15.BL.Gestion_Transformador;

namespace TS15V2.UI.APP.componentes
{
    public partial class BuscarTransformador : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarListas();
        }

        private void CargarListas()
        {
            CargarFabricante();
        }

        private void CargarFabricante()
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            BOCliente clienteBO = new BOCliente();

            this.ddlFabricante.DataSource = clienteBO.ConsultarFabricantes(contexto, error);
            this.ddlFabricante.DataValueField = "id";
            this.ddlFabricante.DataTextField = "nombre";
            this.ddlFabricante.DataBind();
        }

        protected void ddlFabricante_DataBound(object sender, EventArgs e)
        {
            this.ddlFabricante.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }

        protected void btnBuscarTranformador_Click(object sender, EventArgs e)
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            BOTransformador transformadorBO = new BOTransformador();

            gvTransformadores.DataSource = transformadorBO.Consultar(contexto, error);
            gvTransformadores.DataBind();
            mpeTransformador.Show();
        }

        protected void gvTransformadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idCliente = gvTransformadores.DataKeys[gvTransformadores.SelectedRow.RowIndex].Values[0].ToString();
            string nombreCliente = gvTransformadores.DataKeys[gvTransformadores.SelectedRow.RowIndex].Values[1].ToString();

            //this.hfIdCliente.Value = idCliente;
            //this.lblNombreCliente.Text = nombreCliente;
            //this.pnlMsj.CssClass = "alert alert-success";
            //this.pnlMsj.Visible = true;

            //CargarTipoSolicitud();
            //this.pnlTipoSolicitud.Visible = true;
        }

        protected void gvTransformadores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("OnMouseOver", "this.style.cursor='pointer';this.style.textDecoration='underline';");
                e.Row.Attributes["OnMouseOut"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Click para seleccionar";
                e.Row.Attributes["OnClick"] = Page.ClientScript.GetPostBackClientHyperlink(gvTransformadores, "Select$" + e.Row.RowIndex);
            }
        }
    }
}