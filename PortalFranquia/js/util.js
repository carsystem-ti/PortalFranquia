function checkEmail(email) {

    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if ((email.value != "") && (!filter.test(email.value))) {
        alert('Formato de e-mail inválido !');
        email.focus();
        return false;
    }
}

//valida o CPF 
function ValidarCPF(cpf) {

    var soma;
    var resto;
    var i;

    if ((cpf.length != 11) ||
        (cpf == "00000000000") || (cpf == "11111111111") ||
        (cpf == "22222222222") || (cpf == "33333333333") ||
        (cpf == "44444444444") || (cpf == "55555555555") ||
        (cpf == "66666666666") || (cpf == "77777777777") ||
        (cpf == "88888888888") || (cpf == "99999999999")) {
        return false;
    }

    soma = 0;

    for (i = 1; i <= 9; i++) {
        soma += Math.floor(cpf.charAt(i - 1)) * (11 - i);
    }

    resto = 11 - (soma - (Math.floor(soma / 11) * 11));

    if ((resto == 10) || (resto == 11)) {
        resto = 0;
    }

    if (resto != Math.floor(cpf.charAt(9))) {
        return false;
    }

    soma = 0;

    for (i = 1; i <= 10; i++) {
        soma += cpf.charAt(i - 1) * (12 - i);
    }

    resto = 11 - (soma - (Math.floor(soma / 11) * 11));

    if ((resto == 10) || (resto == 11)) {
        resto = 0;
    }

    if (resto != Math.floor(cpf.charAt(10))) {
        return false;
    }

    return true;
}

// valida o CNPJ
function ValidarCNPJ(cnpj) {

    var valida = new Array(6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2);
    var dig1 = new Number;
    var dig2 = new Number;

    var digito = new Number(eval(cnpj.charAt(12) + cnpj.charAt(13)));

    for (i = 0; i < valida.length; i++) {
        dig1 += (i > 0 ? (cnpj.charAt(i - 1) * valida[i]) : 0);
        dig2 += cnpj.charAt(i) * valida[i];
    }
    dig1 = (((dig1 % 11) < 2) ? 0 : (11 - (dig1 % 11)));
    dig2 = (((dig2 % 11) < 2) ? 0 : (11 - (dig2 % 11)));

    if (((dig1 * 10) + dig2) != digito)
        return false;
    else
        return true;
}

// valida o CPF ou CNPJ e devolve o valor correto com a mascara em caso de erro devolve "ERROR"
function ValidaMascaraCPFCNPJ(CPFCNPJ) {
    // Valida o CPF
    if (CPFCNPJ.length == 11) {
        if (ValidarCPF(CPFCNPJ))
            return CPFCNPJ.substring(0, 3) + "." + CPFCNPJ.substring(3, 6) + "." + CPFCNPJ.substring(6, 9) + "-" + CPFCNPJ.substring(9, 11)
        else
            return "ERROR";
    }
    // Valida o CNPJ
    else {
        if (ValidarCNPJ(CPFCNPJ))
            return CPFCNPJ.substring(0, 2) + "." + CPFCNPJ.substring(2, 5) + "." + CPFCNPJ.substring(5, 8) + "/" + CPFCNPJ.substring(8, 12) + "-" + CPFCNPJ.substring(12, 14) 
        else
            return "ERROR";
    }
}

// Recebe um input type text com o valor do CPF ou CNPJ e devolve o valor mascarado ou dá um alert em caso de erro
function TrataCPFCNPJ(CPFCNPJ) {
    if (CPFCNPJ.value.length > 10) {
        aux = ValidaMascaraCPFCNPJ(CPFCNPJ.value);
        if (aux == "ERROR") {
            CPFCNPJ.focus();
            alert("CPF ou CNPJ inválido !");
        }
        else
            CPFCNPJ.value = aux;
    }
}

