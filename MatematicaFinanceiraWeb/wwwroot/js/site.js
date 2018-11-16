$("#opcoesCalcular").change(function () {
    var selected_option = $('#opcoesCalcular').val();
    var arrayIncludesT = ['2', '3', '4', '5', '8', '9'];
    var arrayIncludesK = ['10', '6'];


    if (arrayIncludesT.includes(selected_option)) {
        $('#t').attr('pk', '1').show();
        $('#k').attr('pk', '1').hide();
    }
    else if (arrayIncludesK.includes(selected_option)) {
        $('#t').attr('pk', '1').show();
        $('#k').attr('pk', '1').show();
    }
    else {
        $('#t').attr('pk', '1').hide();
        $('#k').attr('pk', '1').hide();
    }
});

$("#tipoSubmit").click(function () {
    $("#opcoesCalcular").removeAttr("required");
    var prazo = $("#prazo").val();
    var parcelaInformada = $("#parcelaT").val();
    var parcelaInformadaLimite = $("#parcelaK").val();
    console.log(parcelaInformada);
    if (prazo < parcelaInformada || prazo < parcelaInformadaLimite) {
        window.alert("Número de parcela é maior que a informada para financiamento.");
        event.preventDefault(); // Cancel the submit
    }
});



