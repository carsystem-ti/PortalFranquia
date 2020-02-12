<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dadosCliente.ascx.cs" Inherits="PortalFranquia.componentes.OS.dadosCliente" %>
<br />
<div>
    <div style="float:left; width: 70%; text-align: center">                
        <asp:Label ID="txtTipoOS" runat="server" Text="" ForeColor="White" Font-Bold="true"></asp:Label>
    </div>
    <div style="float: right">
        ID Atual:    
        <asp:TextBox ID="txtIDAtual" runat="server" Width="70px" ReadOnly="true" Font-Bold="true"></asp:TextBox>        
    </div>
</div>
<br />

<div>
    <div style="float: left">
        Placa:
    <br />
        <asp:TextBox ID="txtPlaca" runat="server" Width="65px" ReadOnly="true" Font-Bold="true"></asp:TextBox>
    </div>
    <div style="float: left; margin-left: 3px">
        Contrato:
    <br />
        <asp:TextBox ID="txtContrato" runat="server" Width="60px" ReadOnly="true" Font-Bold="true"></asp:TextBox>
    </div>
    <div style="float: left; margin-left: 3px">
        Cliente:
    <br />
        <asp:TextBox ID="txtCliente" runat="server" Width="265px" ReadOnly="true" Font-Bold="true"></asp:TextBox>
    </div>
    <div style="float: right; margin-left: 3px; margin-top: -2px">
        Veículo:
    <br />
        <asp:TextBox ID="txtVeiculo" runat="server" Width="210px" ReadOnly="true" Font-Bold="true"></asp:TextBox>
    </div>
</div>
