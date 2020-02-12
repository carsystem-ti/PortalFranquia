<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="DetalhesPecas.aspx.cs" Inherits="PortalFranquia.Compras.DetalhesPecas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link href="../css/detalhesCompras.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div>
        <asp:Panel ID="pnTitulo" runat="server" Visible="false" CssClass="divAzulTitulo">
                    <asp:Label ID="lbTitulo" runat="server" Text="DETALHAMENTO PEDIDO COMPRA "></asp:Label>
                </asp:Panel>
    </div>
    <br />
    <br />
    <br />
    <div style="float:left;margin-left:23%">
        <asp:GridView ID="GridDetalhes" runat="server" AutoGenerateColumns="False"  CssClass="Compras" HeaderStyle-CssClass="AnaliticoHeader"  Width="491px" Font-Names="Verdana" Font-Size="Medium" OnPreRender="GridDetalhes_PreRender">
            <Columns>
                <asp:BoundField DataField="id_pedido" HeaderText="Pedido" />
                <asp:BoundField DataField="ds_franquia" HeaderText="Franquia" />
                <asp:BoundField DataField="id_produto" HeaderText="Código" />
                <asp:BoundField DataField="ds_produto" HeaderText="Produto" />
                <asp:BoundField DataField="id_Sbc" HeaderText="ID" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
