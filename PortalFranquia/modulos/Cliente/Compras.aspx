<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="PortalFranquia.modulos.Cliente.Compras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <style type="text/css" >
            table {
                border-collapse: separate;
                border-spacing: 1;
            } 
            table, td, th {  
                border: 0px solid #4cff00;
                text-align: left;
                border-radius: 5px;
                -moz-border-radius: 5px;
                background-color: 1px;
            }
            .auto-style3 {
                width: 100%;
                color: dodgerblue;
                text-align: center;
                border-collapse: separate;
                font-weight: bold;
                -moz-border-radius: 1px;
            }
            .auto-style4 {
                height: 24px;
                text-align: center;
                font-size: 16px;
            }
            .auto-style5 {
                height: 24px;
                text-align: center;
                font-size: 10px;
            }

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style3">
                <tr>
                    <td class="auto-style4">COMPRAS</td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:GridView ID="gdCompras" runat="server" CellPadding="4" GridLines="None" ForeColor="#333333" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Pedido" HeaderText="Pedido"></asp:BoundField>
                                <asp:BoundField DataField="Prod e Serviços" HeaderText="Prod e Serviços" />
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                <asp:BoundField DataField="Valor" DataFormatString="{0:c}" HeaderText="Valor" />
                                <asp:BoundField DataField="Desc." DataFormatString="{0:c}" HeaderText="Desc" />
                                <asp:BoundField DataField="Desc. Prom." DataFormatString="{0:c}" HeaderText="Desc. Prom." />
                                <asp:BoundField DataField="Total" DataFormatString="{0:c}" HeaderText="Total" />
                                <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" />
                                <asp:BoundField DataField="Supervisor" HeaderText="Supervisor" />
                                <asp:BoundField DataField="Data Ped." HeaderText="Data Ped." />
                                <asp:BoundField DataField="Confirmação" HeaderText="Confirmação" />
                                <asp:BoundField DataField="Cancelamento" HeaderText="Cancelamento" />
                                <asp:BoundField DataField="Status" HeaderText="Status" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
