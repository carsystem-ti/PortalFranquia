<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="VendaVoucher.aspx.cs" Inherits="PortalFranquia.modulos.Vendas.VendaVourcher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/Vourcher.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/botoes.css" rel="stylesheet" />
    <script src="../../js/jquery.js"></script>
    <script src="../../js/jquery.js"></script>
    <script src="../../js/jquery-ui.min.js"></script>
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <script src="../../js/jquery.maskedinput.js"></script>
    <script src="../../js/Voucher.js"></script>
    <script type="text/javascript" src="../../js/jquery.centralize.js"></script>
    <script type="text/javascript" src="../../js/kModal.js"></script>
    <script type="text/javascript" src="../../js/jquery.PrintArea.js"></script>
    <script src="../../js/MaskedEditFix.js"></script>
    <script src="../../js/maskCpfCnpj.js"></script> 
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <link href="../../css/mensagem.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            if ($(".telaBoleto").html() != null && $(".telaBoleto").html().trim() != '')
                imprimirBoleto();
        });
    </script>
    <style type="text/css">
        #divBoletos {
            width: auto;
            height: auto;
        }

        .box {
            background: #fff;
            border: 3px solid gray;
            box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
            margin: 25px;
            padding: 30px;
            z-index: 501;
        }

        .boxLoading {
            z-index: 601;
        }

        .box2 {
            z-index: 502;
            height: auto;
            width: auto;
        }

        .modal-overlay {
            /*display: none;*/
            background-color: lightgrey;
            opacity: 0.8;
            height: 300%;
            left: 0;
            position: absolute;
            top: 0;
            width: 300%;
            z-index: 500;
        }

        .modal-overlay-loading {
            /*display: none;*/
            background-color: lightgrey;
            opacity: 0.8;
            height: 100%;
            left: 0;
            position: absolute;
            top: 0;
            z-index: 600;
        }

        .modalCloseImg {
            background: url(../imagens/delete.png) no-repeat;
            width: 32px;
            height: 32px;
            display: inline;
            z-index: 3200;
            position: absolute;
            top: -22px;
            right: -15px;
            cursor: pointer;
        }

        .modalPrintImg {
            background: url(../imagens/print.png) no-repeat;
            width: 32px;
            height: 32px;
            display: inline;
            z-index: 3200;
            position: absolute;
            top: -22px;
            right: 20px;
            cursor: pointer;
        }

        .modalEmailImg {
            background: url(../imagens/new_mail.png) no-repeat;
            width: 32px;
            height: 32px;
            display: inline;
            z-index: 3200;
            position: absolute;
            top: -22px;
            right: 56px;
            cursor: pointer;
        }

        .loading {
            background: url(../imagens/ajax-loader.gif) no-repeat;
            height: 150px;
            width: 214px;
        }

        #Button1 {
            background-color: #0026ff;
            color: white;
            display: none;
        }

        #Button:hover {
            background-color: #0026ff;
        }

        #pedido {
            width: 130px;
        }

        #dtPedido {
            width: 100px;
        }

        .imgBoleto {
            height: 40px;
            width: 250px;
            margin-left: 90px;
        }
        fieldset.scheduler-border {
    border: 6px groove #ddd !important;
    padding: 0 1.4em 1.4em 1.4em !important;
    margin: 0 0 1.5em 0 !important;
    -webkit-box-shadow:  0px 0px 0px 0px #000;
            box-shadow:  0px 0px 0px 0px #000;
}

    legend.scheduler-border {
        font-size: 1.2em !important;
        font-weight: bold !important;
        text-align: left !important;
        width:auto;
        padding:0 10px;
        border-bottom:none;
    }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <label style="width: 480px">Filtro</label>

            </div>
            <div>
                <asp:DropDownList ID="dropFiltro" runat="server" Height="29px" Width="230px" AutoPostBack="True" OnSelectedIndexChanged="dropFiltro_SelectedIndexChanged1">
                    <asp:ListItem Value="0">SELECIONE</asp:ListItem>
                    <asp:ListItem Value="1">VOUCHER</asp:ListItem>
                    <asp:ListItem Value="2">CPF_CNPJ</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtBuscaDados" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtConsultaCpfCnpj" onkeypress="return mascara(this)" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtVendedor" ClientIDMode="Static" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="txtMidia" runat="server" Visible="False"></asp:TextBox>
                <asp:Button ID="btnBusca" runat="server" Text="Buscar Dados" OnClick="btnBusca_Click" />
                <asp:Button ID="btnGeraContrato" runat="server" Text="GERAR CONTRATO" OnClick="btnGeraContrato_Click" Visible="False" />

                <asp:Button ID="btnIMprimir" runat="server" Text="IMPRIMIR BOLETO" OnClick="btnIMprimir_Click" Visible="False" />
            </div>
            <br />
            <asp:Label ID="lblmensagem" Visible="False" runat="server" Text="Label" Font-Bold="True" Font-Names="Verdana" Font-Size="Small" ForeColor="Red"></asp:Label>
            <h4 style="color: #ea8511">Dados do Cliente&nbsp;
                <asp:CheckBox ID="chkAlterar" runat="server" AutoPostBack="True" Font-Names="Vrinda" Font-Size="Small" ForeColor="Red" OnCheckedChanged="chkAlterar_CheckedChanged" Text=" Alterar Dados" />
            </h4>
            <div>
                <div>
                    <label style="width: 90px">Pedido</label>
                    <label style="width: 100px">Data Pedido</label>
                    <label style="width: 100px">Status</label>
                    <label style="width: 170px">CPF/CNPJ</label>
                    <label style="width: 135px">RG</label>
                    <label style="width: 246px">NOME</label>
                  
                    
                </div>
                <div>


                    <asp:TextBox ID="txtNumeroPedido" CssClass="pedido" ClientIDMode="Static" runat="server" Width="88px" ReadOnly="True"></asp:TextBox>
                    <asp:TextBox ID="txtDataPedido" ClientIDMode="Static" CssClass="dtPedido" runat="server" Width="98px" ReadOnly="True"></asp:TextBox>
                    <asp:TextBox ID="txtStatusPedido" ClientIDMode="Static" runat="server" Width="105px" ReadOnly="True"></asp:TextBox>
                    <asp:TextBox ID="txtCpfCnpj" ClientIDMode="Static" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:TextBox ID="txtRg" ClientIDMode="Static" runat="server" Width="128px"></asp:TextBox>
                    <asp:TextBox ID="txtNome" ClientIDMode="Static" runat="server" Width="245px" ReadOnly="True"></asp:TextBox>
                   
                    

                </div>
                <br />
                <div>
                    <label style="width: 100px">Cep</label>
                    <label style="width: 310px">Endereço</label>
                    <label style="width: 70px">Número</label>
                    <label style="width: 170px">Complemento</label>
                    <label style="width: 300px">Bairro</label>
                </div>
                <div>

                    <asp:TextBox ID="txtCep" ClientIDMode="Static" runat="server" Width="97px"></asp:TextBox>
                    <asp:TextBox ID="txtEndereco" ClientIDMode="Static" runat="server" Width="309px" ReadOnly="True"></asp:TextBox>
                    <asp:TextBox ID="txtNumero" ClientIDMode="Static" runat="server" Width="74px"></asp:TextBox>
                    <asp:TextBox ID="txtComplemento" ClientIDMode="Static" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtBairro" ClientIDMode="Static" runat="server" Width="441px" ReadOnly="True"></asp:TextBox>
                </div>
                <br />

                <div>
                    <label style="width: 170px">Cidade</label>
                    <label style="width: 50px">UF</label>
                    <label style="width: 110px">Telefone</label>
                    <label style="width: 100px">Celular</label>
                    <label style="width: 220px">E-mail</label>
                  
                </div>
                <div>

                    <asp:TextBox ID="txtCidade" ClientIDMode="Static" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:TextBox ID="txtUF" ClientIDMode="Static" runat="server" Width="50px" ReadOnly="True"></asp:TextBox>

                    <asp:TextBox ID="txtTelefone" ClientIDMode="Static" runat="server" Width="107px"></asp:TextBox>
                    <asp:TextBox ID="txtCelular" ClientIDMode="Static" runat="server" Width="107px"></asp:TextBox>
                    <asp:TextBox ID="txtEmail" ClientIDMode="Static" runat="server" Width="222px"></asp:TextBox>
                
                </div>
                <br />
                <div>
                    <label style="width: 250px;">Produtos Vourcher</label>
                    <label style="width: 140px;">Fabricante</label>
                    <label style="width: 272px;">Modelo</label>
                    <label style="width: 120px">Tipo veiculo</label>
                    <label style="width: 126px;">Ano</label>

                </div>
                <div>
                    <asp:DropDownList ID="slcprodutos" runat="server" DataTextField="ds_produto" DataValueField="id_Veiculo" Height="27px" Width="243px" AutoPostBack="True" OnSelectedIndexChanged="slcprodutos_SelectedIndexChanged"></asp:DropDownList>
                    <asp:TextBox ID="txtFabricante" ClientIDMode="Static" runat="server" Width="143px" Enabled="False"></asp:TextBox>
                    <asp:TextBox ID="txtModelo" ClientIDMode="Static" runat="server" Enabled="False" Width="272px"></asp:TextBox>
                    <asp:TextBox ID="txtTipoVeiculo" ClientIDMode="Static" ReadOnly="true" runat="server" Width="114px" Enabled="False"></asp:TextBox>
                    <asp:TextBox ID="txtAno" ClientIDMode="Static" runat="server" Width="127px" Enabled="False" MaxLength="4"></asp:TextBox>



                </div>
                <br />
                <fieldset class="scheduler-border">
                    <legend class="scheduler-border">Favor preencher os dados</legend>
                <div>
                      <label style="width: 120px">Sexo *</label>
                    <label style="width: 106px">Nasc/Fund *</label>
                      <label style="width: 204px">Chassi *</label>
                    <label style="width: 230px">Renavan *</label>
                    <label style="width: 72px;">Placa *</label>
                    <label style="width: 180px;">Cor *</label>
                    <label style="width: 218px">Combustível *</label>
                </div>
                <div>
                       <asp:DropDownList ID="dropsexo"  runat="server">
                        <asp:ListItem Value="SELECIONE">SELECIONE</asp:ListItem>
                        <asp:ListItem>M</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtDataNascimento" ClientIDMode="Static" runat="server" Width="106px"></asp:TextBox>
                        <asp:TextBox ID="txtChassi" ClientIDMode="Static" runat="server" Width="206px"></asp:TextBox>
                    <asp:TextBox ID="txtRenavan" ClientIDMode="Static" runat="server" Width="229px"></asp:TextBox>
                    <asp:TextBox ID="txtPlaca" ClientIDMode="Static" runat="server" Width="104px"></asp:TextBox>
                    <asp:DropDownList ID="slcCores" runat="server" ClientIDMode="Static" DataTextField="ds_Cor" DataValueField="ds_Cor" Width="187px"></asp:DropDownList>

                    <asp:DropDownList ID="slcCombustivel" runat="server" ClientIDMode="Static">
                        <asp:ListItem>SELECIONE</asp:ListItem>
                        <asp:ListItem>GASOLINA</asp:ListItem>
                        <asp:ListItem>ALCOOL</asp:ListItem>
                        <asp:ListItem>DIESEL</asp:ListItem>
                        <asp:ListItem>FLEX</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnValidaPlaca" runat="server" Text="Validar" OnClick="btnValidaPlaca_Click" />
                </div>
                    </fildset>
            </div>
            <br />
            <br />
            <div class="table-overflow">

                <asp:GridView ID="gridItens" runat="server" AutoGenerateColumns="False" Width="988px">
                    <Columns>
                        <asp:BoundField DataField="id_pedido" HeaderText="Pedido" />
                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                        <asp:BoundField DataField="ds_produto" HeaderText="Produto" />
                        <asp:BoundField DataField="ds_categoria" HeaderText="Categoria" />
                        <asp:BoundField DataField="ds_fabricante" HeaderText="Fabricante" />
                        <asp:BoundField DataField="nr_contrato" HeaderText="Contrato" />
                        <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                    </Columns>
                </asp:GridView>

            </div>
            <br />
            <br />
            <div class="table-overflow">

                <asp:GridView ID="gridPagamentos" runat="server" AutoGenerateColumns="False" Width="988px">
                    <Columns>
                        <asp:BoundField DataField="id_pedido" HeaderText="Pedido" />
                        <asp:BoundField DataField="ds_pagamento" HeaderText="Pagamento" />
                        <asp:BoundField DataField="vl_pagamento" HeaderText="Valor" />
                        <asp:BoundField DataField="nr_parcela" HeaderText="Parcela" />
                        <asp:BoundField DataField="vl_calculado" HeaderText="Valor Calculado" />
                    </Columns>
                </asp:GridView>

            </div>
            <div style="display: none;">
                <div id="divBoleto" class="telaBoleto" runat="server">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<asp:Button ID="Button1" runat="server" CssClass="btn-success" ClientIDMode="Static" OnClick="Button1_Click1" Text="IMPRIMIR BOLETO" />--%>
    <script type="text/javascript">

        function imprimirBoleto() {

            $('.Cabecalho').remove();
            $('body').css('background-color', 'white');
            $('#divBoletos td').css('background-color', 'white');

            $.each($('#divBoletos td'), function (index, value) {
                $(this).addClass('naoComum');
            });

            var iHtmlBoleto = "<div id ='printArea' style='width:100%; height:100%;'><div class='impressaoBoleto'>" + $(".Pagina").html() + "</div></div>";

            criaPopup("", true, false, iHtmlBoleto, true, false,
                function () {
                    $(".telaBoleto").html('');
                });

            $(".telaBoleto").html('');

            $(".modalPrintImg").click(function (event) {
                event.stopPropagation();
                $("#printArea").printArea();
            });
        }
    </script>
</asp:Content>
