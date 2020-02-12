<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalhesOs.aspx.cs" Inherits="PortalFranquia.modulos.OS.DetalhesOs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../css/OrdemS.css" rel="stylesheet" />
<link href="../../css/bootstrap.css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/jquery.centralize.js"></script>
    <script src="../../js/OSsAbertas.js"></script>
 

   <script type="text/javascript">
            $(document).ready(function() {
                window.prettyPrint() && prettyPrint();
               
             
            });
        </script>

</head>
<body>
    <form id="form1" runat="server">
       <div class="container">
             
             
    <div class="row">
        <div class="col-md-15">
            <div class="well well-sm">
                
                <div class="row">
                    <asp:HiddenField ID="idOSSelecionada" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="Usuario" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="Cetec" runat="server" ClientIDMode="Static" />
                    <div class="col-md-6">
                         <div class="form-group">
                             <label style="width:auto" for="subject">
                                Número de OS </label>
                                <input type="text" class="form-control" id="txtIdOs" runat="server"  placeholder="Numero OS" name="txtIdOs" />

                        </div>
                        <div class="form-group">
                             <label style="width:auto" for="subject">
                                Resolvido por </label>
                            <select  runat="server"  id="cmbID" name="cmbID"  onchange="f1()"  class="form-control">
                                <option value="0" selected="">SELECIONE</option>
                                <option value="CETEC">CETEC</option>
                                <option value="VISITA">VISITA</option>
                            </select>
                        </div>
                      <%--     <div class="form-group">
                             <label style="width:auto" for="subject">
                                Serviço executado</label>
                            <select id="subject" name="subject" class="form-control" required="required">
                                <option value="na" selected="">SUPORTE CARRO INTERNO</option>
                            </select>
                       </div>--%>
                          <div class="form-group">
                             <label runat="server" id="lblEmpresa" style="width:auto" for="subject">
                                Empresa </label>
                            
                   <asp:DropDownList ID="dropEmpresa" ClientIDMode="Static"  class="form-control" runat="server" DataTextField="ds_empresa" onchange="CarregarTecnicos()"  DataValueField="cd_empresa"></asp:DropDownList>
                     
                        </div>
                         <div class="form-group">
                             <label style="width:auto" for="subject">
                                Tecnico </label>
                            
                   <asp:DropDownList ID="dropTecnico" ClientIDMode="Static"  class="form-control" runat="server" DataTextField="ds_Instalador" DataValueField="ds_Instalador"></asp:DropDownList>
                     
                        </div>
                          
                            <div class="form-group">
                            <label for="subject">
                                Ação tomada</label>
                            <asp:DropDownList ID="dropAcaoOs"  class="form-control" runat="server" DataTextField="ds_os" DataValueField="ds_os"></asp:DropDownList>
                        </div>
                         <div class="form-group">
                             <label style="width:auto" for="subject">
                                Motivo Atendimento </label>
                            <asp:DropDownList ID="dropMotivosAtendimento"  ClientIDMode="Static" class="form-control" onchange="CarregarDetalhes()"  runat="server" DataTextField="ds_Procedimento" DataValueField="cd_Procedimento"></asp:DropDownList>
   
              </div>
                         <div class="form-group">
                             <label style="width:auto" for="subject">
                                Detalhes Motivos </label>
              
                            <asp:DropDownList ID="dropDetalhesMotivos"   class="form-control" runat="server" DataValueField="Id" DataTextField="ds_descricao"  ClientIDMode="Static"></asp:DropDownList>
           
                        </div>
                         <%-- <div class="form-group">
                            <label style="width:auto" for="subject">
                                Problema resolvido</label>
                       
                        </div>--%>
                    </div>
                    <div class="col-md-6">
                          <div class="form-group">
                             <label style="width:auto" for="subject">
                               Problema Resolvido </label>
                            <select  runat="server"  id="slcResolvido" name="slcResolvido"    class="form-control">
                                <option value="0" selected="">SELECIONE</option>
                                <option value="S">SIM</option>
                                <option value="N">NÃO</option>
                            </select>
                        </div>
                        <div class="form-group">
                             <label style="width:auto" for="subject">
                              TROCOU PEÇA </label>
                            <select  runat="server"  id="slcpeca" name="slcpeca"   class="form-control">
                                <option value="0" selected="">SELECIONE</option>
                                <option value="S">SIM</option>
                                <option value="N">NÃO</option>
                            </select>
                        </div>
                        
                        
                        
                        
                        <div class="form-group">
                            <label for="name">
                                Medidas adotadas</label>
                            <textarea name="message" id="message" class="form-control" rows="9" cols="25"
                                placeholder="Message"></textarea>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <button type="submit" name="btnEncerrarOs"  class="btn btn-primary pull-right" id="btnEncerrarOs">
                            Encerrar Os</button>
                        
                    </div>
                </div>
              
            </div>
        </div>
    </div>
</div>


    </form>
</body>
</html>
