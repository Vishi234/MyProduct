var columnDefs;
var gridOptions;
var MyData;
var year = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
columnDefs = [
    { headerName: '', field: '', width: 53, cellClass: 'grid-center', suppressFilter: true, checkboxSelection: true, headerCheckboxSelection: true },
    { headerName: 'Channel', field: 'CHANNEL_NAME', width: 100, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' }, cellRenderer: ChannelBack },
    { headerName: 'Sku', field: 'SYSTEM_SKU', width: 250, cellClass: 'grid-lef', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Channel Sku', field: 'CHANNEL_SKU', width: 250, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Product ID', field: 'PRODUCT_ID', width: 200, cellClass: 'grid-right', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Blocked Inventory', field: 'BLOCKED_INVENTORY', width: 150, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Inventory Sync', field: 'INVENTORY_SYNC', width: 150, cellClass: 'grid-center', suppressFilter: true, cellRenderer: InventoryBack },
    { headerName: 'Product Is Live', field: 'LIVE', width: 150, cellClass: 'grid-center', suppressFilter: true, cellRenderer: LiveBack }
];
gridOptions = GridInitializer(columnDefs);
function ChannelBack(params) {
    var html = '';
    if (params.data.CHANNEL_NAME == 'Flipkart') {
        html = '<span class="badge flipkart">Flipkart</span>'
    }
    else if (params.data.CHANNEL_NAME == 'Amazon') {
        html = '<span class="badge amazon">Amazon</span>'
    }
    return html;
}
function EditButton(params) {
    var html = '';
    html = "<span class='editCss'><a href='javascript:void(0)' onclick=''><img src='../assets/img/edit_icon.svg' alt='Edit'/></a></span>";
    return html;
}
function InventoryBack(params) {
    var html = '';
    if (params.data.INVENTORY_SYNC == '0') {
        html = '<span class="badge badge-danger">Disabled</span>'
    }
    else {
        html = '<span class="badge badge-success">Enabled</span>'
    }
    return html;
}
function LiveBack(params) {
    var html = '';
    if (params.data.LIVE == '0') {
        html = '<span class="badge badge-danger">Offline</span>'
    }
    else {
        html = '<span class="badge badge-success">Online</span>'
    }
    return html;
}
function DateBack(params) {
    var html = '';
    var d = new Date(params.data.CREATED_DATE);
    html = "<span class='anchorLink'><a href='javascript:void(0)'>" + year[d.getMonth()] + " " + ((d.getDate().toString().length == 1) ? "0" + d.getDate() : d.getDate()) + "</a>"
    return html;
}
function TimeFormat(timeString) {
    var time = timeString;
    var hours = Number(time.match(/^(\d+)/)[1]);
    var minutes = Number(time.match(/:(\d+)/)[1]);
    if (hours < 12) hours = hours + 12;
    if (hours == 12) hours = hours - 12;
    var sHours = hours.toString();
    var sMinutes = minutes.toString();
    if (hours < 10) sHours = "0" + sHours;
    if (minutes < 10) sMinutes = "0" + sMinutes;
    return sHours + ":" + sMinutes;
}
document.addEventListener('DOMContentLoaded', function () {
    var allColumnIds = [];
    var gridDiv = document.querySelector('#listing-grid');
    new agGrid.Grid(gridDiv, gridOptions);
    FetchListing('1', '1', '', '', '');

    $(".ltm>ul>li>a").click(function () {
        if ($(this).attr("step") == "linked") {
            FetchListing('1', '1', '', '', '');
        }
        else if ($(this).attr("step") == "unlinked") {
            FetchListing('0', '1', '', '', '');
        }
        else {
            FetchListing('1', '1', '', '', '');
        }
    })
});
function FetchListing(isLinked, isEnable, sku, fromDate, toDate) {
    $.ajax({
        type: 'GET',
        url: "GetListing?isLinked=" + isLinked + "&isEnable=" + isEnable + "&sku=" + sku + "&fromDate=" + fromDate + "&toDate=" + toDate,
        contentType: "application/json",
        data: {},
        success: function (data) {
            if (data.length > 0) {
                MyData = JSON.parse(data);
            }
            gridOptions.api.setRowData(MyData);
        }
    });
    return MyData;

}
