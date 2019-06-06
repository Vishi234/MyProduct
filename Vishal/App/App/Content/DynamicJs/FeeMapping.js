function getFeeMappingGridSettings() {
 var gridViewSettings = new Array();
 var labelArray = getLabel_Header();
 var FeeMapping = [
{ headerName: labelArray['$EDIT$'], field: 'Edit', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: labelArray['$ACADEMIC_YEAR$'], field: 'acdYear', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE$'], field: 'course', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false}
 ];
 var FeeMapping_Export = ['Edit'];
var FeeMapping_ExportCaption = ['EDIT'];

 gridViewSettings['$FeeMapping$'] =FeeMapping;
 gridViewSettings['$FeeMapping_Export$'] =FeeMapping_Export;
 gridViewSettings['$FeeMapping_ExportCaption$'] =FeeMapping_ExportCaption;
  return gridViewSettings;
}