<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="itensProtocolo.aspx.cs" Inherits="PortalFranquia.Estoque.itensProtocolo" %>

<!DOCTYPE html>

<%
            PortalFranquia.modulos.Estoque.funcoesEstoque iFuncoes = new PortalFranquia.modulos.Estoque.funcoesEstoque();

            int iContador = 0;            
            bool isSupervisor = ((PortalFranquia.dao.AcessoLogin)Session["acessoLogin"]).isSupervisor;
            string iNomeDiv="";
            string iClass = "";
            string iLabelBotao = "";
            string iFuncaoBotao = "recebeItemProtocolo";
            int iStatusProtocolo = Convert.ToInt32(Request.Form["pCodigoStatus"]);
            int iCodigoProtocolo = Convert.ToInt32(Request.Form["pCodigoProtocolo"]);
            

            System.Data.DataTable iTabela = iFuncoes.getDetalhesProtocolo(iCodigoProtocolo);
%>
	<div class="caixa" style="width:610px;">	
		<div class="tituloTabelas">
            <%if ( iTabela.Rows.Count == 0 ) {%>
                <h1 class="tituloCaixa">SEM REGISTROS</h1>
                <a href='#' class='botaoAzul noVisibility'>' Enviar </a>
            <%
                  Response.End();
            }
            else
            {
            %>
                <h1 class="tituloCaixa"><%=iTabela.Rows[0]["Titulo"].ToString()%></h1>
                <a href='#' class='botaoAzul <%= iStatusProtocolo==1?"":"noVisibility" %>  ' onclick="javascript:setStatusProtocolo(<%=iCodigoProtocolo%>, <%= iStatusProtocolo==1?"3":iStatusProtocolo==3?"4":"X" %>)">
                    <%= iStatusProtocolo==1?"Enviar":"XXX" %>  
                </a>
            
            <%}%>
		</div>
		<div id="caixinhaDetalhe" class="caixinha">	    
<%            
            foreach (System.Data.DataRow iLinha in iTabela.Rows)
            {
                iContador++;
                iNomeDiv = iFuncoes.getRandomName(iContador);
            %>
                <div id="<%=iNomeDiv%>">
                    <a class="itemLista">

                        <div class="botaoBranco A identificaPeca"><%=iLinha["id_item"].ToString()%></div>
<%
                    switch (iStatusProtocolo )
                    {
                        case 1:
                            if (isSupervisor){
                                iClass = "botaoVermelho B";
                                iLabelBotao = "Excluir";
                                iFuncaoBotao = "delItemProtocolo";
                            }
                            else
                                iClass = "noVisibility";
                            break;
                        case 3:
                            iClass = "botaoVerde B ";
                            iLabelBotao = "Receber";
                            iFuncaoBotao = "recebeItemProtocolo";
                            break;
                        case 4:
                            iClass = "noVisibility";
                            break;
                    }                    
%>                   
                        <%if (iLabelBotao == "Receber") {%>
                            <div class='botaoVermelho B' onclick="javascript:<%="getMotivos(" + iLinha["codigoItem"].ToString() + ", 1 ,'" +  iLinha["tituloOcorrencia"].ToString() + "');"%>"> Recusar </div>
                        <%}%>
                        <div class='<%=iClass%>' onclick="javascript:<%=iFuncaoBotao 
                                                                                            + "('" + iLinha["id_item"].ToString() + "'"
                                                                                            + "," + Convert.ToInt32(Request.Form["pCodigoProtocolo"]).ToString() 
                                                                                            + ",'" + iNomeDiv + "'"
                                                                                            + ");"%>"> <%=iLabelBotao%> </div>
                        
                            <%=iLinha["item"].ToString()%><span>Versao: <%=iLinha["versaoEquipamento"].ToString()%></span>
	                </a>
                </div>
            <%} %>
        </div>
        <h3>Procurar:&nbsp;&nbsp;</h3><input type="text" id="caixaBusca" class="caixaLeitura" value="" onkeyup="javascript: Pesquisa($(this));"/>
    </div> 
