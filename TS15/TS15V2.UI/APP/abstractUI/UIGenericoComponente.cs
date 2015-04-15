using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS15V2.UI.APP.util;

namespace TS15V2.UI.APP.abstractUI
{
    public abstract class UIGenericoComponente : System.Web.UI.UserControl, IControlable
    {
        private UISingleton _singletonControlador = UISingleton.GetInstance();
        private ValidadorRol _validadorRol;
        private ValidadorCliente _validadorCliente;

        public UIGenericoComponente()
        {
            _validadorRol = new ValidadorRol();
            _validadorCliente = new ValidadorCliente();
        }

        public UISingleton SingletonControlador
        {
            get { return _singletonControlador; }
            set { _singletonControlador = value; }
        }

        public ValidadorRol ValidadorRol
        {
            get { return _validadorRol; }
            set { _validadorRol = value; }
        }

        public ValidadorCliente ValidadorCliente
        {
            get { return _validadorCliente; }
            set { _validadorCliente = value; }
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