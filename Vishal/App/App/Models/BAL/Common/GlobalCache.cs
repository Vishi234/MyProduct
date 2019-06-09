using App.Models.Entity.Common;
using DaL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Security.AccessControl;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;

namespace App.Models.BAL.Common
{
    public class GlobalCache
    {
        public object CacheClass
        {
            get; private set;
        }
        string sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        public ResultEntity CreateDynamicGridJS()
        {
            ResultEntity objResult = new ResultEntity();
            try
            {
                Hashtable htGridHeading = new Hashtable();
                ResourceSet resourceSet = Resource.Labels.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                var resEnum = resourceSet.GetEnumerator();
                while (resEnum.MoveNext())
                {
                    htGridHeading.Add(resEnum.Key, resEnum.Value.ToString());
                }
                HttpContext.Current.Application["htGridHeading"] = htGridHeading;
                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/Content/ConfigFiles/GridHeaders.xml"), FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);

                XmlNodeList nodeList = (XmlNodeList)xmldoc.GetElementsByTagName("module");
                string colName = "";

                foreach (XmlNode moduleList in nodeList)
                {
                    string strFile = string.Empty;
                    string strColAttr = string.Empty;
                    string strFileExport = string.Empty;
                    string strFileExportCaption = string.Empty;
                    string strReportColumns = string.Empty;
                    string strReportColAlias = string.Empty;

                    strFile = "function get" + moduleList.Attributes["name"].Value + "GridSettings() {\n"
                                    + " var gridViewSettings = new Array();\n"
                                    + " var labelArray = getLabel_Header();";       //CR-27_Point 6
                    foreach (XmlNode reportNode in moduleList)
                    {
                        strFile += "\n var " + reportNode.Attributes["name"].Value + " = [\n";
                        int form = Convert.ToInt32(reportNode.Attributes["id"].Value);

                        foreach (XmlNode columnNode in reportNode)
                        {
                            strColAttr = "";
                            if (columnNode.Attributes["dbFieldName"].Value != null || columnNode.Attributes["dbFieldName"].Value != "")
                            {
                                if (columnNode.Attributes["dbFieldAlias"].Value == null || columnNode.Attributes["dbFieldAlias"].Value == "")
                                {
                                    strReportColAlias += columnNode.Attributes["dbFieldAlias"].Value + ",";//"\"" + columnNode.Attributes["dbFieldName"].Value + "\",";
                                }
                                else
                                {
                                    strReportColAlias += columnNode.Attributes["dbFieldAlias"].Value + ",";//"\"" + columnNode.Attributes["dbFieldAlias"].Value + "\",";
                                }
                                strReportColumns += columnNode.Attributes["dbFieldName"].Value + ",";
                            }

                            foreach (XmlAttribute attr in columnNode.Attributes)
                            {

                                if (attr.Name.ToLower() == "hide".ToLower() || attr.Name.ToLower() == "suppressMenu".ToLower())
                                    strColAttr += ", " + attr.Name + ": " + ((attr.Value) == "" ? "false" : attr.Value);

                                else if (attr.Name.ToLower() == "dbFieldName".ToLower())
                                    colName = attr.Value;

                                else if (attr.Name.ToLower() == "dbFieldAlias".ToLower())
                                {
                                    if (attr.Value == colName || attr.Value == "")
                                    {
                                        strColAttr += ", field: " + "'" + ((colName) == "" ? "" : colName) + "'";
                                    }
                                    else
                                    {
                                        strColAttr += ", field: " + "'" + ((attr.Value) == "" ? "" : attr.Value) + "'";
                                    }
                                }

                                else if (attr.Name.ToLower() == "headerName".ToLower())
                                    strColAttr += ", " + attr.Name + ": " + ((attr.Value) == "" ? "''" : '"' + htGridHeading[attr.Value].ToString() + '"');

                                else if (attr.Name.ToLower() == "width")
                                    strColAttr += ", " + attr.Name + ": " + (attr.Value);

                                else if (attr.Name.ToLower() == "headerTooltip".ToLower() || attr.Name.ToLower() == "cellStyle".ToLower() || attr.Name.ToLower() == "cellClass".ToLower())
                                    strColAttr += ", " + attr.Name + ": " + "'" + ((attr.Value) == "" ? "" : attr.Value) + "'";

                                else if (attr.Name.ToLower() == "cellRenderer".ToLower() && attr.Value.ToLower() != "")
                                    strColAttr += ", " + attr.Name + ": " + "'" + ((attr.Value) == "" ? "" : attr.Value) + "'";

                                else if (attr.Name.ToLower() == "headerCellRenderer".ToLower() && attr.Value.ToLower() != "")
                                    strColAttr += ", " + attr.Name + ": " + "'" + ((attr.Value) == "" ? "" : attr.Value) + "'";

                                else if (attr.Name.ToLower() == "headerGroup".ToLower() && attr.Value.ToLower() != "")  //0.3
                                    strColAttr += ", " + attr.Name + ": " + ((attr.Value) == "" ? "''" : '"' + htGridHeading[attr.Value].ToString() + '"'); //0.3

                                else if (attr.Name.ToLower() == "export".ToLower())
                                {

                                    if (attr.Value.ToLower() == "true")
                                    {
                                        strColAttr += ", " + attr.Name + ": " + (attr.Value);
                                        strFileExport += "'" + columnNode.Attributes["dbFieldAlias"].Value + "',";
                                        strFileExportCaption += "'" + ((columnNode.Attributes["headerName"].Value) == "" ? "" : htGridHeading[columnNode.Attributes["headerName"].Value]) + "',";
                                    }
                                    else
                                    {
                                        strColAttr += ", " + attr.Name + ": " + (attr.Value);
                                    }

                                }

                            }
                            strFile += "{" + strColAttr.Substring(1, strColAttr.Length - 1) + "},\n";
                        }

                        //calling SP to store Report Columns
                        strReportColumns = strReportColumns.EndsWith(",") == true ? strReportColumns.Substring(0, strReportColumns.Length - 1) : strReportColumns;
                        strReportColAlias = strReportColAlias.EndsWith(",") == true ? strReportColAlias.Substring(0, strReportColAlias.Length - 1) : strReportColAlias;
                        GetReportColumns("P", form, reportNode.Attributes["name"].Value, strReportColumns, strReportColAlias);
                        //call to SP end

                        strReportColumns = "";
                        strReportColAlias = "";

                        strFileExport = (strFileExport.EndsWith(",") == true ? strFileExport.Substring(0, strFileExport.Length - 1) : strFileExport);
                        strFileExportCaption = (strFileExportCaption.EndsWith(",") == true ? strFileExportCaption.Substring(0, strFileExportCaption.Length - 1) : strFileExportCaption);
                        strFileExportCaption = strFileExportCaption.Replace("$", "");

                        strFile = strFile.EndsWith(",\n") == true ? strFile.Substring(0, strFile.Length - 2) : strFile;
                        strFile += "\n ];\n ";

                        if (strFileExport.Length > 0)
                            strFile += "var " + reportNode.Attributes["name"].Value + "_Export" + " = [" + strFileExport + "];\n";

                        if (strFileExportCaption.Length > 0)
                            strFile += "var " + reportNode.Attributes["name"].Value + "_ExportCaption" + " = [" + strFileExportCaption + "];\n";

                        strFile += "\n gridViewSettings['$" + reportNode.Attributes["name"].Value + "$'] =" + reportNode.Attributes["name"].Value + ";";
                        strFile += "\n gridViewSettings['$" + reportNode.Attributes["name"].Value + "_Export" + "$'] =" + reportNode.Attributes["name"].Value + "_Export" + ";";        //CR-27_Point 3
                        strFile += "\n gridViewSettings['$" + reportNode.Attributes["name"].Value + "_ExportCaption" + "$'] =" + reportNode.Attributes["name"].Value + "_ExportCaption" + ";\n";  //CR-27_Point 3
                        strFileExportCaption = string.Empty;
                        strFileExport = string.Empty;
                    }

                    strFile += "  return gridViewSettings;\n" +
                        "}";
                    System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath("~/Content/DynamicJs/" + moduleList.Attributes["name"].Value + ".js"), strFile);
                    strFile = string.Empty;
                    strColAttr = string.Empty;
                    strFileExportCaption = string.Empty;
                    strFileExport = string.Empty;
                }
                objResult.flag = "S";
                objResult.msg = "Cache refreshed successfully";
                return objResult;
            }
            catch (Exception ex)
            {
                Common.WriteException(ex);
                objResult.flag = "F";
                objResult.msg = ex.Message;
                return objResult;
            }

        }

        string[] ReadAllResourceLines(string resourceName)
        {
            using (Stream stream = Assembly.GetEntryAssembly()
                .GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return EnumerateLines(reader).ToArray();
            }
        }

        IEnumerable<string> EnumerateLines(TextReader reader)
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
        private void GetReportColumns(string reportType, int formID, string reportName, string rptColumns, string rptColAlias)
        {
            try
            {
                SqlParameter[] sqlParameter = new SqlParameter[8];
                sqlParameter[0] = new SqlParameter("@PI_REPORT_TYPE", reportType);
                sqlParameter[1] = new SqlParameter("@PI_FORM_ID", formID);

                sqlParameter[2] = new SqlParameter("@PI_REPORT_ID", formID);
                sqlParameter[3] = new SqlParameter("@PI_REPORT_NAME", reportName);

                sqlParameter[4] = new SqlParameter("@PI_COLUMNS", rptColumns);
                sqlParameter[5] = new SqlParameter("@PI_COL_ALIAS", rptColAlias);

                sqlParameter[6] = new SqlParameter("@PO_RSP_FLAG", SqlDbType.NVarChar);
                sqlParameter[6].Direction = ParameterDirection.Output;
                sqlParameter[6].Size = 1;
                sqlParameter[7] = new SqlParameter("@PO_RSP_MSG", SqlDbType.NVarChar);
                sqlParameter[7].Direction = ParameterDirection.Output;
                sqlParameter[7].Size = 500;
                SqlHelper.ExecuteNonQuery(sqlConn, CommandType.StoredProcedure, "SP_INSERT_REPORT_CONFIG", sqlParameter);
            }
            catch (Exception ex)
            {
                Common.WriteException(ex);
            }
        }
        public void RefreshAllDropDown()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string JsonData = serializer.Serialize(
               new
               {
                   AcademicYear = CommonFunc.RdrToList(GetDropDownData("1", 'A')),
                   Course = CommonFunc.RdrToList(GetDropDownData("2", 'A')),
                   Subject = CommonFunc.RdrToList(GetDropDownData("4", 'A')),
                   Param = CommonFunc.RdrToList(GetDropDownData("3", 'D')),
                   Location = CommonFunc.RdrToList(GetDropDownData("5", 'A')),
                   Department = CommonFunc.RdrToList(GetDropDownData("6", 'A')),
                   Designation = CommonFunc.RdrToList(GetDropDownData("7", 'A')),
                   FeeName = CommonFunc.RdrToList(GetDropDownData("8", 'A')),
                   EmpType = CommonFunc.RdrToList(GetDropDownData("22", 'A')),
                   JobType = CommonFunc.RdrToList(GetDropDownData("23", 'A')),
                   Role = CommonFunc.RdrToList(GetDropDownData("9", 'A')),
               });
            string path = HttpContext.Current.Server.MapPath("~/Content/DynamicJs/");
            File.WriteAllText(path + "DropdownData.json", JsonData);

        }
        public string GetCommonDDL()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string JsonData = serializer.Serialize(
               new
               {
                   AcademicYear = CommonFunc.RdrToList(GetDropDownData("1", 'A')),
                   Course = CommonFunc.RdrToList(GetDropDownData("2", 'A')),
                   Subject = CommonFunc.RdrToList(GetDropDownData("4", 'A')),
                   Department = CommonFunc.RdrToList(GetDropDownData("6", 'A')),
                   Designation = CommonFunc.RdrToList(GetDropDownData("7", 'A')),
                   FeeName = CommonFunc.RdrToList(GetDropDownData("8", 'A')),
                   EmpType = CommonFunc.RdrToList(GetDropDownData("22", 'A')),
                   JobType = CommonFunc.RdrToList(GetDropDownData("23", 'A')),
                   Role = CommonFunc.RdrToList(GetDropDownData("9", 'A')),
               });
            return JsonData;
        }
        public SqlDataReader GetDropDownData(string ddlType, char flag)
        {
            string details = string.Empty;
            SqlDataReader dr = null;
            try
            {
                string sqlConn = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                SqlParameter[] sqlParameter = new SqlParameter[2];

                sqlParameter[0] = new SqlParameter("@P_FLAG", flag);
                sqlParameter[1] = new SqlParameter("@DDL_TYPE", ddlType);
                dr = SqlHelper.ExecuteReader(sqlConn, CommandType.StoredProcedure, "SP_GET_DROPDOWN_DATA", sqlParameter);
                return dr;
            }
            catch (Exception ex)
            {
                Common.WriteException(ex);
                return dr;
            }

        }
    }
}