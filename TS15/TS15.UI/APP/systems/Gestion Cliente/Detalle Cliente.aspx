<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="Detalle Cliente.aspx.cs" Inherits="TS15.UI.APP.systems.Gestion_Cliente.Detalle_Cliente" %>

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
                Detalle Cliente
            </h1>
            <ol class="breadcrumb">
                <li><i class="fa fa-dashboard"></i><a href="index.html">Inicio</a> </li>
                <li class="active"><i class="fa fa-edit"></i>Forms </li>
            </ol>
        </div>
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <label>
                    Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" Enabled="false"
                    ReadOnly="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                    Tipo Documento:</label>
                <asp:TextBox runat="server" ID="txtTipDoc" CssClass="form-control" Enabled="false"
                    ReadOnly="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                    Número de Documento</label>
                <asp:TextBox runat="server" ID="txtNumDoc" CssClass="form-control" Enabled="false"
                    ReadOnly="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                    Dirección:</label>
                <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>
                    Teléfono:</label>
                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnGuardar" class="btn btn-success" Text="Guardar"
                OnClick="btnGuardar_Click" />
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfIdCliente" />
    <!-- /.row -->
    <script type="text/javascript" src="../../js/jquery-1.11.0.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <!-- Morris Charts JavaScript -->
    <script type="text/javascript" src="../../js/plugins/morris/raphael.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/morris/morris.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/morris/morris-data.js"></script>
</asp:Content>
