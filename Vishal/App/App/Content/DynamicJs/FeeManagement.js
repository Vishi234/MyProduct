function getFeeManagementGridSettings() {
 var gridViewSettings = new Array();
 var labelArray = getLabel_Header();
 var FeeType = [
{ headerName: labelArray['$EDIT$'], field: 'Edit', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: labelArray['$FEE_NAME$'], field: 'id', hide: true, headerTooltip: '', width: 47, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FEE_NAME$'], field: 'feeName', hide: false, headerTooltip: '', width: 122, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$TYPE_ID$'], field: 'pTypeId', hide: true, headerTooltip: '', width: 130, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$PAYMENT_TYPE$'], field: 'pType', hide: false, headerTooltip: '', width: 124, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$MONTH$'], field: 'monthId', hide: true, headerTooltip: '', width: 320, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$MONTH$'], field: 'month', hide: false, headerTooltip: '', width: 197, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$DESCRIPTION$'], field: 'descrip', hide: false, headerTooltip: '', width: 203, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$IS_ACTIVE$'], field: 'isActive', hide: false, headerTooltip: '', width: 109, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'},
{ headerName: labelArray['$TERMS$'], field: 'trm', hide: false, headerTooltip: '', width: 83, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FEE_SUBMISSION_DAY$'], field: 'fsd', hide: false, headerTooltip: '', width: 151, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FEE_RELAXATION_DAYS$'], field: 'frd', hide: false, headerTooltip: '', width: 156, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false}
 ];
 var FeeType_Export = ['Edit','isActive'];
var FeeType_ExportCaption = ['EDIT','IS_ACTIVE'];

 gridViewSettings['$FeeType$'] =FeeType;
 gridViewSettings['$FeeType_Export$'] =FeeType_Export;
 gridViewSettings['$FeeType_ExportCaption$'] =FeeType_ExportCaption;

 var FeeMapping = [
{ headerName: labelArray['$ID$'], field: 'id', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ACADEMIC_YEAR$'], field: 'yrId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ACADEMIC_YEAR$'], field: 'acYr', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$COURSE$'], field: 'crsId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE$'], field: 'crsNm', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$FEE_NAME$'], field: 'fId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FEE_NAME$'], field: 'fNm', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$TYPE_ID$'], field: 'typeID', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$PAYMENT_TYPE$'], field: 'pType', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$TERMS$'], field: 'trms', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$FEE_AMOUNT$'], field: 'amt', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-right', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateTextBox'}
 ];
 var FeeMapping_Export = ['acYr','crsNm','fNm','pType','trms','amt'];
var FeeMapping_ExportCaption = ['ACADEMIC_YEAR','COURSE','FEE_NAME','PAYMENT_TYPE','TERMS','FEE_AMOUNT'];

 gridViewSettings['$FeeMapping$'] =FeeMapping;
 gridViewSettings['$FeeMapping_Export$'] =FeeMapping_Export;
 gridViewSettings['$FeeMapping_ExportCaption$'] =FeeMapping_ExportCaption;

 var Payments = [
{ headerName: labelArray['$VIEWPAY$'], field: 'edit', hide: false, headerTooltip: '', width: 220, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateAction'},
{ headerName: labelArray['$STU_CODE$'], field: 'stuCode', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FIRST_NAME$'], field: 'fName', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$LAST_NAME$'], field: 'lName', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$COURSE$'], field: 'crsId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE$'], field: 'crNm', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ACADEMIC_YEAR$'], field: 'yrId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$ACADEMIC_YEAR$'], field: 'acdYear', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$SEMESTER$'], field: 'sem', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$TOTAL$'], field: 'feeAmt', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$DISCOUNT$'], field: 'discount', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FINE$'], field: 'fne', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$PAID$'], field: 'paid', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$DUE$'], field: 'due', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateLink'}
 ];
 var Payments_Export = ['edit','lName','yrId','acdYear','feeAmt','fne','paid','due'];
var Payments_ExportCaption = ['VIEWPAY','LAST_NAME','ACADEMIC_YEAR','ACADEMIC_YEAR','TOTAL','FINE','PAID','DUE'];

 gridViewSettings['$Payments$'] =Payments;
 gridViewSettings['$Payments_Export$'] =Payments_Export;
 gridViewSettings['$Payments_ExportCaption$'] =Payments_ExportCaption;

 var StudentFeePay = [
{ headerName: labelArray['$STU_CODE$'], field: 'sCode', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FEE_NAME$'], field: 'acYr', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FEE_NAME$'], field: 'crs', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FEE_NAME$'], field: 'sem', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FEE_NAME$'], field: 'fId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FEE_NAME$'], field: 'fName', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$FEE_AMOUNT$'], field: 'fAmnt', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$DUE$'], field: 'dueAmnt', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$DISCOUNT$'], field: 'dis', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false, cellRenderer: 'CreateInput'},
{ headerName: labelArray['$FINE$'], field: 'fine', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateInput'},
{ headerName: labelArray['$PAID$'], field: 'paidAmnt', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateInput'}
 ];
 var StudentFeePay_Export = ['fName','fAmnt','dueAmnt','fine','paidAmnt'];
var StudentFeePay_ExportCaption = ['FEE_NAME','FEE_AMOUNT','DUE','FINE','PAID'];

 gridViewSettings['$StudentFeePay$'] =StudentFeePay;
 gridViewSettings['$StudentFeePay_Export$'] =StudentFeePay_Export;
 gridViewSettings['$StudentFeePay_ExportCaption$'] =StudentFeePay_ExportCaption;

 var StudentFeeHis = [
{ headerName: labelArray['$STU_CODE$'], field: 'sCode', hide: false, headerTooltip: '', width: 122, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ACADEMIC_YEAR$'], field: 'acYr', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE_NAME$'], field: 'crs', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FEE_NAME$'], field: 'fName', hide: false, headerTooltip: '', width: 213, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$TOTAL$'], field: 'fAmnt', hide: false, headerTooltip: '', width: 80, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$DUE$'], field: 'dueAmnt', hide: false, headerTooltip: '', width: 76, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$DISCOUNT$'], field: 'dis', hide: false, headerTooltip: '', width: 92, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FINE$'], field: 'fine', hide: false, headerTooltip: '', width: 67, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$PAID$'], field: 'paidAmnt', hide: false, headerTooltip: '', width: 71, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$RECIEPT_NO$'], field: 'recNo', hide: false, headerTooltip: '', width: 125, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$PAYMENT_DATE$'], field: 'pDt', hide: false, headerTooltip: '', width: 120, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true}
 ];
 var StudentFeeHis_Export = ['fName','fAmnt','dueAmnt','fine','paidAmnt','recNo','pDt'];
var StudentFeeHis_ExportCaption = ['FEE_NAME','TOTAL','DUE','FINE','PAID','RECIEPT_NO','PAYMENT_DATE'];

 gridViewSettings['$StudentFeeHis$'] =StudentFeeHis;
 gridViewSettings['$StudentFeeHis_Export$'] =StudentFeeHis_Export;
 gridViewSettings['$StudentFeeHis_ExportCaption$'] =StudentFeeHis_ExportCaption;

 var FeeCollectionReport = [
{ headerName: labelArray['$PAYMENT_DATE$'], field: 'pDt', hide: false, headerTooltip: '', width: 122, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$RECIEPT_NO$'], field: 'reNo', hide: false, headerTooltip: '', width: 122, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$STU_CODE$'], field: 'sCd', hide: false, headerTooltip: '', width: 122, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FIRST_NAME$'], field: 'fNm', hide: false, headerTooltip: '', width: 122, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$LAST_NAME$'], field: 'lNm', hide: false, headerTooltip: '', width: 122, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE_NAME$'], field: 'crs', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$SEMESTER$'], field: 'sem', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FEE_NAME$'], field: 'feNm', hide: false, headerTooltip: '', width: 213, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$DUE$'], field: 'dueAmnt', hide: false, headerTooltip: '', width: 76, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$FINE$'], field: 'fine', hide: false, headerTooltip: '', width: 67, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$PAID$'], field: 'paidAmnt', hide: false, headerTooltip: '', width: 71, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$TOTAL$'], field: 'fAmnt', hide: false, headerTooltip: '', width: 80, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true}
 ];
 var FeeCollectionReport_Export = ['feNm','dueAmnt','fine','paidAmnt','fAmnt'];
var FeeCollectionReport_ExportCaption = ['FEE_NAME','DUE','FINE','PAID','TOTAL'];

 gridViewSettings['$FeeCollectionReport$'] =FeeCollectionReport;
 gridViewSettings['$FeeCollectionReport_Export$'] =FeeCollectionReport_Export;
 gridViewSettings['$FeeCollectionReport_ExportCaption$'] =FeeCollectionReport_ExportCaption;
  return gridViewSettings;
}