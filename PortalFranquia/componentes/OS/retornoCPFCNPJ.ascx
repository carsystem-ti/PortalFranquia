<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="retornoCPFCNPJ.ascx.cs" Inherits="PortalFranquia.componentes.OS.retornoCPFCNPJ" %>
<asp:Label ID="lbTitulo" runat="server" Text="Retorno da pesquisa por CPF/CNPJ: " ForeColor="DarkBlue" Font-Bold="true" Font-Size="x-Large"></asp:Label>
<br />
<br />
<asp:GridView ID="grdCPF" runat="server" Width="100%"  CellSpacing="-1" AllowPaging="True" PageSize="15" OnPageIndexChanging="grdCPF_PageIndexChanging"  OnRowDataBound="grdCPF_RowDataBound" OnSelectedIndexChanging="grdCPF_SelectedIndexChanging"></asp:GridView>
