using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15.Common.Generated;
using TS15.BL.gestion_protocolo;
using TS15V2.UI.APP.util;

namespace TS15V2.UI.APP.dev.GestionProtocolo
{
    public partial class ProtocoloNTC3396 : GenericoProtocolo
    {
         // Datos
        private List<gen_parametrica> _listaColores;
        private BOProtocolo_NTC3396 _BObject;

        // Constructores
        public ProtocoloNTC3396()
        {
            CargarListas();
            _BObject = new BOProtocolo_NTC3396();
            Transformador = new tfr_transformador();
            Transformador.id = 1;
        }

        // Init
        protected void Page_Load(object sender, EventArgs e)
        {
            
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