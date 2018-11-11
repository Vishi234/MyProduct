﻿function Same(evt) {
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
                    }
                }
            })
    })
});
window.addEventListener("submit", function (e) {
    var form = e.target;
    if (form.getAttribute("enctype") === "multipart/form-data") {
        if (form.dataset.ajax) {
            e.preventDefault();
            e.stopImmediatePropagation();
            var xhr = new XMLHttpRequest();
            xhr.open(form.method, form.action);
            xhr.onreadystatechange = function () {
                if (xhr.readyState == 4 && xhr.status == 200) {
                    if (form.dataset.ajaxUpdate) {
                        var updateTarget = document.querySelector(form.dataset.ajaxUpdate);
                        if (updateTarget) {
                            updateTarget.innerHTML = xhr.responseText;
                        }
                    }
                }
            };
            xhr.send(new FormData(form));
        }
    }
}, true);
function OnSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
}
function OnFailure(response) {
    alert("failure");
}