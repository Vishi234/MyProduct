var gridOptions;
var columnDefs;
var MyData;
var year = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]

columnDefs = [
    { headerName: 'Channel', field: 'Ch_Prefix', width: 50, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' }, cellRenderer: ChannelIcon },
    { headerName: 'Order Sync', field: 'OrderSync', width: 50, cellClass: 'grid-center', filterParams: { newRowsAction: 'keep' }, cellRenderer: OrderSyncStatus },
    { headerName: 'Inventory Sync', field: 'InventorySync', width: 50, cellClass: 'grid-center', filterParams: { newRowsAction: 'keep' }, cellRenderer: InventorySyncStatus },
    { headerName: 'API Status', field: 'ConnectingStatus', width: 50, cellClass: 'grid-center', filterParams: { newRowsAction: 'keep' }, cellRenderer: ApiStatus },
];
gridOptions = GridInitializer(columnDefs);

function getParameterByName(name) {
    var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
    return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
}
function ChannelIcon(params) {
    var html = '';
    var color = "";
    var className = "";
    if (params.data.Ch_Prefix == "FP") {
        color = "#0E76CD";
        className = "flipkart-label";
    }
    else if (params.data.Ch_Prefix == "AZ") {
        color = "#F79400";
        className = "amazon-label"
    }
    html = "<a href='/Setting/Channel_Detail?Ch=" + params.data.Ch_Prefix + "&Key=" + params.data.ChannelId + "'><span class=" + className + " style='background-color:" + color + "'>" + params.data.Ch_Prefix + "</span> <span class='chNm'>" + params.data.ChannelName + "</span></a>"
    return html;
}
function ApiStatus(params) {
    var html = '';
    if (params.data.ConnectingStatus == false) {
        html = '<span class="badge badge-danger">Disconnected</span>'
    }
    else {
        html = '<span class="badge badge-success">Connected</span>'
    }
    return html;
}
function OrderSyncStatus(params) {
    var html = '';
    if (params.data.OrderSync == false) {
        html = '<span class="badge badge-danger">Disabled</span>'
    }
    else {
        html = '<span class="badge badge-success">Enabled</span>'
    }
    return html;
}
function InventorySyncStatus(params) {
    var html = '';
    if (params.data.InventorySync == false) {
        html = '<span class="badge badge-danger">Disabled</span>'
    }
    else {
        html = '<span class="badge badge-success">Enabled</span>'
    }
    return html;
}

function ChangeFlag() {
    $("#Flag").val("A");
}
function StatusRenderer(params) {
    var html = '';
    if (params.data.Status == false) {
        html = '<span class="badge badge-danger">Disabled</span>'
    }
    else {
        html = '<span class="badge badge-success">Enabled</span>'
    }
    return html;
}
function Refresh() {
    GetChannel();
    scramble();
    var api = gridOptions.api;
    ['CategoryId', 'Name', 'Code', 'PriceRange', 'Status'].forEach(function (col, index) {
        var millis = index * 100;
        var params = {
            force: true,
            columns: [col]
        };
        callRefreshAfterMillis(params, millis, api);
    });
}
function scramble() {
    MyData.forEach(scrambleItem);
}
function scrambleItem(item) {
    ['CategoryId', 'Name', 'Code', 'PriceRange', 'Status'].forEach(function (colId, i) {
        // skip 50% of the cells so updates are random
        if (Math.random() > 0.5) {
            return;
        }
        $.each(MyData, function (i, item) {
            item[colId] = item[colId];
        })

    });
}
function onFilterTextBoxChanged() {
    gridOptions.api.setQuickFilter(document.getElementById('filter-text-box').value);
}
function GetChannel(type) {
    $.ajax({
        type: 'GET',
        url: "GetChannel",
        contentType: "application/json",
        data: {},
        success: function (data) {
            if (data.length > 0) {
                MyData = data
            }
            gridOptions.api.setRowData(MyData);
        }
    });
    return MyData;
}
document.addEventListener('DOMContentLoaded', function () {
    var gridDiv = document.querySelector('#channel-grid');
    new agGrid.Grid(gridDiv, gridOptions);
    MyData = GetChannel();
    GetChannelDetail();
});
function GetChannelDetail() {
    var html = "";
    var type = getParameterByName('Ch')
    switch (type) {
        case "AZ":
            {
                $("#ch-img").attr("src", "~/assets/img/channel-logo/S_Amazon.png");
                $("#summary-div").css("display", "none");
                $("#info-div").css("display", "block");
                html = '';
                html += '<ol>';
                html += '<li>Go to <a href="http://developer.amazonservices.in">http://developer.amazonservices.in</a></li>';
                html += '<li>Click the Sign up for MWS button.</li>';
                html += '<li>Log into your Amazon seller account.</li>';
                html += '<li>Select the following option: <b>"I want to access my Amazon seller account with MWS"</b> and click next.</li>';
                html += '<li>Accept the Amazon MWS License Agreement.</li>';
                html += '<li>Copy the credential and paste it</li>';
                html += '</ol>';
                $("#info-steps").html(html);
            }
            break;
        case "FP":
            {
                $("#ch-img").attr("src", "~/assets/img/channel-logo/S_Flipkart.png");
                $("#summary-div").css("display", "none");
                $("#info-div").css("display", "block");
                html = '';
                html += '<ol>';
                html += '<li>Go to <a href="https://api.flipkart.net/oauth-register/login">https://api.flipkart.net/oauth-register/login</a></li>';
                html += '<li>Sign in using your flipkart seller credentials.</li>';
                html += '<li>On log in, click on "Register New Application"</li>';
                html += '<li>Enter Application name and description as "SellerHub" (or whatever you prefer to identify later)</li>';
                html += '<li>In the newly generated table row copy Application Id and Application Secret and paste it in the corresponding fields above</li>';
                html += '</ol>';
                $("#info-steps").html(html);
            }
    }
}
function EditButton(params) {
    var html = '';
    var data = JSON.stringify(params.data);
    html = "<span class='editCss'><a href='javascript:void(0)' onclick='EditCategory(" + data + ")'><img src='../assets/img/edit_icon.svg' alt='Edit'/></a></span>";
    return html;
}
function EditCategory(record) {
    $("#CategoryId").val(record.CategoryId);
    $("#Flag").val("E");
    $("#txtCatName").val(record.Name);
    $("#txtCode").val(record.Code);
    $("#txtPriceRange").val(record.PriceRange);
    $("#txtIGST").val(record.IGST);
    $("#txtCGST").val(record.CGST);
    $("#txtSGST").val(record.SGST);
    $("#txtUTGST").val(record.UTGST);
    $("#txtCESS").val(record.CESS);
    $("#status").prop("checked", record.Status)
    if (record.Status == true) {
        $(".toggle").removeClass("btn-default off");
        $(".toggle").addClass("btn-primary on");
    }
    else {
        $(".toggle").removeClass("btn-primary on");
        $(".toggle").addClass("btn-default off");
    }
    $("#add-category").modal("show");
    $("#btnSveCat").text("Update");
    document.getElementById("mdlTtl").innerText = "Update Category";
}
function OnCatSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
    if (response.ERROR_FLAG == "S") {
        $("#add-category").modal("hide");
        GetChannel();
    }

}
function OnCatFailure(response) {

}