$(document).ready(function () {
    //Chamadas
        $("#btnGeraContrato").hide();
        $('#btnConsultaDados').on('click', function () { RetornaDados(); });
        $('#btnConsultaPlaca').on('click', function () { ValidaPlaca(); });
        $('#btnGeraContrato').on('click', function () { set_Contrato(); });
        $('#btnImprimir').on('click', function () { Boleto(); });
        //$('#slcprodutos').optionsValues('click', function () { teste(); });
    //Fim dos Metodos.

    //Mascarras
    $('#txtCep').mask('99999-999');
    $('#txtDataNascimento').mask('99/99/9999');
    

    //Fim das Macarras
});
function myfunction() {

}
function RetornaDados()
{
    var obj = new Object();
    obj.tpFiltro = $("#dropFiltro").val();
    obj._param = $("#ContentPlaceHolder1_txtFiltro").val();
    if (obj._param != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'VendaVourcher.aspx/getDados',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                var retorno = JSON.parse(response.d);
                
                if (retorno.length > 0) {
                    tabelaContratosEncontrados(retorno);
                   getProdutosVourcher(retorno[0].id_pedido);
                   $("#btnGeraContrato").hide();
                   $("#Button1").hide();
                   
                   getCores();
                   getPedidosGeral(retorno[0].id_pedido, obj.tpFiltro);
                }
            },  
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }
        });
    }
    else {
        alert("Qual número do chamado..?");
    }
}
function getProdutosVourcher(pedido) {
    var obj = new Object();
    var dados = {};
    obj.id_pedido = pedido;
    if (obj.id_pedido != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'VendaVourcher.aspx/Veiculos',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                dados = JSON.parse(response.d);

                var optionsValues = '<select id=slcprodutos name="slcprodutos"  style="width:260px;height:28px">';
                optionsValues += '<option value="' + 0 + '">' + 'SELECIONE' + '</option>';
                $.each(dados, function (i, valor) {
                    optionsValues += '<option value="' + valor.id_veiculo + '">' + valor.ds_produto + '</option>';
                });
                optionsValues += '</select>';
                var options = $('#slcprodutos');
                options.replaceWith(optionsValues);
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }
        });
    }
    else {
       
    }
}
function getCores() {
    var obj = new Object();
    var getCores = {};
    obj.id_pedido = $("#txtNumeroPedido").val();
    if (obj.id_pedido != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'VendaVourcher.aspx/getAutoCores',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                getCores = JSON.parse(response.d);
                var optionsValues = '<select id=slcCores name="slcCores"  style="width:140px;height:28px">';
                optionsValues += '<option value="' + 0 + '">' + 'SELECIONE' + '</option>';
                $.each(getCores, function (i, valor) {
                    optionsValues += '<option value="' + valor.ds_cores + '">' + valor.ds_cores + '</option>';
                });
                optionsValues += '</select>';
                var options = $('#slcCores');
                options.replaceWith(optionsValues);
                
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }
        });
    }
    else {
        alert('Favor preencher todos os dados');
    }
}
function getItensVourcher() {
    var obj = new Object();
    var getdados = {};
    obj.tipo = 1;
    obj.id_pedido = $("#txtNumeroPedido").val();
    obj.id_veiculo =  $("#slcprodutos").val();
    if (obj.id_pedido != "" && obj.id_veiculo != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'VendaVourcher.aspx/ItensProduto',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                getdados = JSON.parse(response.d);

                if (getdados[0].nr_contrato > 0) {
                    $("#btnGeraContrato").hide();
                    $("#txtPlaca").prop("disabled", true);
                    $("#Button1").show();
                    
                }
                else {
                    
                    $("#txtPlaca").prop("disabled", false);
                    $("#btnGeraContrato").show();
                    $("#Button1").hide();
                }
               tabelaItensEncontrados(getdados);
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }
        });
    }
    else {
        alert('Favor preencher todos os dados');
    }
}
function getPedidosGeral(id_pedido,tp_filtro) {
    var obj = new Object();
    var getdados = {};
    obj.tipo = tp_filtro;
    obj.pedido = id_pedido;
    obj.id_veiculo = $("#slcprodutos").val();
    if (obj.id_veiculo == 0)
    {
        obj.tipo = 3;
    }
    obj._fitro = $("#ContentPlaceHolder1_txtFiltro").val();
    if (obj.pedido != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'VendaVourcher.aspx/ItensGeralProduto',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                getdados = JSON.parse(response.d);
              tabelaItensEncontrados(getdados);
            },
            error: function () {
               // alert("aqui caiu erro");
            }
        });
    }
    else {
        alert('Favor preencher todos os dados');
    }
}
function ValidaPlaca() {
    var obj = new Object();
    obj.tipo = 1;
    obj.ds_placa = $("#txtPlaca").val();
    var dt_nascimento = $("#txtDataNascimento").val();
    var sexo = $("#dropsexo").val();
    var id_produto = $("#slcprodutos").val();
    var cores = $("#slcCores option:selected").text();
    var ds_combustivel = $("#slcCombustivel option:selected").text();
    var ds_renavan = $("#txtRenavan").val();
    var ds_chassi = $("#txtChassi").val();
    if (obj.ds_placa != "" && dt_nascimento != "" && sexo != "0" && parseInt(id_produto) > 0 && cores != "SELECIONE" && ds_combustivel != "SELECIONE" && ds_renavan != "" && ds_chassi != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'VendaVourcher.aspx/ValidaPlaca',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                var retorno = JSON.parse(response.d);
                if (retorno > 0) {
                    alert("Placa ja consta em nossa base de dados");
                }
                else {
                    getItensVourcher();
                }
                
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }
        });
    }
    else {

        if (obj.ds_placa == "")
        {
            alert("Favor inserir a Placa");
        }
        if (dt_nascimento == "")
        {
            alert("Favor inserir a Data de Nascimento");
        }
        if (sexo == "0") {
            alert("Favor preencher o campo Sexo");
        }
        if (parseInt(id_produto) == 0) {
            alert("Favor selecione Produto");
        }
        if (cores == "SELECIONE")
        {
            alert("Favor preencher Cor do Veículo");
        }
        if (ds_combustivel == "SELECIONE") {
            alert("Favor preencher Combustivel do Veículo");
        }
        if (ds_renavan == "") {
            alert("Favor preencher Renavan do Veículo");
        }
        if (ds_chassi == "") {
            alert("Favor preencher Chassi do Veículo");
        }
    }
}
function limpaDiv() {
    //$("#contrato").empty();
    $("#contrato").empty();
    
}
function tabelaContratosEncontrados(linhas) {
    $("#txtNumeroPedido").val(linhas[0].id_pedido);
    $("#txtDataPedido").val(linhas[0].dt_pedido);
    $("#txtStatusPedido").val(linhas[0].st_pedido);
    $("#txtNome").val(linhas[0].ds_cliente);
    $("#txtCpfCnpj").val(linhas[0].nr_cpfCnpj);
    $("#txtRg").val(linhas[0].nr_rg);
    $("#txtCep").val(linhas[0].nr_cep);
    $("#txtEndereco").val(linhas[0].ds_endereco);
    $("#txtNumero").val(linhas[0].nr_endereco);
    $("#txtComplemento").val(linhas[0].ds_complemento);
    $("#txtBairro").val(linhas[0].ds_bairro);
    $("#txtCidade").val(linhas[0].ds_cidade);
    $("#txtUF").val(linhas[0].ds_uf);
    $("#txtTelefone").val(linhas[0].nr_telefone);
    $("#txtCelular").val(linhas[0].nr_celular);
    $("#txtEmail").val(linhas[0].ds_email);
    $("#txtMidia").val(linhas[0].cd_midia);
    



}
function tabelaItensEncontrados(linhas) {

    $("#txtFabricante").val(linhas[0].ds_fabricante);
    $("#txtModelo").val(linhas[0].Modelo);
    $("#txtTipoVeiculo").val(linhas[0].ds_tipoVeiculo);
    $("#txtVendedor").val(linhas[0].ds_vendedor);
    $("#txtAno").val(linhas[0].ds_anoVeiculo);
    if (linhas[0].nr_contrato.length > 0)
    {
        $("#Button1").show();
    }
    var linhaTitulo1 = ("<table id='tabela5' data-toggle='table'    class='table'>" +
    "<thead>" +
        "<tr>" +
            "<th>Pedido</th>" +
            "<th>Modelo</th>" +
            "<th>Vendedor</th>" +
            "<th>Tipo</th>" +
            "<th>Produto</th>" +
            "<th>Contrato</th>" +
            "<th>Placa</th>" +
        "</tr>" +
    "</thead>" +
    
            Itens(linhas) +
            "</table>" 

            )
        
        

        var linha = linhas;
        $("#contrato").html(linhaTitulo1 + linha);
}
function Itens(linhas)
{
    var linha=0;

    for (var i = 0; i < linhas.length; i++) {
        
            linha += "<tr><td class='text-center'><label>" + linhas[i].id_pedido + "</label></td>" +
                "<td class='text-center'><label>" + linhas[i].Modelo + "</label></td>" +
                "<td class='text-center'><label>" + linhas[i].ds_vendedor + "</label></td>" +
                "<td class='text-center'><label>" + linhas[i].Tipo + "</label></td>" +
                  "<td class='text-center'><label>" + linhas[i].ds_produto + "</label></td>" +
                  "<td class='text-center'><label>" + linhas[i].nr_contrato + "</label></td>" +
                  "<td class='text-center'><label>" + linhas[i].ds_placa + "</label></td></tr>"
          }

    return linha;
}
function set_Contrato() {
    var obj = new Object();
    var getRet = {};
    obj.id_veiculo = $("#slcprodutos").val();
    obj.nr_pedido = $("#txtNumeroPedido").val();
    obj.ds_produto = $("#slcprodutos option:selected").text();
    obj.ds_nome = $("#txtNome").val();
    obj.nr_CpfCnpj= $("#txtCpfCnpj").val();
    obj.nr_RG = $("#txtRg").val();
    obj.nr_Cep=$("#txtCep").val();
    obj.ds_endereco = $("#txtEndereco").val();
    obj.nr_residencial = $("#txtNumero").val();
    obj.ds_complemento = $("#txtComplemento").val();
    obj.ds_bairro = $("#txtBairro").val();
    obj.ds_cidade = $("#txtCidade").val();
    obj.ds_uf=$("#txtUF").val();
    obj.ds_telefone = $("#txtTelefone").val();
    obj.ds_celular = $("#txtCelular").val();
    obj.ds_sexo = $("#dropsexo").val();
    obj.ds_placa = $("#txtPlaca").val();
    obj.dt_nascimento = $("#txtDataNascimento").val();
    obj.ds_email = $("#txtEmail").val();
    obj.ds_fabricante = $("#txtFabricante").val();
    obj.tp_Veiculo = $("#txtTipoVeiculo").val();
    obj.ds_modelo = $("#txtModelo").val();
    obj.ds_AnoVeiculo = $("#txtAno").val();
    obj.ds_cores = $("#slcCores option:selected").text();
    obj.ds_combustivel = $("#slcCombustivel option:selected").text();
    obj.ds_renavan = $("#txtRenavan").val();
    obj.ds_chassi = $("#txtChassi").val();
    obj.ds_vendedor = $("#txtVendedor").val();
    obj.ds_midia = $("#txtMidia").val();

    if (obj.nr_pedido != "" && obj.ds_produto != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'VendaVourcher.aspx/setContrato',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {
                alert(response.d);
                RetornaDados();
            },
            error: function () {
                alert("Ocorreu erro entre em contato com Administrador do sistema   !");
            }
        });
    }
    else {
        alert('Favor preencher todos os dados');
    }
}
function Boleto() {
    var obj = new Object();
    
    var dados = {};
    obj.id_pedido = $("#ContentPlaceHolder1_txtFiltro").val();
    obj.boleto = null;
    if (obj.id_pedido != "") {
        var parametros = JSON.stringify(obj);
        $.ajax({
            type: 'post',
            url: 'VendaVourcher.aspx/ImprimiBoleto',
            contentType: "application/json; charset=utf-8",
            data: parametros,
            dataType: "json",
            success: function (response) {

                $("#divBoleto").html(response.d);
              //  imprimirBoleto();

                //if ($(".telaBoleto").html() != null && $(".telaBoleto").html().trim() != '')
                 
            },
            error: function () {
                $("#divBoleto").html(response.d);
            }
        });
    }
    else {

    }
}

function imprimirBoleto() {

    $('.Cabecalho').remove();
    $('body').css('background-color', 'white');
    $('#divBoletos td').css('background-color', 'white');

    $.each($('#divBoletos td'), function (index, value) {
        $(this).addClass('naoComum');
    });

    var iHtmlBoleto = "<div id ='printArea' style='width:921.6px; height:450px;'><div class='impressaoBoleto'>" + $(".Pagina").html() + "</div></div>";

    criaPopup("", true, false, iHtmlBoleto, true, false,
        function () {
            $(".telaBoleto").html('');
        });

    $(".telaBoleto").html('');

    $(".modalPrintImg").click(function (event) {
        $('#' + divBoleto).printElement();
        //event.stopPropagation();
    //    //$("#printArea").printArea();
    //    var conteudo = document.getElementById('divBoleto').innerHTML,
    //tela_impressao = window.open('about:blank');

    //    tela_impressao.document.write(conteudo);
    //    tela_impressao.window.print();
    //    tela_impressao.window.close();
    });
}