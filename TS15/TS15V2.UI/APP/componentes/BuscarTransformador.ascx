<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BuscarTransformador.ascx.cs"
    Inherits="TS15V2.UI.APP.componentes.BuscarTransformador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="box span12">
    <div class="box-header" data-original-title>
        <h2>
            <i class="halflings-icon edit"></i><span class="break"></span>Buscar Transformador</h2>
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
                        Nombre Fabricante:
                    </label>
                    <div class="controls">
                        <asp:DropDownList runat="server" ID="ddlFabricante" CssClass="form-control" OnDataBound="ddlFabricante_DataBound"
                            Enabled="false">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="txtNumDoc">
                        Número de Serie:
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="txtNumSerie" CssClass="form-control" MaxLength="30"
                            Enabled="false" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="form-actions">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Button runat="server" ID="btnBuscarTranformador" class="btn btn-success" Text="Buscar"
                                OnClick="btnBuscarTranformador_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </fieldset>
        </div>
    </div>
</div>
<asp:UpdatePanel runat="server" ID="Up_pnlTransformador" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel runat="server" ID="pnlTransformador" CssClass="modalPopup" BackImageUrl="~/APP/img/basica_odd.png"
            DefaultButton="btnCerrarTransformador" Style="display: none;">
            <asp:ModalPopupExtender runat="server" ID="mpeTransformador" PopupControlID="pnlTransformador"
                TargetControlID="lblTransformador" BackgroundCssClass="modalBackGround" CancelControlID="btnCerrarTransformador">
            </asp:ModalPopupExtender>
            <asp:Label runat="server" ID="lblTransformador"></asp:Label>
            <div class="cerrar">
                <asp:ImageButton ID="btnCerrarTransformador" runat="server" ImageUrl="~/APP/img/close_link.png" />
            </div>
            <h3 style="color: #72c014; border-bottom: 1px dotted black; padding-bottom: 5px;">
                Seleccione</h3>
            <div style="text-align: left">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView runat="server" ID="gvTransformadores" AutoGenerateColumns="false" AllowPaging="true"
                                        DataKeyNames="id,numserie,fabricante_id" PageSize="10" OnRowDataBound="gvTransformadores_RowDataBound"
                                        OnSelectedIndexChanged="gvTransformadores_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="numserie" HeaderText="Número de Serie">
                                                <ItemStyle HorizontalAlign="Justify" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="fecfabricacion" HeaderText="Fecha de Fabricación" DataFormatString="{0:d}">
                                                <ItemStyle HorizontalAlign="Justify" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="volentrada" HeaderText="Voltaje Entrada">
                                                <ItemStyle HorizontalAlign="Justify" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="volsalida" HeaderText="Voltaje Salida">
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
                                    <asp:PostBackTrigger ControlID="gvTransformadores" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
