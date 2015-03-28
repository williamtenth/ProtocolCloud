<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="ConsultarHistorial.aspx.cs" Inherits="TS15.UI.APP.systems.Gestion_Cliente.ConsultarHistorial" %>

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
                Consultar Historial
            </h1>
            <ol class="breadcrumb">
                <li><i class="fa fa-dashboard"></i><a href="index.html">Inicio</a> </li>
                <li class="active"><i class="fa fa-edit"></i>Forms </li>
            </ol>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4">
            <div class="form-group">
                <label>
                    Tipo de Documento</label>
                <asp:DropDownList runat="server" ID="ddlTipDocumento" CssClass="form-control" OnDataBound="ddlTipDocumento_DataBound">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-1">
            <br />
            <br />
            <asp:RequiredFieldValidator runat="server" ID="rfv_ddlTipDocumento" ControlToValidate="ddlTipDocumento"
                Display="Dynamic" ForeColor="Red" Font-Bold="true" InitialValue="-1">*</asp:RequiredFieldValidator></div>
        <div class="col-lg-4">
            <div class="form-group">
                <label>
                    Número de Documento</label>
                <asp:TextBox runat="server" ID="txtNumDoc" CssClass="form-control" MaxLength="30"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
