<%@ Page Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="OrdemServico.aspx.cs" Inherits="PortalFranquia.modulos.OS.OrdemServico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.7.429, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script src="../../js/OrdemServico.js"></script>
    <script src="../../js/jquery.maskedinput.js"></script>
    <div class="LinhaBusca">

        <div class="left">
            <label class="label-default" for="idContrato">Contrato</label>
            <%--    <input type="text" id="idEquipamento"/>  --%>
            <asp:TextBox ID="txtContrato" MaxLength="10" Enabled="True" runat="server"></asp:TextBox>
            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtContrato" />
            
            <label class="label-default" for="placaVeiculo">Placa do Veículo</label>
            <%--<input type="text" id="codigoFranquia"/>--%>
            <asp:TextBox ID="placa" MaxLength="7" runat="server"></asp:TextBox>


            <label class="label-default" for="cpfcnpj">CPF/CNPJ</label>
            <%--<input type="text" id="codigoFranquia"/>--%>
            <input type='text' id='cpfcnpj' name='cpfcnpj' onkeypress=' mascaraMutuario(this, cpfCnpj) ' onblur=' clearTimeout() '/>
    

            <%--<input type="text" style="width: 150px" id="input-box"/>--%>
            <input type="button" name="Pesquisar" value="Pesquisar" id="Pesquisar" class="btn-primary" style="margin-top: 4px;" />

            <div id="result"></div>
        </div>
    </div>
    <div id="avisos"></div>
    <div id="contrato"></div>
    <div id="tabela"></div>
    <div id="ordemServico"></div>
    <div id="abrirOs"></div>
    <div>
    </div>
    
</asp:Content>

