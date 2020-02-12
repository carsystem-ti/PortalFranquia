<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detalhes.aspx.cs" Inherits="PortalFranquia.Estoque.detalhes" %>

<%  
            string iNome = Request.Form["pNomeDiv"] == null ? "" : Request.Form["pNomeDiv"].ToString();

            PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();

            string iNomeDiv;
            int iContador = 0;

            bool isSupervisor = ((PortalFranquia.dao.AcessoLogin)Session["acessoLogin"]).isSupervisor;

            System.Data.DataTable iTabela = iFuncoes.getDetalhesEstoqueLoja(
                Request.Form["pCodigoLocalizacao"].ToString(),
                Request.Form["pTipoEquipamento"].ToString(),
                Convert.ToBoolean(Request.Form["pIsCarSystem"]),
                Convert.ToInt32(Request.Form["pTipoEstoque"]),
                Convert.ToInt32(Request.Form["pStatusInventario"]),
                Request.Form["pVersaoEquipamento"].ToString()
                );
%>
	<div class="caixa" style="max-width:520px;">	
		<div class="tituloTabelas">
<%
            if ( iTabela.Rows.Count == 0 ) {%>
                <h1 class="tituloCaixa">SEM REGISTROS</h1>
                <a href='#' class='botaoVerde B noVisibility'>' Enviar </a>
<%                  
            }
            else
            {
%>
                    <h1 class="tituloCaixa"><%=iTabela.Rows[0]["Titulo"].ToString()%></h1>
            
                    <a id="quantidadeTotal" href='#' class='botaoVerde tituloBotao' onclick="<%=iTabela.Rows[0]["Titulo"].ToString() =="AGUARD. ENVIO"?"javascript:setProtocoloTodos()":""%>"><%=iTabela.Rows.Count.ToString()%></a>
		</div>
		<div id="caixinhaDetalhe" class="caixinha">	    
<%
                foreach (System.Data.DataRow iLinha in iTabela.Rows)
                {
                    iNomeDiv = iFuncoes.getRandomName(iContador);
                    iContador++;
%>
            
                    <div id="<%=iNomeDiv%>">
                        <a class="itemLista">
                            <div class="botaoBranco A identificaPeca"><%=iLinha["id_item"].ToString()%></div>
                            <div class="botaoVerde B <%=iTabela.Rows[0]["Titulo"].ToString() =="AGUARD. ENVIO" && !isSupervisor?"":"noVisibility"%>"
                                onclick="javascript:setStatusEquipamento('<%=iLinha["id_item"].ToString() + "','" + iNome +  "'"%>,$(this), 4);">Enviar</div>
                            <%=iLinha["item"].ToString()%><span>Versao: <%=iLinha["versaoEquipamento"].ToString()%></span>                
                        </a>
                    </div>
<%
                } 
%>         
        </div>
            <h3>Procurar:&nbsp;&nbsp;</h3><input type="text" id="caixaBusca" class="caixaLeitura" value="" onkeyup="javascript: Pesquisa($(this));">
<%
        }
%>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<% 
        string iClass = "";
        if ( ( iTabela.Rows.Count > 0 && iTabela.Rows[0]["Titulo"].ToString()  != "AGUARD. ENVIO" ) || isSupervisor )
            iClass = "noVisibility";    
%>        
            <div class="botaoAzul <%=iClass%>" 
                onclick="javascript:marcarProtocolo('<%= Request.Form["pCodigoLocalizacao"].ToString() %>');" >Protocolo</div>
        
    </div> 
