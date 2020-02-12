<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="OsServico.aspx.cs" Inherits="PortalFranquia.modulos.OS.OsServico" %>

<%@ Register Src="~/componentes/OS/EncerrarOs.ascx" TagPrefix="uc2" TagName="EncerrarOs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../css/mostraOSAbertas.css" rel="stylesheet" />
    <link href="../../css/kModal.css" rel="stylesheet" />
    <script src="../../js/kModal.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../../js/jquery.centralize.js"></script>
    <script src="../../js/OSsAbertas.js"></script>
    <link href="../../css/OrdemS.css" rel="stylesheet" />
      
    
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap.min.js"></script>

         <script type="text/javascript">
    $("[id*=btnModalPopup]").live("click", function () {
        $("#modal_dialog").dialog({
            title: "jQuery Modal Dialog Popup",
            buttons: {
                Close: function () {
                    $(this).dialog('close');
                }
            },
            modal: true
        });
        return false;
    });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Label ID="lbMensErro" runat="server" Text="" CssClass="mensErro" Visible="true"></asp:Label>
    <asp:Label Text="Informe o Contrato" runat="server" /><br />
     <input type="text"  id="txtPesquisa" runat="server"  placeholder="Número Contrato" name="txtPesquisa" />
        <asp:Button Text="Pesquisar" runat="server" ID="btnPesquisar" OnClick="btnPesquisar_Click"  ClientIDMode="Static"/>
        </div>


        <br />
    <br />
    <br />
     <div id="modal_dialog" style="display: none">
    This is a Modal Background popup
</div>
<asp:Button ID="btnModalPopup" runat="server" Text="Show Modal Popup" />
 
    <div style="height:470px; overflow-y: scroll; width: 100%">
    
  <asp:HiddenField ID="idOSSelecionada" runat="server" ClientIDMode="Static" />
  
     
              
<asp:GridView ID="grid" runat="server"   AutoGenerateColumns="false" Width="99%" CellSpacing="-1">
    <Columns>
        <asp:BoundField DataField="Data" HeaderText="Data" DataFormatString="{0:d}" HeaderStyle-Width="9%">
<HeaderStyle Width="9%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Placa" HeaderText="Placa" HeaderStyle-Width="7%">
<HeaderStyle Width="7%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Contrato" HeaderText="Contrato" HeaderStyle-Width="7%">
<HeaderStyle Width="7%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Cliente" HeaderText="Cliente" HeaderStyle-Width="31%">
<HeaderStyle Width="31%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Veículo" HeaderText="Veículo" HeaderStyle-Width="20%">
<HeaderStyle Width="20%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Instalador" HeaderText="Instalador" HeaderStyle-Width="16%">     
<HeaderStyle Width="16%"></HeaderStyle>
        </asp:BoundField>
        <asp:TemplateField ItemStyle-BorderStyle="None" ItemStyle-BackColor="White" HeaderStyle-Width="10%">
            <ItemTemplate>                
                <asp:ImageButton runat="server" ID="btConfirmaOS" ImageUrl="~/imagens/chamado/salvar.jpg" OnClientClick='<%# Eval("id_OS", "javascript:EncerrarOs({0}); return false;") %>' ToolTip="Encerra a OS"/>
                <asp:ImageButton runat="server" ID="btCancelaOS" ImageUrl="~/imagens/chamado/excluir.jpg" OnClientClick='<%# Eval("id_OS", "javascript:CancelaOS({0}); return false;") %>' ToolTip="Cancela a OS"/>
                <asp:ImageButton runat="server" ID="btTrocaEquipamento" ImageUrl="~/imagens/OS/trocaIcone.jpg" OnClientClick='<%# Eval("id_OS", "javascript:TrocaID({0}") + Eval("id_Equipamento",",{0}); return false;") %>' ToolTip="Troca equipamento"/>
            </ItemTemplate>

<HeaderStyle Width="10%"></HeaderStyle>

<ItemStyle BackColor="White" BorderStyle="None"></ItemStyle>
        </asp:TemplateField>   
    </Columns>
</asp:GridView>
        

           
    <div class="bs-example">
        <!-- Modal HTML -->
        <div  id="poupCepkmMulti" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h3 style="color:#ea8511">PEDIDO  :   </h3>
                    </div>
                    <div class="modal-body">
                        <h2 style="color:#ea8511">CEP ATUAL: <a style="color:black"> </a></h2>
                        <hr style="color:black;background-color:Black;border-width:2px;border-color:black" />
                        <div style="margin-left:20px">
                            <div>
                                <label style="width: 40px; color: black">CEP</label>
                                <input style="width: 76px; height: 28px;color:black" type="text" id="txtCepKM" ng-model="sModel.CepkmTroca" name="txtCepKM" />
                                <input type="button" id="btnCalcular"  class="btn btn-foursquare" value="Calcular" />
                            </div>
                        </div>


                    </div>
                    <div class="modal-footer">
                       
                        <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>

                    </div>
                </div>
            </div>
        </div>
    </div>
                         <asp:Panel ID="pnEncerramentoOs" runat="server" ClientIDMode="Static">
        <uc2:EncerrarOs runat="server" ID="EncerrarOs" />
        
    </asp:Panel>
   </div>
 
</asp:Content>
