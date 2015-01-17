<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="Busqueda Cliente.aspx.cs" Inherits="TS15.UI.APP.systems.Gestion_Cliente.Busqueda_Cliente" %>

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
    <!-- Page Heading -->
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
                <small>Consultar Clientes</small>
            </h1>
            <ol class="breadcrumb">
                <li><i class="fa fa-dashboard"></i><a href="index.html">Inicio</a> </li>
                <li class="active"><i class="fa fa-table"></i>Consultar Clientes </li>
            </ol>
        </div>
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-6">
            <div class="form-group">
                <label>
                    Tipo de Documento</label>
                <asp:DropDownList runat="server" ID="ddlTipDocumento" CssClass="form-control" OnDataBound="ddlTipDocumento_DataBound1">
                </asp:DropDownList>
                <label>
                    Número de Documento</label>
                <asp:TextBox runat="server" ID="txtNumDoc" CssClass="form-control"></asp:TextBox>
                <label>
                    Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-1">
            <asp:Button runat="server" ID="btnConsultar" Text="Consultar" CssClass="btn btn-success"
                OnClick="btnBuscar_Click" />
        </div>
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-1">
            <br />
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="table-responsive">
                <asp:GridView runat="server" ID="gvClientes" CssClass="table table-hover" AutoGenerateColumns="false"
                    OnRowCommand="gvClientes_RowCommand" DataKeyNames="id">
                    <Columns>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="tipdoc" HeaderText="Tipo Documento" />
                        <asp:BoundField DataField="numdocumento" HeaderText="No. Documento" />
                        <asp:BoundField DataField="direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lbtnVer" CommandName="Ver" CssClass="btn btn-success">
                                <i class="glyphicon glyphicon-zoom-in icon-white"></i>Ver</asp:LinkButton>
                                <asp:LinkButton runat="server" ID="ltbnEditar" CommandName="Editar" CssClass="btn btn-info">
                                <i class="glyphicon glyphicon-edit icon-white"></i>Editar</asp:LinkButton>
                                <%--<asp:LinkButton runat="server" ID="lbtnEliminar" CommandName="Eliminar" CssClass="btn btn-danger"
                                    OnClientClick="return confirm('¿Realmente deseas eliminar este registro?');">
                                <i class="glyphicon glyphicon-trash icon-white">Eliminar</i>
                                </asp:LinkButton>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <!-- /.row -->
    <script type="text/javascript" src="../../js/jquery-1.11.0.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script type="text/javascript" src="../../js/bootstrap.min.js"></script>
    <!-- Morris Charts JavaScript -->
    <script type="text/javascript" src="../../js/plugins/morris/raphael.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/morris/morris.min.js"></script>
    <script type="text/javascript" src="../../js/plugins/morris/morris-data.js"></script>
</asp:Content>
