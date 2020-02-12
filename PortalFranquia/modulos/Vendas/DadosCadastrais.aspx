<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="DadosCadastrais.aspx.cs" Inherits="PortalFranquia.modulos.Vendas.DadosCadastrais" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/Venda.css" rel="stylesheet" />
    <link href="../../css/mensagem.css" rel="stylesheet" />
     <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.js"></script>    
    <script type="text/javascript" src="../../js/mask.js"></script>
    <script  type="text/javascript">
        $(document).ready(function () {

            jQuery(function ($) {

                $("#txtdtNascimento").setMask('date');
                
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
            width: 112px;
        }
        .auto-style2 {
            width: 71px;
        }
        .auto-style3 {
            width: 408px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="dialog" style="display: none; height: 200px; width: 400px;">
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </div>
    <div style="float: left">
        <asp:RadioButtonList ID="rdbTpPessoa" runat="server" AutoPostBack="True" Width="156px" Font-Size="Small" Font-Bold="True" Font-Names="Verdana" OnSelectedIndexChanged="rdbTpPessoa_SelectedIndexChanged">
            <asp:ListItem Value="0">PESSOA FÍSICA</asp:ListItem>
            <asp:ListItem Value="1">PESSOA JURÍDICA</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div id="ConsultaCpf" runat="server" visible="false" style="float: left; margin-left: 5%; width: 439px;">
        <asp:Label ID="lbldocumento" runat="server" Height="25px" Text="CPF" Width="35px" CssClass="label" Font-Bold="True"></asp:Label><asp:TextBox ID="txtCpf" runat="server" Height="20px"></asp:TextBox>
        <asp:MaskedEditExtender ID="txtCpf_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False"  CultureName="en-US" Enabled="True" Mask="999.999.999-99" TargetControlID="txtCpf">
        </asp:MaskedEditExtender>
        <asp:Button ID="btnPesquisar" runat="server" Height="29px" Text="Pesquisar" OnClick="btnPesquisar_Click" />
    </div>
    <div id="ConsultaCnpj" runat="server" visible="false" style="float: left; margin-left: 5%; width: 439px;">
        <asp:Label ID="Label1" runat="server" Height="25px" Text="CNPJ" Width="35px" CssClass="label" Font-Bold="True" Font-Italic="False"></asp:Label><asp:TextBox ID="txtCnpj" runat="server" Height="20px"></asp:TextBox>
        <asp:MaskedEditExtender ID="txtCnpj_MaskedEditExtender" runat="server" CultureName="en-US" Enabled="True" Mask="99.999.999/9999-99" TargetControlID="txtCnpj" ClearMaskOnLostFocus="False">
        </asp:MaskedEditExtender>
        <asp:Button ID="btnCnpj" runat="server" Height="29px" Text="Pesquisar" OnClick="btnCnpj_Click" />
    </div>
    <div id="filtroAprovacao" runat="server" visible="false" style="float: right; margin-left: 40%; margin-top: -40px; width: 627px; height: 53px;">
        <asp:RadioButton ID="rdbAprovado" CssClass="aprovado" runat="server" Text="APROVADO" Font-Size="Small" Visible="False" AutoPostBack="True" OnCheckedChanged="rdbAprovado_CheckedChanged" />
        <asp:RadioButton ID="rdbReprovado" CssClass="reprovado" runat="server" Text="REPROVADO" Visible="False" AutoPostBack="True" OnCheckedChanged="rdbReprovado_CheckedChanged" />
        <asp:RadioButton ID="rdbanalise" CssClass="analise" runat="server" Text="ANÁLISE MANUAL" Visible="False" />
    </div>
    <div id="dadoscliente" runat="server" visible="false">
        <div style="float: left; width: 1055px;">
            <asp:Label ID="Label25" runat="server" Text="Cod.Consulta" ClientIDMode="Static" Height="16px" Width="87px" CssClass="label"></asp:Label>
            <asp:Label ID="Label20" ClientIDMode="Static" runat="server" Text="Data" Width="100px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label22" ClientIDMode="Static" runat="server" Text="Resultado"
                Width="82px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label3" ClientIDMode="Static" runat="server" Text="Cliente" Width="223px" Height="17px" CssClass="label"></asp:Label>
            <asp:Label ID="Label2" ClientIDMode="Static" runat="server" Text="Residencial"
                Width="115px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label6" ClientIDMode="Static" runat="server" Text="Celular"
                Width="103px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label7" ClientIDMode="Static" runat="server" Text="Comercial"
                Width="103px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label8" ClientIDMode="Static" runat="server" Text="Profisão"
                Width="145px" Height="16px" CssClass="label"></asp:Label>

            <asp:Label ID="Label23" ClientIDMode="Static" runat="server" Text="E-mail"
                Width="70px" Height="16px" CssClass="label"></asp:Label>
        </div>
        <br />
        <br />
        <div style="float: left;">
            <asp:TextBox ID="txtCodigoConsulta" runat="server" Width="66px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtData" runat="server" Width="89px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtResultado" runat="server" Width="81px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtNome" runat="server" Width="208px" Height="20px" ClientIDMode="Static" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="TxtResidencial" runat="server" Width="100px" Height="20px"></asp:TextBox>
            <asp:MaskedEditExtender ID="TxtResidencial_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="TxtResidencial">
            </asp:MaskedEditExtender>
            <asp:TextBox ID="txtCelular" runat="server" Width="100px" Height="20px"></asp:TextBox>
            <asp:MaskedEditExtender ID="txtCelular_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)99999-9999" TargetControlID="txtCelular">
            </asp:MaskedEditExtender>
            <asp:TextBox ID="txtComercial" runat="server" Width="100px" Height="20px"></asp:TextBox>
            <asp:MaskedEditExtender ID="txtComercial_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="txtComercial">
            </asp:MaskedEditExtender>
            <asp:DropDownList ID="dropProfisao" runat="server" DataTextField="ds_profissao" DataValueField="cd_profissao" Height="23px" Width="130px">
            </asp:DropDownList>
            <asp:TextBox ID="txtEmail" runat="server" Width="147px" Height="20px"></asp:TextBox>

        </div>
    </div>
    <br />
    <br />
    <br />
    <div id="dadosclienteComplementares" runat="server" visible="False">
        <div style="float: left; width: 1055px;">
            <asp:Label ID="Label47" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="RG" Width="131px"></asp:Label>
            <asp:Label ID="Label9" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Data Nascimento" Width="152px"></asp:Label>
            <asp:Label ID="Label49" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Sexo" Width="119px"></asp:Label>
            <asp:Label ID="Label11" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Mídia" Width="82px"></asp:Label>
        </div>
        <br />
        <br />
        <div style="float: left;">
            <asp:TextBox ID="txtRG" runat="server" Height="20px" Width="125px"></asp:TextBox>
            <asp:TextBox ID="txtdtNascimento" runat="server" Height="20px" Width="125px" ClientIDMode="Static"></asp:TextBox>
            <asp:DropDownList ID="dropSexo" runat="server" DataTextField="ds_Ocupacao" DataValueField="cd_Ocupacao" Height="23px" Width="130px">
                <asp:ListItem Value="M">Masculino</asp:ListItem>
                <asp:ListItem Value="F">Feminino</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="dropMidia" runat="server" DataTextField="ds_midia" DataValueField="id_midia" Height="23px" Width="130px">
            </asp:DropDownList>
            <asp:ImageButton ID="imgAvancarCliente" runat="server" Height="21px" ImageUrl="~/imagens/ativar.png" OnClick="imgAvancarCliente_Click" Width="47px" />
            <asp:ImageButton ID="imgEditCliente" runat="server" Height="21px" ImageUrl="~/imagens/b_edit.png" OnClick="imgEditCliente_Click" Visible="False" Width="61px" />
        </div>
    </div>
    <br />
    <br />
    <div id="dadosresidencial" style="float: left;" runat="server" visible="false">
                            <div style="float: left; height: 26px;">
                                <asp:Label ID="Label40" ClientIDMode="Static" runat="server" CssClass="label" Text="Cep"
                                    Width="65px" Height="16px"></asp:Label>
                                <asp:Label ID="Label41" ClientIDMode="Static" runat="server" CssClass="label" Text="Endereco"
                                    Width="233px" Height="16px"></asp:Label>
                                <asp:Label ID="Label42" ClientIDMode="Static" runat="server" CssClass="label" Text="Nr."
                                    Width="117px" Height="16px"></asp:Label>
                                <asp:Label ID="Label43" ClientIDMode="Static" runat="server" Text="Complemento"
                                    Width="218px" Height="17px" CssClass="label"></asp:Label>
                                <asp:Label ID="Label44" ClientIDMode="Static" CssClass="label" runat="server" Text="Bairro"
                                    Width="170px" Height="21px"></asp:Label>
                                <asp:Label ID="Label45" ClientIDMode="Static" runat="server" CssClass="label" Text="Cidade"
                                    Width="166px" Height="16px"></asp:Label>
                                <asp:Label ID="Label46" ClientIDMode="Static" runat="server" CssClass="label" Text="UF"
                                    Width="103px" Height="16px"></asp:Label>
                            </div>
                            <br />
                            <br />
                            <div style="float: left">
                                <asp:TextBox ID="txtCep" runat="server" Width="71px" Height="20px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="txtCep_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99999-999" TargetControlID="txtCep">
                                </asp:MaskedEditExtender>
                                <asp:ImageButton ID="imgCep" runat="server" Height="24px" ImageUrl="~/imagens/buscar.png" OnClick="imgCep_Click" />
                                <asp:TextBox ID="txtEndereco" runat="server" Width="231px" Height="20px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="txtnr" runat="server" Width="42px" Height="20px"></asp:TextBox>
                                <asp:TextBox ID="txtComplemento" runat="server" Width="210px" Height="20px"></asp:TextBox>
                                <asp:TextBox ID="txtBairro" runat="server" Width="157px" Height="20px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="txtCidade" runat="server" Width="157px" Height="20px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="txtUf" runat="server" Width="96px" Height="20px" ReadOnly="True"></asp:TextBox>
                                <asp:ImageButton ID="imgEndereco" runat="server" Height="18px" ImageUrl="~/imagens/ativar.png" OnClick="imgEndereco_Click" Width="47px" />
                                <asp:ImageButton ID="imgEditEndereco" runat="server" ImageUrl="~/imagens/b_edit.png" OnClick="imgEditEndereco_Click" Visible="False" Height="20px" Width="61px" />
                            </div>
                        </div>
    <table id="habilitarProximo" runat="server" visible="false" class="style43">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblct" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium"
                    ForeColor="Red" Text="Nr.Pedido"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:TextBox ID="txtpedido" runat="server" Font-Names="Vrinda" Font-Size="Small" Width="123px"
                    ForeColor="Red" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:Label ID="lblmensagem" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium"
                    ForeColor="Red" Visible="False"></asp:Label>
            </td>
            <td class="style48">
                <asp:Button ID="btn_confirmar" runat="server" CssClass="btnAzul" Text="Confirmar"
                    OnClick="btn_confirmar_Click" Font-Names="Vrinda" Font-Size="Small" Height="36px" />
            </td>
            <td class="style49">
                <asp:Button ID="btn_avancar" runat="server" CssClass="btnCinza" PostBackUrl="~/modulos/Vendas/VendasProdutos.aspx"
                    Text="Avançar &gt;&gt;" Font-Names="Vrinda" Font-Size="Small" Enabled="False" />
            </td>
        </tr>
    </table>
</asp:Content>
