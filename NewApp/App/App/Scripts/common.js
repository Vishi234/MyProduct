function CallToast(message, flag) {
    var heading = ((flag == 'F') ? "Error" : ((flag == 'V') ? "Information" : "Success"));
    var icon = ((flag == 'F') ? "error" : ((flag == 'V') ? "info" : "success"));
    $.toast({
        heading: heading,
        text: message,
        icon: icon,
        position: 'top-right',
        hideAfter: 3000,
        stack: false
    })

}
function DynamiColDef(module, file, node) {
    var url = "/Configuration/" + module + "/" + file + ".json";
    var columnDef = [];
    $.ajax({
        url: url,
        dataType: 'json',
        async: false,
        success: function (result) {
            var reportJson = result[node];
            $.each(reportJson, function (i, item) {
                columnDef.push(item);
            });
        },
    });
    return columnDef
}
function GridInitializer(colDef,rowdata) {
    var gridOptions = {
        columnDefs: colDef,
        enableSorting: true,
        enableFilter: true,
        rowData: rowdata,
        rowHeight: 33,
        enableCellChangeFlash: true,
        refreshCells: true,
        enableColResize: true,
        colResizeDefault: 'shift',
        enableColResize: true,
        pagination: true,
        paginationPageSize: 20,
        paginationNumberFormatter: function (params) {
            return '[' + params.value.toLocaleString() + ']';
        },
        onGridReady: function (params) {
            var allColumnIds = [];
            gridOptions.columnApi.getAllColumns().forEach(function (column) {
                allColumnIds.push(column.colId);
            });
            gridOptions.columnApi.autoSizeColumns(allColumnIds);
            params.api.sizeColumnsToFit();
        },
    };
    return gridOptions;
}
function callRefreshAfterMillis(params, millis, gridApi) {
    setTimeout(function () {
        gridApi.refreshCells(params);
    }, millis);
}
function onPageSizeChanged(newPageSize) {
    var value = document.getElementById('page-size').value;
    gridOptions.api.paginationSetPageSize(Number(value));
}