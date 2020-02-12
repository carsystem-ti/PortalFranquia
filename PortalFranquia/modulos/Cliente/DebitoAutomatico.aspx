<%@ Page Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="DebitoAutomatico.aspx.cs" Inherits="PortalFranquia.modulos.Cliente.DebitoAutomatico" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.7.429, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script src="../../js/debitoAutomatico.js"></script>
    <script src="../../js/jquery.maskedinput.js"></script>
    <div class="LinhaBusca">

        <div class="left">
            <label class="label-default" for="idContrato">Contrato</label>
            <%--    <input type="text" id="idEquipamento"/>  --%>
            <asp:TextBox ID="contrato" MaxLength="10" Enabled="True" runat="server"></asp:TextBox>
            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="contrato" />

            <%--<input type="text" style="width: 150px" id="input-box"/>--%>
            <input type="button" name="Pesquisar" value="Pesquisar" id="Pesquisar" class="btn-primary" style="margin-top: 4px;" />

            <div id="dadosCliente"></div>
        </div>
    </div>
    <div id="tipoDebito"></div>
    <div id="adicionar"></div>
    <div>
    </div>

</asp:Content>
