<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="RelOSPendente.aspx.cs" Inherits="PortalFranquia.RelOSPendente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/RelatorioPagamento.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div class="classBody">
       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Label ID="lbMensErro" ForeColor="Red" runat="server" Text="" Visible="false"></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />

            </Triggers>
        </asp:UpdatePanel>

        <asp:Label ID="lbFranquia" runat="server" Text="Selecione a franquia: " Visible="false"></asp:Label>
        <asp:DropDownList ID="ddlFranquia" runat="server" Visible="false" ></asp:DropDownList>
        &nbsp;
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100px" Height="29px" OnClick="btnBuscar_Click" />
        &nbsp;
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnTitulo" runat="server" Visible="false" CssClass="divAzulTitulo">
                    <asp:Label ID="lbTitulo" runat="server" Text="RELATÓRIO DE ORDEM DE SERVIÇO  -  Franquia - CETEC SOCORRO"></asp:Label>
                </asp:Panel>
                <br />
                <asp:Panel ID="pnRelatorio" runat="server" Visible="false">
                    <div class="divAzulTitulo">
                        <asp:Label ID="lbPeriodo" runat="server" Text="O.S. PENDENTES PARA ANÁLISE"></asp:Label>
                    </div>
                    <br />
                    <asp:GridView ID="gridOSPendente" runat="server" CssClass="Analitico" HeaderStyle-CssClass="AnaliticoHeader" ShowFooter="True" FooterStyle-CssClass="AnaliticoFooter" AutoGenerateColumns="false" Width="100%" OnRowDataBound="gridOSPendente_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="Data" HeaderText="Data" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridServicoData" />
                            <asp:BoundField DataField="OS" HeaderText="O.S." ItemStyle-CssClass="colGridServiconrOS" ItemStyle-HorizontalAlign="Right" />                            
                            <asp:BoundField DataField="Contrato" HeaderText="Contrato" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridServicoContrato" />
                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" ItemStyle-CssClass="colGridServicoCliente" />
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo O.S." ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="colGridServicoTpOS" />                            
                            <asp:BoundField DataField="Valor" HeaderText="Valor" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:###,###,##0.00}" ItemStyle-CssClass="colGridServicoValor" />
                            <asp:BoundField DataField="Local" HeaderText="Local" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="colGridServicoLocal" />
                            <asp:BoundField DataField="dt Ult.OS" HeaderText="Dt ult. OS" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="colGridServicoUltOS" />
                            <asp:BoundField DataField="Dias" HeaderText="Nr Dias Ult OS" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="colGridServicoDiasUltOS" />
                            <asp:BoundField DataField="ds_motivo" HeaderText="Motivo" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="colGridServicoDiasUltOS" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
       
<div style="float:right;padding-top: 0px" visible="false">
                <fieldset visible="false">
                <asp:Label ID="lbexportar" runat="server" Text="Exportar para.:" Font-Bold="True" visible="false" ></asp:Label>
                <asp:ImageButton ID="imgexportgridOSPendente" runat="server" Height="30px" AlternateText="Exportar Para o Excel" ImageUrl="~/imagens/relatorios/btn_excel.png"  Width="33px" Visible="false" OnClick="imgexportgridOSPendente_Click" />
                </fieldset>
        <br />
    <br />
    </div>

</asp:Content>
