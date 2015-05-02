﻿<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="ProtocoloNTC1005.aspx.cs" Inherits="TS15V2.UI.APP.dev.GestionProtocolo.ProtocoloNTC1005"
    EnableSessionState="True" %>

<%@ Register Src="../../componentes/ModalMsj.ascx" TagName="ModalMsj" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <link rel="shortcut icon" href="../../img/favicon.ico">
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
        <li><i class="icon-home"></i><a href="../../Home.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><i class="icon-edit"></i><a href="#">Prueba NTC 3396</a> </li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2>
                    <i class="halflings-icon edit"></i><span class="break"></span>Medición de cortocircuito</h2>
                <%--<div class="box-icon">
                    <a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a><a href="#"
                        class="btn-minimize"><i class="halflings-icon chevron-up"></i></a><a href="#" class="btn-close">
                            <i class="halflings-icon remove"></i></a>
                </div>--%>
            </div>
            <div class="box-content">
                <!--Encabezado-->
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            Icc*
                        </label>
                        <asp:TextBox runat="server" ID="txtIcc" CssClass="form-control" Enabled="false" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtIcc_MaskedEditExtender0" runat="server" TargetControlID="txtIcc"
                            Mask="99999999.99" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            Ucc*
                        </label>
                        <asp:TextBox runat="server" ID="txtUcc" CssClass="form-control" Enabled="false" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtUcc_MaskedEditExtender1" runat="server" TargetControlID="txtUcc"
                            Mask="99999999.99" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            Resultado*
                        </label>
                        <asp:DropDownList ID="lbResultado" runat="server" Enabled="False" OnDataBound="IniciarComponenteLista">
                        </asp:DropDownList>
                        &nbsp;</div>
                </div>
                <!--Detalle de Perdidas-->
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            Perdidas a 24 °C*
                        </label>
                        <asp:TextBox runat="server" ID="txtPerdidas24" CssClass="form-control" Enabled="false" MaxLength="18"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtPerdidas24_MaskedEditExtender2" runat="server" TargetControlID="txtPerdidas24"
                            Mask="9999999999999999.99" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            Perdidas a 85 °C*
                        </label>
                        <asp:TextBox runat="server" ID="txtPerdidas85" CssClass="form-control" Enabled="false" MaxLength="18"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtPerdidas85_MaskedEditExtender1" runat="server" TargetControlID="txtPerdidas85"
                            Mask="9999999999999999.99" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            Perdidas Garantizadas*
                        </label>
                        <asp:TextBox runat="server" ID="txtPerdidasGarantizadas" CssClass="form-control" Enabled="false" MaxLength="18"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtPerdidasGarantizadas_MaskedEditExtender1" runat="server" TargetControlID="txtPerdidasGarantizadas"
                            Mask="9999999999999999.99" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <!--Detalle de I2r-->
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            I2R a 24 °C*
                        </label>
                        <asp:TextBox runat="server" ID="txtI2R24" CssClass="form-control" Enabled="false" MaxLength="18"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtI2R24_MaskedEditExtender1" runat="server" TargetControlID="txtI2R24"
                            Mask="9999999999999999.99" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            I2R a 24 °C*
                        </label>
                        <asp:TextBox runat="server" ID="txtI2R85" CssClass="form-control" Enabled="false" MaxLength="18"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtI2R85_MaskedEditExtender2" runat="server" TargetControlID="txtI2R85"
                            Mask="9999999999999999.99" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            I2R Garantizadas
                        </label>
                        <asp:TextBox runat="server" ID="txtI2RGarantizadas" CssClass="form-control" Enabled="false" MaxLength="18"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtI2RGarantizadas_MaskedEditExtender3" runat="server" TargetControlID="txtI2RGarantizadas"
                            Mask="9999999999999999.99" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <!--Impedancia-->
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            Impedancia a 24 °C*
                        </label>
                        <asp:TextBox runat="server" ID="txtImpedancia24" CssClass="form-control" Enabled="false" MaxLength="18"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtImpedancia24_MaskedEditExtender1" runat="server" TargetControlID="txtImpedancia24"
                            Mask="99.999" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            Impedancia a 85 °C*
                        </label>
                        <asp:TextBox runat="server" ID="txtImpedancia85" CssClass="form-control" Enabled="false" MaxLength="18"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtImpedancia85_MaskedEditExtender1" runat="server" TargetControlID="txtImpedancia85"
                            Mask="99.999" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            Impedancia Garantizada*
                        </label>
                        <asp:TextBox runat="server" ID="txtImpedanciaGarantizadas" CssClass="form-control" Enabled="false" MaxLength="18"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtImpedanciaGarantizadas_MaskedEditExtender2" runat="server" TargetControlID="txtImpedanciaGarantizadas"
                            Mask="99.999" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <!--Regulación y eficiencia-->
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            Regulación a plena carga*
                        </label>
                        <asp:TextBox runat="server" ID="txtRegulacion" CssClass="form-control" Enabled="false" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtRegulacion_MaskedEditExtender3" runat="server" TargetControlID="txtRegulacion"
                            Mask="999999.9999" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            F.P*
                        </label>
                        <asp:TextBox runat="server" ID="txtRegFP" CssClass="form-control" Enabled="false" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtRegFP_MaskedEditExtender4" runat="server" TargetControlID="txtRegFP"
                            Mask="0.99" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            Eficiencia a plena carga*
                        </label>
                        <asp:TextBox runat="server" ID="txtEficiencia" CssClass="form-control" Enabled="false" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtEficiencia_MaskedEditExtender3" runat="server" TargetControlID="txtEficiencia"
                            Mask="999999.9999" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span3">
                        <label>
                            F.P*
                        </label>
                        <asp:TextBox runat="server" ID="txtEfiFP" CssClass="form-control" Enabled="false" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtEfiFP_MaskedEditExtender4" runat="server" TargetControlID="txtEfiFP"
                            Mask="0.99" OnFocusCssClass="MaskedEditFocus"
                            MaskType="Number" InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <!--Botonera-->
                <div class="row-fluid">
                    <asp:Panel ID="pnlBotonera" runat="server">
                        <asp:Panel ID="pnlInicial" runat="server">
                            <asp:Button ID="btModificar" runat="server" Text="Modificar" class="btn btn-success"
                                OnClick="Modificar" />
                            <asp:Button ID="btTerminar" runat="server" Text="Terminar" class="btn btn-success"
                                OnClick="Terminar" />
                        </asp:Panel>
                        <asp:Panel ID="pnlGuardar" Visible="false" runat="server">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success"
                                OnClick="Guardar" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-success"
                                OnClick="Cancelar" />
                        </asp:Panel>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <uc3:ModalMsj ID="MsjConfirmacion" runat="server" />
    <!-- start: JavaScript-->
    <script type="text/javascript" src="../../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-migrate-1.0.0.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui-1.10.0.custom.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.ui.touch-punch.js"></script>
    <script type="text/javascript" src="../../js/modernizr.js"></script>
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.cookie.js"></script>
    <script type="text/javascript" src='../../js/fullcalendar.min.js'></script>
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
