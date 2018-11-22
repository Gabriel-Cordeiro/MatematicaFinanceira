$("#opcoesCalcular").change(function () {
    $("#resultado").remove();
    var selected_option = $('#opcoesCalcular').val();
    var arrayIncludesT = ['2', '3', '4', '5', '8', '9'];
    var arrayIncludesK = ['10', '6'];

    var textParcelaT = '<input required type="number" min="0" id="parcelaT" name="t" class="form-control" placeholder="Nº da parcela">';
    var textParcelaK = '<input required type="number" min="0" id="parcelaK" name="k" class="form-control" placeholder="Nº da parcela final">';

    if (arrayIncludesT.includes(selected_option)) {
        $('#t').html(textParcelaT);
        $("#parcelaK").remove();
    }
    else if (arrayIncludesK.includes(selected_option)) {
        $('#t').html(textParcelaT);
        $('#k').html(textParcelaK);
    }
    else {
        $("#parcelaK").remove();
        $("#parcelaT").remove();
    }
});

$("#TaxaJuros").ready(function () {
    var val = $("#TaxaJuros").val().replace('.', ',');
    $("#TaxaJuros").val(val);
});

$("#tipoSubmit").click(function () {
    $("#opcoesCalcular").removeAttr("required");
    $("#opcoesCalcularSac").removeAttr("required");
    $("#parcelaT").removeAttr("required");
    $("#parcelaK").removeAttr("required");
    var val = $("#TaxaJuros").val().replace('.', ',');
    $("#TaxaJuros").val(val);
});

$("#opcoesCalcularSac").change(function () {
    $("#resultado").remove();
    var selected_option = $('#opcoesCalcularSac').val();
    var arrayIncludesT = ['2', '3', '4', '5', '8', '7'];
    var arrayIncludesK = ['10', '6', '9'];

    var textParcelaT = '<input required type="number" min="0" id="parcelaT" name="t" class="form-control" placeholder="Nº da parcela">';
    var textParcelaK = '<input required type="number" min="0" id="parcelaK" name="k" class="form-control" placeholder="Nº da parcela final">';

    if (arrayIncludesT.includes(selected_option)) {
        $('#t').html(textParcelaT);
        $("#parcelaK").remove();
    }
    else if (arrayIncludesK.includes(selected_option)) {
        $('#t').html(textParcelaT);
        $('#k').html(textParcelaK);
    }
    else {
        $("#parcelaK").remove();
        $("#parcelaT").remove();
    }
});


$("#calcSubmit").click(function () {
    var prazo = parseInt($("#prazo").val());
    var parcelaInformada = !isNaN($("#parcelaT").val()) ? parseInt($("#parcelaT").val()) : 0;
    var parcelaInformadaLimite = !isNaN($("#parcelaK").val()) ? parseInt($("#parcelaK").val()) : 0;

    if (parcelaInformada > prazo || parcelaInformadaLimite > prazo) {
        window.alert("Número de parcela é maior que a informada para financiamento.");
        event.preventDefault(); // Cancel the submit
    }
});



