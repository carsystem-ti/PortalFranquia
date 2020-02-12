<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Certificado.aspx.cs" Inherits="PortalFranquia.modulos.OS.Certificado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

	<title> Impressão de Contrato </title>
		
	<script language="javascript">
        function Imprimir() {
            //self.focus();
            //window.print();		    		    		    
        }
    </script>
        
	<style type="text/css">
	    .style1 {
	    }

	    .style2 {
	        width: 66px;
	    }

    </style>

    <style type="text/css">
      .folha {
            page-break-after: always;
            }
  
     .contents {
	    float: left;
	    width: 1024px;
	    background: #ffffff;
	    margin: 0 0 0 20px;
	    display: inline;
        height: 900px;
                
    }
       
 p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:12.0pt;
	font-family:"Calibri","sans-serif";
	    margin-left: 0cm;
        margin-right: 0cm;
        margin-top: 0cm;
    }
    a:link
	{color:blue;
	text-decoration:underline;
	text-underline:single;
    }
    .quebrapagina {
   page-break-before: always;
}
     .style1
        {
            width: 51%;
        }
        .style2
        {
            width: 56%;
        }
        .style3
        {
            width: 274px;
        }
        .auto-style3 {
            width: 1445px;
        }
        .auto-style4 {
            width: 690px;
            height: 25px;
        }
        .auto-style5 {
            height: 25px;
        }
        .auto-style6 {
            width: 463px;
            height: 25px;
        }
        .auto-style7 {
            width: 4px;
        }
        .auto-style8 {
            height: 25px;
            width: 4px;
        }
       
        .auto-style9 {
            width: 115px;
        }
       
        .auto-style10 {
            width: 463px;
        }
       
        .auto-style12 {
            width: 1445px;
            height: 25px;
        }
       
        .auto-style13 {
            height: 110px;
        }
       
    </style>    
    
<link href="../../css/indexx.css" rel="stylesheet" />

</head>

<body>
    <form id="form1" runat="server">
<div  style="text-align:center" class="contents">
    <div id="wrapper">
        <div id="header">
            <br />
            <br />
            <br />
            <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <div style="text-align:left ; font-size:14px;"  class="text">
                PARABÉNS! O seu veículo está protegido com o melhor e mais moderno sistema de Rastreamento. 
                <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
                <br />
                Em caso de roubo, não reaja, procure um lugar seguro e ligue para
		        <span class="green">0800-772-7271</span>
                Abaixo as informações do Plano e Cobertura.
            </div>
        </div>
    <br />
    <div id="dados">
         <table style="font-size:14px;">
             <thead>
				    <th colspan="10">Dados do contratante</th>
		     </thead>
             <tr>
                <td class="auto-style12" style="text-align:left">Nome:
                    <asp:Label ID="lblNome" runat="server" Text=""></asp:Label>
                </td>
                <td class="auto-style8"></td>
                <td class="auto-style6" style="text-align:left">CPF:
                    <asp:Label ID="lblCPF" runat="server" Text="" style="width:367px"></asp:Label>
                </td>
                <td class="auto-style4" style="text-align:left">Contrato:
                    <asp:Label ID="lblContrato" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" style="text-align:left">Endereço:
                    <asp:Label ID="lblEndereco" runat="server" Text=""></asp:Label>
                </td>
                <td class="auto-style8"></td>
                <td class="auto-style6" style="text-align:left">Cidade:
                    <asp:Label ID="lblCidade" runat="server" Text="" style="width:367px"></asp:Label>
                </td>
                <td class="auto-style5" style="text-align:left">Cep:
                    <asp:Label ID="lblCEP" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="text-align:left">Bairro:
                    <asp:Label ID="lblBairro" runat="server" Text=""></asp:Label>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style10" style="text-align:left">Telefone:
                    <asp:Label ID="lblTelefone" runat="server" Text="" style="width:367px"></asp:Label>
                </td>
                <td class="auto-style4" style="text-align:left">UF:
                    <asp:Label ID="lblUF" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="text-align:left">E-mail:
                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                </td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style10" style="text-align:left">Celular:
                    <asp:Label ID="lblCelular" runat="server" Text="" style="width:367px"></asp:Label>
                </td>
            </tr>
         </table>
    </div>
    <div id="produtos">
		    <table>
			    <thead>
					<th colspan="7">
						Produtos | Serviços | Coberturas Adicionais 
					</th>
			    </thead>
		    </table>

        <table style="font-size:14px;">
            <tr>
                <asp:GridView ID="grdProdutos" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField HeaderText="Proteção Contratada" DataField="ds_produto" AccessibleHeaderText="teste" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Cód. FIPE" DataField="id_Fipe" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Modelo" DataField="ds_modelo" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Placa" DataField="placa" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Ano" DataField="Ano" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnxFranquia %>" SelectCommand="pro_getDadosCertificadoPortal" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="lblContrato" Name="contrato" PropertyName="Text" Type="String" />
                        <asp:SessionParameter Name="usuario" SessionField="strUser" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </tr>
        </table>
        <table border="1">
            <td style="text-align:left; font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif; background-color:white" class="auto-style9">
                    Total Pedido: R$ <asp:Label ID="lblValorTotal" runat="server" Text=""></asp:Label>
            </td>
                
        </table>
    </div><!-- #produtos -->

        <div id="resumo">
            
            <table class="auto-style13" style="margin: 1px; padding: 1px;">

                    <th style="text-align:center;">
                        Resumo das principais cláusulas contratuais 
                    </th>
                    <tbody>
                        <tr>
                        <td style="padding: 1px; text-align:left; vertical-align: text-top;">
                            <asp:Label ID="lblProduto431" runat="server" Text=""></asp:Label>

                            <asp:Label ID="lblProduto429CPF" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto429CPFGuincho" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto429CPFResidencial" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto429CPFVidro" runat="server" Text=""></asp:Label>
                            <br />

                            <asp:Label ID="lblProduto429CNPJ" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto429CNPJGuincho" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto429CNPJResidencial" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto429CNPJVidro" runat="server" Text=""></asp:Label>
                            <br />

                            <asp:Label ID="lblProduto428CPF" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto428CPFGuincho" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto428CPFResidencial" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto428CPFVidro" runat="server" Text=""></asp:Label>
                            <br />
                            <asp:Label ID="lblProduto428CNPJ" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto428CNPJGuincho" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto428CNPJResidencial" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto428CNPJVidro" runat="server" Text=""></asp:Label>
                            <br />

                            <asp:Label ID="lblProdutosDiversos" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProdutosDiversosCPF" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProdutosDiversosCNPJ" runat="server" Text=""></asp:Label>
                            <br />

                            <asp:Label ID="lblProduto420422" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblProduto436437438" runat="server" Text=""></asp:Label>

                            <br />

                        </td>
                        </tr>
                    </tbody>
            </table>
        </div><!-- #resumo -->

        <br />
        <br />
        <br />
        <br />
        <br />

        <div id="footer">

	        <div class="signs">
		        <div style="float:left" class="left">
           
		        Contratante (assinatura igual ao cheque/documento)
		        </div>
                <div class="right">
           
			        Local e Data
		        </div>

                <br />
     
	        </div><!-- .signs -->

        </div><!-- #footer -->
    </div>
</div>
    </form>
</body>
</html>
