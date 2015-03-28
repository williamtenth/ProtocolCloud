<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuscarCliente.ascx.cs"
    Inherits="TS15.UI.APP.componentes.BuscarCliente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<% if (false)
   { %>
<link rel="Stylesheet" type="text/css" href="../css/general.css" />
<link href="../css/bootstrap.min.css" rel="stylesheet" />
<!-- Custom CSS -->
<link href="../css/sb-admin.css" rel="stylesheet" />
<!-- Morris Charts CSS -->
<link href="../css/plugins/morris.css" rel="stylesheet" />
<!-- Custom Fonts -->
<link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
<!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
<% } %>
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
    <asp:Panel runat="server" ID="pnlDatosCliente" CssClass="col-lg-4" Visible="false">
        <div class="form-group">
            <asp:Label runat="server" ID="lblNombreCliente"></asp:Label>
        </div>
    </asp:Panel>
    <div class="col-lg-1">
        <br />
        <br />
        <asp:RequiredFieldValidator runat="server" ID="rfv_txtNumDoc" ControlToValidate="txtNumDoc"
            Display="Dynamic" ForeColor="Red" Font-Bold="true">*</asp:RequiredFieldValidator>
    </div>
    <div class="col-lg-2">
        <div class="form-group">
            <asp:Button runat="server" ID="btnBuscar" class="btn btn-success" Text="Buscar" OnClick="btnBuscar_Click"
                Style="margin-top: 23px" />
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlMsj" CssClass="alert alert-info" Visible="false">
        <strong>
            <asp:Label runat="server" ID="lblMsjBuscar" Visible="false"></asp:Label></strong>
    </asp:Panel>
</div>
<%--Modal Clientes--%>
<asp:UpdatePanel runat="server" ID="Up_pnlClientes" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdatePanel runat="server" ID="Up_pnlCaficultor" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlCaficultor" CssClass="modalPopup" BackImageUrl="~/APP/img/basica_odd.png"
                    DefaultButton="imgBtnCerrarModalCaficultor" Style="display: none">
                    <asp:ModalPopupExtender runat="server" ID="mpeCaficultor" PopupControlID="pnlCaficultor"
                        TargetControlID="lblPopCaficultor" BackgroundCssClass="modalBackGround" CancelControlID="imgBtnCerrarModalCaficultor">
                    </asp:ModalPopupExtender>
                    <asp:Label runat="server" ID="lblPopCaficultor"></asp:Label>
                    <div class="cerrar">
                        <asp:ImageButton ID="imgBtnCerrarModalCaficultor" runat="server" ImageUrl="~/APP/img/close_link.png" />
                    </div>
                    <h3 style="color: #72c014; border-bottom: 1px dotted black; padding-bottom: 5px;">
                        Seleccione</h3>
                    <div style="text-align: left">
                        <table width="100%">
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView runat="server" ID="gvClientes" AutoGenerateColumns="false" CssClass="grilla"
                                                DataKeyNames="intIdOCA" AllowPaging="true" PageSize="10">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button runat="server" CssClass="checkBoxClear" CommandName="SeleccionarCaficultor"
                                                                        ID="imgBtnSeleccionarCaficultor" ToolTip="Seleccionar Caficultor" ForeColor="#000099"
                                                                        OnClientClick="CambiarImagenActivo(this)"></asp:Button>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20px"></HeaderStyle>
                                                        <ItemStyle ForeColor="#000099" HorizontalAlign="Justify" VerticalAlign="Middle">
                                                        </ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="strNombresApellidos" HeaderText="Nombre(s)">
                                                        <ItemStyle HorizontalAlign="Justify" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="strNumeroIdentificacion" HeaderText="Número de Identificación">
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
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--<asp:Panel runat="server" ID="pnlClientes" CssClass="modalPopup" BackImageUrl="~/APP/img/basica_odd.png"
            DefaultButton="btnCerrarClientes" Style="display: none;">
            <asp:ModalPopupExtender runat="server" ID="mpeClientes" PopupControlID="pnlClientes"
                TargetControlID="lblPopClientes" BackgroundCssClass="modalBackGround" CancelControlID="btnCerrarClientes">
            </asp:ModalPopupExtender>
            <asp:Label runat="server" ID="lblPopClientes"></asp:Label>
            <div class="cerrar">
                <asp:ImageButton ID="btnCerrarClientes" runat="server" ImageUrl="~/APP/img/close_link.png" />
            </div>
            <h3 style="color: #72c014; border-bottom: 1px dotted black; padding-bottom: 5px;">
                Seleccione</h3>
            <div style="text-align: left">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView runat="server" ID="gvClientes" AutoGenerateColumns="false" CssClass="table table-hover table-striped"
                                        DataKeyNames="id" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvClientes_PageIndexChanging"
                                        OnRowCommand="gvClientes_RowCommand">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button runat="server" CssClass="checkBoxClear" CommandName="SeleccionarCaficultor"
                                                                ID="imgBtnSeleccionarCaficultor" ToolTip="Seleccionar Caficultor" ForeColor="#000099"
                                                                OnClientClick="CambiarImagenActivo(this)"></asp:Button>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                                <HeaderStyle Width="20px"></HeaderStyle>
                                                <ItemStyle ForeColor="#000099" HorizontalAlign="Justify" VerticalAlign="Middle">
                                                </ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="nombre" HeaderText="Nombre(s)">
                                                <ItemStyle HorizontalAlign="Justify" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="numDocumento" HeaderText="Número de Identificación">
                                                <ItemStyle HorizontalAlign="Justify" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <asp:Label runat="server" ID="lblMensaje" Text="No se encontraron datos." ForeColor="Red"
                                                Font-Bold="true" Style="text-align: center"></asp:Label>
                                        </EmptyDataTemplate>
                                        <PagerStyle HorizontalAlign="Center" CssClass="pager" BorderWidth="0px" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>--%>
    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript" language="javascript">
    function CambiarImagenActivo(Object) {
        Object.className = "checkBox";
    }
</script>
