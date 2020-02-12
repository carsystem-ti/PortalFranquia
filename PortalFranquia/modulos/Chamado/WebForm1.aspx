<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PortalFranquia.modulos.Chamados.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <script src="../../js/MaxLength.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //Configuração Normal 
            $("[id*=TextBox1]").MaxLength({ MaxLength: 10 });

            //Especificando o controle de contagem de caráter explicitamente
            $("[id*=TextBox2]").MaxLength(
            {
                MaxLength: 15,
              //  CharacterCountControl: $('#counter')
            });

            //Desativar a Contagem de Caracteres
            $("[id*=TextBox3]").MaxLength(
            {
                MaxLength: 20,
                DisplayCharacterCount: false
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">Máximo de 10 caracteres <br />
    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="300" Height="100"></asp:TextBox>
   
    <br />
    <div id="counter">
    </div>Especificando o controle de contagem de caráter explicitamente para 15.<br />
    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="300" Height="100"
        Text="XanBurzun"></asp:TextBox>
    
    <br />
    Desativar a Contagem de Caracteres e no máximo de 20 caracteres<br />
    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Width="300" Height="100"></asp:TextBox>
    
    </form>
</body>
</html>
