<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="homeEstoque.aspx.cs" Inherits="PortalFranquia.homeEstoque" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <link href="css/Home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div class="linhaMenu">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="linkMenu" NavigateUrl="~/Estoque/tabelas.aspx">Produtos em Estoque</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Estoque/tabelas.aspx"><img src="imagens/emEstoque.png" /></asp:HyperLink>
        </div>
        <div>
            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="linkMenu" NavigateUrl="~/Compras/FranquiaEstoque.aspx">Compras</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Compras/FranquiaEstoque.aspx"><img  src="imagens/meuspedidos.jpg" /></asp:HyperLink>
        </div>
        <div>            
            <asp:HyperLink ID="HyperLink7" runat="server" CssClass="linkMenu" Visible="True" NavigateUrl="~/Estoque/movimentacao.aspx">Movimentação</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Estoque/movimentacao.aspx"><img  src="imagens/movimentacao.png" /></asp:HyperLink>
        </div>
    </div>
    <br />
    <br />
    <div class="linhaMenu">
        <div>
            <asp:HyperLink ID="HyperLink9" runat="server" CssClass="linkMenu" Visible="False">Espaço vazio</asp:HyperLink>
            <br />
        </div>
        <div>
            <asp:HyperLink ID="HyperLink11" runat="server" CssClass="linkMenu" Visible="False">Espaço vazio</asp:HyperLink>
            <br />
        </div>
        <div>
            <asp:HyperLink ID="HyperLink13" runat="server" CssClass="linkMenu" Visible="False">Espaço vazio</asp:HyperLink>
            <br />
        </div>
        <div>
            <asp:HyperLink ID="HyperLink15" runat="server" CssClass="linkMenu" Visible="False">Espaço vazio</asp:HyperLink>
            <br />
        </div>
    </div>
</asp:Content>
