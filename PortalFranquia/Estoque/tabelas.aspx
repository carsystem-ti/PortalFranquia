<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="tabelas.aspx.cs" Inherits="PortalFranquia.Estoque.tabelas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/kModal.css" rel="stylesheet" />

    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/jquery.centralize.js"></script>
    <script type="text/javascript" src="../js/kModal.js?24032014"></script>
    <script type="text/javascript" src="../js/jquery.PrintArea.js"></script>
    <script type="text/javascript" src="../js/javaEstoque.js?24032014"></script>

    <link href="../css/kEstoque.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="script-warning"></div>
    <div class="menu">
        <table class="cetec">
            <%
                string iScript = "";
                System.Globalization.TextInfo altText = new System.Globalization.CultureInfo("en-US", false).TextInfo;
                    
                PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();

                foreach (System.Data.DataRow iLinha in iFuncoes.getLojas(codigoGrupo == 38 || codigoGrupo == 33 || codigoGrupo == 21 ? "" : codigoLoja).Rows)
                {
                    if (iScript == "")
                        iScript = "javascript:getEstoque('" + iLinha["cd_cetec"].ToString() + "', '" + iLinha["ds_franquia"].ToString() + "')";
            %>
                    <tr><td class="<%=iLinha["cor"].ToString()%> naoComum" onclick="javascript:getEstoque('<%=iLinha["cd_cetec"].ToString()%>', '<%=iLinha["ds_franquia"].ToString()%>')"><%=iLinha["ds_franquia"].ToString()%></td></tr>
            <%}%>
            <tr><td id="btnProtocolo"  class="botaoAzul naoComum" onclick="javascript:getProtocolo('<%=codigoGrupo == 38 || codigoGrupo == 33 || codigoGrupo == 21 ? "" : codigoLoja %>')" >Protocolo</td></tr>
        </table>
        <script><%=iScript%></script>
    </div>
    <div id="estoqueMaster" class="master" >
	    <div class="caixa">	
		    <div class="tituloTabelas"><h1 class="tituloCaixa">VENDAS FRANQUIA</h1>
                <a href='#' class="botao<%=altText.ToTitleCase(resumos[0].cor)%> tituloBotao" 
                    onclick="javascript:getDetalhes('<%=codigoLoja%>','',false,1,1,'','');"> <%= resumos[0].quantidade.ToString() %> </a>
		    </div>
		    <div class="caixinha">
                    <%=resumos[0].detalhe%>
		    </div>
	    </div>
	    <div class="caixa">	
		    <div class="tituloTabelas">
                <h1 class="tituloCaixa">SUPORTE</h1>
                <a href='#' class="botao<%=altText.ToTitleCase(resumos[1].cor)%> tituloBotao" 
                    onclick="javascript:getDetalhes('<%=codigoLoja%>','',true,2,1,'','');"> <%=resumos[1].quantidade.ToString() %> </a>
		    </div>
		    <div class="caixinha">
                    <%=resumos[1].detalhe%>
		    </div>
	    </div>
	    <div class="caixa">	
		    <div class="tituloTabelas">
                <h1 class="tituloCaixa">VENDAS CARSYSTEM</h1>
                <a href='#' class="botao<%=altText.ToTitleCase(resumos[2].cor)%> tituloBotao" 
                    onclick="javascript:getDetalhes('<%=codigoLoja%>','',true,1,1,'','');">  <%=resumos[2].quantidade.ToString() %> </a>
		    </div>
		    <div class="caixinha">
                    <%=resumos[2].detalhe%>
		    </div>
	    </div>
	    <div class="caixa">	
		    <div class="tituloTabelas">
                <h1 class="tituloCaixa">REPOSICAO</h1>                
                <a id="quantidadeTotal" href='#' class="botaoVerde tituloBotao" 
                    onclick="javascript:getDetalhes('<%=codigoLoja%>','',true,2,3,'','');"> <%=resumos[3].quantidade.ToString()%> </a>
		    </div>
		    <div id="caixinhaReposicao" class="caixinha">
                    <%=resumos[3].detalhe%>
		    </div>

	    </div>
    </div>

    <div class="noDisplay" >
        <div id="Detalhes" class="master"></div>
    </div>
</asp:Content>
