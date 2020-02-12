var _codigoProtocolo;
var _tipoProtocolo;

function getDetalhes(pCodigoLocalizacao, pTipoEquipamento, pIsCarSystem, pTipoEstoque, pStatusInventario, pNomeDiv, pVersaoEquipamento) {
    criaPopup('#loadiv', false, true, null, false, true);

    $.post("detalhes.aspx",
    {
        pCodigoLocalizacao: pCodigoLocalizacao
        , pTipoEquipamento: pTipoEquipamento
        , pIsCarSystem: pIsCarSystem
        , pTipoEstoque: pTipoEstoque
        , pStatusInventario: pStatusInventario
        , pNomeDiv: pNomeDiv
        , pVersaoEquipamento: pVersaoEquipamento
    },
    function (data, status) {
        //$("#Detalhes").html(data);
        criaPopup('#Detalhes', true, false, data, true, false);
        $(".modalPrintImg").unbind("click");
        $(".modalPrintImg").click(function () {
            printArea($("#conteudoTosco>.caixa"));
        });
    });
}

function addOcorrencia(pCodigoIdentificador, pCodigoMotivo)
{    
    $.ajax({
        type: "POST",
        url: "protocolo.aspx",
        dataType: "html",
        data: {
            funcao: "addOcorrencia",
            pCodigoMotivo: pCodigoMotivo,
            pCodigoIdentificador: pCodigoIdentificador
        },
        async: false,
        success: function (result) {
            $('#script-warning').css('color', 'green');
            $('#script-warning').html(result);
            $('#script-warning').show();
        },
        error: function (result, textStatus, errorThrown) {
            $('#script-warning').css('color', 'red');
            $('#script-warning').html(result + " -- " + textStatus + " -- " + errorThrown);
            $('#script-warning').show();
        }
    }).done(function (dummy) { fechaLoading(); });
}

function getMotivos(pCodigoIdentificador, pCodigoGrupo, pTituloOcorrencia) {

    Loading();

        $.ajax({
            type: "POST",
            url: "protocolo.aspx",
            dataType: "json",
            data: {
                funcao: "getMotivos",
                pCodigoGrupo: pCodigoGrupo                
            },
            async: false,
            success: function (result) {

                if (result.length <= 0)
                    return;

                var iHTML = '<div id="divOcorrencias">'
                    + '<h1 class="tituloOcorrencia" > ' + pTituloOcorrencia + '</h1>'
                    + '<div class="caixaMotivos">';
                // checked="checked"
                for (var i = 0; i < result.length; i++) {
                    var obj = result[i];

                    iHTML += '<input type="radio" name="radioMotivo" value="' + obj.codigoMotivo + '" class="botaoMotivo" id="mot_' + obj.codigoMotivo + '"/>';
                    iHTML += '<label for="mot_' + obj.codigoMotivo + '" class="botaoBranco motivo-label botoesMotivo">' + obj.motivo + '</label>';
                }

                iHTML += '</div>';
                iHTML += '<div class="botoesMotivoComando">';
                iHTML += '<div id="motBotaoA" class="botaoVermelho" style="font-weight: 900;">' + obj.tituloBotaoA + '</div>';
                iHTML += '<div id="motBotaoB" class="botaoAzul">' + obj.tituloBotaoB + '</div>';
                iHTML += '</div>';
                iHTML += '</div>';
                
                showPopup({
                    nomeDiv: '',
                    botaoFechar: true,
                    semFundo: false,
                    conteudoHTML: iHTML,
                    temPrint: false,
                    semEfeito: false,
                    botaoEmail: false,
                    funcaoEmail: null,
                    funcaoSaida: null
                });

                $("#motBotaoA").on('click', function () {
                    if ($(".botaoMotivo:checked").val() == null || $(".botaoMotivo:checked").val() == 0) {
                        alert("Motivo nao selecionado");
                        return false;
                    }
                    addOcorrencia(pCodigoIdentificador, $(".botaoMotivo:checked").val());
                    getDetalhesProtocolo( _codigoProtocolo, _tipoProtocolo );
                });
                $("#motBotaoB").on('click', function () { closePopup(); });
            },
            error: function (result, textStatus, errorThrown) {
                $('#script-warning').html(result + " -- " + textStatus + " -- " + errorThrown);
                $('#script-warning').show();
            }
        }).done(function (dummy) { fechaLoading(); });

}

function setStatusEquipamento(pCodigoEquipamento, pNomeDiv, pObjeto, pCodigoStatus) {
    $.ajax({
        type: "POST",
        url: "protocolo.aspx",
        dataType: "html",
        data: {
            funcao: 'setStatusEquipamento',
            pCodigoEquipamento: pCodigoEquipamento,
            pCodigoStatus: pCodigoStatus
        },
        async: false,
        success: function (result) {
            if (result == 'efetuado') {
                if (pNomeDiv != '') {
                    $("#" + pNomeDiv + ">.quantidadeEstoque").html($("#" + pNomeDiv + ">.quantidadeEstoque").html() - 1);

                    if ($("#quantidadeTotal").html() > 0)
                        $("#quantidadeTotal").html($("#quantidadeTotal").html() - 1);

                    if ($("#" + pNomeDiv + ">.quantidadeEstoque").html() <= 0)
                        $("#" + pNomeDiv).addClass("noDisplay");

                }
                pObjeto.addClass("noVisibility");
            }
            else {
                alert(result);
            }
        },
        error: function (result, textStatus, errorThrown) {
            alert(textStatus + " -- " + errorThrown);
        }
    });
}
function setProtocoloTodos() {
    if (confirm("Marcar todos?")) {
        $("#caixinhaDetalhe>div").each(function (index) {
            $(this).find("a").click();            
        });
    }

    $("#caixinhaReposicao>div").addClass("noDisplay");
    $("#quantidadeTotal").html("0");

    alert("Processamento Concluido");
}
function Pesquisa(pObjeto) {

    var iConteudo = pObjeto.val();
    var iAchados = 0;
    var iContador = 0;

    $('#caixinhaDetalhe>div').each(function () {
        iContador++;
        $(this).removeClass("noDisplay");
    });

    if (iConteudo == "")
        return;

    $('#caixinhaDetalhe>div').each(function () {
        var isFound = $(this).html().indexOf(iConteudo);
        if (isFound < 0) {
            iContador--;
            $(this).addClass("noDisplay");
        }
        else {
            iAchados++;
            iObjeto = $(this);
        }
    });
    /*
    if ( iAchados == 1 ) {
        if (!$(iObjeto).find($(".botaoFlat")).hasClass("noVisibility")) {
            $(iObjeto).find($(".botaoFlat")).click();
            pObjeto.val("");
            Pesquisa(pObjeto);
        }
    }*/

    $("#modalContent>#conteudoTosco>.caixa>.tituloTabelas>#quantidadeTotal").html(iContador);
}
function getEstoque(pCodigoLoja, pNomeLoja) {
    $.ajax({
        type: "POST",
        url: "tabelas.aspx",
        dataType: "html",
        data: { pCodigoLoja: pCodigoLoja },
        success: function (result) {
            $('#estoqueMaster').html($("<div>").html(result).find('#estoqueMaster'));
            $('#lbFranquia').html('Franquia:' + pNomeLoja);
        },
        error: function (result, textStatus, errorThrown) {
            alert(textStatus + " -- " + errorThrown);
        }
    });

}
function marcarProtocolo(pCodigoLoja) {
    $.ajax({
        type: "POST",
        url: "protocolo.aspx",
        dataType: "html",
        data: {
            pCodigoLoja: pCodigoLoja,
            funcao: "setProtocolo"
        },
        async: false,
        success: function (result) {
            alert(result);
        },
        error: function (result, textStatus, errorThrown) {
            alert(textStatus + " -- " + errorThrown);
        }
    });
}
function getProtocolo(pCodigoLoja) {
    Loading("#loadiv");
    $.ajax({
        type: "POST",
        url: "protocolo.aspx",
        dataType: "html",
        data: { pCodigoLoja: pCodigoLoja },
        success: function (result) {
            $('#estoqueMaster').html($("<div>").html(result).find('#estoqueMaster'));
            $('#lbFranquia').html('Franquia:' + pCodigoLoja);
        },
        error: function (result, textStatus, errorThrown) {
            alert(textStatus + " -- " + errorThrown);
        }
    }).done(function (dummy) { fechaLoading(); });

}
function protocoloKeyPress(e) {
    if (e.keyCode == 13)
        $("#cmdAdicionaEQP").click();
}
function getEquipamento(pCodigoEquipamento) {

    var digitMatch = pCodigoEquipamento.match(/\d+/); // matches one or more digits
    //pCodigoEquipamento = digitMatch[0];

    var isFound = $("#pecasProtocolos").val().indexOf(pCodigoEquipamento);

    if (isFound >= 0) {
        alert("Equipamento já adicionado!");
        return;
    }

    Loading("#loadiv");

    $.ajax({
        type: "POST",
        url: "protocolo.aspx",
        dataType: "html",
        data: { pCodigoEquipamento: pCodigoEquipamento, funcao: "getEquipamento" },
        async: false,
        success: function (result) {
            var iRetorno = result.split(";");
            if (iRetorno[0] == "OK") {

                $("#pecasProtocolos").val($("#pecasProtocolos").val() + pCodigoEquipamento + ";")

                var iHTML = "<div id='" + iRetorno[1] + "'>"
                    + "<div class='codigoEquipamento'>" + pCodigoEquipamento + "</div>"
                    + "<div class='detalheEstoque'>" + iRetorno[2] + "</div>"
                    + "<a href='#' class='botaoFlat vermelho' onclick='javascript:retiraProtocolo(\"" + pCodigoEquipamento + "\",\"" + iRetorno[1] + "\");'> Excluir </a>"
                    + "</div>";

                $("#itensProtocolo").append(iHTML);
            }
            else {
                alert(iRetorno[2]);
            }
        },
        error: function (result, textStatus, errorThrown) {
            alert(textStatus + " -- " + errorThrown);
        }
    }).done(function (dummy) { fechaLoading(); });

    $("#codigoItem").select();
}
function exibirProtocoloMaker() {
    $("#pecasProtocolos").val("");
    criaPopup('#criarProtocolo', true, false, null, true, false);
    $(".modalPrintImg").unbind("click");
    $(".modalPrintImg").click(function () {
        printArea($("#conteudoTosco>.caixa"));
    });
}
function retiraProtocolo(pCodigoEquipamento, pNomeDiv) {
    $("#pecasProtocolos").val($("#pecasProtocolos").val().replace(pCodigoEquipamento + ";", ""));
    $("#" + pNomeDiv).remove();
}
function setProtocolo() {

    if ($("#pecasProtocolos").val() == "") {
        alert("Nenhum equipamento selecionado");
        return;
    }

    if (!confirm("Gerar protocolo para a loja " + $( "#comboCetec option:selected" ).text() + " do tipo " + $( "#comboTipoEstoque option:selected" ).html()+ "?" ) )
        return;

    $.ajax({
        type: "POST",
        url: "protocolo.aspx",
        dataType: "html",
        data: {
            pCodigos: $("#pecasProtocolos").val(),
            funcao: "setProtocolo",
            pCodigoFranquia: $("#comboCetec").val(),
            pTipoEstoque: $("#comboTipoEstoque").val()
        },
        async: false,
        success: function (result) {
            if (result == "OK") {                
                $('#itensProtocolo').html('');
                $('#pecasProtocolos').val('');
                alert("Protocolo gerado!");                
            }
            else {
                alert(result);
            }
            $("#btnProtocolo").click();
        },
        error: function (result, textStatus, errorThrown) {
            alert(textStatus + " -- " + errorThrown);
        }
    }).done(function (dummy) { fechaLoading(); });
}
function getDetalhesProtocolo(pCodigoProtocolo, pCodigoStatus) {
    
    Loading();

    _codigoProtocolo = pCodigoProtocolo;
    _tipoProtocolo = pCodigoStatus;

    $.ajax({
        type: "POST",
        url: "itensProtocolo.aspx",
        dataType: "html",
        data: {
            pCodigoProtocolo: pCodigoProtocolo,
            pCodigoStatus: pCodigoStatus
        },
        async: false,
        success: function (result) {

            criaPopup('#Detalhes', true, false, result, true, false);

            $(".modalPrintImg").unbind("click");
            $(".modalPrintImg").click(function () {
                printArea($("#conteudoTosco>.caixa"));
            });
        },
        error: function (result, textStatus, errorThrown) {
            $('#script-warning').html(result + " -- " + textStatus + " -- " + errorThrown);
            $('#script-warning').show();
        }
    }).done(function (dummy) { fechaLoading(); });
}
function setStatusProtocolo(pCodigoProtocolo, pCodigoStatus) {

    if (!confirm("Alterar protocolo: " + pCodigoProtocolo + "?"))
        return;

    Loading("#loadiv");

    $.ajax({
        type: "POST",
        url: "protocolo.aspx",
        dataType: "html",
        data: {
            pCodigoProtocolo: pCodigoProtocolo,
            pCodigoStatus: pCodigoStatus,
            funcao: "setStatusProtocolo"
        },
        async: false,
        success: function (result) {            
            if (result == "OK") {
                alert('Protocolo alterado');
                closePopup();
                $("#btnProtocolo").click();
            }
            else {
                alert(iRetorno[2]);
            }
        },
        error: function (result, textStatus, errorThrown) {
            alert(textStatus + " -- " + errorThrown);
        }
    }).done(function (dummy) { fechaLoading(); });

}
function recebeItemProtocolo(pCodigoEquipamento, pCodigoProtocolo, pNomeDiv) {

    if (!confirm("Receber item: " + pCodigoEquipamento + " ?"))
        return;

    Loading("#loadiv");

    $.ajax({
        type: "POST",
        url: "protocolo.aspx",
        dataType: "html",
        data: {
            pCodigoProtocolo: pCodigoProtocolo,
            pCodigoEquipamento: pCodigoEquipamento,
            funcao: "recebeItemProtocolo"
        },
        async: true,
        success: function (result) {
            if (result == "OK") {
                $("#" + pNomeDiv).remove();
                $("#btnProtocolo").click();
            }
            else {
                alert(result);
            }
        },
        error: function (result, textStatus, errorThrown) {
            alert(textStatus + " -- " + errorThrown);
        }
    }).done(function (dummy) { fechaLoading(); });

}
function delItemProtocolo(pCodigoEquipamento, pCodigoProtocolo, pNomeDiv) {

    if (!confirm("Excluir item: " + pCodigoEquipamento + " ?"))
        return;

    Loading("#loadiv");

    $.ajax({
        type: "POST",
        url: "protocolo.aspx",
        dataType: "html",
        data: {
            pCodigoEquipamento: pCodigoEquipamento,
            pCodigoProtocolo: pCodigoProtocolo,
            funcao: "delItemProtocolo"
        },
        async: false,
        success: function (result) {
            if (result == "OK") {
                $("#" + pNomeDiv).remove();
                $("#btnProtocolo").click();
            }
            else {
                alert(result);
            }
        },
        error: function (result, textStatus, errorThrown) {
            alert(textStatus + " -- " + errorThrown);
        }
    }).done(function (dummy) { fechaLoading(); });
}

function printArea(div) {

        var oldPage = document.body.innerHTML;

        var iAltura = div.css('height');
        div.css('height', 'auto');

        //Get the HTML of div
        var divElements = div.html();
        //Get the HTML of whole page
        

        //Reset the page's HTML with div's HTML only
        document.body.innerHTML =
          "<html><head><title></title></head><body>" +
          divElements + "</body>";

        //Print Page
        window.print();

        //Restore orignal HTML
        document.body.innerHTML = oldPage;

        div.css('height', iAltura);
        closePopup();
}