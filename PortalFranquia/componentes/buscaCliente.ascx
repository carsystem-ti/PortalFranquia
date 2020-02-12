<br />
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="buscaCliente.ascx.cs" Inherits="PortalFranquia.componentes.BuscaCliente" %>
<asp:Label ID="lbTitulo" runat="server" Text="Localizar cliente:" ForeColor="White" Font-Bold="true"></asp:Label>
<br />
<asp:Label ID="Label1" runat="server" Text="Pesquisar"></asp:Label>
<asp:DropDownList ID="ddlPesquisa" runat="server" Height="26px"></asp:DropDownList>
&nbsp;
<asp:TextBox ID="txtValorPesquisa" runat="server" Height="24px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredtxtValorPesquisa" runat="server" ErrorMessage="*" ControlToValidate="txtValorPesquisa" CssClass="mensErro"></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btnPesquisa" runat="server" Text="Pesquisar" OnClick="Button1_Click" />