function CallToast(message, flag) {
    $.toast({
        heading: ((flag == 'F') ? "Error" : "Success"),
        text: message,
        icon: ((flag == 'F') ? 'error' : 'success'),
        position: 'top-right',
        hideAfter: 3000,
        stack: false
    })
}
function toggleIcon(e) {
    var a = $(e.target).prev('.panel-heading');
    var b = a.find("svg")[0].classList
    if (b.contains("fa-plus")) {
        $(e.target).prev('.panel-heading').find("svg")[0].classList.remove("fa-plus");
        $(e.target).prev('.panel-heading').find("svg")[0].classList.add("fa-minus");
    }
    else {
        $(e.target).prev('.panel-heading').find("svg")[0].classList.add("fa-plus");
        $(e.target).prev('.panel-heading').find("svg")[0].classList.remove("fa-minus");
    }
    //$(e.target)
    //    .prev('.panel-heading')
    //    .find("svg")
    //    .toggleClass('fa-plus fa-minus');
}
document.addEventListener("DOMContentLoaded", function () {
    $('.panel-group').on('hidden.bs.collapse', toggleIcon);
    $('.panel-group').on('shown.bs.collapse', toggleIcon);
    $("select").multiselect();
})
function GetStates(evt, Id) {
    $.ajax({
        url: '/Setting/GetLocation?countryId=' + $(evt).val() + '&stateId=0',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $("#" + Id).empty();
            var MyData = result;
            var select = document.getElementById(Id);
            //var option = '<option value="0">Please select</option>';
            $.each(MyData, function (i, item) {
                var option = document.createElement("option");
                option.value = item.StateId
                option.text = item.StateName
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
        url: '/Setting/GetLocation?countryId=' + $("#" + controlId).val() + '&stateId=' + $(evt).val(),
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $("#" + Id).empty();
            var MyData = result;
            var select = document.getElementById(Id);
            //var option = '<option value="0">Please select</option>';
            $.each(MyData, function (i, item) {
                var option = document.createElement("option");
                option.value = item.CityId
                option.text = item.CityName
                select.appendChild(option);
            });
            $("#" + Id)[0].sumo.reload();
        },
        async: false,
        processData: false
    });
}

