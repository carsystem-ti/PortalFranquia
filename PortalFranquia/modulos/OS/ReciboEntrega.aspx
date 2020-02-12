<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReciboEntrega.aspx.cs" Inherits="PortalFranquia.modulos.OS.ReciboEntrega" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Recibo de Entrega</title>
</head>
<body style="font-family: Arial, sans-serif; vertical-align:center">
    <br />
    <form id="form1" runat="server">
        <table width="90%" style="text-align:center; margin:auto;">
			<tr>
				<td align="left">
					<asp:Image ID="imgLogo" runat="server" ImageUrl="~/imagens/logo300.png" />
				</td>
			</tr>
			<br />
			<tr>
				<td align="center"><h2><asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label></h2></td>
			</tr>				
			<tr>
				<td align="center"><h2>Recibo de Entrega N° <asp:Label ID="lblNroRecibo" runat="server" Text=""></asp:Label></h2></td>
			</tr>				
				<td align="left">
					<br />
					<br />
					Declaramos ter recebido de <asp:Label ID="lblDsNome" runat="server" Text=""></asp:Label> (CPF/CNPJ) <asp:Label ID="lblNrDocumento" runat="server" Text=""></asp:Label>,
				o equipamento <asp:Label ID="lblDsProduto" runat="server" Text=""></asp:Label>.
				</td>
			</tr>
				<td  align="left">Retirado do veiculo de placa <asp:Label ID="lblNrPlaca" runat="server" Text=""></asp:Label>, modelo <asp:Label ID="lblDsModelo" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td align="right"><br /><br /><asp:Label ID="lblDsCidade" runat="server" Text=""></asp:Label> , <asp:Label ID="lblNrDia" runat="server" Text=""></asp:Label> de <asp:Label ID="lblDsMes" runat="server" Text=""></asp:Label> de <asp:Label ID="lblDsAno" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td align="right"><br/><br/>_____________________________________________</td>
			</tr>
			<tr>
				<td align="right">
                    <asp:Label ID="lblDsNomeEmpresa" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td align="right"><br/><br/>_____________________________________________</td>
			</tr>
			<tr>
				<td align="right"><asp:Label ID="lblNomeAssinatura" runat="server" Text=""></asp:Label></td>
			</tr>
		</table>		
		<br />
		<br />
		<br />
		<br />
		<br />
		<br />
        <table width="90%" style="text-align:center; margin:auto;">
			<tr>
				<td align="left">
					<asp:Image ID="imgLogo2" runat="server" ImageUrl="~/imagens/logo300.png" />
				</td>
			</tr>
			<br />
			<br />
			<tr>
				<td align="center"><h2>Recibo de Entrega N° <asp:Label ID="lblNroRecibo2" runat="server" Text=""></asp:Label></h2></td>
			</tr>				
				<td align="left">
					<br />
					<br />
					Declaramos ter recebido de <asp:Label ID="lblDsNome2" runat="server" Text=""></asp:Label> (CPF/CNPJ) <asp:Label ID="lblNrDocumento2" runat="server" Text=""></asp:Label>, 
				o equipamento <asp:Label ID="lblDsProduto2" runat="server" Text=""></asp:Label>.
				</td>
			</tr>
				<td align="left">Retirado do veiculo de placa <asp:Label ID="lblNrPlaca2" runat="server" Text=""></asp:Label>, modelo <asp:Label ID="lblDsModelo2" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td align="right"><br /><br /><asp:Label ID="lblDsCidade2" runat="server" Text=""></asp:Label> , <asp:Label ID="lblNrDia2" runat="server" Text=""></asp:Label> de <asp:Label ID="lblDsMes2" runat="server" Text=""></asp:Label> de <asp:Label ID="lblDsAno2" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td align="right"><br/><br/>_____________________________________________</td>
			</tr>
			<tr>
				<td align="right">
                    <asp:Label ID="lblDsNomeEmpresa2" runat="server" Text=""></asp:Label></td>
			</tr>
			<tr>
				<td align="right"><br/><br/>_____________________________________________</td>
			</tr>
			<tr>
				<td align="right"><asp:Label ID="lblNomeAssinatura2" runat="server" Text=""></asp:Label></td>
			</tr>
		</table>		

    </form>
</body>
</html>
