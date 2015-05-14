using System;
using System.Web.UI;
using TS15V2.UI.APP.util;
using TS15V2.UI.APP.componentes;

namespace TS15V2.UI.APP.abstractUI
{
    public abstract class UIGenericoPagina : System.Web.UI.Page, IControlable
    {
        private UISingleton _singletonControlador = UISingleton.GetInstance();
        private ValidadorRol _validadorRol;
        private ValidadorCliente _validadorCliente;
        private Boolean _enable;

        public UIGenericoPagina()
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
            //throw new NotImplementedException();
        }

        public void DesactivarControles()
        {
            //throw new NotImplementedException();
        }

        public void CargarListas()
        {
            //throw new NotImplementedException();
        }

        public Boolean Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        public void EnviarAModalMsj(ModalMsj modalMsj, String titulo, String mensaje)
        {
            modalMsj.TituloModal = titulo;
            modalMsj.MensajeModal = mensaje;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
                
    }
}
