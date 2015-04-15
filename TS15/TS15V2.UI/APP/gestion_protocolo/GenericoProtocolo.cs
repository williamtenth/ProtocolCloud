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

namespace TS15V2.UI.APP.gestion_protocolo
{
	public abstract class GenericoProtocolo : UIGenericoPagina, IGestionable, ITerminable {

        // Datos
        private List<gen_parametrica> _listaParResultados;
        private pro_proceso _proceso;
        private tfr_transformador _transformador;

        // Constructores
        public GenericoProtocolo(){
            _proceso = new pro_proceso();
            _transformador = new tfr_transformador();
            CargarListas();
		}

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
            get {
                if (_listaParResultados == null)
                    Console.Write("Lista de param�trica vac�a. No existen valores para 'resultado'");
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


        public void Terminar()
        {
            throw new NotImplementedException();
        }

        public void Crear()
        {
            throw new NotImplementedException();
        }

        public void Eliminar()
        {
            throw new NotImplementedException();
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public void Cancelar()
        {
            throw new NotImplementedException();
        }
    }//end GenericoProtocolo

}//end namespace gestion_protocolo