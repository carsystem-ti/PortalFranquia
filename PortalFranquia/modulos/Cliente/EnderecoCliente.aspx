<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnderecoCliente.aspx.cs" Inherits="PortalFranquia.modulos.OS.EnderecoCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Endereço Cliente</title>
        <style type="text/css" >
            table {
                border-collapse: separate;
                border-spacing: 1;
            } 
            table, td, th {  
                border: 1px solid #ddd;
                text-align: left;
                border-radius: 5px;
                -moz-border-radius: 5px;
                color: dimgray;
                background-color: #cdfe99;

            }
            .auto-style1 {
                width: 210px;
                margin-left: 23px;
                font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
                height: 18px;
                font-weight: bold;
            }

            .auto-style2 {
                background-color: white;
                font-family: Arial;
                font-size: 15px;
                color: dodgerblue;
                width: 210px;
                height: 18px;
                border-color: white;
            }

            .auto-style6 {
                width: 861px;
                background-color: white;
                border-color: white;
            }
            .auto-style7 {
                width: 866px;
            }

            .auto-style8 {
                width: 96px;
                margin-left: 23px;
                font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
                height: 18px;
                font-weight: bold;
                
            }
            .auto-style9 {
                background-color: white;
                font-family: Arial;
                font-size: 15px;
                color: dodgerblue;
                width: 96px;
                height: 18px;
                border-color: white;
            }
            .auto-style10 {
                width: 478px;
                margin-left: 23px;
                font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
                height: 18px;
                font-weight: bold;
            }
            .auto-style11 {
                background-color: white;
                font-family: Arial;
                font-size: 15px;
                color: dodgerblue;
                width: 478px;
                height: 18px;
                border-color: white;
            }
            .auto-style44 {
                width: 230px;
                font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
                color: dimgray;
                height: 18px;
                font-weight: bold;
            }

        </style>
</head>
<body style="width: 881px">
    <form id="form1" runat="server" class="auto-style7">
        <div class="auto-style6">
            <table class="auto-style6">
                <tr>
                    <td class="auto-style8"><b>Cep</b></td>
                    <td class="auto-style10">Endereço Residencial</td>
                    <td class="auto-style1">Número</td>
                </tr>

                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="lblCep" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <asp:Label ID="lblEndereco" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblNumero" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table class="auto-style6">
                <tr>
                    <td class="auto-style1">Complemento</td>
                    <td class="auto-style1">Bairro</td>
                    <td class="auto-style1">Cidade</td>
                    <td class="auto-style1">UF</td>

                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblComplemento" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblBairro" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblCidade" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblUf" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <table class="auto-style6">
                <tr>
                    <td class="auto-style44">Pontos de Referência</td>
                    <td class="auto-style44">Região</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblReferencia" runat="server" Text=""></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="lblRegiao" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
