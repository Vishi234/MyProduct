var columnDefs;
var gridOptions;
var MyData;
var year = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
columnDefs = [
    { headerName: '', field: '', width: 20, cellClass: 'grid-center', suppressFilter: true, cellRenderer: EditButton },
    { headerName: 'Product Name', field: 'PRODUCT_NAME', width: 50, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Product SKU', field: 'PRODUCT_SKU', width: 50, cellClass: 'grid-lef', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Category', field: 'CATEGORY', width: 50, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Color', field: 'COLOR', width: 50, cellClass: 'grid-right', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Brand', field: 'BRAND', width: 50, cellClass: 'grid-center', suppressFilter: true, cellRenderer: StatusRenderer },
    { headerName: 'Size', field: 'SIZE', width: 50, cellClass: 'grid-center', suppressFilter: true, cellRenderer: StatusRenderer },
    { headerName: 'Weight', field: 'WEIGHT', width: 50, cellClass: 'grid-center', suppressFilter: true, cellRenderer: StatusRenderer },
    { headerName: 'Height', field: 'HEIGHT', width: 50, cellClass: 'grid-center', suppressFilter: true, cellRenderer: StatusRenderer },
    { headerName: 'Width', field: 'WIDTH', width: 50, cellClass: 'grid-center', suppressFilter: true, cellRenderer: StatusRenderer },
    { headerName: 'Length', field: 'LENGTH', width: 50, cellClass: 'grid-center', suppressFilter: true, cellRenderer: StatusRenderer },
    { headerName: 'Inventory', field: 'INVENTORY', width: 50, cellClass: 'grid-center', suppressFilter: true, cellRenderer: StatusRenderer },
];
gridOptions = GridInitializer(columnDefs);
document.addEventListener('DOMContentLoaded', function () {
    var gridDiv = document.querySelector('#categroy-grid');
    new agGrid.Grid(gridDiv, gridOptions);
});