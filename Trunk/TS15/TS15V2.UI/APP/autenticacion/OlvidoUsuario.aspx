<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OlvidoUsuario.aspx.cs"
    Inherits="TS15.UI.APP.OlvidoUsuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Recuperar Contraseña</title>
    <!--- CSS --->
    <link rel="Stylesheet" href="../css/loginStyle.css" type="text/css" />
    <!--- Javascript libraries (jQuery and Selectivizr) used for the custom checkbox --->
    <!--[if (gte IE 6)&(lte IE 8)]>
		<script type="text/javascript" src="jquery-1.7.1.min.js"></script>
		<script type="text/javascript" src="selectivizr.js"></script>
		<noscript><link rel="stylesheet" href="fallback.css" /></noscript>
	<![endif]-->
</head>
<body>
    <div id="container">
        <form id="form1" runat="server" class="passRecovery">
        <div>
            <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
                <UserNameTemplate>
                    <div class="login">
                        RECUPERACIÓN DE CONTRASEÑA</div>
                    <div class="username-text">
                        Correo Electronico:<asp:RequiredFieldValidator ID="UserNameRequired" runat="server"
                            ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required."
                            ValidationGroup="PasswordRecovery1" ForeColor="Red" Font-Bold="true" Font-Size="16px">*</asp:RequiredFieldValidator></div>
                    <div class="mail-field">
                        <%--<input type="text" name="username" />--%>
                        <asp:TextBox ID="UserName" runat="server" Width="350px"></asp:TextBox>
                    </div>
                    <div class="error-login">
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </div>
                    <div class="volver">
                        <a href="Index.aspx">Regresar</Regresar></a></div>
                    <!--<input type="checkbox" name="remember-me" id="remember-me" /><label for="remember-me">Recordarme</label>-->
                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="ENVIAR" ValidationGroup="PasswordRecovery1"
                        CssClass="enviar-pass-recovery" />
                    <%--<input type="submit" name="submit" value="INGRESAR" />--%>
                </UserNameTemplate>
            </asp:PasswordRecovery>
        </div>
        <div id="footer">
            <!--Web 2.0 Login Form by <a href="http://azmind.com">Azmind.com</a> - <a href="http://azmind.com/2012/01/15/create-a-clean-web-2-0-login-form-part-2-html-css/">
            Download it here!</a>-->
        </div>
        </form>
    </div>
</body>
</html>
