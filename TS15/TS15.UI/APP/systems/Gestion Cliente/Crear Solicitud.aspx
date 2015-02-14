<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="Crear Solicitud.aspx.cs" Inherits="TS15.UI.APP.systems.Gestion_Cliente.Crear_Solicitud" %>

<%@ Register Src="../../componentes/BuscarCliente.ascx" TagName="BuscarCliente" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../../css/sb-admin.css" rel="stylesheet" />
    <!-- Morris Charts CSS -->
    <link href="../../css/plugins/morris.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                Crear Solicitud del Cliente
            </h1>
            <ol class="breadcrumb">
                <li><i class="fa fa-dashboard"></i><a href="index.html">Inicio</a> </li>
                <li class="active"><i class="fa fa-edit"></i>Forms </li>
            </ol>
        </div>
    </div>
    <!-- Buscar Cliente -->
    <uc1:BuscarCliente ID="ctrlBusquedaCliente" runat="server" />
    <!-- /Buscar Cliente -->
    <asp:Panel runat="server" ID="pnlTipoSolicitud" CssClass="row" Visible="false">
        <div class="col-lg-4">
            <div class="form-group">
                <label>
                    Tipo de Solicitud:</label>
                <asp:DropDownList runat="server" ID="ddlTipoSolicitud" CssClass="form-control" OnDataBound="ddlTipoSolicitud_DataBound"
                    OnSelectedIndexChanged="ddlTipoSolicitud_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
    </asp:Panel>
    <!-- /.row -->
    <asp:Panel runat="server" ID="pnlServicio" CssClass="row" Visible="false">
        <div class="col-lg-6">
            <div class="form-group">
                <label>
                    Cantidad:</label>
                <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control"></asp:TextBox>
                <label>
                    Fase:</label>
                <asp:DropDownList runat="server" ID="ddlTipoTransformador" CssClass="form-control"
                    OnDataBound="ddlTipoTransformador_DataBound">
                </asp:DropDownList>
                <label>
                    Capacidad:</label>
                <asp:DropDownList runat="server" ID="ddlCapacidad" CssClass="form-control" OnDataBound="ddlCapacidad_DataBound">
                </asp:DropDownList>
                <label>
                    Voltaje de Entrada:</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
                <label>
                    Voltaje de Salida:</label>
                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </asp:Panel>
    <!-- /.row -->
    <asp:Panel runat="server" ID="pnlSuministro" CssClass="row">
        <div class="col-lg-4">
            <div class="form-group">
                <label>
                    Fabricante:</label>
                <asp:DropDownList runat="server" ID="ddlFabricante" CssClass="form-control" OnDataBound="ddlFabricante_DataBound">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-1">
        </div>
        <div class="col-lg-4">
            <div class="form-group">
                <label>
                    Número de Serie:</label>
                <asp:TextBox runat="server" ID="txtNumeroSerie" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-1">
        </div>
        <div class="col-lg-2">
            <asp:Button runat="server" ID="btnBuscarTransformador" CssClass="btn btn-success"
                Text="Buscar" Style="margin-top: 23px;" />
        </div>
    </asp:Panel>
    <!-- /.row -->
    <asp:HiddenField runat="server" ID="hfIdCliente" />
    <script type="text/javascript" src="../../js/jquery-1.11.0.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <!-- Morris Charts
    JavaScript -->
    <script type="text/javascript" src="../../js/plugins/morris/raphael.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/morris/morris.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/morris/morris-data.js"></script>
</asp:Content>
