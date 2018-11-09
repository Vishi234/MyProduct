var gridOptions;
var columnDefs;
var MyData;
var year = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
columnDefs = [
    { headerName: '', field: '', width: 20, cellClass: 'grid-center', suppressFilter: true, cellRenderer: EditButton },
    { headerName: 'Category #', field: 'CategoryId', width: 50, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Category Name', field: 'Name', width: 50, cellClass: 'grid-lef', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Code', field: 'Code', width: 50, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Price Range', field: 'PriceRange', width: 50, cellClass: 'grid-right', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Status', field: 'Status', width: 50, cellClass: 'grid-center', suppressFilter: true, cellRenderer: StatusRenderer },
];
gridOptions = GridInitializer(columnDefs);

function StatusRenderer(params) {
    var html = '';
    if (params.data.Status == "0") {
        html = '<span class="badge badge-danger">Disabled</span>'
    }
    else {
        html = '<span class="badge badge-success">Enabled</span>'
    }
    return html;
}
function Refresh() {
    GetCategory();
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
function GetCategory(type) {
    $.ajax({
        type: 'GET',
        url: "GetCategory",
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
    var gridDiv = document.querySelector('#categroy-grid');
    new agGrid.Grid(gridDiv, gridOptions);
    MyData = GetCategory();
    $('#add-category').on('hidden.bs.modal', function () {
        $("#txtCatName").val("");
        $("#txtCode").val("");
        $("#txtPriceRange").val("");
        $("#txtIGST").val("");
        $("#txtCGST").val("");
        $("#txtSGST").val("");
        $("#txtUTGST").val("");
        $("#txtCESS").val("");
        $("#btnSveCat").text("Save");
        document.getElementById("mdlTtl").innerText = "Add Category";
    });

});
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
    $("#add-category").modal("show");
    $("#btnSveCat").text("Update");
    document.getElementById("mdlTtl").innerText = "Update Category";
}

function OnCatSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
    if (response.ERROR_FLAG == "S") {
        $("#add-category").modal("hide");
        GetCategory();
    }

}
function OnCatFailure(response) {

}