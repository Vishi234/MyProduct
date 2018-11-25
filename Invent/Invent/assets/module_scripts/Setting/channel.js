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
    var channel_id = "";
    var data = JSON.stringify(params.data);
    switch (params.data.Ch_Prefix) {
        case "FP":
            {
                color = "#0E76CD";
                className = "flipkart-label";
                channel_id = "flipkart-channel";
            }
            break;
        case "AZ":
            {
                color = "#F79400";
                className = "amazon-label"
                channel_id = "amazon-channel";
            }
            break;

    }
    html = "<a href='javascript:void(0)' onclick='EditChannel(" + data + ")' data-toggle='modal'  data-target='#" + channel_id + "'><span class=" + className + " style='background-color:" + color + "'>" + params.data.Ch_Prefix + "</span> <span class='chNm'>" + params.data.ChannelName + "</span></a>"
    return html;
}
function EditChannel(MyData) {
    var APIData;
    switch (MyData.Ch_Prefix) {
        case "FP":
            {
                $("#fpChId").val(MyData.ChannelId);
                $("#FPFlag").val('E');
                $("#FPChannelName").val(MyData.ChannelName);
                $("#FPLedgerName").val(MyData.LeadgerName);
                $("#FPOrderSync").prop("checked", MyData.OrderSync)
                if (MyData.OrderSync == true) {
                    $(".FPOrder .toggle").removeClass("btn-default off");
                    $(".FPOrder .toggle").addClass("btn-primary on");
                }
                else {
                    $(".FPOrder .toggle").removeClass("btn-primary on");
                    $(".FPOrder .toggle").addClass("btn-default off");
                }
                $("#FPInventorySync").prop("checked", MyData.InventorySync)
                if (MyData.InventorySync == true) {
                    $(".FPInvent .toggle").removeClass("btn-default off");
                    $(".FPInvent .toggle").addClass("btn-primary on");
                }
                else {
                    $(".FPInvent .toggle").removeClass("btn-primary on");
                    $(".FPInvent .toggle").addClass("btn-default off");
                }
                APIData = JSON.parse(MyData.ApiDetails);
                $("#FPApplicationName").val(APIData.ApplicationName);
                $("#FPApplicationId").val(APIData.ApplicationId);
                $("#FPApplicationSecret").val(APIData.ApplicationSecret);
                $("#FPLocationId").val(APIData.LocationId);
                $("#FPUserName").val(APIData.Username);
                $("#FPPassword").val(APIData.Password);
            }
            break;
        case "AZ":
            {
                $("#AzChId").val(MyData.ChannelId);
                $("#AZFlag").val('E');
                $("#AZChannelName").val(MyData.ChannelName);
                $("#AZLedgerName").val(MyData.LeadgerName);
                $("#AZOrderSync").prop("checked", MyData.OrderSync)
                if (MyData.OrderSync == true) {
                    $(".AZOrder .toggle").removeClass("btn-default off");
                    $(".AZOrder .toggle").addClass("btn-primary on");
                }
                else {
                    $(".AZOrder .toggle").removeClass("btn-primary on");
                    $(".AZOrder .toggle").addClass("btn-default off");
                }
                $("#AZInventorySync").prop("checked", MyData.InventorySync)
                if (MyData.InventorySync == true) {
                    $(".AZInvent .toggle").removeClass("btn-default off");
                    $(".AZInvent .toggle").addClass("btn-primary on");
                }
                else {
                    $(".AZInvent .toggle").removeClass("btn-primary on");
                    $(".AZInvent .toggle").addClass("btn-default off");
                }
                APIData = JSON.parse(MyData.ApiDetails);
                $("#AZSellerId").val(APIData.SellerId);
                $("#AZMarketplaceId").val(APIData.MarketplaceId);
                $("#AZAccessKey").val(APIData.AccessKey);
                $("#AZSecretKey").val(APIData.SecretKey);
                $("#AZAuthToken").val(APIData.AuthToken);
                $("#AZUserName").val(APIData.Username);
                $("#AZPassword").val(APIData.Password);
            }
            break;

    }
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
function EditButton(params) {
    var html = '';
    var data = JSON.stringify(params.data);
    html = "<span class='editCss'><a href='javascript:void(0)' onclick='EditCategory(" + data + ")'><img src='../assets/img/edit_icon.svg' alt='Edit'/></a></span>";
    return html;
}
function OnChannelApiSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
    if (response.ERROR_FLAG == "S") {
        $('.nav-tabs a:first').tab('show')
        $(".modal").modal("hide");
        GetChannel();
    }
}
function OnChannelApiFailure(response) {
    alert("Error occured.");
}