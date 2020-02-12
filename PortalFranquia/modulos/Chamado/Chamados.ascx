<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Chamados.ascx.cs" Inherits="PortalFranquia.modulos.Chamados.Chamados1" %>
<html>
<head>
    <link href="css/mensagem.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/MaxLength.min.js"></script>
    <link href="../../css/mensagem.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/jquery-ui.js"></script>
    <script type="text/javascript">
        function Mensagem(message) {
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
        /*td {
            margin: 0;
            padding: 0;
            border: 0;
            outline: 0;
            font-weight: inherit;
            font-style: inherit;
            font-family: inherit;
            vertical-align: none;
            background-color: white;
        }*/
        .auto-style1 {
            width: 82%;
        }

        .auto-style2 {
            width: 23px;
        }

        TextBox {
            float: left;
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
                font-size: 16px;
                border-radius: 5px;
                box-shadow: 0 0 0 5px #59B0B9;
                margin-left: 20px;
            }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            width: 96px;
            height: 26px;
        }
        .auto-style5 {
            width: 7px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
    </style>

    <%--    <script type="text/javascript">
        $(function () {
            //Configuração Normal 
            $("[id*=lblmensagem]").MaxLength({ MaxLength: 1000 });

            //Especificando o controle de contagem de caráter explicitamente
            $("[id*=txtDescricao]").MaxLength(
            {
                MaxLength: 1000,
                CharacterCountControl: $('#counter')
            });

            //Desativar a Contagem de Caracteres
            $("[id*=txtDescricao]").MaxLength(
            {
                MaxLength: 1000,
                DisplayCharacterCount: false
            });
        });
    </script>--%>
</head>
    <body>
     <div id="dialog" style="display: none; height: 400px; width: 400px;">
    </div>
<fieldset style="width: 904px; height: 405px;margin-left:12%">
    <legend>Abertura de Ocorrências</legend>
    <div id="form1" runat="server">
        <table>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblArea" runat="server" Text="Área:" Font-Names="Verdana"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dropArea" runat="server" Height="24px" Width="283px" AutoPostBack="True" DataTextField="ds_Departamento" DataValueField="id_Departamento" OnSelectedIndexChanged="dropArea_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblAssunto" runat="server" Text="Assunto:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dropAsssunto" runat="server" Height="24px" Width="363px" AutoPostBack="True" DataTextField="ds_Assunto" DataValueField="id_Assunto" OnSelectedIndexChanged="dropAsssunto_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <br />
        <table class="auto-style3">
            <tr>
                <td class="auto-style5">
                </td>
                <td class="auto-style4">
                    <asp:Label ID="lblArea6" runat="server" Text="Contato/Ramal"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtNome0" runat="server" Width="145px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
<table">
            <tr>
                <td valign="top">
                </td>
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2">
                    <asp:Label ID="lblArea0" runat="server" Text="Descrição" Font-Names="Verdana"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="txtDescricao" runat="server" Height="162px" Width="95%" TextMode="MultiLine" ViewStateMode="Disabled" ClientIDMode="Static" MaxLength="1000"></asp:TextBox>
                            </td>
                        </tr>
        </table>
                </td>

            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblArea2" runat="server" Text="Departamento:" Font-Names="Verdana"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFranquia" runat="server" Width="307px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblArea3" runat="server" Text="Usuário:" Font-Names="Verdana"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNome" runat="server" Width="307px" Enabled="False"></asp:TextBox>
                </td>
                <td></td>
                <td>

                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>

                    &nbsp;</td>
            </tr>
            <tr>
                <td </td>
                <td>
                    &nbsp;</td>
                <td</td>
                <td>
                    &nbsp;</td>
                <td</td>
                <td</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblArea4" runat="server" Text="Status:" Font-Names="Verdana"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtStatus" runat="server" Width="307px" Enabled="False" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="lblArea5" runat="server" Text="Prazo:" Font-Names="Verdana"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSLA" runat="server" Width="307px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton ID="imgSalvar" runat="server" ImageUrl="~/imagens/Chamado/salvar.jpg" OnClick="imgSalvar_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="imgExcluir" runat="server" ImageUrl="~/imagens/Chamado/excluir.jpg" />
                </td>
            </tr>
            <td</td>
                </table>
    </div>
</fieldset>
        </body>
</html>