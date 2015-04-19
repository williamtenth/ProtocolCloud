using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Configuration;

namespace TS15V2.UI.APP.util
{
    public class ValidadorRol
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        Boolean ValidarRol(string rol)
        {
            return true;
        }

        /// <summary>
        /// Devuelve la lista de roles para el usuario en sesion
        /// </summary>
        /// <returns></returns>
        public string[] ValidarRoles()
        {
            MembershipUser user = Membership.GetUser(true);
            Guid userId = (Guid)user.ProviderUserKey;
            string[] userRoles = Roles.GetRolesForUser(user.UserName);

            return userRoles;
        }
        public static string ROL_CLIENTE = "Cliente";
        public static string ROL_RESPONSABLEBODEGA = "ResponsableBodega";
        public static string ROL_RESPONSABLECLIENTE = "ResponsableCliente";
        public static string ROL_RESPONSABLEPROTOCOLO = "ResponsableProtocolo";
        public static string ROL_RESPONSABLETRANSFORMADOR = "ResponsableTransformador";
        public static string ROL_USUARIO = "Usuario";

        public bool ContieneRol(string rol)
        {
            bool bitRol = false;

            if (ValidarRoles().Contains(WebConfigurationManager.AppSettings[rol]))
                bitRol = true;

            return bitRol;
        }
    }
}