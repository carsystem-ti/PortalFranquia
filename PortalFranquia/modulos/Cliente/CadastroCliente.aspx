<%@ Page Title="" Language="C#" MasterPageFile="~/principal.Master" AutoEventWireup="true" CodeBehind="CadastroCliente.aspx.cs" Inherits="PortalFranquia.modulos.Cliente.CadastroCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <style type="text/css" >
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
        .auto-style1 {
            width: 47%;
            margin-left: 23px;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }

        .auto-style4 {
            width: 180px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            color: white;
            height: 18px;
        }

        .auto-style5 {
            width: 210px;
            font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            color:white;
            height: 18px;
            background-color: white;
            border: 0px;
        }

        .auto-style6 {
            width: 150px;
            border-radius: 14px;
            
        }
        .auto-style8 {
            width: 79%;
            margin-left: 23px;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }
        .auto-style9 {
            background-color: white; 
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 210px;
            height: 18px;
        }
        .auto-style10 {
            background-color:white; 
            font-family:Arial; 
            font-size: 12px;
            color:dodgerblue;
            width: 800px;
            height: 18px;
        }
        
        .auto-style12 {
            width: 282px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }
        .auto-style13 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 282px;
            height: 18px;
        }

        .auto-style14 {
            width: 339px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }
        .auto-style15 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 339px;
            height: 18px;
        }

        .auto-style16 {
            width: 395px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }
        .auto-style17 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 395px;
            height: 18px;
        }

        .auto-style18 {
            width: 95%;
            margin-left: 23px;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            color: dimgray;
            background-color: white;
        }

        .auto-style21 {
            width: 599px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }

        .auto-style22 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 500px;
            height: 18px;
        }

        .auto-style23 {
            width: 612px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }
        .auto-style24 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 450px;
            height: 18px;
        }


        .auto-style26 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 370px;
            height: 18px;
        }
        .auto-style27 {
            width: 370px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }
        .auto-style30 {
            width: 489px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }

        .auto-style32 {
            width: 120px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }

        .auto-style33 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 120px;
            height: 18px;
        }

        .auto-style34 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 489px;
            height: 18px;
        }
        .auto-style35 {
            width: 355px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }
        .auto-style36 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 355px;
            height: 18px;
        }

        .auto-style38 {
            background-color: white;
            font-family: Arial;
            font-size: 12px;
            color: dodgerblue;
            width: 299px;
            height: 18px;
        }
        .auto-style39 {
            width: 299px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }


        .auto-style40 {
            width: 347px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }

        .auto-style41 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 347px;
            height: 18px;
        }

        .auto-style44 {
            width: 230px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }

        .auto-style51 {
            width: 802px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            height: 18px;
            color: dimgray;
            background-color: #cdfe99;
        }

        .auto-style52 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 802px;
            height: 18px;
        }


        .auto-style53 {
            width: 219px;
            background-color: white;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            color: white;
            height: 18px;
        }
        .auto-style54 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 219px;
            height: 18px;
        }

        .auto-style55 {
            border-radius: 14px;
            font-size: 10px;
        }

        .auto-style56 {
            width: 470px;
            vertical-align:top;
            color: dimgray;
            background-color: white;
            text-align:left;
        }
        
        .auto-style59 {
            width: 604px;
            color: dimgray;
            background-color: white;
            height: 213px;
            text-align:left;
        }

        .auto-style60 {
            width: 155px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            color: dimgray;
            background-color: #cdfe99;
        }

        .auto-style61 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 155px;
            height: 18px;
        }

        .auto-style62 {
            width: 469px;
            background-color:white;
            color: dimgray;
            background-color: white;
            text-align: center;
            vertical-align:top;
        }

        .auto-style63 {
            width: 155px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            text-align: center;
            vertical-align: middle;
            color: dimgray;
            background-color: #cdfe99;
        }

        .auto-style64 {
            width: 95%;
            margin-left: 0px;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            vertical-align: top;
            color: dimgray;
            background-color: white;
        }

        .auto-style65 {
            width: 293px;
            font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
            color: dimgray;
            background-color: #cdfe99;
            border-collapse: separate;
            border-spacing: 2;
        }

        .auto-style66 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 293px;
            height: 18px;
        }

        .auto-style67 {
            width: 626px;
            height: 25px;
        }
        .auto-style68 {
            width: 95%;
            margin-left: 23px;
            font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
        }
        .auto-style69 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 82px;
            height: 18px;
        }
        .auto-style70 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 68px;
            height: 18px;
        }
        .auto-style71 {
            background-color: white;
            font-family: Arial;
            font-size: 15px;
            color: dodgerblue;
            width: 64px;
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
    <form id="form">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">Pedido(Contrato)</td>
                    <td class="auto-style4">Placa do Veículo</td>
                    <td class="auto-style4">CPF/CNPJ</td>
                    <td colspan="2" rowspan="2" style="background-color:white;">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="auto-style6" Height="48px" OnClick="btnBuscar_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtContrato" MaxLength="6" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtPlaca" MaxLength="7" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtCpfCnpj" MaxLength="18" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <hr />
            <asp:Panel ID="pnlCadastro" Visible="false" runat="server">
                <div id="divCadastro" >
                    <table class="auto-style8">
                        <tr>
                            <td class="auto-style44">Pedido(Contrato)</td>
                            <td class="auto-style44">Status</td>
                            <td class="auto-style44">Atendimento</td>
                            <td class="auto-style44">Venda</td>

                            <td class="auto-style53"></td>
            
                            <td class="auto-style44">Tel. Residencial</td>
                            <td class="auto-style44">Tel. Celular</td>
                            <td class="auto-style44">Tel. Comercial</td>

                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <b><asp:Label ID="lblContrato" runat="server" Text=""></asp:Label></b>
                            </td>
                            <td class="auto-style9">
                                <asp:Label ID="lblStatusEquipamento" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:Label ID="lblAtendimento" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:Label ID="lblStatusVenda" runat="server" Text=""></asp:Label>
                            </td>

                            <td class="auto-style54"></td>
            
                            <td class="auto-style24">
                                <b><asp:Label ID="lblTelResidencial" runat="server" Text=""></asp:Label></b>
                            </td>
                            <td class="auto-style24">
                                <b><asp:Label ID="lblTelCelular" runat="server" Text=""></asp:Label></b>
                            </td>
                            <td class="auto-style24">
                                <b><asp:Label ID="lblTelComercial" runat="server" Text=""></asp:Label></b>
                            </td>
                        </tr>
                    </table>
                    <table class="auto-style68">
                        <tr>
                            <td class="auto-style51">Cliente</td>
                            <td class="auto-style16">CPF / CNPJ</td>
                            <td class="auto-style14">RG / IE</td>
                            <td class="auto-style12">Data Nascimento</td>
                            <td colspan="2" rowspan="2" style="background-color:white;">
                                <asp:Button ID="btnEndereco" runat="server" Text="Endereço" CssClass="auto-style55" Height="48px" OnClick="btnEndereco_Click" OnClientClick="mensagem()" />
                            </td>
                            <td colspan="2" rowspan="2" style="background-color:white;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style52">
                                <b><asp:Label ID="lblCliente" runat="server" Text=""></asp:Label></b>
                            </td>
                            <td class="auto-style17">
                                <asp:Label ID="lblCpfCnpj" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style15">
                                <asp:Label ID="lblRgIe" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="auto-style13">
                                <asp:Label ID="lblDtNascimento" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table class="auto-style18">
                        <tr>
                            <td class="auto-style40">Tipo Veículo</td>
                            <td class="auto-style39">Fabricante</td>
                            <td class="auto-style39">Modelo</td>
                            <td class="auto-style27">Placa</td>
                            <td class="auto-style32">Ano</td>
                            <td class="auto-style35">Renavan</td>
                            <td class="auto-style30">Chassi</td>
                            <td class="auto-style21">Combustível</td>
                            <td class="auto-style23">Cor</td>
                        </tr>
                        <tr>
                            <td  class="auto-style41">
                                <asp:Label ID="lblTpVeiculo" runat="server" Text=""></asp:Label>

                            </td>
                            <td  class="auto-style38">

                                <asp:Label ID="lblFabricante" runat="server" Text=""></asp:Label>

                            </td>
                            <td  class="auto-style10">

                                <asp:Label ID="lblModelo" runat="server" Text=""></asp:Label>

                            </td>
                            <td  class="auto-style26">

                                <asp:Label ID="lblPlaca" runat="server" Text=""></asp:Label>

                            </td>
                            <td  class="auto-style33">

                                <asp:Label ID="lblAno" runat="server" Text=""></asp:Label>

                            </td>
                            <td  class="auto-style36">

                                <asp:Label ID="lblRenavan" runat="server" Text=""></asp:Label>

                            </td>
                            <td  class="auto-style34">

                                <asp:Label ID="lblChassi" runat="server" Text=""></asp:Label>

                            </td>
                            <td  class="auto-style22">
                                <asp:Label ID="lblCombustivel" runat="server" Text=""></asp:Label>
                            </td>
                            <td  class="auto-style24">
                                <asp:Label ID="lblCor" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table class="auto-style18">
                        <tr>
                            <td class="auto-style56">
                                <table class="auto-style59">
                                    <tr style="vertical-align:central;">
                                        <td class="auto-style63">OBSERVAÇÕES</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style62">
                                            <asp:TextBox ID="txtObs" runat="server" AutoCompleteType="Cellular" ForeColor="DodgerBlue" Height="193px" ReadOnly="True" TextMode="MultiLine" Width="595px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="vertical-align:top; background-color:white;">
                                <table class="auto-style64">
                                    <tr>
                                        <td class="auto-style60">Instalação</td>
                                        <td class="auto-style65">Ativado por</td>
                                        <td class="auto-style60">Ativado em</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style61">
                                            <asp:Label ID="lblInstalacao" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style66">
                                            <asp:Label ID="lblAtivadoPor" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style61">
                                            <asp:Label ID="lblAtivadoEm" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style60">Instaladora</td>
                                        <td class="auto-style65">Instalador</td>
                                        <td class="auto-style60">Data Venda</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style61">
                                            <asp:Label ID="lblInstaladora" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style66">
                                            <asp:Label ID="lblInstalador" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style61">
                                            <asp:Label ID="lblDataVenda" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style60">Confirmada em</td>
                                        <td class="auto-style65">Vendedor</td>
                                        <td class="auto-style60">Renovação até</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style61">
                                            <asp:Label ID="lblConfirmadaEm" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style66">
                                            <asp:Label ID="lblVendedor" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td class="auto-style61">
                                            <asp:Label ID="lblRenovacaoAte" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <table class="auto-style67">
                                    <tr>
                                        <td class="auto-style71">
                                            <asp:Button ID="btnIncObs" runat="server" Text="Incluir OBS" CssClass="auto-style55" Height="30px" Width="150px" OnClick="btnIncObs_Click" />
                                        </td>
                                        <td class="auto-style69" style="font-size:8px;">
                                            <asp:Button ID="btnVeiculo" runat="server" CssClass="auto-style55" Height="30px" OnClick="btnVeiculo_Click" Text="TDV" Width="150px" />
                                        </td>
                                        <td class="auto-style70" style="font-size:8px;">
                                            <asp:Button ID="btnProprietario" runat="server" CssClass="auto-style55" Height="30px" Text="TDP" Width="150px" OnClick="btnProprietario_Click" />
                                        </td>
                                        <td class="auto-style61">
                                            <asp:Button ID="btnAlterarCadastro" runat="server" Text="Alterar cadastro" CssClass="auto-style55" Height="30px" Width="150px" OnClick="btnAlterarCadastro_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style71">
                                            <asp:Button ID="btnCompras" runat="server" CssClass="auto-style55" Height="30px" Text="Compras" Width="150px" OnClick="btnCompras_Click" />
                                        </td>
                                        <td class="auto-style69" style="font-size:8px;">
                                            <asp:Button ID="btnPosFinanceira" runat="server" CssClass="auto-style55" Height="30px" Text="Pos.Financeira" Width="150px" />
                                        </td>
                                        <td class="auto-style70" style="font-size:8px;">
                                            <asp:Button ID="btnTrocarSenha" runat="server" CssClass="auto-style55" Height="30px" Text="Trocar Senha" Width="150px" />
                                        </td>
                                        <td class="auto-style61">
                                            <asp:Button ID="btnVazio" runat="server" CssClass="auto-style55" Height="30px" Text="Vazio" Width="150px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</asp:Content>
