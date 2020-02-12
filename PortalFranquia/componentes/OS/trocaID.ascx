<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="trocaID.ascx.cs" Inherits="PortalFranquia.componentes.OS.trocaID" %>
<br />
<asp:Label ID="lbTitulo" runat="server" Text="Troca de ID: " ForeColor="DarkBlue" Font-Bold="true" Font-Size="x-Large"></asp:Label>
<br />
<br />
ID Atual
<br />
<asp:TextBox ID="txtIDAtual" runat="server" ReadOnly="true" ClientIDMode="Static" CssClass="alteraIDAtual"></asp:TextBox>
&nbsp;
Trocar ID: 
<asp:DropDownList ID="ddlIDs" runat="server"></asp:DropDownList>
&nbsp;
Motivo da Troca
<asp:DropDownList ID="ddlMotivoTroca" runat="server"></asp:DropDownList>
&nbsp;
<asp:Button ID="btnTroca" runat="server" Text="Trocar Peça" OnClick="btnTroca_Click" />
<asp:Label ID="lbMens" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
