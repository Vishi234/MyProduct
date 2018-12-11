function Import(evt) {
    var path = $("#downloadPath").val();
    $("#data-grid").hide();
    $("#importfile").val('');
    $(".error").empty();
    switch ($(evt).val()) {
        case "Category":
            {
                document.getElementById("mdlTtl").innerHTML = "Import Category";
                $("#Import").modal("show");
            }
            break;
        case "PRODUCT_MASTER":
            {
                document.getElementById("mdlTtl").innerHTML = "Channel Product Master";
                $("#Import").modal("show");
                $("#downloadCsv").attr("href", path + $(evt).val() + ".csv")

                gridOptions = GridInitializer(DynamiColDef("Setting", "Import", "PRODUCT_MASTER"));
                $("#data-grid").empty();
                var gridDiv = document.querySelector('#data-grid');
                new agGrid.Grid(gridDiv, gridOptions);
                gridOptions.api.setRowData(null);
            }
            break;
        case "LISTING_MASTER":
            {
                document.getElementById("mdlTtl").innerHTML = "Bulk Listing";
                $("#Import").modal("show");
                $("#downloadCsv").attr("href", path + $(evt).val() + ".csv")

                gridOptions = GridInitializer(DynamiColDef("Setting", "Import", "LISTING_MASTER"));
                $("#data-grid").empty();
                var gridDiv = document.querySelector('#data-grid');
                new agGrid.Grid(gridDiv, gridOptions);
                gridOptions.api.setRowData(null);
            }
    }
}
function InlineLoading(evt, action) {
    if (action == "Show") {
        $(evt).find("span").removeClass("hide");
        $(evt).find("span").addClass("show");
        $(evt).find("span>svg").addClass("fa-spin");
        $(evt).attr("disabled", "disabled");
    }
    else {
        $(evt).find("span").removeClass("show");
        $(evt).find("span").addClass("hide");
        $(evt).find("svg").removeClass("fa-spin");
        $(evt).removeAttr("disabled");
    }
}
function UploadFile(evt) {
    if (window.FormData !== undefined) {
        InlineLoading(evt, 'Show');
        var file = $("#importfile").val();
        if (file.length > 0) {
            var extension = file.replace(/^.*\./, '');
            if (extension.toLowerCase() != "csv") {
                CallToast("Only .CSV format allowed.", "F");
                InlineLoading(evt, 'Hide');
                return false;
            }
        }
        else {
            CallToast("Pelase select file.", "F");
            InlineLoading(evt, 'Hide');
            return false;
        }
        var fileUpload = $("#importfile").get(0);
        var files = fileUpload.files;
        var fileData = new FormData();
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }
        fileData.append('Key', $("#import").val());

        $.ajax({
            url: '/Setting/ImportFile',
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            async: true,
            success: function (result) {
                $(".error").removeClass("success");
                $(".error").removeClass("fail");
                InlineLoading(evt, 'Hide');
                if (result.ERROR_FLAG == undefined) {
                    var MyData = result;
                    if (MyData.length > 0) {
                        if (MyData[0].FLAG == "F") {
                            $("#data-grid").show();
                            gridOptions.api.setRowData(MyData);
                            $(".error").addClass("fail");
                            $(".error").html("<p>" + MyData[0].MESSAGE + "</p>");
                            return false;
                        }
                        else {
                            $("#importfile").val('');
                            $("#data-grid").hide();
                            gridOptions.api.setRowData(null);
                            $(".error").addClass("success");
                            $(".error").html("<p>" + MyData[0].MESSAGE + "</p>");
                            return false;
                        }
                    }
                    else {
                        $("#data-grid").hide();
                    }

                }
                else {
                    $("#data-grid").hide();
                    if (result.ERROR_FLAG == "F") {
                        $(".error").addClass("fail");
                        $(".error").html("<p>" + result.ERROR_MSG + "</p>");
                        return false;
                    }
                    else {
                        $(".error").addClass("success");
                        $(".error").html("<p>" + result.ERROR_MSG + "</p>");
                        return false;
                    }
                }

            },
            error: function (err) {
                return false;
            }
        });
    } else {
        alert("FormData is not supported.");
        InlineLoading(evt, 'Hide');
    }
}

