<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Veiculo.aspx.cs" Inherits="PortalFranquia.modulos.Cliente.Veiculo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        table {
            border-collapse: separate;
            border-spacing: 2;
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
            -moz-border-radius: 5px;
        }


        .auto-style4 {
            text-align: center;
        }

        .auto-style5 {
            width: 230px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }
        .auto-style6 {
            border-radius: 12px;
            color: red;
            border-collapse: separate;
            text-align: left;
            font-weight: bold;
            font-size: 16px;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }

        .auto-style7 {
            width: 180px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }
        .auto-style8 {
            width: 180px;
        }

        .auto-style9 {
            text-align: left;
            font-weight: bold;
        }

        .auto-style11 {
            margin-left: 2px;
            border-radius: 10px;
            font-size: 12px;
        }

        .auto-style12 {
            text-align: center;
            width: 917px;
            font-size: 16px;
        }
        .auto-style13 {
            text-align: left;
            width: 180px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style3">
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style13">TROCA DE VEÍCULO</td>
                        <td class="auto-style12">DADOS DO VEÍCULO ATUAL</td>
                        <td class="auto-style9">
                            <asp:Button ID="btnTrocaVeiculo" runat="server" Text="Efetuar Troca de Veículo" OnClick="btnTrocaVeiculo_Click" CssClass="auto-style11" Height="41px" /></td>
                    </tr>
                </table>
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style5">Placa</td>
                        <td class="auto-style5">Tipo</td>
                        <td class="auto-style5">Fabricante</td>
                        <td class="auto-style5">Modelo</td>
                        <td class="auto-style5">Cor</td>
                        <td class="auto-style5">Comb.</td>
                        <td class="auto-style5">Chassi</td>
                        <td class="auto-style5">Renavan</td>
                        <td class="auto-style5">Ano</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPlaca" runat="server" Text=""></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblTipo" runat="server" Text=""></asp:Label>

                        </td>
                        <td>
                            <asp:Label ID="lblFabricante" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblModelo" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCor" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblComb" runat="server" Text=""></asp:Label></td>
                        <td>
                            <asp:Label ID="lblChassi" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRenavan" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblAno" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
                <hr />
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style4">DADOS DO NOVO VEÍCULO</td>
                    </tr>
                </table>
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style5">Placa</td>
                        <td class="auto-style7">Tipo</td>
                        <td class="auto-style5">Fabricante</td>
                        <td class="auto-style5">Modelo</td>
                        <td class="auto-style5">Cor</td>
                        <td class="auto-style5">Comb.</td>
                        <td class="auto-style5">Chassi</td>
                        <td class="auto-style5">Renavan</td>
                        <td class="auto-style5">Ano</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPlaca" Width="80" MaxLength="7" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style8">
                            <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Tipo" DataValueField="Tipo">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnxFranquia %>" SelectCommand="SELECT Tipo From Principal..[Tipos de veiculo] WHERE (Ativo = 'S')"></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlFabricante" runat="server" Width="200" DataSourceID="SqlDataSource3" DataTextField="ds_fabricante" DataValueField="id_fabricante" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:cnxFranquia %>" SelectCommand="select id_fabricante,ds_fabricante from Principal..tbl_Cad_Fabricante  where fl_ativo = 'S' order by 1
    "></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlModelo" runat="server" Width="200" DataSourceID="SqlDataSource2" DataTextField="Modelo">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:cnxFranquia %>" SelectCommand="Franquia.pro_getModelos" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlFabricante" Name="id" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>

                        <td>
                            <asp:DropDownList ID="ddlCor" runat="server" Width="90" MaxLength="4" DataSourceID="SqlDataSource4" DataTextField="Cor" DataValueField="Cor">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:cnxFranquia %>" SelectCommand="SELECT [Ca cor] AS Cor From Cores"></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlComb" runat="server" Width="95" DataSourceID="SqlDataSource5" DataTextField="Combustivel" DataValueField="id">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:cnxFranquia %>" SelectCommand="SELECT id,Combustivel From Combustivel"></asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:TextBox ID="txtChassi" Width="130" MaxLength="17" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRenavan" Width="100" MaxLength="11" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAno" Width="40" MaxLength="4" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style6">

                            <asp:Label ID="lblMensagemErro" runat="server" Text=""></asp:Label>

                        </td>
                    </tr>
                </table>
        </table>
        </div>
    </form>
</body>
</html>
