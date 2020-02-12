<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="WebVendas.aspx.cs" Inherits="PortalFranquia.WebVendas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Venda.css" rel="stylesheet" />
       <link href="css/Venda.css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>    
    <link href="css/mensagem.css" rel="stylesheet" />
    <script type="text/javascript" src="js/mask.js"></script>
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
    </script>
    <style type="text/css">
        #dadosresidencial
        {
            height: 62px;
        }

        #dadosVeiculo
        {
            height: 59px;
        }

        #dadoscliente
        {
            height: 60px;
        }

        .divSomeSelect
        {
            display: none;
            width: 0%;
        }
    
        #dadoscliente0
        {
            height: 60px;
        }

        #dadosclienteComplementares
        {
            height: 59px;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="lblmensagem" runat="server"  Visible="False" ForeColor="Red" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium"></asp:Label>
    <asp:Label ID="lblpedido" runat="server" Text="Pedido" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium" ForeColor="Red"></asp:Label><asp:TextBox ID="txtPedido" runat="server"></asp:TextBox>
    <div style="float:left; width: 1220px; height: 424px;">
        <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="false" Height="329px" Width="1190px" FinishCompleteButtonText="Finalizar" FinishPreviousButtonText="Voltar" StartNextButtonText="Avançar" StepNextButtonText="Avançar" StepPreviousButtonText="Voltar" OnFinishButtonClick="Wizard1_FinishButtonClick">
            <WizardSteps>
                <asp:WizardStep ID="WizardStep1"  runat="server" Title="Pesquisa">
                    <div class="content">
                        <div style="float: left; margin-top: -75px; height: 58px; width: 134px;">
                            <asp:RadioButtonList ID="rdbTpPessoa" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="rdbTpPessoa_SelectedIndexChanged"  Width="156px" Font-Size="Small" Font-Bold="True" Font-Names="Verdana">
                                <asp:ListItem Value="0">PESSOA FÍSICA</asp:ListItem>
                                <asp:ListItem Value="1">PESSOA JURÍDICA</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div id="ConsultaCpf" runat="server" visible="false" style="float: left; margin-left: 18%; margin-top: -76px; width: 320px;">
                            <asp:Label ID="lbldocumento" runat="server" Height="25px" Text="CPF" Width="35px" CssClass="label" Font-Bold="True"></asp:Label><asp:TextBox ID="txtCpf" runat="server" Height="20px"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtCpf_MaskedEditExtender" CultureName="en-US" runat="server" Enabled="True" Mask="999.999.999-99" TargetControlID="txtCpf">
                            </asp:MaskedEditExtender>
                            <asp:Button ID="btnPesquisar" runat="server" Height="29px" Text="Pesquisar" OnClick="btnPesquisar_Click" />
                        </div>
                        <div id="ConsultaCnpj" runat="server" visible="false" style="float: left; margin-left: 18%; margin-top: -50px; width: 320px;">
                            <asp:Label ID="Label1" runat="server" Height="25px" Text="CNPJ" Width="35px" CssClass="label" Font-Bold="True" Font-Italic="False"></asp:Label><asp:TextBox ID="txtCnpj" runat="server" Height="20px"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtCnpj_MaskedEditExtender" runat="server"  CultureName="en-US"  Enabled="True" Mask="99.999.999/9999-99" TargetControlID="txtCnpj">
                            </asp:MaskedEditExtender>
                            <asp:Button ID="btnCnpj" runat="server" Height="29px" Text="Pesquisar" OnClick="btnCnpj_Click" />
                        </div>
                        <div id="filtroAprovacao" runat="server" visible="false" style="float: right; margin-right: 50px; margin-top: -60px; width: 627px; height: 53px;">
                            <asp:RadioButton ID="rdbAprovado" CssClass="aprovado" runat="server" Text="APROVADO" Font-Size="Small" Visible="False" AutoPostBack="True" OnCheckedChanged="rdbAprovado_CheckedChanged" />
                            <asp:RadioButton ID="rdbReprovado" CssClass="reprovado" runat="server" Text="REPROVADO" Visible="False" AutoPostBack="True" OnCheckedChanged="rdbReprovado_CheckedChanged" />
                            <asp:RadioButton ID="rdbanalise" CssClass="analise" runat="server" Text="ANÁLISE MANUAL" Visible="False" />
                        </div>
                        <div id="dadoscliente" runat="server" visible="false">
                            <div style="float: left; width: 1055px;">
                                <asp:Label ID="Label25" runat="server" Text="Cod.Consulta" ClientIDMode="Static" Height="16px" Width="71px" CssClass="label"></asp:Label>
                                <asp:Label ID="Label20" ClientIDMode="Static" runat="server" Text="Data" Width="73px" Height="16px" CssClass="label"></asp:Label>
                                <asp:Label ID="Label22" ClientIDMode="Static" runat="server" Text="Resultado"
                                    Width="82px" Height="16px" CssClass="label"></asp:Label>
                                <asp:Label ID="Label3" ClientIDMode="Static" runat="server" Text="Cliente" Width="210px" Height="16px" CssClass="label"></asp:Label>
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
                            <br />
                            <div style="float: left;">
                                <asp:TextBox ID="txtCodigoConsulta" runat="server" Width="66px" Height="20px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="txtData" runat="server" Width="89px" Height="20px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="txtResultado" runat="server" Width="81px" Height="20px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="txtNome" runat="server" Width="208px" Height="20px" ClientIDMode="Static"></asp:TextBox>
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
                        <br />
                        <div id="dadosclienteComplementares" runat="server" visible="False">
                            <div style="float: left; width: 1055px;">
                                <asp:Label ID="Label47" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="RG" Width="131px"></asp:Label>
                                <asp:Label ID="Label9" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Data Nascimento" Width="131px"></asp:Label>
                                <asp:Label ID="Label49" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Sexo" Width="82px"></asp:Label>
                                <asp:Label ID="Label11" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Mídia" Width="82px"></asp:Label>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div style="float: left;">
                                <asp:TextBox ID="txtRG" runat="server" Height="20px" Width="125px"></asp:TextBox>
                                <asp:TextBox ID="txtdtNascimento" runat="server" Height="20px" Width="125px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="txtdtNascimento_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" TargetControlID="txtdtNascimento">
                                </asp:MaskedEditExtender>
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
                        <br />
                        <br />
                        <div id="dadosresidencial" style="float: left;" runat="server" visible="false">
                            <div style="float: left">
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
                            <br />
                            <div style="float: left">
                                <asp:TextBox ID="txtCep" runat="server" Width="71px" Height="20px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="txtCep_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99999-999" TargetControlID="txtCep">
                                </asp:MaskedEditExtender>
                                <asp:ImageButton ID="imgCep" runat="server" Height="24px" ImageUrl="~/imagens/buscar.png" OnClick="imgCep_Click" />
                                <asp:TextBox ID="txtEndereco" runat="server" Width="231px" Height="20px"></asp:TextBox>
                                <asp:TextBox ID="txtnr" runat="server" Width="42px" Height="20px"></asp:TextBox>
                                <asp:TextBox ID="txtComplemento" runat="server" Width="210px" Height="20px"></asp:TextBox>
                                <asp:TextBox ID="txtBairro" runat="server" Width="157px" Height="20px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="txtCidade" runat="server" Width="157px" Height="20px" ReadOnly="True"></asp:TextBox>
                                <asp:TextBox ID="txtUf" runat="server" Width="96px" Height="20px" ReadOnly="True"></asp:TextBox>
                                <asp:ImageButton ID="imgEndereco" runat="server" Height="18px" ImageUrl="~/imagens/ativar.png" OnClick="imgEndereco_Click" Width="47px" />
                                <asp:ImageButton ID="imgEditEndereco" runat="server" ImageUrl="~/imagens/b_edit.png" OnClick="imgEditEndereco_Click" Visible="False" Height="20px" Width="61px" />
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                       </div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Veiculo/Produto">
                    <div class="content">
                        <div id="dadosVeiculo" runat="server" style="float: left; margin-top: -69px;" visible="false">
                            <div style="float: left">
                                <asp:Label ID="Label14" ClientIDMode="Static" runat="server" Text="Placa" CssClass="label"
                                    Width="61px" Height="16px"></asp:Label>
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
                                <asp:Label ID="Label38" ClientIDMode="Static" runat="server" Text="Ano" CssClass="label"
                                    Width="65px" Height="16px"></asp:Label>
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
                                <asp:TextBox ID="txtAno" runat="server" Width="35px" Height="23px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="txtAno_MaskedEditExtender" runat="server"  Enabled="True" Mask="9999" MaskType="Number" TargetControlID="txtAno">
                                </asp:MaskedEditExtender>
                                <asp:TextBox ID="txtChassi" runat="server" Width="95px" Height="23px"></asp:TextBox>
                                <asp:TextBox ID="txtRenavam" runat="server" Width="99px" Height="23px"></asp:TextBox>
                                <asp:DropDownList ID="dropProdutos" runat="server" Height="26px" Width="156px" DataTextField="dsProduto" OnSelectedIndexChanged="dropProdutos_SelectedIndexChanged" AutoPostBack="true" DataValueField="cdproduto"></asp:DropDownList>
                                <asp:TextBox ID="txtValorTabela" runat="server" ReadOnly="true" Width="60px" Height="23px"></asp:TextBox>
                                <asp:TextBox ID="txtValorProduto" ClientIDMode="Static" runat="server" Width="60px" Height="23px"></asp:TextBox>
                                <asp:ImageButton ID="imgAddprodutos" runat="server" ImageUrl="~/imagens/add.png" Height="20px" OnClick="imgAddprodutos_Click" />
                                <asp:ImageButton ID="imgVeiculo" runat="server" Height="22px" ImageUrl="~/imagens/ativar.png" OnClick="imgVeiculo_Click" Width="26px" Visible="False" />
                                <asp:ImageButton ID="imgEditVeiculo" runat="server" ImageUrl="~/imagens/b_edit.png" OnClick="imgEditVeiculo_Click" Visible="False" Height="21px" Width="61px" />
                            </div>
                            <br />
                            <br />
                            <div style="float: left">
                                <asp:GridView ID="GridProdutos" runat="server" CellSpacing="-1" ShowFooter="false" Height="50px" Font-Size="X-Small" Width="1100px" AutoGenerateColumns="False" OnRowDataBound="GridProdutos_RowDataBound" OnRowDeleting="GridProdutos_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                                        <asp:BoundField DataField="placa" HeaderText="Placa" />
                                        <asp:BoundField DataField="id_modelo" HeaderText="Id-Modelo" />
                                        <asp:BoundField DataField="modelo" HeaderText="Modelo" />
                                        <asp:BoundField DataField="cor" HeaderText="Cor" />
                                        <asp:BoundField DataField="chassi" HeaderText="Chassi" />
                                        <asp:BoundField DataField="renavan" HeaderText="Renavan" />
                                        <asp:BoundField DataField="Produto" HeaderText="Produto" />
                                        <asp:BoundField DataField="Valor" HeaderText="Valor" />
                                        <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                                        <asp:BoundField DataField="ano" HeaderText="Ano" />
                                        <asp:BoundField DataField="comb" HeaderText="Comb" />
                                        <asp:BoundField DataField="tipoProduto" HeaderText="Tipo" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/imagens/excluir.png" HeaderText="Excluir" ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep3" runat="server" Title="Pagamentos">
                    <div class="content">
                        <br />
                        <div id="divpagamento" runat="server" visible="False" style="float: left; margin-top: -69px;">
                            <div style="float: left;">
                                <asp:Label ID="Label10" ClientIDMode="Static" runat="server"  Text="Total Venda" CssClass="label"
                                    Width="80px" Height="16px"></asp:Label>
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
                                <asp:TextBox ID="txtTotalVenda" runat="server" Height="18px" Enabled="false" Width="55px"></asp:TextBox>
                                <asp:DropDownList ID="dropForma" runat="server" AutoPostBack="True" DataTextField="ds_pagamento" DataValueField="id_forma" Height="24px" OnSelectedIndexChanged="dropForma_SelectedIndexChanged" Width="145px">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtQtdParcela" runat="server" Height="18px" Width="40px"></asp:TextBox>
                                <asp:TextBox ID="txtValor" runat="server" ClientIDMode="Static" Width="72px" Height="18px"></asp:TextBox>
                                <asp:TextBox ID="txtvencimentoCheque" runat="server" Width="97px" Height="18px" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="txtTitular" runat="server" Height="18px" Visible="False" Width="179px"></asp:TextBox>
                                <asp:TextBox ID="txtDocumento" runat="server" Height="18px" Visible="False" Width="115px"></asp:TextBox>
                                <asp:CalendarExtender ID="txtvencimentoCheque_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtvencimentoCheque" TodaysDateFormat="dd/MM/yyyy">
                                </asp:CalendarExtender>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="TxtResidencial" ClearMaskOnLostFocus="False">
                                </asp:MaskedEditExtender>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)99999-9999" TargetControlID="txtCelular" ClearMaskOnLostFocus="False">
                                </asp:MaskedEditExtender>
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="txtComercial" ClearMaskOnLostFocus="False">
                                </asp:MaskedEditExtender>
                                <asp:TextBox ID="txtLeitura" runat="server" AutoPostBack="True" Height="16px" OnTextChanged="txtLeitura_TextChanged" Visible="False" Width="280px"></asp:TextBox>
                                <asp:ImageButton ID="imgPagamento" runat="server" Height="20px" ImageUrl="~/imagens/add.png" OnClick="imgPagamento_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </div>
                            <br />
                            <br />
                            <br />
                            <div id="lblcheques" runat="server" visible="False" style="width: 1202px; float: left">
                                <asp:Label ID="lblAgencia" runat="server" ClientIDMode="Static" CssClass="label" Enabled="False" Height="18px" Text="Agencia" Visible="False" Width="65px"></asp:Label>
                                <asp:Label ID="lblconta" runat="server" ClientIDMode="Static" CssClass="label" Enabled="False" Height="16px" Text="Conta" Visible="False" Width="136px"></asp:Label>
                                <asp:Label ID="lblnrcheque" runat="server" ClientIDMode="Static" CssClass="label" Enabled="False" Height="16px" Text="Cheque" Visible="False" Width="100px"></asp:Label>
                                <asp:Label ID="lblbanco" runat="server" ClientIDMode="Static" CssClass="label" Enabled="False" Height="16px" Text="Banco" Visible="False" Width="91px"></asp:Label>
                            </div>
                            <br />
                            <br />
                            <div id="txtCheques" style="float: left" runat="server" visible="False">
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" TargetControlID="txtvencimentoCheque" TodaysDateFormat="dd/MM/yyyy">
                                </asp:CalendarExtender>
                                <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="TxtResidencial" ClearMaskOnLostFocus="False">
                                </asp:MaskedEditExtender>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)99999-9999" TargetControlID="txtCelular" ClearMaskOnLostFocus="False">
                                </asp:MaskedEditExtender>
                                <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(99)9999-9999" TargetControlID="txtComercial" ClearMaskOnLostFocus="False">
                                </asp:MaskedEditExtender>
                                <asp:TextBox ID="txtAgencia" runat="server" Height="16px" Visible="False" Width="57px"></asp:TextBox>
                                <asp:TextBox ID="txtConta" runat="server" Height="16px" Visible="False" Width="127px"></asp:TextBox>
                                <asp:TextBox ID="txtNrCheque" runat="server" Height="16px" Visible="False" Width="92px"></asp:TextBox>
                                <asp:TextBox ID="txtBanco" runat="server" Height="16px" Visible="False" Width="75px"></asp:TextBox>
                            </div>
                            <br />
                            <br />
                            <div id="pagamento" runat="server" style="height: 50px; float: left;">
                                <asp:GridView ID="gridPagamento" runat="server" AutoGenerateColumns="False" CellSpacing="-1" EmptyDataText="&nbsp;" Font-Size="X-Small" Height="16px" OnRowDeleting="gridPagamento_RowDeleting" Width="1110px" OnRowDataBound="gridPagamento_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                                        <asp:BoundField DataField="Pagamento" HeaderText="Pagamento" />
                                        <asp:BoundField DataField="quantidade" HeaderText="Parcela" />
                                        <asp:BoundField DataField="valor" HeaderText="Valor" />
                                        <asp:BoundField DataField="data" HeaderText="Vencimento" />
                                        <asp:BoundField DataField="titular" HeaderText="Titular" />
                                        <asp:BoundField DataField="nr_agencia" HeaderText="Agencia" />
                                        <asp:BoundField DataField="nr_conta" HeaderText="Conta" />
                                        <asp:BoundField DataField="nr_documento" HeaderText="Documento" />
                                        <asp:BoundField DataField="nr_cheque" HeaderText="Cheque" />
                                        <asp:BoundField DataField="nr_Banco" HeaderText="Banco" />
                                        <asp:BoundField DataField="ccm" HeaderText="ccm" />
                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/imagens/excluir.png" HeaderText="Excluir" ShowDeleteButton="True" />
                                        <asp:CommandField ShowSelectButton="True">
                                            <ItemStyle CssClass="divSomeSelect"></ItemStyle>
                                        </asp:CommandField>
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
                          <div style="float:right;margin-top:100px;margin-right:40%"  id="finalizar" runat="server" visible="false">
                            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar Pedido" />
                            <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar Pedido" OnClick="btnFinalizar_Click" />
                              <asp:Label ID="lblPagamento" runat="server"  Visible="False" ForeColor="Red" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium"></asp:Label>
                        </div>
                    </div>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep5" runat="server" Title="Gerar Contrato">
                    <div class="content">
                        <div style="float: left">
                            <asp:GridView ID="GridContrato" runat="server" CellSpacing="-1" Height="20px" Width="900px" Font-Size="Small" AutoGenerateColumns="False" DataKeyNames="id_pedido" OnRowDataBound="GridContrato_RowDataBound" OnPreRender="GridContrato_PreRender" OnRowDeleting="GridContrato_RowDeleting">
                                <Columns>
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                            <img alt="" style="cursor: pointer"src="imagens/plus.png" />
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
                            <br />
                        </div>
                    </div>
                </asp:WizardStep>
            </WizardSteps>
            <HeaderTemplate>
                <ul id="wizHeader">
                  <%--  <asp:Repeater ID="SideBarList" runat="server">
                        <ItemTemplate>
                           <%-- <li><a class="<%#GetClassForWizardStep(Container.DataItem) %>" title="<%#Eval("Name")%>">
                                <%# Eval("Name")%></a> </li>
                        </ItemTemplate>--%>
                <%--    </asp:Repeater>--%>
                </ul>--%>
            </HeaderTemplate>
        </asp:Wizard>
</div>
</asp:Content>
