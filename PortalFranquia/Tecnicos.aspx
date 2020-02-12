<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="PortalFranquia.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 1215px;
            height: 456px;
        }
        .auto-style2 {
            width: 384px;
        }
        .auto-style3 {
            height: 23px;
            width: 1207px;
        }
        .auto-style4 {
            height: 170px;
        }
        .auto-style5 {
            text-align: left;
        }
        .auto-style6 {
            width: 691px;
        }
        .auto-style7 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr style="text-align:left; font-size:large;">
                <td class="auto-style3">
                    <asp:RadioButton ID="rdbCadastro" runat="server" OnCheckedChanged="rdbCadastro_CheckedChanged" AutoPostBack="true" Font-Bold="True" ForeColor="#0066CC" Text="CADASTRO" Font-Names="Verdana" />

                    <asp:RadioButton ID="rdbDesativacao" runat="server" OnCheckedChanged="rdbDesativacao_CheckedChanged" AutoPostBack="true" Font-Bold="True" Font-Names="Verdana" Text="DESATIVAÇÃO" ForeColor="#0066CC" />
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td rowspan="2" class="auto-style2" style="background-color:white; vertical-align:top; font-size:large; border-color:white;">
                    <asp:GridView ID="grvLojas" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" DataSourceID="SqlDataSource1" PageSize="12" OnSelectedIndexChanged="grvLojas_SelectedIndexChanged" Visible="False">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="cd_cetec" HeaderText="Cetec/Franquia" SortExpression="cd_cetec" >
                            <HeaderStyle Font-Size="10pt" Font-Bold="True" Font-Names="Verdana" />
                            <ItemStyle BackColor="White" Font-Size="10pt" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ds_cetec" HeaderText="Descrição" ReadOnly="True" SortExpression="Descrição" >
                            <HeaderStyle Font-Size="10pt" Font-Bold="True" Font-Names="Verdana" HorizontalAlign="Left" />
                            <ItemStyle BackColor="White" Font-Size="10pt" />
                            </asp:BoundField>
                            <asp:CommandField ButtonType="Button" HeaderText="Selecionar" ShowHeader="True" ShowSelectButton="True" >
                            <HeaderStyle Font-Size="10pt" Font-Strikeout="False" Font-Bold="True" Font-Names="Verdana" />
                            <ItemStyle BackColor="White" Font-Size="10pt" />
                            </asp:CommandField>
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" BorderColor="Black" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnxFranquia %>" SelectCommand="pro_GetCetecsFranquiasTecnicos" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </td>
                <div id="divCadastro">
                    <td style="background-color:white; vertical-align:top; font-size:large; border-color:white;" class="auto-style4">
                        <asp:Label ID="lblCadastro" BackColor="YellowGreen" runat="server" Text="CADASTRO - Cadastrar instalador" BorderStyle="Ridge" Width="805px" Font-Bold="True" Font-Names="Verdana" ForeColor="#0066CC"></asp:Label>
                            <br /><br />

                        <table class="auto-style6">
                            <tr>
                                <td style="background-color:white; vertical-align:top; font-size:large; border-color:white;" colspan="2">
                                    <asp:Label ID="lblDigiteNomeInstalador" BackColor="YellowGreen"  runat="server" Text="Digite o nome do Instalador" BorderColor="#CCCCCC" BorderStyle="Ridge" Width="735px" Font-Bold="True" Font-Names="Verdana" ForeColor="#0066CC" Font-Size="10pt" Visible="False"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td style="background-color:white; border-color:white;" class="auto-style5">
                                    <asp:TextBox ID="txtNomeInstalador" runat="server" Height="32px" Width="607px" Font-Names="Verdana" Font-Size="10pt" Visible="False" Enabled="False"></asp:TextBox>
                                </td>
                                <td style="background-color:white; border-color:white;" class="auto-style7">
                                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" Height="41px" OnClick="btnCadastrar_Click" Visible="False" Enabled="False" />
                                </td>
                            </tr>
                            
                        </table>
                        
                        <asp:Label ID="lblMsg" Visible="false" ForeColor="Red" runat="server" Text=""></asp:Label>
                        
                        <br /><br />

                    </td>
                </div>
            </tr>
            <tr>
                <div id="divDesativacao">
                    <td style="background-color:white; vertical-align:top; font-size:large; border-color:white;">
                        <asp:Label ID="lblDesativar" BackColor="YellowGreen"  runat="server" Text="DESATIVAÇÃO - Desativar Instalador" BorderColor="#CCCCCC" BorderStyle="Ridge" Width="805px" Font-Bold="True" Font-Names="Verdana" ForeColor="#0066CC"></asp:Label>
                        <asp:Label ID="lblCodigo" runat="server" Text="Label" Visible="false"></asp:Label>
                        <br /><br />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id instalador" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="5" Width="801px" AllowPaging="True" BorderStyle="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="Instalador" HeaderText="Instalador" ReadOnly="True" >
                                <HeaderStyle Font-Size="10pt" HorizontalAlign="Left" Font-Bold="True" Font-Names="Verdana" />
                                <ItemStyle BackColor="White" Font-Size="10pt" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Id Instalador" HeaderText="Id Instalador" InsertVisible="False" ReadOnly="True" SortExpression="Id Instalador" >
                                <HeaderStyle Font-Size="10pt" Font-Bold="True" Font-Names="Verdana" />
                                <ItemStyle BackColor="White" Font-Size="10pt" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:CommandField ButtonType="Button" HeaderText="Selecionar" SelectText="Desativar" ShowSelectButton="True" >
                                <HeaderStyle Font-Size="10pt" Font-Bold="True" Font-Names="Verdana" />
                                <ItemStyle BackColor="White" HorizontalAlign="Center" />
                                </asp:CommandField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:cnxFranquia %>" SelectCommand="pro_GetTecnicosDesativar" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblCodigo" Name="cd_cetec" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </div>
            </tr>
        </table>
    </div>
</asp:Content>
