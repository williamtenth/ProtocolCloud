using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TS15V2.UI.APP.abstractUI
{
    public class ControladorComponentes : System.Web.UI.UserControl, IControlable
    {
        private SingletonControlador _singletonControlador = SingletonControlador.GetInstance();
        private ValidadorRol _validadorRol;
        private ValidadorCliente _validadorCliente;

        public ValidadorCliente ValidadorCliente
        {
            get { return _validadorCliente; }
            set { _validadorCliente = value; }
        }

        public ControladorComponentes()
        {
            
            _validadorRol = new ValidadorRol();
        }

        public SingletonControlador SingletonControlador
        {
            get { return _singletonControlador; }
            set { _singletonControlador = value; }
        }

        public ValidadorRol ValidadorRol
        {
            get { return _validadorRol; }
            set { _validadorRol = value; }
        }


        public void ActivarControles()
        {
            throw new NotImplementedException();
        }

        public void DesactivarControles()
        {
            throw new NotImplementedException();
        }


        public void CargarListas()
        {
            throw new NotImplementedException();
        }
    }
}