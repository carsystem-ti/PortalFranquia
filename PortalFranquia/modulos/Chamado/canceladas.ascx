<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="canceladas.ascx.cs" Inherits="PortalFranquia.modulos.Chamados.canceladas" %>
<script src="../../js/jquery.min.js"></script>
<script src="../../js/jquery-ui.js"></script>
<script src="../../js/MaskedEditFix.js"></script>
<script src="../../js/mask.js"></script>
<script src="../../js/jquery.centralize.js"></script>
<script src="../../js/jquery.PrintArea.js"></script>
<script src="../../js/kModal.js"></script>
<link href="css/mensagem.css" rel="stylesheet" />
<link href="../../css/kModal.css" rel="stylesheet" />

<style type="text/css">
    td {
        margin: 0;
        padding: 0;
        border: 0;
        outline: 0;
        font-weight: inherit;
        font-style: inherit;
        font-size: 100%;
        font-family: inherit;
        vertical-align: none;
        background-color: white;
    }

    .GridChamados {
        background-color: #4fd8e8;
        background-image: linear-gradient(to bottom, transparent, rgba(0,0,0,.3));
    }

    .css {
        /*background: #1e5799; /* Old browsers */
        background: -moz-linear-gradient(top, #1e5799 0%, #7db9e8 55%); /* FF3.6+ */
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#1e5799), color-stop(55%,#7db9e8)); /* Chrome,Safari4+ */
        background: -webkit-linear-gradient(top, #1e5799 0%,#7db9e8 55%); /* Chrome10+,Safari5.1+ */
        background: -o-linear-gradient(top, #1e5799 0%,#7db9e8 55%); /* Opera 11.10+ */
        background: -ms-linear-gradient(top, #1e5799 0%,#7db9e8 55%); /* IE10+ */
        background: linear-gradient(to bottom, #1e5799 0%,#7db9e8 55%); /* W3C */
        filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#1e5799', endColorstr='#7db9e8',GradientType=0 ); /* IE6-9 */
    }

    .containerImpressaoOS {
        overflow-y: scroll;
        width: 900px;
        height: 500px;
    }

</style>
<fieldset style="width: 994px;margin-left: 8%">
    <legend>Chamados em Canceladas</legend>
    <br />
    <asp:GridView ID="GridChamados" CssClass="css" runat="server" AutoGenerateColumns="False" Font-Names="Vrinda" Font-Size="Small" OnRowDataBound="GridChamados_RowDataBound" Width="987px" OnSelectedIndexChanged="GridChamados_SelectedIndexChanged" BackColor="#4fd8e8" BorderColor="White" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="True" OnPageIndexChanging="GridChamados_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Nr.Chamado" HeaderText="Nr.Chamado">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Data" HeaderText="Data Abertura">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
              <asp:BoundField DataField="ds_Departamento" HeaderText="DP">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Usuario" HeaderText="Usuario">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Assunto" HeaderText="Assunto">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="Franquia" HeaderText="Franquia">
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:CommandField ShowSelectButton="True">
               <ItemStyle CssClass="divSomeSelect" />
            </asp:CommandField>
        </Columns>
       <SelectedRowStyle CssClass="selectRowTD" />
        <FooterStyle BackColor="#4fd8e8" CssClass="css" ForeColor="Black" />
        <HeaderStyle BackColor="#4fd8e8" CssClass="css" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#4fd8e8" CssClass="css" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#4fd8e8" CssClass="css" ForeColor="Black" />
        <SortedAscendingCellStyle CssClass="css" BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle CssClass="css" BackColor="#4fd8e8" />
        <SortedDescendingCellStyle CssClass="css" BackColor="#4fd8e8" />
        <SortedDescendingHeaderStyle CssClass="css" BackColor="#4fd8e8" />
    </asp:GridView>
    <br />
    <br />
    <br />
</fieldset>