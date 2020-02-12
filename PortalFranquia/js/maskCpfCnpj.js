function mascara(str) {
    // Caso passe de 14 caracteres será formatado como CNPJ
    if (str.value.length > 14)
        str.value = cnpj(str.value);
        // Caso contrário como CPF
    else
        str.value = cpf(str.value);
}

// Funcao de formatacao CPF
function cpf(valor) {
    valor = valor.replace(/\D/g, "")                    //Remove tudo o que não é dígito
    valor = valor.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
    valor = valor.replace(/(\d{3})(\d)/, "$1.$2")       //Coloca um ponto entre o terceiro e o quarto dígitos
    //de novo (para o segundo bloco de números)
    valor = valor.replace(/(\d{3})(\d{1,2})$/, "$1-$2") //Coloca um hífen entre o terceiro e o quarto dígitos
    return valor;




}

// Funcao de formatacao CNPJ
function cnpj(valor) {
    // Remove qualquer caracter digitado que não seja numero
    valor = valor.replace(/\D/g, "");

    // Adiciona um ponto entre o segundo e o terceiro dígitos
    valor = valor.replace(/^(\d{2})(\d)/, "$1.$2");

    // Adiciona um ponto entre o quinto e o sexto dígitos
    valor = valor.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3");

    // Adiciona uma barra entre o oitavaloro e o nono dígitos
    valor = valor.replace(/\.(\d{3})(\d)/, ".$1/$2");

    // Adiciona um hífen depois do bloco de quatro dígitos
    valor = valor.replace(/(\d{4})(\d)/, "$1-$2");
    return valor;
}
function valida_cpf(valor) {

    // Garante que o valor é uma string
    valor = valor.toString();

    // Remove caracteres inválidos do valor
    valor = valor.replace(/[^0-9]/g, '');


    // Captura os 9 primeiros dígitos do CPF
    // Ex.: 02546288423 = 025462884
    var digitos = valor.substr(0, 9);

    // Faz o cálculo dos 9 primeiros dígitos do CPF para obter o primeiro dígito
    var novo_cpf = calc_digitos_posicoes(digitos);

    // Faz o cálculo dos 10 dígitos do CPF para obter o último dígito
    var novo_cpf = calc_digitos_posicoes(novo_cpf, 11);

    // Verifica se o novo CPF gerado é idêntico ao CPF enviado
    if (novo_cpf === valor) {
        // CPF válido
        return true;
    } else {
        // CPF inválido
        return false;
    }

} // valida_cpf