

$(document).ready(function () {
    /* Executa a requisição quando o campo CEP perder o foco */
    $('#cep_d').blur(function () {

        /* Configura a requisição AJAX */
        $.ajax({
            url: '_app/Uteis/consultar_cep2.php', /* URL que será chamada */
            type: 'POST', /* Tipo da requisição */
            data: 'cep=' + $('#cep_d').val(), /* dado que será enviado via POST */
            dataType: 'json', /* Tipo de transmissão */
            success: function (data) {
                if (data.sucesso == 1) {
                    $('#rua_d').val(data.rua);
                    $('#bairro_d').val(data.bairro);
                    $('#cidade_d').val(data.cidade);
                    $('#estado_d').val(data.estado);

                    $('#numero').focus();
                }
            }
        });
        return false;
    });
});

