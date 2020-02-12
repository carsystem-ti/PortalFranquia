<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Bordero.aspx.cs" EnableEventValidation="false" Inherits="PortalFranquia.modulos.BorderoCheques.Bordero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/mensagem.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <link href="../../css/Bordero.css" rel="stylesheet" />
    <script src="../../js/jquery-ui.js"></script>    
    <script src="../../js/mask.js"></script>
    <script type="text/javascript">
        function ShowPopup(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Mensagem importante",
                    buttons: {
                        OK: function () {
                            $(this).dialog('close');
                            location.href = "FranquiaPedido.aspx";
                        }
                    },
                    modal: true
                });
            });
        };
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
    <div id="dialog" style="display: none; height: 600px; width: 600px; border: 2px solid #A4B7BB; background-color: #DEEFF1">
    </div>
    <div>
        <asp:Panel ID="Panel1" runat="server" Width="1144px">
            <div style="float: left; width: 1220px;">
                <asp:Label ID="Label52" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Base" Width="99px" ForeColor="#FF3300"></asp:Label>
                <asp:Label ID="Label47" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Total Cheques" Width="99px"></asp:Label>
                <asp:Label ID="Label51" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Valor Total " Width="88px"></asp:Label>
                <asp:Label ID="Label9" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Qtd." Width="96px"></asp:Label>
                <asp:Label ID="Label49" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Desconto" Width="95px"></asp:Label>
                <asp:Label ID="Label11" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Valor Bruto" Width="106px"></asp:Label>
                <asp:Label ID="Label50" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Valor Liquido" Width="97px"></asp:Label>
                <asp:CheckBox ID="chkTroca" runat="server" AutoPostBack="True" OnCheckedChanged="chkTroca_CheckedChanged" Text="   Troca" />
            </div>
            <br />
            <div style="float: left;">
                <asp:TextBox ID="txtDataBase" runat="server" Height="20px" Width="96px"></asp:TextBox>
                <asp:TextBox ID="txtTotalGeral" runat="server" Height="20px" Width="96px"></asp:TextBox>
                <asp:TextBox ID="txtValorGeral" runat="server" Enabled="False" Height="20px" Width="82px"></asp:TextBox>
                <asp:TextBox ID="txtTotalSelecionada" runat="server" Height="20px" Width="92px" ClientIDMode="Static">0</asp:TextBox>
                <asp:TextBox ID="txtDesconto" runat="server" ClientIDMode="Static" Height="20px" Width="92px">0</asp:TextBox>
                <asp:TextBox ID="txtBruto" runat="server" ClientIDMode="Static" Height="20px" Width="92px"></asp:TextBox>
                <asp:TextBox ID="txtLiquido" runat="server" ClientIDMode="Static" Height="20px" Width="92px"></asp:TextBox>
            </div>
        </asp:Panel>
    </div>
    <div id="divBotao" runat="server" visible="false" style="float: left; margin-left: 60%; margin-top: -29px; width: 457px;">
        <asp:Button ID="btnFinalizar" runat="server" OnClick="btnFinalizar_Click" Text="GERAR BORDERÔ" ForeColor="Black" Width="226px" />
        <asp:Button ID="btnAdmFranquia" runat="server" ForeColor="Black" OnClick="btnAdmFranquia_Click" Text="ADM Franquia" Width="204px" />
    </div>
    <br />
    <br />
    <br />

    <div style="height: 350px; overflow: auto;">
        <div>

            <asp:GridView ID="GridBordero" runat="server" CellSpacing="-1" Height="5px" Width="100%" Font-Size="X-Small" CssClass="grdViewOrders" AutoGenerateColumns="False" DataKeyNames="id_pedido" Font-Names="Verdana">
                <AlternatingRowStyle Font-Names="Verdana" Font-Size="X-Small" />
                <Columns>
                    <asp:BoundField DataField="id_pedido" HeaderText="Pedido">
                        <ItemStyle HorizontalAlign="Left" CssClass="DataCell"></ItemStyle>
                        <HeaderStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:#,##0.00;(#,##0.00);0}" />
                    <asp:BoundField DataField="Vencimento" HeaderText="Vencimento" />
                    <asp:BoundField DataField="Contrato" HeaderText="Contrato" />
                    <asp:BoundField DataField="Titular" HeaderText="Titular" />
                    <asp:BoundField DataField="nr_documento" HeaderText="Documento" />
                    <asp:BoundField DataField="Banco" HeaderText="Banco" />
                    <asp:BoundField DataField="nr_conta" HeaderText="Conta" />
                    <asp:BoundField DataField="Agencia" HeaderText="Agencia" />
                    <asp:BoundField DataField="Cheque" HeaderText="Cheque" />
                    <asp:BoundField DataField="Base" HeaderText="Base" />
                    <asp:BoundField DataField="Taxa" HeaderText="Taxa" />
                    <asp:BoundField DataField="Juros" HeaderText="Juros" DataFormatString="{0:#,##0.00;(#,##0.00);0}" />
                    <asp:BoundField DataField="vlLiquido" HeaderText="Valor Liquido" DataFormatString="{0:#,##0.00;(#,##0.00);0}" />
                    <asp:BoundField DataField="CMC7" HeaderText="CMC7" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkTodos" runat="server" ClientIDMode="Static" AutoPostBack="True" OnCheckedChanged="chkTodos_CheckedChanged" OnLoad="chkTodos_Load" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelecionar" ClientIDMode="Static" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelecionar_CheckedChanged" OnLoad="chkSelecionar_Load" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle Font-Names="Verdana" Font-Size="X-Small" />
                <EmptyDataRowStyle Font-Names="Verdana" Font-Size="X-Small" />
                <FooterStyle Font-Names="Verdana" Font-Size="X-Small" />
                <HeaderStyle Font-Size="X-Small" />
            </asp:GridView>

        </div>
    </div>

</asp:Content>
