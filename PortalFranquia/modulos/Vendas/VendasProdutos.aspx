<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="VendasProdutos.aspx.cs" Inherits="PortalFranquia.modulos.Vendas.Produtos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/mensagem.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/jquery-ui.js"></script>    
    <script src="../../js/mask.js"></script>
    <script  type="text/javascript">
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
            width: 400px;
        }
        .auto-style2 {
            width: 73px;
        }
        .auto-style3 {
            width: 138px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
     <div id="dialog" style="display: none; height: 200px; width: 400px;">
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </div>
    <br />
     <div id="dadosVeiculo" runat="server" style="float: left;">
                            <div style="float: left">
                                <asp:Label ID="Label14" ClientIDMode="Static" runat="server" Text="Placa" CssClass="label"
                                    Width="67px" Height="16px"></asp:Label>
                                <asp:Label ID="Label38" ClientIDMode="Static" runat="server" Text="Ano" CssClass="label"
                                    Width="65px" Height="16px"></asp:Label>
                                <asp:Label ID="Label15" ClientIDMode="Static" runat="server" Text="Fabricante" CssClass="label"
                                    Width="120px" Height="16px"></asp:Label>
                                <asp:Label ID="Label16" ClientIDMode="Static" runat="server" Text="Modelo" CssClass="label"
                                    Width="124px" Height="16px"></asp:Label>
                                <asp:Label ID="Label17" ClientIDMode="Static" runat="server" Text="Cor" CssClass="label"
                                    Width="90px" Height="16px"></asp:Label>
                                <asp:Label ID="Label37" ClientIDMode="Static" runat="server" Text="Tipo" CssClass="label"
                                    Width="109px" Height="16px"></asp:Label>
                                <asp:Label ID="Label39" ClientIDMode="Static" runat="server" Text="Combústivel." CssClass="label"
                                    Width="107px" Height="16px"></asp:Label>
                                <asp:Label ID="Label18" ClientIDMode="Static" runat="server" Text="Chassi" CssClass="label"
                                    Width="89px" Height="18px"></asp:Label>
                                <asp:Label ID="Label19" ClientIDMode="Static" runat="server" Text="Renavam" CssClass="label"
                                    Width="109px" Height="16px"></asp:Label>
                                <asp:Label ID="Label29" ClientIDMode="Static" runat="server" Text="Produtos" CssClass="label"
                                    Width="100px" Height="16px"></asp:Label>
                                <asp:Label ID="Label5" ClientIDMode="Static" runat="server" Text="Vl.Tabela " CssClass="label"
                                    Width="130px" Height="16px"></asp:Label>
                                <asp:Label ID="Label36" ClientIDMode="Static" runat="server" Text="Valor " CssClass="label"
                                    Width="10px" Height="16px"></asp:Label>
                            </div>
                            <br />
                            <div style="float: left">
                                <asp:TextBox ID="txtPlaca" runat="server" Width="61px" Height="23px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="txtPlaca_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="true" Enabled="True" Mask="AAA-9999" TargetControlID="txtPlaca">
                                </asp:MaskedEditExtender>
                                <asp:TextBox ID="txtAno" runat="server" Width="35px" Height="23px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="txtAno_MaskedEditExtender" runat="server"  Enabled="True" Mask="9999" MaskType="Number" TargetControlID="txtAno">
                                </asp:MaskedEditExtender>
                                <asp:DropDownList ID="dropFabricante" runat="server" Height="26px" Width="120px" AutoPostBack="True" DataTextField="ds_fabricante" DataValueField="id_fabricante" OnSelectedIndexChanged="dropFabricante_SelectedIndexChanged"></asp:DropDownList>
                                <asp:DropDownList ID="dropmodelo" runat="server" Height="26px" Width="124px" DataTextField="modelo" DataValueField="id_modelo" AutoPostBack="True" OnSelectedIndexChanged="dropmodelo_SelectedIndexChanged"></asp:DropDownList>
                                <asp:DropDownList ID="dropCores" runat="server" Height="26px" Width="80px" DataTextField="ds_Cor" DataValueField="ds_Cor" AutoPostBack="True"></asp:DropDownList>
                                <asp:TextBox runat="server" ReadOnly="True" Height="20px" Width="110px" ID="txtTipoVeiculo"></asp:TextBox>
                                <asp:DropDownList ID="dropComb" runat="server" Height="26px" Width="110px" Font-Names="Vrinda">
                                    <asp:ListItem>GASOLINA</asp:ListItem>
                                    <asp:ListItem>ALCOOL</asp:ListItem>
                                    <asp:ListItem>DIESEL</asp:ListItem>
                                    <asp:ListItem>FLEX</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtChassi" runat="server" Width="95px" Height="23px"></asp:TextBox>
                                <asp:TextBox ID="txtRenavam" runat="server" Width="99px" Height="23px"></asp:TextBox>
                                <asp:DropDownList ID="dropProdutos" runat="server" Height="26px" Width="156px" DataTextField="ds_produto" OnSelectedIndexChanged="dropProdutos_SelectedIndexChanged" AutoPostBack="true" DataValueField="id_produto"></asp:DropDownList>
                                <asp:TextBox ID="txtValorTabela" runat="server" ReadOnly="true" Width="60px" Height="23px"></asp:TextBox>
                                <asp:TextBox ID="txtValorProduto" ClientIDMode="Static" runat="server" Width="60px" Height="23px"></asp:TextBox>
                                <asp:ImageButton ID="imgAddprodutos" runat="server" ImageUrl="../../imagens/add.png" Height="20px" OnClick="imgAddprodutos_Click" />
                            </div>
                            <br />
                            <br />
                            <div style="float: left">
                                <asp:GridView ID="GridProdutos" runat="server" CellSpacing="-1" ShowFooter="false" Height="50px" Font-Size="X-Small" Width="1100px" AutoGenerateColumns="False" OnRowDataBound="GridProdutos_RowDataBound" OnRowDeleting="GridProdutos_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="id_pedido" HeaderText="Código" />
                                        <asp:BoundField DataField="id_item" HeaderText="Item" />
                                        <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                                        <asp:BoundField DataField="ds_produto" HeaderText="Produto" />
                                        <asp:BoundField DataField="id_modelo" HeaderText="Id-Modelo" />
                                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                                        <asp:BoundField DataField="ds_ano" HeaderText="Cor" />
                                        <asp:BoundField DataField="ds_chassi" HeaderText="Chassi" />
                                        <asp:BoundField DataField="ds_renavan" HeaderText="Renavan" />
                                        <asp:BoundField DataField="vl_unitario" HeaderText="Valor" />
                                        <asp:BoundField DataField="tp_produto" HeaderText="Tipo" />
                                        <asp:BoundField DataField="ds_ano" HeaderText="Ano" />
                                        <asp:BoundField DataField="ds_combustivel" HeaderText="Comb" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/imagens/excluir.png" HeaderText="Excluir" ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <br />
                            </div>
                        </div>
    <table id="habilitarProximo" runat="server">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblct" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium"
                    ForeColor="Red" Text="Nr.Pedido"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="txtpedido" runat="server" Font-Names="Vrinda" Font-Size="Small" Width="123px"
                    ForeColor="Red" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style1">
                <asp:Label ID="lblmensagem" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium"
                    ForeColor="Red" Visible="False"></asp:Label>
            </td>
            <td class="style49">
                <asp:Button ID="btn_avancar" runat="server" CssClass="btnCinza"
                    Text="Avançar &gt;&gt;" Font-Names="Vrinda" Font-Size="Small" PostBackUrl="~/modulos/Vendas/VendasPagamentos.aspx" Enabled="False" />
            </td>
        </tr>
    </table>
</asp:Content>
