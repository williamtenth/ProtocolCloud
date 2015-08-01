<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="GestionarInfoTransformador.aspx.cs" Inherits="TS15V2.UI.APP.dev.GestionTransformador.GestionarInfoTransformador"
    EnableEventValidation="false" %>

<%@ Register Src="../../componentes/BuscarCliente.ascx" TagName="BuscarCliente" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../componentes/ModalMsj.ascx" TagName="ModalMsj" TagPrefix="uc3" %>
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
        <li><i class="icon-edit"></i><a href="#">Gestionar Información del Transformador</a>
        </li>
    </ul>
    <div class="row-fluid sortable ui-sortable">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <uc1:BuscarCliente ID="ucBusquedaCliente" runat="server" OnClienteChange="ucBusquedaCliente_ClienteChange" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row-fluid sortable ui-sortable">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <uc2:BuscarTransformador ID="ucBusquedaTransformador" runat="server" Visible="false"
                    OnTransformadorChange="ucBusquedaTransformador_TransformadorChange" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:Panel runat="server" ID="pnlTabs" CssClass="row-fluid" Visible="false">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
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
                                    <asp:GridView runat="server" ID="gvSolicitudesTransformador" AutoGenerateColumns="false"
                                        CssClass="table table-bordered table-striped table-condensed">
                                        <Columns>
                                            <asp:BoundField DataField="consecutivo" HeaderText="Consecutivo" />
                                            <asp:BoundField DataField="fechasolicitud" HeaderText="Fecha" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="tipSolicitud" HeaderText="Tipo Solicitud" />
                                            <asp:BoundField DataField="nombre" HeaderText="Nombre Fabricante" />
                                            <asp:BoundField DataField="numserie" HeaderText="Número de Serie" />
                                            <asp:BoundField DataField="tfrcapacidad" HeaderText="Capacidad" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="tab-pane active" id="info">
                                <div class="box-content" style="min-height: 420px">
                                    <div class="form-horizontal">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label" for="ddlFabricante">
                                                    Nombre de Fabricante:</label>
                                                <div class="controls">
                                                    <asp:DropDownList runat="server" ID="ddlFabricante" CssClass="form-control" OnDataBound="ddlFabricante_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_ddlFabricante" ControlToValidate="ddlFabricante"
                                                        ErrorMessage="*" ForeColor="Red" InitialValue="-1" ValidationGroup="vgCrearTransformador"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtNumSerie">
                                                    Número de Serie:</label>
                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txtNumSerie" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                                    <asp:HiddenField runat="server" ID="hfIdTransformador" />
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_txtNumSerie" ControlToValidate="txtNumSerie"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtAltura">
                                                    Altura:</label>
                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txtAltura" CssClass="form-control" ReadOnly="true"
                                                        Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_txtAltura" ControlToValidate="txtAltura"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="ddlSerieAT">
                                                    Serie AT:</label>
                                                <div class="controls">
                                                    <asp:DropDownList runat="server" ID="ddlSerieAT" CssClass="form-control" OnDataBound="ddlSerieAT_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_ddlSerieAT" ControlToValidate="ddlSerieAT"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="ddlSerieBT">
                                                    Serie BT:</label>
                                                <div class="controls">
                                                    <asp:DropDownList runat="server" ID="ddlSerieBT" CssClass="form-control" OnDataBound="ddlSerieBT_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_ddlSerieBT" ControlToValidate="ddlSerieBT"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="ddlCapacidad">
                                                    Capacidad:</label>
                                                <div class="controls">
                                                    <asp:DropDownList runat="server" ID="ddlCapacidad" CssClass="form-control" OnDataBound="ddlCapacidad_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_ddlCapacidad" ControlToValidate="ddlCapacidad"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="ddlFase">
                                                    Fase:</label>
                                                <div class="controls">
                                                    <asp:DropDownList runat="server" ID="ddlFase" CssClass="form-control" OnDataBound="ddlFase_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_ddlFase" ControlToValidate="ddlFase"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtFechaFabricacion">
                                                    Fecha de Fabricación:</label>
                                                <div class="controls">
                                                    <div class="input-append date">
                                                        <asp:TextBox runat="server" ID="txtFechaFabricacion" CssClass="span11 datepicker"
                                                            MaxLength="10"></asp:TextBox>
                                                        <span class="add-on"><i class="icon-calendar"></i></span>
                                                    </div>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_txtFechaFabricacion" ControlToValidate="txtFechaFabricacion"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtTempDevanado">
                                                    Temp. Devanado:</label>
                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txtTempDevanado" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_txtTempDevanado" ControlToValidate="txtTempDevanado"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtAislamiento">
                                                    Aislamiento:</label>
                                                <div class="controls">
                                                    <asp:DropDownList runat="server" ID="ddlAislamiento" CssClass="form-control" OnDataBound="ddlAislamiento_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_ddlAislamiento" ControlToValidate="ddlAislamiento"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtFrecuencia">
                                                    Frecuencia:</label>
                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txtFrecuencia" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_txtFrecuencia" ControlToValidate="txtFrecuencia"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtRefrigeracion">
                                                    Refrigeración:</label>
                                                <div class="controls">
                                                    <asp:DropDownList runat="server" ID="ddlRefrigeracion" CssClass="form-control" OnDataBound="ddlRefrigeracion_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_ddlRefrigeracion" ControlToValidate="ddlRefrigeracion"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtVoltajeEntrada">
                                                    Voltaje Entrada:</label>
                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txtVoltajeEntrada" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_txtVoltajeEntrada" ControlToValidate="txtVoltajeEntrada"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtVoltajeSalida">
                                                    Voltaje Salida:</label>
                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txtVoltajeSalida" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_txtVoltajeSalida" ControlToValidate="txtVoltajeSalida"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtVoltajeEntDerivada">
                                                    Voltaje Entrada Derivada:</label>
                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txtVoltajeEntDerivada" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_txtVoltajeEntDerivada" ControlToValidate="txtVoltajeEntDerivada"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtVoltajeSalDerivada">
                                                    Voltaje Salida Derivada:</label>
                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txtVoltajeSalDerivada" CssClass="form-control" MaxLength="10"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_txtVoltajeSalDerivada" ControlToValidate="txtVoltajeSalDerivada"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="txtNumDerivaciones">
                                                    Número Derivaciones:</label>
                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txtNumDerivaciones" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_txtNumDerivaciones" ControlToValidate="txtNumDerivaciones"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label" for="ddlGrupoConexion">
                                                    Grupo Conexión:</label>
                                                <div class="controls">
                                                    <asp:DropDownList runat="server" ID="ddlGrupoConexion" CssClass="form-control" OnDataBound="ddlGrupoConexion_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator runat="server" ID="rfv_ddlGrupoConexion" ControlToValidate="ddlGrupoConexion"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="vgCrearTransformador" InitialValue="-1"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="form-actions">
                                                <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar"
                                                    OnClick="btnGuardar_Click" CausesValidation="true" ValidationGroup="vgCrearTransformador" />
                                                <asp:Button runat="server" ID="btnModificar" CssClass="btn btn-primary" Text="Modificar"
                                                    OnClick="btnModificar_Click" />
                                                <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-primary" Text="Cancelar"
                                                    OnClick="btnCancelar_Click" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--/span-->
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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
