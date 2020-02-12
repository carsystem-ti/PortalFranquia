<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EncerrarOs.ascx.cs" Inherits="PortalFranquia.componentes.OS.EncerrarOs" %>
<link href="../../css/OrdemS.css" rel="stylesheet" />
<link href="../../css/bootstrap.css" rel="stylesheet" />
<script src="../../js/jquery.min.js"></script>
<script src="../../js/jquery.centralize.js"></script>
<script src="../../js/OSsAbertas.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
    #messageos {
        resize: none;
        /* impede que o próprio usuário altere o tamanho do textarea */
        width: 418px;
        height: 100px;
        overflow-y: auto;
    }

    #message {
        resize: none;
        /* impede que o próprio usuário altere o tamanho do textarea */
        width: 418px;
        height: 120px;
        overflow-y: auto;
    }
</style>

<script type="text/javascript">
    $(document).ready(function () {
       // window.prettyPrint() && prettyPrint();


    });
        </script>


<div class="container">
    <div class="row">
        <div class="col-md-15">
            <div class="well well-sm">
                <form>
                    <div class="row">
                        <asp:HiddenField ID="idOSSelecionada" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="Usuario" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="Cetec" runat="server" ClientIDMode="Static" />
                    
                        <div class="col-md-6">
                            <div class="form-group">
                                <label style="width: auto" for="subject">
                                    Número de OS
                                </label>
                                <input type="text" class="form-control" id="txtIdOs"  placeholder="Numero OS" name="txtIdOs">
                            </div>
                              <div class="form-group">
                                <label style="width: auto" for="subject">
                                    Número Peça
                                </label>
                                <input type="text" class="form-control" id="txtUltimoId" readonly="readonly"  placeholder="Numero Peça" name="txtUltimoId">
                            </div>
                            <div class="form-group">
                                <label style="width: auto" for="subject">
                                    Resolvido por
                                </label>
                                <select runat="server" id="cmbID" name="cmbID" onchange="f1()" class="form-control">
                                    <option value="0" selected="">SELECIONE</option>
                                    <option value="CETEC">CETEC</option>
                                    <option value="VISITA">VISITA</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <label style="width: auto" for="subject">
                                    Tecnico
                                </label>

                                <asp:DropDownList ID="dropTecnico" ClientIDMode="Static" class="form-control" runat="server" DataTextField="ds_Instalador" DataValueField="ds_Instalador"></asp:DropDownList>

                            </div>

                            <div class="form-group">
                                <label for="subject">
                                    Ação tomada</label>
                                <asp:DropDownList ID="dropAcaoOs" class="form-control" runat="server" DataTextField="ds_os" DataValueField="ds_os"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label id="motivoate" style="width: auto" for="subject">
                                    Motivo Atendimento
                                </label>
                                <asp:DropDownList ID="dropMotivosAtendimento" ClientIDMode="Static" class="form-control" onchange="CarregarDetalhes()" runat="server" DataTextField="ds_Procedimento" DataValueField="cd_Procedimento"></asp:DropDownList>

                            </div>
                            <div class="form-group">
                                <label id="detmotivo" style="width: auto" for="subject">
                                    Detalhes Motivos
                                </label>

                                <asp:DropDownList ID="dropDetalhesMotivos" class="form-control" onchange="GravaItens()" runat="server" DataValueField="Id" DataTextField="ds_descricao" ClientIDMode="Static"></asp:DropDownList><br />
                                <button id="btnEcluir" name="btnEcluir" class="btn btn-xs btn-danger" style="min-width: 70px;">
                                    <span class=" glyphicon glyphicon-trash "></span>&nbsp;Excluir Motivo
                                </button>
                                <button id="btnteste" name="btnteste" class="btn btn-xs btn-danger" style="min-width: 70px;">
                                    <span class=" glyphicon glyphicon-trash "></span>&nbsp;Excluir Motivo
                                </button>
                            </div>


                            <%-- <div class="form-group">
                            <label style="width:auto" for="subject">
                                Problema resolvido</label>
                       
                        </div>--%>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="name">
                                    Detalhes Os</label>
                                <textarea name="messageos" id="messageos" class="form-control"
                                    placeholder="Message"></textarea>

                            </div>
                            <div class="form-group">
                                <label style="width: auto" for="subject">
                                    Problema Resolvido
                                </label>
                                <select runat="server" id="slcResolvido" name="slcResolvido" class="form-control">
                                    <option value="0" selected="">SELECIONE</option>
                                    <option value="S">SIM</option>
                                    <option value="N">NÃO</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <label style="width: auto" for="subject">
                                    TROCOU PEÇA
                                </label>
                                <select runat="server" id="slcpeca" name="slcpeca" class="form-control">
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
                            <button type="submit" name="btnEncerrarOs" class="btn btn-primary pull-right" id="btnEncerrarOs">
                                Encerrar Os</button>

                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

