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
        private tfr_transformador _transformador;

        public tfr_transformador _Transformador
        {
            get { return _transformador; }
            set { _transformador = value; }
        }

        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            iniciar(1);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            _transformador.id = 1;
            iniciar(_transformador.id);
        }

        protected void iniciar(int trafo_id)
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            BOTransformador transforamdorBO = new BOTransformador();

            cli_cliente cliente = (cli_cliente)transforamdorBO.ConsultarClienteXTrafoId(trafo_id, contexto, error);
            txtNumDoc.Text = cliente.numdocumento;
            txtNombre.Text = cliente.nombre;
            txtNumDoc.DataBind();
            txtNombre.DataBind();
        }

        protected void btnRetirar_Click(object sender, EventArgs e)
        {
            dbTS15Entities contexto = new dbTS15Entities();
            RawError error = new RawError();
            BOTransformador transforamdorBO = new BOTransformador();

            transforamdorBO.RetirarTranfoDeCliente(_transformador.id, contexto, error);
        }
    }
}