<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="HomeCompras.aspx.cs" Inherits="PortalFranquia.HomeVendas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/Home.css" rel="stylesheet" />
    <link href="css/Home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <div class="linhaMenu">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="linkMenu" NavigateUrl="~/Compras/FranquiaCompra.aspx">Pedidos Compras</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Compras/FranquiaCompra.aspx"><img src="../imagens/pedidoDeCompras.jpg" /></asp:HyperLink>
        </div>
        <div>
            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="linkMenu" NavigateUrl="~/Compras/FranquiaPedido.aspx">Meus Pedidos</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Compras/FranquiaPedido.aspx"><img src="../imagens/meusPedidos.jpg" /></asp:HyperLink>
        </div>
        <div>
            <asp:HyperLink ID="HyperLink7" runat="server" CssClass="linkMenu" >Pedidos/ID´S</asp:HyperLink>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Compras/AdmFranquia.aspx"><img src="../imagens/estoque.jpg" /></asp:HyperLink>
            <br />
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
