<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Informacao.aspx.cs" Inherits="PortalFranquia.modulos.BorderoCheques.Informacao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 30px;
        }
    </style>
    <link href="../../css/Bordero.css" rel="stylesheet" />
    <link href="../../css/comum.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div style="border-style: double; border-color: inherit; border-width: medium; ; height: 329px; font-family: Verdana, Geneva, Tahoma, sans-serif; font-size: medium; color: #FF0000; width: 697px;">
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
            <div style="float:left;margin-left:30%;margin-top:-40px; height: 33px;">
            
                    <asp:Button ID="btnGrava" runat="server" Text="Grava" Width="99px" />
            </div>
            <br />
            <div style="float:left;margin-left:10px;">
            <asp:TextBox ID="txtObs" runat="server" Width="673px" Height="82px" TextMode="MultiLine" ViewStateMode="Disabled" Wrap="False" style="margin-right: 0px"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="TextBox2" runat="server" Width="670px" Height="82px" TextMode="MultiLine" ViewStateMode="Disabled" Wrap="False"></asp:TextBox>
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
    
</asp:Content>
