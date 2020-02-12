<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="VendasPagamentos.aspx.cs" Inherits="PortalFranquia.modulos.Vendas.VendasPagamentos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="css/Venda.css" rel="stylesheet" />
    <link href="../../css/mensagem.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/jquery-ui.js"></script>    
    <script src="../../js/mask.js"></script>
    <script  type="text/javascript">

        $(document).ready(function () {

            jQuery(function ($) {

                $("#txtValorProduto").setMask('moeda');
                $("#txtValor").setMask('moeda');
                $("#txtvencimentoCheque").setMask('date');
                
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="dialog" style="display: none; height: 200px; width: 400px;">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </div>
    <div id="divpagamento" runat="server" visible="false" style="float: left" >
                            <div style="float: left;">
                                <asp:Label ID="Label36" ClientIDMode="Static" runat="server" Text="Total operação:" CssClass="label"
                                    Width="106px" Height="21px"></asp:Label>
                                <asp:Label ID="Label4" ClientIDMode="Static" runat="server" Text="Pagamentos" CssClass="label"
                                    Width="120px" Height="16px"></asp:Label>
                                <asp:Label ID="Label35" ClientIDMode="Static" runat="server" Text="Parcelas" CssClass="label"
                                    Width="60px" Height="16px" Enabled="False"></asp:Label>
                                <asp:Label ID="Label27" ClientIDMode="Static" runat="server" Text="Valor" CssClass="label"
                                    Width="73px" Height="16px" Enabled="False"></asp:Label>
                                <asp:Label ID="lblvencimento" ClientIDMode="Static" runat="server" Text="1-Vencimento" CssClass="label"
                                    Width="105px" Height="16px" Enabled="False" Visible="False"></asp:Label>
                                <asp:Label ID="lbltitular" ClientIDMode="Static" runat="server" Text="Titular" CssClass="label"
                                    Width="183px" Height="19px" Enabled="False" Visible="False"></asp:Label>
                                <asp:Label ID="lbldoc" runat="server" ClientIDMode="Static" CssClass="label" Enabled="False" Height="18px" Text="CNPJ/CPF" Visible="False" Width="123px"></asp:Label>
                                <asp:Label ID="lblLeitura" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Leitura" Visible="False" Width="76px"></asp:Label>
                                <asp:CheckBox runat="server" AutoPostBack="True" Font-Size="Small" Text="Manual " ForeColor="Red" ID="chkLeitora" Visible="False" OnCheckedChanged="chkLeitora_CheckedChanged"></asp:CheckBox>
                            </div>
                            <br />
                            <br />
                            <div style="float: left">
                                <asp:TextBox ID="txtTotalOperacao" runat="server" Width="97px" Height="18px" ClientIDMode="Static" Enabled="False" ReadOnly="True"></asp:TextBox>
                                <asp:DropDownList ID="dropForma" runat="server" AutoPostBack="True" DataTextField="ds_pagamento" DataValueField="id_forma" Height="24px" OnSelectedIndexChanged="dropForma_SelectedIndexChanged" Width="145px">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtQtdParcela" runat="server" Height="18px" Width="40px" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtValor" runat="server" ClientIDMode="Static" Width="72px" Height="18px"></asp:TextBox>
                                <asp:TextBox ID="txtvencimentoCheque" runat="server" Width="97px" Height="18px" Visible="False" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtTitular" runat="server" Height="18px" Visible="False" Width="179px"></asp:TextBox>
                                <asp:TextBox ID="txtDocumento"  runat="server" Height="18px" Visible="False" Width="115px"></asp:TextBox>
                                <asp:TextBox ID="txtLeitura" runat="server" AutoPostBack="True" Height="16px" Visible="False" Width="280px"></asp:TextBox>
                                <asp:ImageButton ID="imgPagamento" runat="server" Height="20px" ImageUrl="~/imagens/add.png" OnClick="imgPagamento_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                            <br />
                            <br />
                            <div id="lblcheques" runat="server" visible="False" style="width: 1202px; float: left">
                                <asp:Label ID="lblAgencia" runat="server" ClientIDMode="Static" CssClass="label" Enabled="False" Height="18px" Text="Agencia" Visible="False" Width="65px"></asp:Label>
                                <asp:Label ID="lblconta" runat="server" ClientIDMode="Static" CssClass="label" Enabled="False" Height="16px" Text="Conta" Visible="False" Width="136px"></asp:Label>
                                <asp:Label ID="lblnrcheque" runat="server" ClientIDMode="Static" CssClass="label" Enabled="False" Height="16px" Text="Cheque" Visible="False" Width="100px"></asp:Label>
                                <asp:Label ID="lblbanco" runat="server" ClientIDMode="Static" CssClass="label" Enabled="False" Height="16px" Text="Banco" Visible="False" Width="91px"></asp:Label>
                            </div>
                            <br />
                            <div id="txtCheques" style="float: left" runat="server" visible="False">
                                <asp:TextBox ID="txtAgencia" runat="server" Height="16px" Visible="False" Width="57px"></asp:TextBox>
                                <asp:TextBox ID="txtConta" runat="server" Height="16px" Visible="False" Width="127px"></asp:TextBox>
                                <asp:TextBox ID="txtNrCheque" runat="server" Height="16px" Visible="False" Width="92px"></asp:TextBox>
                                <asp:TextBox ID="txtBanco" runat="server" Height="16px" Visible="False" Width="75px"></asp:TextBox>
                            </div>
                            <br />
                            <br />
                            <div id="pagamento" runat="server" style="float: left">
                                <asp:GridView ID="gridPagamento" runat="server" AutoGenerateColumns="False" CellSpacing="-1" EmptyDataText="&nbsp;" Font-Size="X-Small" Height="16px" OnRowDeleting="gridPagamento_RowDeleting" Width="1110px" OnRowDataBound="gridPagamento_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="id_pedido" HeaderText="Pedido" />
                                         <asp:BoundField DataField="id_pagamento" HeaderText="Código" />
                                        <asp:BoundField DataField="ds_pagamento" HeaderText="Pagamento" />
                                        <asp:BoundField DataField="pc_pagamento" HeaderText="Parcela" />
                                        <asp:BoundField DataField="vl_pagamento" HeaderText="Valor" />
                                        <asp:BoundField DataField="dt_vencimento" HeaderText="Vencimento" />
                                        <asp:BoundField DataField="ds_titular" HeaderText="Titular" />
                                        <asp:BoundField DataField="nr_agencia" HeaderText="Agencia" />
                                        <asp:BoundField DataField="nr_conta" HeaderText="Conta" />
                                        <asp:BoundField DataField="nr_documento" HeaderText="Documento" />
                                        <asp:BoundField DataField="nr_cheque" HeaderText="Cheque" />
                                        <asp:BoundField DataField="nr_Banco" HeaderText="Banco" />
                                        <asp:BoundField DataField="nr_ccm7" HeaderText="ccm" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/imagens/excluir.png" HeaderText="Excluir" ShowDeleteButton="True" />
                                    </Columns>
                                    <EditRowStyle Font-Size="Small" />
                                    <EmptyDataRowStyle Font-Size="Small" />
                                    <FooterStyle Font-Size="Small" />
                                    <HeaderStyle Font-Size="Small" />
                                    <SelectedRowStyle CssClass="selectRowTD" />
                                </asp:GridView>
                            </div>
                        </div>
    <br />
    <br />
    <br />
   <table id="habilitarProximo" runat="server"  class="style43">
        <tr>
            <td class="style45">
                <asp:Label ID="lblct" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium"
                    ForeColor="Red" Text="Nr.Pedido"></asp:Label>
            </td>
            <td class="style46">
                <asp:TextBox ID="txtpedido" runat="server" Font-Names="Vrinda" Font-Size="Small" Width="123px"
                    ForeColor="Red" Enabled="False"></asp:TextBox>
            </td>
            <td class="style49">
                <asp:Button ID="btn_avancar" runat="server" CssClass="btnCinza" PostBackUrl="~/modulos/Vendas/Contratos.aspx"
                    Text="Avançar &gt;&gt;" Font-Names="Vrinda" Font-Size="Small" OnClick="btn_avancar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
