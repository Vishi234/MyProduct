var LocationData;
function Same(evt) {
    if ($(evt).prop('checked') == true) {
        $("#ship-dtl").css("height", "0px");
    }
    else {
        $("#ship-dtl").css("height", "280px");
    }
}

function FilePreview(evt, imgId) {
    var input = evt;
    var url = $(evt).val();
    var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
    if (input.files && input.files[0] && (ext == "gif" || ext == "png" || ext == "jpeg" || ext == "jpg")) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#' + imgId).attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
    else {
        $('#' + imgId).attr('src', '/assets/img/no-image.gif');
    }
}
document.addEventListener('DOMContentLoaded', function () {
    $("#rmvImg").click(function () {
        $.ajax
            ({
                type: 'GET',
                url: "/Setting/RemoveImage",
                data: {},
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data.ERROR_FLAG == "S") {
                        $("#ImageFile").removeAttr("disabled");
                        $("#proimg").attr("src", "/assets/img/no-image.gif");
                        $("#rmvImg").css("display", "none");
                        $("#imgPath").val("");
                    }
                }
            })
    })
    //GetLocation("0", "0");
    Intializer();
});
function Intializer() {
    $.ajax
        ({
            type: "GET",
            url: "/Setting/Initialize",
            contentType: "applicaiton/json",
            dataType: "json",
            success: function (result) {
                var MyData = result;
                $("#CompanyName").val(MyData.COMPANY_NAME);
                $("#DisplayName").val(MyData.DISPLAY_NAME);
                $("#FirstName").val(MyData.FIRST_NAME);
                $("#LastName").val(MyData.LAST_NAME);
                $("#EmailId").val(MyData.EMAIL_ID);
                $("#proimg").attr("src", ((MyData.PROFILE_PIC == "" || MyData.PROFILE_PIC == null) ? "/assets/img/no-image.gif" : "/assets/img/profile-pic/" + MyData.PROFILE_PIC))
                $("#ImageFile").prop("disabled", ((MyData.PROFILE_PIC == "" || MyData.PROFILE_PIC == null) ? false : true));
                $("#imgPath").val(MyData.PROFILE_PIC);
                $("#rmvImg").attr("style", ((MyData.PROFILE_PIC == "" || MyData.PROFILE_PIC == null) ? "display:none;" : "display:block;"));
                $("#Pan").val(MyData.PAN);
                $("#Gstin").val(MyData.GSTIN);
                $("#Tin").val(MyData.TIN);
                $("#Address_1").val(MyData.ADDRESS_LINE_1);
                $("#Address_2").val(MyData.ADDRESS_LINE_2);
                GetLocation("0", "0");
                $("#CountryId").val(MyData.COUNTRY_ID);
                $('#CountryId')[0].sumo.reload();
                GetLocation(MyData.COUNTRY_ID, "0");
                $("#StateId").val(MyData.STATE_ID);
                $('#StateId')[0].sumo.reload();
                GetLocation(MyData.COUNTRY_ID, MyData.STATE_ID);
                $("#CityId").val(MyData.CITY_ID);
                $('#CityId')[0].sumo.reload();
                $("#Pin_Code").val(MyData.PIN_CODE);
                $("#Phone").val(MyData.PHONE);
                $("#S_Address_1").val(MyData.S_ADDRESS_LINE_1);
                $("#S_Address_2").val(MyData.S_ADDRESS_LINE_2);
                $("#S_Country").val(MyData.S_COUNTRY_NAME);
                $("#S_State").val(MyData.S_STATE_NAME);
                $("#S_City").val(MyData.S_CITY_NAME);
                $("#S_Pin_Code").val(MyData.S_PIN_CODE);
                $("#S_Phone").val(MyData.S_PHONE);
                $("#OldPassword").val(MyData.PASSWORD)
            }

        })
}
function UploadLogo() {
    if (window.FormData !== undefined) {

        var fileUpload = $("#ImageFile").get(0);
        var files = fileUpload.files;

        // Create FormData object  
        var fileData = new FormData();

        // Looping over all files and add it to FormData object  
        for (var i = 0; i < files.length; i++) {
            fileData.append(files[i].name, files[i]);
        }
        // fileData.append('username', ‘Manas’);  

        $.ajax({
            url: '/Setting/UploadLogo',
            type: "POST",
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: fileData,
            async: true,
            success: function (result) {
                $("#imgPath").val(result);
            },
            error: function (err) {
                return false;
            }
        });
    } else {
        alert("FormData is not supported.");
    }
}
function OnGenSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
    if (response.ERROR_FLAG == "S") {
        Intializer();
    }

}
function OnGenFailure(response) {

}
function OnAuthSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
    if (response.ERROR_FLAG == "S") {
        window.location.href = "/Auth/Login";
    }

}
function OnAuthFailure(response) {

}
function OnChannelApiSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
    if (response.ERROR_FLAG == "S") {
        $(".modal").modal("hide");
    }
}
function OnChannelApiFailure(response) {
    alert("Error occured.");
}