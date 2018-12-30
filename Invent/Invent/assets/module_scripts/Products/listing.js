var columnDefs;
var gridOptions;
var MyData;
var SkuData;
var year = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
columnDefs = [
    { headerName: '', field: '', width: 53, cellClass: 'grid-center', suppressFilter: true, checkboxSelection: true, headerCheckboxSelection: true },
    { headerName: 'Action', field: 'action', width: 100, cellClass: 'grid-center', hide: true, suppressFilter: true, cellRenderer: Action },
    { headerName: 'Channel', field: 'CHANNEL_NAME', width: 100, cellClass: 'grid-center', filterParams: { newRowsAction: 'keep' }, cellRenderer: ChannelBack },
    { headerName: 'Sku', field: 'SYSTEM_SKU', width: 250, cellClass: 'grid-center', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Channel Sku', field: 'CHANNEL_SKU', width: 250, cellClass: 'grid-center', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Product ID', field: 'PRODUCT_ID', width: 200, cellClass: 'grid-center', filterParams: { newRowsAction: 'keep' } },
    { headerName: 'Blocked Inventory', field: 'BLOCKED_INVENTORY', width: 150, cellClass: 'grid-center', suppressFilter: true },
    { headerName: 'Inventory Sync', field: 'INVENTORY_SYNC', width: 150, cellClass: 'grid-center', suppressFilter: true, cellRenderer: InventoryBack },
    { headerName: 'Product Is Live', field: 'LIVE', width: 130, cellClass: 'grid-center', suppressFilter: true, cellRenderer: LiveBack }
];

function Action(params) {
    var html = '';
    var data = JSON.stringify(params.data);
    html = "<button type='submit' onclick='LinkNow(" + data + ")' class='btn btn-primary' style='padding: 3px 10px;font-size: 12px;margin-top: 1px;border-radius: 3px;'><i class='fa fa-plug'></i> | Link</button>"
    return html;
}
function LinkNow(data) {
    document.getElementById("lstId").innerHTML = data.PRODUCT_ID;
    document.getElementById("lstNm").innerHTML = convert(data.PRODUCT_NAME);
    document.getElementById("chnm").innerHTML = data.CHANNEL_NAME;
    $("#product-link").modal("show");
    $("#exlst").addClass("exlst-hide");
    $("#linknow").attr("disabled");
    $("#linknow").attr("key", data.LISTING_ID);
    $(".select-default").find("span").html('Select Item to link <i class="fa fa-angle-down"></i>');
    FetchSkus();
}
function convert(string) {
    return string.replace(/&#(?:x([\da-f]+)|(\d+));/ig, function (_, hex, dec) {
        return String.fromCharCode(dec || +('0x' + hex))
    })
}
function LinkListing(id, sku) {
    var obj = {
        listingId: id,
        systemSku: sku
    };
    $.ajax
        ({
            type: 'POST',
            url: '/Products/LinkListing',
            contentType: 'application/json',
            data: JSON.stringify(obj),
            success: function (data) {
                CallToast(data.ERROR_MSG, data.ERROR_FLAG);
                $("#product-link").modal("hide");
                FetchListing('0', '0', '', '', '');
            }
        })
}

function FetchSkus() {
    $.get("/Products/GetSkus", function (data) {
        SkuData = '';
        SkuData = JSON.parse(data);
        $(".select-item>ul").empty();
        var html = '';
        $.each(SkuData, function (i, item) {
            html += "<li onclick='GetValue(this);' value=" + item.VARIANT_SKU + "><span>" + item.PRODUCT_NAME + "</span>";
            html += "<p>(" + item.VARIANT_SKU + ")</p></li>";
        });
        $(".select-item>ul").append(html);
    });
}
function GetValue(evt) {
    var name = $(evt).find("span").text();
    var sku = $(evt).find("p").text();
    $(".select-default").find("span").html(sku.substring(1, sku.length - 1) + '<i class="fa fa-angle-down"></i>');
    $(".select-default").removeClass("sd-active");
    $(".select-item").removeClass("expand");
    $("#exlst").removeClass("exlst-hide");
    document.getElementById("s-lst").innerHTML = sku.substring(1, sku.length - 1);
    document.getElementById("s-sku").innerHTML = convert(name);
    $("#linknow").removeAttr("disabled");
}
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
    gridOptions = GridInitializer(columnDefs);
    new agGrid.Grid(gridDiv, gridOptions);
    FetchListing('1', '1', '', '', '');

    $(".ltm>ul>li>a").click(function () {
        if ($(this).attr("step") == "linked") {
            columnDefs[1].hide = true;
            gridOptions.api.setColumnDefs(columnDefs);
            FetchListing('1', '1', '', '', '');

        }
        else if ($(this).attr("step") == "unlinked") {
            columnDefs[1].hide = false;
            gridOptions.api.setColumnDefs(columnDefs);
            FetchListing('0', '0', '', '', '');
        }
        else {
            FetchListing('1', '1', '', '', '');
        }
    })
    $("#linknow").click(function () {
        var sysSku = document.getElementById("s-lst").innerText;
        var id = $(this).attr("key");
        LinkListing(id, sysSku);
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
