<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Troca.aspx.cs" Inherits="PortalFranquia.modulos.Troca.Troca" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/mensagem.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.js"></script>    
    <script type="text/javascript" src="../../js/mask.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function ($) {

                $("#txtValorCobrado").setMask('moeda');
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
        #dadoscliente {
            width: 1220px;
            margin-left: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dialog" style="display: none; height: 400px; width: 400px;">
    </div>
    <div  runat="server" style="float: left; width: 1190px;">
            <asp:Label ID="Label15" ClientIDMode="Static" runat="server" Text="Selecione" Width="165px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label38" ClientIDMode="Static" runat="server" Text="Contrato/Placa"
                Width="162px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label18" ClientIDMode="Static" runat="server" Text="Cliente"
                Width="335px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label37" ClientIDMode="Static" runat="server" Text="Contrato" Width="121px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label39" ClientIDMode="Static" runat="server" Text="Placa" Width="90px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label19" ClientIDMode="Static" runat="server" Text="ID Atual" Width="121px" Height="16px" CssClass="label"></asp:Label>
        </div>
    <br />
    <div style="float: left;">
            <asp:DropDownList ID="dropSelecao" runat="server" Height="24px" Width="165px">
                <asp:ListItem>Selecione</asp:ListItem>
                <asp:ListItem Value="1">Contrato</asp:ListItem>
                <asp:ListItem Value="2">Placa</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtContratoPlaca" runat="server" Width="113px" Height="20px"></asp:TextBox>
            <asp:ImageButton ID="imgBusca" runat="server" ImageUrl="~/imagens/buscar.png" OnClick="imgBusca_Click" Width="43px" />
            <asp:TextBox ID="txtNome" runat="server" Width="324px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtContrato" runat="server" Width="113px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtPlaca" runat="server" Width="89px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtId" runat="server" Width="89px" Height="20px" ReadOnly="True"></asp:TextBox>

        </div>
    <br />
    <br />
    <br />
    <div id="dadoscliente" runat="server">
        <div style="float: left; width: 1190px;">
            <asp:Label ID="Label34" ClientIDMode="Static" runat="server" Text="Cod." Width="31px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label25" runat="server" Text="Produto" ClientIDMode="Static" Height="19px" Width="179px" CssClass="label"></asp:Label>
            <asp:Label ID="Label20" ClientIDMode="Static" runat="server" Text="Status" Width="87px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label22" ClientIDMode="Static" runat="server" Text="Atendimento"
                Width="172px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label3" ClientIDMode="Static" runat="server" Text="Venda" Width="121px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label2" ClientIDMode="Static" runat="server" Text="Cpf/Cnpj"
                Width="154px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label6" ClientIDMode="Static" runat="server" Text="RG/Insc.Estadual"
                Width="128px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label1" runat="server" Text="Dt. Nascimento" ClientIDMode="Static" Height="16px" Width="137px" CssClass="label"></asp:Label>
            <asp:Label ID="Label4" ClientIDMode="Static" runat="server" Text="Dt.Venda" Width="72px" Height="16px" CssClass="label"></asp:Label>
        </div>
        <br />
        <div style="float: left;">
            <asp:TextBox ID="txtCodigo" runat="server" Width="17px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtProduto" runat="server" Width="182px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtStatusContrato" runat="server" Width="89px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtStatusAtendimento" runat="server" Width="139px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtstatusVenda" runat="server" Width="128px" Height="20px" ClientIDMode="Static" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtCpf_Cnpj" runat="server" Width="135px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtDocumento" runat="server" Width="169px" Height="20px" ReadOnly="True"></asp:TextBox>

        </div>
        &nbsp;<asp:TextBox ID="txtDataNascimento" runat="server" Width="107px" Height="20px" ReadOnly="True"></asp:TextBox>
        <asp:TextBox ID="txtDataVenda" runat="server" Width="125px" Height="20px" ReadOnly="True"></asp:TextBox>
    </div>
    <br />
    <div id="Div1" runat="server">
        <div style="float: left; width: 1212px;">
            <asp:Label ID="Label5" ClientIDMode="Static" runat="server" Text="Dt.Confirmação"
                Width="105px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label7" ClientIDMode="Static" runat="server" Text="Vendedor" Width="116px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label8" ClientIDMode="Static" runat="server" Text="Veículo"
                Width="110px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label9" ClientIDMode="Static" runat="server" Text="Fabricante"
                Width="106px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label26" ClientIDMode="Static" runat="server" Text="Categoria"
                Width="98px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label27" ClientIDMode="Static" runat="server" Text="Ano"
                Width="51px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label28" ClientIDMode="Static" runat="server" Text="Renavan"
                Width="146px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label29" ClientIDMode="Static" runat="server" Text="Chassi"
                Width="204px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label30" ClientIDMode="Static" runat="server" Text="Combustivel"
                Width="146px" Height="16px" CssClass="label"></asp:Label>
            <asp:Label ID="Label31" ClientIDMode="Static" runat="server" Text="Cor"
                Width="39px" Height="16px" CssClass="label"></asp:Label>
        </div>
        <br />
        <div style="float: left; width: 1228px;">
            <asp:TextBox ID="txtDtConfirmacao" runat="server" Width="95px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtVendedor" runat="server" Width="109px" Height="20px" ClientIDMode="Static" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtVeiculo" runat="server" Width="116px" Height="20px" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtFabricante" runat="server" Width="101px" Height="20px" ReadOnly="True"></asp:TextBox>

            <asp:TextBox ID="txtCategoria" runat="server" Width="101px" Height="20px" ReadOnly="True"></asp:TextBox>

            <asp:TextBox ID="txtAno" runat="server" Width="49px" Height="20px" ReadOnly="True"></asp:TextBox>

            <asp:TextBox ID="txtRenavan" runat="server" Width="112px" Height="20px" ReadOnly="True"></asp:TextBox>

            <asp:TextBox ID="txtChassi" runat="server" Width="172px" Height="20px" ReadOnly="True"></asp:TextBox>

            <asp:TextBox ID="txtCombustivel" runat="server" Width="137px" Height="20px" ReadOnly="True"></asp:TextBox>

            <asp:TextBox ID="txtCor" runat="server" Width="103px" Height="20px" ReadOnly="True"></asp:TextBox>

        </div>
    </div>
    <br />
    <br />
    <div id="divProduto" runat="server" visible="false">
        <div style="float: left; width: 1212px;">
            <asp:Label ID="Label10" ClientIDMode="Static" runat="server" Text="Selecione o produto da troca:"
                Width="262px" Height="16px" CssClass="label" Font-Bold="True"></asp:Label>
            <asp:Label ID="Label11" ClientIDMode="Static" runat="server" Text="Valor Troca:" Width="132px" Height="16px" CssClass="label" Font-Bold="True"></asp:Label>
            <asp:Label ID="Label12" ClientIDMode="Static" runat="server" Text="Valor Cobrado"
                Width="110px" Height="16px" CssClass="label" Font-Bold="True"></asp:Label>
        </div>
        <br />
        <div style="float: left;">
            <asp:DropDownList ID="dropProdutosTrocas" runat="server" Height="25px" Width="249px" AutoPostBack="True" DataTextField="ds_produto" DataValueField="id_produto" OnSelectedIndexChanged="dropProdutosTrocas_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:TextBox ID="txtValorTroca" runat="server" Width="133px" Height="20px" ClientIDMode="Static" Enabled="False" ReadOnly="True"></asp:TextBox>
            <asp:TextBox ID="txtValorCobrado" runat="server" Width="101px" Height="20px" ClientIDMode="Static"></asp:TextBox>

        </div>
        <asp:ImageButton ID="imgAvancarCliente" runat="server" Height="21px" ImageUrl="~/imagens/ativar.png" OnClick="imgAvancarCliente_Click" Width="47px" />

                                <asp:ImageButton runat="server" ImageUrl="~/imagens/b_edit.png" Height="21px" Width="61px" ID="imgEditCliente" Visible="False" OnClick="imgEditCliente_Click"></asp:ImageButton>

    </div>
    <br />
    <div style="float: left;margin-left:30%" id="finalizar" runat="server" visible="false">
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar Pedido" />
        <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar Pedido" OnClick="btnFinalizar_Click" />

    </div>
    <div id="divpagamento" runat="server" visible="false" style="float: left">
        <div style="float: left; width: 1176px;">
            <asp:Label ID="Label36" ClientIDMode="Static" runat="server" Text="Valor Total" CssClass="label"
                Width="73px" Height="16px" Enabled="False"></asp:Label>
            <asp:Label ID="Label13" ClientIDMode="Static" runat="server" Text="Pagamentos" CssClass="label"
                Width="161px" Height="16px"></asp:Label>
            <asp:Label ID="Label35" ClientIDMode="Static" runat="server" Text="Parcelas" CssClass="label"
                Width="60px" Height="16px" Enabled="False"></asp:Label>
            <asp:Label ID="Label14" ClientIDMode="Static" runat="server" Text="Valor" CssClass="label"
                Width="57px" Height="16px" Enabled="False"></asp:Label>
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
            <asp:TextBox ID="txtValorTotalOperacao" runat="server" ClientIDMode="Static" Width="72px" Height="18px" Enabled="False"></asp:TextBox>
            <asp:DropDownList ID="dropForma" runat="server" AutoPostBack="True" DataTextField="ds_pagamento" DataValueField="id_forma" Height="24px" OnSelectedIndexChanged="dropForma_SelectedIndexChanged" Width="145px">
            </asp:DropDownList>
            <asp:TextBox ID="txtQtdParcela" runat="server" Height="18px" Width="40px" ClientIDMode="Static"></asp:TextBox>
            <asp:TextBox ID="txtValor" runat="server" ClientIDMode="Static" Width="72px" Height="18px"></asp:TextBox>
            <asp:TextBox ID="txtvencimentoCheque" runat="server" Width="97px" Height="18px" Visible="False" ClientIDMode="Static"></asp:TextBox>
            <asp:TextBox ID="txtTitular" runat="server" Height="18px" Visible="False" Width="179px"></asp:TextBox>
            <asp:TextBox ID="txtCpfCnpjCheque" runat="server" Height="18px" Visible="False" Width="115px"></asp:TextBox>
            <asp:TextBox ID="txtLeitura" runat="server" AutoPostBack="True" Height="16px" OnTextChanged="txtLeitura_TextChanged" Visible="False" Width="280px"></asp:TextBox>
            <asp:ImageButton ID="imgPagamento" runat="server" Height="20px" ImageUrl="~/imagens/add.png" OnClick="imgPagamento_Click" Style="width: 20px" />
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
           <div style="height: 150px; overflow: auto;">
            <asp:GridView ID="gridPagamento" runat="server" AutoGenerateColumns="False" CellSpacing="-1" EmptyDataText="&nbsp;" Font-Size="Small" OnRowDeleting="gridPagamento_RowDeleting" OnRowDataBound="gridPagamento_RowDataBound" Font-Names="Verdana">
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
                </Columns>
                <EditRowStyle Font-Size="Small" />
                <EmptyDataRowStyle Font-Size="Small" />
                <FooterStyle Font-Size="Small" />
                <HeaderStyle Font-Size="Small" />
                <SelectedRowStyle CssClass="selectRowTD" />
            </asp:GridView>
                </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    
</asp:Content>
