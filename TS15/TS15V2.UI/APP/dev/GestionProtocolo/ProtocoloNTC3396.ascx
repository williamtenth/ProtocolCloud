﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProtocoloNTC3396.ascx.cs"
    Inherits="TS15V2.UI.APP.dev.GestionProtocolo.ProtocoloNTC3396C" %>
<%@ Register Src="../../componentes/ModalMsj.ascx" TagName="ModalMsj" TagPrefix="uc3" %>
<ul class="breadcrumb">
    <li><i class="icon-edit"></i><a href="#">Prueba NTC 3396</a> </li>
</ul>
<div class="row-fluid sortable ui-sortable">
    <div class="box span12">
        <div class="box-header" data-original-title>
            <h2>
                <i class="halflings-icon edit"></i><span class="break"></span>Información de pintura</h2>
            <%--<div class="box-icon">
                    <a href="#" class="btn-setting"><i class="halflings-icon wrench"></i></a><a href="#"
                        class="btn-minimize"><i class="halflings-icon chevron-up"></i></a><a href="#" class="btn-close">
                            <i class="halflings-icon remove"></i></a>
                </div>--%>
        </div>
        <div class="box-content">
            <%--div class="row-fluid">
                    <div class="span_3">
                        <label>
                            Transformador</label>
                        <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                </div--%>
            <div class="row-fluid">
                <div class="span3">
                    <label>
                        Color
                    </label>
                    <asp:DropDownList ID="lbColor" runat="server" Enabled="False" OnDataBound="IniciarComponenteLista">
                    </asp:DropDownList>
                    &nbsp;</div>
            </div>
            <div class="row-fluid">
                <div class="span3">
                    <label>
                        Salina Ambiente 1*
                    </label>
                    <asp:DropDownList ID="lbSalina1" runat="server" Enabled="False" OnDataBound="IniciarComponenteLista">
                    </asp:DropDownList>
                    &nbsp;</div>
            </div>
            <div class="row-fluid">
                <div class="span3">
                    <label>
                        Salina Ambiente 2*
                    </label>
                    <asp:DropDownList ID="lbSalina2" runat="server" Enabled="False" OnDataBound="IniciarComponenteLista">
                    </asp:DropDownList>
                    &nbsp;</div>
            </div>
            <div class="row-fluid">
                <div class="span3">
                    <label>
                        Impacto*
                    </label>
                    <asp:DropDownList ID="lbImpacto" runat="server" Enabled="False" OnDataBound="IniciarComponenteLista">
                    </asp:DropDownList>
                    &nbsp;</div>
            </div>
            <div class="row-fluid">
                <div class="span3">
                    <label>
                        Espesor</label>
                    <asp:TextBox runat="server" ID="txtEspesor" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span3">
                    <label>
                        Espesor Ambiente 1*
                    </label>
                    <asp:DropDownList ID="lbEspesor1" runat="server" Enabled="False" OnDataBound="IniciarComponenteLista">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row-fluid">
                <div class="span3">
                    <label>
                        Espesor Ambiente 2*
                    </label>
                    <asp:DropDownList ID="lbEspesor2" runat="server" Enabled="False" OnDataBound="IniciarComponenteLista">
                    </asp:DropDownList>
                    &nbsp;</div>
            </div>
            <div class="row-fluid">
                <div class="span3">
                    <label>
                        Adherencia*
                    </label>
                    <asp:TextBox runat="server" ID="txtAdherencia" CssClass="form-control" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="row-fluid">
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
