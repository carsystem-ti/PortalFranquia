<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="RelPagamentos.aspx.cs" Inherits="DPromocional.Relatorio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script runat="server">

   
    
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../../css/RelatorioPagamento.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
       &nbsp;<div class="classBody">
        
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            
                <asp:Label ID="lbMensErro" ForeColor="Red" runat="server" Text="" Visible="false"></asp:Label>
         
            </ContentTemplate>
            <Triggers>
             <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
             <asp:AsyncPostBackTrigger ControlID="lkbtVoltar" EventName="Click" />
             <asp:PostBackTrigger ControlID="imggridDescontosDiversos" />
             <asp:PostBackTrigger ControlID="imggridservicoexterno" />
             <asp:PostBackTrigger ControlID="imggridServicoInterno" />
             <asp:PostBackTrigger ControlID="imggridanaliticoajustcredito" />
             <asp:PostBackTrigger ControlID="imggridForaVendaPolitica" />
             <asp:PostBackTrigger ControlID="imggridVendaPolitica" />


            </Triggers>
        </asp:UpdatePanel>
            
        <br />
        <asp:Label ID="Label1" runat="server" Text="Selecione o período (mês/ano):"></asp:Label>
        <asp:DropDownList ID="ddlMes" runat="server">
            <asp:ListItem Value="1">01</asp:ListItem>
            <asp:ListItem Value="2">02</asp:ListItem>
            <asp:ListItem Value="3">03</asp:ListItem>
            <asp:ListItem Value="4">04</asp:ListItem>
            <asp:ListItem Value="5">05</asp:ListItem>
            <asp:ListItem Value="6">06</asp:ListItem>
            <asp:ListItem Value="7">07</asp:ListItem>
            <asp:ListItem Value="8">08</asp:ListItem>
            <asp:ListItem Value="9">09</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
    <asp:TextBox ID="txtAno" runat="server" Width="50px"></asp:TextBox>
       
        <asp:MaskedEditExtender runat="server"
            ID="MaskAno"
            TargetControlID="txtAno"
            Mask="9999"
            MaskType="Number"
            MessageValidatorTip="true" />
            
        &nbsp;
    <asp:Label ID="lbFranquia" runat="server" Text="Selecione a franquia: " Visible="false"></asp:Label>
        <asp:DropDownList ID="ddlFranquia" runat="server" Visible="false"></asp:DropDownList>
        &nbsp;
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100px" Height="29px" OnClick="btnBuscar_Click" />
        &nbsp;
    <br />
        <br />
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                
                <asp:Panel ID="pnTitulo" runat="server" Visible="false" CssClass="divAzulTitulo">
                    <asp:Label ID="lbTitulo" runat="server" Text="RELATÓRIO DE PAGAMENTOS  -  Franquia  -005601-SUP GUGA"></asp:Label>
                </asp:Panel>
                <br />
                <asp:Panel ID="pnSintetico" runat="server" Visible="false">
                    <div class="divAzulTitulo">
                        <asp:Label ID="lbPeriodo" runat="server" Text="Período de apuração  01/07/2013 a 31/07/2013"></asp:Label>
                    </div>
                    <br />
                    <div>
                        <table class="divCabecGrid" cellspacing="0" rules="all" border="1">
                            <tr>
                                <td class="colPeriodo colFonteNegrito" align="left">CRÉDITOS</td>
                                <td class="colValor colFonteNegrito" align="right">
                                    <asp:Label ID="lbCredito" runat="server" Text="0,00"></asp:Label>
                                </td>
                                <td class="colBotao colFonteNegrito"></td>
                                <td class="colNotaFiscal colFonteNegrito" align="center"></td>
                                <td class="colDataLiberacao colFonteNegrito" align="center"></td>
                                <td class="colDataPagamento colFonteNegrito" align="center"></td>
                                <td class="colResponsavel colFonteNegrito" align="center"></td>
                            </tr>
                            <tr class="Alternado">
                                <td class="colPeriodo colFonteNegrito" align="left">&nbsp;&nbsp;&nbsp;&nbsp;SERVIÇOS/BONUS</td>
                                <td class="colValor colFonteNegrito" align="right">
                                    <asp:Label ID="lbComissoes" runat="server" Text="0,00"></asp:Label>
                                </td>
                                <td class="colBotao colFonteNegrito"></td>
                                <td class="colNotaFiscal colFonteNegrito" align="center">Nota Fiscal</td>
                                <td class="colDataLiberacao colFonteNegrito" align="center">Dt Liberação</td>
                                <td class="colDataPagamento colFonteNegrito" align="center">Dt Pagamento</td>
                                <td class="colResponsavel colFonteNegrito" align="center">Responsável</td>
                            </tr>
                        </table>
                    </div>

                     <asp:GridView ID="gridSintetico" runat="server" ShowHeader="False" Width="100%" AutoGenerateColumns="False" OnRowCommand="gridSintetico_RowCommand">
                        <AlternatingRowStyle CssClass="Alternado" />
                        <Columns>
                            <asp:BoundField DataField="Periodo" ItemStyle-CssClass="colPeriodo" HtmlEncode="false">
                                <ItemStyle CssClass="colPeriodo"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Valor" ItemStyle-CssClass="colValor" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right" CssClass="colValor"></ItemStyle>
                            </asp:BoundField>

                            <asp:ButtonField Text="Analitico" ButtonType="Button" ItemStyle-CssClass="colBotao" ControlStyle-CssClass="btnAnalitico" CommandName="analitico" />

                            <asp:BoundField DataField="NotaFiscal" ItemStyle-CssClass="colNotaFiscal" ItemStyle-HorizontalAlign="center">
                                <ItemStyle HorizontalAlign="center" CssClass="colNotaFiscal"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DataLiberacao" ItemStyle-CssClass="colDataLiberacao">
                                <ItemStyle CssClass="colDataLiberacao" HorizontalAlign="center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DataPagamento" ItemStyle-CssClass="colDataPagamento">
                                <ItemStyle CssClass="colDataPagamento" HorizontalAlign="center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Responsavel" ItemStyle-CssClass="colResponsavel">
                                <ItemStyle CssClass="colResponsavel"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="idAgenda" runat="server" Value='<%#Eval("idAgenda")%> '  />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />

                    <table class="divCabecGrid" cellspacing="0" rules="all" border="1">
                        <tr class="Alternado">
                            <td class="colPeriodo colFonteNegrito" align="left">&nbsp;&nbsp;&nbsp;&nbsp;AJUSTE DE CRÉDITO</td>
                            <td class="colValor colFonteNegrito" align="right">
                                <asp:Label ID="lbTotAjusteCredito" runat="server" Text="0,00"></asp:Label>
                            </td>
                            <td class="colBotao colFonteNegrito"></td>
                            <td class="colNotaFiscal colFonteNegrito" align="center"></td>
                            <td class="colDataLiberacao colFonteNegrito" align="center"></td>
                            <td class="colDataPagamento colFonteNegrito" align="center"></td>
                            <td class="colResponsavel colFonteNegrito" align="center"></td>
                        </tr>
                    </table>
                    <asp:GridView ID="gridSinteticoAjusteCre" runat="server" ShowHeader="False" Width="100%" AutoGenerateColumns="False" OnRowCommand="gridSinteticoAjusteCre_RowCommand">
                        <AlternatingRowStyle CssClass="Alternado" />
                        <Columns>
                            <asp:BoundField DataField="Periodo" ItemStyle-CssClass="colPeriodo" HtmlEncode="false">
                                <ItemStyle CssClass="colPeriodo"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Valor" ItemStyle-CssClass="colValor" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right" CssClass="colValor"></ItemStyle>
                            </asp:BoundField>
                            <asp:ButtonField Text="Analítico" ButtonType="Button" ItemStyle-CssClass="colBotao" ControlStyle-CssClass="btnAnalitico" CommandName="analitico" />
                            <asp:BoundField DataField="NotaFiscal" ItemStyle-CssClass="colNotaFiscal" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right" CssClass="colNotaFiscal"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DataLiberacao" ItemStyle-CssClass="colDataLiberacao">
                                <ItemStyle CssClass="colDataLiberacao" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DataPagamento" ItemStyle-CssClass="colDataPagamento">
                                <ItemStyle CssClass="colDataPagamento" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Responsavel" ItemStyle-CssClass="colResponsavel">
                                <ItemStyle CssClass="colResponsavel"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="idAgenda" runat="server" Value='<%#Eval("idAgenda")%> ' /> 
                                    <asp:HiddenField ID="idLancamento" runat="server" Value='<%#Eval("idLancamento")%> ' /> 
                                    <asp:HiddenField ID="tp" runat="server" Value='11' /> 
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="gridSinteticoCreditos" runat="server" ShowHeader="False" Width="100%" AutoGenerateColumns="False" OnRowCommand="gridSintetico_RowCommand" CssClass="Alternado">
                        <Columns>
                            <asp:BoundField DataField="Lancamento" ItemStyle-CssClass="colPeriodo colFonteNegrito" HtmlEncode="false">
                                <ItemStyle CssClass="colPeriodo colFonteNegrito"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Valor" ItemStyle-CssClass="colValor colFonteNegrito" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right" CssClass="colValor colFonteNegrito"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="botao" ItemStyle-CssClass="colBotao" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right" CssClass="colBotao"></ItemStyle>
                            </asp:BoundField>

                            <asp:BoundField DataField="NotaFiscal" ItemStyle-CssClass="colNotaFiscal" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" CssClass="colNotaFiscal"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DataLiberacao" ItemStyle-CssClass="colDataLiberacao">
                                <ItemStyle CssClass="colDataLiberacao" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DataPagamento" ItemStyle-CssClass="colDataPagamento">
                                <ItemStyle CssClass="colDataPagamento" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Responsavel" ItemStyle-CssClass="colResponsavel">
                                <ItemStyle CssClass="colResponsavel"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="idAgenda" runat="server" Value='<%#Eval("idAgenda")%> ' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <table class="divCabecGrid" cellspacing="0" rules="all" border="1">
                        <tr class="Alternado">
                            <td class="colPeriodo colFonteNegrito" align="left">DEBITOS</td>
                            <td class="colValor colFonteNegrito" align="right">
                                <asp:Label ID="lbTotAjusteDebito" runat="server" Text="0,00"></asp:Label>
                            </td>
                            <td class="colBotao colFonteNegrito"></td>
                            <td class="colNotaFiscal colFonteNegrito" align="center"></td>
                            <td class="colDataLiberacao colFonteNegrito" align="center"></td>
                            <td class="colDataPagamento colFonteNegrito" align="center"></td>
                            <td class="colResponsavel colFonteNegrito" align="center"></td>
                        </tr>
                    </table>
                    <asp:GridView ID="gridSinteticoAjusteDeb" runat="server" ShowHeader="False" Width="100%" AutoGenerateColumns="False" OnRowCommand="gridSinteticoAjusteCre_RowCommand">
                        <AlternatingRowStyle CssClass="Alternado" />
                        <Columns>
                            <asp:BoundField DataField="Periodo" ItemStyle-CssClass="colPeriodo" HtmlEncode="false">
                                <ItemStyle CssClass="colPeriodo"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Valor" ItemStyle-CssClass="colValor" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right" CssClass="colValor"></ItemStyle>
                            </asp:BoundField>

                            <asp:ButtonField Text="Analítico" ButtonType="Button" ItemStyle-CssClass="colBotao" ControlStyle-CssClass="btnAnalitico" CommandName="analitico" />

                            <asp:BoundField DataField="NotaFiscal" ItemStyle-CssClass="colNotaFiscal" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right" CssClass="colNotaFiscal"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DataLiberacao" ItemStyle-CssClass="colDataLiberacao">
                                <ItemStyle CssClass="colDataLiberacao" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DataPagamento" ItemStyle-CssClass="colDataPagamento">
                                <ItemStyle CssClass="colDataPagamento" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Responsavel" ItemStyle-CssClass="colResponsavel">
                                <ItemStyle CssClass="colResponsavel"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="idAgenda" runat="server" Value='<%#Eval("idAgenda")%> ' />
                                    <asp:HiddenField ID="idLancamento" runat="server" Value='<%#Eval("idLancamento")%> ' />
                                    <asp:HiddenField ID="tp" runat="server" Value='11' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <!-- Sintetico Debitos -->
                    <asp:GridView ID="gridSinteticoDebitos" runat="server" ShowHeader="False" Width="100%" AutoGenerateColumns="False" OnRowCommand="gridSinteticoAjusteCre_RowCommand" CssClass="Alternado" OnRowDataBound="gridSinteticoDebitos_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Lancamento" ItemStyle-CssClass="colPeriodo colFonteNegrito" HtmlEncode="false">
                                <ItemStyle CssClass="colPeriodo colFonteNegrito"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Valor" ItemStyle-CssClass="colValor colFonteNegrito" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right" CssClass="colValor colFonteNegrito"></ItemStyle>
                            </asp:BoundField>

                            <asp:ButtonField Text="Analítico" ButtonType="Button" ItemStyle-CssClass="colBotao" ControlStyle-CssClass="btnAnalitico" CommandName="analitico"/>
                            
                            <asp:BoundField DataField="NotaFiscal" ItemStyle-CssClass="colNotaFiscal" ItemStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right" CssClass="colNotaFiscal"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DataLiberacao" ItemStyle-CssClass="colDataLiberacao">
                                <ItemStyle CssClass="colDataLiberacao" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DataPagamento" ItemStyle-CssClass="colDataPagamento">
                                <ItemStyle CssClass="colDataPagamento" HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Responsavel" ItemStyle-CssClass="colResponsavel">
                                <ItemStyle CssClass="colResponsavel"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="idAgenda" runat="server" Value='<%#Eval("idAgenda")%> ' />
                                    <asp:HiddenField ID="idLancamento" runat="server" Value='<%#Eval("idLancamento")%> ' />
                                    <asp:HiddenField ID="tp" runat="server" Value='12' /> 
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    
                    <table class="divCabecGrid" cellspacing="0" rules="all" border="1">
                        <tr>
                            <td class="colPeriodo colFonteNegrito" align="left">SALDO</td>
                            <td class="colValor colFonteNegrito" align="right">
                                <asp:Label ID="lbSaldo" runat="server" Text="0,00"></asp:Label>
                            </td>
                            <td class="colBotao colFonteNegrito"></td>
                            <td class="colNotaFiscal colFonteNegrito" align="center"></td>
                            <td class="colDataLiberacao colFonteNegrito" align="center"></td>
                            <td class="colDataPagamento colFonteNegrito" align="center"></td>
                            <td class="colResponsavel colFonteNegrito" align="center"></td>
                        </tr>
                    </table>
                </asp:Panel>

                <!-- Analitico Venda -->
                <asp:Panel ID="pnAnalitico" runat="server" Visible="false">
                    <div class="divAzulTitulo">
                        <asp:Label ID="lbPeriodoVendaPolitica" runat="server" Text="Período de apuração  01/07/2013 a 31/07/2013"></asp:Label>
                    </div>
                    <asp:GridView ID="gridVendaPolitica" runat="server" CssClass="Analitico" HeaderStyle-CssClass="AnaliticoHeader" ShowFooter="True" FooterStyle-CssClass="AnaliticoFooter" AutoGenerateColumns="false" Width="100%" OnRowDataBound="gridVendaPolitica_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="dt_geracao" HeaderText="Data" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridVendaData" />
                            <asp:BoundField DataField="ds_vendedor" HeaderText="Vendedor" ItemStyle-CssClass="colGridVendaVendedor" />
                            <asp:BoundField DataField="nr_contrato" HeaderText="Contrato" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridVendaContrato" />
                            <asp:BoundField DataField="id_Pedido" HeaderText="CDV" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridVendaCDV" />
                            <asp:BoundField DataField="ds_produto" HeaderText="Produto" ItemStyle-CssClass="colGridVendaProduto" />
                            <asp:BoundField DataField="vl_unitario" HeaderText="Valor" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" ItemStyle-CssClass="colGridVendaValor" />
                            <asp:BoundField DataField="vl_desconto" HeaderText="Desconto" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" ItemStyle-CssClass="colGridVendaDesconto" />
                            <asp:BoundField DataField="pc_desconto" HeaderText="% Desc" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:##0.0}%" ItemStyle-CssClass="colGridVendaPerDesc" />
                            <asp:BoundField DataField="vl_basecom" HeaderText="Vl Cobrado" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" ItemStyle-CssClass="colGridVendaVlCobrado" />
                            <asp:BoundField DataField="tp_pagamento" HeaderText="Forma" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridVendaForma" />
                            <asp:BoundField DataField="vl_comissao" HeaderText="Comissão" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" ItemStyle-CssClass="colGridVendaComissao" />
                            <asp:BoundField DataField="pc_com" HeaderText="%" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:0.00}%" ItemStyle-CssClass="colGridVendaPer" />
                            <asp:BoundField DataField="tp_comissao" HeaderText="Tipo" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridVendaTipo" />
                            <asp:BoundField DataField="tp_lancamento" HeaderText="D/C" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridVendaDC" />
                            <asp:BoundField DataField="nr_diasCancelamento" HeaderText="Nr Dias Canc." ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridVendaNrDiasCanc" />
                            <asp:BoundField DataField="nr_parcelas" HeaderText="Nr Parcelas" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridVendaNrParcelas" />
                        </Columns>
                    </asp:GridView>
                <div style="float:right;padding-top: 0px" visible="true">
                <fieldset visible="true">
                <asp:Label ID="lbexportvendapolitica" runat="server" Text="Exportar para.:" Font-Bold="True" visible="false" ></asp:Label>
                <asp:ImageButton ID="imggridVendaPolitica" runat="server" Height="30px" AlternateText="Exportar Para o Excel" ImageUrl="~/imagens/relatorios/btn_excel.png"  Width="33px" Visible="false" OnClick="imggridVendaPolitica_Click"  />
          &nbsp;
                </fieldset>
                </div><br /><br />

                    
                    <div class="divAzulTitulo">
                        <asp:Label ID="lbPeriodoVendaNaoPolitica" runat="server" Text="Período de apuração  01/07/2013 a 31/07/2013"></asp:Label>
                    </div>
                    <asp:GridView ID="gridForaVendaPolitica" runat="server" CssClass="Analitico" HeaderStyle-CssClass="AnaliticoHeader" ShowFooter="True" FooterStyle-CssClass="AnaliticoFooter" AutoGenerateColumns="false" Width="100%" OnRowDataBound="gridVendaPolitica_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="dt_geracao" HeaderText="Data" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridVendaData" />
                            <asp:BoundField DataField="ds_vendedor" HeaderText="Vendedor" ItemStyle-CssClass="colGridVendaVendedor" />
                            <asp:BoundField DataField="nr_contrato" HeaderText="Contrato" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridVendaContrato" />
                            <asp:BoundField DataField="id_Pedido" HeaderText="CDV" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridVendaCDV" />
                            <asp:BoundField DataField="ds_produto" HeaderText="Produto" ItemStyle-CssClass="colGridVendaProduto" />
                            <asp:BoundField DataField="vl_unitario" HeaderText="Valor" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" ItemStyle-CssClass="colGridVendaValor" />
                            <asp:BoundField DataField="vl_desconto" HeaderText="Desconto" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" ItemStyle-CssClass="colGridVendaDesconto" />
                            <asp:BoundField DataField="pc_desconto" HeaderText="% Desc" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:##0.0}%" ItemStyle-CssClass="colGridVendaPerDesc" />
                            <asp:BoundField DataField="vl_basecom" HeaderText="Vl Cobrado" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" ItemStyle-CssClass="colGridVendaVlCobrado" />
                            <asp:BoundField DataField="tp_pagamento" HeaderText="Forma" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridVendaForma" />
                            <asp:BoundField DataField="vl_comissao" HeaderText="Comissão" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" ItemStyle-CssClass="colGridVendaComissao" />
                            <asp:BoundField DataField="pc_com" HeaderText="%" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:0.00}%" ItemStyle-CssClass="colGridVendaPer" />
                            <asp:BoundField DataField="tp_comissao" HeaderText="Tipo" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridVendaTipo" />
                            <asp:BoundField DataField="tp_lancamento" HeaderText="D/C" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridVendaDC" />
                            <asp:BoundField DataField="nr_diasCancelamento" HeaderText="Nr Dias Canc." ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridVendaNrDiasCanc" />
                            <asp:BoundField DataField="nr_parcelas" HeaderText="Nr Parcelas" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridVendaNrParcelas" />
                        </Columns>
                    </asp:GridView>
                     <div style="float:right;padding-top: 0px" visible="true">
                <fieldset visible="true">
                <asp:Label ID="lbexportaforavendapolitica" runat="server" Text="Exportar para.:" Font-Bold="True" visible="false" ></asp:Label>
                <asp:ImageButton ID="imggridForaVendaPolitica" runat="server" Height="30px" AlternateText="Exportar Para o Excel" ImageUrl="~/imagens/relatorios/btn_excel.png"  Width="33px" Visible="false" OnClick="imggridForaVendaPolitica_Click1"  />
          &nbsp;
                </fieldset>
                </div>

                    <br />
                    <table class="tbTotalGeral">
                        <tr class="AnaliticoFooter">
                            <td align="center" class="colGridVendaData" colspan="5">Total do Período</td>
                            <td align="right" class="colGridVendaValor">
                                <asp:Label ID="lbTotValor" runat="server" Text="0"></asp:Label></td>
                            <td align="right" class="colGridVendaDesconto">
                                <asp:Label ID="lbTotDesconto" runat="server" Text="0"></asp:Label></td>
                            <td align="right" class="colGridVendaPerDesc">
                                <asp:Label ID="lbTotPerDesc" runat="server" Text="0"></asp:Label></td>
                            <td align="right" class="colGridVendaVlCobrado">
                                <asp:Label ID="lbTotVlCobrado" runat="server" Text="0"></asp:Label></td>
                            <td align="center" class="colGridVendaForma"></td>
                            <td align="right" class="colGridVendaComissao">
                                <asp:Label ID="lbTotComissao" runat="server" Text="0"></asp:Label></td>
                            <td align="right" class="colGridVendaPer"></td>
                            <td align="center" class="colGridVendaTipo"></td>
                            <td align="center" class="colGridVendaDC"></td>
                            <td align="right" class="colGridVendaNrDiasCanc"></td>
                            <td align="right" class="colGridVendaNrParcelas"></td>
                        </tr>
                        <tr>
                            <td align="center" class="colGridVendaData"></td>
                            <td class="colGridVendaVendedor"></td>
                            <td align="right" class="colGridVendaContrato"></td>
                            <td align="right" class="colGridVendaCDV"></td>
                            <td class="colGridVendaProduto"></td>
                            <td align="right" class="colGridVendaValor"></td>
                            <td align="right" class="colGridVendaDesconto"></td>
                            <td align="right" class="colGridVendaPerDesc"></td>
                            <td align="right" class="colGridVendaVlCobrado"></td>
                            <td align="center" class="colGridVendaForma"></td>
                            <td align="right" class="colGridVendaComissao"></td>
                            <td align="right" class="colGridVendaPer"></td>
                            <td align="center" class="colGridVendaTipo"></td>
                            <td align="center" class="colGridVendaDC"></td>
                            <td align="right" class="colGridVendaNrDiasCanc"></td>
                            <td align="right" class="colGridVendaNrParcelas"></td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table>
                        <tr>
                            <th align="left">Forma</th>
                            <th align="left">Tipo</th>
                            <th align="left">D/C</th>
                            <th align="left">Nr Dias Canc.</th>
                        </tr>
                        <tr class="Alternado">
                            <td>CC- Cartão Crédito</td>
                            <td>P-Produto</td>
                            <td>D- Débito</td>
                            <td>Número de dias entre a confirmação e o cancelamento da venda</td>
                        </tr>
                        <tr class="Alternado">
                            <td>DEP- Depósito</td>
                            <td>S-Serviço</td>
                            <td>C-Crédito</td>
                        </tr>
                        <tr class="Alternado">
                            <td>CH- Cheque</td>
                            <td>M-Migração</td>
                        </tr>
                        <tr class="Alternado">
                            <td>DIN -Dinheiro</td>
                            <td>T-Troca</td>
                        </tr>
                        <tr class="Alternado">
                            <td>FIN -Financeiro</td>
                            <td>A-Acessório</td>
                        </tr>
                        <tr class="Alternado">
                            <td>AV -Avista</td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="pnAnaliticoAjusteCredito" runat="server" Visible="false">
                    <asp:GridView ID="gridAnaliticoAjusteCredito" runat="server" CssClass="Analitico" HeaderStyle-CssClass="AnaliticoHeader" ShowFooter="True" FooterStyle-CssClass="AnaliticoFooter" AutoGenerateColumns="false" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="Valor" HeaderText="Valor" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" >
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Data" HeaderText="Data" ItemStyle-HorizontalAlign="Center" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Usuario" HeaderText="Usuário" />
                            <asp:BoundField DataField="Obs" HeaderText="Observação" />
                        </Columns>
                        <FooterStyle CssClass="AnaliticoFooter" />
                        <HeaderStyle CssClass="AnaliticoHeader" />
                    </asp:GridView>
                    
                    <div style="float:right;padding-top: 0px" visible="true">
                <fieldset visible="true">
                <asp:Label ID="lbexportarajustcredito" runat="server" Text="Exportar para.:" Font-Bold="True" visible="false" ></asp:Label>
                <asp:ImageButton ID="imggridanaliticoajustcredito" runat="server" Height="30px" AlternateText="Exportar Para o Excel" ImageUrl="~/imagens/relatorios/btn_excel.png"  Width="33px" Visible="false" OnClick="imggridanaliticoajustcredito_Click"  />
          &nbsp;
                </fieldset>
                </asp:Panel></div>


                <!-- Desconto NF Serviços -->
                <asp:Panel ID="pnDescontosDiversos" runat="server" Visible="false">
                    <asp:GridView ID="gridDescontosDiversos"  runat="server" CssClass="Analitico" HeaderStyle-CssClass="AnaliticoHeader" ShowFooter="true" FooterStyle-CssClass="AnaliticoFooter" AutoGenerateColumns="false" Width="100%">
                        <Columns>
                             <asp:BoundField DataField="id_pedido" HeaderText="Pedido" ItemStyle-HorizontalAlign="Left" >
                             <ItemStyle HorizontalAlign="Left"  />
                             </asp:BoundField>
                            <asp:BoundField DataField="id_item" HeaderText="Item" ItemStyle-HorizontalAlign="Left" >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ds_vendedor" HeaderText="Vendedor" />
                            <asp:BoundField DataField="nr_contrato" HeaderText="Contrato" />
                            <asp:BoundField DataField="ds_nome" HeaderText="Nome" />
                            <asp:BoundField DataField="ds_produto" HeaderText="Produto" />
                            <asp:BoundField DataField="dt_confirmacao" HeaderText="Data Confirmação" ItemStyle-HorizontalAlign="Center" >
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="vl_notaFiscalcs" HeaderText="NF Carsystem" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:c}"  >
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField >
                            </Columns>
                        <FooterStyle CssClass="AnaliticoFooter" />
                        <HeaderStyle CssClass="AnaliticoHeader" />
                    </asp:GridView>

                   
                 <div style="float:right;padding-top: 0px" visible="false">
                <fieldset visible="true">
                <asp:Label ID="lbexportar" runat="server" Text="Exportar para.:" Font-Bold="True" visible="false" ></asp:Label>
                <asp:ImageButton ID="imggridDescontosDiversos" runat="server" Height="30px" AlternateText="Exportar Para o Excel" ImageUrl="~/imagens/relatorios/btn_excel.png"  Width="33px" Visible="false" OnClick="imggridDescontosDiversos_Click"  />
          &nbsp;
                </fieldset>
                </asp:Panel></div>
                 

                <!-- Analitico Serviço -->
                <asp:Panel ID="pnAnaliticoServico" runat="server" Visible="false">
                    <div class="divAzulTitulo">
                        <asp:Label ID="lbPeriodoServicoInterno" runat="server" Text="Período de apuração  01/07/2013 a 31/07/2013"></asp:Label>
                    </div>
                    <asp:GridView ID="gridServicoInterno" runat="server" CssClass="Analitico" HeaderStyle-CssClass="AnaliticoHeader" ShowFooter="True" FooterStyle-CssClass="AnaliticoFooter" AutoGenerateColumns="false" Width="100%" OnRowDataBound="gridServicoInterno_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="dt_encerramento" HeaderText="Data" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridServicoData" />
                            <asp:BoundField DataField="nr_os" HeaderText="O.S." ItemStyle-CssClass="colGridServiconrOS" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="ds_tecnico" HeaderText="Técnico" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="colGridServicoTecnico" />
                            <asp:BoundField DataField="nr_contrato" HeaderText="Contrato" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridServicoContrato" />
                            <asp:BoundField DataField="ds_cliente" HeaderText="Cliente" ItemStyle-CssClass="colGridServicoCliente" />
                            <asp:BoundField DataField="tp_os" HeaderText="Tipo O.S." ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="colGridServicoTpOS" />
                            <asp:BoundField DataField="ds_produto" HeaderText="Produto" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="colGridServicoProduto" />
                            <asp:BoundField DataField="vl_servico" HeaderText="Valor" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" ItemStyle-CssClass="colGridServicoValor" />
                            <asp:BoundField DataField="ds_local" HeaderText="Local" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="colGridServicoLocal" />
                            <asp:BoundField DataField="dt_ultOs" HeaderText="Dt ult. OS" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridServicoUltOS" />
                            <asp:BoundField DataField="nr_diasUltOs" HeaderText="Nr Dias Ult OS" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridServicoDiasUltOS" />
                        </Columns>
                    </asp:GridView>
                    
                    <div style="float:right;padding-top: 0px" visible="true">
                    <fieldset visible="true">
                    <asp:Label ID="lbexportserveinterno" runat="server" Text="Exportar para.:" Font-Bold="True" visible="false" ></asp:Label>
                    <asp:ImageButton ID="imggridServicoInterno" runat="server" Height="30px" AlternateText="Exportar Para o Excel" ImageUrl="~/imagens/relatorios/btn_excel.png"  Width="33px" Visible="false" OnClick="imggridServicoInterno_Click"  />
                    &nbsp;
                    </fieldset></panel>
                    </div>
                    <br />
                    <br /><br />
                    <div class="divAzulTitulo">
                        <asp:Label ID="lbPeriodoServicoExterno" runat="server" Text="Período de apuração  01/07/2013 a 31/07/2013"></asp:Label>
                    </div>
                    <asp:GridView ID="gridServicoExterno" runat="server" CssClass="Analitico" HeaderStyle-CssClass="AnaliticoHeader" ShowFooter="True" FooterStyle-CssClass="AnaliticoFooter" AutoGenerateColumns="false" Width="100%" OnRowDataBound="gridServicoInterno_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="dt_encerramento" HeaderText="Data" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridServicoData" />
                            <asp:BoundField DataField="nr_os" HeaderText="O.S." ItemStyle-CssClass="colGridServiconrOS" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="ds_tecnico" HeaderText="Técnico" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="colGridServicoTecnico" />
                            <asp:BoundField DataField="nr_contrato" HeaderText="Contrato" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridServicoContrato" />
                            <asp:BoundField DataField="ds_cliente" HeaderText="Cliente" ItemStyle-CssClass="colGridServicoCliente" />
                            <asp:BoundField DataField="tp_os" HeaderText="Tipo O.S." ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="colGridServicoTpOS" />
                            <asp:BoundField DataField="ds_produto" HeaderText="Produto" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="colGridServicoProduto" />
                            <asp:BoundField DataField="vl_servico" HeaderText="Valor" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" ItemStyle-CssClass="colGridServicoValor" />
                            <asp:BoundField DataField="ds_local" HeaderText="Local" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="colGridServicoLocal" />
                            <asp:BoundField DataField="dt_ultOs" HeaderText="Dt ult. OS" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridServicoUltOS" />
                            <asp:BoundField DataField="nr_diasUltOs" HeaderText="Nr Dias Ult OS" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridServicoDiasUltOS" />
                        </Columns>
                    </asp:GridView>
                    <div style="float:right;padding-top: 0px" visible="true">
                    <fieldset visible="true">
                    <asp:Label ID="lbexportservexterno" runat="server" Text="Exportar para.:" Font-Bold="True" visible="false" ></asp:Label>
                    <asp:ImageButton ID="imggridservicoexterno" runat="server" Height="30px" AlternateText="Exportar Para o Excel" ImageUrl="~/imagens/relatorios/btn_excel.png"  Width="33px" Visible="false" OnClick="imggridservicoexterno_Click"  />
          &nbsp;
                    </fieldset></panel>
                    </div>
                   
                    <br />
                    <table class="tbTotalGeral">
                        <tr class="AnaliticoFooter">
                            <td align="right" class="colGridServicoData" colspan="7">Total do Período</td>
                            <td align="right" class="colGridServicoValor">
                                <asp:Label ID="lbTotValorServico" runat="server" Text="0" CssClass="classBody"></asp:Label></td>
                            <td align="right" class="colGridServicoLocal"></td>
                            <td align="right" class="colGridServicoUltOS"></td>
                            <td align="right" class="colGridServicoDiasUltOS"></td>
                        </tr>
                        <tr>
                            <td align="center" class="colGridServicoData"></td>
                            <td align="center" class="colGridServiconrOS"></td>
                            <td align="center" class="colGridServicoTecnico"></td>
                            <td align="center" class="colGridServicoContrato"></td>
                            <td align="center" class="colGridServicoCliente"></td>
                            <td align="center" class="colGridServicoTpOS"></td>
                            <td align="center" class="colGridServicoProduto"></td>
                            <td align="right" class="colGridServicoValor"></td>
                            <td align="right" class="colGridServicoLocal"></td>
                            <td align="right" class="colGridServicoUltOS"></td>
                            <td align="right" class="colGridServicoDiasUltOS"></td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
             <asp:ASyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
             <asp:AsyncPostBackTrigger ControlID="lkbtVoltar" EventName="Click" />
             <asp:PostBackTrigger ControlID="imggridDescontosDiversos"  />
             <asp:PostBackTrigger ControlID="imggridservicoexterno" />
             <asp:PostBackTrigger ControlID="imggridServicoInterno" />
             <asp:PostBackTrigger ControlID="imggridanaliticoajustcredito" />
             <asp:PostBackTrigger ControlID="imggridForaVendaPolitica" />
             <asp:PostBackTrigger ControlID="imggridVendaPolitica" />




            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
