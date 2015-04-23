///////////////////////////////////////////////////////////
//  GenericoProtocolo.cs
//  Implementation of the Class GenericoProtocolo
//  Generated by Enterprise Architect
//  Created on:      14-abr.-2015 10:48:21 a. m.
//  Original author: william_cuadros
///////////////////////////////////////////////////////////

using TS15.Common.Generated;
using TS15V2.UI.APP.abstractUI;
using TS15V2.UI.APP.util;
using System.Collections.Generic;
using System;
using System.Data.Objects.DataClasses;
using TS15.BL.gestion_transformador;

namespace TS15V2.UI.APP.dev.GestionProtocolo
{
    public abstract class GenericoProtocolo : UIGenericoPagina, IGestionable, ITerminable
    {

        // Datos
        private List<gen_parametrica> _listaParResultados;
        private pro_proceso _proceso;
        private tfr_transformador _transformador;
        // BO
        private BOTransformador _BOTransformadorObjet;

        // Constructores
        public GenericoProtocolo()
        {
            _proceso = new pro_proceso();
            _BOTransformadorObjet = new BOTransformador();
            //CargarTransformador();
            CargarListas();
        }

        private void CargarTransformador()
        {
            if (Session[VariablesGlobales.SESSION_TRANSFORMADOR] != null)
            {
                _transformador = (tfr_transformador)Session[VariablesGlobales.SESSION_TRANSFORMADOR];

            }
            else
            {
                _transformador = (tfr_transformador)_BOTransformadorObjet.ConsultarXId(1);
            }

            _transformador = (tfr_transformador)_BOTransformadorObjet.ConsultarXId(0);

        }

        public abstract void CargarPrueba();

        // M�todos
        /// <summary>
        /// Este m�todo carga las listas:
        /// -  los valores de resultado de pruebas.
        /// </summary>
        public void CargarListas()
        {
            _listaParResultados = Parametros.ConsultarParametros("resultado");
        }

        // M�todos Set & Get
        public List<gen_parametrica> ListaParResultados
        {
            get
            {
                if (_listaParResultados == null)
                    Console.Write("Lista de param�trica vac�a. No existen valores para 'resultado'");
                return _listaParResultados;
            }
            set { _listaParResultados = value; }
        }

        public void Terminar(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Crear(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Modificar(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Guardar(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Cancelar(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        // Set y Get
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

        protected void Page_Init(object sender, EventArgs e)
        {
            CargarTransformador();
        }

    }//end GenericoProtocolo

}//end namespace gestion_protocolo