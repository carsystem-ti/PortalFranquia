<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="AdmFranquia.aspx.cs" Inherits="PortalFranquia.AdmFranquia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

    <link href="../css/mensagem.css" rel="stylesheet" />
    <link href="../css/detalhesCompras.css" rel="stylesheet" />
    <link href="../css/kModal.css" rel="stylesheet" />

    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.js" type="text/javascript"></script>

    <script src="../js/jquery.centralize.js"></script>
    <script src="../js/kModal.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            /*
            jQuery(function ($) {

                $("#txtValorProduto").setMask('moeda');
                $("#txtValor").setMask('moeda');
            });*/
        });
        function ShowPopup(message) {
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dialog" style="display: none; height: 400px; width: 400px; border: 2px solid #A4B7BB; background-color: #DEEFF1">
    </div>
    <div style="float: left; margin-left: 5%">
        &nbsp;<fieldset style="width: 589px; height: 83px">
            <legend style="width: 544px">Selecione o Filtro
            </legend>
            <div class="Dlabel">
                <asp:Label ID="Label16" runat="server" Height="16px" Text="Data Inicial" Width="107px"></asp:Label>
                <asp:Label ID="Label17" runat="server" Height="17px" Text="Data Final" Width="148px"></asp:Label>
                <asp:Label ID="lblFranquia" runat="server" Height="17px" Text="Data Final" Width="148px"></asp:Label>
                </div>
            <div class="selecao">
                <asp:TextBox ID="txtInicial" runat="server" Height="19px" Width="95px"></asp:TextBox>
                <asp:MaskedEditExtender ID="txtInicial_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Number" TargetControlID="txtInicial">
                </asp:MaskedEditExtender>
                <asp:TextBox ID="TxtFinal" runat="server" Height="19px" Width="94px"></asp:TextBox>
                <asp:MaskedEditExtender ID="TxtFinal_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Number" TargetControlID="TxtFinal">
                </asp:MaskedEditExtender>
                <asp:DropDownList ID="dropfranquias" runat="server" DataTextField="ds_franquia" DataValueField="id_franquia" Height="24px" Width="203px">
                </asp:DropDownList>
                <asp:Button ID="btnPesquisar" runat="server" Font-Bold="True" Height="31px" Text="Pesquisar" Width="125px" ClientIDMode="Static" OnClick="btnPesquisar_Click" />
            </div>
        </fieldset>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
            <br />
            <div style="float: left; margin-left: 10%">
                <asp:GridView ID="gridContrato" runat="server" ClientIDMode="Static" DataKeyNames="id_pedido" CssClass="Compras" HeaderStyle-CssClass="AnaliticoHeader" CellSpacing="-1" Height="20px" Width="900px" Font-Size="Large" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gridContrato_PageIndexChanging" OnPreRender="gridContrato_PreRender" OnSelectedIndexChanged="gridContrato_SelectedIndexChanged" Font-Names="Verdana">
                    <Columns>
                        <asp:BoundField DataField="id_pedido" HeaderText="Pedido">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ds_franquia" HeaderText="Franquia" />
                        <asp:BoundField DataField="id_produto" HeaderText="codigo" />
                        <asp:BoundField DataField="ds_produto" HeaderText="Produto" />
                        <asp:BoundField DataField="ds_status" HeaderText="Status" />
                        <asp:BoundField DataField="ds_usuarioPedido" HeaderText="Usuario" />
                        <asp:BoundField DataField="qt_compra" HeaderText="Qtde">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="valor" DataFormatString="{0:###,###,##0.00}" HeaderText="Valor">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Detalhes">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnLinkView" runat="server" OnClick="btnLinkView_Click">Detalhes</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="AnaliticoHeader"></HeaderStyle>
                </asp:GridView>
            </div>
            <br />
            <asp:Panel ID="PnlEmployee" runat="server" CssClass="ModalPopup" Style="display: none; width: 600px; height: 400px">
                <div id="gDiv">
                    <td colspan="2" style="float: left; margin-left: 50%">
                        <asp:ImageButton ID="btnClose" ClientIDMode="Static" runat="server" ImageUrl="~/imagens/excluir.png" />
                    </td>
                    <br />
                    <br />
                    <div style="float: left; margin-left: 10%">
                        <asp:Label ID="lblmensagem" runat="server" Text="Label" Font-Bold="True" Font-Names="VERDANA" Font-Size="Small" ForeColor="Red"></asp:Label>
                    </div>
                    <div id="divdetalhes" style="margin-left: 50px; margin-right: 50px">
                        <br />
                        <br />
                        <asp:GridView ID="GridDetalhes" runat="server" ClientIDMode="Static" AutoGenerateColumns="False" CssClass="Compras" HeaderStyle-CssClass="AnaliticoHeader" Width="491px" Font-Names="Verdana" Font-Size="Medium" OnPreRender="GridDetalhes_PreRender">
                            <Columns>
                                <asp:BoundField DataField="id_pedido" HeaderText="Pedido" />
                                <asp:BoundField DataField="ds_franquia" HeaderText="Franquia" />
                                <asp:BoundField DataField="ds_franquia" HeaderText="Franquia" />
                                <asp:BoundField DataField="id_produto" HeaderText="Código" />
                                <asp:BoundField DataField="ds_produto" HeaderText="Produto" />
                                <asp:BoundField DataField="id_Sbc" HeaderText="ID" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:Panel>
            <asp:Button ID="btnControl" runat="server" Style="display: none" />
            <asp:ModalPopupExtender ID="PnlEmployee_ModalPopupExtender" runat="server"
                DynamicServicePath="" Enabled="True" TargetControlID="btnControl"
                PopupControlID="PnlEmployee" BackgroundCssClass="ModalBackground"
                DropShadow="true" CancelControlID="btnClose">
            </asp:ModalPopupExtender>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
