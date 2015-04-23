<%@ Page Title="" Language="C#" MasterPageFile="~/APP/master pages/principal.Master"
    AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TS15V2.UI.APP.dev.GestionCliente.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPrincipal" runat="server">
    <%--  Inicio DashBoard--%>
    <div>
        <h1 class="h1">
            Tablero de Control
        </h1>
        <p>
        </p>
        <div style="float: left">
            <div style="width: 400px; margin-left: 30px;">
                <fieldset>
                    <legend><span class="span_Introduccion">Introducci&oacute;n</span></legend>
                    <table>
                        <tr>
                            <td colspan="4">
                                <h2>
                                    SEMILLA</h2>
                            </td>
                        </tr>
                        <tr style="text-align: justify;">
                            <td colspan="4">
                                <span style="text-align: justify;">Lorem ipsum dolor sit amet, consectetuer adipiscing
                                    elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus
                                    et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies
                                    nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec
                                    pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus
                                    ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium.
                                    Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate
                                    eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac,
                                    enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus
                                    viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies
                                    nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus.
                                    Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet
                                    adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit
                                    id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero
                                    venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt.
                                    Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed
                                    consequat, leo eget bibendum sodales, augue velit cursus nunc </span>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <p>
            </p>
            <div style="float: left; margin-left: 30px; width: 400px">
                <fieldset>
                    <legend><span class="span_asignadasami">Asignadas a Mi</span></legend>
                    <input id="gadget-10002-form-isConfigured-pref" type="hidden" class="hidden" value="true"
                        name="up_isConfigured" />
                    <input id="gadget-10002-form-sortColumn-pref" type="hidden" class="hidden" name="up_sortColumn" />
                    <input id="gadget-10002-form-columnNames-pref" type="hidden" class="hidden" value="--Default--"
                        name="up_columnNames" />
                    <input id="gadget-10002-form-num-pref" type="hidden" class="hidden" value="10" name="up_num" />
                    <input id="gadget-10002-form-refresh-pref" type="hidden" class="hidden" value="false"
                        name="up_refresh" />
                    <table style="border: 10px;">
                        <tr>
                            <td>
                                <span>Proyecto</span>
                            </td>
                            <td>
                                <span>Tipo de Actividad</span>
                            </td>
                            <td>
                                <span>Actividad</span>
                            </td>
                            <td>
                                <span>Prioridad</span>
                            </td>
                            <td>
                                <span>Estado</span>
                            </td>
                            <td>
                                <span>Fecha</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a>PRUYEC-1</a>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <div>
                            <span>1</span>-<span>1</span> of <a href="#">1</a>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        <div style="float: right; margin-right: 30px;">
            <fieldset>
                <legend><span class="span_actividadesresientes">Actividades Recientes</span> </legend>
                <input id="Hidden1" type="hidden" class="hidden" value="true" name="up_isConfigured" />
                <input id="Hidden2" type="hidden" class="hidden" name="up_sortColumn" />
                <input id="Hidden3" type="hidden" class="hidden" value="--Default--" name="up_columnNames" />
                <input id="Hidden4" type="hidden" class="hidden" value="10" name="up_num" />
                <input id="Hidden5" type="hidden" class="hidden" value="false" name="up_refresh" />
                <div id="divActividadesProyecto">
                </div>
            </fieldset>
        </div>
    </div>
    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/App.js"></script>
    <script type="text/javascript" src="../Scripts/Proyecto.js"></script>
    <script type="text/javascript" src="../Scripts/Actividades.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.columns-1.0.min.js"></script>
    <script type="text/javascript" src="../Scripts/Principal.js"></script>
    <link href="../Content/App.css" rel="stylesheet" />
</asp:Content>
