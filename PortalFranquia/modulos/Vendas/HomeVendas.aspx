<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="HomeVendas.aspx.cs" Inherits="PortalFranquia.HomeVendas1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/Home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <br />
    <div class="linhaMenu">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/Vendas/DadosCadastrais.aspx">Gerar Vendas</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulos/Vendas/DadosCadastrais.aspx"><img src="../../imagens/pedidoDeCompras.jpg" /></asp:HyperLink>
        </div>
        <div>
            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/Vendas/MeusPedidosVendas.aspx">Meus Pedidos Vendas</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/modulos/Vendas/MeusPedidosVendas.aspx"><img src="../../imagens/meuspedidos.jpg" /></asp:HyperLink>
        </div>
        <div>
            <asp:HyperLink ID="HyperLink16" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/Vendas/Troca.aspx">Troca de Produto</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/modulos/Vendas/Troca.aspx"><img src="../../imagens/troca/MenuTroca.jpg" /></asp:HyperLink>
            <br />
        </div>
            <asp:HyperLink ID="HyperLink18" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/Vendas/MeusPedidosTroca.aspx">Meus Pedidos Trocas</asp:HyperLink>
            <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/modulos/Vendas/MeusPedidosTroca.aspx"><img src="../../imagens/meuspedidos.jpg" /></asp:HyperLink>
    </div>
    <br />
    <br />
    <div class="linhaMenu">
        <div>
            <asp:HyperLink ID="HyperLink9" runat="server" CssClass="linkMenu" Visible="true">Borderô</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/modulos/Vendas/Bordero.aspx"><img src="../../imagens/Bordero/cheque2.jpg" /></asp:HyperLink>
        </div>
        <div>
            <asp:HyperLink ID="HyperLink11" runat="server" CssClass="linkMenu" Visible="true">Adm Borderô</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/modulos/Vendas/AdmBordero.aspx"><img src="../../imagens/Bordero/Cheques1.jpg"/></asp:HyperLink>
        
        </div>
        <div>
            <asp:HyperLink ID="HyperLink13" runat="server" CssClass="linkMenu">Correção Cheques</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="~/modulos/Vendas/CorrigirCheques.aspx"><img src="../../imagens/Bordero/Cheque.jpg"/></asp:HyperLink>
        
            <br />
        </div>
        <div>
            <asp:HyperLink ID="HyperLink15" runat="server" CssClass="linkMenu">Venda Voucher</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="~/modulos/Vendas/VendaVoucher.aspx"><img src="../../imagens/Bordero/vourcher.jpg"/></asp:HyperLink>
            <br />
        </div>
    </div>
    
</asp:Content>
