function Import(evt) {
    var path = $("#downloadPath").val();
    switch ($(evt).val()) {
        case "Category":
            {
                document.getElementById("mdlTtl").innerHTML = "Import Category";
                $("#Import").modal("show");
            }
            break;
        case "ITEM_MASTER":
            {
                document.getElementById("mdlTtl").innerHTML = "Channel Item Master";
                $("#Import").modal("show");
                $("#downloadCsv").attr("href", path + $(evt).val() + ".csv")

                gridOptions = GridInitializer(DynamiColDef("Setting", "Import", "ITEM_MASTER"));
                $("#data-grid").empty();
                var gridDiv = document.querySelector('#data-grid');
                new agGrid.Grid(gridDiv, gridOptions);
                gridOptions.api.setRowData(null);
            }
    }
}

function UploadFile() {
    if (window.FormData !== undefined) {

        var file = $("#importfile").val();
        if (file.length > 0) {
            var extension = file.replace(/^.*\./, '');
            if (extension.toLowerCase() != "csv") {
                CallToast("Only .CSV format allowed.", "F");
                return false;
            }
        }
        else {
            CallToast("Pelase select file.", "F");
            return false;
        }
        var fileUpload = $("#importfile").get(0);
        var files = fileUpload.files;

        // Create FormData object  
        var fileData = new FormData();

        // Looping over all files and add it to FormData object  
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
                if (result.ERROR_FLAG == undefined) {
                    var MyData = result;
                    gridOptions.api.setRowData(MyData);
                    if (MyData[0].FLAG == "F") {
                        $(".error").addClass("fail");
                        $(".error").html("<p>" + MyData[0].MESSAGE + "</p>");
                        return false;
                    }
                    else {
                        $(".error").addClass("success");
                        $(".error").html("<p>" + MyData[0].MESSAGE + "</p>");
                        return false;
                    }
                }
                else {
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


                //CallToast(result.ERROR_MSG, result.ERROR_FLAG);
                // $("#imgPath").val(result);
            },
            error: function (err) {
                return false;
            }
        });
    } else {
        alert("FormData is not supported.");
    }
}

