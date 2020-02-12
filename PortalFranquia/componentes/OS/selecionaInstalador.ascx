<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="selecionaInstalador.ascx.cs" Inherits="PortalFranquia.componentes.OS.selecionaInstalador" %>
<br />
<asp:Label ID="lbTitulo" runat="server" Text="Selecione o instalador, adicione informações ou voucher: " ForeColor="DarkBlue" Font-Bold="true" Font-Size="x-Large"></asp:Label>
<br />
<br />
<div style="display:inline-block; width:100%">
    <div style="float: left; width: 20%">
        <asp:Label ID="Label1" runat="server" Text="Instalador"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlInstalador" runat="server" Width="100%"></asp:DropDownList>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 75%">
        <asp:Label ID="Label2" runat="server" Text="Informações Adicionais"></asp:Label>
        <br />
        <asp:TextBox ID="txtInformacoesAdicionais" runat="server" Width="100%" TextMode="MultiLine" Height="150px"></asp:TextBox>
    </div>
    <br />    
</div>
<div >
    <asp:Label ID="Label3" runat="server" Text="Voucher"></asp:Label>
    <br />
    <asp:TextBox ID="txtVoucher" runat="server" Width="230px"></asp:TextBox>
    &nbsp&nbsp&nbsp&nbsp
    <asp:Button ID="Button1" runat="server" Text="Verificar" OnClick="Button1_Click" />
    &nbsp&nbsp&nbsp&nbsp
    <asp:Label ID="lbMensErro" runat="server" Text="" Visible="false" CssClass="mensErro"></asp:Label>
</div>