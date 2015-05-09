using TS15.Common.Generated;
using TS15V2.UI.APP.abstractUI;
using TS15V2.UI.APP.util;
using System.Collections.Generic;
using System;
using System.Data.Objects.DataClasses;
using TS15.BL.gestion_transformador;
using TS15.Common.util;

namespace TS15V2.UI.APP.dev.GestionProtocolo
{
    public abstract class GenericoProtocoloComponente : UIGenericoComponente
    {
        // Datos
        private List<gen_parametrica> _listaParResultados;
        private cli_pedido _pedido;
        private pro_proceso _proceso;
        private tfr_transformador _transformador;
        // BO
        private BOTransformador _BOTransformadorObjet;

        // Constructores
        public GenericoProtocoloComponente()
        {
            _proceso = new pro_proceso();
            _BOTransformadorObjet = new BOTransformador();
            //CargarTransformador();
            //CargarListas();
        }

        // Métodos
        public void CargarSesion()
        {
            _pedido = (cli_pedido)Session[VariablesGlobales.SESION_CLIENTE_PEDIDO];
            _proceso = (pro_proceso)Session[VariablesGlobales.SESION_PROCESO_PRUEBA];
            _transformador = (tfr_transformador)Session[VariablesGlobales.SESSION_TRANSFORMADOR];

        }

        public abstract void CargarPrueba();

        /// <summary>
        /// Este método carga las listas:
        /// -  los valores de resultado de pruebas.
        /// </summary>
        public void CargarListas()
        {
            _listaParResultados = Parametros.ConsultarParametros(VariablesGlobales.GEN_PARAMETRICA_RESULTADO);
        }

        // Métodos
        protected void Page_Init(object sender, EventArgs e)
        {
            CargarListas();
            if (!Page.IsPostBack)
            {
                CargarSesion();
            }
            
        }

        // Set y Get
        public List<gen_parametrica> ListaParResultados
        {
            get
            {
                if (_listaParResultados == null)
                    Console.Write("Lista de paramétrica vacía. No existen valores para 'resultado'");
                return _listaParResultados;
            }
            set { _listaParResultados = value; }
        }

        public TS15.Common.Generated.pro_proceso Proceso
        {
            get { return _proceso; }
            set { _proceso = value; }
        }

        public TS15.Common.Generated.tfr_transformador Transformador
        {
            get { return _transformador; }
            set { _transformador = value; }
        }

        public TS15.Common.Generated.cli_pedido Pedido
        {
            get { return _pedido; }
            set { _pedido = value; }
        }
    }
}