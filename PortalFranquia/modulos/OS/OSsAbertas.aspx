<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="OSsAbertas.aspx.cs" Inherits="PortalFranquia.modulos.OS.OSAbertas" %>


<%--<%@ Register Src="~/componentes/OS/trocaID.ascx" TagPrefix="uc1" TagName="trocaID" %>
<%@ Register Src="~/componentes/OS/EncerrarOs.ascx" TagPrefix="uc2" TagName="EncerrarOs" %>--%>


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
       <script type="text/javascript">
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

	<asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<div>
				<asp:Label ID="lbMensErro" runat="server" Text="" CssClass="mensErro" Visible="true"></asp:Label>

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
						<td class="auto-style2">
							<select id="slcPesquisa" runat="server"  class="form-control" name="D1" style="width: 200px; height: 35px">
								<option value="0">Selecione</option>
								<option value="3">Histórico</option>
								<option value="2">Contrato</option>
							</select></td>
						<td class="auto-style12">
							<input type="text" runat="server" id="txtPesquisa" class="auto-style8" placeholder="Contrato" /></td>
						<td class="auto-style4">
							<input runat="server" type="button" id="Button4" name="btnBuscar" value="Buscar" onserverclick="btnPesquisar_Click" class="btn btn-info" />
						</td>
						<td class="auto-style19">
							<input type="text" runat="server" id="txtPesquisaVoucher" class="auto-style6" placeholder="Voucher" /></td>
						<td class="auto-style17">
							<input runat="server" type="button" id="btVoucher" name="btVoucher" value="Vincular" onserverclick="btVoucher_Click" class="btn btn-info" />



						</td>
						<td class="auto-style18">
							<select class="form-control" datatextfield="ds_Motivo" datavaluefield="cd_ID" runat="server" style="width: 200px; height: 35px" id="slcMotivos">
							</select>
						</td>
						<td class="auto-style20">
							<input runat="server" type="button" id="btCancelarOrdem" name="btCancelarOrdem" value="Cancelar" onserverclick="btCancelarOrdem_Click" class="btn btn-info" />
						</td>
					</tr>
					<tr>
						<td class="auto-style2">&nbsp;</td>
						<td class="auto-style12">&nbsp;</td>
						<td class="auto-style4">&nbsp;</td>
						<td class="auto-style19">&nbsp;</td>
						<td class="auto-style17">&nbsp;</td>
						<td class="auto-style18">&nbsp;</td>
						<td class="auto-style20">&nbsp;</td>
					</tr>
				</table>
				<br />

				<div class="form-inline">

					<div>
					</div>


				</div>
			</div>
			</div>
		   
		  
			<div>

				<asp:Button Text="Último Pacote" runat="server" Visible="false" ID="btnUltimoPacote" OnClick="btnUltimoPacote_Click" ClientIDMode="Static" />




			</div>
            <div runat="server" id="divRecado" visible="false">
                <div class="container">
                      <h2 style="color:red">Ordem de Serviço não foi Encerrada!</h2>
         <p>Fique atento as seguintes regras!</p>

         <h3 style="color:#EA8511">Dados Pessoais</h3>
         <dl>
             <dt>RG</dt>
             <dt>Data de Nascimento</dt>

             <dt>Sexo</dt>
             <dt>Telefones</dt>
            <dt>E-mail</dt>
             
         </dl>
                     <h3 style="color:#EA8511">Dados do Veículo</h3>
         <dl>
             <dt>Placa</dt>
             <dt>Cor</dt>

             <dt>Combustível</dt>
             <dt>Renavan</dt>
                <dt>Chassi</dt>
         </dl>
                                <h3 style="color:#EA8511">Regras de Encerramento</h3>
         <dl>
             <dt>GPS Atualizado com a data atualizada.</dt>
             <dt>Data registro atualizada.</dt>

             <dt>Teste e/ou bloqueio enviado e recebido.</dt>
             <dt>Senha e dados atualizados no tablet (Serviço Interno).</dt>
                
         </dl>
                </div>

            </div>
            <div style="width: auto; height: auto;max-height:370px; overflow: auto">
			<asp:GridView ID="gridsOS" runat="server"  OnSelectedIndexChanged="gridsOS_SelectedIndexChanged" DataKeyNames="id_OS,st_os"  CssClass="thVistoriaLocalizada" Width="100%" AutoGenerateColumns="False" BorderStyle="Solid">
				<Columns>

					<asp:BoundField DataField="Data" HeaderText="Data" />
					<asp:BoundField DataField="Placa" HeaderText="Placa" />
					<asp:BoundField DataField="Contrato" HeaderText="Contrato" />
					<asp:BoundField DataField="Cliente" HeaderText="Cliente" />
					<asp:BoundField DataField="Veículo" HeaderText="Veículo" />
					<asp:BoundField DataField="Instalador" HeaderText="Instalador" />
					<asp:BoundField DataField="id_OS" HeaderText="id_OS" Visible="False" />
					<asp:BoundField DataField="tipoOS" HeaderText="tipoOS" />
					<asp:BoundField DataField="ds_produto" HeaderText="Produto" />
					<asp:BoundField DataField="id_Equipamento" HeaderText="id_Equipamento" Visible="False" />
					<asp:BoundField DataField="st_os" HeaderText="st_os" Visible="False" />


				    <asp:TemplateField HeaderText="+">
                        <ItemTemplate>
                            <%--<button type="button" runat="server" id="btnDetalhes" name="btnDetalhes" onserverclick="btnDetalhes_ServerClick" class="btn btn-success btn-sm"><span class="glyphicon glyphicon-thumbs-up"></span></button>--%>
                        <asp:ImageButton ID="imgEntrarCT" runat="server" CommandName="Select" 
                                                    Height="26px" ImageUrl="~/imagens/plus.png"/>                       
                        </ItemTemplate>
                    </asp:TemplateField>


				</Columns>
			</asp:GridView>
           </div>
			<br />
			<div runat="server" id="divOs" visible="false" style="height: 500px; overflow-y: scroll; width: 100%">
				<br />
				<div class="container">
					<div class="row">
						<div class="col-md-15">
							<div class="well well-sm" id="primeiraTela" runat="server">

								<div class="row">
									<asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
									<asp:HiddenField ID="HiddenField2" runat="server" ClientIDMode="Static" />
									<asp:HiddenField ID="Cetec" runat="server" ClientIDMode="Static" />



									<div class="col-md-6">
										<div class="form-group">
											<label style="width: auto" for="subject">
												Número de OS
											</label>
											<input type="text" runat="server" readonly="readonly" class="form-control" id="txtIdOs" placeholder="Numero OS" name="txtIdOs" />
										</div>
										<div class="form-group">
											<label style="width: auto" for="subject">
												Número Peça
											</label>
											<input type="text" runat="server" class="form-control" id="txtUltimoId" readonly="readonly" placeholder="Numero Peça" name="txtUltimoId" />
										</div>
                                        	<div runat="server" id="divVisita" class="form-group">
											<label style="width: auto" for="subject">
												Visita
											</label>

											<asp:DropDownList ID="dropVisita" ClientIDMode="Static" class="form-control" runat="server"  AutoPostBack="True" Width="241px">
                                                <asp:ListItem Selected="True" Value="0">Nao</asp:ListItem>
                                                <asp:ListItem Value="1">VISITA</asp:ListItem>
                                                </asp:DropDownList>

										</div>

										<div class="form-group">
											<label style="width: auto" for="subject">
												Tecnico
											</label>

											<asp:DropDownList ID="dropTecnico" ClientIDMode="Static" class="form-control" runat="server" DataTextField="ds_Instalador" DataValueField="ds_Instalador" AutoPostBack="True" OnSelectedIndexChanged="dropTecnico_SelectedIndexChanged" Width="241px"></asp:DropDownList>

										</div>
										<div class="form-group">
											<label id="motivoate" style="width: auto" for="subject">
												Detalhe Atendimento
											</label>
											<asp:DropDownList ID="dropMotivosAtendimento" AutoPostBack="true" ClientIDMode="Static" class="form-control" runat="server" DataTextField="ds_Procedimento" DataValueField="cd_Procedimento" OnSelectedIndexChanged="dropMotivosAtendimento_SelectedIndexChanged" Width="241px"></asp:DropDownList>

										</div>
										<div class="form-group">
											<label id="detmotivo" style="width: auto" for="subject">
												Detalhes Motivos
											</label>

											<asp:DropDownList ID="dropDetalhesMotivos" class="form-control" runat="server" DataValueField="Id" DataTextField="ds_descricao" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="dropDetalhesMotivos_SelectedIndexChanged" Width="241px"></asp:DropDownList><br />


											<asp:Button ID="Button1" ClientIDMode="Static" class="btn btn-default btn-lg" runat="server" OnClick="Button1_Click" Text="Remover" />

										</div>
									</div>



									<div class="col-md-6" id="segundaTela" runat="server">
										<div class="form-group">
											<label for="name">
												Detalhes OS</label>
											<textarea name="messageos" style="width: 565px; resize: vertical; height: 120px;" runat="server" id="messageos" class="form-control"
												placeholder="Message"></textarea>

										</div>


										<div class="form-group">
											<label for="name">
												Medidas adotadas</label>
											<textarea runat="server" name="message" style="resize: vertical;" id="message" class="form-control" rows="9" cols="69"
												placeholder="Message"></textarea>
										</div>
									</div>
									<div style="float: right">
										<asp:Button ID="btnEncerrarOs" ClientIDMode="Static" class="btn btn-default btn-lg" runat="server" Text=" Encerrar Os" OnClick="btnEncerrarOs_Click" />

									</div>
								</div>

							</div>
						</div>
					</div>
				</div>

			</div>
			<div runat="server" id="DivResumo" visible="false" class="container">
				<h4 style="text-align: center;width:100%;font-weight: bold;color:#EA8511">Resumo Encerramento Ordem de Serviço</h4>
				<div class="row">
					<div class="col-md-15">
						<div class="well well-sm">

							<div class="row">
								<asp:HiddenField ID="HiddenField3" runat="server" ClientIDMode="Static" />
								<asp:HiddenField ID="HiddenField4" runat="server" ClientIDMode="Static" />
								<asp:HiddenField ID="HiddenField5" runat="server" ClientIDMode="Static" />

								<div class="col-md-6">
									<div class="form-group">
										<label style="width: auto" for="subject">
											Número de OS
										</label>
										<input type="text" runat="server" readonly="readonly" class="form-control" id="EtxtNumeroOS" placeholder="Numero OS" name="EtxtNumeroOS" />
									</div>
									<div class="form-group">
										<label style="width: auto" for="subject">
											Número Peça
										</label>
										<input type="text" runat="server" class="form-control" id="EtxtNumeroPeca" readonly="readonly" placeholder="Numero Peça" name="EtxtNumeroPeca" />
									</div>

									<div class="form-group">
										<label style="width: auto" for="subject">
											Tecnico
										</label>

										<input type="text" runat="server" class="form-control" readonly="readonly" id="EtxtTecnico" name="EtxtTecnico" />

									</div>
                                       <div class="form-group">
										<label style="width: auto" for="subject">
											Data Abertura
										</label>

										<input type="text" runat="server" class="form-control" readonly="readonly" id="EtxtDataAbertura" name="EtxtDataAbertura" />

									</div>
                                    <div class="form-group">
										<label style="width: auto" for="subject">
											Data Encerramento
										</label>

										<input type="text" runat="server" class="form-control" readonly="readonly" id="EtxtDataEncerramento" name="EtxtDataEncerramento" />

									</div>

								</div>
								<div class="col-md-6">
                                    	<div class="form-group">
										<label for="name">
											Informação OS</label>
										<textarea name="etxtInfoOS" style="width: 565px; height: 120px" readonly="readonly" runat="server" id="EtxtInfoOS" class="form-control"
											placeholder="Message"></textarea>

									</div>
									<div class="form-group">
										<label for="name">
											Detalhes OS</label>
										<textarea name="EtxtDetalheOs" style="width: 565px; height: 120px" readonly="readonly" runat="server" id="EtxtDetalheOs" class="form-control"
											placeholder="Message"></textarea>

									</div>
									<div class="form-group">
										<label for="name">
											Medidas adotadas</label>
										<textarea runat="server" name="message" id="EtxtMedidaAdotada" readonly="readonly" class="form-control" rows="9"
											placeholder="Message"></textarea>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>

		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
			<asp:AsyncPostBackTrigger ControlID="btnEncerrarOs" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="slcPesquisa"  />
		</Triggers>
	</asp:UpdatePanel>

	<asp:HiddenField ID="idOSSelecionada" runat="server" ClientIDMode="Static" />
	<input type="text" class="form-control" id="txtIdOsCancela" style="display: none" placeholder="Numero OS" name="txtIdOsCancela" />
	<asp:HiddenField ID="Usuario" runat="server" ClientIDMode="Static" />
	<asp:HiddenField ID="id_grupo" runat="server" ClientIDMode="Static" />

</asp:Content>

