<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OSInternaExterna.ascx.cs" Inherits="PortalFranquia.componentes.OS.OSInternaExterna" %>
<br />
<asp:Label ID="lbTitulo" runat="server" Text="Local da realização do serviço: " ForeColor="DarkBlue" Font-Bold="true" Font-Size="x-Large"></asp:Label>
<br />
<br />
<div style="text-align:center">
    <asp:RadioButton ID="rbOSInterna" runat="server" Checked="true" Text="Interno" GroupName="rbOSInternaExterna" Font-Size="xx-Large" />
    <!-- &nbsp;&nbsp;&nbsp; -->
    <br />
    <br />
    <asp:RadioButton ID="rbOSExterna" runat="server" Text="Externo" GroupName="rbOSInternaExterna" Font-Size="xx-Large" />
</div>
