﻿<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="Crear Pedido.aspx.cs" Inherits="TS15.UI.APP.systems.Gestion_Cliente.Crear_Pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- start: Mobile Specific -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- end: Mobile Specific -->
    <!-- start: CSS -->
    <link id="bootstrap-style" href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link id="base-style" href="../css/style.css" rel="stylesheet" />
    <link id="base-style-responsive" href="../css/style-responsive.css" rel="stylesheet" />
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
        <li><i class="icon-home"></i><a href="index.html">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><i class="icon-edit"></i><a href="#">Crear Pedido</a> </li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div data-original-title="" class="box-header">
                <h2>
                    <i class="halflings-icon edit"></i><span class="break"></span>Form Elements</h2>
                <div class="box-icon">
                    <a class="btn-setting" href="#"><i class="halflings-icon wrench"></i></a><a class="btn-minimize"
                        href="#"><i class="halflings-icon chevron-up"></i></a><a class="btn-close" href="#">
                            <i class="halflings-icon remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="ddlFabricante">
                                Nombre de Fabricante:</label>
                            <div class="controls">
                                <asp:DropDownList runat="server" ID="ddlFabricante" CssClass="form-control" OnDataBound="ddlFabricante_DataBound">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtNumSerie">
                                Número de Serie:</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtNumSerie" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="txtAltura">
                                Altura:</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="txtAltura" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="ddlSerieBT">
                                Serie BT:</label>
                            <div class="controls">
                                <asp:DropDownList runat="server" ID="ddlSerieBT" CssClass="form-control" OnDataBound="ddlSerieBT_DataBound">
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
                            <label class="control-label" for="ddlFase">
                                Fase:</label>
                            <div class="controls">
                                <asp:DropDownList runat="server" ID="ddlFase" CssClass="form-control" OnDataBound="ddlFase_DataBound">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <!-- start: JavaScript-->
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../js/jquery-migrate-1.0.0.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.10.0.custom.min.js"></script>
    <script type="text/javascript" src="../js/jquery.ui.touch-punch.js"></script>
    <script type="text/javascript" src="../js/modernizr.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/jquery.cookie.js"></script>
    <script type="text/javascript" src='../js/fullcalendar.min.js'></script>
    <script type="text/javascript" src='../js/jquery.dataTables.min.js'></script>
    <script type="text/javascript" src="../js/excanvas.js"></script>
    <script type="text/javascript" src="../js/jquery.flot.js"></script>
    <script type="text/javascript" src="../js/jquery.flot.pie.js"></script>
    <script type="text/javascript" src="../js/jquery.flot.stack.js"></script>
    <script type="text/javascript" src="../js/jquery.flot.resize.min.js"></script>
    <script type="text/javascript" src="../js/jquery.chosen.min.js"></script>
    <script type="text/javascript" src="../js/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../js/jquery.cleditor.min.js"></script>
    <script type="text/javascript" src="../js/jquery.noty.js"></script>
    <script type="text/javascript" src="../js/jquery.elfinder.min.js"></script>
    <script type="text/javascript" src="../js/jquery.raty.min.js"></script>
    <script type="text/javascript" src="../js/jquery.iphone.toggle.js"></script>
    <script type="text/javascript" src="../js/jquery.uploadify-3.1.min.js"></script>
    <script type="text/javascript" src="../js/jquery.gritter.min.js"></script>
    <script type="text/javascript" src="../js/jquery.imagesloaded.js"></script>
    <script type="text/javascript" src="../js/jquery.masonry.min.js"></script>
    <script type="text/javascript" src="../js/jquery.knob.modified.js"></script>
    <script type="text/javascript" src="../js/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="../js/counter.js"></script>
    <script type="text/javascript" src="../js/retina.js"></script>
    <script type="text/javascript" src="../js/custom.js"></script>
    <!-- end: JavaScript-->
</asp:Content>
