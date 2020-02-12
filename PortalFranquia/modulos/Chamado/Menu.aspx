<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="PortalFranquia.modulos.Chamados.Chamados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register TagPrefix="My" TagName="ind" Src="~/modulos/Chamado/Chamados.ascx" %>
    <%@ Register TagPrefix="My" TagName="dist" Src="~/modulos/Chamado/Abertos.ascx" %>
    <%@ Register TagPrefix="My" TagName="atendimento" Src="~/modulos/Chamado/EmAtendimento.ascx" %>
    <%@ Register TagPrefix="My" TagName="encerradas" Src="~/modulos/Chamado/Encerradas.ascx" %>
    <%@ Register TagPrefix="My" TagName="canceladas" Src="~/modulos/Chamado/canceladas.ascx" %>
    <%@ Register TagPrefix="My" TagName="reabertos" Src="~/modulos/Chamado/Reabertos.ascx" %>
    <%@ Register TagPrefix="My" TagName="MeusChamados" Src="~/modulos/Chamado/MeusChamados.ascx" %>
    <script type="text/javascript" src="../../js/jquery-ui.js"></script>
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/jquery.centralize.js"></script>
    <script type="text/javascript" src="../../js/jquery.PrintArea.js"></script>
    <script type="text/javascript" src="../../js/kModal.js"></script>
    <script src="../../js/Jchamados.js"></script>
    <link href="../../css/kModal.css" rel="stylesheet" />
    <script type="text/javascript">
        function Imprimir() {
            $.ajax({
                type: "POST",
                url: 'DetalhesChamados.aspx',
                dataType: "html",
                data: {},
                success: function (result) {
                    $("#osPrint").html("<div style='height:1200px; width:900px;'>" + result + "</div>");
                    criaPopup("", true, false, "<div class='    '><div class='impressaoOS'>" + result + "</div></div>", true, false);
                    $(".modalPrintImg").click(function (event) {
                        event.stopPropagation();
                        $(".impressaoOS").printArea();
                    });
                },
                error: function (result, textStatus, errorThrown) {
                }
            }).done(function (dummy) {
                fechaLoading();
            });
        }
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
    <style type="text/css">
        td {
            margin: 0;
            padding: 0;
            border: 0;
            outline: 0;
            font-weight: inherit;
            font-style: inherit;
            font-family: inherit;
            vertical-align: none;
            background-color: white;
        }

        .Panel {
            margin-left: 20%;
            margin-top: -2%;
            position: fixed;
            left: 0pt;
        }

        .containerImpressaoOS {
            overflow-y: scroll;
            width: 950px;
            height: 500px;
        }

        fieldset {
            font-family: sans-serif;
            border: 5px solid #59B0B9;
            background: #FFFFFF;
        }

            fieldset legend {
                background: #1F497D;
                color: #fff;
                padding: 5px 10px;
                font-size: 19px;
                border-radius: 5px;
                box-shadow: 0 0 0 5px #59B0B9;
                margin-left: 20px;
            }

        #Menu {
            float: left;
        }

        th {
            border-width: 0px;
            border-color: white;
            border-style: none;
        }

        .containerImpressaoOS {
            overflow-y: scroll;
            width: 800px;
            height: 500px;
        }

        table {
            width: 149px;
        }

        .fonte {
            font-family: sans-serif;
            background: #FFFFFF;
        }
           .divSomeSelect
        {
            display: none;
            width: 0%;
        }
        .auto-style8 {
            height: 41px;
        }
    </style>
    <link href="../css/mensagem.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dialog" style="display: none; height: 200px; width: 400px;">
        <asp:Label ID="lblmensagem" runat="server" Font-Bold="True" Font-Names="Vrinda" Font-Size="Medium" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
    </div>
    <div style="width: 1191px">

        <table id="Menu">
            <tr>
                <td>
                    <asp:ImageButton ID="imgAbrir" runat="server" ImageUrl="~/imagens/chamado/Abrir.jpg" OnClick="imgAbrir_Click" Width="38px" PostBackUrl="~/imagens/chamado/Abrir.jpg" ClientIDMode="Static" />
                </td>
                <td class="fonte">
                    <asp:LinkButton ID="lblAbrir" runat="server" Font-Names="Verdana" Font-Size="X-Small" OnClick="lblAbrir_Click" ClientIDMode="Static">Abrir </asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="imgAbertas" runat="server" ImageUrl="~/imagens/chamado/Abertas.jpg" Width="40px" Height="39px" OnClick="imgAbertas_Click" ClientIDMode="Static" />
                </td>
                <td>
                    <asp:LinkButton ID="lblAbertas" runat="server" Font-Names="Verdana" Font-Size="X-Small" OnClick="lblAbertas_Click" ClientIDMode="Static">Abertas</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="imgEncerradas" runat="server" ImageUrl="~/imagens/chamado/Encerradas.jpg" Width="38px" Height="39px" OnClick="imgEncerradas_Click" ClientIDMode="Static" />
                </td>
                <td>
                    <asp:LinkButton ID="lblEncerradas" runat="server" Font-Names="Verdana" Font-Size="X-Small" OnClick="lblEncerradas_Click1" ClientIDMode="Static">Encerradas</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="imgCanceladas" runat="server" ImageUrl="~/imagens/chamado/canceladas.jpg" Width="38px" Height="39px" OnClick="imgCanceladas_Click" ClientIDMode="Static" />
                </td>
                <td>
                    <asp:LinkButton ID="lblCanceladas" runat="server" Font-Names="Verdana" Font-Size="X-Small" OnClick="lblCanceladas_Click" ClientIDMode="Static">Canceladas</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:ImageButton ID="imgEmAtendimento" runat="server" ClientIDMode="Static" ImageUrl="~/imagens/chamado/Encerradas.jpg" Width="38px" Height="39px" OnClick="imgEmAtendimento_Click" />
                </td>
                <td class="auto-style8">
                    <asp:LinkButton ID="lblEmatendimento" runat="server" Font-Names="Verdana" Font-Size="X-Small" OnClick="lblEmatendimento_Click" ClientIDMode="Static">Em Atendimento</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:ImageButton ID="imgReabertos" runat="server" ImageUrl="~/imagens/chamado/Encerradas.jpg" Width="38px" Height="39px" OnClick="imgReabertos_Click" ClientIDMode="Static" />
                </td>
                <td class="auto-style8">
                    <asp:LinkButton ID="lblReabertos" runat="server" Font-Names="Verdana" Font-Size="X-Small" OnClick="lblReabertos_Click" ClientIDMode="Static">Reabertos</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:ImageButton ID="imgMeusChamados" runat="server" ImageUrl="~/imagens/chamado/Encerradas.jpg" Width="38px" Height="39px" ClientIDMode="Static" OnClick="imgMeusChamados_Click" Visible="False" />
                </td>
                <td class="auto-style8">
                    <asp:LinkButton ID="lblMeuchamados" runat="server" Font-Names="Verdana" Font-Size="X-Small" ClientIDMode="Static" OnClick="lblMeuchamados_Click" Visible="False">Meus Chamados</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Panel CssClass="Panel" ID="PnlGeral" runat="server" Width="940px">
            <My:ind ID="ind" Visible="false" runat="server"></My:ind>
        </asp:Panel>
        <asp:Panel CssClass="Panel" ID="Panel1" runat="server" Width="940px">
            <My:dist ID="ChamadosAbertos" Visible="false" runat="server"></My:dist>
        </asp:Panel>
        <asp:Panel CssClass="Panel" ID="Panel2" runat="server" Width="940px">
            <My:atendimento ID="atendimento" Visible="false" runat="server"></My:atendimento>
        </asp:Panel>
        <asp:Panel CssClass="Panel" ID="Panel3" runat="server" Width="940px">
            <My:encerradas ID="encerradas" Visible="false" runat="server"></My:encerradas>
        </asp:Panel>
           <asp:Panel CssClass="Panel" ID="Panel4" runat="server" Width="940px">
            <My:canceladas ID="canceladas" Visible="false" runat="server"></My:canceladas>
        </asp:Panel>
             <asp:Panel CssClass="Panel" ID="Panel5" runat="server" Width="940px">
            <My:reabertos ID="reabertos" Visible="false" runat="server"></My:reabertos>
        </asp:Panel>
        <asp:Panel CssClass="Panel" ID="Panel6" runat="server" Width="940px">
            <My:MeusChamados ID="MeusChamados" Visible="false" runat="server"></My:MeusChamados>
        </asp:Panel>
    </div>
    <input id="sessionInput"  type="hidden" value='<%= Session["menu"] %>' />
</asp:Content>
