<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="GestorProtocolo.aspx.cs" Inherits="TS15V2.UI.APP.dev.GestionProtocolo.GestorProtocolo"
    EnableSessionState="true" %>

<%@ Register Src="../../componentes/ModalMsj.ascx" TagName="ModalMsj" TagPrefix="uc0" %>
<%@ Register Src="ProtocoloNTC1005.ascx" TagName="ProtocoloNTC1005" TagPrefix="uc1" %>
<%@ Register Src="ProtocoloNTC1031.ascx" TagName="ProtocoloNTC1031" TagPrefix="uc2" %>
<%@ Register Src="ProtocoloNTC1465.ascx" TagName="ProtocoloNTC1465" TagPrefix="uc3" %>
<%@ Register Src="ProtocoloNTC3396.ascx" TagName="ProtocoloNTC3396" TagPrefix="uc4" %>
<%@ Register Src="ProtocoloNTC375.ascx" TagName="ProtocoloNTC375" TagPrefix="uc5" %>
<%@ Register Src="ProtocoloNTC837.ascx" TagName="ProtocoloNTC837" TagPrefix="uc6" %>
<%@ Register Src="ProtocoloNTC471.ascx" TagName="ProtocoloNTC471" TagPrefix="uc7" %>
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
        <li><i class="icon-edit"></i><a href="#">Gestión Protocolo</a> </li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <%--TIPO SOLICITUD--%>
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="ddlFabricante">
                                Solicitud:</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtSolicitud" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="txtSolicitud_RequiredFieldValidator1"
                                    ControlToValidate="txtSolicitud" ErrorMessage="*" ForeColor="red" ValidationGroup="vgCrearSolicitud"></asp:RequiredFieldValidator>
                                <asp:FilteredTextBoxExtender ID="txtSolicitud_FilteredTextBoxExtender" runat="server"
                                    TargetControlID="txtSolicitud" FilterType="Custom, Numbers" ValidChars="0123456789" />
                            </div>
                        </div>
                        <asp:Panel runat="server" ID="pnlCantidad" CssClass="control-group">
                            <label class="control-label" for="txtCantidad">
                                Fabricante :</label>
                            <div class="controls">
                                <asp:TextBox runat="server" Enabled="false" ID="txtFabricante" CssClass="form-control"
                                    MaxLength="80"></asp:TextBox>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlCapacidad" CssClass="control-group">
                            <label class="control-label" for="ddlCapacidad">
                                Número de serie:</label>
                            <div class="controls">
                                <asp:TextBox runat="server" Enabled="false" ID="txtNumSerie" CssClass="form-control"
                                    MaxLength="50"></asp:TextBox>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlVolEntrada" CssClass="control-group">
                            <label class="control-label" for="txtVolEntrada">
                                Resultado pruebas:</label>
                            <div class="controls">
                                <asp:TextBox runat="server" Enabled="false" ID="txtResultado" CssClass="form-control"
                                    MaxLength="30"></asp:TextBox>
                            </div>
                        </asp:Panel>
                        <!--Botonera-->
                        <div class="form-actions">
                            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" OnClick="Buscar"
                                Text="Buscar" />
                            <asp:Panel ID="pnlBotonera" runat="server" Visible="false">
                                <asp:Panel ID="pnlCrear" runat="server" Visible="false">
                                    <asp:Button ID="btnCrear" runat="server" CssClass="btn btn-primary" OnClick="Crear"
                                        Text="Crear" ValidationGroup="vgCrearSolicitud" />
                                </asp:Panel>
                                <asp:Panel ID="pnlEditar" runat="server" Visible="false">
                                    <%--<asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-primary" OnClick="Consultar"
                                        Text="Consultar" />--%>
                                    <asp:Button ID="btnTerminar" runat="server" CssClass="btn btn-primary" OnClick="Terminar"
                                        Text="Terminar" />
                                    <%--<asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-primary" OnClick="Eliminar"
                                        Text="Eliminar" />--%>
                                </asp:Panel>
                            </asp:Panel>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <asp:GridView runat="server" ID="gvPruebas" DataKeyNames="Prueba, Nombre" AutoGenerateColumns="false"
        CssClass="table table-striped" OnRowCommand="Consultar">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:d}" />
            <asp:BoundField DataField="Resultado" HeaderText="Resultado" />
            <asp:TemplateField HeaderText="Consultar">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lbtnConsultar" CommandName="Consultar" CssClass="btn btn-success"
                        ToolTip="Consultar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                            <i class="halflings-icon white zoom-in"></i>
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <SelectedRowStyle Font-Underline="true" Font-Bold="True" ForeColor="#3071A9" />
    </asp:GridView>
    <div class="row-fluid sortable ui-sortable">
        <uc1:ProtocoloNTC1005 ID="ucProtocoloNTC1005" runat="server" Visible="false" />
        <uc2:ProtocoloNTC1031 ID="ucProtocoloNTC1031" runat="server" Visible="false" />
        <uc3:ProtocoloNTC1465 ID="ucProtocoloNTC1465" runat="server" Visible="false" />
        <uc4:ProtocoloNTC3396 ID="ucProtocoloNTC3396" runat="server" Visible="false" />
        <uc5:ProtocoloNTC375 ID="ucProtocoloNTC375" runat="server" Visible="false" />
        <uc6:ProtocoloNTC837 ID="ucProtocoloNTC837" runat="server" Visible="false" />
        <uc7:ProtocoloNTC471 ID="ucProtocoloNTC471" runat="server" Visible="false" />
    </div>
    <uc0:ModalMsj ID="MsjConfirmacion" runat="server" />
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
