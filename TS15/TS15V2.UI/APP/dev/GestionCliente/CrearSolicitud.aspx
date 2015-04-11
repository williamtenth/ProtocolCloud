<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="CrearSolicitud.aspx.cs" Inherits="TS15V2.UI.APP.dev.GestionCliente.CrearSolicitud" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../componentes/BuscarCliente.ascx" TagName="BuscarCliente" TagPrefix="uc1" %>
<%@ Register Src="../../componentes/BuscarTransformador.ascx" TagName="BuscarTransformador"
    TagPrefix="uc2" %>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="../Home.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><i class="icon-edit"></i><a href="#">Crear Solicitud</a> </li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <uc1:BuscarCliente ID="ucBusquedaCliente" runat="server" />
    </div>
    <div class="row-fluid sortable ui-sortable">
        <uc2:BuscarTransformador ID="ucBusquedaTransformador" runat="server" />
    </div>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <%--TIPO SOLICITUD--%>
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <div class="span5">
                            <div class="control-group">
                                <label class="control-label" for="ddlFabricante">
                                    Tipo de Solicitud:</label>
                                <div class="controls">
                                    <asp:DropDownList runat="server" ID="ddlTipoSolicitud" CssClass="form-control" OnDataBound="ddlTipoSolicitud_DataBound"
                                        OnSelectedIndexChanged="ddlTipoSolicitud_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
            <%--SUMINISTRO--%>
            <%--<div class="box-content">
                <asp:Panel runat="server" ID="pnlSuministro" CssClass="form-horizontal" Visible="false">
                    <fieldset>
                        <div class="span5">
                            <div class="control-group">
                                <label class="control-label" for="ddlFabricante">
                                    Fabricante:</label>
                                <div class="controls">
                                    <asp:DropDownList runat="server" ID="ddlFabricante" CssClass="form-control" OnDataBound="ddlFabricante_DataBound">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="span5">
                            <div class="control-group">
                                <label class="control-label" for="txtNumeroSerie">
                                    Número de Serie:</label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtNumeroSerie" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="span2">
                            <asp:Button runat="server" ID="btnBuscarTransformador" CssClass="btn btn-success"
                                Text="Buscar" />
                        </div>
                    </fieldset>
                </asp:Panel>
            </div>--%>
            <%--SERVICIO--%>
            <div class="box-content">
                <asp:Panel runat="server" ID="pnlServicio" CssClass="form-horizontal" Visible="false">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="txtCantidad">
                                Cantidad:</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="ddlTipoTransformador">
                                Fase:</label>
                            <div class="controls">
                                <asp:DropDownList runat="server" ID="ddlTipoTransformador" CssClass="form-control"
                                    OnDataBound="ddlTipoTransformador_DataBound">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="ddlCapacidad">
                                Capacidad:</label>
                            <div class="controls">
                                <asp:DropDownList runat="server" ID="ddlCapacidad" CssClass="form-control" OnDataBound="ddlCapacidad_DataBound">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtVolEntrada">
                                Voltaje de Entrada:</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtVolEntrada" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtVolSalida">
                                Voltaje de Salida:</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtVolSalida" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                </asp:Panel>
            </div>
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <div class="form-actions">
                            <asp:Button ID="btnCrearSolicitud" runat="server" CssClass="btn btn-primary" Text="Crear Solicitud"
                                OnClick="btnCrearSolicitud_Click" Visible="false" />
                            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-primary" Text="Cancelar"
                                OnClick="btnCancelar_Click" Visible="false" />
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
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
