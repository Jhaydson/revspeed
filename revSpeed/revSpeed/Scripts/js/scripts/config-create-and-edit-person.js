$(document).ready(function () {

    $('#Telephones_0__Number').mask('(99) 99999-9999');
    $('#Telephones_1__Number').mask('(99) 99999-9999');

    $("#Clients_TypePerson").change(function () {
        //Variavel que recebe valor do select

        var select = document.getElementById('Clients_TypePerson').value;

        if (select == 1) {
            //TypePerson Selecionado.
            $('#lb-tp').addClass('hide');
            $('#lb-tps').removeClass('hide');

            $('#namelegalp').text("Nome");
            $('#LastName').text("Sobre Nome");
            $('#cpfcnpj').text("Cpf");
            $('#rgeinscricao').text("RG");
            $('#DateNacs').text("Data de Nascimento");

            //Sexo
            $('#Genre').removeClass('hide');
            $('#lb-genre').removeClass('hide');

            //CPF
            $('#bc-cnpj').removeClass('hide');
            $('#Clients_CpfOrCnpj').mask('999.999.999-99');

            //RG
            $('#bc-inscricao').addClass('hide');
            $('#bc-rg').removeClass('hide');

            //Responsável
            $('#bc-resp').addClass('hide');

        } else if (select == 2) {
            //TypePerson Selecionado.
            $('#lb-tp').addClass('hide');
            $('#lb-tps').removeClass('hide');

            $('#namelegalp').text("Razão Social");
            $('#LastName').text("Nome Fantasia");
            $('#cpfcnpj').text("Cnpj");
            $('#rgeinscricao').text("Inscrição Estadual");
            $('#DateNacs').text("Data de Abertura");

            //Sexo
            $('#Genre').addClass('hide');

            //CNPJ
            $('#bc-cnpj').removeClass('hide');
            $('#Clients_CpfOrCnpj').mask('99.999.999/9999-99');

            //Inscrição
            $('#bc-rg').removeClass('hide');

            //Responsável
            $('#bc-resp').removeClass('hide');

        }

    });
});

function AddTel() {
    //Adiciona campos de telephone de acordo com clique no botão.
    $('#contact2').removeClass('hide');
    $('#bt-addTel').addClass('hide');
}


function AddAddress() {
    //Adiciona campos de endereço de acordo com clique no botão.
    if ($('#address2').hasClass('hide')) {
        $('#address2').removeClass('hide');
    } else {
        $('#address3').removeClass('hide');
        $('#bt-addAdd2').addClass('hide');
    };

}

$(document).ready(function () {

    $('#Address_0__ZipCode').mask('99.999-999');
    $('#Address_1__ZipCode').mask('99.999-999');

    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Clients/Create"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    /* Executa a requisição quando o campo CEP perder o foco */
    $('#Address_0__ZipCode').blur(function () {
        /* Configura a requisição AJAX */
        $.ajax({
            url: '@Url.Action("CorreiosBusca", "Clients")',
            type: "GET",
            headers: headersadr,
            contentType: "application/json",
            data: { cep: $("#Address_0__ZipCode").val(), __RequestVerificationToken: token },
            success: function (result) {
                $("#Address_0__Block").val(result[0])
                $("#Address_0__Neighborhood").val(result[1])
                $("#Address_0__City").val(result[2])
                $("#Address_0__State").val(result[3])
            },
            error: function (xhr, exception) {
                alert('Cep não localizado');
            }
        });
        return false;
    });
    $('#Address_1__ZipCode').blur(function () {
        /* Configura a requisição AJAX */
        $.ajax({
            url: '@Url.Action("CorreiosBusca", "Clients")',
            type: "GET",
            headers: headersadr,
            contentType: "application/json",
            data: { cep: $("#Address_1__ZipCode").val(), __RequestVerificationToken: token },
            success: function (result) {
                $("#Address_1__Block").val(result[0])
                $("#Address_1__Neighborhood").val(result[1])
                $("#Address_1__City").val(result[2])
                $("#Address_1__State").val(result[3])
            },
            error: function (xhr, exception) {
                alert('Cep não localizado');
            }
        });
        return false;
    });
    $('#Address_2__ZipCode').blur(function () {
        /* Configura a requisição AJAX */
        $.ajax({
            url: '@Url.Action("CorreiosBusca", "Clients")',
            type: "GET",
            headers: headersadr,
            contentType: "application/json",
            data: { cep: $("#Address_2__ZipCode").val(), __RequestVerificationToken: token },
            success: function (result) {
                $("#Address_2__Block").val(result[0])
                $("#Address_2__Neighborhood").val(result[1])
                $("#Address_2__City").val(result[2])
                $("#Address_2__State").val(result[3])
            },
            error: function (xhr, exception) {
                alert('Cep não localizado');
            }
        });
        return false;
    });
});

$(document).ready(function () {

    var screenWidth = screen.width;
    var screenHeight = screen.height;

    if (screenWidth < 600) {
        //Tipo de Pessoa
        $('#TpPerson').removeClass('s4');
        $('#TpPerson').addClass('s12');

        //Nome
        $('#nomeLegal').removeClass('s6');
        $('#nomeLegal').addClass('s12');

        //SobreNome
        $('#SobreNome').removeClass('s6');
        $('#SobreNome').addClass('s12');

        //Sexo
        $('#Genre').removeClass('s4');
        $('#Genre').addClass('s12');

        //cnpj
        $('#bc-cnpj').removeClass('s4');
        $('#bc-cnpj').addClass('s12');

        //rg
        $('#bc-rg').removeClass('s4');
        $('#bc-rg').addClass('s12');

        //resp
        $('#bc-resp').removeClass('s4');
        $('#bc-resp').addClass('s12');

        //Sexo
        $('#bc-nascimento').removeClass('s4');
        $('#bc-nascimento').addClass('s12');

        //Status Cliente
        $('#statusclient').removeClass('s6');
        $('#statusclient').addClass('s12');

        //res_mov1
        $('#res_mov1').removeClass('s2');
        $('#res_mov1').addClass('s12');

        //number_1
        $('#number_1').removeClass('s4');
        $('#number_1').addClass('s12');

        //res_mov1
        $('#res_mov2').removeClass('s2');
        $('#res_mov2').addClass('s12');

        //number_1
        $('#number_2').removeClass('s4');
        $('#number_2').addClass('s12');

        //number_1
        $('#typ2').removeClass('s4');
        $('#typ2').addClass('s12');
    }


});

