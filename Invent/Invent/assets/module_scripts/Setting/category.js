var gridOptions;
var columnDefs;
var MyData;
var year = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
columnDefs = [
    { headerName: '', field: '', width: 20, pinned: 'left', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Category #', field: 'ORDER_ID', pinned: 'left', width: 90, filterParams: { newRowsAction: 'keep' }},
    { headerName: 'Catrgory Name', field: 'CHANNEL', width: 50, filterParams: { newRowsAction: 'keep' }},
    { headerName: 'Code', field: 'TITLE', width: 110, cellClass: 'cell-wrap-text', autoHeight: true, filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Created Date', field: 'ORDER_DATE', width: 110, filterParams: { newRowsAction: 'keep' }},
    { headerName: 'Last Modified Date', field: 'SHIPPING_DATE', width: 100, filterParams: { newRowsAction: 'keep' }},
    { headerName: 'Price Range', field: 'TOTAL_PRICE', width: 50, filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Status', field: 'STATUS', width: 50, filterParams: { newRowsAction: 'keep' } },
];
gridOptions = GridInitializer(columnDefs);

function onFilterTextBoxChanged() {
    gridOptions.api.setQuickFilter(document.getElementById('filter-text-box').value);
}
function GetCategory(type) {
    $.ajax({
        type: 'GET',
        url: "GetCategory",
        contentType: "application/json",
        data: {},
        success: function (data) {
            //MyData = JSON.parse(data);
            //gridOptions.api.setRowData(MyData);
        }
    });
    return MyData;
}
document.addEventListener('DOMContentLoaded', function () {
    var gridDiv = document.querySelector('#categroy-grid');
    new agGrid.Grid(gridDiv, gridOptions);
    MyData = GetCategory();


});

function OnCatSuccess(response) {
    alert(response)
}
function OnCatFailure(response) {

}