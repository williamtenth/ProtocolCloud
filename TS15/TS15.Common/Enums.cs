using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace TS15.Common
{
    public class Enums
    {
        public enum Roles
        {
            [EnumMember(Value = "Administrador Sistema")]
            AdministradorSistema,
            [EnumMember(Value = "Cliente")]
            Cliente,
            [EnumMember(Value = "Responsable Bodega")]
            ResponsableBodega,
            [EnumMember(Value = "Responsable Cliente")]
            ResponsableCliente,
            [EnumMember(Value = "Responsable Protocolo")]
            ResponsableProtocolo,
            [EnumMember(Value = "Responsable Transformador")]
            ResponsableTransformador,
            [EnumMember(Value = "Usuario")]
            Usuario
        }
    }
}
