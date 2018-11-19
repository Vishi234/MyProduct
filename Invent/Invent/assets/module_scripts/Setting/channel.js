var gridOptions;
var columnDefs;
var MyData;
var year = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
columnDefs = [
    { headerName: 'Channel', field: 'Prefix', width: 50, cellClass: 'grid-left', filterParams: { newRowsAction: 'keep' }, cellRenderer: ChannelIcon },
    { headerName: 'Order Sync', field: 'OrderSync', width: 50, cellClass: 'grid-center', filterParams: { newRowsAction: 'keep' }, cellRenderer: OrderSyncStatus },
    { headerName: 'Inventory Sync', field: 'InventorySync', width: 50, cellClass: 'grid-center', filterParams: { newRowsAction: 'keep' }, cellRenderer: InventorySyncStatus },
    { headerName: 'API Status', field: 'ConnectingStatus', width: 50, cellClass: 'grid-center', filterParams: { newRowsAction: 'keep' }, cellRenderer: ApiStatus },
];
gridOptions = GridInitializer(columnDefs);

function ChannelIcon(params) {
    var html = '';
    var color = "";
    var className = "";
    if (params.data.Ch_Prefix == "FP") {
        color = "#0E76CD";
        className = "flipkart-label";
    }
    else if (params.data.Ch_Prefix == "AZ") {
        color = "#F79400";
        className = "amazon-label"
    }
    html = "<a href='javascript:void(0)'><span class=" + className + " style='background-color:" + color + "'>" + params.data.Ch_Prefix + "</span> <span class='chNm'>" + params.data.ChannelName + "</span></a>"
    return html;
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
function Refresh() {
    GetChannel();
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
    $("#status").prop("checked", record.Status)
    if (record.Status == true) {
        $(".toggle").removeClass("btn-default off");
        $(".toggle").addClass("btn-primary on");
    }
    else {
        $(".toggle").removeClass("btn-primary on");
        $(".toggle").addClass("btn-default off");
    }
    $("#add-category").modal("show");
    $("#btnSveCat").text("Update");
    document.getElementById("mdlTtl").innerText = "Update Category";
}

function OnCatSuccess(response) {
    CallToast(response.ERROR_MSG, response.ERROR_FLAG);
    if (response.ERROR_FLAG == "S") {
        $("#add-category").modal("hide");
        GetChannel();
    }

}
function OnCatFailure(response) {

}