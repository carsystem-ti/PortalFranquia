<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncluirObservacoesCadastro.aspx.cs" Inherits="PortalFranquia.modulos.Cliente.IncluirObservacoesCadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
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

        .auto-style2 {
            text-align: left;
            width: 382px;
            color:dodgerblue;
            
        }

        .auto-style4 {
            text-align: right;
            color:dodgerblue;
        }

        .auto-style5 {
            border-radius: 14px;
            font-size: 16px;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }

        .auto-style6 {
            width: 542px;
        }
        .auto-style7 {
            width: 460px;
            color: dodgerblue;
            text-align: center;
            font-weight: bold;
        }
        .auto-style8 {
            width: 541px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style6">
            <table class="auto-style8">
                <tr>
                    <td class="auto-style7">
                        <asp:Label ID="lblIncluirObservacoes" runat="server" Text="INCLUIR OBSERVAÇÕES" Font-Names="Arial"></asp:Label>
                        
                    </td>
                </tr>
            </table>
            <table class="auto-style8">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblContrato" runat="server" Text="" Font-Names="Arial"></asp:Label>
                    </td>
                    <td class="auto-style4">
                        <asp:Button ID="btnGravar" runat="server" Text="Gravar" CssClass="auto-style5" Height="35px" Width="149px" OnClick="btnGravar_Click"/>
                                        
                    </td>
                </tr>
            </table>
            <table class="auto-style8">
                <tr>
                    <td>
                        <asp:TextBox ID="txtObs" runat="server" CssClass="auto-style5" TextMode="MultiLine" Height="117px" Width="524px"></asp:TextBox>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
