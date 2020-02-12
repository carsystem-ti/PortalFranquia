<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="OS.aspx.cs" Inherits="PortalFranquia.modulos.OS.OS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/Home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="linhaMenu">
        <asp:HyperLink ID="LinkVendas" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/OS/AberturaOs.aspx">
            <div>
                Abrir O.S.
                <br />
                <img src="../../imagens/OS/AbrirOS.jpg" />
            </div>
        </asp:HyperLink>

        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="linkMenu"  NavigateUrl="~/modulos/OS/OSsAbertas.aspx">
            <div>
                O.S. Abertas
                <br />
                <img src="../../imagens/OS/OSAberta.jpg"/>
            </div>
        </asp:HyperLink>
        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/OS/historicoEquipamento.aspx"><%-- NavigateUrl="~/WebVendas.aspx" --%>
            <div>
                Hist&oacute;rico Equipamentos
                <br />
                <img src="../../imagens/pesquisaHistorico.jpg" />
            </div>
        </asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/OS/promocoes.aspx"><%-- NavigateUrl="~/WebVendas.aspx" --%>
            <div>
                Promoções
                <br />
                <img src="../../imagens/promocao.jpg" />
            </div>
        </asp:HyperLink>
    </div>
      <br />
    <br />
    <div class="linhaMenu">
          <asp:HyperLink ID="HyperLink11" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/OS/resumoOS.aspx">
            <div>
                Agenda
                <br />
                <img alt="" src="../../imagens/agenda.jpg" />
            </div>
        </asp:HyperLink>
       <asp:HyperLink ID="HyperLink16" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/OS/aprovaTroca.aspx"> 
            <div>
                Aprovação Plus
                <br />
                <img alt="" src="../../imagens/TrocaProprietario.jpg" />
            </div>
        </asp:HyperLink>
        <asp:HyperLink ID="HyperLink13" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/OS/documentos.aspx">
            <div>
                Documentos
            <br />
                <img alt="" src="../../imagens/documentos.png" />
            </div>
        </asp:HyperLink>
        <asp:HyperLink ID="HyperLink15" runat="server" CssClass="linkMenu"> 
            <div>
                
                <br />
                
            </div>
        </asp:HyperLink>
        <br />
    </div>
</asp:Content>
