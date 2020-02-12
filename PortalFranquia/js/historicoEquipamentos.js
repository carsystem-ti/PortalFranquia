$(document).ready(function () {
    $('#cmdBuscar').on('click', function () { efetuaBusca(); });
    $('#cmdGerencia').on('click', function () { gerencia(); });
    $('#cmdExportar').on('click', function () { efetuaBusca(); });
    $("#corpoGrid").html("<h1 class='semRegistros' >SEM REGISTROS</h1>");
});

function gerencia() {
    //Loading();
    var vinculo = {};
    vinculo.pFuncao = "setVinculo";
    vinculo.pCodigoEquipamento = $("#ContentPlaceHolder1_idEquipamento").val();
    vinculo.pFranquia = $("#ContentPlaceHolder1_codigoFranquia").val();
    vinculo.pVinculo = $("#vinculo").val();
    var dto = { 'Vinculo': vinculo };
    $.ajax({
        type: "POST",
        url: "historicoEquipamento.aspx/GetData",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(dto),
        success: function (response) {
            var names = response.d;
            alert(names);
        },
        failure: function (result, textStatus, errorThrown) {
            $("#script-warning").html(result + " -- " + textStatus + " -- " + errorThrown);
            $("#script-warning").show();
        }
    });
    //.done(function (dummy) { fechaLoading(); });
}

function efetuaBusca() {
    Loading();

    $.ajax({
        type: "POST",
        url: 'historicoEquipamento.aspx',
        dataType: "json",
        data:
            {
                pFuncao: 'getHistorico',
                pCriterio: $("#criterioBusca").val(),
                pTipoBusca: $(".criteriosBusca input[type=radio]:checked").val()
            },
        success: function (result) {

            var itens = [];

            if (result.length == 0) {
                $("#corpoGrid").html("<h1 class='semRegistros' >SEM REGISTROS</h1>");
            }
            else {

                for (var i = 0; i < result.length; i++) {
                    var obj = result[i];

                    itens.push("<tr class='linhaGridOS'>");
                    itens.push("<td class='contrato'><div class='celula dataHora'><div class='tituloCelula'>Data/Hora</div>" + obj.data + " " + obj.hora + "</div></td>");
                    itens.push("<td>");
                    itens.push("<div class='celula prestadora'><div class='tituloCelula'>prestadora </div>" + obj.prestadora + "</div>");
                    itens.push("<div class='celula contrato'><div class='tituloCelula'>Contrato</div>" + obj.contrato + "</div>");
                    itens.push("<div class='celula novoID'><div class='tituloCelula'>Novo ID</div>" + obj.novoID + "</div>");
                    itens.push("<div class='celula velhoID'><div class='tituloCelula'>Velho ID</div>" + obj.velhoID + "</div>");
                    itens.push("<div class='celula servico'><div class='tituloCelula'>servico</div>" + obj.servico + "</div>");
                    itens.push("<div class='celula efetuado'><div class='tituloCelula'>Efetuado</div>" + obj.efetuado + "</div>");
                    itens.push("<div class='celula isFranquia'><div class='tituloCelula'>Venda Franquia</div>" + obj.isFranquia + "</div>");
                    itens.push("<div class='celula troca'><div class='tituloCelula'>Troca</div>" + obj.troca + "</div>");
                    itens.push("<div class='celula emEstoque'><div class='tituloCelula'>Em Estoque</div>" + obj.emEstoque + "</div>");
                    itens.push("<div class='celula semEquipamento'><div class='tituloCelula'>Sem Equipamento</div>" + obj.semEquipamento + "</div>");
                    itens.push("<div class='celula mensagem'><div class='tituloCelula'>Mensagem</div>" + obj.mensagem + "</div>");
                    itens.push("<div class='celula usuario'><div class='tituloCelula'>Sistema/Usuario</div>" + obj.usuario + "</div>");
                    itens.push("</td></tr>");
                }

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