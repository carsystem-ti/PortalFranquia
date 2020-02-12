<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="PortalFranquia.modulos.Cliente.Cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/Home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <%--<asp:Label ID="lbMensErro" runat="server" Text="" Visible="false" CssClass="mensErro"></asp:Label>--%>
    <div class="linhaMenu">
        <asp:HyperLink ID="DebitoAutomatico" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/Cliente/DebitoAutomatico.aspx"><%-- NavigateUrl="~/HomeVendas.aspx" --%>
            <div>
               Transferencia de Veiculo
                <br />
                <img alt="Transferencia" src="../../imagens/Cliente/Transferencia.jpg" />
            </div>
        </asp:HyperLink>
        
        <asp:HyperLink ID="OrdemServico" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/Cliente/OrdemServico.aspx"><%-- NavigateUrl="~/HomeVendas.aspx" --%>
            <div>
               Ordem de Serviço
                <br />
                <img alt="Ordem de Serviço" src="../../imagens/Cliente/manutencao.jpg" />
            </div>
        </asp:HyperLink>
        <%--<asp:HyperLink ID="HyperLink3" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/Vendas/HomeVendas.aspx"><%-- NavigateUrl="~/WebVendas.aspx" --%>
      <%--  <div>
            Vendas
                <br />
            <img alt="" src="imagens/vendas.jpg" />
        </div>--%>
        <%--</asp:HyperLink>--%>
        <%--<asp:HyperLink ID="HyperLink5" runat="server" CssClass="linkMenu">
            <div>
                Cliente
                <br />
                <img alt="" src="imagens/cliente.jpg" />
            </div>
        </asp:HyperLink>--%>
        <%--<asp:HyperLink ID="HyperLink7" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/OS/OS.aspx">
            <div>
                Ordem de Serviço
                <br />
                <img alt="" src="imagens/ordemDeServico.jpg" />
            </div>
        </asp:HyperLink>--%>
    </div>
    <br />
    <br />
    <div class="linhaMenu">
        <%--<asp:HyperLink ID="HyperLink9" runat="server" CssClass="linkMenu">
            <div>
                Caixa
                <br />
                <img alt="" src="imagens/caixa.jpg" />
            </div>
        </asp:HyperLink>
       <asp:HyperLink ID="HyperLink16" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/Chamado/Menu.aspx"> 
            <div>
                     S.A.F            
                <br />
                <img alt="" src="imagens/chamado/Menuchamado.jpg" />               
            </div>
        </asp:HyperLink>
        <asp:HyperLink ID="HyperLink13" runat="server" CssClass="linkMenu" NavigateUrl="~/modulos/relatorios/Relatorio.aspx">
            <div>
                Relatórios
            <br />
                <img alt="" src="imagens/relatorios.jpg" />
            </div>
        </asp:HyperLink>
        <asp:HyperLink ID="HyperLink15" runat="server" CssClass="linkMenu" NavigateUrl="~/homeEstoque.aspx"> 
            <div>
                Estoque            
                <br />
                <img alt="" src="imagens/estoque.jpg" />               
            </div>
        </asp:HyperLink>--%>
        <br />
    </div>
</asp:Content>


