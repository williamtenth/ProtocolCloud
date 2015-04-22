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
        private BOProtocolo_NTC3396 _BOntc3396Object;
        private pro_ntc3396 _prueba;

        // Constructores
        public ProtocoloNTC3396()
        {
            _BOntc3396Object = new BOProtocolo_NTC3396();
            CargarListas();
            CargarPrueba();
        }

        // Init
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = Transformador.numserie;
        }

        // Métodos

        /// <summary>
        /// Este método carga las listas:
        /// -  los valores de resultado de una prueba.
        /// </summary>
        public void CargarListas()
        {
            _listaColores = Parametros.ConsultarParametros("rtrfcolor");
            Console.Out.Write("Colores: " + _listaColores.Count);
        }


        public void Modificar(object sender, EventArgs e)
        {
            ActivarControles(true);

        }

        public void Guardar(object sender, EventArgs e)
        {
            _prueba.espesorvalor = Decimal.Parse(txtEspesor.Text);
            
        }

        public void Cancelar(object sender, EventArgs e)
        {
            ActivarControles(false);
        }

        public void Terminar(object sender, EventArgs e)
        {
            if (!_BOntc3396Object.Terminar(_prueba))
                Console.Out.Write("Error al Terminar Prueba");
        }

        public void ActivarControles(Boolean valorEnable){
            this.lbColor.Enabled = valorEnable;
            this.lbEspesor1.Enabled = valorEnable;
            this.lbEspesor2.Enabled = valorEnable;
            this.lbImpacto.Enabled = valorEnable;
            this.lbSalina1.Enabled = valorEnable;
            this.lbSalina2.Enabled = valorEnable;
            this.txtAdherencia.Enabled = valorEnable;
            this.txtEspesor.Enabled = valorEnable;
            pnlInicial.Visible = !valorEnable;
            pnlGuardar.Visible = valorEnable;
        }

        public override void CargarPrueba()
        {
            if (Transformador != null)
            {
                _prueba = (pro_ntc3396)_BOntc3396Object.ObtenerUltimaPrueba(Transformador);
            }
            else
            {
                _prueba = new pro_ntc3396();
                _prueba.fecha = new DateTime();
            }
        }
    }
}