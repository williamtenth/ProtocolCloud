using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TS15V2.UI.APP.util
{
    public class ValidadorRol
    {
        private string[] roles;


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
    }
}