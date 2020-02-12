<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="protocolo.aspx.cs" Inherits="PortalFranquia.Estoque.protocolo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/kModal.css" rel="stylesheet" />

    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/jquery.centralize.js"></script>
    <script type="text/javascript" src="../js/kModal.js"></script>
    <script type="text/javascript" src="../js/javaEstoque.js"></script>

    <link href="../css/kEstoque.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="estoqueMaster" class="master" >
	    <div class="caixa">	
		    <div class="tituloTabelas"><h1 class="tituloCaixa">ENVIAR</h1>
                <a href='#' class='botaoAzul <%= isSupervisor?"":"noVisibility"%>' onclick="javascript:exibirProtocoloMaker();"> CRIAR </a>
		    </div>
		    <div class="caixinha">
                <%=getProtocolo(1)%>
		    </div>
	    </div>

	    <div class="caixa">	
		    <div class="tituloTabelas"><h1 class="tituloCaixa">AGUARDANDO</h1>
                <a href='#' class="botaoVerdeFlat noVisibility"> XXXX </a>
		    </div>
		    <div class="caixinha">
                <%=getProtocolo(2)%>
		    </div>
	    </div>
	    <div class="caixa">	
		    <div class="tituloTabelas"><h1 class="tituloCaixa">RECEBER</h1>
                <a href='#' class="botaoVerdeFlat noVisibility"> XXXX </a>
		    </div>
		    <div class="caixinha">
                <%=getProtocolo(3)%>
		    </div>
	    </div>
	    <div class="caixa">	
		    <div class="tituloTabelas"><h1 class="tituloCaixa">CONCLUIDO</h1>
                <a href='#' class="botaoVerdeFlat noVisibility"> XXXX </a>
		    </div>
		    <div class="caixinha">
                <%=getProtocolo(4)%>
		    </div>
	    </div>
        <input id="pecasProtocolos" type="hidden" />

        <div class="noDisplay" >
            <div id="criarProtocolo">
	            <div class="caixa" style="height:300px;">
		            <div class="tituloTabelas" style="height:50px;">
                        <select id="comboCetec">
                            <%
                                PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();

                                foreach (System.Data.DataRow iLinha in iFuncoes.getLojas("").Rows )
                                {
                            %>
                                    <option value="<%=iLinha["cd_cetec"].ToString()%>" ><%=iLinha["ds_franquia"].ToString()%></option>
                            <%}%>
                        </select>

                        <select id="comboTipoEstoque">
                            <!--option value="1" >VENDA</!--option!-->
                            <option value="2">SUPORTE</option>
                            <option value="3">COMPROMETIDO</option>
                        </select>
                        <input id="codigoItem" type="text" value="" onkeypress="javascript: protocoloKeyPress(event);"/>
                        
                        <a href='#' class="botaoAzul comandoProtocolo"onclick="javascript:setProtocolo();"> Protocolar </a>
                        <a href='#' class="botaoVermelho comandoProtocolo" onclick="javascript:$('#itensProtocolo').html(''); $('#pecasProtocolos').val('');"> Limpar </a>
                        <a href='#' id="cmdAdicionaEQP" class="botaoVerde comandoProtocolo" onclick="javascript:getEquipamento($('#codigoItem').val());"> Adicionar </a>
		            </div>
		            <div id="itensProtocolo" class="caixinha" style="height:80%;">                        
		            </div>
	            </div>
            </div>
            <div id="Detalhes" class="master"></div>
        </div>
</asp:Content>
