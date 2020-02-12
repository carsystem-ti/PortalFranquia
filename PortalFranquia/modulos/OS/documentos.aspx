<%@ Page Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="documentos.aspx.cs" Inherits="PortalFranquia.modulos.OS.documentos" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 1209px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <td colspan="6" style="font-size:larger"><center><b>Documentos</b></center></td>
            <tbody>
                <tr>
                    <td style="font-size: medium" Width="235px"><center><a href="../../Documentos/CARTA DE AUTORIZAÇÃO.pdf" target="_blank">Autorização</a></center></td>
                    <td style="font-size: medium" Width="235px"><center><a href="../../Documentos/AUTORIZAÇÃO DE TRANSFERÊNCIA DE TITULARIDADE.pdf"  target="_blank">Transferência de Titularidade</a></center></td>
                    <td style="font-size: medium" Width="235px"><center><a href="../../Documentos/AUTORIZAÇÃO DE TRANSFERÊNCIA DE TITULARIDADE POR BEM MAIOR.pdf"  target="_blank">TDP BEM MAIOR</a></center></td>
                    <td style="font-size: medium" Width="235px"><center><a href="../../Documentos/AUTORIZAÇÃO DE RETIRADA E TRANSFERÊNCIA.pdf"  target="_blank">TDV ou RETIRADA</a></center></td>
                    <td style="font-size: medium" Width="235px"><center><a href="../../Documentos/CREDENCIAMENTO DE TERCEIROS CENTRAL DE EMERGENCIA.pdf"  target="_blank">Credenciamento terceiros</a></center></td>
                    <td style="font-size: medium" Width="235px"><center><a href="../../Documentos/Check_list_devolução_de_peças.pdf"  target="_blank">Devolução ou consumo excessivo</a></center></td>
                </tr>
 
                <!--
                <tr>
                    <td style="font-size: medium"><a href="../../Documentos/checkListEmBrancoCarro.pdf">Checklist em branco para CARRO</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/checkListEmBrancoMotocicletas.pdf">Checklist em branco para MOTO</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/ContratoBloqPlus.pdf">Contrato Bloq. Plus</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/ContratoRastPlus.pdf">Contrato Rast. Plus</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/POLFR 004_Política Estoque_Versão 02.pdf">Política Estoque</a></td>
                </tr>
                <tr>
                    <td style="font-size: medium"><a href="../../Documentos/POLFR 005_Política Comercial Franquia Lojas_Versão 03.pdf">Política Comercial Franquia</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/POLFR 006_Política de Compra e Revenda_Versão 02.pdf">Política de Compra e Revenda</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/PROFR 001_Procedimento de Atendimento Franquia Lojas_Versão 04.pdf">Procedimento de Atendimento Franquia</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/PROFR 002_Procedimento de Atendimento Técnico_Versão 01.pdf">Procedimento de Atendimento Técnico</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/Rastreador_Plus_Promocao.pdf">Contrato Rastreador Plus Promocional</a></td>
                </tr>
                <tr>
                    <td style="font-size: medium"><a href="../../Documentos/Bloquador_Plus_Promocao.pdf">Contrato Bloqueador Plus Promocional</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/Planilha_Para_Controle_de_Peças.xls">Planilha para Controle de Peças</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/Planilha_Para_Controle_de_Vistorias.xls">Planilha para Controle de Vistorias</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/Relatório_de_Perícia.pdf">Relatório de Perícia</a></td>
                    <td style="font-size: medium"><a href="../../Documentos/Termo_de_Doação.pdf">Termo de Doação</a></td>
                </tr>
                <tr>
                    <td style="font-size: medium" colspan="2"><a href="../../Documentos/Termo_de_Responsabilidade_Xenon.pdf">Termo de Responsabilidade Xenon</a></td>
                    <td style="font-size: medium" colspan="3"><a href="../../Documentos/TermoparaDoação.pdf">Contrato Ativação - Termo Doação Condicionada</a></td>
                </tr>

                    <td><a href="https://portal.carsystem.com/webBoleto/listaDebitos.aspx?txtContrato=' + frmCAC.idContrato.value + '&codigoEmpresa=1';" target="_blank"</a>teste</td>
                    <td><a href="https://portal.carsystem.com/webBoleto/listaDebitos.aspx?txtContrato=133455&1" target="_blank"</a>teste</td>

                -->
            </tbody>
        </table>
        <table>
                <tr>
                    <td class="auto-style1">
                        Contrato: <asp:TextBox ID="txtContrato" runat="server" Width="78px" MaxLength="6" Height="27px"></asp:TextBox>

                        <asp:Button ID="btnCertificado" name="btnCertificado" runat="server" Text="Certificado" Width="200px" OnClick="btnCertificado_Click"/>
                        <asp:Button ID="btnCarne" name="btnCarne" runat="server" Text="Carnê" Width="200px" OnClick="btnCarne_Click" />
                        <asp:Button ID="btnCheckList" name="btnCheckList" runat="server" Text="CheckList" Width="200px" OnClick="btnCheckList_Click" />
                        <asp:Button ID="btnReciboEntrega" CommandName="btnReciboEntrega" runat="server" Text="Recibo de Entrega" Width="200px" OnClick="btnReciboEntrega_Click" />
                        <asp:Button ID="btnAutorizacao" CommandName="btnAutorizacao" runat="server" Text="Autorização" Width="200px" OnClick="btnAutorizacao_Click"/>
                    </td>
                </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNomeCliente" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
                </td>
            </tr>

        </table>
        <asp:HiddenField ID="hdfContrato" runat="server" />
    </div>
</asp:Content>
