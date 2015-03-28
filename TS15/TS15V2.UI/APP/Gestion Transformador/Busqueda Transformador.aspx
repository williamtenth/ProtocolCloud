<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="Busqueda Transformador.aspx.cs" Inherits="TS15.UI.APP.systems.Gestion_Transformador.Busqueda_Transformador" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <style>
        /************** Modal PopUp *****************************************************************************************************/
        
        .cerrar
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
            background: url(../img/overlay.png) repeat 0 0;
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
        <li><i class="icon-home"></i><a href="index.html">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><i class="icon-edit"></i><a href="#">Buscar Transformador</a> </li>
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
                        <div class="span5">
                            <div class="control-group">
                                <label class="control-label" for="ddlTipDocumento">
                                    Nombre Fabricante:
                                </label>
                                <div class="controls">
                                    <asp:DropDownList runat="server" ID="ddlFabricante" CssClass="form-control" OnDataBound="ddlFabricante_DataBound">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="span5">
                            <div class="control-group">
                                <label class="control-label" for="txtNumDoc">
                                    Número de Serie:
                                </label>
                                <div class="controls">
                                    <asp:TextBox runat="server" ID="txtNumSerie" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="span2">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Button runat="server" ID="btnBuscar" class="btn btn-success" Text="Buscar" OnClick="btnBuscar_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="Up_pnlTransformadores" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnlTransformadores" CssClass="modalPopup" BackImageUrl="~/APP/img/basica_odd.png"
                DefaultButton="btnCloseTransformadores" Style="display: none;">
                <asp:ModalPopupExtender runat="server" ID="mpeTransformadores" PopupControlID="pnlTransformadores"
                    TargetControlID="lblPopTransformadores" BackgroundCssClass="modalBackGround"
                    CancelControlID="btnCloseTransformadores">
                </asp:ModalPopupExtender>
                <asp:Label runat="server" ID="lblPopTransformadores"></asp:Label>
                <div class="cerrar">
                    <asp:ImageButton ID="btnCloseTransformadores" runat="server" ImageUrl="~/APP/img/close_link.png" />
                </div>
                <h3 style="color: #72c014; border-bottom: 1px dotted black; padding-bottom: 5px;">
                    Seleccione</h3>
                <div style="text-align: left">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="gvTransformadores" AutoGenerateColumns="false" DataKeyNames="id,nombre"
                                            AllowPaging="true" PageSize="10" OnRowDataBound="gvTransformadores_RowDataBound"
                                            OnSelectedIndexChanging="gvTransformadores_SelectedIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="nombre" HeaderText="Nombre(s)">
                                                    <ItemStyle HorizontalAlign="Justify" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="numdocumento" HeaderText="Número de Identificación">
                                                    <ItemStyle HorizontalAlign="Justify" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <asp:Label runat="server" ID="lblMensaje" Text="No se encontraron datos." ForeColor="Red"
                                                    Font-Bold="true" Style="text-align: center"></asp:Label>
                                            </EmptyDataTemplate>
                                            <PagerStyle HorizontalAlign="Center" CssClass="pager" BorderWidth="0px" />
                                            <AlternatingRowStyle BackColor="#ebf3de" />
                                            <HeaderStyle CssClass="grilla" />
                                            <RowStyle CssClass="grilla" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="gvClientes" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
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
