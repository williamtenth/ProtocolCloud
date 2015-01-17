<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TS15.UI.APP.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr" lang="es-CO">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Autenticación de Usuarios</title>
    <!--- CSS --->
    <link href="css/bootstrap-cerulean.min.css" rel="stylesheet" />
    <link href="css/charisma-app.css" rel="stylesheet" />
</head>
<body style="background-image: url('img/bg.jpg')">
    <form id="form1" runat="server">
    <asp:Login runat="server" ID="loginSystem" FailureText="* Por favor valide su nombre de usuario y contraseña."
        FailureTextStyle-Font-Bold="true" FailureTextStyle-ForeColor="Red" DestinationPageUrl="~/APP/systems/Home.aspx">
        <LayoutTemplate>
            <div class="ch-container">
                <div class="row">
                    <div class="row">
                        <div class="col-md-12 center login-header">
                            <h2 style="color: White; font-weight: bolder;">
                                Protocolo Para Transformadores Serie 15Kv
                            </h2>
                        </div>
                        <!--/span-->
                    </div>
                    <!--/row-->
                    <div class="row">
                        <div class="well col-md-5 center login-box">
                            <div class="alert alert-info" style="font-weight: bold;">
                                Por favor ingrese con su nombre de usuario y contraseña.
                            </div>
                            <fieldset>
                                <div class="input-group input-group-lg">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user red"></i></span>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                </div>
                                <div class="clearfix">
                                </div>
                                <br>
                                <div class="input-group input-group-lg">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock red"></i></span>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="Password"
                                        CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="clearfix">
                                </div>
                                <div class="input-prepend">
                                    <!--<label class="remember" for="remember">
                                <input type="checkbox" id="remember">
                                Remember me</label>-->
                                </div>
                                <div class="clearfix">
                                </div>
                                <p class="center col-md-5">
                                    <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-primary" CommandName="Login"
                                        Text="Ingresar" ValidationGroup="loginSystem" />
                                </p>
                                <p class="center col-md-5" style="width: 400px; color: Red">
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="* Por favor ingrese su usuario." ValidationGroup="loginSystem"
                                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="* Por favor ingrese su contraseña." ValidationGroup="loginSystem"
                                        Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                </p>
                            </fieldset>
                        </div>
                        <!--/span-->
                    </div>
                    <!--/row-->
                </div>
                <!--/fluid-row-->
            </div>
        </LayoutTemplate>
        <FailureTextStyle Font-Bold="True"></FailureTextStyle>
    </asp:Login>
    </form>
</body>
</html>
