using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL.gestion_cliente;
using TS15.BL.gestion_transformador;
using System.Web.Security;
using System.Web.Configuration;
using TS15V2.UI.APP.abstractUI;
using TS15V2.UI.APP.util;

namespace TS15V2.UI.APP.componentes
{
    public partial class BuscarTransformador : UIGenericoComponente
    {
        private cli_cliente _cliente;
        private List<tfr_transformador> lstTransformadoresFabricante;
        private BOTransformador _BOTransformadorObject;
        private BOCliente _BOClienteObject;

        public event EventHandler TransformadorChange;

        public BuscarTransformador()
        {
            _BOTransformadorObject = new BOTransformador();
            _BOClienteObject = new BOCliente();
        }

        private void ValidarRoles()
        {
            string[] roles = ValidadorRol.ValidarRoles();

            if (roles.Contains(WebConfigurationManager.AppSettings["Cliente"]))
            { }

            if (roles.Contains(WebConfigurationManager.AppSettings["ResponsableCliente"]))
                ActivarControles();

            if (roles.Contains(WebConfigurationManager.AppSettings["ResponsableCliente"]) || roles.Contains(WebConfigurationManager.AppSettings["ResponsableTransformador"]) || roles.Contains(WebConfigurationManager.AppSettings["ResponsableProtocolo"]))
            { }

            else
                DesactivarControles();
        }

        private void ActivarControles()
        {
            this.ddlFabricante.Enabled = true;
            this.txtNumSerie.Enabled = true;
            this.txtNumSerie.ReadOnly = false;
            this.btnBuscarTranformador.Enabled = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["Cliente"] != null)
                    _cliente = (cli_cliente)Session["Cliente"];

                CargarListas();
                ValidarRoles();
            }
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

            this.ddlFabricante.DataSource = _BOClienteObject.ConsultarFabricantes();
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
            //if (_cliente != null)
            //{
            //    lstTransformadoresFabricante = _BOTransformadorObject.ConsultarTransformadoresCliente(_cliente.id);
            //    gvTransformadores.DataSource = lstTransformadoresFabricante;
            //    gvTransformadores.DataBind();
            //    mpeTransformador.Show();
            //}
            //else
            //{
            lstTransformadoresFabricante = _BOTransformadorObject.ConsultarTransformadoresFabricante();
            gvTransformadores.DataSource = lstTransformadoresFabricante;
            gvTransformadores.DataBind();
            mpeTransformador.Show();
            //}
        }

        protected void gvTransformadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idTransformador = Convert.ToInt32(gvTransformadores.DataKeys[gvTransformadores.SelectedRow.RowIndex].Values[0].ToString());
            string numeroSerie = gvTransformadores.DataKeys[gvTransformadores.SelectedRow.RowIndex].Values[1].ToString();
            string idFabricante = gvTransformadores.DataKeys[gvTransformadores.SelectedRow.RowIndex].Values[2].ToString();

            ddlFabricante.SelectedValue = idFabricante;
            txtNumSerie.Text = numeroSerie;
            hfIdTransformador.Value = idTransformador.ToString();

            // Delegate the event to the caller
            if (this.TransformadorChange != null) this.TransformadorChange(sender, e);

            tfr_transformador transformadorObject = _BOTransformadorObject.ConsultarXId(idTransformador) as tfr_transformador;
            Session[VariablesGlobales.SESSION_TRANSFORMADOR] = transformadorObject;
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

        public void ValidationGroupControles(string validationGroup, bool enabled)
        {
            this.rfv_ddlFabricante.ValidationGroup = validationGroup;
            this.rfv_txtNumSerie.ValidationGroup = validationGroup;

            this.rfv_ddlFabricante.Enabled = enabled;
            this.rfv_txtNumSerie.Enabled = enabled;
        }

        public string IdTransformador
        {
            get { return hfIdTransformador.Value; }
        }
    }
}