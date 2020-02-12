
var perSemEfeito;
var perNomeDiv;

function showPopup(pOpcoes) {
    criaPopup(pOpcoes.nomeDiv, pOpcoes.botaoFechar, pOpcoes.semFundo, pOpcoes.conteudoHTML, pOpcoes.temPrint, pOpcoes.semEfeito, pOpcoes.funcaoSaida, pOpcoes.botaoEmail, pOpcoes.funcaoEmail, pOpcoes.funcaoPrint);
}

function criaPopup(nomeDiv, botaoFechar, semFundo, conteudoHTML, temPrint, semEfeito, funcaoSaida, botaoEmail, funcaoEmail, funcaoPrint) {

    perSemEfeito = semEfeito;
    
    $('#allModal').remove();

    $("body").append('<div id="allModal"></div>');
    $("#allModal").append('<div class="modal-overlay" id="kModalOverlay"></div>');
    $("#allModal").append('<div id="box"></div>');

    var cssDireita = -15;

    if (semFundo == true) {
        $("#box").addClass("box2");
    }
    else {
        $("#box").addClass("box");
    }

    $("#box").hide();

    if (conteudoHTML != null) {
        $("#box").append('<div id="modalContent"></div>');
        $("#modalContent").append("<div id='conteudoTosco'></div>");
        $("#conteudoTosco").append(conteudoHTML);
    }
    else {
        $("#box").append('<div id="modalContent"></div>');
        $("#modalContent").append($(nomeDiv).html());
        perNomeDiv = nomeDiv;
        $(nomeDiv).html("");
    }

    if (botaoFechar == true || botaoFechar == null) {
        $("#box").append('<div class="modalCloseImg"></div>');

        $('.modalCloseImg').css('right', cssDireita);
        cssDireita += 37;

        $(".modalCloseImg").click(function (event) {

            if (typeof funcaoSaida == "function") 
                closePopup(semEfeito, funcaoSaida());
            else
                closePopup();
        });
    }

    if (temPrint == true) {
        $("#box").append('<div class="modalPrintImg"></div>');

        $('.modalPrintImg').css('right', cssDireita);
        cssDireita += 37;

        $(".modalPrintImg").click(function (event) {
            if (typeof funcaoPrint == "function")
                funcaoPrint();
        });
    }

    if (botaoEmail == true) {
        $("#box").append('<div class="modalEmailImg"></div>');

        $('.modalEmailImg').css('right', cssDireita);
        cssDireita += 37;
        if (typeof funcaoEmail == "function") {
            $(".modalEmailImg").on('click', function (event) {                
                funcaoEmail();
            });
        }
    }


    //redimensiona(nomeDiv);
    $("#box").centralize();

    if (semEfeito == true) {
        $("#box").show();
    }
    else {
        $('.modalPrintImg').hide();
        $('.modalCloseImg').hide();
        $("#box").slideDown(100, function () {
            $('.modalCloseImg').show();
            if (temPrint == true)
                $('.modalPrintImg').show();
        });
    }

    $("#allModal *").on('click', function (event) { event.stopPropagation(); });
}

function redimensiona(nomeDiv) {

    if ($(nomeDiv).width() == 0) {
        $("#modalContent").width(804);
    }
    else {
        $("#modalContent").width($(nomeDiv).width());
    }

    if ($(nomeDiv).height() == 0) {
        $("#modalContent").height(190);
    }
    else {
        $("#modalContent").height($(nomeDiv).height());
    }

    $("#box").height($("#modalContent").height());
    $("#box").width($("#modalContent").width());

    //window.setTimeout(function () { $("#box").centralize(); }, 1500);
    //window.setTimeout(function () { alert("foi"); }, 2000);
    $("#box").centralize();
}

function closePopup(semEfeito, funcaoSaida) {

    if (semEfeito == null)
        semEfeito = perSemEfeito;

    $(perNomeDiv).html($("#modalContent").html());

    $('.modalCloseImg').hide();
    $('.modalPrintImg').hide();

    if (semEfeito == true) {
        $("#box").fadeOut('fast', function () {
            $('#kModalOverlay').fadeOut('fast', function () {
                $('#allModal').remove();

                if (typeof funcaoSaida == "function") {
                    funcaoSaida();
                }
            })
        });
    }
    else {
        $("#box").slideUp(100, function () {
            $('#kModalOverlay').fadeOut('slow', function () {
                $('#allModal').remove();

                if (typeof funcaoSaida == "function") {
                    funcaoSaida();
                }
            })
        });
    }
}


function Loading(nomeDiv) {
    $('#allLoading').remove();

    $("body").append('<div id="allLoading"></div>');
    $("#allLoading").append('<div class="modal-overlay-loading" id="kModalOverlay"></div>');
    $("#allLoading").append('<div id="caixaLoading"></div>');

    $("#caixaLoading").addClass("boxLoading");

    $("#caixaLoading").hide();

    $("#caixaLoading").append('<div id="loadingContent"></div>');

    $("#loadingContent").append('<div id="loadiv"><h5 style="text-align:center;">Carregando...<br/><div class="loading"></div></h5></div>');

    $("#caixaLoading").centralize();

    $("#caixaLoading").show();
}
function fechaLoading() {
    $('#allLoading').remove();
}