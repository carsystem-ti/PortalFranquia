<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="AberturaOs.aspx.cs" Inherits="PortalFranquia.modulos.OS.AberturaOs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/mostraOSAbertas.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <%--<%@ Register Src="~/componentes/OS/trocaID.ascx" TagPrefix="uc1" TagName="trocaID" %>
<%@ Register Src="~/componentes/OS/EncerrarOs.ascx" TagPrefix="uc2" TagName="EncerrarOs" %>--%>    <%--    <link href="../../css/kModal.css" rel="stylesheet" />
	<script src="../../js/kModal.js" type="text/javascript"></script>--%>

    <script src="../../js/OSsAbertas.js"></script>
    <link href="../../css/OrdemS.css" rel="stylesheet" />
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap-glyphicons.css" rel="stylesheet" />
    <link href="../../css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
		.voucher {
			margin-left: 200px;
			font-weight: bold;
		}

		.CancelarOs {
			margin-left: 330px;
			font-weight: bold;
		}

		.Contrato {
			font-weight: bold;
		}

		.tableMinhasVistorias {
			width: 100%;
			table-layout: fixed;
		}

		.tbl-header {
			background-color: #27ae60; /*Cor de fundo do cabeçalho*/
		}

		.tbl-content {
			height: 169px; /* Tamanho do corpo da tabela*/
			overflow-x: auto;
			margin-top: 0px;
			border: 1px solid #27ae60; /* Cor da borda*/
		}

		/* Classe que configura o layout d cabeçalho*/
		.thMinhasVistorias {
			padding: 2px 15px;
			font-weight: bold;
			font-size: 14px;
			color: #fff;
			text-transform: uppercase;
			text-align: center;
		}

		/* Classe que configura as colunas da tabela*/
		.tdMinhasVistorias {
			padding: 5px;
			text-align: left;
			vertical-align: middle;
			font-weight: 400;
			font-size: 12px;
			color: black; /* Cor da fonte */
			border-bottom: solid 1px #27ae60;
		}

		::-webkit-scrollbar {
			width: 6px;
		}

		::-webkit-scrollbar-track {
			-webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3);
		}

		::-webkit-scrollbar-thumb {
			-webkit-box-shadow: inset 0 0 6px rgba(0,0,0,0.3);
		}

		.tdProtocolo {
			width: 8%;
		}

		.tdCliente {
			width: 21%;
		}

		.tdPlaca {
			width: 6%;
		}

		.tdData {
			width: 8%;
		}

		.tdMarcaModelo {
			width: 20%;
		}

		.tdTipoVistoria {
			width: 15%;
		}

		.tdVistoriador {
			width: 20%;
		}

		.tdAcao {
			width: 4%;
		}

		.tdRemoveVisLiberada {
			width: 2%;
		}



		.thVistoriaLocalizada {
			padding: 2px 15px;
			font-weight: bold;
			font-size: 14px;
			text-transform: uppercase;
			text-align: center;
			background-color: #2980b9;
			color: white;
			border: 1px solid #2980b9;
		}

		.tdVistoriaLocalizada {
			padding: 2px 15px;
			text-align: left;
			vertical-align: middle;
			font-weight: 400;
			font-size: 14px;
			color: black; /* Cor da fonte */
		}

		.panelRegister {
			border-color: #28B463;
			-webkit-box-shadow: 2px 2px 30px 1px rgba(50, 50, 50, 0.88);
			-moz-box-shadow: 2px 2px 30px 1px rgba(50, 50, 50, 0.88);
			box-shadow: 2px 2px 30px 1px rgba(50, 50, 50, 0.88);
			color: #ffffff;
			width: 100%;
		}

		.titleRegister {
			width: 100%;
			height: 22px;
			font-size: 14px;
			font-weight: bold;
			border-bottom: 2px solid #28B463;
			margin-bottom: 5px;
			background-color: #28B463;
			color: white;
		}

		.inputEnabled {
			width: 100%;
			font-weight: bold;
		}

		.input-group {
			position: relative;
			display: table;
			border-collapse: separate;
			top: 0px;
			left: 0px;
			width: 0px;
		}

		.tableVistoriaLocalizada {
			width: 90%;
			table-layout: fixed;
			color: black;
		}

		.auto-style1 {
			width: 111px;
			background-color: #fff;
			border-color: #fff;
			border-style: solid;
			border-width: 2px;
			color: #fff;
		}

		.auto-style2 {
			width: 188px;
			background-color: #fff;
			border-color: #fff;
			border-style: solid;
			border-width: 2px;
			color: #fff;
		}

		.auto-style4 {
			width: 85px;
			background-color: #fff;
			border-color: #fff;
			border-style: solid;
			border-width: 2px;
			color: #fff;
		}

		.tab {
			background-color: white;
			border-bottom-color: white;
			color: white;
			border: 1px solid write;
		}

		.td {
			background-color: #fff;
			border-color: #fff;
			border-style: solid;
			border-width: 2px;
			color: #fff;
		}

		.auto-style6 {
			display: block;
			padding: 6px 12px;
			font-size: 14px;
			line-height: 1.428571429;
			color: #555555;
			vertical-align: middle;
			background-color: #ffffff;
			border: 1px solid #cccccc;
			border-radius: 4px;
			-webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
			box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
			-webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
			transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
			width: 88%;
		}

		.auto-style8 {
			display: block;
			padding: 6px 12px;
			font-size: 14px;
			line-height: 1.428571429;
			color: #555555;
			vertical-align: middle;
			background-color: #ffffff;
			border: 1px solid #cccccc;
			border-radius: 4px;
			-webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
			box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
			-webkit-transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
			transition: border-color ease-in-out 0.15s, box-shadow ease-in-out 0.15s;
			width: 102%;
		}

		.auto-style12 {
			border: 2px solid #fff;
			width: 157px;
			background-color: #fff;
			color: #fff;
		}

		.auto-style17 {
			width: 118px;
			border: 2px solid #fff;
			width: 137px;
			background-color: #fff;
			color: #fff;
		}

		.auto-style18 {
			width: 235px;
			border: 2px solid #fff;
			width: 137px;
			background-color: #fff;
			color: #fff;
		}

		.auto-style19 {
			border: 2px solid #fff;
			width: 146px;
			background-color: #fff;
			color: #fff;
		}

		.auto-style20 {
			width: 112px;
			border: 2px solid #fff;
			width: 146px;
			background-color: #fff;
			color: #fff;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="td">
        <tr>
            <td class="auto-style2">
                <h4 style="color: royalblue" class="auto-style1">Pesquisar</h4>
            </td>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style18">&nbsp;</td>
        </tr>
        <tr>
            
            <td class="auto-style12">
                <input type="text" runat="server" id="txtPesquisa" class="auto-style8" placeholder="Contrato" /></td>
            <td class="auto-style4">
                <input runat="server" type="button" id="Button4" name="btnBuscar" value="Buscar" onserverclick="btnPesquisar_Click" class="btn btn-info" />
            </td>
            <td class="auto-style19">
                <input type="text" runat="server" id="txtPesquisaVoucher" class="auto-style6" placeholder="Voucher" /></td>
            <td class="auto-style17">
                <input runat="server" type="button" id="btVoucher" name="btVoucher" value="Vincular" class="btn btn-info" />



            </td>
            <td class="auto-style20">
                <input runat="server" type="button" id="btCancelarOrdem" name="btCancelarOrdem" value="Cancelar" class="btn btn-info" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <h4 style="color: royalblue" class="auto-style1">Cliente</h4>
            </td>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style20">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <input type="text" runat="server" id="txtPesquisa0" class="auto-style8" placeholder="Contrato" /></td>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style19">&nbsp;</td>
            <td class="auto-style17">&nbsp;</td>
            <td class="auto-style18">&nbsp;</td>
            <td class="auto-style20">&nbsp;</td>
        </tr>
    </table>


</asp:Content>
