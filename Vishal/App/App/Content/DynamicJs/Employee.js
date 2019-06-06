function getEmployeeGridSettings() {
 var gridViewSettings = new Array();
 var labelArray = getLabel_Header();
 var EmployeeDetails = [
{ headerName: labelArray['$EDIT$'], field: 'Edit', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: labelArray['$ID$'], field: 'empCode', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FIRST_NAME$'], field: 'empfname', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$LAST_NAME$'], field: 'lname', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$QUALIFICATION$'], field: 'qual', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$DEPT_ID$'], field: 'deptId', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$DEPT_NAME$'], field: 'deptNm', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$DESIG_ID$'], field: 'desigId', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$DESIG_NAME$'], field: 'desigNm', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$EMP_TYPE_ID$'], field: 'empTpId', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$EMPLOYEE_TYPE$'], field: 'empType', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$JOB_TYPE_ID$'], field: 'empJTpId', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$JOB_TYPE$'], field: 'jbType', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$FATHER_NAME$'], field: 'fName', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$MOTHER_NAME$'], field: 'mName', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$GENDER$'], field: 'sex', hide: true, headerTooltip: '', width: 110, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$DOB$'], field: 'dob', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$DOJ$'], field: 'doj', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$SPOOUSE_NAME$'], field: 'spName', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$BLOOD_GROUP$'], field: 'bldGrp', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$MARITAL_STATUS$'], field: 'mStatus', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$NATIONALITY$'], field: 'nationality', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ADDRESS_LINE_1$'], field: 'addressLine1', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ADDRESS_LINE_2$'], field: 'addressLine2', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$MOBILE_NO$'], field: 'mobile', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$PHONE_NO$'], field: 'pnNo', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$STATE$'], field: 'state', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$CITY$'], field: 'city', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ZIPCODE$'], field: 'zpCode', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$EMPLOYER_NAME$'], field: 'employer', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$DATE_OF_JOINING$'], field: 'lDOJ', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$DATE_OF_LEAVING$'], field: 'lDOL', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$L_PHONE$'], field: 'lPhoneNo', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$TOTAL_EXP$'], field: 'totalExp', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$REASONLEAVE$'], field: 'resLeaving', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$LASTSALARY$'], field: 'lastSalary', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$PF_NUMBER$'], field: 'pfNumber', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$BANK_NAME$'], field: 'bankName', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ACCOUNT_NO$'], field: 'accNo', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$IFSC_CODE$'], field: 'ifsCode', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ADHAAR_NO$'], field: 'adNo', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$ANNUAL_PACK$'], field: 'anPckg', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$SUBJECTS$'], field: 'sbjct', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$LOGIN_ID$'], field: 'loginId', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$PASSWORD$'], field: 'pass', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$EMAIL$'], field: 'email', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true}
 ];
 var EmployeeDetails_Export = ['Edit','qual','desigId','desigNm','doj','mStatus','state','lPhoneNo','adNo','anPckg','sbjct','pass','email'];
var EmployeeDetails_ExportCaption = ['EDIT','QUALIFICATION','DESIG_ID','DESIG_NAME','DOJ','MARITAL_STATUS','STATE','L_PHONE','ADHAAR_NO','ANNUAL_PACK','SUBJECTS','PASSWORD','EMAIL'];

 gridViewSettings['$EmployeeDetails$'] =EmployeeDetails;
 gridViewSettings['$EmployeeDetails_Export$'] =EmployeeDetails_Export;
 gridViewSettings['$EmployeeDetails_ExportCaption$'] =EmployeeDetails_ExportCaption;
  return gridViewSettings;
}