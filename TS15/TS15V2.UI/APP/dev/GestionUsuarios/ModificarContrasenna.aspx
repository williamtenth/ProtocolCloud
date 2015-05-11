<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="ModificarContrasenna.aspx.cs" Inherits="TS15V2.UI.APP.dev.GestionUsuarios.ModificarContrasenna" %>

<%@ Register Src="../../componentes/BuscarCliente.ascx" TagName="BuscarCliente" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../componentes/ModalMsj.ascx" TagName="ModalMsj" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- start: Mobile Specific -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- end: Mobile Specific -->
    <!-- start: CSS -->
    <link id="bootstrap-style" href="../../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link id="base-style" href="../../css/style.css" rel="stylesheet" />
    <link id="base-style-responsive" href="../../css/style-responsive.css" rel="stylesheet" />
    <!-- end: CSS -->
    <!-- The HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
	  	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
		<link id="ie-style" href="css/ie.css" rel="stylesheet">
	<![endif]-->
    <!--[if IE 9]>
		<link id="ie9style" href="css/ie9.css" rel="stylesheet">
	<![endif]-->
    <!-- start: Favicon -->
    <link rel="shortcut icon" href="../img/favicon.ico">
    <!-- end: Favicon -->
    <style>
        /************** Modal PopUp *****************************************************************************************************/.cerrar
        {
            float: right;
            margin-right: -30px;
            margin-top: -20px;
            z-index: 20;
        }
        .detalles
        {
            width: 320px;
            margin: auto;
            height: 55px;
            padding-top: 15px; /* background-image: url(../img/bg_detalles.png); background-position: top center; background-repeat: no-repeat;*/
        }
        .detalles p
        {
            font-size: 35px;
            text-align: center;
            font-family: 'Museo' , Arial, sans-serif;
            height: auto;
            margin: auto;
        }
        .modalPopup
        {
            font-size: 10pt;
            border-radius: 10px;
            -ms-border-radius: 10px;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            z-index: 10001;
            padding: 10px 20px;
            width: 500px;
        }
        .modalPopup2
        {
            font-size: 10pt;
            border-radius: 10px;
            -ms-border-radius: 10px;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            z-index: 25;
            padding: 10px 20px;
            width: 600px;
            z-index: 10001 !important;
        }
        .modalBackGround
        {
            background: url(../../img/overlay.png) repeat 0 0;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .modalBackgroundCargando
        {
            background-color: Black;
            filter: alpha(opacity=55);
            opacity: 0.50;
            z-index: 10100 !important;
        }
        .imgFinca
        {
            max-width: 100%;
            max-height: 300px;
        }
        /***********************************************************************************************************************/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="../Home.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><i class="icon-edit"></i><a href="#">Gestionar Cuentas</a> </li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div data-original-title="" class="box-header">
                <h2>
                    <i class="halflings-icon edit"></i><span class="break"></span>Crear Usuario</h2>
                <div class="box-icon">
                    <a class="btn-setting" href="#"><i class="halflings-icon wrench"></i></a><a class="btn-minimize"
                        href="#"><i class="halflings-icon chevron-up"></i></a><a class="btn-close" href="#">
                            <i class="halflings-icon remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/APP/Home.aspx"
                            EnableViewState="false" RenderOuterTable="false" SuccessText="La contraseña ha sido modificada correctamente.">
                            <ChangePasswordTemplate>
                                <span class="failureNotification">
                                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                                </span>
                                <div class="accountInfo">
                                    <fieldset class="changePassword">
                                        <p>
                                            <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Anitgüa Contraseña:</asp:Label>
                                            <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                CssClass="failureNotification" ErrorMessage="*" ToolTip="Old Password is required."
                                                ValidationGroup="ChangeUserPasswordValidationGroup" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                                        </p>
                                        <p>
                                            <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nueva Contraseña:</asp:Label>
                                            <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                CssClass="failureNotification" ErrorMessage="*" ToolTip="New Password is required."
                                                ValidationGroup="ChangeUserPasswordValidationGroup" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                                        </p>
                                        <p>
                                            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirmar Nueva Contraseña:</asp:Label>
                                            <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                CssClass="failureNotification" Display="Dynamic" ErrorMessage="*" ToolTip="Confirm New Password is required."
                                                ValidationGroup="ChangeUserPasswordValidationGroup" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                                ControlToValidate="ConfirmNewPassword" CssClass="failureNotification" Display="Dynamic"
                                                ErrorMessage="*" ValidationGroup="ChangeUserPasswordValidationGroup" ForeColor="Red"
                                                Font-Bold="true"></asp:CompareValidator>
                                        </p>
                                    </fieldset>
                                    <p class="submitButton">
                                        <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                            Text="Cambiar Contraseña" ValidationGroup="ChangeUserPasswordValidationGroup"
                                            CssClass="btn btn-primary" />
                                        <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                            CssClass="btn btn-primary" Text="Cancelar" />
                                    </p>
                                </div>
                            </ChangePasswordTemplate>
                        </asp:ChangePassword>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <uc3:ModalMsj ID="ModalMsj1" runat="server" />
    <!-- start: JavaScript-->
    <script type="text/javascript" src="../../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-migrate-1.0.0.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.10.0.custom.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.touch-punch.js"></script>
    <script type="text/javascript" src="../../js/modernizr.js"></script>
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.cookie.js"></script>
    <script type="text/javascript" src="../../js/fullcalendar.min.js"></script>
    <script type="text/javascript" src='../../js/jquery.dataTables.min.js'></script>
    <script type="text/javascript" src="../../js/excanvas.js"></script>
    <script type="text/javascript" src="../../js/jquery.flot.js"></script>
    <script type="text/javascript" src="../../js/jquery.flot.pie.js"></script>
    <script type="text/javascript" src="../../js/jquery.flot.stack.js"></script>
    <script type="text/javascript" src="../../js/jquery.flot.resize.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.chosen.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.cleditor.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.noty.js"></script>
    <script type="text/javascript" src="../../js/jquery.elfinder.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.raty.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.iphone.toggle.js"></script>
    <script type="text/javascript" src="../../js/jquery.uploadify-3.1.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.gritter.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.imagesloaded.js"></script>
    <script type="text/javascript" src="../../js/jquery.masonry.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.knob.modified.js"></script>
    <script type="text/javascript" src="../../js/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../../js/counter.js"></script>
    <script type="text/javascript" src="../../js/retina.js"></script>
    <script type="text/javascript" src="../../js/custom.js"></script>
    <!-- end: JavaScript-->
</asp:Content>
