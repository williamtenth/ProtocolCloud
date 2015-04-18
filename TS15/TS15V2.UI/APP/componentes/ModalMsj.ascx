<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModalMsj.ascx.cs" Inherits="TS15V2.UI.APP.componentes.ModalMsj" %>
<div class="container">
    <div class="row">
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <script type="text/javascript">
                    function openModal() {
                        $('#myModal').modal('show');
                    }
                </script>
                <!-- Modal -->
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                    aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title" id="myModalLabel">
                                    <asp:Label runat="server" ID="lblTitulo"></asp:Label>
                                </h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label runat="server" ID="lblMensaje">></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
