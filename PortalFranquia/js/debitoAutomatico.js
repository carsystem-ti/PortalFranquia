$(document).ready(function () {
    $('#Pesquisar').on('click', function () { retornaDadosCliente(); });
});

function retornaDados(retorno,contrato) {
    window.Nome = retorno.Nome;
    window.Documento = retorno.Documento;
    window.Placa = retorno.Placa;
    window.Contrato = contrato;
}

function ocultaDiv(tabela) {
    $(tabela).toggle();

}

function retornaDadosCliente() {
    var contrato = $("#ContentPlaceHolder1_contrato").val();
    $.ajax({
        type: "POST",
        url: 'debitoAutomatico.aspx/RetornaDadosCliente',
        dataType: "json",
        contentType: "application/json",
        data:
            "{ contrato: " + contrato + " }",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            retornaDados(retorno,contrato);
            tabelaDadosCliente(retorno);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function tabelaDadosCliente(retorno) {
    var linhaTitulo1 = ("</br><button id='trigger' type='button' class='btn-primary' onclick='ocultaDiv(\"" + '#tabela' + "\");' >Dados do Cliente</button><table id=tabela class='TableOs text'>" +
    "<thead>" +
        "<tr>" +
            "<th>Dados do Cliente</th>" +
        "</tr>" +
    "</thead>" +
    "<tbody>" +
        "<tr>" +
            "<th>Nome</th>" +
            "<th>Documento</th>" +
            "<th>Placa</th>" +
        "</tr>");

    var linha1 = "<tr>"
    + "<td>" + retorno.Nome + "</td>"
    + "<td>" + retorno.Documento + "</td>"
    + "<td>" + retorno.Placa + "</td>"
    + "</tr>"
    ;
    var botao = "<tr>" +
        "<td><input type='button' class='btn-primary' value='Adicionar' onclick='Adicionar();'></td>" +
        "<td colspan='2'><input type='button' class='btn-primary' value='Retirar' onclick='Retirar();'></td>" +
            "</tr>"
    ;

    $("#dadosCliente").html(linhaTitulo1 + linha1 + botao);
}

function Retirar() {
    var contrato = Contrato;
    $.ajax({
        type: "POST",
        url: 'debitoAutomatico.aspx/RetirarDebitoAutomatico',
        dataType: "json",
        contentType: "application/json",
        data:
            "{ contrato: " + contrato + " }",
        success: function (response) {
            alert(response.d);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function Adicionar() {
    $.ajax({
        type: "POST",
        url: 'debitoAutomatico.aspx/RetornaBancos',
        dataType: "json",
        contentType: "application/json",
        //data:
        //    "{ contrato: " + contrato + " }",
        success: function (response) {
            var retorno = JSON.parse(response.d);
            //tabelaAdicionar(retorno);
            tipoDebito(retorno);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function tipoDebito(retorno) {
    var botao = "</br><input type='button' class='btn-primary' value='Conta' onclick='adicionarConta(\"" + retorno + "\");'>" +
        "|<input type='button' class='btn-primary' value='Cartão' onclick='adicionarCartao();'>";
    $("#tipoDebito").html(botao);
}

function montaSelect(retorno) {
    var opcao = "";
    retorno = retorno.split(",");
    for (var i = 0; i < retorno.length; i++) {
        opcao = opcao + "<option value=" + retorno[i] + ">" + retorno[i] + "</option>";
    }
    return opcao;
}

function montaTabelaConta(opcao) {
    var linhaTitulo1 = ("</br><button id='trigger' type='button' class='btn-primary' onclick='ocultaDiv(\"" + '#tabela2' + "\");' >Adicionar Conta</button><table id=tabela2 class='TableOs text'>" +
    "<thead>" +
        "<tr>" +
            "<th>Adicionar Conta Débito Automático</th>" +
        "</tr>" +
    "</thead>" +
    "<tbody>" +
        "<tr>" +
            "<th colspan='2'>Banco</th>" +
        "</tr>");
    var linha1 = "<tr>"
        + "<td colspan='2'><select id='banco'>" + opcao + "</select></td>"
        + "</tr>"

        + "<tr>"
           + "<th>Agência</th>"
           +"<th>Dígito da Agência</th>"
        + "</tr>" +

        "<tr>"
        + "<td><input type='text' id='agencia' maxlength='10' /></td>"
        + "<td><input type='text' id='digitoAgencia' maxlength='1' /></td>" +
        "</tr>" +

        "<tr>"
        +"<th>Conta</th>"
        +"<th>Dígito da Conta</th>"+
        "</tr>" +

        "<tr>"
        + "<td><input type='text' id='conta' maxlength='10'></td>"
        + "<td><input type='text' id='digitoConta' maxlength='1'></td>" +
        "</tr>"

        + "<tr>" +
        "<th colspan='2'>Nome</th>" +
        "</tr>"

        + "<tr>"
        + "<td colspan='2'><input type='text' id='nome' maxlength='103'></td>" +
        "</tr>"

        + "<tr>" +
        "<th colspan='2'>Documento</th>" +
        "</tr>" +

        "<tr>" +
        "<td colspan='2'><input type='text' id='documento' maxlength='19'></td>" +
        "</tr>";

    var botao = "<tr>" +
        "<td colspan='2'><input type='button' class='btn-primary' value='Salvar' onclick='SalvarConta();' ></td>" +
            "</tr></tbody></table>"
    ;

    $("#adicionar").html(linhaTitulo1 + linha1 + botao);
}

function adicionarConta(retorno) {

    var opcao = montaSelect(retorno);
    montaTabelaConta(opcao);
}


function montaTabelaCartao() {
    var linhaTitulo2 = "</br><button id='trigger' type='button' class='btn-primary' onclick='ocultaDiv(\"" + '#tabela3' + "\");' >Adicionar Cartão</button><table id=tabela3 class='TableOs text'>" +
    "<thead>" +
    "<tr>" +
            "<th>Adicionar Cartão Débito Automático</th>" +
        "</tr>" +
    "</thead>" +
    "<tbody>" +
        "<tr>" +
            "<th>Titular</th>" +
            "<th>Cartão de Crédito</th>" +
            "<th>Data de Validade</th>" +
            "<th>Número de Segurança</th>" +
        "</tr>";

    var linha2 = "<tr>"
    + "<td><input type='text' id='titular' maxlength='103'></td>"
    + "<td><input type='text' id='cartaoCredito' maxlength='16'></td>"
    + "<td><input type='text' id='dataValidade' maxlength='4'></td>"
    + "<td><input type='text' id='numeroSeguranca' maxlength='3'></td>"
    + "</tr>";

    var botao = "<tr>" +
        "<td colspan='4'><input type='button' class='btn-primary' value='Salvar' onclick='SalvarCartao();'></td>" +
            "</tr></tbody></table>"
    ;

    $("#adicionar").html(linhaTitulo2 + linha2 + botao);
}

function adicionarCartao() {
    montaTabelaCartao();
}

function SalvarConta() {
    var adicionarDebito = {};
    adicionarDebito.NomeBanco = $("#banco option:selected").text();
    adicionarDebito.NumeroAgencia = $("#agencia").val();
    adicionarDebito.NumeroConta = $("#conta").val();
    adicionarDebito.DigitoAgencia = $("#digitoAgencia").val();
    adicionarDebito.DigitoConta = $("#digitoConta").val();
    adicionarDebito.NumeroDocumento = $("#documento").val();
    adicionarDebito.Titular = $("#nome").val();
    adicionarDebito.TipoDebito = "0";
    adicionarDebito.NumeroContrato = Contrato;
    adicionarDebito.CartaoCredito = "";
    adicionarDebito.DataValidade = "";
    adicionarDebito.NumeroSeguranca = "";
    

    if (adicionarDebito.NumeroAgencia === "" || adicionarDebito.NumeroConta === "" || adicionarDebito.DigitoAgencia === "" || adicionarDebito.DigitoConta === "" || adicionarDebito.NumeroDocumento === "" || adicionarDebito.Titular === "") {
        alert("Preencha todos os campos!");
        breakAfter();
    }

    if (adicionarDebito.NumeroAgencia.length < 4 || adicionarDebito.NumeroConta.length < 4 || adicionarDebito.NumeroDocumento.length < 11 || adicionarDebito.Titular.length < 10) {
        alert("Dados inválidos!");
        breakAfter();
    }

    var dto = { 'adicionar': adicionarDebito };

    $.ajax({
        type: "POST",
        url: 'debitoAutomatico.aspx/AdicionarDebitoAutomatico',
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(dto),
        success: function (response) {
            alert(response.d);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}

function SalvarCartao() {
    var adicionarDebito = {};
    adicionarDebito.NomeBanco = "CIELO";
    adicionarDebito.NumeroAgencia = "";
    adicionarDebito.NumeroConta = "";
    adicionarDebito.DigitoAgencia = 0 ;
    adicionarDebito.DigitoConta = 0;
    adicionarDebito.NumeroDocumento = Documento;
    adicionarDebito.Titular = $("#titular").val();
    adicionarDebito.TipoDebito = "1";
    adicionarDebito.NumeroContrato = Contrato;
    adicionarDebito.CartaoCredito = $("#cartaoCredito").val();
    adicionarDebito.DataValidade = $("#dataValidade").val();
    adicionarDebito.NumeroSeguranca = $("#numeroSeguranca").val();

    if (adicionarDebito.Titular === "" || adicionarDebito.CartaoCredito === "" || adicionarDebito.DataValidade === "" || adicionarDebito.NumeroSeguranca === "") {
        alert("Preencha todos os campos!");
        breakAfter();
    }

    if (adicionarDebito.CartaoCredito.length !== 16) {
        alert("Dados inválidos!");
        breakAfter();
    }

    var dto = { 'adicionar': adicionarDebito };

    $.ajax({
        type: "POST",
        url: 'debitoAutomatico.aspx/AdicionarDebitoAutomatico',
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(dto),
        success: function (response) {
            alert(response.d);
        },
        error: function () {
            alert("Erro carregando os dados! Por favor tente novamente.");
        }
    });
}