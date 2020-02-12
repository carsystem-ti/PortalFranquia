<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informacoes.aspx.cs" Inherits="PortalFranquia.modulos.BorderoCheques.Informacoes" %>

<!DOCTYPE html>
<link href="../../css/Bordero.css" rel="stylesheet" />
<link href="../../css/comum.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <div style="border-style: double; border-color: inherit; border-width: medium; height: 329px; font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #FF0000;">
        <p style="float:left;margin-left:50%; width: 267px;">FORMULÁRIO DE OBSERVACÕES</p>
        <br />
        <br />
        <div style="float:left;margin-top:-45px; height: 246px;">
            <table style="color:white;">
                <tr style="color:white;">
                    <td style="color:white;" class="auto-style2">
                        <asp:Label ID="lblUsuario" runat="server" Text="Pedido"></asp:Label>
                    </td>
                    <td style="color:white;" class="auto-style2">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr style="color:white;">
                    <td style="color:white;">
                        <asp:Label ID="lblUsuario0" runat="server" Text="Usuario"></asp:Label>
                    </td>
                    <td style="color:white;">
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <div style="float:left;margin-left:25%;margin-top:-40px; height: 33px;">
            
                    <asp:Button ID="btnGrava" runat="server" Text="Grava" Width="99px" />
            </div>
            <br />
            <div style="float:left;margin-left:10px;">
            <asp:TextBox ID="txtObs" runat="server" Width="711px" Height="82px" TextMode="MultiLine" ViewStateMode="Disabled" Wrap="False"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="TextBox2" runat="server" Width="706px" Height="82px" TextMode="MultiLine" ViewStateMode="Disabled" Wrap="False"></asp:TextBox>
                </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
    </form>
</body>
</html>
