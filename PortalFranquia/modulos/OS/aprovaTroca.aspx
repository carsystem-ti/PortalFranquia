<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="aprovaTroca.aspx.cs" Inherits="PortalFranquia.modulos.OS.aprovaTroca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="lbMensErro" runat="server" Text="" Visible="false" CssClass="mensErro"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbTitulo" runat="server" Text="Dados do Proprietário" ForeColor="Gray" Font-Bold="true" Font-Size="x-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Nome do Proprietário"></asp:Label>
            <asp:TextBox ID="txtNomeProp" runat="server" Width="40%" Enabled="false"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="CPF/CNPJ"></asp:Label>
            <asp:TextBox ID="txtCPFCNPJProp" runat="server" Width="15%" Enabled="false"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="RG"></asp:Label>
            <asp:TextBox ID="txtRGProp" runat="server" Width="15%" Enabled="false"></asp:TextBox>
            <asp:HiddenField ID="txtContrato" runat="server" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Dados Transferência" ForeColor="Gray" Font-Bold="true" Font-Size="x-Large"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Nome"></asp:Label>
            <asp:TextBox ID="txtNomeNovo" runat="server" Width="30%"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="CPF/CNPJ Novo"></asp:Label>
            <asp:TextBox ID="txtCPFCNPJ" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="RG Novo"></asp:Label>
            <asp:TextBox ID="txtRG" runat="server"></asp:TextBox>
            <asp:RadioButton ID="rbFisica" runat="server" Text="Fisica" Checked="true" />
            <asp:RadioButton ID="rbJuridica" runat="server" Text="Juridica" Checked="false" />
            <br />
            <br />
            <br />
            <div style="text-align: center">
                <asp:Button ID="btEnviar" runat="server" Text="Enviar Consulta" OnClick="btEnviar_Click" />
                <br />
                <br />
                <asp:Label ID="lbProtocoloEnvio" runat="server" Text="" CssClass="mensErro"></asp:Label>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btEnviar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
