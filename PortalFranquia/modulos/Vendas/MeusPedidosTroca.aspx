<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="MeusPedidosTroca.aspx.cs" Inherits="PortalFranquia.modulos.Vendas.MeusPedidosTroca" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/jquery-ui.js"></script>    
    <script src="../../js/mask.js"></script>
    <link href="css/produtos.css" rel="stylesheet" />
    <link href="css/mensagem.css" rel="stylesheet" />
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
            window.open('Recibo.aspx', '', 'top=0,left=0,menubar=no,toolbar=no,location=no,resizable=no,height=430,width=680,status=no,scrollbars=no,maximize=null,resizable=0,titlebar=no;');
        }
    </script>
    <style type="text/css">
        .Dlabel {
            width: 324px;
        }

        .divSomeSelect {
            display: none;
            width: 0%;
        }

        .selectRowTD td {
            background-color: yellow;
            border-color: orange;
            font-weight: bold;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
        &nbsp;<fieldset style="width: 362px; height: 83px">
            <legend>Selecione o Filtro
                </legend>
            <div class="Dlabel">
                <asp:Label ID="Label16" runat="server" Height="16px" Text="Data Inicial" Width="107px"></asp:Label>
                <asp:Label ID="Label17" runat="server" Height="17px" Text="Data Final" Width="148px"></asp:Label>

            </div>
            <div class="selecao">
                <asp:TextBox ID="txtInicial" runat="server" Height="19px" Width="95px" ClientIDMode="Static"></asp:TextBox>
                <asp:TextBox ID="TxtFinal" runat="server" Height="19px" Width="94px" ClientIDMode="Static"></asp:TextBox>
                <asp:Button ID="btnPesquisar" runat="server" Font-Bold="True" Height="31px" Text="Pesquisar" Width="125px" ClientIDMode="Static" OnClick="btnPesquisar_Click" />
            </div>
        </fieldset>
    </div>
      <br />
    <br />
    <div>
        <asp:GridView ID="gridContrato" runat="server" CellSpacing="-1" Height="20px" Width="900px" Font-Size="Small" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gridContrato_PageIndexChanging" DataKeyNames="id_troca" OnPreRender="gridContrato_PreRender">
            <Columns>
                <asp:BoundField DataField="id_troca" HeaderText="Pedido" />
                <asp:BoundField DataField="ds_franquia" HeaderText="Franquia" />
                <asp:BoundField DataField="Nome" HeaderText="Cliente" />
                <asp:BoundField DataField="ds_modelo" HeaderText="Modelo" />
                <asp:BoundField DataField="ds_produto" HeaderText="Produto" />
                <asp:BoundField DataField="ds_placa" HeaderText="Placa" />
                <asp:BoundField DataField="nr_contrato" HeaderText="Contrato" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
