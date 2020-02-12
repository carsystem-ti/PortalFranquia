<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="dadosClienteComplementares.ascx.cs" Inherits="PortalFranquia.componentes.OS.dadosClienteComplementares" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Label ID="lbTitulo" runat="server" Text="Confirmação dos dados: " ForeColor="DarkBlue" Font-Bold="true" Font-Size="x-Large"></asp:Label>
<asp:Label ID="lbMensErro" runat="server" Text="" Visible="false" CssClass="mensErro"></asp:Label>
<br />
<div style="display:inline-block; width:100%">
    <div style="float: left; width: 40%">
        <asp:Label ID="Label1" runat="server" Text="Produto"></asp:Label>
        <br />
        <asp:TextBox ID="txtProduto" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>        
    </div>    
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 17%"">
        <asp:Label ID="Label2" runat="server" Text="Status"></asp:Label>
        <br />
        <asp:TextBox ID="txtStatus" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 20%"">
        <asp:Label ID="Label3" runat="server" Text="Atendimento"></asp:Label>
        <br />
        <asp:TextBox ID="txtAtendimento" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 20%">
        <asp:Label ID="Label4" runat="server" Text="Venda"></asp:Label>
        <br />
        <asp:TextBox ID="txtVenda" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
</div>
<br />
<div style="display:inline-block; width:100%">
    <div style="float: left; width: 15%">
        <asp:Label ID="Label5" runat="server" Text="CPF/CNPJ"></asp:Label>
        <br />
        <asp:TextBox ID="txtCPFCNPJ" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 25%">
        <asp:Label ID="Label6" runat="server" Text="RG/Inscrição Estadual"></asp:Label>
        <br />
        <asp:TextBox ID="txtRGInsEstadual" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 10%">
        <asp:Label ID="Label7" runat="server" Text="Dt. Nasc"></asp:Label>
        <br />
        <asp:TextBox ID="txtDtNasc" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 10%">
        <asp:Label ID="Label8" runat="server" Text="Dt. Venda"></asp:Label>
        <br />
        <asp:TextBox ID="txtDtVenda" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 15%">
        <asp:Label ID="Label9" runat="server" Text="Dt. Confirmação"></asp:Label>
        <br />
        <asp:TextBox ID="txtDtConfirmacao" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 20%">
        <asp:Label ID="Label10" runat="server" Text="Vendedor"></asp:Label>
        <br />
        <asp:TextBox ID="txtVendedor" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
</div>
<div style="display:inline-block; width: 100%">
    <div style="float: left; width: 18%">
        <asp:Label ID="Label11" runat="server" Text="Veículo"></asp:Label>
        <br />
        <asp:TextBox ID="txtVeiculo" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 10%">
        <asp:Label ID="Label12" runat="server" Text="Fabricante"></asp:Label>
        <br />
        <asp:TextBox ID="txtFabricante" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 10%">
        <asp:Label ID="Label13" runat="server" Text="Categoria"></asp:Label>
        <br />
        <asp:TextBox ID="txtCategoria" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 8%">
        <asp:Label ID="Label14" runat="server" Text="Ano"></asp:Label>
        <br />
        <asp:TextBox ID="txtAno" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 10%">
        <asp:Label ID="Label15" runat="server" Text="RENAVAN"></asp:Label>
        <br />
        <asp:TextBox ID="txtRenavan" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 18%">
        <asp:Label ID="Label16" runat="server" Text="CHASSI"></asp:Label>
        <br />
        <asp:TextBox ID="txtChassi" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 10%">
        <asp:Label ID="Label17" runat="server" Text="Combustível"></asp:Label>
        <br />
        <asp:TextBox ID="txtCombustivel" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
    <div style="float: left; width: 10px">
        &nbsp;
    </div>
    <div style="float: left; width: 10%">
        <asp:Label ID="Label18" runat="server" Text="Cor"></asp:Label>
        <br />
        <asp:TextBox ID="txtCor" runat="server" Width="100%" ReadOnly="true"></asp:TextBox>
    </div>
</div>
<br />
<div style="display:inline-block; width: 100%">
    <div style="float: right">
        <asp:Button ID="Button1" runat="server" Text="Solicitar Alteração" OnClick="Button1_Click" />
    </div>
</div>

<asp:Panel ID="pnAtualizaDados" runat="server" Visible="false">
    <asp:Label ID="Label19" runat="server" Text="Atualização de Dados : " ForeColor="DarkBlue" Font-Bold="true" Font-Size="x-Large"></asp:Label>
    <br />
    <div style="display:inline-block; width:100%">
        <div style="float: left; width: 50%">
            <asp:Label ID="Label20" runat="server" Text="Nome"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoNome" runat="server" Width="100%"></asp:TextBox>        
        </div>    
        <div style="float: left; width: 10px">
            &nbsp;
        </div>
        <div style="float: left; width: 18%">
            <asp:Label ID="Label21" runat="server" Text="CPF/CNPJ"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoCPFCNPJ" runat="server" Width="100%" ClientIDMode="Static" CssClass="somenteNumero"  onBlur="TrataCPFCNPJ(document.getElementById('txtNovoCPFCNPJ'));" onFocus="$('#txtNovoCPFCNPJ').val($('#txtNovoCPFCNPJ').val().replace(/\-/g,'').replace(/\./g,'').replace(/\//g,''))"></asp:TextBox>
        </div>
        <div style="float: left; width: 10px">
            &nbsp;
        </div>
        <div style="float: left; width: 18%">
            <asp:Label ID="Label22" runat="server" Text="RG/Inscrição Estadual"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoRGInsEstadual" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div style="float: left; width: 10px">
            &nbsp;
        </div>
        <div style="float: left; width: 10%">
            <asp:Label ID="Label23" runat="server" Text="Dt. Nasc"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoDtNascimento" runat="server" Width="100%"></asp:TextBox>
            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" Mask="99/99/9999" MaskType="Date" TargetControlID="txtNovoDtNascimento"></asp:MaskedEditExtender>                     
        </div>
    </div>
    <div style="display:inline-block; width: 100%">
        <div style="float: left; width: 18%">
            <asp:Label ID="Label24" runat="server" Text="Veículo"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoVeiculo" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div style="float: left; width: 10px">
            &nbsp;
        </div>
        <div style="float: left; width: 10%">
            <asp:Label ID="Label25" runat="server" Text="Fabricante"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoFabricante" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div style="float: left; width: 10px">
            &nbsp;
        </div>
        <div style="float: left; width: 10%">
            <asp:Label ID="Label26" runat="server" Text="Categoria"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoCategoria" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div style="float: left; width: 10px">
            &nbsp;
        </div>
        <div style="float: left; width: 8%">
            <asp:Label ID="Label27" runat="server" Text="Ano"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoAno" runat="server" Width="100%" CssClass="somenteNumero"></asp:TextBox>
            
        </div>
        <div style="float: left; width: 10px">
            &nbsp;
        </div>
        <div style="float: left; width: 10%">
            <asp:Label ID="Label28" runat="server" Text="RENAVAN"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoRENAVAN" runat="server" Width="100%" CssClass="somenteNumero"></asp:TextBox>
        </div>
        <div style="float: left; width: 10px">
            &nbsp;
        </div>
        <div style="float: left; width: 18%">
            <asp:Label ID="Label29" runat="server" Text="CHASSI"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoCHASSI" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div style="float: left; width: 10px">
            &nbsp;
        </div>
        <div style="float: left; width: 10%">
            <asp:Label ID="Label30" runat="server" Text="Combustível"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoCombustivel" runat="server" Width="100%"></asp:TextBox>
        </div>
        <div style="float: left; width: 10px">
            &nbsp;
        </div>
        <div style="float: left; width: 10%">
            <asp:Label ID="Label31" runat="server" Text="Cor"></asp:Label>
            <br />
            <asp:TextBox ID="txtNovoCor" runat="server" Width="100%"></asp:TextBox>
        </div>
    </div>
    <div style="display:inline-block; width:100%">
        <div style="float: right">
            <asp:Button ID="Button2" runat="server" Text="Enviar" OnClick="Button2_Click" />
        </div>
    </div>
</asp:Panel>
