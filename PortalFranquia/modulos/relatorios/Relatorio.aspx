<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" Inherits="PortalFranquia.Relatorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/Home.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="linhaMenu">
        <asp:HyperLink ID="LinkVendas" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/relatorios/RelPagamentos.aspx">
            <div>
                Pagamentos Serviços
                <br />
                <img src="../../imagens/relatorios/PagamentoServico.jpg" />
            </div>
        </asp:HyperLink>

        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/relatorios/RelOSPendente.aspx">
            <div>
                Pendências
                <br />
                <img src="../../imagens/relatorios/RelOSPendente.jpg" />
            </div>
        </asp:HyperLink>

        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/relatorios/RelVendasFranquia.aspx">
            <div>
                 Vendas
                <br />
                <img src="../../imagens/vendas.jpg" />
            </div>
        </asp:HyperLink>

    </div>
</asp:Content>
