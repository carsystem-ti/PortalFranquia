<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="tipoOS.aspx.cs" Inherits="PortalFranquia.modulos.OS.tipoOS" EnableEventValidation="false"%>

<%@ Register Src="~/componentes/OS/trocaID.ascx" TagPrefix="uc1" TagName="selecionaID" %>
<%@ Register Src="~/componentes/OS/OSInternaExterna.ascx" TagPrefix="uc1" TagName="selecionaInternaExterna" %>
<%@ Register Src="~/componentes/OS/dadosClienteComplementares.ascx" TagPrefix="uc1" TagName="dadosClienteComplementares" %>
<%@ Register Src="~/componentes/OS/selecionaInstalador.ascx" TagPrefix="uc1" TagName="selecionaInstalador" %>
<%@ Register Src="~/componentes/OS/retornoCPFCNPJ.ascx" TagPrefix="uc1" TagName="retornoCPFCNPJ" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/Home.css" rel="stylesheet" />
    <link href="../../css/OS.css" rel="stylesheet" />
    <script type="text/javascript" src  ="../../js/util.js"></script>
    <script type="text/javascript" src  ="../../js/jquery.js"></script>
    <script type="text/javascript" src  ="../../js/jquery.numeric.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;         
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="corpo">
                <asp:Label ID="lbMensErro" runat="server" Text="" Visible="false" CssClass="mensErro"></asp:Label>
                <asp:Panel ID="pnTipoOS" runat="server" Visible="true">
                    <asp:Label ID="lbTitulo" runat="server" Text="Selecione o tipo de OS: " ForeColor="Gray" Font-Bold="true" Font-Size="x-Large"></asp:Label>
                    
                    <div class="linhaMenu">
                        <asp:LinkButton ID="LinkInstalacao" runat="server" CssClass="linkMenu desabilitaLink" OnClick="Link_Click" Enabled="false">
                            <div id="divInstalacao" runat="server">
                                Instalação
                        <br />
                                <img src="../../imagens/OS/instalacaoPB.jpg" id="imgInstalacao" runat="server" />
                            </div>
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkSuporte" runat="server" CssClass="linkMenu desabilitaLink" OnClick="Link_Click" Enabled="false">
                            <div id="divSuporte" runat="server">
                                Suporte
                        <br />
                                <img src="../../imagens/OS/suportePB.jpg" id="imgSuporte" runat="server" />
                            </div>
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkRetirada" runat="server" CssClass="linkMenu desabilitaLink" OnClick="Link_Click" Enabled="false">
                            <div id="divRetirada" runat="server">
                                Retirada
                        <br />
                                <img src="../../imagens/OS/retiradaPB.jpg" id="imgRetirada" runat="server" />
                            </div>
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkReinstalacao" runat="server" CssClass="linkMenu desabilitaLink" OnClick="Link_Click" Enabled="false">
                            <div id="divReinstalacao" runat="server">
                                Reinstalação            
                        <br />
                                <img src="../../imagens/OS/reinstalacaoPB.jpg" id="imgReinstalacao" runat="server" />
                            </div>
                        </asp:LinkButton>
                    </div>
                    <br />
                    <br />
                    <div class="linhaMenu">
                        <asp:LinkButton ID="LinkTroca" runat="server" CssClass="linkMenu desabilitaLink" OnClick="Link_Click" Enabled="false">
                            <div id="divTroca" runat="server">
                                Troca
                        <br />
                                <img src="../../imagens/OS/trocaPB.jpg" id="imgTroca" runat="server" />
                            </div>
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkRecall" runat="server" CssClass="linkMenu desabilitaLink" OnClick="Link_Click" Enabled="false">
                            <div id="divRecall" runat="server">
                                Recall
                        <br />
                                <img src="../../imagens/OS/recallPB.jpg" id="imgRecall" runat="server" />
                            </div>
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkRevisaoPlus" runat="server" CssClass="linkMenu desabilitaLink" OnClick="Link_Click" Enabled="false">
                            <div id="divRevisaoPlus" runat="server">
                                Revisão Plus
                        <br />
                                <img src="../../imagens/OS/revisaoPlusPB.jpg" id="imgRevisaoPlus" runat="server" />
                            </div>
                        </asp:LinkButton>
                        <asp:LinkButton ID="LinkConstatacao" runat="server" CssClass="linkMenu desabilitaLink" OnClick="Link_Click" Enabled="false">
                            <div id="divConstatacao" runat="server">
                                Constatação            
                        <br />
                                <img src="../../imagens/OS/constatacaoPB.jpg" id="imgConstatacao" runat="server" />
                            </div>
                        </asp:LinkButton>
                    </div>
                </asp:Panel>
                <uc1:selecionaID runat="server" ID="selecionaID" Visible="false" />
                <uc1:selecionaInternaExterna runat="server" ID="selecionaInternaExterna" Visible="false" />
                <uc1:dadosClienteComplementares runat="server" ID="dadosClienteComplementares" Visible="false" />
                <uc1:selecionaInstalador runat="server" ID="selecionaInstalador" Visible="false" />
                <uc1:retornoCPFCNPJ runat="server" ID="retornoCPFCNPJ" Visible="false" />
            </div>
            <asp:Panel ID="rodape" CssClass="rodape" runat="server" Visible="false">
                <div style="float: right">
                    <asp:Button ID="btnAvancar" runat="server" Text="Avançar >>" OnClick="btnAvancar_Click" />
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
