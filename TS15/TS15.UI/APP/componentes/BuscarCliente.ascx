<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuscarCliente.ascx.cs"
    Inherits="TS15.UI.APP.componentes.BuscarCliente" %>
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
