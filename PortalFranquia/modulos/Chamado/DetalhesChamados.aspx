<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalhesChamados.aspx.cs" Inherits="PortalFranquia.modulos.Chamados.PegarChamado" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../css/chamados.css" rel="stylesheet" />
    <link href="../../css/mensagem.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/Jchamados.js"></script>
    
    <title></title>
    <style type="text/css">
        .auto-style8 {
            width: 50px;
        }

        .auto-style9 {
            width: 68px;
        }

        .auto-style10 {
            width: 44px;
        }

        .auto-style11 {
            width: 18px;
        }

        .auto-style12 {
            width: 100%;
        }

        .auto-style13 {
            width: 393px;
        }

        .auto-style14 {
            width: 161px;
        }

        .auto-style15 {
            width: 194px;
        }
    </style>
    <script type="text/javascript">
        function ShowPopup(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Mensagem importante",
                    buttons: {
                        OK: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
            });
        };
         </script>
</head>
<body style="width: 881px">
    <form id="dados" runat="server">
        <div id="dialog" style="display: none; height: 200px; width: 400px;">
            <asp:Label ID="lblmensagem" runat="server" Visible="False" ForeColor="Red"></asp:Label>
        </div>
        <fieldset>
            <table style="width: 679px">
                <tr>
                    <td class="auto-style9">
                        <asp:Label ID="lblChamado" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="Medium" Text="CHAMADO:"></asp:Label>
                    </td>
                    <td class="auto-style11">
                        <input id="numero" name="numero" runat="server" type="hidden" />
                        <asp:Label ID="lblNrChamado" name="lblNrChamado" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium" ClientIDMode="Static" ForeColor="Red"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:Label ID="lblstatus" name="lblstatus" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="Medium" ClientIDMode="Static" ForeColor="Red"></asp:Label>
                    </td>
                    <td class="auto-style10">
                        <input type="button" name="btnAceite" runat="server" class="btnAceite"  id="btnAceite" onclick="teste()" value="ATENDER" /></td>
                    <td class="auto-style7">&nbsp;</td>
                </tr>
            </table>
        </fieldset>
        <br />
        <br />
        <fieldset style="width: 882px">
            <legend>DESCRIÇÃO DO CHAMADO</legend>
            <br />
            <table style="float:left">
                <tr style="float: left">
                    <td>
                        <asp:TextBox ID="TxtDescricao" runat="server" Height="86px" TextMode="MultiLine" Width="744px" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <fieldset style="width: 882px">
            <legend>OBSERVAÇÕES DO CHAMADO</legend>
            <br />
            <table class="auto-style3">
                <tr>
                    <td>
                        <asp:TextBox ID="txtComentarios" runat="server" Height="64px" TextMode="MultiLine" Width="744px" ClientIDMode="Static" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNovo" runat="server" Height="52px" TextMode="MultiLine" Width="744px" ClientIDMode="Static"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table class="auto-style12">
                <tr>
                    <td class="auto-style13">
                        <input type="button" name="btn" id="btn" value="Inserir comentário" class="botaoAzul" /></td>
                    <td class="auto-style14">
                        <input type="button" runat="server" name="btnEncerrar" id="btnEncerrar" value="Encerrar" class="botaoAzul" /></td>
                    <td class="auto-style15">
                        <input type="button" runat="server" name="btnReabrir" id="btnReabrir" value="Reabrir Chamado" class="botaoAzul" /></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <div style="float: left; margin-left: 14%">
                &nbsp;
            </div>
            <br />
        </fieldset>
    </form>
</body>
</html>
