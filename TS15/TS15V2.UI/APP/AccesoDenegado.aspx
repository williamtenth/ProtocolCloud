﻿<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="AccesoDenegado.aspx.cs" Inherits="TS15V2.UI.APP.AccesoDenegado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- start: Mobile Specific -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- end: Mobile Specific -->
    <!-- start: CSS -->
    <link id="bootstrap-style" href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link id="base-style" href="css/style.css" rel="stylesheet" />
    <link id="base-style-responsive" href="css/style-responsive.css" rel="stylesheet" />
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
    <link rel="shortcut icon" href="img/favicon.ico">
    <!-- end: Favicon -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <div class="row-fluid">
        <div class="box span12">
            <div class="box-header">
                <h2>
                    <i class="halflings-icon bullhorn"></i><span class="break"></span>
                </h2>
                <%--<div class="box-icon">
                    <a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a><a href="#"
                        class="btn-minimize"><i class="halflings-icon chevron-up"></i></a><a href="#" class="btn-close">
                            <i class="halflings-icon remove"></i></a>
                </div>--%>
            </div>
            <div class="box-content alerts">
                <div class="alert alert-block ">
                    <h4 class="alert-heading">
                        ACCESO DENEGADO</h4>
                    <br />
                    <p>
                        EL acceso a la página solicitada ha sido denegado, por favor consulte con el administrador
                        del sistema.</p>
                </div>
            </div>
        </div>
        <!--/span-->
    </div>
    <!--/row-->
    <!-- start: JavaScript-->
    <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="js/jquery-migrate-1.0.0.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.10.0.custom.min.js"></script>
    <script type="text/javascript" src="js/jquery.ui.touch-punch.js"></script>
    <script type="text/javascript" src="js/modernizr.js"></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/jquery.cookie.js"></script>
    <script type="text/javascript" src='js/fullcalendar.min.js'></script>
    <script type="text/javascript" src='js/jquery.dataTables.min.js'></script>
    <script type="text/javascript" src="js/excanvas.js"></script>
    <script type="text/javascript" src="js/jquery.flot.js"></script>
    <script type="text/javascript" src="js/jquery.flot.pie.js"></script>
    <script type="text/javascript" src="js/jquery.flot.stack.js"></script>
    <script type="text/javascript" src="js/jquery.flot.resize.min.js"></script>
    <script type="text/javascript" src="js/jquery.chosen.min.js"></script>
    <script type="text/javascript" src="js/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="js/jquery.cleditor.min.js"></script>
    <script type="text/javascript" src="js/jquery.noty.js"></script>
    <script type="text/javascript" src="js/jquery.elfinder.min.js"></script>
    <script type="text/javascript" src="js/jquery.raty.min.js"></script>
    <script type="text/javascript" src="js/jquery.iphone.toggle.js"></script>
    <script type="text/javascript" src="js/jquery.uploadify-3.1.min.js"></script>
    <script type="text/javascript" src="js/jquery.gritter.min.js"></script>
    <script type="text/javascript" src="js/jquery.imagesloaded.js"></script>
    <script type="text/javascript" src="js/jquery.masonry.min.js"></script>
    <script type="text/javascript" src="js/jquery.knob.modified.js"></script>
    <script type="text/javascript" src="js/jquery.sparkline.min.js"></script>
    <script type="text/javascript" src="js/counter.js"></script>
    <script type="text/javascript" src="js/retina.js"></script>
    <script type="text/javascript" src="js/custom.js"></script>
    <!-- end: JavaScript-->
</asp:Content>
