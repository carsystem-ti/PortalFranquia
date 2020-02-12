var pCodigoCetec = '000906';
var pLocalOS = 3;

function retornaData(pData) {
    window.Data = pData;
}

var urlFuncoesResumoOS = "funcoesResumoOS.aspx";

var iFonteEventos = {
    type: "POST",
    url: urlFuncoesResumoOS,
    data: {
        pFuncao: 'getResumoOS'
        , pCodigoCetec: pCodigoCetec
    },
    error: function (data, e, x) {
        $('#script-warning').html(e);
        $('#script-warning').show();
    }
};

$(document).ready(function () {
    Loading();
    $("#calendar td").addClass("naoComum");
    $('#calendar').on('click', function (event) { event.stopPropagation(); });
    $('.cbp-hrsub').css('left', $(".container").position().left + 60);
    $(window).resize(function () { $('.cbp-hrsub').css('left', $(".container").position().left + 60); });

    $(".printImg").on('click', function (event) { print(event); });

    getFranquiasRegiao();

    $('#calendar').fullCalendar({
        header: {
            right: 'today prev,next',
            center: 'title',
            left: ''//'month,agendaWeek,agendaDay'
        },
        editable: true,
        monthNames: ['Janeiro', 'Fevereiro', 'Mar&ccedil;o', 'Abril', 'Maio', 'Junho', 'Julho',
        'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        dayNames: ['Domingo', 'Segunda', 'Ter&ccedil;a', 'Quarta', 'Quinta', 'Sexta', 'S&aacute;bado'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
        columnFormat: {
            month: 'ddd',
            week: 'ddd DD/MM',
            day: 'dddd DD/MM'
        },
        weekMode: 'liquid',
        height: 500,
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul',
			'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        titleFormat: {
            month: 'MMMM YYYY',      // September 2009
            week: "DD MMM YYYY",      // Sep 13 2009
            day: 'dddd, DD MMMM YYYY' // Tuesday, Sep 8, 2009
        },
        buttonText: {
            prev: '&lsaquo;', // <
            next: '&rsaquo;', // >
            prevYear: '&laquo;',  // <<
            nextYear: '&raquo;',  // >>
            today: 'hoje',
            month: 'mês',
            week: 'semana',
            day: 'dia'
        },
        lang: 'br',
        events: iFonteEventos,
        loading: function (bool) {
            if (bool) {
                Loading();
            }
            else {
                fechaLoading();
            }

        },
        dayClick: function (date, allDay, jsEvent, view) {
            $("#titulo").html(moment(date).format("DD/MM/YYYY"));
            getDetalhesOS(null, moment(date).format("DD/MM/YYYY"), null);
            getFiltros(moment(date).format("DD/MM/YYYY"));
            $("#titulo").click();
        },
        eventClick: function (calEvent, jsEvent, view) {
            var data = moment(calEvent.start).format("DD/MM/YYYY");

            $("#titulo").html(data);
            getDetalhesOS(null, data, null);
            getFiltros(data);
            $("#titulo").click();
        }
    });
    fechaLoading();
});
function print(event){
    event.stopPropagation();
    $(".linhaGridOS").css('border-bottom', '1px solid');
    $("#printOS").printArea();
    $(".linhaGridOS").css('border-bottom', '0px');
    //$("#titulo").click();
}
function openOS(pCodigoOS) {

    if (pCodigoOS == 0)
        return;
    
    Loading();

    $.ajax({
        type: "POST",
        url: 'impressaoOS.aspx',
        dataType: "html",
        data: {
            pCodigoOS: pCodigoOS
        },
        success: function (result) {

            showPopup({
                nomeDiv: '',
                botaoFechar: true,
                semFundo: false,
                conteudoHTML: "<div class='containerImpressaoOS'><div class='impressaoOS'>" + result + "</div></div>",
                temPrint: true,
                semEfeito: false,
                botaoEmail: true,
                funcaoEmail: function () {
                    showPopup({
                        nomeDiv: '#emailBox',
                        botaoFechar: true,
                        semFundo: false,
                        temPrint: false,
                        semEfeito: false,
                        botaoEmail: false
                    });

                    $('#cmdEnviar').off('click');
                    $('#cmdEnviar').on('click', function (e) {
                        e.stopPropagation();
                        sendEmail(pCodigoOS);
                    });
                }
            });

            //criaPopup("", true, false, "<div class='containerImpressaoOS'><div class='impressaoOS'>" + result + "</div></div>", true, false);
            $(".modalPrintImg").click(function (event) {
                event.stopPropagation();
                $(".impressaoOS").printArea();
            });
        },
        error: function (result, textStatus, errorThrown) {
            $('#script-warning').html(result + " -- " + textStatus + " -- " + errorThrown);
            $('#script-warning').show();
        }
    }).done(function (dummy) { fechaLoading(); });
}
function sendEmail(pCodigoOS) {

    var pEnderecoEmail = $("#textEmail").val();
    Loading();
    $.ajax({
        type: "POST",
        url: 'funcoesResumoOS.aspx',
        dataType: "html",
        data: {
            pFuncao: "email",
            pCodigoOS: pCodigoOS,
            pEnderecoEmail: pEnderecoEmail
        },
        success: function (result) {
            $('#script-warning').html(result);

            if (result.indexOf("ERRO##") < 0)
                $('#script-warning').css('color', 'green');

            $('#script-warning').show(function(){
                setTimeout(function () {
                    $('#script-warning').css('color', 'red');
                    $('#script-warning').hide();
                }, 15000);
            });

        },
        error: function (result, textStatus, errorThrown) {
            $('#script-warning').html(result + " -- " + textStatus + " -- " + errorThrown);
            $('#script-warning').show();
        }
    }).done(function (dummy) {
        fechaLoading();
        closePopup();
    });
}
function getDetalhesOS(pStatusOS, pData, pServico) {
    Loading();
    retornaData(pData);
    $.ajax({
        type: "POST",
        url: urlFuncoesResumoOS,
        dataType: "json",
        data: {
            pCodigoCetec: pCodigoCetec
					, pLocalOS: defineLocal(pLocalOS)
					, pStatusOS: pStatusOS
					, pData: pData
					, pServico: pServico
					, pFuncao: "getDetalhesOS"
        },
        success: function (result) {
            var itens = [];

            if (result.length == 0) {
                $("#corpoGrid").html("<h1 class='semRegistros' >SEM REGISTROS</h1>");
            }
            else {

                for (var i = 0; i < result.length; i++) {
                    var obj = result[i];
                    if (obj.codigoOS == 0) {
                        itens.push("<tr class='linhaGridOS'>");
                    }
                    else {
                        itens.push("<tr class='linhaGridOS' onclick=\"javascript:openOS('" + obj.codigoOS + "');\">");
                    }
                    itens.push("<td class='contrato'><div class='celula contrato'><div class='tituloCelula'>Contrato</div>" + obj.contrato + "</div></td>");
                    itens.push("<td>");
                    itens.push("<div class='celula nome'><div class='tituloCelula'>Nome</div>" + obj.nome + "</div>");
                    itens.push("<div class='celula telefone'><div class='tituloCelula'>telefone</div>" + obj.telefone + "</div>");
                    itens.push("<div class='celula celular'><div class='tituloCelula'>celular</div>" + obj.celular + "</div>");
                    itens.push("<div class='celula veiculo'><div class='tituloCelula'>veiculo</div>" + obj.veiculo + "</div>");
                    itens.push("<div class='celula placa'><div class='tituloCelula'>placa</div>" + obj.placa + "</div>");
                    itens.push("<div class='celula servico'><div class='tituloCelula'>servico</div>" + obj.servico + "</div>");
                    itens.push("<div class='celula produto'><div class='tituloCelula'>produto</div>" + obj.produto + "</div>");
                    itens.push("<div class='celula horario'><div class='tituloCelula'>horario</div>" + obj.horario + "</div>");
                    itens.push("<div class='celula status'><div class='tituloCelula'>status</div>" + obj.status + "</div>");
                    itens.push("<div class='celula local'><div class='tituloCelula'>Local</div>" + obj.local + "</div>");
                    itens.push("<div class='celula tecnico'><div class='tituloCelula'>tecnico</div>" + obj.tecnico + "</div>");
                    itens.push("</td></tr>");
                }

                $(".download").click(function () {
                    getFile(pStatusOS, Data, pServico);
                });

                $("#corpoGrid").html(itens.join(" "));
            }

            $("#totalRegistros").html("Total: " + result.length);
        },
        error: function (result, textStatus, errorThrown) {
            $('#script-warning').html(result + " -- " + textStatus + " -- " + errorThrown);
            $('#script-warning').show();
        }
    }).done(function (dummy) { fechaLoading(); });
}
function setFiltroOS(pStatus, pSelecao) {

    var itemSelecionado = pSelecao.split("&nbsp;&nbsp;")[1].trim();
    var pData = $("#titulo").html();

    if (pStatus == 'Local') {
        if (itemSelecionado.trim() == 'Externa') {
            pLocalOS = 1;
        }
        else if (itemSelecionado.trim() == 'Loja') {
            pLocalOS = 0;
        }
        else if (itemSelecionado.trim() == 'Todas') {
            pLocalOS = 3;
        }
        else if (itemSelecionado.trim() == 'AgendaWeb') {
            pLocalOS = 4;
        }

        getDetalhesOS(null, pData, null);
    }
    else {
        getDetalhesOS(pStatus, pData, itemSelecionado);
    }

    getFiltros(pData);
    $("#combo" + pStatus + ">div").html(pStatus + " \\" + itemSelecionado);
}
function defineLocal(pLocalOS) {

    if (pLocalOS == null) {
        pLocalOS = 3;
    }
    else if (pLocalOS == true) {
        pLocalOS = 1;
    }
    else if (pLocalOS == false) {
        pLocalOS = 0;
    }

    return pLocalOS;
}
function setCetec(codigoCetec) {
    $("#titFranquia").html(codigoCetec);

    pCodigoCetec = codigoCetec.split("</br>")[0];
    $("#calendar").fullCalendar('removeEventSource', iFonteEventos);
    iFonteEventos = {
        type: "POST",
        url: urlFuncoesResumoOS,
        data: {
            pFuncao: 'getResumoOS'
            , pCodigoCetec: pCodigoCetec
        },
        error: function (data, e, x) {
            $('#script-warning').html(e);
            $('#script-warning').show();
        }
    };
    //$('#calendar').fullCalendar('refetchEvents');
    $("#calendar").fullCalendar('addEventSource', iFonteEventos);
    $('#titCalendario').click();
}
function getFranquiasRegiao() {

    Loading();

    $.ajax({
        type: "POST",
        url: urlFuncoesResumoOS,
        dataType: "json",
        data: {
            pFuncao: "getFranquiasRegiao"
        },
        async: false,
        success: function (result) {

            var bigList = {};

            var itens = [];

            var regiao = "";

            var listaItens = "";
            var primeiraLinha;
            var funcaoClick = ""; //setFiltroOS(pCodigoCetec, pNomeCombo)

            for (var i = 0; i < result.length; i++) {
                var obj = result[i];

                if (bigList[obj.regiao] == null)
                    bigList[obj.regiao] = [];

                bigList[obj.regiao].push("<li onclick=\"javascript:setCetec('" + obj.franquia + "');\" id='" + obj.id + "'><a href='#'>" + obj.franquia + "</a></li>");
            }

            $("#divFranquiasRegiao").html("");


            $.each(bigList, function (index, value) {
                var itens = "";
                itens += "<div>";
                itens += "<ul>";
                itens += "<h4>" + index + "</h4>";
                itens += value.join(" ");
                itens += "</ul>";
                itens += "</div>";
                $("#divFranquiasRegiao").append(itens);
            });

            if (result.length == 1) {
                $("#franquia-ativa").click();
            }

        },
        error: function (result, textStatus, errorThrown) {
            $('#script-warning').html(result + " -- " + textStatus + " -- " + errorThrown);
            $('#script-warning').show();
        }
    }).done(function (dummy) { fechaLoading(); });
}
function limpaCombos() {
    $('#comboLocal').html('');
    $('#comboAberta').html('');
    $('#comboAtendimento').html('');
    $('#comboEncerrada').html('');
    $('#comboCancelada').html('');
}
function getTituloComboLocal(){
    if (pLocalOS == 0)
        return "Local \\ Loja";
    else if (pLocalOS == 1)
        return "Local \\ Externa";
    else if (pLocalOS == 3)
        return "Local \\ Todas";
    else if (pLocalOS == 4)
        return "Local \\ AgendaWeb";
}
function getItemCombo( pFiltro, pQuantidade, pDescricao){

    var funcaoClick = "onclick=\"javascript:setFiltroOS('" + pFiltro + "',$(this).html());\"";
    return "<li><a id='itemCombo' " + funcaoClick + " href='#'>" + pQuantidade + "&nbsp;&nbsp; " + pDescricao + "</a></li>";
}
function setCombo(pCombo, pTitulo, pItens, pTotal){
    $("#combo" + pCombo ).html("<div>" + pTitulo 
        + "</div><ul class='dropdown'>" 
        + pItens.join(" ") 
         + getItemCombo(pCombo,  pTotal, "Todas")
        + "</ul>");
}
function geraCombos(pDados) {
    var listaCombos = {};
    var totais= {};

    for (var i = 0; i < pDados.length; i++) {

        var obj = pDados[i];

        if (listaCombos[obj.status] == null){
            listaCombos[obj.status] = [];
        }

        if (obj.status == "#EOF") {

            funcaoClick = "onclick=\"javascript:setFiltroOS('Local',$(this).html());\"";
            
            listaCombos[obj.status].push(getItemCombo("Local", obj.loja, "Loja"));
            listaCombos[obj.status].push(getItemCombo("Local", obj.visita, "Externa"));
            listaCombos[obj.status].push(getItemCombo("Local", obj.agenda, "AgendaWeb"));

            setCombo("Local",getTituloComboLocal(), listaCombos[obj.status], parseInt(obj.loja) + parseInt(obj.visita) + parseInt(obj.agenda));
            
            continue;
        }

        if (totais[obj.status] == null){
            totais[obj.status] = parseInt(obj.quantidade);
        }
        else{
            totais[obj.status] += parseInt(obj.quantidade);
        }

        listaCombos[obj.status].push(getItemCombo(obj.status, obj.quantidade, obj.servico));        
    }

    $.each(listaCombos, function (index, value) {
        if (index != "#EOF") {
            setCombo(index, index, value, totais[index]);
        }
    });
}
function getFiltros(pData) {

    Loading();
    limpaCombos();

    $.ajax({
        type: "POST",
        url: urlFuncoesResumoOS,
        dataType: "json",
        data: {
            pCodigoCetec: pCodigoCetec
					, pData: pData
					, pLocalOS: defineLocal(pLocalOS)
					, pFuncao: "getDetalhesOSFiltros"
        },
        async: false,
        success: function (pDados) {
            geraCombos(pDados);            
        },
        error: function (result, textStatus, errorThrown) {
            $('#script-warning').html(result + " -- " + textStatus + " -- " + errorThrown);
            $('#script-warning').show();
        }
    }).done(function (dummy) { fechaLoading(); });
}
function getFile(pStatusOS, pData, pServico) {

    Loading();

    url = 'excelDownload.ashx?'
    + 'pCodigoCetec=' + pCodigoCetec
    + '&pLocalOS=' + defineLocal(pLocalOS);

    if (pStatusOS != null)
        url += '&pStatusOS=' + pStatusOS;
    else
        url += '&pStatusOS=' + '';

    if (pData != null)
        url += '&pData=' + pData;

    if (pServico != null)
        url += '&pServico=' + pServico;
    else
        url += '&pServico=' + '';

    window.open(url, '_blank', 'height=100, location=no, menubar=no, resizable=no, scrollbars=no, status=no, toolbar=no, width=100');
    fechaLoading();
}