using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS15V2.UI.APP.util;
using TS15V2.UI.APP.componentes;
using System.Web.UI;

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

        public void EnviarAModalMsj(ModalMsj modal)
        {
            modal.TituloModal = "Prueba Titulo";
            modal.MensajeModal = "Este es un menjaje de prueba1";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        public void EnviarAModalMsj(ModalMsj modalMsj, String titulo, String mensaje)
        {
            modalMsj.TituloModal = titulo;
            modalMsj.MensajeModal = mensaje;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }
}