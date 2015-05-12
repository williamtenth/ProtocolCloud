<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProtocoloNTC375.ascx.cs"
    Inherits="TS15V2.UI.APP.dev.GestionProtocolo.ProtocoloNTC375C" %>
<%@ Register Src="../../componentes/ModalMsj.ascx" TagName="ModalMsj" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="row-fluid sortable ui-sortable">
    <div class="box span12">
        <div class="box-header" data-original-title>
            <h2>
                <i class="halflings-icon edit"></i><span class="break"></span>Prueba NTC 375 - Medición
                de Resistencia</h2>
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
                        <label class="control-label" for="txtTiempo">
                            Tiempo de lectura*
                        </label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="txtTiempo" CssClass="form-control" Enabled="false"
                                MaxLength="18"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtTiempo_FilteredTextBoxExtender" runat="server"
                                TargetControlID="txtTiempo" ValidChars="1234567890">
                            </asp:FilteredTextBoxExtender>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="txtTension">
                            Tensión*
                        </label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="txtTension" CssClass="form-control" Enabled="false"
                                MaxLength="18"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtTension_FilteredTextBoxExtender1" runat="server"
                                TargetControlID="txtTension" ValidChars="1234567890">
                            </asp:FilteredTextBoxExtender>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="txtAT_T">
                            AT y T *
                        </label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="txtAT_T" CssClass="form-control" Enabled="false"
                                MaxLength="10"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtAT_T_FilteredTextBoxExtender2" runat="server"
                                TargetControlID="txtAT_T" ValidChars="1234567890">
                            </asp:FilteredTextBoxExtender>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="txtBT_T">
                            BT y T*
                        </label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="txtBT_T" CssClass="form-control" Enabled="false"
                                MaxLength="10"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtBT_T_FilteredTextBoxExtender3" runat="server"
                                TargetControlID="txtBT_T" ValidChars="1234567890">
                            </asp:FilteredTextBoxExtender>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="txtAT_BT_T">
                            AT, BT y T*
                        </label>
                        <div class="controls">
                            <asp:TextBox runat="server" ID="txtAT_BT_T" CssClass="form-control" Enabled="false"
                                MaxLength="10"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtAT_BT_T_FilteredTextBoxExtender4" runat="server"
                                TargetControlID="txtAT_BT_T" ValidChars="1234567890">
                            </asp:FilteredTextBoxExtender>
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
