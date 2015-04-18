﻿using System;
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

namespace TS15V2.UI.APP.componentes
{
    public partial class BuscarTransformador : UIGenericoComponente
    {
        private cli_cliente _cliente;
        private List<tfr_transformador> lstTransformadores;
        private BOTransformador _BOTransformadorObject;
        private BOCliente _BOClienteObject;

        public BuscarTransformador()
        {
            _BOTransformadorObject = new BOTransformador();
            _BOClienteObject = new BOCliente();
            _cliente = (cli_cliente)Session["Cliente"];
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
            if (_cliente != null)
            {
                //lstTransformadores = _BOTransformadorObject.ConsultarTransformadoresCliente(_cliente.id);
                gvTransformadores.DataSource = _BOTransformadorObject.ConsultarTransformadoresCliente(_cliente.id); ;
                gvTransformadores.DataBind();
                mpeTransformador.Show();
            }
        }

        protected void gvTransformadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idCliente = gvTransformadores.DataKeys[gvTransformadores.SelectedRow.RowIndex].Values[0].ToString();
            string nombreCliente = gvTransformadores.DataKeys[gvTransformadores.SelectedRow.RowIndex].Values[1].ToString();


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