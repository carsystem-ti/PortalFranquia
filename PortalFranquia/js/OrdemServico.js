$(window).load(function () {
    Avisos();
});

$(document).ready(function () {
    $('#Pesquisar').on('click', function () { retornaDadosCliente(); });
    $('#txtcep').mask('00000-000');
    $('#telefone').mask('(99)9999-9999');
});

function retornaRevisao(revisao) {
    window.Revisao = revisao;
}

function retornaVistoria(vistoria) {
    window.Vistoria = vistoria;
}

function retornaChamado(chamado) {
    window.Chamado = chamado;
}

function retornaAcoes(acoes) {
    window.Acoes = acoes;
}

function retornaServicos(servicos) {
    window.Servicos = servicos;
}

function retornaCodigoProcedimento(codigo) {
    window.codigoProcedimento = codigo;
}

function retornaProcedimento(procedimento) {
    window.Procedimento = procedimento;
}

function retornaProcedimentoItens(procedimentoItens) {
    window.ProcedimentoItens = procedimentoItens;
}

function retornaStatusOs(status) {
    window.StatusOsComp = status;
}

function retornaEnderecoLoja(retorno) {
    window.EnderecoLoja = retorno;
}

function retornaOrdemServico(contrato, equipamento, statusEquipamento, tipoVeiculo) {
    window.Contrato = contrato;
    window.Equipamento = equipamento;
    window.StatusEquipamento = statusEquipamento;
    window.TipoVeiculo = tipoVeiculo;
}

function retornaStatus(atendimento, os, venda) {
    window.StatusAtendimento = atendimento.toUpperCase();
    window.StatusOsCliente = os.toUpperCase();
    window.StatusVenda = venda.toUpperCase();
}

function retornaNumeroEncerramento(numeroEncerramento) {
    window.NumeroEncerramento = numeroEncerramento;
}

function retornaListaOs(retorno) {
    window.Retorno = retorno;
}

function retornaKilometragem(retorno) {
    window.Km = retorno;
}

function retornaIntLan(intLan) {
    window.IntLan = intLan;
}

function retornaIntLanRelatorio(intLan) {
    window.IntLanRelatorio = intLan;
}

function retornaInstaladoras(instaladoras) {
    window.Instaladoras = instaladoras;
}

function retornaInstalador(instaladores) {
    window.Instaladores = instaladores;
}

function retornaCodigoEmpresa(empresa) {
    window.codigoEmpresa = empresa;
}

function retornaEquipamento(equipamento) {
    window.TipoEquipamento = equipamento;
}

function limpaDiv() {
    //$("#contrato").empty();
    $("#tabela").empty();
    $("#ordemServico").empty();
    $("#abrirOs").empty();
}

function AbrirOs() {
    retornaTipoChamado();
    //retornaKm2();
    TabelaAbrirOs();
    retornaUsuarioValidado();
}

function AlterarOs() {
    retornaTipoChamado();
    TelaAlterarOs();
}

function retornaInstaladora() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaEmpresa',
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            montaSelectInstaladora(retorno);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function montaSelectInstaladora(retorno) {
    var select = "<select id='instaladora'>";
    for (var i = 0; i < retorno.length; i++) {
        select += "<option value=" + retorno[i].CodigoEmpresa + ">" + retorno[i].NomeEmpresa + "</option>";
    }
    select += "</select>";
    retornaInstaladoras(select);
}

function retornaInstalador() {
    var codigo = $("#instaladora option:selected").val();
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaInstaladores',
        dataType: "json",
        contentType: "application/json",
        data:
            "{ codigoEmpresa: " + codigo + " }",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            var lista = montaSelectInstalador(retorno);
            $('#instalador').remove();
            $('#empresa').after(lista);

            $("#message").val('TESTE');


        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function montaSelectInstalador(retorno) {
    var select = "<td id='instalador'><select>";
    for (var i = 0; i < retorno.length; i++) {
        select += "<option value=" + retorno[i] + ">" + retorno[i] + "</option>";
    }
    select += "</select></td>";
    //retornaInstalador(select);
    return select;
}

function Voucher() {
    var numeroOs = IntLan;
    var voucher = $("#voucher").val();
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/DefineVoucher',
        dataType: "json",
        contentType: "application/json",
        data: "{ numeroOs: " + numeroOs + " , numeroVoucher: " + voucher + "}",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            alert(retorno[0].Retorno);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function retornaUsuarioValidado() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaUsuarioValidado',
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            if (retorno.CepPrestadora !== null) {
                retornaEndereco(retorno.CepPrestadora);
            }
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function retornaDadosCliente(contrato) {
    var ordemServico = {};
    ordemServico.Contrato = $("#ContentPlaceHolder1_contrato").val();
    ordemServico.Placa = $("#ContentPlaceHolder1_placa").val();
    ordemServico.Documento = $("#cpfcnpj").val();

    if (contrato !== undefined) {
        ordemServico.Contrato = contrato;
    }

    var dto = { 'ordem': ordemServico };
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaOs',
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(dto),
        success: function (response) {
            var retorno = JSON.parse(response.d);
            limpaDiv();
            if (retorno.length === 1) {
                tabelaClienteDados(retorno[0]);
                retornaOrdemServico(retorno[0].Contrato, retorno[0].Equipamento, retorno[0].StatusEquipamento, retorno[0].TipoVeiculo);
            }
            else if (retorno.length >= 1) {
                var linhas = "";
                var linha;
                for (var i = 0; i < retorno.length; i++) {
                    var valor = retorno[i];
                    linha = contratosEncontrados(valor);
                    linhas += linha;
                }
                tabelaContratosEncontrados(linhas);
            }
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });

}

function retornaOs() {
    var idContrato = Contrato;
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaOrdemServico',
        dataType: "json",
        contentType: "application/json",
        data:
            "{ contrato: " + idContrato + " }",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            if (retorno.length > 0) {
                retornaListaOs(retorno);
                retornaKm(retorno, idContrato);
                retornaInstaladora();

            } else {
                retornaKm2();
                retornaInstaladora();
                retornaTabelaOsVazia();
            }
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function retornaKm(retorno, idContrato) {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaDistanciaKm',
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            var km = JSON.parse(response.d);
            km = montaSelectKm(km);
            retornaKilometragem(km);
            retornaTabelaOs(retorno, idContrato, 0, km);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function retornaKm2() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaDistanciaKm',
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            var km = JSON.parse(response.d);
            km = montaSelectKm(km);
            retornaKilometragem(km);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function montaSelectKm(retorno) {
    var select = "<select id='distanciaKm' ><option value='0'></option>";
    for (var i = 0; i < retorno.length; i++) {
        select += "<option value=" + retorno[i].CodigoCidade + ">" + retorno[i].DescricaoCidade + "</option>";
    }
    select += "</select>";
    return select;
}

function retornaTipoServicos() {
    var chamado = $("#tipoChamado option:selected").val();
    var resolvido = $("#resolvidoPor option:selected").text();
    if (resolvido === "") {
        resolvido = "CETEC";
    }
    var equipamento = Equipamento.substr(0, 10);
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaTipoServicos',
        dataType: "json",
        contentType: "application/json",
        data: "{ produto: '" + chamado + "',grupo: '" + equipamento + "',local: '" + resolvido + "',tipoVeiculo: '" + TipoVeiculo + "'}",
        async: false,
        success: function (response) {
            var tipoServico = JSON.parse(response.d);
            montaSelectServicos(tipoServico);
            //$('#tabela5 > tbody > tr').eq(3).after(selectServicos);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function retornaProcedimentos() {
    var chamado = $("#tipoChamado option:selected").text();
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaProcedimentoServico',
        dataType: "json",
        contentType: "application/json",
        data: "{ servico: '" + chamado + "'}",
        async: false,
        success: function (response) {
            var tipoProcedimento = JSON.parse(response.d);
            montaSelectProcedimento(tipoProcedimento);
            retornaCodigoProcedimento(tipoProcedimento[0]);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function montaSelectProcedimento(tipoProcedimento) {
    var select = "<select id='procedimento' onchange='retornaProcedimentosItens()'>";
    for (var i = 0; i < tipoProcedimento.length; i++) {
        select += "<option value=" + tipoProcedimento[i].Codigo + ">" + tipoProcedimento[i].Descricao + "</option>";
    }
    select += "</select>";
    retornaProcedimento(select);
    return select;
}

function retornaProcedimentosItens(tipoProcedimento) {
    var chamado = $("#procedimento option:selected").val();
    if (chamado === undefined) {
        chamado = tipoProcedimento.Codigo;
    }
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaProcedimentoServicoItens',
        dataType: "json",
        contentType: "application/json",
        data: "{ codigoProcedimento: '" + chamado + "'}",
        async: false,
        success: function (response) {
            var procedimentoItens = JSON.parse(response.d);
            montaCheckBoxProcedimentoItens(procedimentoItens);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function montaCheckBoxProcedimentoItens(procedimentoItens) {
    var checkbox = "";
    for (var i = 0; i < procedimentoItens.length; i++) {
        checkbox += "<label><input type='checkbox' name='procedimentoItens' value=" + procedimentoItens[i].Codigo + ">" + procedimentoItens[i].Descricao + "</label></br>";
    }
    retornaProcedimentoItens(checkbox);
    return checkbox;
}

function salvaProcedimentoItens() {
    var itens = $("input[name=procedimentoItens]:checked").map(function () { return this.value; }).get().join(",");
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/GravaEncerramentoItem',
        dataType: "json",
        contentType: "application/json",
        data: "{ itens: '" + itens + "', intLan: " + IntLan + "}",
        async: false,
        success: function (response) {
            var procedimentoItens = JSON.parse(response.d);
            montaCheckBoxProcedimentoItens(procedimentoItens);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function retornaTabelaOsVazia() {
    var linhaTitulo = ("</br><button id='trigger' type='button' class='btn-primary' onclick='ocultaDiv(\"" + '#tabela2' + "\");' >Ordem de serviço</button><table id=tabela2 class='TableOs text'>" +
      "<thead>" +
          "<tr>" +
              "<th>Ordem de Serviço</th>" +
          "</tr>" +
      "</thead>" +
      "<tbody>" +
          "<tr>" +
              "<td>Este Contrato não possui Ordem de Serviço.</td>" +
          "</tr>" +
          "<tr>" +
        "<td><button id='trigger' type='button' class='btn-primary' onclick='AbrirOs();' >Abrir OS</button></td>" +
        "</tr>");
    $("#ordemServico").html(linhaTitulo);
}

function retornaTabelaEncerramento() {
    var retorno = "<tr><th>Encerramento da OS</th></tr>" +
        "<tr>" +
        "<th>Resolvido por</th>" +
        "<th>Medidas adotadas</th>" +
        "</tr>" +
        "<tr>" +
        "<td>" +
        "<select id='resolvidoPor' onchange=''>" +
        "<option value=''>CETEC</option>" +
        "<option value=''>VISITA</option>" +
        "</select>" +
        "</td>" +
        "<td><textarea id='medidas' cols='40' rows='5' ></textarea></td>" +
        "</tr>" +
        "<tr>" +
        "<th>Serviço executado</th>" +
        "<th>Ação tomada</th>" +
        "</tr>" +
        "<tr>" +
        Servicos +
        Acoes
        +
        "</tr>" +
        "<tr>" +
        "<th>Problema resolvido</th>" +
        "</tr>" +
        "<tr>" +
        "<td>" +
        montaSelectResolvido() +
        "</td>" +

        "</tr>" +
        "<tr>" +
        "<th>Procedimento</th>" +
        "<th>Itens do Procedimento</th>" +
        "</tr>" +
        "<tr>" +
        "<td>" +
        Procedimento +
        "</td>" +
        "<td>" +
        ProcedimentoItens +
        "<button id='salvarProcedimento' type='button' class='btn-primary' onclick='salvaProcedimentoItens();' >Salvar</button>" +
        "</td></tr>" +
        "<tr>" +
        "<th>Trocou equipamento</th>" +
        "<th>Informe o novo equipamento</th>" +
        "</tr>" +
        "<tr>" +
        "<td>" +
        "<select id='trocarEquipamento'>" +
        "<option value='0'>Sim</option>" +
        "<option value='1'>Não</option>" +
        "</select>" +
        "</td>" +
        "<td>" +
        TipoEquipamento +
        "</td>" +
        "</tr>";
    $('#tabela5 > tbody > tr').eq(7).after(retorno);
}

function retornaTipoEquipamento() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaEquipamento',
        dataType: "json",
        contentType: "application/json",
        async: false,
        success: function (response) {
            var equipamento = JSON.parse(response.d);
            montaSelectEquipamento(equipamento);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function montaSelectEquipamento(equipamento) {
    var select = "<select id='tipoEquipamento'>";
    for (var i = 0; i < equipamento.length; i++) {
        select += "<option value=" + i + ">" + equipamento[i] + "</option>";
    }
    select += "</select>";
    retornaEquipamento(select);
    return select;
}

function retornaTipoCancelamento() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaTipoCancelamento',
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            var cancelamento = JSON.parse(response.d);
            var selectCancelamento = montaSelectCancelamento(cancelamento);
            $('#tabela5 > tbody > tr').eq(8).before(selectCancelamento);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function montaSelectCancelamento(cancelamento) {
    var select = "<tr><th colspan='2'>Motivo do cancelamento</th></tr><tr><td colspan='2'><select id='cancelamento'>";
    for (var i = 0; i < cancelamento.length; i++) {
        select += "<option value=" + cancelamento[i].Codigo + ">" + cancelamento[i].Descricao + "</option>";
    }
    select += "</select></td></tr>";
    return select;
}

function retornaTipoAcoes() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaTipoAcoes',
        dataType: "json",
        contentType: "application/json",
        async: false,
        success: function (response) {
            var tipoAcoes = JSON.parse(response.d);
            montaSelectAcoes(tipoAcoes);
            //var selectAcoes = montaSelectAcoes(tipoAcoes);
            //$('#tabela5 > tbody > tr').eq(11).after(selectAcoes);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function montaSelectAcoes(tipoAcoes) {
    var select = "<td><select id='tipoAcoes'>";
    for (var i = 0; i < tipoAcoes.length; i++) {
        select += "<option value=" + tipoAcoes[i] + ">" + tipoAcoes[i] + "</option>";
    }
    select += "</select></td>";
    retornaAcoes(select);
    return select;
}

function montaSelectServicos(tipoServico) {
    var select = "<td><select id='tipoServicos'>";
    for (var i = 0; i < tipoServico.length; i++) {
        select += "<option value=" + tipoServico[i].Codigo + ">" + tipoServico[i].Descricao + "</option>";
    }
    select += "</select></td>";
    retornaServicos(select);
    return select;
}

function montaSelectResolvido() {
    var select = "<select id='resolvido'>" +
        "<option value='S'>Serviço sem cobrança</option>" +
        "<option value='IC'>Serviço isento Carsystem</option>" +
        "<option value='IF'>Serviço isento franquia</option>" +
        "</select>";
    return select;
}

function TelaStatusOs() {
    var status = $("#statusOs option:selected").text();
    if (status === "Cancelada") {
        limpaLinhaTr(8);
        //$('#tabela5 > tbody > tr').eq(8).after().empty();
        retornaTipoCancelamento();
    }
    else if (status === "Encerrada") {
        //$('#tabela5 > tbody > tr').eq(8).after().empty();
        limpaLinhaTr(8);
        retornaTipoEquipamento();
        retornaTipoAcoes();
        retornaTipoServicos();
        retornaProcedimentos();
        retornaProcedimentosItens(codigoProcedimento);
        retornaTabelaEncerramento();
    }

}

function TelaAlterarOs() {
    var linhaTitulo1 = ("</br><button id='trigger' type='button' class='btn-primary' onclick='ocultaDiv(\"" + '#tabela5' + "\");' >Alteração de Ordem de Serviço</button><table id=tabela5 class='TableOs text'>" +
        "<thead>" +
        "<tr>" +
        "<th>Alteração de Ordem de Serviço</th>" +
        "</tr>" +
        "</thead>" +
        "<tbody>");

    var linhaTitulo5 = "<tr>" +
        "<th>Status da OS</th>" +
        "<th>Chamado de OS</th>" +
        "</tr>";

    var linha5 = "<tr>" +
        "<td>" +
        "<select id='statusOs' onchange='TelaStatusOs()'>" +
        "<option value='0'>Aberta</option>" +
        "<option value='4'>Atendendo</option>" +
        "<option value='2'>Cancelada</option>" +
        "<option value='1'>Encerrada</option>" +
        "</select></td>" +
        "<td>" +
        Chamado +
        "</td>" +
        "</tr>";

    var linhaTitulo6 = "<tr>" +
        "<th colspan='2'>Informações do chamado</th>" +
        "</tr>";

    var linha6 = "<tr>" +
        "<td colspan='2'><textarea id='informacoes' cols='40' rows='5' ></textarea></td>" +
        "</tr>";

    var linhaTitulo7 = "<tr>" +
        "<th>Instaladora</th>" +
        "<th>Instalador</th>" +
        "</tr>";

    var linha7 = "<tr>" +
        "<td id='empresa'>" + Instaladoras + "<input type='button' id='instaladores' name='instaladores' value='Instaladores' class='btn-primary' onclick='retornaInstalador();'/></td>" +
        "</tr>";

    var linhaTitulo8 = "<tr>" +
        "<th colspan='2'>Voucher</th>" +
        "</tr>";

    var linha8 = "<tr>" +
        "<td><input type='text' id='voucher' name='voucher'/></td>" +
        "<td><input type='button' id='veficar' name='verificar' value='Verificar' class='btn-primary' onclick='Voucher();'/></td>" +
        "</tr>";

    var botao = "<tr><td colspan='2'><input type='button' value='Gravar' class='btn-primary' onclick='GravarOs(1);'/></td></tr>";
    $("#abrirOs").html(linhaTitulo1 + linhaTitulo5 + linha5 + linhaTitulo6 + linha6 + linhaTitulo7 + linha7 + linhaTitulo8 + linha8 + botao);
}


function TabelaAbrirOs() {

    var linhaTitulo1 = ("</br><button id='trigger' type='button' class='btn-primary' onclick='ocultaDiv(\"" + '#tabela1' + "\");' >Abertura de Ordem de Serviço</button><table id=tabela1 class='TableOs text'>" +
        "<thead>" +
        "<tr>" +
        "<th>Abertura de Ordem de Serviço</th>" +
        "</tr>" +
        "</thead>" +
        "<tbody>");
    //"<tr>" +
    //    "<th>Contrato</th>" +
    //    "<th>Nome</th>" +
    //    "<th>Veículo</th>" +
    //    "<th>Placa</th>" +
    //    "<th>Id Atual</th>" +
    //"</tr>");

    //var linha1 = "<tr>"
    //+ "<td>Contrato</td>"
    //+ "<td>Nome</td>"
    //+ "<td>Veículo</td>"
    //+ "<td>Placa</td>"
    //+ "<td>Id Atual</td>"
    //+ "</tr>"
    //;

    //var linhaTitulo2 = "<tr>" +
    //    "<th colspan='5'></th>" +
    //    "</tr>";

    //var linha2 = "<tr>"
    //+ "<td colspan='3'><label>CEP</label><input type='text' name='txtcep' id='txtcep'/>" +
    //        "<input type='button' name='txtcep' id='txtcep' class='btn-primary' value='Buscar' onclick='retornaEndereco();' /></td>"
    //+ "<td colspan='2'></td>"

    //;

    //var linhaTitulo3 = "<tr>" +
    //        "<th>Telefone</th>" +
    //        "<th>Região</th>" +
    //        "<th colspan='3'>Ponto de Referência</th>" +
    //    "</tr>";

    //var linha3 = "<tr>"
    //+ "<td><input type='text' name='telefone' id='telefone' readonly/></td>"
    //+ "<td><input type='text' name='regiao' id='regiao'/></td>"
    //+ "<td colspan='3'><input type='text' id='referencia' name='referencia'/></td>"
    //+ "<tr>";

    var linhaTitulo4 = "<tr>" +
        "<th>Status da OS</th>" +
        "<th>Chamado de OS</th>" +
        "</tr>"
    ;

    var linha4 = "<tr>" +
        "<td>" +
        "<select id='statusOs'>" +
        "<option value='0'>Aberta</option>" +
        "</select></td>" +
        "<td>" +
        Chamado +
        "</td>" +
        "</tr>"
    ;

    var linhaTitulo5 = "<tr>" +
        "<th>Data da visita</th>" +
        "<th>Hora da visita</th>" +
        "</tr>";
    var linha5 = "<tr>" +
        "<td><input type='date' id='dataVisita' name='dataVisita'/></td>" +
        "<td><input type='time' id='horaVisita' name='horaVisita'/></td>" +
        "</tr>";


    var agora = new Date();
    var mes = (agora.getMonth() + 1);
    var dia = agora.getDate();
    if (mes < 10)
        mes = "0" + mes;
    if (dia < 10)
        dia = "0" + dia;
    var hoje = agora.getFullYear() + "-" + mes + "-" + dia;

    var hora = agora.getHours();
    var minuto = agora.getMinutes();
    var horario = hora + ":" + minuto;

    var linhaTitulo6 = "<tr>" +
        "<th colspan='2'>Informações do chamado</th>" +
        "</tr>";

    var linha6 = "<tr>" +
        "<td colspan='2'><textarea id='informacoes' cols='40' rows='5'></textarea></td>" +
        "</tr>";

    var linhaTitulo7 = "<tr>" +
        "<th colspan='2'>Se houver KM, favor selecionar o destino e a partida</th>" +
        "</tr>";

    var linha7 = "<tr>" +
        "<td colspan='2'>" + Km + "</td>" +
        "</tr>";

    var linhaTitulo8 = "<tr>" +
        "<th>Instaladora</th>" +
        "<th>Instalador</th>" +
        "</tr>";

    var linha8 = "<tr>" +
        "<td id='empresa'>" + Instaladoras + "<input type='button' id='instaladores' name='instaladores' value='Instaladores' class='btn-primary' onclick='retornaInstalador();'/></td>" +
        "</tr>";

    var linhaTitulo9 = "<tr>" +
        "<th colspan='2'>Voucher</th>" +
        "</tr>";

    var linha9 = "<tr>" +
        "<td colspan='2'><input type='text' id='voucher' name='voucher'/><input type='button' id='veficar' name='verificar' value='Verificar' class='btn-primary' onclick='Voucher();'/></td>" +

        "</tr>";

    var botao = "<tr><td colspan='2'><input type='button' value='Gravar' class='btn-primary' onclick='GravarOs(0);'/></td></tr>";
    $("#abrirOs").html(linhaTitulo1 + linhaTitulo4 + linha4 + linhaTitulo5 + linha5 + linhaTitulo6 + linha6 + linhaTitulo7 + linha7 + linhaTitulo8 + linha8 + linhaTitulo9 + linha9 + botao);
    $('#dataVisita').val(hoje);
    $("#horaVisita").val(horario);
    $('#dataVisita').attr({ "min": hoje });
}

function retornaTipoChamado() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaTipoChamado',
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: "{status:'" + StatusOsCliente + "'}",
        success: function (response) {
            var tipoChamado = JSON.parse(response.d);
            retornaOsRevisao();
            retornaUltimaVistoria();
            montaSelectChamado(tipoChamado, Revisao, Vistoria);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function retornaOsRevisao() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/ValidaOsRevisao',
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: "{contrato:'" + Contrato + "'}",
        success: function (response) {
            var osRevisao = JSON.parse(response.d);
            retornaRevisao(osRevisao);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function retornaUltimaVistoria() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaUltimaVistoria',
        dataType: "json",
        contentType: "application/json",
        async: false,
        data: "{contrato:'" + Contrato + "'}",
        success: function (response) {
            var ultimaVistoria = JSON.parse(response.d);
            retornaVistoria(ultimaVistoria);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function montaSelectChamado(tipoChamado, resultado, vistoria) {
    var select = "<select id='tipoChamado' onchange='TelaStatusOs()'>";
    for (var i = 0; i < tipoChamado.length; i++) {
        if (tipoChamado[i].Codigo >= 1 && tipoChamado[i].Codigo <= 9 || tipoChamado[i].Codigo === "12") {
            select += "<option value=" + tipoChamado[i].Codigo + ">" + tipoChamado[i].Descricao + "</option>";
        }
        else if (tipoChamado[i].Codigo === "10" && Equipamento.indexOf("PLUS") !== -1 || tipoChamado[i].Codigo === "10" && vistoria !== "") {
            select += "<option value=" + tipoChamado[i].Codigo + ">" + tipoChamado[i].Descricao + "</option>";
        }
        else if (tipoChamado[i].Codigo === "11" && Equipamento.indexOf("PLUS") !== -1 && resultado !== "") {
            select += "<option value=" + tipoChamado[i].Codigo + ">" + tipoChamado[i].Descricao + "</option>";
        }
        else if (tipoChamado[i].Codigo === "13" && Equipamento.indexOf("PLUS") !== -1) {
            select += "<option value=" + tipoChamado[i].Codigo + ">" + tipoChamado[i].Descricao + "</option>";
        }
    }
    retornaChamado(select);
    return select;
}

function botaoAnterior(posicao) {
    var botao = "<td><input type='button' value='Anterior' class='btn-primary' onclick='AvancaRetorna(\"" + posicao + "\");'/></td>";
    $('#tabela3 > tbody > tr > td').eq(0).before(botao);
    var valor = $('#idContrato').attr('colspan');
    var resultado = valor - 1;
    $('#idContrato').attr('colspan', resultado);
}

function botaoProximo(posicao) {
    var botao = "<td><input type='button' value='Próximo' class='btn-primary' onclick='AvancaRetorna(\"" + posicao + "\");'/></td>";
    var qtd = $("table > tbody").find("> tr:first ").length;

    var valor = $('#idContrato').attr('colspan');
    var resultado = valor - 1;
    $('#idContrato').attr('colspan', resultado);
    $('#servico').after(botao);
}

function AvancaRetorna(posicao) {
    retornaTabelaOs(Retorno, Contrato, posicao);
}

function VerificaAberturaEdicao() {
    var verifica = {};
    verifica.abrirOs = 0;
    verifica.alterarOs = 0;
    if (StatusOsCliente === "") {
        if (StatusEquipamento === "PRE-VENDA" || StatusEquipamento === "ATIVO" || StatusEquipamento === "PRE-ATIVO" || StatusEquipamento === "RETIRADO" || StatusEquipamento === "PLUS NÃO RENOVADO" || StatusEquipamento.substr(0, 3) === "CANC") {
            if ((StatusVenda === "CONFIRMADO" && StatusAtendimento === "NORMAL") || (StatusVenda === "PENDENTE" && StatusAtendimento === "NORMAL") || (StatusEquipamento.substr(0, 3) === "CANC")) {
                verifica.abrirOs = 1;
            }
        }
    }
    else if (StatusOsCliente === "ENCERRADA" || StatusOsCliente === "CANCELADA") {
        if (StatusOsCliente === "ENCERRADA" || StatusOsCliente === "CANCELADA" || StatusOsCliente === "CANCELADO") {
            verifica.abrirOs = 1;
            if (StatusEquipamento === "ATIVO" || StatusEquipamento === "PRE-ATIVO" || StatusEquipamento === "RETIRADO" || StatusEquipamento === "PLUS SEM VISTORIA" || StatusEquipamento === "PLUS NÃO RENOVADO" || StatusEquipamento.substr(0, 3) === "CANC") {
                if (StatusAtendimento === "INADIMPLENTE") {
                    verifica.abrirOs = 0;
                }
            }
        }
        else if (StatusOsCliente === "ENCERRADA" || StatusOsCliente === "CANCELADA" || StatusOsCliente === "CANCELADO") {
            if (StatusOsCliente === "ABERTA" || StatusOsCliente === "EM ATENDIMENTO") {
                if (StatusEquipamento === "ATIVO" || StatusEquipamento === "PRE-ATIVO" || StatusEquipamento === "RETIRADO" || StatusEquipamento.substr(0, 3) === "CANC") {
                    if ((StatusVenda === "CONFIRMADO" && StatusAtendimento === "NORMAL") || StatusEquipamento.substr(0, 3) === "CANC" || StatusEquipamento === "SUSPENSO") {
                        verifica.alterarOs = 1;
                    }
                }
            } else if (StatusEquipamento === "ATIVO" || StatusEquipamento === "PRE-ATIVO" || StatusEquipamento === "RETIRADO" || StatusEquipamento === "PLUS NÃO RENOVADO" || StatusEquipamento.substr(0, 3) === "CANC") {
                if ((StatusVenda === "CONFIRMADO" && StatusAtendimento === "NORMAL") || StatusEquipamento.substr(0, 3) === "CANC") {
                    //Pode AbrirOs
                    verifica.abrirOs = 1;
                    if (StatusEquipamento.substr(0, 3) === "CANC") {
                        //Não pode AbrirOs
                    }
                }
            }
        }
    }
    else if (StatusEquipamento === "ATIVO" || StatusEquipamento === "PRE-ATIVO" || StatusEquipamento === "RETIRADO" || StatusEquipamento === "PLUS SEM VISTORIA" || StatusEquipamento === "PLUS NÃO RENOVADO" || StatusEquipamento.substr(0, 3) === "CANC" || StatusEquipamento === "SUSPENSO") {
        verifica.alterarOs = 1;
    }
    return verifica;
}

function retornaTabelaOs(retorno, idContrato, posicao) {
    retornaNumeroEncerramento(retorno[posicao].NumeroEncerramento);
    retornaIntLan(retorno[posicao].IntLan);
    var atual = parseInt(posicao) + 1;
    retornaStatusOs(retorno[posicao].StatusOs);
    var linhaTitulo1 = ("</br><button id='trigger' type='button' class='btn-primary' onclick='ocultaDiv(\"" + '#tabela3' + "\");' >Ordem de serviço</button><table id=tabela3 class='TableOs text'>" +
        "<thead>" +
        "<tr>" +
        "<th>Ordem de Serviço</th>" +
        "</tr>" +
        "</thead>" +
        "<tbody>" +
        "<tr>" +
        "<td colspan='4' id='idContrato'>" + idContrato + "</td>" +
        "<td>" + retorno[posicao].StatusOs + "</td>" +
        "<td id='servico'>" + atual + "/" + retorno.length + "</td>" +
        "</tr>" +
        "<tr>" +
        "<th>Tipo de Chamado</th>" +
        "<th>Jampeado?</th>" +
        "<th>Número do Encerramento</th>" +
        "<th>Visita Para</th>" +
        "<th>Hora Marcada</th>" +
        "<th>Técnico</th>" +
        "</tr>");

    var linha1 = "<tr>"
        + "<td>" + retorno[posicao].TipoChamado + "</td>"
        + "<td>" + retorno[posicao].Jumper + "</td>"
        + "<td>" + retorno[posicao].NumeroEncerramento + "</td>"
        + "<td>" + retorno[posicao].DataVisita.substr(0, 10) + "</td>"
        + "<td>" + retorno[posicao].HoraVisita.substr(11, 8) + "</td>"
        + "<td>" + retorno[posicao].Instalador + "</td>"
        + "</tr>";

    var linhaTitulo2 = "<tr>" +
        "<th>Endereço Residencial</th>" +
        "<th>Número</th>" +
        "<th>Bairro</th>" +
        "<th>Cidade</th>" +
        "<th>UF</th>" +
        "<th>Região</th></tr>";

    var linha2 = "<tr>"
        + "<td>" + retorno[posicao].Endereco + "</td>"
        + "<td>" + retorno[posicao].Numero + "</td>"
        + "<td>" + retorno[posicao].Bairro + "</td>"
        + "<td>" + retorno[posicao].Cidade + "</td>"
        + "<td>" + retorno[posicao].Uf + "</td>"
        + "<td>" + retorno[posicao].InformacaoRegiao + "</td></tr>";

    var linhaTitulo3 = "<tr><th colspan='3'>Histórico</th><th>Informações do Chamado</th><th colspan='2'>Medida Adotada</th></tr>" +
        "<tr>" +
        "<th>Aberto </th>" +
        "<th>Dia </th>" +
        "<th>Hora </th>";
    var botao1 = "<td><input type='text' id='informacao' name='informacao'></input><input type='button' name='info' value='Incluir Informação' id='info' class='btn-primary' onclick='IncluirInformacao(\"" + 'INF' + "\")' /></td>";
    var botao2 = "<td colspan='2'><input type='text' id='inMedida' name='inMedida'><input type='button' name='medida' value='Incluir Medida' id='medida' class='btn-primary' onclick='IncluirInformacao(\"" + 'OBS' + "\")'/></td>";
    var linha3 = "<tr>" +
        "<td>" + retorno[posicao].AbertaPor + "</td>"
        + "<td>" + retorno[posicao].AbertaEm.substr(0, 10) + "</td>"
        + "<td>" + retorno[posicao].AbertaAs.substr(11, 8) + "</td>" +
        "<td rowspan='5'><textarea id='TextArea' cols='40' rows='5' contenteditable='false'>" + retorno[posicao].InformacoesChamado + "</textarea></td>" +
        "<td rowspan='5' colspan='2'><textarea id='TextArea1' cols='40' rows='5' contenteditable='false'>" + retorno[posicao].MedidaAdotada + "</textarea></td>" +
        "</tr>" +
        "<tr>" +
        "<th>Alterado</th>" +
        "<th>Dia</th>" +
        "<th>Hora</th>" +
        "</tr>" +
        "<tr>" +
        "<td>" + retorno[posicao].AlteradoPor + "</td>" +
        "<td>" + retorno[posicao].AlteradoEm.substr(0, 10) + "</td>" +
        "<td>" + retorno[posicao].AlteradoAs.substr(11, 8) + "</td>" +
        "</tr>" +
        "<tr>" +
        "<th>Encerrado</th>" +
        "<th>Dia</th>" +
        "<th>Hora</th>" +
        "</tr>" +
        "<tr>" +
        "<td>" + retorno[posicao].EncerradaPor + "</td>" +
        "<td>" + retorno[posicao].EncerradaEm.substr(0, 10) + "</td>" +
        "<td>" + retorno[posicao].EncerradaAs.substr(11, 8) + "</td>" +
        "</tr>";
    var linha4;
    if (Equipamento === 'PLUS') {
        linha4 = "<tr><td colspan='6'><input type='button' value='Vistoria' id='vistoria' class='btn-primary' onclick='Vistoria();'></td></tr>";
    } else {
        var abrir = "";
        var alterar = "";
        var verifica = VerificaAberturaEdicao();
        if (verifica.abrirOs === 1) {
            abrir = "<td colspan='3'><input type='button' value='Abrir OS' id='abrir' class='btn-primary' onclick='AbrirOs();'></td>";
        }
        if (verifica.alterarOs === 1) {
            alterar = "<td colspan='3'><input type='button' value='Alterar OS' id='alterar' class='btn-primary' onclick='AlterarOs();'></td>";
        }
        if (abrir === undefined && alterar === undefined) {
            linha4 = "";
        } else {
            linha4 = "<tr>" + abrir + alterar + "</tr>";
        }
    }

    $("#info").html(botao1);
    $("#medida").html(botao2);
    $("#ordemServico").html(linhaTitulo1 + linha1 + linhaTitulo2 + linha2 + linhaTitulo3 + botao1 + botao2 + linha3 + linha4);

    if (posicao >= 1) {
        botaoAnterior(parseInt(posicao) - 1);
    }
    if (parseInt(posicao) + 1 < retorno.length) {
        botaoProximo(parseInt(posicao) + 1);
    }

}

function IncluirInformacao(campo) {
    var numeroEncerramento = NumeroEncerramento;
    var pedido = Contrato;
    var observacao;
    if (campo === 'INF') {
        observacao = $("#informacao").val();
    }
    else if (campo === 'OBS') {
        observacao = $("#inMedida").val();
    }

    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/Informacao',
        dataType: "json",
        contentType: "application/json",
        data:
            "{ pedido: " + pedido + ",numeroEncerramento: '" + numeroEncerramento + "',campo: '" + campo + "',observacao:'" + observacao + "' }",
        success: function () {
            retornaOs();
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });

};

function ocultaDiv(tabela) {
    $(tabela).toggle();
}

function mascaraMutuario(o, f) {
    v_obj = o;
    v_fun = f;
    setTimeout('execmascara()', 1);
}

function execmascara() {
    v_obj.value = v_fun(v_obj.value);
}

function cpfCnpj(v) {

    //Remove tudo o que não é dígito
    v = v.replace(/\D/g, "");

    if (v.length <= 14) { //CPF

        //Coloca um ponto entre o terceiro e o quarto dígitos
        v = v.replace(/(\d{3})(\d)/, "$1.$2");

        //Coloca um ponto entre o terceiro e o quarto dígitos
        //de novo (para o segundo bloco de números)
        v = v.replace(/(\d{3})(\d)/, "$1.$2");

        //Coloca um hífen entre o terceiro e o quarto dígitos
        v = v.replace(/(\d{3})(\d{1,2})$/, "$1-$2");

    } else { //CNPJ

        //Coloca ponto entre o segundo e o terceiro dígitos
        v = v.replace(/^(\d{2})(\d)/, "$1.$2");

        //Coloca ponto entre o quinto e o sexto dígitos
        v = v.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3");

        //Coloca uma barra entre o oitavo e o nono dígitos
        v = v.replace(/\.(\d{3})(\d)/, ".$1/$2");

        //Coloca um hífen depois do bloco de quatro dígitos
        v = v.replace(/(\d{4})(\d)/, "$1-$2");

    }

    return v;
}

function tabelaClienteDados(retorno) {
    retornaStatus(retorno.StatusAtendimento, retorno.StatusOs, retorno.StatusVenda);
    var linhaTitulo1 = ("</br><button id='trigger' type='button' class='btn-primary' onclick='ocultaDiv(\"" + '#tabela4' + "\");' >Dados do cliente</button><table id=tabela4 class='TableOs text'>" +
 "<thead>" +
     "<tr>" +
         "<th>Dados do cliente</th>" +
     "</tr>" +
 "</thead>" +
 "<tbody>" +
 "<tr>" +
  "<td colspan='6'>" + retorno.Equipamento + "</td>" +
  "<td colspan='3'>" + retorno.Versao + "</td>" +
 "</tr>" +
     "<tr>" +
         "<th>Pedido</th>" +
         "<th>Status</th>" +
         "<th>Atendimento</th>" +
         "<th>Venda</th>" +
         "<th>Instalação</th>" +
         "<th>Ativado por</th>" +
         "<th>Ativado em</th>" +
         "<th>Instalador</th>" +
         "<th>Instaladora</th>" +
     "</tr>");

    var linha1 = "<tr>"
    + "<td>" + retorno.Contrato + "</td>"
    + "<td>" + retorno.StatusEquipamento + "</td>"
    + "<td>" + retorno.StatusAtendimento + "</td>"
    + "<td>" + retorno.StatusVenda + "</td>"
    + "<td>" + retorno.DataInstalacao.substr(0, 10) + "</td>"
    + "<td>" + retorno.AtivadoPor + "</td>"
    + "<td>" + retorno.AtivadoEm + "</td>"
    + "<td>" + retorno.Instalador + "</td>"
    + "<td>" + retorno.Instaladora + "</td>"
    + "</tr>"
    ;

    var linhaTitulo2 = "<tr>" +
        "<th>Cliente</th>" +
        "<th>CPF-CNPJ</th>" +
        "<th>RG-Inscr.Estadual</th>" +
        "<th>Data de Nascimento</th>" +
        "<th>Data da Venda</th>" +
        "<th>Confirmada Em</th>" +
        "<th>Vendedor</th>";
    //"<th>Renov. até</th>";

    var linha2 = "<tr>"
    + "<td>" + retorno.ClienteNome + "</td>"
    + "<td>" + retorno.Documento + "</td>"
    + "<td>" + retorno.Rg + "</td>"
    + "<td>" + retorno.DataNascimento.substr(0, 10) + "</td>"
    + "<td>" + retorno.DataVenda.substr(0, 10) + "</td>"
    + "<td>" + retorno.ConfirmadaEm.substr(0, 10) + "</td>"
    + "<td>" + retorno.Vendedor + "</td>"
    //+ "<td>" + retorno.ProximaRenovacao.substr(0, 10) + "</td>"
    ;

    if (retorno.Vigencia !== null) {
        linhaTitulo2 += "<th>Renov. até</th><th>Vigência PLUS</th>" +
        "</tr>";
        linha2 += "<td>" + retorno.ProximaRenovacao.substr(0, 10) + "</td><td>" + retorno.Vigencia.substr(0, 10) + "</td>" +
            "</tr>";
    } else {
        linhaTitulo2 += "<th colspan='2'>Renov. até</th></tr>";
        linha2 += "<td colspan='2'>" + retorno.ProximaRenovacao.substr(0, 10) + "</td></tr>";
    }

    var linhaTitulo3 = "<tr>" +
            "<th>Fabricante </th>" +
            "<th>Modelo </th>" +
            "<th>Placa </th>" +
            "<th>Ano </th>" +
            "<th>Tipo Veículo </th>" +
            "<th>Renavam </th>" +
            "<th>Chassi </th>" +
            "<th>Combustível </th>" +
            "<th>Cor </th>" +
        "</tr>";

    var linha3 = "<tr>"
    + "<td>" + retorno.Fabricante + "</td>"
    + "<td>" + retorno.Modelo + "</td>"
    + "<td>" + retorno.Placa + "</td>"
    + "<td>" + retorno.Ano + "</td>"
    + "<td>" + retorno.TipoVeiculo + "</td>"
    + "<td>" + retorno.Renavam + "</td>"
    + "<td>" + retorno.Chassi + "</td>"
    + "<td>" + retorno.Combustivel + "</td>"
    + "<td>" + retorno.Cor + "</td>"
    + "</tr><tr>"
    ;

    var botao = "<td colspan='9'><input type='button' name='OS' value='O S' id='OS' class='btn-primary' style='margin-top: 4px;' onclick='retornaOs();' /></td></tr>";

    $("#tabela").html(linhaTitulo1 + linha1 + linhaTitulo2 + linha2 + linhaTitulo3 + linha3 + botao);

}

function tabelaContratosEncontrados(linhas) {
    var linhaTitulo1 = ("</br><button id='trigger' type='button' class='btn-primary' onclick='ocultaDiv(\"" + '#tabela5' + "\");' >Contratros Encontrados</button><table id=tabela5 class='TableOs text'>" +
"<thead>" +
    "<tr>" +
        "<th>Contratos Encontrados</th>" +
    "</tr>" +
"</thead>" +
"<tbody>" +
    "<tr>" +
        "<th></th>" +
        "<th>Contrato</th>" +
        "<th>Cliente</th>" +
        "<th>CPF-CNPJ</th>" +
        "<th>Data da Venda</th>" +
        "<th>Status</th>" +
        "<th>Atendimento</th>" +
        "<th>Venda</th>" +
    "</tr>");

    var linha = linhas;

    $("#contrato").html(linhaTitulo1 + linha);
}

function contratosEncontrados(retorno) {

    var linha = "<tr>"
    + "<td><input type='button' class='btn-primary' onclick='retornaDadosCliente(\"" + retorno.Contrato + "\")' value='Abrir' </td>"
    + "<td>" + retorno.Contrato + "</td>"
    + "<td>" + retorno.ClienteNome + "</td>"
    + "<td>" + retorno.Documento + "</td>"
    + "<td>" + retorno.DataVenda.substr(0, 10) + "</td>"
    + "<td>" + retorno.StatusEquipamento + "</td>"
    + "<td>" + retorno.StatusAtendimento + "</td>"
    + "<td>" + retorno.StatusVenda + "</td>"
    + "</tr>"
    ;
    return linha;
}

function retornaEndereco(cepPrestadora) {
    var cep = $("#txtcep").val();
    if (cep === "" || cep === undefined) {
        cep = cepPrestadora;
    }

    if (cep !== "") {
        $.ajax({
            type: "POST",
            url: 'OrdemServico.aspx/RetornaEndereco',
            dataType: "json",
            contentType: "application/json",
            data: "{ cep: '" + cep + "' }",
            success: function (response) {
                var retorno = JSON.parse(response.d);
                if (retorno.Rua === null) {
                    alert("Cep inexistente!");
                    limpaLinhaTabela(4, 6, "Endereço");

                } else {
                    retornaEnderecoLoja(retorno);
                    //var endereco = montaLinhaEndereco(retorno);
                    //$('#tabela1 > tbody > tr').eq(3).after(endereco);
                    //limpaLinhaTabela(6, 0, "Telefone");
                }

            },
            error: function () {
                alert("Erro carregando os dados! Por favor tente novamente.");
            }
        });
    } else {
        alert("Digite um cep!");
    }
}

function limpaLinhaTabela(inicio, fim, texto) {
    var linha = $("#tabela5 tr:contains(\"" + texto + "\")");
    var indiceLinha = $(linha).index();
    if (fim === 0) {
        fim = indiceLinha;
    }
    if (indiceLinha > inicio || indiceLinha === inicio) {
        for (var i = inicio; i < fim; i++) {
            $('#tabela5 > tbody > tr').eq(i).empty();
        }
    }
}

function limpaLinhaTr(inicio) {
    var linha = $("#tabela5 > tbody > tr").length;
    linha -= 1;
    for (var i = inicio; i < linha; i++) {

        $('#tabela5 > tbody > tr').eq(i).empty();
    }
}

function montaLinhaEndereco(retorno) {
    var linhaTitulo = "<tr>" +
        "<th>Endereço</th>" +
        "<th>Número </th>" +
        "<th>Bairro</th>" +
        "<th>Cidade</th>" +
        "<th>Estado</th>" +
        "</tr>";
    var linha = "<tr>" +
        "<td>" + retorno.Rua + "</td>" +
        "<td>" + retorno.Numero + "</td>" +
        "<td>" + retorno.Bairro + "</td>" +
        "<td>" + retorno.Cidade + "</td>" +
        "<td>" + retorno.Estado + "</td>" +
        "</tr>";
    $('#telefone').val(retorno.Telefone);
    var endereco = linhaTitulo + linha;
    return endereco;

}

function Avisos() {
    retornaAvisos();
}

function retornaAvisos() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaAvisos',
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            if (retorno.length >= 1) {
                montaTabelaAvisos(retorno);
            }
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function montaTabelaAvisos(retorno) {
    var linhaTitulo1 = ("</br><button id='trigger' type='button' class='btn-primary' onclick='ocultaDiv(\"" + '#tabela6' + "\");' >Ordens de Serviço de Visita</button><table id=tabela6 class='TableOs text'>" +
"<thead>" +
   "<tr>" +
       "<th>Ordens de Serviço de Visita</th>" +
   "</tr>" +
"</thead>" +
"<tbody>" +
   "<tr>" +
       "<th>OS</th>" +
       "<th>Contrato</th>" +
       "<th>Chamado</th>" +
       "<th>Aberta</th>" +
       "<th>Confirma</th>" +
   "</tr>");

    var linha = tabelaAvisos(retorno);

    $("#avisos").html(linhaTitulo1 + linha);
}

function tabelaAvisos(retorno) {
    var linha = "";
    //if (retorno !== undefined) {
    for (var i = 0; i < retorno.length; i++) {
        linha += "<tr>"
  + "<td><input type='button' id='direciona' class='btn-primary' onclick='redireciona(\"" + retorno[i].NumeroOs + "\")' value='Abrir' /></td>"
  + "<td>" + retorno[i].Contrato + "</td>"
  + "<td>" + retorno[i].Chamado + "</td>"
  + "<td>" + retorno[i].Aberto.substr(0, 10) + "</td>"
  + "<td><input type='button' id='confirmar' class='btn-primary' onclick=' (\"" + retorno[i].NumeroOs + "\")' value='Confirmar' /></td>"
  + "</tr>";
    }
    // }
    return linha;
}

function redireciona(numeroOs) {
    retornaIntLanRelatorio(numeroOs);
    window.open("CetecRelatorio.html", '_blank');
}

function confirmarOs(numeroOs) {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/DefineVisitaOs',
        dataType: "json",
        contentType: "application/json",
        data: "{ numeroOs: '" + numeroOs + "' }",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            alert(retorno);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
};

function stringToDate(_date, _format, _delimiter, time) {
    var formatLowerCase = _format.toLowerCase();
    var formatItems = formatLowerCase.split(_delimiter);
    var dateItems = _date.split(_delimiter);
    var monthIndex = formatItems.indexOf("mm");
    var dayIndex = formatItems.indexOf("dd");
    var yearIndex = formatItems.indexOf("yyyy");
    var month = parseInt(dateItems[monthIndex]);
    month -= 1;
    var timeItems = time.split(":");

    var formatedDate = new Date(dateItems[yearIndex], month, dateItems[dayIndex], timeItems[0], timeItems[1]);
    return formatedDate;
}

function GravarOs(alterar) {
    var ordemServico = {};
    ordemServico.Status = $("#statusOs option:selected").val();
    ordemServico.Contrato = Contrato;
    if (ordemServico.Status === "4" || ordemServico.Status === "0" || ordemServico.Status === "2") {
        ordemServico.TipoChamado = $("#tipoChamado option:selected").text();
        ordemServico.Informacao = $("#informacoes").val();
        ordemServico.Instaladora = $("#instaladora option:selected").val();
        ordemServico.Instalador = $("#instalador option:selected").text();

        if (alterar === 0) {
            ordemServico.Id = "";
        } else {
            ordemServico.Id = IntLan;
        }
        retornaStatusOs("Em Atendimento");
        if (ordemServico.Status === "2") {
            ordemServico.MotivoCancelamento = $("#cancelamento option:selected").val();
            retornaStatusOs("Cancelada");
        }
    }
    if (ordemServico.Status === "0") {
        var endereco = EnderecoLoja;
        ordemServico.Usuario = "";
        ordemServico.DataMarcada = $("#dataVisita").val();
        ordemServico.HoraMarcada = $("#horaVisita").val();
        ordemServico.Endereco = endereco.Rua;
        ordemServico.Bairro = endereco.Bairro;
        ordemServico.Cidade = endereco.Cidade;
        ordemServico.Estado = endereco.Estado;
        ordemServico.FoneContato = endereco.Telefone;
        ordemServico.PontoReferencia = "";
        ordemServico.Regiao = "";
        ordemServico.Numero = endereco.Numero;
        ordemServico.SaidaDestino = $("#distanciaKm option:selected").text();
        ordemServico.CodigoCidade = $("#distanciaKm option:selected").val();
        ordemServico.MotivoCancelamento = "";
        ordemServico.Resolvido = "";
        retornaStatusOs("Aberta");
    }

    if (alterar === 0) {

        if (ordemServico.DataMarcada === "" || ordemServico.HoraMarcada === "" || ordemServico.Informacao === "" || ordemServico.Instalador === "") {
            alert("Favor preencher todos os campos.");
            breakAfter();
        } else {
            var dataVisita = stringToDate(ordemServico.DataMarcada, "yyyy-MM-dd", "-", ordemServico.HoraMarcada);
            var agora = new Date();
            if (dataVisita.getDate() < agora.getDate()) {
                alert("A data não pode ser menor que hoje.");
                breakAfter();
            } else if (dataVisita < agora) {
                alert("O horário não pode ser menor que agora.");
                breakAfter();
            }
        }
    }

    var dto = { 'ordemServico': ordemServico };

    if (StatusOsCliente === "ENCERRADA") {
        if (StatusOsCliente === "ENCERRADA" && ordemServico.TipoChamado === "Visita-tec.") {
            alert("5- Última OS aberta: " + StatusOsCliente + " Os encerrada : " + ordemServico.TipoChamado);
        }
        if (ordemServico.TipoChamado === "Instalação" && StatusVenda === "PENDENTE") {
            $.ajax({
                type: "POST",
                url: 'OrdemServico.aspx/FlagVendaPendente',
                dataType: "json",
                contentType: "application/json",
                data: "{ contrato: " + Contrato + ",intLan: '" + IntLan + "' }",
                success: function (response) {
                    var retorno = JSON.parse(response.d);
                },
                error: function () {
                    alert("Erro carregando os dados! Por favor tente novamente.");
                }
            });
        }

        if (ordemServico.TipoChamado === "Suporte" || ordemServico.TipoChamado === "Instalação" || ordemServico.TipoChamado === "Reinstalação" || ordemServico.TipoChamado === "Recall" || ordemServico.TipoChamado === "Troca" || ordemServico.TipoChamado === "Retirada") {
            $.ajax({
                type: "POST",
                url: 'OrdemServico.aspx/VerificaEncerramentoOs',
                dataType: "json",
                contentType: "application/json",
                data: "{ intLan: " + IntLan + "}",
                success: function (response) {
                    var retorno = JSON.parse(response.d);
                    if (retorno === "0") {
                        alert("Esta OS só poderá ser encerrada após a gravação do encerramento da OS, favor gravar Encerramento da OS.");
                    }
                },
                error: function () {
                    alert("Erro carregando os dados! Por favor tente novamente.");
                }
            });
        }
    }

    if (StatusOsCliente === "ABERTA") {
        if (StatusEquipamento === "PLUS NÃO RENOVADO") {
            if (ordemServico.TipoChamado !== "Revisão-PLUS") {
                alert("Clientes com este status PLUS NÃO RENOVADO, só podem abrir OS de Revisão-PLUS.");
            }
        }

        if (ordemServico.TipoChamado === "Instalação" || ordemServico.TipoChamado === "Reinstalação") {
            $.ajax({
                type: "POST",
                url: 'OrdemServico.aspx/RetornaOsVistoria',
                dataType: "json",
                contentType: "application/json",
                data: "{ contrato: " + Contrato + "}",
                success: function (response) {
                    var retorno = JSON.parse(response.d);
                    if (ordemServico.TipoChamado === "Instalação") {
                        if (retorno.length >= 1 && retorno === 3) {
                            alert("OS de Instalação só pode ser aberta com status de vistoria, APROVADO OU APROVADO PARCIAL.");
                        }
                    }
                },
                error: function () {
                    alert("Erro carregando os dados! Por favor tente novamente.");
                }
            });
        }
        if (ordemServico.TipoChamado === "Reinstalação") {
            $.ajax({
                type: "POST",
                url: 'OrdemServico.aspx/VerificaOsRetirada',
                dataType: "json",
                contentType: "application/json",
                data: "{ contrato: " + Contrato + "}",
                success: function (response) {
                    var retorno = JSON.parse(response.d);
                    if (retorno !== "Retirada") {
                        alert("OS de Reinstalação só pode ser aberta se a ultima OS for de Retirada.");
                    }
                },
                error: function () {
                    alert("Erro carregando os dados! Por favor tente novamente.");
                }
            });
        }
    }

    if (StatusOsCliente === "ENCERRADA" || (StatusOsCliente === "ABERTA") || StatusOsCliente === "CANCELADA" || StatusOsCliente === "EM ATENDIMENTO" || StatusOsCliente === "CONCLUÍDO") {
        if (ordemServico.TipoChamado !== "Retirada" || ordemServico.TipoChamado !== "Visita técnica") {
            if (StatusOsCliente === "ABERTA") {
                if (StatusEquipamento === "PLUS NÃO RENOVADO") {
                    //if (verifica se Teste foi enviado) {

                    //}
                }
            }
        }
    }

    if (StatusOsComp === "Aberta") {
        //GravaOsAberta
        $.ajax({
            type: "POST",
            url: 'OrdemServico.aspx/GravaOsAberta',
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(dto),
            success: function (response) {
                var retorno = JSON.parse(response.d);
                alert(retorno);
                retornaOsAtualizada();
            },
            error: function () {
                alert("Erro carregando os dados! Por favor tente novamente.");
            }
        });
    }
    else if (StatusOsComp === "Encerrada") {
        //GravaOsEncerrada
        $.ajax({
            type: "POST",
            url: 'OrdemServico.aspx/GravaOsEncerrada',
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(dto),
            success: function (response) {
                var retorno = JSON.parse(response.d);
                alert(retorno);
                retornaOsAtualizada();
            },
            error: function () {
                alert("Erro carregando os dados! Por favor tente novamente.");
            }
        });
    }
    else if (StatusOsComp === "Cancelada") {
        //GravaOsCancelada
        $.ajax({
            type: "POST",
            url: 'OrdemServico.aspx/GravaOsCancelada',
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(dto),
            success: function (response) {
                var retorno = JSON.parse(response.d);
                alert(retorno);
                retornaOsAtualizada();
            },
            error: function () {
                alert("Erro carregando os dados! Por favor tente novamente.");
            }
        });
    }
    else if (StatusOsComp === "Em Atendimento") {
        //GravaOsAtendimento
        $.ajax({
            type: "POST",
            url: 'OrdemServico.aspx/GravaOsAtendimento',
            dataType: "json",
            contentType: "application/json",
            data: JSON.stringify(dto),
            success: function (response) {
                var retorno = JSON.parse(response.d);
                alert(retorno);
                retornaOsAtualizada();
            },
            error: function () {
                alert("Erro carregando os dados! Por favor tente novamente.");
            }
        });
    }
}

function retornaOsAtualizada() {
    retornaDadosCliente();
    retornaOs();
}

//Botões
//Enviar
function EnviarTeste() {
    GravarEnvioTeste();
    VerificarExisteComando();
    RastreamentoEnviaComando();
}

function GravarEnvioTeste() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/EnviarTesteComando',
        dataType: "json",
        contentType: "application/json",
        data: "{ contrato: '" + Contrato + "', produto: '"+TipoEquipamento+"' }",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            alert(retorno);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function VerificarExisteComando() {
    var comando = "Teste de Comando";
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaExisteComando',
        dataType: "json",
        contentType: "application/json",
        data: "{ peca: '" + TipoEquipamento + "', contrato: '" + Contrato + "', comando: '" + comando + "' }",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            alert(retorno);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function RastreamentoEnviaComando() {
    $.ajax({
        type: "POST",
        url: 'OrdemServico.aspx/RetornaExisteComando',
        dataType: "json",
        contentType: "application/json",
        data: "{ peca: '" + TipoEquipamento + "', contrato: '" + Contrato + "', comando: '" + comando + "' }",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            alert(retorno);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}
//Enviar
//Botões