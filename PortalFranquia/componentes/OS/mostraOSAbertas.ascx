<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mostraOSAbertas.ascx.cs" Inherits="PortalFranquia.componentes.OS.mostraOSAbertas" %>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<form accept-charset="ISO-8859-1"></form>
<asp:Label ID="lbTitulo" runat="server" Text="Label" Font-Bold="true"></asp:Label>
<asp:GridView ID="grid" runat="server" ClientIDMode="Static"  AutoGenerateColumns="False" Width="100%">
    <Columns>
        <asp:BoundField DataField="Data" HeaderText="Data" DataFormatString="{0:d}" HeaderStyle-Font-Size="X-Small" HeaderStyle-Width="2%">
<HeaderStyle Font-Size="X-Small" Width="2%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Placa" HeaderText="Placa" HeaderStyle-Font-Size="X-Small" HeaderStyle-Width="2%">
<HeaderStyle Font-Size="X-Small" Width="2%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Contrato" HeaderText="Contrato" HeaderStyle-Width="2%">
<HeaderStyle Width="2%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Cliente" HeaderText="Cliente" HeaderStyle-Width="2%">
<HeaderStyle Width="2%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Veículo" HeaderText="Veículo" HeaderStyle-Width="2%">
<HeaderStyle Width="2%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Instalador" HeaderText="Instalador" HeaderStyle-Width="2%">     
<HeaderStyle Width="2%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="tipoOS" HeaderText="tipoOS" HeaderStyle-Width="2%">     
<HeaderStyle Width="2%"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="id_Equipamento"  HeaderText="id_Equipamento"  HeaderStyle-Width="2%" ApplyFormatInEditMode="True">     
<HeaderStyle Width="2%"></HeaderStyle>
        </asp:BoundField>
            <asp:BoundField DataField="dt_Gps" HeaderText="Gps" HeaderStyle-Width="2%">     
<HeaderStyle Width="2%"></HeaderStyle>
        </asp:BoundField>
        <asp:TemplateField ItemStyle-BorderStyle="None"  ItemStyle-BackColor="White" HeaderStyle-Width="5%">
            <ItemTemplate>                
                <asp:ImageButton runat="server" ID="btConfirmaOS" ImageUrl="~/imagens/chamado/salvar.jpg"  OnClientClick='<%# Eval("id_OS", "javascript:EncerrarOs({0}); return false;") %>' ToolTip="Encerra a OS"/>
                <asp:ImageButton runat="server" ID="btCancelaOS" ImageUrl="~/imagens/chamado/excluir.jpg" OnClientClick='<%# Eval("id_OS", "javascript:CancelaOS({0}); return false;") %>' ToolTip="Cancela a OS"/>
                <asp:ImageButton runat="server" ID="btTrocaEquipamento" ImageUrl="~/imagens/OS/trocaIcone.jpg" OnClientClick='<%# Eval("id_OS", "javascript:TrocaID({0}") + Eval("id_Equipamento",",{0}); return false;") %>' ToolTip="Troca equipamento"/>
            </ItemTemplate>

<HeaderStyle Width="5%"></HeaderStyle>

<ItemStyle BackColor="White" BorderStyle="None"></ItemStyle>
        </asp:TemplateField>   
    </Columns>
</asp:GridView>
<br />
