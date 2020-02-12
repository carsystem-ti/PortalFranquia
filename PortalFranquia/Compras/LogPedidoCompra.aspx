<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="LogPedidoCompra.aspx.cs" Inherits="PortalFranquia.LogPedidoCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1
        {
            width: 138px;
        }
    p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
       

    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style2">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Font-Names="Verdana" Font-Size="Small" Text="Número do pedido"></asp:Label>
                    </td>
                    <td class="style3">
                        <asp:Label ID="Label3" runat="server" Font-Names="Verdana" Font-Size="Small" Text="Nome do Usúario"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtCT" runat="server" Enabled="False" Font-Names="Verdana"
                            Font-Size="Small" Height="23px"></asp:TextBox>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="txtnome" runat="server" Enabled="False" Font-Names="Verdana"
                            Font-Size="Small" Height="23px" Width="190px"></asp:TextBox>
                    </td>
                </tr>
            </table>
             <div style="margin-left:4%">
                <asp:Label ID="Label2" runat="server"
                    Text="Digite uma Observação (Somente Informações importantes)"
                    Font-Names="Verdana" ForeColor="Red" Font-Size="Medium"></asp:Label>
            </div>
     <table class="style1">
                <tr>
                    <td>
                        <asp:TextBox ID="txtNovaMensagem" runat="server" Font-Names="Verdana"
                            Height="112px" Width="750px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
    <div style="float:left;margin-left:4%">
                <asp:Button ID="btnMensagem" runat="server" Font-Bold="True"
                    Font-Names="Verdana" ForeColor="#FF3300" Height="35px" Text="Gravar" Font-Size="X-Small" OnClick="btnMensagem_Click" />
            </div>       
            <br />
            <br />
            <p class="MsoNormal">
                <span>Históricos de Informações<p></p>
                </span>
                <p>
                </p>
                <asp:Panel ID="Panel1" runat="server" Width="959px">
                    <asp:TextBox ID="txtRetornaMensagem" runat="server" Height="133px" ReadOnly="True" TextMode="MultiLine" Width="959px"></asp:TextBox>
                </asp:Panel>
                <p>
                </p>
                <p>
                </p>
                <p>
                       &nbsp;</p>
                <p>
                </p>
                <p>
                </p>
                <p>
                </p>
                <p>
                </p>
            </p>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
