<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="FranquiaPedido.aspx.cs" Inherits="PortalFranquia.FranquiaPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <link href="../css/kModal.css" rel="stylesheet" />

    <script type="text/javascript" src="../js/jquery.js"></script>
    
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <link href="../css/mensagem.css" rel="stylesheet" />    

    <script type="text/javascript" src="../js/jquery.centralize.js"></script>
    <script type="text/javascript" src="../js/kModal.js"></script>
    <script type="text/javascript" src="../js/jquery.PrintArea.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            if ($(".telaBoleto").html() != null && $(".telaBoleto").html().trim() != '')
                imprimirBoleto();
        });

        function Imprimir() {
            Loading();
            $.ajax({
                type: "POST",
                url: 'LogPedidoCompras.aspx',
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


        $("#divLoading").ajaxStart(function () {
            $(this).show();
        });

        $("#divLoading").ajaxStop(function () {
            $(this).hide();
        });

    </script>
    <style>
        .divSomeSelect
        {
            display: none;
            width: 0%;
        }
          .containerImpressaoOS {
            overflow-y: scroll;
            width: 800px;
            height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dialog" style="display: none; height: 400px; width: 400px;">
        <asp:Label ID="lblmensagem" runat="server" Visible="False" ForeColor="Red"></asp:Label>
    </div>    
            <div class="Dlabel">
                <asp:RadioButtonList ID="rdbFiltro" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rdbFiltro_SelectedIndexChanged" Font-Names="Vrinda" Font-Size="Small" ClientIDMode="Static" Width="937px">
                    <asp:ListItem Value="1">PEDIDOS ABERTOS</asp:ListItem>
                    <asp:ListItem Value="2">ENVIADO CADASTRO</asp:ListItem>
                    <asp:ListItem Value="3">APROVADO CADASTRO</asp:ListItem>
                    <asp:ListItem Value="4">RECUSADO CADASTRO</asp:ListItem>
                    <asp:ListItem Value="5">EXPEDIÇÃO</asp:ListItem>
                    <asp:ListItem Value="6">EM ENTREGA</asp:ListItem>
                    <asp:ListItem Value="7">CONFIRMADO</asp:ListItem>
                    <asp:ListItem Value="8">CANCELADO</asp:ListItem>
                </asp:RadioButtonList>
            </div>
    <br />
  <div id="grid" runat="server" visible="false" style="float: left;">
                <asp:GridView ID="GridPedidosAbertos" runat="server" CellSpacing="-1"
                    ClientIDMode="Static" AutoGenerateColumns="False" EmptyDataText="&nbsp;" Font-Size="Medium" OnRowDataBound="GridPedidosAbertos_RowDataBound" 
                    Height="40px" BorderColor="DarkCyan" Font-Names="Verdana" DataKeyNames="id_pedido" AllowPaging="True" OnSelectedIndexChanged="GridPedidosAbertos_SelectedIndexChanged" 
                    OnPreRender="GridPedidosAbertos_PreRender" Width="1172px" OnPageIndexChanging="GridPedidosAbertos_PageIndexChanging" 
                    OnRowCommand="GridPedidosAbertos_RowCommand" >
                    <Columns>
                        <asp:BoundField DataField="id_pedido" HeaderText="Pedido" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="id_item" HeaderText="Item" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dt_pedido" HeaderText="Data" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="produto" HeaderText="Produto" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="qt_compra" HeaderText="Qtde." ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                           <asp:BoundField DataField="Valortotal" HeaderText="Total" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right" DataFormatString="{0:c}">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ds_franquia" HeaderText="Franquia" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ds_status" HeaderText="Status Pedido" />
                        <asp:BoundField DataField="ds_usuarioPedido" HeaderText="Usúario" ItemStyle-CssClass="colCodGr">
                            <ItemStyle CssClass="colCodGr" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Acessos">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgLog" runat="server" ImageUrl="~/imagens/email1.png" OnClick="imgLog_Click" Width="28px" />                                
                                <asp:ImageButton ID="imgTaxa" runat="server" ImageUrl="~/imagens/icone_boleto.gif" Width="28px" style="z-index:0;"/>
                                <asp:ImageButton ID="imgBoleto" runat="server" ImageUrl="~/imagens/icone_boleto.gif" Width="28px" style="z-index:0;"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect">
                            <ItemStyle CssClass="divSomeSelect" />
                        </asp:CommandField>
                    </Columns>
                    <SelectedRowStyle CssClass="selectRowTD" />
                </asp:GridView>
                <div id="divItem" style="float: left; margin-left: 40%; width: 356px;" runat="server" visible="false">
                    <asp:GridView ID="GridItem" runat="server" CellSpacing="-1"
                        ClientIDMode="Static" AutoGenerateColumns="False"
                        Width="98%" EmptyDataText="&nbsp;" Font-Size="Small" Height="16px" BorderColor="DarkCyan" Font-Names="Vrinda" DataKeyNames="id_Sbc" AllowPaging="True" OnRowDataBound="GridItem_RowDataBound" OnSelectedIndexChanged="GridItem_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="id_item" HeaderText="Item" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                                <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" Font-Size="Small" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id_Sbc" HeaderText="Peça" ItemStyle-CssClass="colCodigo" ItemStyle-HorizontalAlign="right">
                                <ItemStyle CssClass="colCodigo" HorizontalAlign="Right" Font-Size="Small" />
                            </asp:BoundField>
                            <asp:CommandField ShowSelectButton="True" ItemStyle-CssClass="divSomeSelect">
                                <ItemStyle CssClass="divSomeSelect" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Aceite">
                                <ItemTemplate>
                                    <div class="divGridIndicacao">
                                        <asp:LinkButton ID="lnkAceite" runat="server" CommandName="Aceite" CommandArgument="1">Aceite</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle Font-Size="Small" />
                        <HeaderStyle Font-Size="Small" />
                        <PagerStyle Font-Size="Small" />
                        <RowStyle Font-Size="Small" />
                        <SelectedRowStyle CssClass="selectRowTD" Font-Size="Small" />
                    </asp:GridView>
                </div>
                <br />
                <br />
                <div id="cancelarPedido" runat="server" visible="false" style="float: left">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar Pedido" OnClick="btnCancelar_Click" />
                </div>
                <div id="enviarCadastro" runat="server" style="margin-left: 4%" visible="false">
                    <asp:Button ID="btnEnviarCadastro" runat="server" Text="Enviar cadastro" Width="156px" OnClick="btnEnviarCadastro_Click" />
                </div>
                <div id="cancela" runat="server" visible="false">
                    <asp:Button ID="btncancelarPedido" runat="server" Text="Cancelar Pedido" Width="156px" />
                </div>
            </div>

            <div style="display:none;">

                <div id="divBoleto" class="telaBoleto" runat="server">

                </div>

            </div>

        <script type="text/javascript">

            function imprimirBoleto() {

                $('.Cabecalho').remove();
                $('body').css('background-color', 'white');
                $('#divBoletos td').css('background-color', 'white');

                $.each($('#divBoletos td'), function (index, value) {
                    $(this).addClass('naoComum');
                });

                var iHtmlBoleto = "<div id ='printArea' style='width:921.6px; height:450px;'><div class='impressaoBoleto'>" + $(".Pagina").html() + "</div></div>";

                criaPopup("", true, false, iHtmlBoleto, true, false,
                    function () {
                        $(".telaBoleto").html('');
                    });

                $(".telaBoleto").html('');

                $(".modalPrintImg").click(function (event) {
                    event.stopPropagation();
                    $("#printArea").printArea();
                });
            }
        </script>
</asp:Content>
