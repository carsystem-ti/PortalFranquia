<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="CorrigirCheques.aspx.cs" Inherits="PortalFranquia.modulos.Vendas.CorrigirCheques" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/Bordero.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="painel" runat="server" Width="589px">
        <fieldset style="width: 473px">
            <legend>Filtros </legend>
            <div style="float:left; width: 371px;">
                <asp:Label ID="Label52" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Consulta" Width="71px"></asp:Label>
            </div>
            <br />
            <div style="float:right; width: 571px;">
                <asp:DropDownList ID="dropSelecao" runat="server" Height="27px" Width="185px" Font-Italic="True" Font-Names="Vrinda" ForeColor="Black">
                    <asp:ListItem Value="0">Selecione</asp:ListItem>
                    <asp:ListItem Value="2">Pedido</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtConsulta" runat="server" Height="21px" Width="100px"></asp:TextBox>
                <asp:DropDownList ID="dropfranquias" runat="server" DataTextField="ds_franquia" DataValueField="id_franquia" Height="25px" Visible="False" Width="175px">
                </asp:DropDownList>
                <asp:ImageButton ID="imgBuscar" runat="server" Height="25px" ImageUrl="~/imagens/Bordero/buscar.jpg" OnClick="imgBuscar_Click" Width="84px" />
            </div>
        </fieldset>
    </asp:Panel>
    <br />
   <asp:Panel ID="dadosCheques" ClientIDMode="Static"   runat="server" Visible="false" Width="937px">
        <div style="float: left; width: 1055px;">
            <asp:Label ID="Label54" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Código" Width="54px" ForeColor="#FF3300"></asp:Label>
            <asp:Label ID="Label1" runat="server" ClientIDMode="Static" CssClass="label" ForeColor="#FF3300" Height="16px" Text="Parcela" Width="54px"></asp:Label>
            <asp:Label ID="Label47" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Banco" Width="63px"></asp:Label>
            <asp:Label ID="Label51" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Conta" Width="88px"></asp:Label>
            <asp:Label ID="Label9" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Agencia" Width="96px"></asp:Label>
            <asp:Label ID="Label49" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Cheque" Width="95px"></asp:Label>
            <asp:Label ID="Label11" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Data Venc" Width="106px"></asp:Label>
            <asp:Label ID="Label50" runat="server" ClientIDMode="Static" CssClass="label" Height="16px" Text="Valor " Width="100px"></asp:Label>
        </div>
        <br />
        <div style="float: left;">
            <asp:TextBox ID="txtCodigo" runat="server" Height="20px" Width="44px" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="txtParcela" runat="server" Height="20px" Width="44px"></asp:TextBox>
            <asp:TextBox ID="txtBanco" runat="server" Height="20px" Width="62px" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="txtConta" runat="server" Enabled="False" Height="20px" Width="82px"></asp:TextBox>
            <asp:TextBox ID="txtAgencia" runat="server" Height="20px" Width="92px" ClientIDMode="Static" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="txtCheque" runat="server" ClientIDMode="Static" Height="20px" Width="92px" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="txtVencimento" runat="server" ClientIDMode="Static" Height="20px" Width="92px" Enabled="False"></asp:TextBox>
            <asp:TextBox ID="txtValor" runat="server" ClientIDMode="Static" Height="20px" Width="92px" Enabled="False"></asp:TextBox>
            &nbsp;
        </div>
        <asp:Button ID="btnAtualizar" runat="server" Height="33px" OnClick="btnAtualizar_Click" Text="Atualizar" Width="115px" />
       <br />
        <asp:CheckBox ID="chktroca" runat="server" AutoPostBack="True" Text="Cheque de Troca" />
    </asp:Panel>
    <br />
    <div id="dvLeitura" runat="server" visible="false" style="float:left;margin-left:40%">
        <asp:Label ID="Label53" runat="server" Text="CMC7"></asp:Label>
        <asp:TextBox ID="txtLeitura" runat="server" OnTextChanged="txtLeitura_TextChanged" Width="271px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Height="30px" Text="Leitura" OnClick="Button1_Click" />
</div>
    <div style="height: 350px; overflow: auto; float: left; width: 1220px;">
        <div style="float: left; width: 1212px;">
            <br />
            <asp:GridView ID="GvBordero" runat="server" CellSpacing="-1" Height="5px" Width="100%" Font-Size="X-Small" AutoGenerateColumns="False" DataKeyNames="id_pedido" Font-Names="Verdana">
                <AlternatingRowStyle Font-Names="Verdana" Font-Size="X-Small" />
                <Columns>
                    <asp:TemplateField HeaderText="Selecione">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelecionar" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelecioner_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="id_pedido" HeaderText="Pedido" />
                    <asp:BoundField DataField="id_pagamento" HeaderText="Código" />
                    <asp:BoundField DataField="ds_pagamento" HeaderText="Descricão" />
                    <asp:BoundField DataField="pc_pagamento" HeaderText="Parcela" />
                    <asp:BoundField DataField="vl_pagamento" HeaderText="Valor" DataFormatString="{0:#,##0.00;(#,##0.00);0}" />
                    <asp:BoundField DataField="dt_vencimento" HeaderText="Data Venc." />
                    <asp:BoundField DataField="ds_titular" HeaderText="Titular" />
                    <asp:BoundField DataField="nr_agencia" HeaderText="Agencia" />
                    <asp:BoundField DataField="nr_conta" HeaderText="nr_conta" />
                    <asp:BoundField DataField="nr_documento" HeaderText="Documento" />
                    <asp:BoundField DataField="nr_cheque" HeaderText="Cheque" />
                    <asp:BoundField DataField="nr_banco" HeaderText="Banco" />
                    <asp:BoundField DataField="nr_conta" HeaderText="Conta" />
                    <asp:BoundField DataField="nr_ccm7" HeaderText="nr_ccm7" />
                </Columns>
                <EditRowStyle Font-Names="Verdana" Font-Size="X-Small" />
                <EmptyDataRowStyle Font-Names="Verdana" Font-Size="X-Small" />
                <FooterStyle Font-Names="Verdana" Font-Size="Small" />
            </asp:GridView>
        </div>
        <div>
        </div>
    </div>

</asp:Content>
