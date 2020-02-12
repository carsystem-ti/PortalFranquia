<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="MeusPedidosVendas.aspx.cs" Inherits="PortalFranquia.MeusPedidosVendas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="js/MaskedEditFix.js"></script>--%>
    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/jquery-ui.js"></script>
    <script src="../../js/MaskedEditFix.js"></script>
    <script src="../../js/mask.js"></script>
    <script src="../../js/jquery.centralize.js"></script>
    <script src="../../js/jquery.PrintArea.js"></script>
    <script src="../../js/kModal.js"></script>
    <link href="css/mensagem.css" rel="stylesheet" />
    <link href="../../css/kModal.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {

            jQuery(function ($) {

                $("#txtInicial").setMask('date');
                $("#TxtFinal").setMask('date');

            });
        });
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
        function Imprimir() {
            Loading();
            $.ajax({
                type: "POST",
                url: 'Recibo.aspx',
                dataType: "html",
                data: {},
                success: function (result) {
                    //$("#osPrint").html("<div style='height:1200px; width:900px;'>" + result + "</div>");
                    criaPopup("", true, false, "<div class='containerImpressaoOS'><div class='impressaoOS'>" + result + "</div></div>", true, false);
                    $(".modalPrintImg").click(function (event) {
                        event.stopPropagation();
                        $(".impressaoOS").printArea();
                    });
                },
                error: function (result, textStatus, errorThrown) {
                }
            }).done(function (dummy) { fechaLoading(); });




            //  window.open('Recibo.aspx', '', 'top=0,left=0,menubar=no,toolbar=no,location=no,resizable=no,height=430,width=680,status=no,scrollbars=no,maximize=null,resizable=0,titlebar=no;');
        }
    </script>
    <style type="text/css">
        .Dlabel {
            width: 411px;
        }

        .divSomeSelect {
            display: none;
            width: 0%;
        }

        .containerImpressaoOS {
            overflow-y: scroll;
            width: 800px;
            height: 500px;
        }

        .selectRowTD td {
            background-color: yellow;
            border-color: orange;
            font-weight: bold;
        }
        .teste {
            float:left;
        }
        .selecao {
            width: 587px;
            float: left;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dialog" style="display: none; height: 900px; width: 900px;">
    </div>
    <div class="Dlabel">
        <asp:Label ID="Label16" runat="server" Height="16px" Text="Data Inicial" Width="103px"></asp:Label>
        <asp:Label ID="Label17" runat="server" Height="17px" Text="Data Final" Width="117px"></asp:Label>
        <asp:Label ID="lblSelecione" runat="server" Height="17px" Text="Selecione" Width="72px" Visible="False"></asp:Label>
    </div>
    <br />
    <div>
        <asp:TextBox ID="txtInicial" runat="server" CssClass="teste" Height="16px" Width="94px" ClientIDMode="Static"></asp:TextBox>
        <asp:TextBox ID="TxtFinal" CssClass="teste" runat="server" Height="16px" Width="95px" ClientIDMode="Static"></asp:TextBox>
        <div style="margin-top:-12px;">
        <asp:DropDownList ID="dropfranquias" runat="server" DataTextField="ds_franquia" DataValueField="id_franquia" Height="20px" Visible="False" Width="175px" Font-Names="Courier New"></asp:DropDownList>
            </div>
        <div style="margin-left:390px;margin-top:-22px">
        <asp:Button ID="btnPesquisar" runat="server" Font-Bold="True" Height="31px" Text="Pesquisar" Width="181px" ClientIDMode="Static" OnClick="btnPesquisar_Click" />
            </div>
    </div>
    <br />
    <br />
    <div style="width: 570px" class="teste">
    </div>
    <br />
    <br />
    <div style="float: left; margin-left: 10px; width: 1184px;">
        <asp:GridView ID="gridContrato" runat="server" CellSpacing="-1" Height="20px" Width="1169px" Font-Size="Small" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gridContrato_PageIndexChanging" DataKeyNames="id_pedido" OnRowDataBound="gridContrato_RowDataBound" OnPreRender="gridContrato_PreRender" OnSelectedIndexChanged="gridContrato_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id_pedido" HeaderText="Pedido" />
                <asp:BoundField DataField="ds_franquia" HeaderText="Franquia" />
                <asp:BoundField DataField="ds_cliente" HeaderText="Cliente" />
                <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                <asp:BoundField DataField="ds_produto" HeaderText="Produto" />
                <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                <asp:BoundField DataField="nr_contrato" HeaderText="Contrato" />
                <asp:CommandField ButtonType="Image" HeaderText="Recibo" SelectImageUrl="~/imagens/print.png" SelectText="Recibo" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
