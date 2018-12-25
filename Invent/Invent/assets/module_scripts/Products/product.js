var columnDefs;
var gridOptions;
var MyData;
var year = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
columnDefs = [
    { headerName: '', field: '', width: 50, cellClass: 'grid-center', suppressFilter: true, cellRenderer: EditButton },
    { headerName: 'Product Name', field: 'PRODUCT_NAME', width: 300, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Product SKU', field: 'PRODUCT_SKU', width: 300, cellClass: 'grid-lef', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Category', field: 'CATEGORY', width: 120, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Color', field: 'COLOR', width: 120, cellClass: 'grid-right', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Brand', field: 'BRAND', width: 120, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Size', field: 'SIZE', width: 100, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Weight', field: 'WEIGHT', width: 100, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Height', field: 'HEIGHT', width: 100, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Width', field: 'WIDTH', width: 100, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Length', field: 'LENGTH', width: 100, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Inventory', field: 'INVENTORY', width: 100, cellClass: 'grid-center', suppressFilter: true }
];
gridOptions = GridInitializer(columnDefs);
function EditButton(params) {
    var html = '';
    html = "<span class='editCss'><a href='javascript:void(0)' onclick=''><img src='../assets/img/edit_icon.svg' alt='Edit'/></a></span>";
    return html;
}
function onFilterTextBoxChanged() {
    gridOptions.api.setQuickFilter(document.getElementById('filter-text-box').value);
}
document.addEventListener('DOMContentLoaded', function () {
    var allColumnIds = [];
    var gridDiv = document.querySelector('#product-grid');
    new agGrid.Grid(gridDiv, gridOptions);
    FetchProduct('1', "");
    gridOptions.api.setRowData(null);

    $(".ptm>ul>li>a").click(function () {
        if ($(this).attr("step") == "enable") {
            FetchProduct('1', "");
        }
        else if ($(this).attr("step") == "disable") {
            FetchProduct('0', "");
        }
        else {
            FetchProduct('2', "");
        }
    })
});
function FetchProduct(status, productId) {
    $.ajax({
        type: 'GET',
        url: "GetProduct?status=" + status + "&productId=" + productId,
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
