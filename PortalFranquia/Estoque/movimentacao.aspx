<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="movimentacao.aspx.cs" Inherits="PortalFranquia.Estoque.movimentacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery.js"></script>
    <script src="../js/jquery.maskedinput.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {            
            $("#txtNotaFiscal").mask("999999999999999");

            configuraClickGrid();
        });

        function configuraClickGrid() {
            $("#grdListaEquipamentos tr").click(function () {
                $("#txtID").val($(this).find('td:first').text());
                if ($("#txtNotaFiscal").length)
                    $("#txtNotaFiscal").focus();
                else
                    $("#ddlListaLocalizacao").focus();
            });
        }
    </script>
    <asp:Timer ID="TimerTabela" runat="server" OnTick="TimerTabela_Tick" Interval="30000"></asp:Timer>
    <asp:Timer ID="TimerLimpaMens" runat="server" OnTick="TimerLimpaMens_Tick" Interval="8000" Enabled="false"></asp:Timer>
    <br />
    <asp:UpdatePanel ID="updPanError" runat="server">
        <ContentTemplate>
            <asp:Label ID="lbError" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAlterar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="TimerLimpaMens" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
    <div>
        <div style="float: left; width: 30%">
            <asp:Label ID="Label3" runat="server" Text="Resumo" ForeColor="Gray" Font-Bold="true" Font-Size="x-Large"></asp:Label>
            <asp:UpdatePanel ID="updPanTab" runat="server">
                <ContentTemplate>
                    <asp:Table ID="tblPosicao" runat="server" Width="100%">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell Width="75%">Status</asp:TableHeaderCell>
                            <asp:TableHeaderCell Width="25%">Quantidade</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="Alertas" ForeColor="Gray" Font-Bold="true" Font-Size="x-Large"></asp:Label>
                    <asp:Table ID="tblAlertas" runat="server" Width="100%">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell Width="75%">Tipo</asp:TableHeaderCell>
                            <asp:TableHeaderCell Width="25%">Quantidade</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TimerTabela" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div style="float: left; width: 4%">&nbsp;</div>
        <div style="float: left; width: 66%">
            <div style="width: 100%">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="width: 100%">
                            <asp:Label ID="Label4" runat="server" Text="Alteração" ForeColor="Gray" Font-Bold="true" Font-Size="x-Large"></asp:Label>
                        </div>
                        <div style="float: left; width: 10%">
                            <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtID" runat="server" Width="100%" MaxLength="6" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div style="float: left; width: 2%">&nbsp;</div>
                        <asp:Panel ID="panTipoLocalizacao" runat="server" Style="float: left; width: 30%">
                            <asp:Label ID="Label2" runat="server" Text="Localização"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ddlListaLocalizacao" runat="server" Width="100%" ClientIDMode="Static"></asp:DropDownList>
                        </asp:Panel>
                        <div style="float: left; width: 2%">&nbsp;</div>
                        <asp:Panel ID="panNumeroNota" runat="server" Style="float: left; width: 12%">
                            <asp:Label ID="Label5" runat="server" Text="Nota Fiscal"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtNotaFiscal" runat="server" Width="100%" MaxLength="15" ClientIDMode="Static"></asp:TextBox>
                        </asp:Panel>
                        <div style="float: left; width: 2%">&nbsp;</div>
                        <div style="float: left">
                            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" Style="margin-top: 13px" OnClick="Button1_Click" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAlterar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <br />
            <br />
            <br />
            <br />
            <div style="width: 100%">
                <asp:UpdatePanel ID="updPanGrid" runat="server">
                    <ContentTemplate>
                        <div style="width: 100%; float: right">
                            <asp:Label ID="lblTitLista" runat="server" Text="Lista de Equipamentos" ForeColor="Gray" Font-Bold="true" Font-Size="x-Large"></asp:Label>
                        </div>
                        <asp:GridView ID="grdListaEquipamentos" runat="server" Width="98%" ClientIDMode="Static"></asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>

