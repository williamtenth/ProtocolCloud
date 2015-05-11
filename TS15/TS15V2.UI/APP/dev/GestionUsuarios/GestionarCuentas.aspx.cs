using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TS15V2.UI.APP.abstractUI;
using TS15.BL.gestion_cliente;
using System.Web.Security;

namespace TS15V2.UI.APP.dev.GestionUsuarios
{
    public partial class GestionarCuentas : UIGenericoPagina
    {
        private BOCliente _BOCliente;
        const string passwordQuestion = "What is your favorite color.";

        public GestionarCuentas()
        {
            _BOCliente = new BOCliente();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CargarListasGestionUsuarios();
        }

        private void CargarListasGestionUsuarios()
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            this.ddlCliente.DataSource = _BOCliente.Consultar();
            this.ddlCliente.DataTextField = "nombre";
            this.ddlCliente.DataValueField = "id";
            this.ddlCliente.DataBind();
        }

        protected void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus createStatus;
            string answer = "blue";

            MembershipUser newUser = Membership.CreateUser(this.txtNombreUsuario.Text.Trim(), this.txtPass.Text.Trim(), this.txtMail.Text.Trim(), passwordQuestion, answer, true, out createStatus);

            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                    //CreateAccountResults.Text = "The user account was successfully created!";
                    EnviarAModalMsj(ModalMsj1, "Cuentas de Usuario", "Se ha creado correctamente la cuenta del usuario.");
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    //CreateAccountResults.Text = "There already exists a user with this username.";
                    EnviarAModalMsj(ModalMsj1, "Cuentas de Usuario", "Ya existe un usuario creado con el nombre registrado.");
                    break;

                case MembershipCreateStatus.DuplicateEmail:
                    //CreateAccountResults.Text = "There already exists a user with this email address.";
                    EnviarAModalMsj(ModalMsj1, "Cuentas de Usuario", "Ya existe un usuario creado con el E-Mail registrado.");
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    //CreateAccountResults.Text = "There email address you provided in invalid.";
                    EnviarAModalMsj(ModalMsj1, "Cuentas de Usuario", "El E-Mail registrado no es valido.");
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    //CreateAccountResults.Text = "There security answer was invalid.";
                    EnviarAModalMsj(ModalMsj1, "Cuentas de Usuario", "La pregunta d eseguridad es invalida.");
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    //CreateAccountResults.Text = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.";
                    EnviarAModalMsj(ModalMsj1, "Cuentas de Usuario", "La contraseña ingresada no es valida, debe contener al menos 7 caracteres alfanumericos.");

                    break;
                default:
                    //CreateAccountResults.Text = "There was an unknown error; the user account was NOT created.";
                    EnviarAModalMsj(ModalMsj1, "Cuentas de Usuario", "Ha ocurrdio un error, la cuenta del usuario no ha sido creada.");
                    break;
            }
        }

        protected void ddlCliente_DataBound(object sender, EventArgs e)
        {
            this.ddlCliente.Items.Insert(0, new ListItem("--Seleccione--", "-1"));
        }
    }
}