function getCustomerGridSettings() {
 var gridViewSettings = new Array();
 var labelArray = getLabel_Header();
 var CustomerDetails = [
{ headerName: "Edit", field: 'Edit', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: "Customer Name", field: 'id', hide: true, headerTooltip: '', width: 250, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: "Customer Name", field: 'cstNm', hide: false, headerTooltip: '', width: 200, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: "Email Address", field: 'email', hide: false, headerTooltip: '', width: 200, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: "Phone No", field: 'pNo', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: "Mobile No", field: 'mNo', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'},
{ headerName: "Country Name", field: 'cnt', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'},
{ headerName: "State Name", field: 'sta', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'},
{ headerName: "City Name", field: 'cit', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'},
{ headerName: "Address", field: 'add', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'},
{ headerName: "Pincode", field: 'pin', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'},
{ headerName: "Website", field: 'web', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'},
{ headerName: "Fax No.", field: 'fax', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'},
{ headerName: "Status", field: 'sta', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'}
 ];
 var CustomerDetails_Export = ['Edit','email','pNo','mNo','cnt','sta','cit','add','pin','web','fax','sta'];
var CustomerDetails_ExportCaption = ['Edit','Email Address','Phone No','Mobile No','Country Name','State Name','City Name','Address','Pincode','Website','Fax No.','Status'];

 gridViewSettings['$CustomerDetails$'] =CustomerDetails;
 gridViewSettings['$CustomerDetails_Export$'] =CustomerDetails_Export;
 gridViewSettings['$CustomerDetails_ExportCaption$'] =CustomerDetails_ExportCaption;
  return gridViewSettings;
}