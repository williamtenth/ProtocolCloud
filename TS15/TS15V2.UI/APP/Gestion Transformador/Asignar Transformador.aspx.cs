using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.BL.Gestion_Transformador;

namespace TS15V2.UI.APP.Gestion_Transformador
{
    public partial class Asignar_Transformador : System.Web.UI.Page
    {
        private int transformador_id;

        public int Transformador_id
        {
            get { return transformador_id; }
            set { transformador_id = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            iniciar(1);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            transformador_id = 1;
            iniciar(transformador_id);
        }

        protected void iniciar(int trafo_id)
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            BOTransformador transforamdorBO = new BOTransformador();

            cli_cliente cliente = (cli_cliente)transforamdorBO.ConsultarClienteXTrafoId(transformador_id, contexto, error);
            txtNumDoc.Text = cliente.numdocumento;
            txtNombre.Text = cliente.nombre;
            txtNumDoc.DataBind();
            txtNombre.DataBind();
        }

        protected void btnRetirar_Click(object sender, EventArgs e)
        {

        }
    }
}