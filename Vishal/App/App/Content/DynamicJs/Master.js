function getMasterGridSettings() {
 var gridViewSettings = new Array();
 var labelArray = getLabel_Header();
 var AcademicDetails = [
{ headerName: labelArray['$EDIT$'], field: 'Edit', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: labelArray['$ID$'], field: 'id', hide: true, headerTooltip: '', width: 250, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ACADEMIC_YEAR$'], field: 'acYear', hide: false, headerTooltip: '', width: 200, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$START_DATE$'], field: 'wfDate', hide: false, headerTooltip: '', width: 200, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$END_DATE$'], field: 'wtDate', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$IS_ACTIVE$'], field: 'isActive', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'}
 ];
 var AcademicDetails_Export = ['Edit','wfDate','wtDate','isActive'];
var AcademicDetails_ExportCaption = ['EDIT','START_DATE','END_DATE','IS_ACTIVE'];

 gridViewSettings['$AcademicDetails$'] =AcademicDetails;
 gridViewSettings['$AcademicDetails_Export$'] =AcademicDetails_Export;
 gridViewSettings['$AcademicDetails_ExportCaption$'] =AcademicDetails_ExportCaption;

 var CourseDetails = [
{ headerName: labelArray['$EDIT$'], field: 'Edit', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: labelArray['$COURSE_ID$'], field: 'id', hide: true, headerTooltip: '', width: 50, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE_TYPE$'], field: 'cType', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$COURSE_TYPE_ID$'], field: 'cTypeID', hide: true, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$COURSE_NAME$'], field: 'cnm', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$NO_OF_SEMESTER$'], field: 'nsem', hide: false, headerTooltip: '', width: 200, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$IS_ACTIVE$'], field: 'isActive', hide: false, headerTooltip: '', width: 200, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'}
 ];
 var CourseDetails_Export = ['Edit','cType','cTypeID','nsem','isActive'];
var CourseDetails_ExportCaption = ['EDIT','COURSE_TYPE','COURSE_TYPE_ID','NO_OF_SEMESTER','IS_ACTIVE'];

 gridViewSettings['$CourseDetails$'] =CourseDetails;
 gridViewSettings['$CourseDetails_Export$'] =CourseDetails_Export;
 gridViewSettings['$CourseDetails_ExportCaption$'] =CourseDetails_ExportCaption;

 var DurationDetails = [
{ headerName: labelArray['$EDIT$'], field: 'Edit', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: labelArray['$ID$'], field: 'id', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$YEAR_ID$'], field: 'acYearid', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$YEAR_NAME$'], field: 'acYear', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE_ID$'], field: 'cnmId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE_NAME$'], field: 'cnm', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$NO_OF_SEMESTER$'], field: 'nsem', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$START_DATE$'], field: 'sDt', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$END_DATE$'], field: 'eDt', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$IS_ACTIVE$'], field: 'isActive', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'}
 ];
 var DurationDetails_Export = ['Edit','nsem','sDt','eDt','isActive'];
var DurationDetails_ExportCaption = ['EDIT','NO_OF_SEMESTER','START_DATE','END_DATE','IS_ACTIVE'];

 gridViewSettings['$DurationDetails$'] =DurationDetails;
 gridViewSettings['$DurationDetails_Export$'] =DurationDetails_Export;
 gridViewSettings['$DurationDetails_ExportCaption$'] =DurationDetails_ExportCaption;

 var SectionDetails = [
{ headerName: labelArray['$EDIT$'], field: 'Edit', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: labelArray['$SECTION_ID$'], field: 'id', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE_ID$'], field: 'courseName', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE_ID$'], field: 'courseId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$SEMESTER_ID$'], field: 'semId', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$SECTION_ID$'], field: 'secId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$SECTION_NAME$'], field: 'secName', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$IS_ACTIVE$'], field: 'isActive', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'}
 ];
 var SectionDetails_Export = ['Edit','secName','isActive'];
var SectionDetails_ExportCaption = ['EDIT','SECTION_NAME','IS_ACTIVE'];

 gridViewSettings['$SectionDetails$'] =SectionDetails;
 gridViewSettings['$SectionDetails_Export$'] =SectionDetails_Export;
 gridViewSettings['$SectionDetails_ExportCaption$'] =SectionDetails_ExportCaption;

 var SubjectDetails = [
{ headerName: labelArray['$EDIT$'], field: 'Edit', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: labelArray['$SUBJECT_ID$'], field: 'id', hide: true, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$SUBJECT_CODE$'], field: 'scde', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$SUBJECT_NAME$'], field: 'snm', hide: false, headerTooltip: '', width: 300, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$SUBJECT_SHORT_NAME$'], field: 'ssnm', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$SUBJECT_MEDIUM$'], field: 'smed', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$SUBJECT_MEDIUM_ID$'], field: 'smedID', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$SUBJECT_TYPE$'], field: 'styp', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$SUBJECT_TYPE_ID$'], field: 'stypId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$IS_ACTIVE$'], field: 'isActive', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'}
 ];
 var SubjectDetails_Export = ['Edit','ssnm','smed','smedID','styp','stypId','isActive'];
var SubjectDetails_ExportCaption = ['EDIT','SUBJECT_SHORT_NAME','SUBJECT_MEDIUM','SUBJECT_MEDIUM_ID','SUBJECT_TYPE','SUBJECT_TYPE_ID','IS_ACTIVE'];

 gridViewSettings['$SubjectDetails$'] =SubjectDetails;
 gridViewSettings['$SubjectDetails_Export$'] =SubjectDetails_Export;
 gridViewSettings['$SubjectDetails_ExportCaption$'] =SubjectDetails_ExportCaption;

 var ActivityDetails = [
{ headerName: labelArray['$EDIT$'], field: 'Edit', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: labelArray['$ACTIVITY_ID$'], field: 'id', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ACTIVITY_NAME$'], field: 'anm', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ACTIVITY_TYPE$'], field: 'atyp', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$ACTIVITY_TYPE_ID$'], field: 'atypID', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$START_DATE$'], field: 'sDt', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$END_DATE$'], field: 'eDt', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$IS_ACTIVE$'], field: 'isActive', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'}
 ];
 var ActivityDetails_Export = ['Edit','atyp','atypID','sDt','eDt','isActive'];
var ActivityDetails_ExportCaption = ['EDIT','ACTIVITY_TYPE','ACTIVITY_TYPE_ID','START_DATE','END_DATE','IS_ACTIVE'];

 gridViewSettings['$ActivityDetails$'] =ActivityDetails;
 gridViewSettings['$ActivityDetails_Export$'] =ActivityDetails_Export;
 gridViewSettings['$ActivityDetails_ExportCaption$'] =ActivityDetails_ExportCaption;

 var MappingDetails = [
{ headerName: labelArray['$EDIT$'], field: 'Edit', hide: false, headerTooltip: '', width: 115, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: labelArray['$ID$'], field: 'id', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE_ID$'], field: 'cId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$COURSE_NAME$'], field: 'cName', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$SEMESTER$'], field: 'sem', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$SUBJECT_ID$'], field: 'subId', hide: true, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$SUBJECT_NAME$'], field: 'subName', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$IS_ACTIVE$'], field: 'isActive', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'}
 ];
 var MappingDetails_Export = ['Edit','subId','subName','isActive'];
var MappingDetails_ExportCaption = ['EDIT','SUBJECT_ID','SUBJECT_NAME','IS_ACTIVE'];

 gridViewSettings['$MappingDetails$'] =MappingDetails;
 gridViewSettings['$MappingDetails_Export$'] =MappingDetails_Export;
 gridViewSettings['$MappingDetails_ExportCaption$'] =MappingDetails_ExportCaption;

 var HolidayDetails = [
{ headerName: labelArray['$EDIT$'], field: 'Edit', hide: false, headerTooltip: '', width: 150, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateEdit'},
{ headerName: labelArray['$YEAR_ID$'], field: 'acid', hide: true, headerTooltip: '', width: 250, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$ACADEMIC_YEAR$'], field: 'acName', hide: false, headerTooltip: '', width: 250, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$HOLIDAY_NAME_ID$'], field: 'holyNameId', hide: true, headerTooltip: '', width: 200, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$HOLIDAY_NAME$'], field: 'holyName', hide: false, headerTooltip: '', width: 200, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$RISTRICT_ID$'], field: 'resId', hide: true, headerTooltip: '', width: 200, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$RISTRICT$'], field: 'resHoly', hide: false, headerTooltip: '', width: 200, cellClass: 'grid-center', cellStyle: '', suppressMenu: false, export: false},
{ headerName: labelArray['$START_DATE$'], field: 'wfDate', hide: false, headerTooltip: '', width: 200, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$END_DATE$'], field: 'wtDate', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true},
{ headerName: labelArray['$IS_ACTIVE$'], field: 'isActive', hide: false, headerTooltip: '', width: 100, cellClass: 'grid-left', cellStyle: '', suppressMenu: false, export: true, cellRenderer: 'CreateActive'}
 ];
 var HolidayDetails_Export = ['Edit','wfDate','wtDate','isActive'];
var HolidayDetails_ExportCaption = ['EDIT','START_DATE','END_DATE','IS_ACTIVE'];

 gridViewSettings['$HolidayDetails$'] =HolidayDetails;
 gridViewSettings['$HolidayDetails_Export$'] =HolidayDetails_Export;
 gridViewSettings['$HolidayDetails_ExportCaption$'] =HolidayDetails_ExportCaption;
  return gridViewSettings;
}