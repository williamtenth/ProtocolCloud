<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="GestionarInformacionCliente.aspx.cs" Inherits="TS15V2.UI.APP.dev.GestionCliente.GestionarInformacionCliente"
    EnableEventValidation="false" %>

<%@ Register Src="../../componentes/BuscarCliente.ascx" TagName="BuscarCliente" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../componentes/ModalMsj.ascx" TagName="ModalMsj" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- start: Mobile Specific -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- end: Mobile Specific -->
    <!-- start: CSS -->
    <link rel="stylesheet" href="../../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../css/bootstrap-responsive.min.css" />
    <link href="../../css/style.css" rel="stylesheet" />
    <link href="../../css/style-responsive.css" rel="stylesheet" />
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
        /************** Modal PopUp *****************************************************************************************************/ .cerrar {
            float: right;
            margin-right: -30px;
            margin-top: -20px;
            z-index: 20;
        }

        .detalles {
            width: 320px;
            margin: auto;
            height: 55px;
            padding-top: 15px; /* background-image: url(../img/bg_detalles.png); background-position: top center; background-repeat: no-repeat;*/
        }

            .detalles p {
                font-size: 35px;
                text-align: center;
                font-family: 'Museo', Arial, sans-serif;
                height: auto;
                margin: auto;
            }

        .modalPopup {
            font-size: 10pt;
            border-radius: 10px;
            -ms-border-radius: 10px;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            z-index: 10001;
            padding: 10px 20px;
            width: 500px;
        }

        .modalPopup2 {
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

        .modalBackGround {
            background: url(../../img/overlay.png) repeat 0 0;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }

        .modalBackgroundCargando {
            background-color: Black;
            filter: alpha(opacity=55);
            opacity: 0.50;
            z-index: 10100 !important;
        }

        .imgFinca {
            max-width: 100%;
            max-height: 300px;
        }
        /***********************************************************************************************************************/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="../Home.aspx">Home</a> <i class="icon-angle-right"></i></li>
        <li><i class="icon-edit"></i><a href="#">Gestionar Información Cliente</a> </li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <uc1:BuscarCliente ID="ucBusquedaCliente" runat="server" OnClienteChange="ucBusquedaCliente_ClienteChange" />
    </div>
    <asp:Panel runat="server" ID="pnlTabs" CssClass="row-fluid" Visible="false">
        <div class="box span12">
            <div class="box-header">
                <h2>
                    <i class="halflings-icon th"></i><span class="break"></span>Gestionar Información</h2>
            </div>
            <div class="box-content">
                <ul class="nav tab-menu nav-tabs" id="myTab">
                    <li class="active"><a href="#info"><b>Información General</b> </a></li>
                    <li><a href="#historial"><b>Consultar Historial</b></a></li>
                </ul>
                <div id="myTabContent" class="tab-content">
                    <div class="tab-pane" id="historial">
                        <div class="box-content">
                            <asp:GridView runat="server" ID="gvSolicitudesCliente" AutoGenerateColumns="false"
                                CssClass="table table-bordered table-striped table-condensed">
                                <Columns>
                                    <asp:BoundField DataField="nombreFabricante" HeaderText="Nombre Fabricante" />
                                    <asp:BoundField DataField="numserie" HeaderText="Número de Serie" />
                                    <asp:BoundField DataField="tfrcapacidad" HeaderText="Capacidad" />
                                    <asp:BoundField DataField="consecutivo" HeaderText="Consecutivo" />
                                    <asp:BoundField DataField="fecentrada" HeaderText="Fecha" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="tipsolicitud" HeaderText="Tipo Solicitud" />
                                    <asp:BoundField DataField="" HeaderText="Observación" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="tab-pane active" id="info">
                        <div class="box-content" style="min-height: 365px">
                            <div class="form-horizontal">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label" for="ddlFabricante">
                                            Tipo de Documento:</label>
                                        <div class="controls">
                                            <asp:DropDownList runat="server" ID="ddlTipoDocumento" CssClass="form-control" AutoPostBack="true"
                                                Enabled="false" OnDataBound="ddlTipoDocumento_DataBound">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_ddlTipoDocumento" ControlToValidate="ddlTipoDocumento"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarCliente" InitialValue="-1"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="txtNumeroDocumento">
                                            Número de Documento:</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtNumeroDocumento" CssClass="form-control" MaxLength="20"
                                                Enabled="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_txtNumeroDocumento" ControlToValidate="txtNumeroDocumento"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarCliente"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="ddlCapacidad">
                                            Nombre / Razón Social:</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" MaxLength="50"
                                                Enabled="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_txtNombre" ControlToValidate="txtNombre"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarCliente"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="ddlCapacidad">
                                            Dirección:</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" MaxLength="50"
                                                Enabled="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_txtDireccion" ControlToValidate="txtDireccion"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarCliente"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="txtTelefono">
                                            Teléfono:</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" MaxLength="50"
                                                Enabled="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_txtTelefono" ControlToValidate="txtTelefono"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarCliente"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="txtTipoCliente">
                                            Tipo Cliente:</label>
                                        <div class="controls">
                                            <asp:DropDownList runat="server" ID="ddlTipoCliente" OnDataBound="ddlTipoCliente_DataBound"
                                                Enabled="false">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator runat="server" ID="rfv_ddlTipoCliente" ControlToValidate="ddlTipoCliente"
                                                ErrorMessage="*" ForeColor="red" ValidationGroup="vgGuardarCliente" InitialValue="-1"></asp:RequiredFieldValidator>
                                            <asp:HiddenField runat="server" ID="hfIdCliente" />
                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <asp:Button ID="btnCrearCliente" runat="server" CssClass="btn btn-primary" Text="Crear"
                                            OnClick="btnCrearCliente_Click" />
                                        <asp:Button ID="btnModificarCliente" runat="server" CssClass="btn btn-primary" Text="Modificar"
                                            OnClick="btnModificarCliente_Click" />
                                        <asp:Button ID="btnEliminarCliente" runat="server" CssClass="btn btn-primary" Text="Eliminar"
                                            OnClick="btnEliminarCliente_Click" />
                                        <asp:Button ID="btnGuardarCliente" runat="server" CssClass="btn btn-primary" Text="Guardar"
                                            OnClick="btnGuardarCliente_Click" ValidationGroup="vgGuardarCliente" Visible="false" />
                                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-primary" Text="Cancelar"
                                            OnClick="btnCancelar_Click" Visible="false" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!--/span-->
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
