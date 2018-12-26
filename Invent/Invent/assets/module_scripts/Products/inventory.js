var columnDefs;
var gridOptions;
var MyData;
var count = 0;
var year = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
columnDefs = [
    { headerName: '', field: '', width: 53, cellClass: 'grid-center', suppressFilter: true, checkboxSelection: true, headerCheckboxSelection: true },
    { headerName: 'Product Name', field: 'PRODUCT_NAME', width: 200, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Product Sku', field: 'SYSTEM_SKU', width: 250, cellClass: 'grid-lef', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Shelf', field: 'SHELF', width: 250, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Type', field: 'TYPE', width: 200, cellClass: 'grid-right', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Total', field: 'TOTAL', width: 150, cellClass: 'grid-center', suppressFilter: true, cellRenderer: TotalBack },
    { headerName: 'Available', field: 'AVAILABLE', width: 150, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Block', field: 'BLOCKED_INVENTORY', width: 150, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Size', field: 'SIZE', width: 150, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Brand', field: 'BRAND', width: 150, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Cost', field: 'COST', width: 150, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Height', field: 'HEIGHT', width: 150, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Width', field: 'WIDTH', width: 150, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Length', field: 'LENGTH', width: 150, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Weight', field: 'WEIGHT', width: 150, cellClass: 'grid-center', suppressFilter: true }
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
function TotalBack(param) {
    var html = '';
    var id = count + "txt";
    html = '<input type="text" id=' + id + ' class="customtxt" value=' + param.data.TOTAL + '></input>';
    count++;
    return html;
}
document.addEventListener('DOMContentLoaded', function () {
    var allColumnIds = [];
    var gridDiv = document.querySelector('#inventory-grid');
    new agGrid.Grid(gridDiv, gridOptions);
    count = 0;
    FetchInventory();
    //$(".ltm>ul>li>a").click(function () {
    //    if ($(this).attr("step") == "linked") {
    //        FetchListing('1', '1', '', '', '');
    //    }
    //    else if ($(this).attr("step") == "unlinked") {
    //        FetchListing('0', '1', '', '', '');
    //    }
    //    else {
    //        FetchListing('1', '1', '', '', '');
    //    }
    //})
});
function FetchInventory() {
    $.ajax({
        type: 'GET',
        url: "GetInventory",
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
