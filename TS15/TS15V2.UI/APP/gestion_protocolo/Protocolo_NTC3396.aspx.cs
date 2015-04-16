using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15V2.UI.APP.util;

namespace TS15V2.UI.APP.gestion_protocolo
{
    public partial class Protocolo_NTC3396 : GenericoProtocolo
    {   
        // Datos
        private List<gen_parametrica> _listaColores;

        // Constructores
        public Protocolo_NTC3396()
        {
            CargarListas();
        }

        // Init
        protected void Page_Load(object sender, EventArgs e)
        {
            Transformador = new tfr_transformador();
            Transformador.id = 1;
        }

        // Métodos

        /// <summary>
        /// Este método carga las listas:
        /// -  los valores de resultado de una prueba.
        /// </summary>
        public void CargarListas()
        {
            _listaColores = Parametros.ConsultarParametros("rtrfcolor");
        }
        

        void Modificar()
        {

        }

        void Guardar()
        {

        }

        void Cancelar()
        {

        }

        public void Terminar()
        {

        }

    }
}