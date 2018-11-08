var gridOptions;
var columnDefs;
var MyData;
var year = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
columnDefs = [
    { headerName: '', field: '', width: 20, pinned: 'left', filterParams: { newRowsAction: 'keep' }, checkboxSelection: true, headerCheckboxSelection: true },
    { headerName: 'Order #', field: 'ORDER_ID', pinned: 'left', width: 90, filterParams: { newRowsAction: 'keep' }, cellRenderer: CreateOrderLink },
    { headerName: 'Channel', field: 'CHANNEL', width: 50, filterParams: { newRowsAction: 'keep' }, cellRenderer: CreateChannelBackground },
    { headerName: 'Product', field: 'TITLE', width: 110, cellClass: 'cell-wrap-text', autoHeight: true, filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Order On', field: 'ORDER_DATE', width: 110, filterParams: { newRowsAction: 'keep' }, cellRenderer: OrderFormat },
    { headerName: 'Shipping Date', field: 'SHIPPING_DATE', width: 100, filterParams: { newRowsAction: 'keep' }, cellRenderer: ShipDateFormat },
    { headerName: 'Amount', field: 'TOTAL_PRICE', width: 50, filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Status', field: 'STATUS', width: 50, filterParams: { newRowsAction: 'keep' } },
];
gridOptions = GridInitializer(columnDefs);
function OrderFormat(params) {
    var html = '';
    var date = params.data.ORDER_DATE.split(" ")[0];
    var time = params.data.ORDER_DATE.split(" ")[1];
    var d = new Date(date);
    html = "<span class='anchorLink'><a href='javascript:Void(0)'>" + year[d.getMonth()] + " " + ((d.getDate().toString().length == 1) ? "0" + d.getDate() : d.getDate()) + ", " + TimeFormat(time) + "</a>"
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
function ShipDateFormat(params) {
    var html = '';
    var date = params.data.SHIPPING_DATE.split(" ")[0];
    var time = params.data.SHIPPING_DATE.split(" ")[1];
    var d = new Date(date);
    html = "<span class='anchorLink'><a href='javascript:Void(0)'>" + year[d.getMonth()] + " " + ((d.getDate().toString().length == 1) ? "0" + d.getDate() : d.getDate()) + ", " + TimeFormat(time) + "</a>"
    return html;
}
function CreateOrderLink(params) {
    var html = '';
    html = "<span class='anchorLink'><a href='javascript:Void(0)'>" + params.data.ORDER_ID + "</a>"
    return html;
}
function CreateChannelBackground(params) {
    var html = '';
    var color = "";
    var className = "";
    if (params.data.CHANNEL == "Flipkart") {
        color = "#0E76CD";
        className = "flipkart-label";
    }
    else if (params.data.CHANNEL == "Amazon") {
        color = "#F79400";
        className = "amazon-label"
    }
    html = "<span class=" + className + " style='background-color:" + color + "'>" + params.data.CHANNEL + "</span>"
    return html;
}
function CreateItemLink(params) {
    var html = '';
    html = "<span class='anchorLink'><a href='javascript:Void(0)'>" + params.data.ITEM_ID + "</a>"
    return html;
}
function onFilterTextBoxChanged() {
    gridOptions.api.setQuickFilter(document.getElementById('filter-text-box').value);
}
function GetOrders(type) {
    $.ajax({
        type: 'POST',
        url: "GetOrders",
        contentType: "application/json",
        data: JSON.stringify({ orderType: type }),
        success: function (data) {
            MyData = JSON.parse(data);
            gridOptions.api.setRowData(MyData);
        }
    });
    return MyData;
}
document.addEventListener('DOMContentLoaded', function () {
    var gridDiv = document.querySelector('#orderGrid');
    new agGrid.Grid(gridDiv, gridOptions);
    MyData = GetOrders("A");

});