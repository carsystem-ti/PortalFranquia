<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boleto.aspx.cs" Inherits="PortalFranquia.modulos.Vendas.Bleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" style="height:100%">
    <script src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/jquery.centralize.js"></script>
    <script src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/kModal.js"></script>
    <script type="text/javascript" src="../../js/jquery.PrintArea.js"></script>
    <script type="text/javascript">
        function imprimirBoletos()
        {
            var div = "divBoleto";
            $('#' + div).printElement();
            
        }
    </script>
    <title></title>
    <style>td{margin: 0;padding: 0;border: 0;outline: 0;font-weight: inherit;font-style: inherit;font-size: 100%;font-family: inherit;vertical-align: none;background-color: white;}
corpo
{
background-color:Gray;	
}

.Pagina
{
/*position:absolute;*/
width: 921.6px;
height: auto;
background: white;
border: 1px solid;
margin: 0 auto;
}

.Cabecalho
{
position: relative;
width: 96%;
border-bottom-color:Gray;
border-bottom-style:solid;
border-bottom-width:1px;
top: -1px;
height:70px;
padding: 2%;
}
.ColunaEsquerda
{
width: 210px;
border-right-color:Gray;
border-right-style:solid;
border-right-width:1px;
height:590px;
float: left;
}
.ColunaDireita
{
width: 708px;
height:auto;
float: right;

}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divBoleto" runat="server" >
    
    </div>
    </form>
</body>
</html>
