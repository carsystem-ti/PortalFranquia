<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="AdmBordero.aspx.cs" Inherits="PortalFranquia.modulos.BorderoCheques.AdmBordero" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <link href="../../css/comum.css" rel="stylesheet" />
    <link href="../../css/mensagem.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <link href="../../css/Bordero.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery-ui.js"></script>
    <script type="text/javascript" src="../../js/mask.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../../imagens/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../../imagens/plus.png");
            $(this).closest("tr").next().remove();
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
    <style type="text/css">
        .topleft {
            position: absolute;
            left: 14px;
            margin-left: 3%;
            top: 198px;
            width: 656px;
        }

        .Txtleft {
            position: absolute;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dialog" style="display: none; height: 400px; width: 400px; border: 2px solid #A4B7BB; background-color: #DEEFF1">
    </div>

    <asp:Panel ID="PnlEmployee" runat="server" CssClass="ModalPopup" Style="display: none; color: #59B0B9; background: #59B0B9; border: medium; width: 900px; height: 500px">
        <div id="gDiv">
            <td colspan="2" style="float: right; margin-right: 50%;">
                <asp:ImageButton ID="btnClose" ClientIDMode="Static" runat="server" ImageUrl="~/imagens/excluir.png" />
            </td>
            <br />
            <br />
            <div id="divdetalhes" style="margin-left: 50px; margin-right: 50px">
                <br />
                <br />
                <div>
                    <div style="float: left; margin-top: -45px; height: 246px;">
                        <asp:Label ID="lblretorno" CssClass="descricao" runat="server" Text="OBSERVAÇÕES DO BORDERÔ" Font-Bold="True" Font-Names="VERDANA" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        <br />
                        <br />
                        <br />
                        <table style="color: white;">
                            <tr style="color: white;">
                                <td style="color: white;" class="auto-style2">
                                    <asp:Label ID="lblUsuario" runat="server" Text="Pedido"></asp:Label>
                                </td>
                                <td style="color: white;" class="auto-style2">
                                    <asp:TextBox ID="txtBordero" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="color: white;">
                                <td style="color: white;">
                                    <asp:Label ID="lblUsuario0" runat="server" Text="Usuario"></asp:Label>
                                </td>
                                <td style="color: white;">
                                    <asp:TextBox ID="txtUsuario" ReadOnly="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div style="float: left; margin-left: 25%; margin-top: -40px; height: 33px;">
                            <asp:Button ID="btGravaInf" OnClick="btGravaInf_Click" runat="server" Text="Grava" Width="99px" />
                        </div>
                        <br />
                        <div style="float: left; margin-left: 10px;">
                            <asp:TextBox ID="txtObs" runat="server" Width="800px" Height="82px" TextMode="MultiLine" ViewStateMode="Disabled" Wrap="False"></asp:TextBox>
                            <br />
                            <br />
                            <asp:TextBox ID="txtTodasMensagem" runat="server" Width="800px" Enabled="false" Height="82px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Button ID="btnControl" runat="server" Style="display: none" />
    <asp:ModalPopupExtender ID="PnlEmployee_ModalPopupExtender" runat="server"
        Enabled="True" TargetControlID="btnControl"
        PopupControlID="PnlEmployee" BackgroundCssClass="ModalBackground"
        DropShadow="true" CancelControlID="btnClose">
    </asp:ModalPopupExtender>
    <div style="float: left; width: 553px">
        <asp:Panel ID="painel" runat="server" Width="490px">
            <fieldset style="float: left; width: 574px">
                <legend>Filtros Borderô</legend>
                <div style="float: left; width: 428px;">
                    <asp:Label ID="Label52" runat="server" ClientIDMode="Static" CssClass="label" Height="19px" Text="Consulta" Width="74px" Font-Names="Vrinda" Font-Size="Small"></asp:Label>
                    <asp:Label ID="Label53" runat="server" ClientIDMode="Static" CssClass="label" Height="19px" Text="Digite" Width="99px" Font-Names="Vrinda" Font-Size="Small"></asp:Label>
                    <asp:Label ID="lblstatus" runat="server" ClientIDMode="Static" CssClass="label" Height="19px" Text="Status" Width="99px" Font-Names="Vrinda" Font-Size="Small" Visible="False"></asp:Label>
                </div>
                <br />
                <br />
                <div style="width: 610px">
                    <asp:DropDownList ID="dropSelecao" runat="server" Height="21px" Width="132px" Font-Italic="True" Font-Names="Vrinda" ForeColor="Black" OnSelectedIndexChanged="dropSelecao_SelectedIndexChanged" Font-Size="Small">
                        <asp:ListItem Value="0">Selecione</asp:ListItem>
                        <asp:ListItem Value="1">Nr.Borderô</asp:ListItem>
                        <asp:ListItem Value="2">Pedido</asp:ListItem>
                        <asp:ListItem Value="3">Contrato</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtConsulta" runat="server" Height="21px" Width="83px"></asp:TextBox>
                    <asp:DropDownList ID="dropStatus" runat="server" DataTextField="ds_franquia" DataValueField="id_franquia" Height="25px" Width="86px" Font-Names="Vrinda" Font-Size="Small" Visible="False">
                        <asp:ListItem Value="0">Todos</asp:ListItem>
                        <asp:ListItem Value="1">Aceito</asp:ListItem>
                        <asp:ListItem Value="2">Recusado</asp:ListItem>
                        <asp:ListItem Value="3">Aguardando Aceite</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ImageButton ID="imgBuscar" runat="server" Height="25px" ImageUrl="~/imagens/Bordero/buscar.jpg" OnClick="imgBuscar_Click" Width="69px" />
                </div>
            </fieldset>
        </asp:Panel>
    </div>
    <asp:Panel ID="pnlDados" Visible="false" runat="server">
        <div style="float: right; margin-top: -5%; width: 610px;">
            <asp:ImageButton ID="imgAceite" runat="server" ImageUrl="~/imagens/Bordero/aceite.gif" OnClick="imgAceite_Click" Height="27px" Width="110px" />
            <asp:ImageButton ID="imgRecusar" runat="server" ImageUrl="~/imagens/Bordero/recusar.gif" OnClick="imgRecusar_Click" Width="110px" />
        </div>
    </asp:Panel>
    <br />
    <br />
    <br />
    <br />
    <br />
    <div id="totalizador" runat="server" visible="false" style="float: left">
        <asp:Label ID="Label55" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Franquia:" Width="147px" Font-Names="Vrinda" Font-Size="Small" Font-Bold="True" ForeColor="Red"></asp:Label>
        <asp:Label ID="Label56" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Quantidade" Width="86px" Font-Names="Vrinda" Font-Size="Small" Font-Bold="True" ForeColor="Red"></asp:Label>
        <asp:Label ID="Label57" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Valor Bruto" Width="92px" Font-Names="Vrinda" Font-Size="Small" Font-Bold="True" ForeColor="Red"></asp:Label>
        <asp:Label ID="Label58" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Valor Líquido" Width="109px" Font-Names="Vrinda" Font-Size="Small" Font-Bold="True" ForeColor="Red"></asp:Label>
        <div>
            <asp:TextBox ID="txtFranquia" runat="server" Width="145px" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="Txt_nr_quantidade" runat="server" Width="76px" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="Txt_vl_bruto" runat="server" Width="89px" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="Txt_vl_liquido" runat="server" Width="89px" Enabled="False"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" Height="36px" ImageUrl="~/imagens/relatorios/btn_excel.png" OnClick="ImageButton1_Click" />
        </div>
    </div>
    <br />
    <br />
    <div style="height: 350px; overflow: auto; float: left; width: 1220px;">
        <div style="float: left; width: 1212px;">

            <asp:GridView ID="GvBordero" runat="server" AutoGenerateColumns="False" Font-Names="Arial Narrow"
                Font-Size="10pt" CellSpacing="-1" Width="1201px">
                <Columns>
                    <asp:BoundField DataField="id_pedido" HeaderText="Pedido" />
                    <asp:BoundField DataField="id_bordero" HeaderText="Borderô" />
                    <asp:BoundField DataField="ds_titular" HeaderText="Tit.Cheque" />
                    <asp:BoundField DataField="nr_documento" HeaderText="Cpf_Cnpj" />
                    <asp:BoundField DataField="Nome" HeaderText="Cliente" />
                    <asp:BoundField DataField="nr_contrato" HeaderText="Contrato" />
                    <asp:BoundField DataField="dt_base" HeaderText="Dia Base" />
                    <asp:BoundField DataField="dt_vencimento" HeaderText="Vencimento" />
                    <asp:BoundField DataField="dias" HeaderText="Dias" />
                    <asp:BoundField DataField="nr_banco" HeaderText="Banco" />
                    <asp:BoundField DataField="nr_agencia" HeaderText="Agencia" />
                    <asp:BoundField DataField="nr_conta" HeaderText="Conta" />
                    <asp:BoundField DataField="nr_cheque" HeaderText="Cheque" />
                    <asp:BoundField DataField="nr_ccm7" HeaderText="CMC7" />
                    <asp:BoundField DataField="vl_cheque" HeaderText="Bruto" DataFormatString="{0:#,##0.00;(#,##0.00);0}" />
                    <asp:BoundField DataField="vl_liquido" HeaderText="Liquido" DataFormatString="{0:#,##0.00;(#,##0.00);0}" />
                    <asp:BoundField DataField="ds_status" HeaderText="Status" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkTodos" runat="server" ClientIDMode="Static" AutoPostBack="True" OnCheckedChanged="chkTodos_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelecionar" ClientIDMode="Static" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelecionar_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Obs.">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnLinkView" ClientIDMode="Static" runat="server" OnClick="btnLinkView_Click">Obs</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle Font-Names="Verdana" Font-Size="X-Small" />
                <EmptyDataRowStyle Font-Names="Verdana" Font-Size="X-Small" />
                <FooterStyle Font-Names="Verdana" Font-Size="Small" />
            </asp:GridView>
        </div>
        <div>
        </div>
    </div>

</asp:Content>
