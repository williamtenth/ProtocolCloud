<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProtocoloNTC837.ascx.cs"
    Inherits="TS15V2.UI.APP.dev.GestionProtocolo.ProtocoloNTC837C" %>
<%@ Register Src="../../componentes/ModalMsj.ascx" TagName="ModalMsj" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="box span12">
    <div class="box-header" data-original-title>
        <h2>
            <i class="halflings-icon edit"></i><span class="break"></span>Prueba NTC 837 - Medición
            de Cortocircuito</h2>
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
                    <label class="control-label" for="txtBt_at_t">
                        BT contra AT y tierra (kV)*
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="txtBt_at_t" CssClass="form-control" Enabled="false"
                            MaxLength="18"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtBt_at_t_MaskedEditExtender0" runat="server" TargetControlID="txtBt_at_t"
                            Mask="9999999999999999.99" OnFocusCssClass="MaskedEditFocus" MaskType="Number"
                            InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="txtAt_bt_t">
                        AT contra BT y tierra (kV)*
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="txtAt_bt_t" CssClass="form-control" Enabled="false"
                            MaxLength="18"></asp:TextBox>
                        <asp:MaskedEditExtender ID="txtAt_bt_t_MaskedEditExtender1" runat="server" TargetControlID="txtAt_bt_t"
                            Mask="9999999999999999.99" OnFocusCssClass="MaskedEditFocus" MaskType="Number"
                            InputDirection="RightToLeft" ClipboardEnabled="true" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="txtTension">
                        Tensión (V)*
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="txtTension" CssClass="form-control" Enabled="false"
                            MaxLength="18"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txtTension_FilteredTextBoxExtender" runat="server"
                            TargetControlID="txtTension" FilterType="Custom, Numbers" ValidChars="0123456789" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="txtFrecuencia">
                        Frecuencia (Hz)*
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="txtFrecuencia" CssClass="form-control" Enabled="false"
                            MaxLength="18"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txtFrecuencia_FilteredTextBoxExtender1" runat="server"
                            TargetControlID="txtFrecuencia" FilterType="Custom, Numbers" ValidChars="0123456789" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="txtTiempo">
                        Tiempo (s)*
                    </label>
                    <div class="controls">
                        <asp:TextBox runat="server" ID="txtTiempo" CssClass="form-control" Enabled="false"
                            MaxLength="18"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txtTiempo_FilteredTextBoxExtender2" runat="server"
                            TargetControlID="txtTiempo" FilterType="Custom, Numbers" ValidChars="0123456789" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="lbResultado">
                        Resultado*
                    </label>
                    <div class="controls">
                        <asp:DropDownList ID="lbResultado" runat="server" Enabled="False" OnDataBound="IniciarComponenteLista">
                        </asp:DropDownList>
                    </div>
                </div>
                <!--Detalle de Perdidas-->
                <!--Botonera-->
                <div class="control-group">
                    <asp:Panel ID="pnlBotonera" runat="server">
                        <asp:Panel ID="pnlInicial" runat="server">
                            <asp:Button ID="btModificar" runat="server" Text="Modificar" class="btn btn-success"
                                OnClick="Modificar" />
                            <asp:Button ID="btTerminar" runat="server" Text="Terminar" class="btn btn-success"
                                OnClick="Terminar" />
                        </asp:Panel>
                        <asp:Panel ID="pnlGuardar" Visible="false" runat="server">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success"
                                OnClick="Guardar" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-success"
                                OnClick="Cancelar" />
                        </asp:Panel>
                    </asp:Panel>
                </div>
            </fieldset>
        </div>
    </div>
</div>
<uc3:ModalMsj ID="MsjConfirmacion" runat="server" />
<!-- start: JavaScript-->
<script type="text/javascript" src="../../js/jquery-1.9.1.min.js"></script>
<script type="text/javascript" src="../../js/jquery-migrate-1.0.0.min.js"></script>
<script type="text/javascript" src="../../js/jquery-ui-1.10.0.custom.min.js"></script>
<script type="text/javascript" src="../../js/jquery.ui.touch-punch.js"></script>
<script type="text/javascript" src="../../js/modernizr.js"></script>
<script type="text/javascript" src="../../js/bootstrap.min.js"></script>
<script type="text/javascript" src="../../js/jquery.cookie.js"></script>
<script type="text/javascript" src='../../js/fullcalendar.min.js'></script>
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
