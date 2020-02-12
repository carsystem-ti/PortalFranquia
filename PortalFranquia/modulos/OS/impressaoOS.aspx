<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="impressaoOS.aspx.cs" Inherits="PortalFranquia.modulos.OS.impressaoOS" %>

<!DOCTYPE html>

    <%
        PortalFranquia.dao.resumoOS iFuncoes = new PortalFranquia.dao.resumoOS();

        Int64 iCodigoOS = Convert.ToInt64(Request.Form["pCodigoOS"]);
        
        if ( iCodigoOS == 0 )
            iCodigoOS = Convert.ToInt64(Session["pCodigoOS"]);

        if ((Request.Form["pCodigoOS"] == null || iCodigoOS == 0) && Session["pCodigoOS"] == null)
        {
            Response.Write("<h1>OS NÃO INFORMADA</h1>");
            Response.End();
        }
        
        System.Data.DataTable iTabela = iFuncoes.getOS(Convert.ToInt64(iCodigoOS));

        if (iTabela.Rows[0]["isOsAceita"].ToString() == "0")
        {
            Response.Write("<h1 style='color:red; font-size:32px;'>Esta OS não foi confirmada ( aceita ) nesta franquia, por este motivo não pode ser impressa!</h1>");
            Response.End();
        }
    %>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
		    <title>Ordem de serviço | Relatório</title>
    </head>
	<body topmargin=0 bottommargin=0 leftmargin=0 rightmargin=0>	
		
		<div id="DivRel">				
			<table width=700px border=0 cellspacing=0 cellpadding=0 align=center>
				<tr>
					<td>
						<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td align=left>									
                                    <img src="https://mail.carsystem.com/imagens/logocs.jpg" />
								</td>																															
								<td width=180 align=center>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<strong>Ordem de Serviço</strong> <br>
										<%=iTabela.Rows[0]["Controle de os"].ToString()%>
									</font>
								</td>							
							</tr>											
						</table>
						<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=100% align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<hr></hr>
									</font>
								</td>
						</table>															
						<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=180 align=right>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										Pedido :&nbsp;&nbsp;
									</font>
								</td>
								<td width=60>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<%=iTabela.Rows[0]["pedido"].ToString()%>
									</font>
								</td>							
								<td width=100 align=right>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										Cliente :&nbsp;&nbsp;
									</font>
								</td>
								<td>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<%=iTabela.Rows[0]["Nome"].ToString()%>
									</font>
								</td>														
							</tr>						
						</table>					
						<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=100% align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<hr></hr>
									</font>
								</td>
						</table>										
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=400 align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Endereço do cliente</strong>
									</font>
								</td>							
							</tr>						
						</table>					
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">									
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=iTabela.Rows[0]["Endereço"].ToString()%>
                                                                                                                                    , <%=iTabela.Rows[0]["Cl nmero residencia"].ToString()%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                                      <%=iTabela.Rows[0]["Complemento"].ToString()%>
										                                                                                              <%=iTabela.Rows[0]["Bairro"].ToString()%><br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=iTabela.Rows[0]["cidade"].ToString()%> - <%=iTabela.Rows[0]["uf"].ToString()%><br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ponto de referência : 
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=iTabela.Rows[0]["Ponto de referencia"].ToString()%><br>
									</font>
								</td>
							</tr>						
						</table>										
						<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=180 align=right>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										Telefone :&nbsp;&nbsp;
									</font>
								</td>
								<td width=225>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<%=iTabela.Rows[0]["Tel"].ToString()%>
									</font>
								</td>							
								<td width=180 align=right>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										Celular :&nbsp;&nbsp;
									</font>
								</td>
								<td width=225>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<%=iTabela.Rows[0]["Celular"].ToString()%>
									</font>
								</td>														
							</tr>						
						</table>			
						<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=100% align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<hr></hr>
									</font>
								</td>
						</table>															
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=400 align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Endereço do instalação e ou suporte</strong>
									</font>
								</td>							
							</tr>						
						</table>					
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">									
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=iTabela.Rows[0]["End do chamado"].ToString()%>
                                                                                                                                , <%=iTabela.Rows[0]["N do chamado"].ToString()%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                                  <%=iTabela.Rows[0]["Inf regiao"].ToString()%><br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%=iTabela.Rows[0]["Bairr do chamado"].ToString()%> / <%=iTabela.Rows[0]["Cid do chamado"].ToString()%> - <%=iTabela.Rows[0]["Est do chamado"].ToString()%><br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ponto de referência : <%=iTabela.Rows[0]["Ref para o chamado"].ToString()%><br>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Telefone :&nbsp;&nbsp;<%=iTabela.Rows[0]["F para contato no chamado"].ToString()%>
									</font>
								</td>
							</tr>						
						</table>										
						<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=100% align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<hr></hr>
									</font>
								</td>
						</table>										
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=400 align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dados do veículo</strong>
									</font>
								</td>
							</tr>						
						</table>					
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">									
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <%=iTabela.Rows[0]["Tipo veiculo"].ToString()%> - 
                                        <%=iTabela.Rows[0]["Modelo do veiculo"].ToString()%>&nbsp;
                                        <%=iTabela.Rows[0]["Cor"].ToString()%>&nbsp;
                                        <%=iTabela.Rows[0]["Ano"].ToString()%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STRONG>
                                        <%=iTabela.Rows[0]["Placa do veiculo"].ToString()%></STRONG>
									</font>
								</td>
								<td align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">                                        
                                        Combustível :&nbsp;&nbsp;<%=iTabela.Rows[0]["Comb do veiculo"].ToString()%>                                        
									</font>
								</td>
							</tr>
                            <tr>
                                <td align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">		
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        Renavam :&nbsp;&nbsp;<%=iTabela.Rows[0]["Renavan do veiculo"].ToString()%>							
									</font>
								</td>
                                <td align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">		
                                        Chassi :&nbsp;&nbsp;<%=iTabela.Rows[0]["Chassi do veiculo"].ToString()%>
									</font>
								</td>
                            </tr>
						</table>									
						<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=100% align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<hr></hr>
									</font>
								</td>
						</table>										
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=400 align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Produto:</strong>
                                            <%=iTabela.Rows[0]["P proudto"].ToString()%>&nbsp;&nbsp;&nbsp;VERSÃO:&nbsp;
                                            <%=iTabela.Rows[0]["versaoEquipamento"].ToString()%>&nbsp;&nbsp;&nbsp;ID ATUAL:&nbsp;
                                            <%=iTabela.Rows[0]["Id_anterior"].ToString()%>
									</font>
								</td>							
							</tr>						
						</table>					
						<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=100% align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<hr></hr>
									</font>
								</td>
						</table>										
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=400 align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dados do chamado</strong>
									</font>
								</td>							
							</tr>						
						</table>					
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">									
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Aberta em&nbsp;
                                        <%=Convert.ToDateTime(iTabela.Rows[0]["Aberta em"]).ToString("dd/MM/yyyy")%> às 
                                        <%=Convert.ToDateTime(iTabela.Rows[0]["Aberta as"]).ToString("hh:mm:ss")%> 
                                        (<%=iTabela.Rows[0]["Chamado de"].ToString()%>)<br>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Prevista para&nbsp;
                                        <%=Convert.ToDateTime(iTabela.Rows[0]["Visita marcada para"]).ToString("dd/MM/yyyy")%> às 
                                        <%=Convert.ToDateTime(iTabela.Rows[0]["Hora marcada ou prometida"]).ToString("hh:mm:ss")%>
									</font><br><br>
								</td>
							</tr>						
						</table>
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td width=400 align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">
										<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Informações úteis</strong>
									</font>
								</td>							
							</tr>						
						</table>					
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td align=left>
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2">									
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <%=iTabela.Rows[0]["Informações chamado"].ToString()%><br><br>
									</font>
								</td>
							</tr>						
						</table>
						<table width=100% cellspacing=0 cellpadding=0 align=center>
							<tr>
								<td align=left colspan="3" style="text-align:center;" >
									<font face="Verdana, Arial, Helvetica, sans-serif" size="2" >
										<strong>Estou ciente de que o problema foi solucionado que o sistema e o veículo estão em perfeito funcionamento, sendo que acompanhei o teste do veículo e do sistema.</strong><br><br><br>
									</font>
								</td>
                            </tr>
                            <tr>
                                <td style="width:50%; border-bottom:1px solid;">
                                    
                                </td>
                                <td style="width:40%; border-bottom:0px;">
                                    
                                </td>
                                <td style="width:10%; border-bottom:1px solid;">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
							</tr>						
						</table>					
					</td>
				</tr>						
			</table>
		</div>
		
		<form name=frmSendInformation>								
			<input type=hidden id=txtParametro name=txtParametro value="">			
			<input type=hidden name=txtPagina value="">											
		</form>
									
		<br>
		<br>
		<br>
		<br>
		
	</body>
</html>



