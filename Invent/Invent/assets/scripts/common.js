var count = 0;
function CallToast(message, flag) {
    $.toast({
        heading: ((flag == 'F') ? "Error" : "Success"),
        text: message,
        icon: ((flag == 'F') ? 'error' : 'success'),
        position: 'top-right',
        hideAfter: 10000
    })

}
function ShipAddress(evt) {
    if ($(evt).prop('checked') == true) {
        var addLine1 = $("#Address_1").val();
        var addLine2 = $("#Address_2").val();
        var countryId = $("#CountryId").val();
        var countryText = $("#CountryId option:selected").text();
        var stateId = $("#StateId").val();
        var sateText = $("#StateId option:selected").text();
        var cityId = $("#CityId").val();
        var cityText = $("#CityId option:selected").text();
        var pinCode = $("#Pin_Code").val();
        var phone = $("#Phone").val();

        $("#S_Address_1").val(addLine1);
        $("#S_Address_1").attr("disabled", "disabled");
        $("#S_Address_2").val(addLine2);
        $("#S_Address_2").attr("disabled", "disabled");
        $("#S_CountryId").val(countryId);
        $("#S_CountryId").attr("disabled", "disabled");
        $("#S_CountryId")[0].sumo.reload();
        $("#S_StateId").append("<option value=" + stateId + ">" + sateText + "</option>");
        $("#S_StateId").val(stateId);
        $("#S_StateId").attr("disabled", "disabled");
        $("#S_StateId")[0].sumo.reload();
        $("#S_CityId").append("<option value=" + cityId + ">" + cityText + "</option>");
        $("#S_CityId").val(cityId);
        $("#S_CityId").attr("disabled", "disabled");
        $("#S_CityId")[0].sumo.reload();
        $("#S_Pin_Code").val(pinCode);
        $("#S_Pin_Code").attr("disabled", "disabled");
        $("#S_Phone").val(phone);
        $("#S_Phone").attr("disabled", "disabled");
    }
    else {
        $("#S_Address_1").val('');
        $("#S_Address_1").removeAttr("disabled");
        $("#S_Address_2").val('');
        $("#S_Address_2").removeAttr("disabled");
        $("#S_CountryId").val('');
        $("#S_CountryId").removeAttr("disabled");
        $("#S_CountryId")[0].sumo.reload();
        $("#S_StateId").empty();
        $("#S_StateId").append("<option value='0'>Please select</option>");
        $("#S_StateId").removeAttr("disabled");
        $("#S_StateId")[0].sumo.reload();
        $("#S_CityId").empty();
        $("#S_CityId").append("<option value='0'>Please select</option>");
        $("#S_CityId").removeAttr("disabled");
        $("#S_CityId")[0].sumo.reload();
        $("#S_Pin_Code").val('');
        $("#S_Pin_Code").removeAttr("disabled");
        $("#S_Phone").val('');
        $("#S_Phone").removeAttr("disabled");
    }
}
function GetStates(evt, Id) {
    $.ajax({
        url: '/Configuration/GetStates',
        type: 'POST',
        data: JSON.stringify({ countryId: $(evt).val() }),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $("#" + Id).empty();
            var MyData = result;
            var select = document.getElementById(Id);
            //var option = '<option value="0">Please select</option>';
            $.each(MyData, function (i, item) {
                var option = document.createElement("option");
                option.value = item.Value
                option.text = item.Text
                select.appendChild(option);
            });
            $("#" + Id)[0].sumo.reload();
        },
        async: false,
        processData: false
    });
}
function GetCities(controlId, evt, Id) {
    $.ajax({
        url: '/Configuration/GetCities',
        type: 'POST',
        data: JSON.stringify({ countryId: $("#" + controlId).val(), stateId: $(evt).val() }),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $("#" + Id).empty();
            var MyData = result;
            var select = document.getElementById(Id);
            //var option = '<option value="0">Please select</option>';
            $.each(MyData, function (i, item) {
                var option = document.createElement("option");
                option.value = item.Value
                option.text = item.Text
                select.appendChild(option);
            });
            $("#" + Id)[0].sumo.reload();
        },
        async: false,
        processData: false
    });
}
function OnSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
    if (response.ERROR_FLAG == "S") {
        count++;
    }
    if (parseInt(count) >= 2) {
        window.location.href = "/Configuration/Step_2"
    }

}
function OnFailure(response) {
    alert("Error occured.");
}
