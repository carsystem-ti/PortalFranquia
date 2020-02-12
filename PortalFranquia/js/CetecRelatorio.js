$(window).load(function () {
    retornaRelatorio();
});

function retornaRelatorio() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaRelatorioCetec',
        dataType: "json",
        contentType: "application/json",
        data: "{ numeroOs: " + window.opener.IntLanRelatorio + " }",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            montaRelatorio(retorno);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function montaRelatorio(retorno) {
    var tabela = "<table width=700px border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td align=left>" +
        "<input type='image' src='../../imagens/logo.bmp' id=image1 name=image1>" +
        "</td>" +
        "<td width=180 align=center>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<strong>Ordem de Serviço</strong> <br>" +
        retorno.ControleOs +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=100% align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<hr></hr>" +
        "</font>" +
        "</td>" +
        "</table>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=180 align=right>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "Pedido :&nbsp;&nbsp;" +
        "</font>" +
        "</td>" +
        "<td width=60>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        retorno.Pedido +
        "</font>" +
        "</td>" +
        "<td width=100 align=right>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "Cliente :&nbsp;&nbsp;" +
        "</font>" +
        "</td>" +
        "<td>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        retorno.Nome +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=100% align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<hr></hr>" +
        "</font>" +
        "</td>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=400 align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Endereço do cliente</strong>" +
        "</font><br><br>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        retorno.EnderecoCliente + "," + retorno.Numero +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        retorno.Complemento +
        "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        retorno.Bairro + "/" + retorno.Cidade +
        "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        retorno.Cep + "-" + retorno.Uf +
        "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ponto de referência : <br>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        retorno.PontoReferencia +
        "<br><br></font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=180 align=right>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "Telefone :&nbsp;&nbsp;" +
        "</font>" +
        "</td>" +
        "<td width=225>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        retorno.Telefone +
        "</font>" +
        "</td>" +
        "<td width=180 align=right>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "Celular :&nbsp;&nbsp;" +
        "</font>" +
        "</td>" +
        "<td width=225>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        retorno.Celular +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=100% align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<hr></hr>" +
        "</font>" +
        "</td>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=400 align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Endereço da instalação e ou suporte</strong>" +
        "</font><br><br>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        retorno.EnderecoChamado + "," + retorno.NumeroChamado +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        retorno.Regiao +
        "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        retorno.BairroChamado + "/" + retorno.CidadeChamado +
        "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        retorno.EstadoChamado +
        "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ponto de referência : <br>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        retorno.ReferenciaChamado +
        "<br><br>" +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=180 align=right>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "Telefone :&nbsp;&nbsp;" +
        "</font>" +
        "</td>" +
        "<td width=225>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        retorno.FoneChamado +
        "</font>" +
        "</td>" +
        "<td width=180 align=right>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "&nbsp;&nbsp;" +
        "</font>" +
        "</td>" +
        "<td width=225>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "&nbsp;&nbsp;" +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=100% align=left>" +
        " <font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<hr></hr>" +
        "</font>" +
        "</td>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=400 align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dados do veículo</strong>" +
        " </font><br><br>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
        retorno.TipoVeiculo + " - " + retorno.Modelo + "&nbsp;" + retorno.Cor + "&nbsp;" + retorno.Ano
        + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<STRONG>" + retorno.Placa + "</STRONG><br><br>" +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=180 align=right>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "Combustível :&nbsp;&nbsp;" +
        "</font>" +
        "</td>" +
        "<td width=225>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        retorno.Combustivel +
        "</font>" +
        "</td>" +
        "<td width=180 align=right>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "Série :&nbsp;&nbsp;" +
        "</font>" +
        "</td>" +
        "<td width=225>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        retorno.NumeroSerie +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=180 align=right>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "Renavam :&nbsp;&nbsp;" +
        "</font>" +
        "</td>" +
        "<td width=225>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        retorno.Renavam +
        "</font>" +
        "</td>" +
        "<td width=180 align=right>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "Chassi :&nbsp;&nbsp;" +
        "</font>" +
        "</td>" +
        "<td width=225>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        retorno.Chassi +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=100% align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<hr></hr>" +
        "</font>" +
        "</td>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=400 align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Produto</strong>" +
        "</font><br><br>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "&nbsp;&nbsp;&nbsp;" + retorno.Produto + "&nbsp;&nbsp;&nbsp;VERSÃO:&nbsp;" + retorno.Versao + "&nbsp;&nbsp;&nbsp;ID ATUAL:&nbsp;" + retorno.Peca + "<br>" +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% border=0 cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=100% align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<hr></hr>" +
        "</font>" +
        "</td>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=400 align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dados do chamado</strong>" +
        "</font><br><br>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Aberta em&nbsp;" + retorno.AbertaEm + " às " + retorno.AbertaAs + "("+ retorno.ChamadoDe + ")<br>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Prevista para&nbsp;" + retorno.VisitaMarcada.substr(0, 10) + " às " + retorno.HoraMarcada.substr(11, 8) + "<br><br>" +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td width=400 align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Informações úteis</strong>" +
        "</font><br><br>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + retorno.InformacoesChamado + "<br><br><br>" +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "<table width=100% cellspacing=0 cellpadding=0 align=center>" +
        "<tr>" +
        "<td align=left>" +
        "<font face='Verdana, Arial, Helvetica, sans-serif' size='2'>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Estou ciente de que o problema foi solucionado que o sistema e o veículo estão em perfeito funcionamento, sendo que acompanhei o teste do veículo e do sistema.<br><br>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_______________________________________<br><br>" +
        "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;____/____/_______" +
        "</font>" +
        "</td>" +
        "</tr>" +
        "</table>" +
        "</td>" +
        "</tr>" +
        "</table>";
    $("#relatorio").html(tabela);
}