<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuscarCliente.ascx.cs"
    Inherits="TS15.UI.APP.componentes.BuscarCliente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="box span12">
    <div class="box-header" data-original-title>
        <h2>
            <i class="halflings-icon edit"></i><span class="break"></span>Buscar Clientes</h2>
        <%--<div class="box-icon">
                    <a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a><a href="#"
                        class="btn-minimize"><i class="halflings-icon chevron-up"></i></a><a href="#" class="btn-close">
                            <i class="halflings-icon remove"></i></a>
                </div>--%>
    </div>
    <div class="box-content">
        <div class="form-horizontal">
            <fieldset>
                <div class="control-group">
                    <label class="control-label" for="ddlTipDocumento">
                        Tipo de Documento:
                    </label>
                    <div class="controls">
                        <asp:DropDownList runat="server" ID="ddlTipDocumento" CssClass="form-control" OnDataBound="ddlTipDocumento_DataBound"
                            Enabled="false">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="rfv_ddlTipDocumento" ControlToValidate="ddlTipDocumento"
                            ErrorMessage="*" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="txtNumDoc">
                        Número de Documento:
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="txtNumDoc" CssClass="form-control" MaxLength="30"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfv_txtNumDoc" ControlToValidate="txtNumDoc"
                            ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <asp:Panel runat="server" ID="pnlCliente" CssClass="control-group" Visible="false">
                    <label class="control-label" for="txtCliente">
                        Nombre / Razón Social:
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" MaxLength="30"
                            ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="rfv_txtCliente" ControlToValidate="txtCliente"
                            ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:HiddenField runat="server" ID="hfIdCliente" />
                    </div>
                </asp:Panel>
                <div class="form-actions">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Button runat="server" ID="btnBuscar" class="btn btn-success" Text="Buscar" OnClick="btnBuscar_Click"
                                CausesValidation="false" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </fieldset>
        </div>
    </div>
</div>
<asp:UpdatePanel runat="server" ID="Up_pnlClientes" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel runat="server" ID="pnlClientes" CssClass="modalPopup" BackImageUrl="~/APP/img/basica_odd.png"
            DefaultButton="btnCerrarClientes" Style="display: none;">
            <asp:ModalPopupExtender runat="server" ID="mpeClientes" PopupControlID="pnlClientes"
                TargetControlID="lblClientes" BackgroundCssClass="modalBackGround" CancelControlID="btnCerrarClientes">
            </asp:ModalPopupExtender>
            <asp:Label runat="server" ID="lblClientes"></asp:Label>
            <div class="cerrar">
                <asp:ImageButton ID="btnCerrarClientes" runat="server" ImageUrl="~/APP/img/close_link.png" />
            </div>
            <h3 style="color: #72c014; border-bottom: 1px dotted black; padding-bottom: 5px;">
                Seleccione</h3>
            <div style="text-align: left">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView runat="server" ID="gvClientes" AutoGenerateColumns="false" DataKeyNames="id,nombre,tipdoc,numdocumento"
                                        AllowPaging="true" PageSize="10" OnRowDataBound="gvClientes_RowDataBound" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged">
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
