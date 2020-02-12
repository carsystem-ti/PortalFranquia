$(document).ready(function () {

    $("#pnCancelaOS").hide();
    $("#btCancelaOSRotina").hide();
    $("#pnTrocaID").hide();
    $("#pnEncerramentoOs").hide();
    $("#ctl00$ContentPlaceHolder1$btnEncerrarOs").click(function () { set_encerraOs(); });
    $("#btnteste").click(function () {
        alert('teste');
        //ExcluirMotivo();
    });
    $("#btCancelaOS").click(function () { set_CancelaOs(); });

});
function set_CancelaOs() {
    //Loading();
    alert('TESTE');
    //---------------------------------//---------------------------------------
    //Parametros 
    var id_os = $("#idOSSelecionada").val();
    var ds_motivoCancelamento = $("#ddlMotivoCancelamento option:selected").val();
    var nome = $("#Usuario").val();
    var obj = new Object();
    var dados = {};
    obj.nr_os = id_os;
    obj.usuariologado = nome;
    obj.ds_motivoCancelamento = ds_motivoCancelamento;
    
    
    //---------------------------------//---------------------------------------
    if (obj.nr_os != undefined && obj.nr_os > 0 && obj.ds_motivoCancelamento != undefined && obj.usuariologado != undefined) {

        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'OSsAbertas.aspx/set_CancelaOs',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                if (response.d == 'S') {
                    fechaLoading();
                    $('.modalCloseImg').click();
                    alert('ORDEM DE SERVIÇO CANCELADA COM SUCESSO :' + id_os);
                    myFun(obj.nr_os);
                }
                else
                {
                    fechaLoading();
                    $('.modalCloseImg').click();
                    alert('NÃO CONSEGUIMOS DE SERVIÇO CANCELADA COM SUCESSO :' + id_os);
                    myFun(obj.nr_os);
                }
                
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }

        });
    }
    else {
        $("#dropDetalhesMotivos").empty();
    }
}
function set_encerraOs() {
    //Loading();

    //---------------------------------//---------------------------------------
    //Parametros 
    var id_os = $("#txtIdOs").val();
    var motivo = $("#dropMotivosAtendimento option:selected").text();
    var detalhes = $("#dropDetalhesMotivos option:selected").text();
    var TpEncerramento = document.getElementById("ContentPlaceHolder1_EncerrarOs_cmbID").value;
    var nome = $("#Usuario").val();
    var ds_loja = $("#Cetec").val();
    var Tecnico = $("#dropTecnico option:selected").text();
    
    alert(Tecnico);
   
    var Acao = $("#ContentPlaceHolder1_EncerrarOs_dropAcaoOs option:selected").text();
    var texto = $("#message").val();
    var obj = new Object();
    var dados = {};
    obj.id_status = 1;
    obj.nr_os = $("#txtIdOs").val();
    obj.problemaResolvido = $("#ContentPlaceHolder1_EncerrarOs_slcResolvido option:selected").val();
    obj.ds_medidaAdotada = $("#message").val();
    obj.ds_acaoServico = $("#ContentPlaceHolder1_EncerrarOs_dropAcaoOs option:selected").text();
    obj.ds_trocaID = $("#ContentPlaceHolder1_EncerrarOs_slcpeca option:selected").val();
    obj.ds_resolvidoPor = $("#ContentPlaceHolder1_EncerrarOs_cmbID option:selected").text();
    obj.tecnico = $("#dropTecnico option:selected").val();
    obj.usuariologado = nome;
    obj.ds_empresa = ds_loja;
    //obj.id_detalhesSuporte = $("#dropDetalhesMotivos option:selected").val();
    //---------------------------------//---------------------------------------
    if (obj.id_status != undefined && obj.problemaResolvido != undefined && obj.ds_medidaAdotada != undefined && obj.ds_acaoServico != undefined && obj.ds_trocaID != undefined && obj.ds_resolvidoPor != undefined && obj.tecnico != undefined && obj.ds_empresa != undefined) {

        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'OSsAbertas.aspx/set_EncerraOs',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {

               // alert(response);
                fechaLoading();
                $('.modalCloseImg').click();
                alert('ORDEM DE SERVIÇO ENCERRADA COM SUCESSO :' + id_os);
                myFun(obj.nr_os);
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }

        });
    }
    else {
        $("#dropDetalhesMotivos").empty();
    }
}

function get_Os() {
    Loading();

    //---------------------------------//---------------------------------------
    //Parametros 
    var nr_contrato = document.getElementById("ContentPlaceHolder1_txtPesquisa").value;
// $("#ctl00$ContentPlaceHolder1$txtPesquisa").val();
    var obj = new Object();
    var dados = {};
    obj.nr_contrato = nr_contrato;
    if (obj.nr_contrato != undefined) {

        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'OSsAbertas.aspx/getOs',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                    fechaLoading();
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }

        });
    }
    else {
        $("#dropDetalhesMotivos").empty();
    }
}
function teste() {

alert('teste');
}
function myFun(os) {
            
            
            if (os != null)
                
            window.location.assign("/DevFranquia/modulos/OS/OSsAbertas.aspx");


        }
function CancelaOS(idOS) {
    $("#idOSSelecionada").val(idOS);
    $("#txtIdOsCancela").text(idOS);
    showPopup({ nomeDiv: "#pnCancelaOS", botaoFechar: true, semFundo: false, temPrint: false, semEfeito: false, botaoEmail: false });
   
}
function schedule(selectedValue) {
    //alert(selectedValue);
}
function CarregarMotivos() {
    var obj = new Object();
    var dados = {};
    obj.nr_os = $("#txtIdOs").val();
    if (obj.nr_os > 0) {
       // alert(obj.id);
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'OSsAbertas.aspx/InfoEncerramento',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                dados = JSON.parse(response.d);
                if (dados.length > 0) {
                    var optionsValues = '<select id=dropMotivosAtendimento onchange="CarregarDetalhes()"  class="form-control" name="dropDetalhesMotivos">';
                    optionsValues += '<option value="' + 0 + '">' + 'SELECIONE' + '</option>';
                    $.each(dados, function (i, valor) {
                        optionsValues += '<option value="' + valor.cd_Procedimento + '">' + valor.ds_Procedimento + '</option>';
                    });
                    optionsValues += '</select>';
                    var options = $('#dropMotivosAtendimento');
                    options.replaceWith(optionsValues);
                    $("#dropMotivosAtendimento").show();
                    $("#dropDetalhesMotivos").show();
                    $("#motivoate").show();
                    $("#detmotivo").show();
                    $("#btnEcluir").show();
                }
                else
                {
                    $("#dropMotivosAtendimento").hide();
                    $("#dropDetalhesMotivos").hide();
                    $("#motivoate").hide();
                    $("#detmotivo").hide();
                    $("#btnEcluir").hide();
                    
                }
                
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }

        });
    }
    else
    {
        $("#dropMotivosAtendimento").empty();
    }
}
function Itens() {

    $("#divPrincipal").append("<h1>Título</h1>");

}
function CarregarTecnicos() {
    var obj = new Object();
    var dados = {};
    obj.nr_os =$("#txtIdOs").val();
    if (obj.nr_os  > 0) {
       
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'OSsAbertas.aspx/getTecnicos',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                dados = JSON.parse(response.d);

                var optionsValues = '<select id="dropTecnico"  class="form-control" name="dropTecnico">';
                optionsValues += '<option value="' + 0 + '">' + 'SELECIONE' + '</option>';
                $.each(dados, function (i, valor) {
                    optionsValues += '<option value="' + valor.ds_Instalador + '">' + valor.ds_Instalador + '</option>';
                });
                optionsValues += '</select>';
                var options = $('#dropTecnico');
                options.replaceWith(optionsValues);
                
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }

        });
    }
    else
    {
        $("#dropMotivosAtendimento").empty();
    }
}
function CarregarDetalhes(selectedValue) {
    var obj = new Object();
    var dados = {};
    obj.id = $("#dropMotivosAtendimento").val();
    if (obj.id != 0 && obj.id != "SELECIONE MOTIVO") {
       // alert(obj.id);
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'OSsAbertas.aspx/ItensEncerramento',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                dados = JSON.parse(response.d);
                if (dados.length > 0) {
                    var optionsValues = '<select id=dropDetalhesMotivos class="form-control" onchange="GravaItens()" name="dropDetalhesMotivos">';
                    optionsValues += '<option value="' + 0 + '">' + 'SELECIONE' + '</option>';
                    $.each(dados, function (i, valor) {
                        optionsValues += '<option value="' + valor.Id + '">' + valor.ds_descricao + '</option>';
                    });
                    optionsValues += '</select>';
                    var options = $('#dropDetalhesMotivos');
                    options.replaceWith(optionsValues);
                    $("#dropDetalhesMotivos").show();
                    $("#motivoate").show();
                    $("#detmotivo").show();
                    $("#btnEcluir").show();
                    
                    
                }
                else
                {
                    $("#dropDetalhesMotivos").hide();
                    $("#motivoate").hide();
                    $("#detmotivo").hide();
                    $("#btnEcluir").hide();
                    
                    
                }
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }

        });
    }
    else
    {
        $("#dropDetalhesMotivos").empty();
    }
}
function detalhesOs(nr_os) {
    var obj = new Object();
    var mensagem = {};
    obj.nr_os = nr_os
    if (obj.nr_os != 0 && obj.nr_os != undefined) {
        // alert(obj.id);
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'OSsAbertas.aspx/detalhesOs',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                mensagem = JSON.parse(response.d);
                
               
                var optionsValues = "";
                optionsValues = '<textarea name="ContentPlaceHolder1_messageos" id="ContentPlaceHolder1_messageos" class="form-control" rows="9" cols="25">';
                $.each(mensagem, function (i, valor) {
                    optionsValues += valor.item + "\n";
                });
                optionsValues += '</textarea>';
                var options = $('#ContentPlaceHolder1_messageos');
                options.replaceWith(optionsValues);
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }

        });
    }
    else {
        $("#ContentPlaceHolder1_messageos").empty();
    }
}
function GravaItens() {
    var obj = new Object();
    var retorno = {};
    obj.nr_os = document.getElementById('ContentPlaceHolder1_txtIdOs').value;
    obj.id_motivo = document.getElementById("dropDetalhesMotivos").value;
    var iConfirma = confirm("Deseja realmente inseri este motivo?");
    if (iConfirma == true) {
        if (obj.id_motivo != 0 && obj.id_motivo != undefined && obj.nr_os != undefined) {
            // alert(obj.id);
            var parametros = JSON.stringify(obj);
            $.ajax({
                type: 'post',
                url: 'OSsAbertas.aspx/set_detalhe',
                contentType: "application/json; charset=utf-8",
                data: parametros,
                dataType: "json",
                success: function (response) {
                    retorno = JSON.parse(response.d);


                    var optionsValues = "";
                    optionsValues = '<textarea name="ContentPlaceHolder1_messageos" id="ContentPlaceHolder1_messageos" class="form-control" rows="9" cols="25">';
                    $.each(retorno, function (i, valor) {
                        optionsValues += valor.item + "\n";
                    });
                    optionsValues += '</textarea>';
                    var options = $('#ContentPlaceHolder1_messageos');
                    options.replaceWith(optionsValues);
                },
                error: function () {
                    alert("Ocorreu erro entre em contato com Administrador do sistema   !");
                }

            });
        }
        else {
            $("#ContentPlaceHolder1_messageos").empty();
        }
    }
    else
    {

    }
}
function ExcluirMotivo() {
    var obj = new Object();
    var dados = {};
    obj.nr_os = document.getElementById('ContentPlaceHolder1_txtIdOs').value;
    obj.id_motivo = document.getElementById("dropDetalhesMotivos").value;

    if (obj.id_motivo != 0 && obj.id_motivo != undefined && obj.nr_os != undefined && obj.id_motivo > 0) {
        // alert(obj.id);
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'OSsAbertas.aspx/set_Excluir',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                dados = JSON.parse(response.d);

                var optionsValues = "";
                optionsValues = '<textarea name="ContentPlaceHolder1_messageos" id="ContentPlaceHolder1_messageos" class="form-control" rows="9" cols="25">';
                $.each(retorno, function (i, valor) {
                    optionsValues += valor.item + "\n";
                });
                optionsValues += '</textarea>';
                var options = $('#ContentPlaceHolder1_messageos');
                options.replaceWith(optionsValues);
            },
                
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }

        });
    }
    else {
        $("#ContentPlaceHolder1_messageos").empty();
    }
}
function f1() {
    var cmbValue = document.getElementById("ContentPlaceHolder1_EncerrarOs_cmbID").value;
    var obj = new Object();
    obj.descricao = cmbValue;
    var parametros = JSON.stringify(obj);
    $.ajax({
        type: 'post',
        url: 'OSsAbertas.aspx/atende',
        contentType: "application/json; charset=utf-8",
        data: parametros,
        dataType: "json",
        success: function (jsonResult) {
        CarregarMotivos();
        CarregarTecnicos();
        },
        error: function () {
            alert("Ocorreu erro entre em contato com Administrador do sistema   !");
        }
    });
}
$(function () {
    $("[id*=grid] td").click(function () {
        DisplayDetails($(this).closest("tr"));
    });
});
function DisplayDetails(row) {
    var peca = "";
    peca =  $("td", row).eq(7).html();
    
    
    $("#txtUltimoId").val(peca);
    var texto = "Teste ok id: " + peca + " km [     ] " + " Tensão Bateria [   ] [   ]" + "\n" +
        "Tensão Partida [   ][   ]  " + "Tensão Carga [   ][   ]" + "\n" +
         "Nível Combust. [   ]" + "KM do Veiculo [   ]    " + "\n" + "Varias:    "
        ;

    $("#message").val(texto);
}
function EncerrarOs(idOS) {

    $("#idOSSelecionada").val(idOS);
    $("#txtIdOs").val(idOS);
    
   
   showPopup({ nomeDiv: "#pnEncerramentoOs", botaoFechar: true, semFundo: false, temPrint: false, semEfeito: false, botaoEmail: false });
    $("#idOSSelecionada").val(idOS);    
    $("#txtIdOs").val(idOS);

    
  

detalhesOs(idOS);

}

function TrocaID(strPedido, idEquipamento, strTipoOS) {
    showPopup({ nomeDiv: "#pnTrocaID", botaoFechar: true, semFundo: false, temPrint: false, semEfeito: false, botaoEmail: false });

    $(".alteraIDAtual").val(idEquipamento);

    // Preeenche os tipos de troca
    $.ajax({
                type: 'POST'        
                , url: "InformacoesOS.asmx/getMotivosTroca"
                //, contentType: 'application/json; charset=utf-8'
                , dataType: 'xml'        
                //, data: {}
                , success: function (data, status) {                    
                    $('.ddlMotivoTroca').find('option').remove();
                    $(data).find('RetornoSelect').each(function () {                        
                        $('.ddlMotivoTroca').append('<option value="' + $(this).find('value').text() + '">' + $(this).find('texto').text() + '</option>');
                    });
                }
                , error: function (xmlHttpRequest, status, err) {
                    //Caso ocorra algum erro:
                    alert("Erro !!! 33" + err + status);
                }       
    });

    // Preenche os IDs liberados para essa OS
    $.ajax({
        type: 'POST'
                , url: "InformacoesOS.asmx/getIDLiberados"
        //, contentType: 'application/json; charset=utf-8'
                , dataType: 'xml'
        , data: { Pedido: strPedido, TipoOS: strTipoOS }
                , success: function (data, status) {
                    $('.ddlIDs').find('option').remove();
                    $(data).find('RetornoSelect').each(function () {
                        $('.ddlIDs').append('<option value="' + $(this).find('value').text() + '">' + $(this).find('texto').text() + '</option>');
                    });
                }
                , error: function (xmlHttpRequest, status, err) {
                    //Caso ocorra algum erro:
                    alert("Erro !!! 33" + err + status);
                }
    });

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
}
