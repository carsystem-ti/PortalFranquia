<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Contrato.aspx.cs" Inherits="PortalFranquia.Contrato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="linhaMenu">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/Cliente/CadastroCliente.aspx">Cadastro Cliente</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/modulos/Cliente/CadastroCliente.aspx"><img  src="imagens/cadastroCliente.jpg" /></asp:HyperLink>
        </div>
        <div>
            <asp:HyperLink ID="HyperLink3" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/OS/OS.aspx">Ordem de Serviço</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/modulos/OS/OS.aspx"><img src="imagens/OrdemDeServico.jpg" /></asp:HyperLink>
        </div>
        <div>
            <asp:HyperLink ID="HyperLink5" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/OS/OS.aspx">Técnicos</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Tecnicos.aspx"><img src="imagens/Tecnicos.jpg" /></asp:HyperLink>
        </div>
        <div>
            <asp:HyperLink ID="HyperLink6" runat="server" CssClass="linkMenu" Visible="False">Espaço vazio</asp:HyperLink>
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
