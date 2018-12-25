var count = 1;

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
function GetLocation(countryId, stateId) {
    $.ajax
        ({
            type: "GET",
            url: "/Setting/GetLocation?countryId=" + countryId + "&stateId=" + stateId,
            contentType: "applicaiton/json",
            dataType: "json",
            success: function (result) {
                var MyData = result;
                if (countryId == "0") {
                    $("#CountryId").empty();
                    var select = document.getElementById("CountryId");
                    $.each(MyData, function (i, item) {
                        var option = document.createElement("option");
                        option.value = item.CountryId
                        option.text = item.CountryName
                        select.appendChild(option);
                    });
                    $("#CountryId")[0].sumo.reload();
                }
                if (parseInt(countryId) > 0 && stateId == "0") {
                    $("#StateId").empty();
                    var select = document.getElementById("StateId");
                    $.each(MyData, function (i, item) {
                        var option = document.createElement("option");
                        option.value = item.StateId
                        option.text = item.StateName
                        select.appendChild(option);
                    });
                    $("#StateId")[0].sumo.reload();
                }
                if (parseInt(countryId) > 0 && parseInt(stateId) > 0) {
                    $("#CitId").empty();
                    var select = document.getElementById("CitId");
                    $.each(MyData, function (i, item) {
                        var option = document.createElement("option");
                        option.value = item.CityId
                        option.text = item.CityName
                        select.appendChild(option);
                    });
                    $("#CitId")[0].sumo.reload();
                }
            }
        });
}
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
function OnGenSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
}
function OnAccountSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
    if (response.ERROR_FLAG == "S") {
        document.getElementsByClassName("tab2")[0].children[0].children[0].setAttribute("href", "jacascript:void(0)");
        document.getElementsByClassName("tab3")[0].children[0].children[0].setAttribute("href", "#tab3");
        document.getElementsByClassName("tab3")[0].children[0].children[0].click();
    }

}
function OnBillingSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
    if (response.ERROR_FLAG == "S") {
        window.location.href = "/Configuration/Step_2"
    }
}
function OnFailure(response) {
    alert("Error occured.");
}
function GridInitializer(colDef) {
    var gridOptions = {
        columnDefs: colDef,
        enableSorting: true,
        enableFilter: true,
        rowData: null,
        rowHeight: 33,
        enableCellChangeFlash: true,
        refreshCells: true,
        enableColResize: true,
        colResizeDefault: 'shift',
        enableColResize: true,
        pagination: true,
        paginationPageSize: 20,
        paginationNumberFormatter: function (params) {
            return '[' + params.value.toLocaleString() + ']';
        },
        onGridReady: function (params) {
            //var allColumnIds = [];
            //gridOptions.columnApi.getAllColumns().forEach(function (column) {
            //    allColumnIds.push(column.colId);
            //});
            //gridOptions.columnApi.autoSizeColumns(allColumnIds);
            //params.api.sizeColumnsToFit();
            //setTimeout(function () {
            //    gridOptions.api.resetRowHeights();
            //}, 500);
        },
        //onColumnResized: onColumnResized

    };
    return gridOptions;
}
//function onColumnResized(event) {
//    if (event.finished) {
//        gridOptions.api.resetRowHeights();
//    }
//}
function callRefreshAfterMillis(params, millis, gridApi) {
    setTimeout(function () {
        gridApi.refreshCells(params);
    }, millis);
}
function onPageSizeChanged(newPageSize) {
    var value = document.getElementById('page-size').value;
    gridOptions.api.paginationSetPageSize(Number(value));
}
document.addEventListener('DOMContentLoaded', function () {
    $(".modal").on("hidden.bs.modal", function () {
        $(".nav-tabs li").removeClass("active2");
        $(".nav-tabs li:nth-child(1)").addClass("active2");
        $(".nav-tabs li:nth-child(2)").find("a").addClass("disabled");
        $('.nav-tabs a:first').tab('show')
        $(".tab-content div:nth-child(1)").addClass("in active show");
        $(".tab-content div:nth-child(2)").removeClass("in active show");
    });
    $(".nav-tabs li").click(function () {
        if (!$(this).find("a").hasClass("disabled")) {
            $(".nav-tabs li").removeClass("active2");
            $(this).addClass("active2");
        }
    });

    $(".tm").click(function () {
        if ($(this).find(".toggle-menu").is(":visible")) {
            $(this).find(".toggle-menu").css("display", "none");
        }
        else {
            $(this).find(".toggle-menu").css("display", "block");
        }
    })
});

function OnChannelSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
    if (response.ERROR_FLAG == "S") {
        $(".nav-tabs li:nth-child(1)").removeClass("active2");
        $(".nav-tabs li:nth-child(2)").find("a").removeClass("disabled");
        $(".nav-tabs li:nth-child(2)").addClass("active2");
        $(".tab-content div:nth-child(1)").removeClass("in active show");
        $(".tab-content div:nth-child(2)").addClass("in active show");
    }
}
function OnChannelFailure(response) {
    alert("Error occured.");
}
//Module Like : Setting , Node : Import
function DynamiColDef(module, file, node) {
    var url = "/GridConfiguration/" + module + "/" + file + ".json";
    var columnDef = [];
    $.ajax({
        url: url,
        dataType: 'json',
        async: false,
        success: function (result) {
            var reportJson = result[node];
            $.each(reportJson, function (i, item) {
                columnDef.push(item);
            });
        },
    });
    return columnDef
}