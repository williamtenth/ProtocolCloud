<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="GestionarPedidos.aspx.cs" Inherits="TS15V2.UI.APP.dev.GestionCliente.GestionarPedidos"
    EnableEventValidation="false" %>

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
        <li><i class="icon-edit"></i><a href="#">Gestionar Pedidos</a> </li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <uc1:BuscarCliente ID="ucBusquedaCliente" runat="server" OnClienteChange="ucBusquedaCliente_ClienteChange" />
    </div>
    <asp:Panel runat="server" ID="pnlGrilla" CssClass="row-fluid sortable ui-sortable"
        Visible="false">
        <div class="box span12">
            <div class="box-header">
                <h2>
                    <i class="halflings-icon th"></i><span class="break"></span>Solicitudes</h2>
            </div>
            <div class="box-content">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="gvSolicitudesCliente" DataKeyNames="tipSolicitud,idpedido,transformador_id"
                            AutoGenerateColumns="false" CssClass="table table-bordered table-striped table-condensed" OnRowCommand="gvSolicitudesCliente_RowCommand"
                            OnSelectedIndexChanged="gvSolicitudesCliente_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="consecutivo" HeaderText="Consecutivo" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="fechasolicitud" HeaderText="Fecha" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="tipSolicitud" HeaderText="Tipo Solicitud" />
                                <asp:BoundField DataField="tipoSolicitud" HeaderText="Tipo Solicitud" />
                                <asp:TemplateField HeaderText="Aprobado">
                                    <ItemTemplate>
                                        <%# Eval("aprobado") == null ? " " : (Boolean.Parse(Eval("aprobado").ToString())) ? "Si" : "No"%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField ButtonType="Link" CommandName="Select" Text="Seleccionar" />
                            </Columns>
                            <SelectedRowStyle Font-Underline="true" Font-Bold="True" ForeColor="#3071A9" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Panel runat="server" ID="pnlControles" Visible="false">
                            <div class="form-horizontal">
                                <fieldset>
                                    <asp:Panel runat="server" ID="pnlFabricante" CssClass="control-group" Visible="false">
                                        <label class="control-label" for="txtFabricante">
                                            Fabricante:</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtFabricante" CssClass="form-control" MaxLength="20"
                                                Enabled="false" Visible="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_txtFabricante" ControlToValidate="txtFabricante"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarCliente"></asp:RequiredFieldValidator>
                                            <asp:HiddenField runat="server" ID="hfIdFabricante" />
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlNumeroSerie" CssClass="control-group" Visible="false">
                                        <label class="control-label" for="txtNumeroSerie">
                                            Número de Serie:</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtNumeroSerie" CssClass="form-control" MaxLength="20"
                                                Enabled="false" Visible="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_txtNumeroSerie" ControlToValidate="txtNumeroSerie"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarCliente"></asp:RequiredFieldValidator>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlCantidad" CssClass="control-group" Visible="false">
                                        <label class="control-label" for="txtCantidad">
                                            Cantidad:</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" MaxLength="20"
                                                Enabled="false" Visible="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_txtCantidad" ControlToValidate="txtCantidad"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarSolicitud"></asp:RequiredFieldValidator>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlCapacidad" CssClass="control-group" Visible="false">
                                        <label class="control-label" for="ddlCapacidad">
                                            Capacidad:</label>
                                        <div class="controls">
                                            <asp:DropDownList runat="server" ID="ddlCapacidad" CssClass="form-control" OnDataBound="ddlCapacidad_DataBound"
                                                Enabled="false" Visible="false">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_ddlCapacidad" ControlToValidate="ddlCapacidad"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarSolicitud" InitialValue="-1"></asp:RequiredFieldValidator>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlVolEntrada" CssClass="control-group" Visible="false">
                                        <label class="control-label" for="txtVolEntrada">
                                            Voltaje Entrada:</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtVolEntrada" CssClass="form-control" MaxLength="20"
                                                Enabled="false" Visible="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_txtVolEntrada" ControlToValidate="txtVolEntrada"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarSolicitud"></asp:RequiredFieldValidator>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlVolSalida" CssClass="control-group" Visible="false">
                                        <label class="control-label" for="txtVolSalida">
                                            Voltaje Salida:</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtVolSalida" CssClass="form-control" MaxLength="20"
                                                Enabled="false" Visible="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_txtVolSalida" ControlToValidate="txtVolSalida"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarSolicitud"></asp:RequiredFieldValidator>
                                            <asp:HiddenField runat="server" ID="hfIdPedido" />
                                            <asp:HiddenField runat="server" ID="hfTipoSolicitud" />
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlAprobado" CssClass="control-group" Visible="false">
                                        <label class="control-label" for="txtVolSalida">
                                            Aprobado:</label>
                                        <div class="controls">
                                            <asp:DropDownList runat="server" ID="ddlAprobado" Enabled="false">
                                                <asp:ListItem Text="--Seleccione--" Value="-1">
                                                </asp:ListItem>
                                                <asp:ListItem Text="Si" Value="True">
                                                </asp:ListItem>
                                                <asp:ListItem Text="No" Value="False">
                                                </asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_ddlAprobado" ControlToValidate="ddlAprobado"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarSolicitud" InitialValue="-1"></asp:RequiredFieldValidator>
                                        </div>
                                    </asp:Panel>
                                </fieldset>
                                <div class="form-actions">
                                    <asp:Button ID="btnModificarSolicitud" runat="server" CssClass="btn btn-primary"
                                        Text="Modificar" OnClick="btnModificarSolicitud_Click" />
                                    <asp:Button ID="btnEliminarSolicitud" runat="server" CssClass="btn btn-primary" Text="Eliminar"
                                        OnClick="btnEliminarSolicitud_Click" />
                                    <asp:Button ID="btnBuscarSolicitud" runat="server" CssClass="btn btn-primary" Text="Buscar"
                                        OnClick="btnBuscarSolicitud_Click" />
                                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar"
                                        OnClick="btnGuardar_Click" Visible="false" ValidationGroup="vgGuardarSolicitud"
                                        CausesValidation="true" />
                                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-primary" Text="Cancelar"
                                        OnClick="btnCancelar_Click" Visible="false" />
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>
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
