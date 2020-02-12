<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="RelVendasFranquia.aspx.cs" Inherits="PortalFranquia.modulos.relatorios.RelVendasFranquia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/comum.css" rel="stylesheet" />
    <link href="../../css/RelatorioPagamento.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float:left;margin-left:0%">
        <br />
    <asp:Label ID="Label1" runat="server" Text="Selecione o período (mês/ano):"></asp:Label>
    <asp:DropDownList ID="ddlMes" runat="server">
        <asp:ListItem Value="1">01</asp:ListItem>
        <asp:ListItem Value="2">02</asp:ListItem>
        <asp:ListItem Value="3">03</asp:ListItem>
        <asp:ListItem Value="4">04</asp:ListItem>
        <asp:ListItem Value="5">05</asp:ListItem>
        <asp:ListItem Value="6">06</asp:ListItem>
        <asp:ListItem Value="7">07</asp:ListItem>
        <asp:ListItem Value="8">08</asp:ListItem>
        <asp:ListItem Value="9">09</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
    </asp:DropDownList>
    
        &nbsp;<asp:TextBox ID="txtAno" runat="server" Width="50px" AutoPostBack="True"></asp:TextBox>
        &nbsp;<asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" Height="29px" Width="100px" />  &nbsp;  </asp:UpdatePanel>

        &nbsp;
        &nbsp;
        <br />
        <br />
    </div>
    <br />    <br />    <br />
    <asp:Panel ID="pnTituloRelvnd" runat="server" CssClass="divAzulTitulo" Height="16px" Visible="false" Width="1221px">
        <asp:Label ID="lbTitulovnd" runat="server" Visible="False" Text="Período de apuração  - Vendas de acordo com a Politica de Vendas "></asp:Label>
    </asp:Panel>
    <asp:GridView ID="GridRelVnd" runat="server" AutoGenerateColumns="False" CssClass="Analitico" HeaderStyle-CssClass="AnaliticoHeader" FooterStyle-CssClass="AnaliticoFooter" ForeColor="#333333" GridLines="None" Width="100%" ShowFooter="True" OnRowDataBound="GridRelVnd_RowDataBound" OnSorting="GridRelVnd_Sorting">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="dt_confirmacao" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ds_vendedor" HeaderText="Vendedor">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="nr_contrato" HeaderText="Contrato">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ds_produto" HeaderText="Produto">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="vl_unitario" HeaderText="Valor" DataFormatString="{0:c}">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <EmptyDataTemplate>
            <asp:Label ID="lbsemdb" runat="server" ForeColor="Red" Text="Não Existe Dados"></asp:Label>
        </EmptyDataTemplate>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

<div style="float:right;padding-top: 0px" visible="false">
                <fieldset visible="false">
                <asp:Label ID="lbexportar" runat="server" Text="Exportar para.:" Font-Bold="True" visible="false" ></asp:Label>
                <asp:ImageButton ID="imgExport" runat="server" Height="27px" ImageUrl="~/imagens/relatorios/btn_excel.png" Width="32px" visible="false" OnClick="imgExport_Click" />
                </fieldset>
        <br />
   
</asp:Content>