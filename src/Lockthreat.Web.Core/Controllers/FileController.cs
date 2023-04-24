using System;
using System.Net;
using System.Threading.Tasks;
using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;
using Lockthreat.Dto;
using Lockthreat.Storage;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Lockthreat.Configuration;
using System.Collections;

namespace Lockthreat.Web.Controllers
{
    public class FileController : LockthreatControllerBase
    {
        private readonly ITempFileCacheManager _tempFileCacheManager;
        private readonly IBinaryObjectManager _binaryObjectManager;
        private readonly IConfigurationRoot _appConfiguration;
        private readonly IWebHostEnvironment _env;
        public FileController(IWebHostEnvironment env,
            ITempFileCacheManager tempFileCacheManager,
            IBinaryObjectManager binaryObjectManager
        )
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
            _tempFileCacheManager = tempFileCacheManager;
            _binaryObjectManager = binaryObjectManager;
        }

        [DisableAuditing]
        public ActionResult DownloadTempFile(FileDto file)
        {
            var fileBytes = _tempFileCacheManager.GetFile(file.FileToken);
            if (fileBytes == null)
            {
                return NotFound(L("RequestedFileDoesNotExists"));
            }

            return File(fileBytes, file.FileType, file.FileName);
        }

        [DisableAuditing]
        public async Task<ActionResult> DownloadBinaryFile(Guid id, string contentType, string fileName)
        {
            var fileObject = await _binaryObjectManager.GetOrNullAsync(id);
            if (fileObject == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            return File(fileObject.Bytes, contentType, fileName);
        }


        [HttpPost]
        public ActionResult ProcessImportFile()
        {
            try
            {
                var file = Request.Form.Files[0];

                //Open the Excel file using ClosedXML.
                using (XLWorkbook workBook = new XLWorkbook(file.OpenReadStream()))
                {
                    //Create a new DataTable.
                    var dt = new DataTable();
                    var  duplicatedt = new DataTable();

                   
                    //Read the first Sheet from Excel file.
                    for (int K = 1; workBook.Worksheets.Count >= K; K++)
                    {
                        dt = new DataTable();
                        duplicatedt = new DataTable();
                        bool firstRow = true;                       
                        #region Dyanamic store column and row in dataTable 
                        foreach (IXLRow row in workBook.Worksheet(K).Rows())
                        {
                            
                                //Use the first row to add columns to DataTable.
                                if (firstRow)
                                {

                                    foreach (IXLCell cell in row.Cells())
                                    {
                                        if ((string)cell.CachedValue == "")
                                        {
                                            break;
                                        }
                                        dt.Columns.Add(cell.Value.ToString());
                                        duplicatedt.Columns.Add(cell.Value.ToString());
                                    }
                                    firstRow = false;
                                }
                                else
                                {
                                    //Add rows to DataTable.

                                    dt.Rows.Add();
                                    int i = 0, j = 1;

                                    foreach (IXLCell cell in row.Cells())
                                    {
                                        if (dt.Columns.Count >= j)
                                        {
                                        Start:
                                            if (cell.Address.ToString() == ColumnLetter(j) + cell.Address.RowNumber)
                                            {
                                                dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                            }
                                            else { j++; i++; goto Start; }
                                            j++;
                                        }
                                        i++;
                                    }
                                }
                            

                            
                        }

                        for (int i = 1; i < dt.Rows.Count; i++)
                        {

                            DataRow row = dt.Rows[i];
                            object ID = row[0];
                            if (ID.ToString().Trim() == null || String.IsNullOrEmpty(ID.ToString().Trim()) || ID.ToString().Trim() == "")
                            {

                                dt.Rows[i].Delete();
                            }
                        }
                        dt.AcceptChanges();

                        #endregion
                      
                        #region Store data in Sql Table using SQLBulkCopy                    
                        if (dt.Rows.Count > 0)
                        {
                            //  if (workBook.Worksheet(K).Name.ToLower() == "BankFile".ToLower())
                            //  {
                            string consString = _appConfiguration["ConnectionStrings:Default"];
                            using (SqlConnection con = new SqlConnection(consString))
                            {
                                duplicatedt = RemoveDuplicateRows(dt, "ParameterName");

                                if (workBook.Worksheet(K).Name.ToLower() == "Sheet2".ToLower())
                                {
                                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                                    {
                                        //Set the database table name
                                        sqlBulkCopy.DestinationTableName = "AbpDynamicParameters";
                                        sqlBulkCopy.ColumnMappings.Add("Id", "Id");
                                        sqlBulkCopy.ColumnMappings.Add("ParameterName", "ParameterName");
                                        sqlBulkCopy.ColumnMappings.Add("InputType", "InputType");
                                        sqlBulkCopy.ColumnMappings.Add("TenantId", "TenantId");
                                        con.Open();                                     
                                        sqlBulkCopy.WriteToServer(duplicatedt);
                                        con.Close();
                                    }
                                }

                                else if (workBook.Worksheet(K).Name.ToLower() == "Sheet1".ToLower())
                                {
                                    duplicatedt = RemoveDuplicateRows(dt, "Value");
                                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                                    {
                                        //Set the database table name
                                        sqlBulkCopy.DestinationTableName = "AbpDynamicParameterValues";
                                        sqlBulkCopy.ColumnMappings.Add("Value", "Value");     
                                        sqlBulkCopy.ColumnMappings.Add("DynamicParameterId", "DynamicParameterId");
                                        sqlBulkCopy.ColumnMappings.Add("TenantId", "TenantId");
                                        con.Open();                                  
                                        sqlBulkCopy.WriteToServer(duplicatedt);
                                        con.Close();
                                    }
                                }

                            }

                        }
                        #endregion
                    }
                }

                return Json(new
                {
                    msg = "Data inserted succesfully done."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    msg = "Data inserted failed."
                });
            }
        }


        public DataTable RemoveDuplicateRows(DataTable table, string DistinctColumn)
        {
            try
            {
                ArrayList UniqueRecords = new ArrayList();
                ArrayList DuplicateRecords = new ArrayList();

                // Check if records is already added to UniqueRecords otherwise,
                // Add the records to DuplicateRecords
                foreach (DataRow dRow in table.Rows)
                {
                    if (UniqueRecords.Contains(dRow[DistinctColumn]))
                        DuplicateRecords.Add(dRow);
                    else
                        UniqueRecords.Add(dRow[DistinctColumn]);
                }

                // Remove duplicate rows from DataTable added to DuplicateRecords
                foreach (DataRow dRow in DuplicateRecords)
                {
                    table.Rows.Remove(dRow);
                }

                // Return the clean DataTable which contains unique records.
                return table;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //private  static DataTable RemoveDuplicatesRows (DataTable dt)
        //{
          

        //    DataTable uniqueCols =  dt.DefaultView.ToTable(true,"Id","ParameterName","InputType");
        //    return uniqueCols;
        //}


        private static string ColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }

    }
}