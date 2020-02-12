<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Contratos.aspx.cs" Inherits="PortalFranquia.modulos.Vendas.Contratos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="css/Venda.css" rel="stylesheet" />
    <link href="../../css/mensagem.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/jquery-ui.js"></script>    
    <script src="../../js/mask.js"></script>
    <script  type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../imagens/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../imagens/plus.png");
            $(this).closest("tr").next().remove();
        });
        $(document).ready(function () {

            jQuery(function ($) {

                $("#txtValorProduto").setMask('moeda');
                $("#txtValor").setMask('moeda');
            });
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
    <style type="text/css">
        .auto-style1 {
            width: 70px;
        }
        .auto-style2 {
            width: 133px;
        }
        .auto-style3 {
            width: 337px;
        }
        .auto-style4 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="dialog" style="display: none; height: 200px; width: 400px;">
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </div>
       <div style="float: left">
                            <asp:GridView ID="GridContrato" runat="server" CellSpacing="-1" Height="20px" Width="900px" Font-Size="Small" AutoGenerateColumns="False" DataKeyNames="id_pedido" OnRowDataBound="GridContrato_RowDataBound" OnPreRender="GridContrato_PreRender" OnRowDeleting="GridContrato_RowDeleting">
                                <Columns>
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                            <img alt="" style="cursor: pointer" src="../../imagens/plus.png"/>
                                            <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                                                <asp:GridView ID="gvOrders" Width="600px" runat="server" AutoGenerateColumns="false"
                                                    CssClass="Grid" HorizontalAlign="Left">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:BoundField ItemStyle-Width="150px" DataField="id_pedido" HeaderText="Pedido" />
                                                        <asp:BoundField ItemStyle-Width="200px" DataField="id_item" HeaderText="Item" />
                                                        <asp:BoundField ItemStyle-Width="150px" DataField="ds_placa" HeaderText="Placa" />
                                                        <asp:BoundField ItemStyle-Width="150px" DataField="nr_contrato" HeaderText="Contrato" />
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="id_pedido" HeaderText="Pedido" />
                                    <asp:BoundField DataField="ds_franquia" HeaderText="Franquia" />
                                    <asp:BoundField DataField="ds_cliente" HeaderText="Cliente" />
                                    <asp:BoundField DataField="cd_vendedor" HeaderText="Vendedor" />
                                    <asp:BoundField DataField="ds_documento" HeaderText="CPF" />
                                    <asp:BoundField DataField="nr_rg" HeaderText="RG" />
                                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/imagens/contrato.jpg" HeaderText="Gerar Contrato" ShowDeleteButton="True" />
                                </Columns>
                            </asp:GridView>
                            <br />
                        </div>
    <table id="habilitarProximo" runat="server"  class="style43">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblct" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium"
                    ForeColor="Red" Text="Nr.Pedido"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtpedido" runat="server" Font-Names="Vrinda" Font-Size="Small" Width="123px"
                    ForeColor="Red" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="lblmensagem" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium"
                    ForeColor="Red" Visible="False"></asp:Label>
            </td>
            <td class="style49">
                <asp:Button ID="btn_avancar" runat="server" CssClass="btnCinza" PostBackUrl="~/MeusPedidosVendas.aspx"
                    Text="Meus Pedidos &gt;&gt;" Font-Names="Vrinda" Font-Size="Small" />
            </td>
        </tr>
    </table>
     <table id="erro" runat="server" visible="true" class="auto-style4">
         <tr>
             <td>
                <asp:Label ID="lblerro" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium"
                    ForeColor="Red" Text="erro"></asp:Label>
             </td>
         </tr>
     </table>
    <br />
    <br />

</asp:Content>
