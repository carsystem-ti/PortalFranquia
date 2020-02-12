<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="promocoes.aspx.cs" Inherits="PortalFranquia.modulos.OS.promocoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Contrato:"></asp:Label>
    <asp:TextBox ID="txtContrato" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Voucher:"></asp:Label>
    <asp:TextBox ID="txtVoucher" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Baixar" OnClick="Button1_Click" />
    <br />
    <br />
    <br />
    <asp:Label ID="lbMensagem" runat="server" Text="" CssClass="mensErro" Visible="false"></asp:Label>
</asp:Content>
