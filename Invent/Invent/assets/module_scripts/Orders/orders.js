var gridOptions;
var columnDefs;
var MyData;
columnDefs = [
    { headerName: '', field: '', width: 20, filterParams: { newRowsAction: 'keep' }, checkboxSelection: true, headerCheckboxSelection: true },
    { headerName: 'OrderID', field: 'OrderId', width: 90, filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Item ID', field: 'ItemId', width: 70, filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Channel', field: 'Channel', width: 50, filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Product Info', field: 'ProductInfo', width: 110, cellClass: 'cell-wrap-text', autoHeight: true, filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Order Date', field: 'OrderDate', width: 110, filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Ship Date', field: 'ShipDate', width: 100, filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Amount', field: 'Amount', width: 50, filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Status', field: 'Status', width: 50, filterParams: { newRowsAction: 'keep' } },
];
gridOptions = GridInitializer(columnDefs);


document.addEventListener('DOMContentLoaded', function () {
    //var gridDiv = document.querySelector('#orderGrid');
    //new agGrid.Grid(gridDiv, gridOptions);
    MyData = GetOrders("A");

});
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
            gridOptions.api.setRowData(data);
        }
    });
    return MyData;
}
//$(".orderStatus li a").click(function () {
//    var type = $(this).attr("type");

//});