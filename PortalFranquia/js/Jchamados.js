//Inserir comentario

$('#btn').click(function () {
    Loading();
    var obj = new Object();
    obj.numeroDetalhes = $('#numero').val();
    obj.numero = $('#numero').val();
    obj.novomen = $('#txtNovo').val();
    obj.antigamen = $('#txtComentarios').val();
    if (obj.novomen != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'DetalhesChamados.aspx/GravaComentarios',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (jsonResult) {
                $('#txtComentarios').val($('#txtNovo').val() + " - " + jsonResult.d + "\n" + $('#txtComentarios').val());
                $("#txtNovo").val('');
                $('.modalCloseImg').click();
                var getSessionValue = $('#sessionInput').val();
                alert('Comentário inserido com sucesso');
                switch (getSessionValue)
                {
                    case 1:
                        $('#imgAbrir').click();
                        break;

                    case 2:
                        $('#imgAbertas').click();
                        break;
                        

                    case 3:
                        $('#imgEmAtendimento').click();
                        break;

                    case 4:
                        $('#imgEncerradas').click();
                        break;

                    case 5:
                        $('#imgCanceladas').click();
                        break;

                    case 6:
                        $('#imgReabertos').click();
                        break;
                }
            },
            Error: function (jsonResult) {
                alert(jsonResult);
            }
        }).done(function (dummy) { fechaLoading(); });
    }
    else {
        ShowPopup("FAVOR INSERIR UM COMENTÁRIO..");
    }
}).done(function (dummy) { fechaLoading(); });


//Aceitar o chamado
function teste() {
    alert('TESTE');
    var obj = new Object();
    obj.numeroDetalhes = $('#numero').val();
    if (obj.numeroDetalhes != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'DetalhesChamados.aspx/AtenderChamado',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (jsonResult) {
                $("#btnAceite").hide();
                //alert(jsonResult.d);
                alert('Comentário aceito com sucesso');
                $('.modalCloseImg').click();
                $('#imgEmAtendimento').click();
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }
        });
    }
    else {
        ShowPopup("Qual número do chamado..?");
    }
}

$('#btnAceite').click(function () {
    //Loading();
    alert('TESTE');
    var obj = new Object();
    obj.numeroDetalhes = $('#numero').val();
    if (obj.numeroDetalhes != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'DetalhesChamados.aspx/AtenderChamado',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (jsonResult) {
                $("#btnAceite").hide();
                //alert(jsonResult.d);
                alert('Comentário aceito com sucesso');
                $('.modalCloseImg').click();
                $('#imgEmAtendimento').click();
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }
        });
    }
    else {
        ShowPopup("Qual número do chamado..?");
    }
}).done(function (dummy) { fechaLoading(); });

//Reabre chamado
$('#btnReabrir').click(function () {
    Loading();
    var obj = new Object();
    obj.numeroDetalhes = $('#numero').val();
    obj.ds_encerramento = $('#txtNovo').val();
    obj.ds_abertura = $('#TxtDescricao').val();
    if (obj.ds_encerramento != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'DetalhesChamados.aspx/ReabrirChamado',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (jsonResult) {
                $("#btnReabrir").hide();
                $('#lblstatus').text("REABERTO");
                alert(jsonResult.d);
                $('.modalCloseImg').click();
                alert('Chamado reaberto com sucesso');
                $('#imgReabertos').click();
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }
        }).done(function (dummy) { fechaLoading(); });
    }
    else {
        ShowPopup("FAVOR INSERIR MOTIVO REABERTURA..");
    }
}).done(function (dummy) { fechaLoading(); });


$('#btnEncerrar').click(function () {
    Loading();
    var obj = new Object();
    obj.numeroDetalhes = $('#numero').val();
    obj.ds_encerramento = $('#txtNovo').val();
    obj.ds_abertura = $('#TxtDescricao').val();
    obj.ds_observacao = $('#txtComentarios').val();
    if (obj.ds_encerramento != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'DetalhesChamados.aspx/FinalizarChamado',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (jsonResult) {
                alert('Chamado encerrado com sucesso');
                $("#btnEncerrar").hide();
                $("#btnAceite").hide();
                $('#lblstatus').text("ENCERRADO");
                $('.modalCloseImg').click();
                $('#imgEncerradas').click();
                
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }
        });
    }
    else {
        ShowPopup("FAVOR DESCREVER SOLUÇÃO ");
    }
}).done(function (dummy) { fechaLoading(); });

function ShowPopup(message) {
    $(function () {
        $("#dialog").html(message);
        $("#dialog").dialog({
            title: "Mensagem importante",
            buttons: {
                Close: function () {
                    $(this).dialog('close');
                }
            },
            modal: true
        });
    });
};
$(function () {
    $("#txtNovo").keyup(function () {
        var limite = 180;
        var tamanho = $(this).val().length;
        if (tamanho > limite)
            tamanho -= 1;
        var contador = limite - tamanho;
        $(".contador").text(contador);
        if (limite >= tamanho) {
            var txt = $(this).val().substring(0, limite);
            $(this).val(txt);
        }
        else if (tamanho > limite)
            $(".contador").css("color", "#FF0000");
    });
});


