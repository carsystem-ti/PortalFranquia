<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="FranquiaEstoque.aspx.cs" Inherits="PortalFranquia.FranquiaEstoque" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
    <link href="../css/kModal.css" rel="stylesheet" />

    <script type="text/javascript" src="../js/jquery.js"></script>
    
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <link href="../css/mensagem.css" rel="stylesheet" />    

<%--    
    <script src="../js/jquery-ui.js"></script>
    <script type="text/javascript" src="../js/mask.js"></script>--%>

    <script type="text/javascript" src="../js/jquery.centralize.js"></script>
    <script type="text/javascript" src="../js/kModal.js"></script>
    <script type="text/javascript" src="../js/jquery.PrintArea.js"></script>
    
        <script type="text/javascript">
            
            $(document).ready(function () {
                
                if ( $(".telaBoleto").html() != null &&  $(".telaBoleto").html().trim() != '')
                    imprimirBoleto();
                 /*        
                jQuery(function ($) {

                    $("#txtdataNota").setMask('date');

                });*/
            });

            function Mensagem(message) {
                $(function () {
                    $("#dialog").html(message);
                    $("#dialog").dialog({
                        title: "Mensagem importante",
                        buttons: {
                            OK: function () {
                                $(this).dialog('close');

                            }
                        },
                        modal: true
                    });
                });
            };
    </script>
    <style>
        .divSomeSelect {
    display: none;
    width: 0%;
}
.selectRowTD td {
    background-color: yellow;
    border-color: orange;
    font-weight: bold;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="dialog" style="display: none; height: 200px; width: 400px;">
        <asp:Label ID="lblmensagem" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </div>    
    <br />
    <div class="Dlabel">
        <asp:RadioButtonList ID="rdbFiltro" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdbFiltro_SelectedIndexChanged" Font-Names="Vrinda" Font-Size="Small" ClientIDMode="Static" Width="1158px">
            <asp:ListItem Value="1">PEDIDOS ABERTOS</asp:ListItem>
            <asp:ListItem Value="2">ENVIADO CADASTRO</asp:ListItem>
            <asp:ListItem Value="3">APROVADO CADASTRO</asp:ListItem>
            <asp:ListItem Value="4">RECUSADO CADASTRO</asp:ListItem>
            <asp:ListItem Value="5">EXPEDIÇÃO</asp:ListItem>
            <asp:ListItem Value="6">EM ENTREGA</asp:ListItem>
            <asp:ListItem Value="7">CONFIRMADO</asp:ListItem>
            <asp:ListItem Value="8">CANCELADO</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <fieldset>
        <legend>Dados</legend>
        <div id="divGrid" runat="server" style="width: 553px">
                <asp:GridView ID="GridPedidosAbertos" runat="server" CellSpacing="-1"
                    ClientIDMode="Static" AutoGenerateColumns="False" EmptyDataText="&nbsp;" Font-Size="Medium" OnRowDataBound="GridPedidosAbertos_RowDataBound" Height="50px" Font-Names="Vrinda" BorderWidth="1px" OnSelectedIndexChanged="GridPedidosAbertos_SelectedIndexChanged" OnPreRender="GridPedidosAbertos_PreRender" AllowPaging="True" PageSize="8" Width="655px" OnPageIndexChanging="GridPedidosAbertos_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="id_pedido" HeaderText="Pedido" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="id_item" HeaderText="Item" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="codigo" HeaderText="Codigo" ItemStyle-CssClass="colDocumento" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle CssClass="colDocumento" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ds_produto" HeaderText="Produto" ItemStyle-CssClass="colNome">
                            <ItemStyle CssClass="colNome" />
                        </asp:BoundField>
                           <asp:BoundField DataField="ds_versao" HeaderText="Versão" ItemStyle-CssClass="colNome">
                            <ItemStyle CssClass="colNome" />
                        </asp:BoundField>
                        <asp:BoundField DataField="qt_compra" HeaderText="Qtde." ItemStyle-CssClass="colContrato" ItemStyle-HorizontalAlign="Center">
                            <ItemStyle CssClass="colContrato" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ds_franquia" HeaderText="Franquia" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dt_pedido" HeaderText="Data" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="total" HeaderText="Total" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ds_usuarioPedido" HeaderText="Usúario" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect">
                            <ItemStyle CssClass="divSomeSelect" />
                        </asp:CommandField>
                    </Columns>
                    <SelectedRowStyle CssClass="selectRowTD" />
                </asp:GridView>
        </div>
    </fieldset>
    <div id="vincular" runat="server" visible="false" style="float:left;margin-left:740px; margin-top: -80px; width: 464px;">
        <div style="float:right;margin-right:50px; width: 435px;">
                <asp:Label ID="Label5" runat="server" Height="16px" Text="Pedido" Width="60px"></asp:Label>
                <asp:Label ID="Label7" runat="server" Height="16px" Text="Versão" Width="44px"></asp:Label>
                <asp:Label ID="Label1" runat="server" Height="16px" Text="Item Pedido" Width="83px"></asp:Label>
                <asp:Label ID="Label3" runat="server" Height="16px" Text="Qtd." Width="61px"></asp:Label>
                <asp:Label ID="Label4" runat="server" Height="18px" Text="ID" Width="91px"></asp:Label>
            </div>
            <div style="float:right; width: 464px;">
                <asp:TextBox ID="txtPedidoCompra" runat="server" Height="16px" Width="58px" ReadOnly="True"></asp:TextBox>
                <asp:TextBox ID="txtVersao" runat="server" Height="16px" Width="23px" ReadOnly="True"></asp:TextBox>
                <asp:TextBox ID="txtPedido" runat="server" Height="16px" Width="84px" ReadOnly="True"></asp:TextBox>
                <asp:TextBox ID="txtQuantidade" runat="server" Height="16px" Width="45px" ReadOnly="True"></asp:TextBox>
                <asp:TextBox ID="TxtPeca" runat="server" Height="16px" Width="71px" OnLoad="TxtPeca_Load" MaxLength="6"></asp:TextBox>
                <asp:Button ID="btnIncluir" runat="server" Text="Incluir" OnClick="btnIncluir_Click" Height="36px" ClientIDMode="Static" OnLoad="btnIncluir_Load" Width="98px" />
            </div>
     </div>
    <div style="float: left; margin-top: 4px; margin-left: 29%">
        <div id="pedidos" runat="server" visible="false">
            <asp:GridView ID="GridPedidos" runat="server" AutoGenerateColumns="False" BackColor="White"
                BorderColor="White" BorderStyle="Solid" Font-Names="Franklin Gothic Book"
                Font-Size="Small" ForeColor="Black" HorizontalAlign="Center" PageSize="8" Width="511px"
                Height="16px" ShowFooter="True" OnDataBound="GridPedidos_DataBound" OnRowDeleting="GridPedidos_RowDeleting" CellSpacing="-1">
                <AlternatingRowStyle BorderColor="DarkCyan" />
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="codigo">
                        <FooterStyle Font-Names="Franklin Gothic Book" Font-Size="Small" />
                        <HeaderStyle Font-Names="Franklin Gothic Book" Font-Size="Small" Font-Strikeout="False"
                            HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Item Pedido" DataField="pedido">
                        <FooterStyle Font-Names="Franklin Gothic Book" Font-Size="Small" />
                        <HeaderStyle Font-Names="Franklin Gothic Book" Font-Size="Small" Font-Strikeout="False"
                            HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="ID/LOC" DataField="peca">
                        <FooterStyle Font-Names="Franklin Gothic Book" Font-Size="Small" HorizontalAlign="Left" />
                        <HeaderStyle Font-Names="Franklin Gothic Book" Font-Size="Small" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:CommandField HeaderText="Excluir" ShowDeleteButton="True" ButtonType="Image"
                        DeleteImageUrl="~/imagens/excluir.png" />
                </Columns>
                <EditRowStyle BorderColor="#B34A06" />
                <EmptyDataRowStyle BorderColor="#628AA2" />
                <FooterStyle BackColor="#CCCCCC" BorderColor="#B34A06" />
                <HeaderStyle BackColor="DarkCyan" BorderColor="#360486" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="DarkCyan" BorderColor="#360486" Font-Names="Franklin Gothic Book"
                    ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BorderColor="#B34A06" />
                <SelectedRowStyle BackColor="DarkCyan" BorderColor="DarkCyan" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" BorderColor="DarkCyan" />
                <SortedAscendingHeaderStyle BackColor="Gray" BorderColor="#B34A06" />
                <SortedDescendingCellStyle BackColor="DarkCyan" />
                <SortedDescendingHeaderStyle BackColor="DarkCyan" />
            </asp:GridView>
        </div>
    </div>
    <div id="finalizar" runat="server" visible="false" style="float: right; margin-top: 5px; margin-right: 45%">
        <asp:Button ID="btnFinaliza" runat="server" Text="Finalizar Distribuição" OnClick="btnFinaliza_Click" Width="219px" />

    </div>
    <div id="DivAprovacaoPedido" runat="server" visible="false" style="float: left; margin-top: 5px; margin-right: 45%; width: 348px;">
        <asp:Button ID="btnAprovarPedido" runat="server" Text="Aprovar Pedido" Width="170px" OnClick="btnAprovarPedido_Click" />
        <asp:Button ID="btnReprovarPedido" runat="server" OnClick="btnReprovarPedido_Click" Text="Reprovar Pedido" Width="157px" />
    </div>
    <div id="DivNumeroNota" runat="server" visible="false" style="float: left; margin-top: 5px; width: 629px;">
        <asp:Label ID="Label6" runat="server" Text="Número da Nota"></asp:Label><asp:TextBox ID="txtNrNota" runat="server"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Text="Serie:"></asp:Label><asp:TextBox ID="txtSerie" runat="server" MaxLength="1" Width="36px"></asp:TextBox>
        <asp:Label ID="Label9" runat="server" Text="Data:"></asp:Label><asp:TextBox ID="txtdataNota" runat="server" Height="22px" Width="78px" ClientIDMode="Static"></asp:TextBox>
        <asp:Button ID="btnVincularNota" runat="server" OnClick="btnVincularNota_Click" Text="Vincular" Width="107px" Height="29px" />
    </div>

    <div style="display:none;">

        <div id="divBoleto" class="telaBoleto" runat="server">

        </div>

    </div>
        <script type="text/javascript">
            /*
            $(document).ready(function () {

                jQuery(function ($) {

                    $("#txtdataNota").setMask('date');

                });
            });*/

            function imprimirBoleto() {

                $('.Cabecalho').remove();
                $('body').css('background-color', 'white');
                /*
                $('#divBoletos td').css('background-color', 'white');

                $('#divBoletos td').css('margin',' 0');
                $('#divBoletos td').css('padding',' 0');
                $('#divBoletos td').css('border',' 0');
                $('#divBoletos td').css('outline',' 0');
                $('#divBoletos td').css('font-weight',' inherit');
                $('#divBoletos td').css('font-style',' inherit');
                $('#divBoletos td').css('font-size',' 100%');
                $('#divBoletos td').css('font-family',' inherit');
                $('#divBoletos td').css('vertical-align',' baseline');

                $.each($('#divBoletos td'), function (index, value) {
                    $(this).addClass('naoComum');
                });
                */

                var iHtmlBoleto = "<div id ='printArea' style='width:921.6px; height:450px;'><div class='impressaoBoleto'>" + $(".Pagina").html() + "</div></div>";

                criaPopup("", true, false, iHtmlBoleto, true, false,
                    function () {
                        $(".telaBoleto").html('');
                    });

                $(".modalPrintImg").click(function (event) {
                    event.stopPropagation();
                    $("#printArea").printArea();
                });
            }
        </script>
</asp:Content>
