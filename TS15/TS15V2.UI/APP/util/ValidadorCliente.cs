﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TS15.BL.gestion_cliente;
using TS15.Common.Generated;
using TS15.Common.RawObjects;

namespace TS15V2.UI.APP.util
{
    public class ValidadorCliente
    {
        public vw_cli_usuario ValidarCliente(RawError error)
        {
            MembershipUser user = Membership.GetUser(true);
            Guid userID = (Guid)user.ProviderUserKey;
            BOCliente clienteBO = new BOCliente();

            return clienteBO.ConsultarClienteUser(userID);
        }
    }
}