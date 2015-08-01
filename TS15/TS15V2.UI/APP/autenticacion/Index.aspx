<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TS15.UI.APP.Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" dir="ltr" lang="es-CO">
<head runat="server">
    <!--
        ===
        This comment should NOT be removed.

        Charisma v2.0.0

        Copyright 2012-2014 Muhammad Usman
        Licensed under the Apache License v2.0
        http://www.apache.org/licenses/LICENSE-2.0

        http://usman.it
        http://twitter.com/halalit_usman
        ===
    -->
    <meta charset="utf-8">
    <title>Autenticación de Usuarios</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="Charisma, a fully featured, responsive, HTML5, Bootstrap admin template.">
    <meta name="author" content="Muhammad Usman">
    <!-- The styles -->
    <link href="css/bootstrap-cerulean.min.css" rel="stylesheet">
    <link href="css/charisma-app.css" rel="stylesheet">
    <%--<link href='bower_components/fullcalendar/dist/fullcalendar.css' rel='stylesheet'>
    <link href='bower_components/fullcalendar/dist/fullcalendar.print.css' rel='stylesheet'
        media='print'>
    <link href='bower_components/chosen/chosen.min.css' rel='stylesheet'>
    <link href='bower_components/colorbox/example3/colorbox.css' rel='stylesheet'>
    <link href='bower_components/responsive-tables/responsive-tables.css' rel='stylesheet'>
    <link href='bower_components/bootstrap-tour/build/css/bootstrap-tour.min.css' rel='stylesheet'>--%>
    <link href='css/jquery.noty.css' rel='stylesheet'>
    <link href='css/noty_theme_default.css' rel='stylesheet'>
    <link href='css/elfinder.min.css' rel='stylesheet'>
    <link href='css/elfinder.theme.css' rel='stylesheet'>
    <link href='css/jquery.iphone.toggle.css' rel='stylesheet'>
    <link href='css/uploadify.css' rel='stylesheet'>
    <link href='css/animate.min.css' rel='stylesheet'>
    <!-- jQuery -->
    <%--<script src="bower_components/jquery/jquery.min.js"></script>--%>
    <!-- The HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
    <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->
    <!-- The fav icon -->
    <link rel="shortcut icon" href="img/favicon.ico">
</head>
<body style="background-image: url('../img/bg.jpg')">
    <form id="form1" runat="server">
        <asp:Login runat="server" ID="loginSystem" FailureText="* Por favor valide su nombre de usuario y contraseña."
            FailureTextStyle-Font-Bold="true" FailureTextStyle-ForeColor="Red" DestinationPageUrl="~/APP/Home.aspx" align="center">
            <LayoutTemplate>
                <div class="ch-container">
                    <div class="row">
                        <div class="row">
                            <div class="col-md-12 center login-header">
                                <h2 style="color: White; font-weight: bolder;">Protocolo de Pruebas Transformadores Serie 15Kv
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
