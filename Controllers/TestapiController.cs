using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text;
using Operational.Encrypt;
using Microsoft.Extensions.Configuration;
using Ethereal_EM.Repository;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using OfficeOpenXml;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json.Linq;

namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class TestapiController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public TestapiController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpGet("check", Name = "check")]
        public dynamic check()
        {
            var appsettingbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var Configuration = appsettingbuilder.Build();
            var version = Configuration.GetSection("appSettings:API_Version").Value;

            return "Success API Version: " + version;
        }

        [HttpGet("checkdatabase", Name = "checkdatabase")]
        public dynamic checkdatabase()
        {
            try
            {
                //dynamic objres = _repositoryWrapper.AdminLevel.FindByID(1);
                var testing = new Admin_Controller(_repositoryWrapper);
                JObject JO = new JObject();
                JO.Add("ID", 1);
                var T =testing.Get_Admin(JO);
                return T;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("Import", Name = "Impor")]

        public dynamic Import()
        {
            try
            {

                var files = Request.Form.Files;
                if (files.Count > 0)
                {
                    var file = files[0];
                    if (file.Length > 0)
                    {
                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        var stream = file.OpenReadStream();
                        using (var zip = new ZipArchive(stream, ZipArchiveMode.Read))
                        {
                            foreach (var entry in zip.Entries)
                            {
                                using (var stream1 = entry.Open())
                                {
                                    // do whatever we want with stream
                                    // ...
                                }
                            }
                        }
                        // ZipArchive zipFile = ZipFile.Open(ZipPath, ZipArchiveMode.Read);
                        // ZipArchiveEntry fileFromArchive = zipFile.GetEntry(fileName);
                        {
                            /*  using (ExcelPackage package = new ExcelPackage(fileStream))
                             {
                                 StringBuilder sb = new StringBuilder();
                                 ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                                 int rowCount = worksheet.Dimension.Rows;
                                 int ColCount = worksheet.Dimension.Columns;

                                 var returnarray = new List<Newtonsoft.Json.Linq.JObject>();
                                 string[] header = new string[ColCount];

                                 for (int col = 1; col <= ColCount; col++)
                                 {
                                     var headerstr = worksheet.Cells[1, col].Value.ToString();


                                     header[col - 1] = headerstr.Replace(" ", "");



                                 }
                                 for (int row = 2; row <= rowCount; row++)
                                 {
                                     Newtonsoft.Json.Linq.JObject obj = new Newtonsoft.Json.Linq.JObject();
                                     for (int col = 1; col <= ColCount; col++)
                                     {
                                         if (worksheet.Cells[row, col].Value != null)
                                         {

                                             obj[header[col - 1]] = worksheet.Cells[row, col].Value.ToString();


                                         }
                                         else
                                         {
                                             obj[header[col - 1]] = null;
                                         }
                                     }
                                     obj["ID"] = 0;

                                     returnarray.Add(obj);
                                     Console.WriteLine(returnarray[row - 2]);
                                     //sb.Append(Environment.NewLine);
                                 }
                                 dynamic objresult = new { data = returnarray, colname = header };
                                 return objresult;
                             } */
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return false;

        }
        [HttpPost("Upload1", Name = "Upload1")]

        public string FileUpload()
        {
            //string filename = "";
            //string ext = "";
            /*     byte[] data = Convert.FromBase64String(fileparam);
                string decodedString = Encoding.UTF8.GetString(data);
                Char delimiter = '/';
                String[] substrings = decodedString.Split(delimiter);
                if (substrings.Length >= 1)
                    filename = substrings[0];
                if (substrings.Length >= 2)
                    ext = substrings[1]; */
            string returnStr = "Fail to Upload";
            try
            {
                var files = Request.Form.Files;
                if (files.Count > 0)
                {
                    var appsettingbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                    var Configuration = appsettingbuilder.Build();
                    string folderPath = "";
                    string fullPath = "";

                    /////////stockphoto/////////

                    folderPath = Configuration.GetSection("appSettings:uploadStockPath").Value;
                    fullPath = folderPath + "pp" + "." + "png";

                    // Save the file
                    var file = files[0];
                    if (file.Length > 0)
                    {
                        using (var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate))
                        {
                            file.CopyTo(fileStream);
                        }
                    }
                    Response.ContentType = "application/json";
                    returnStr = "Succesfully Upload";
                }

            }
            catch (Exception ex)
            {
                returnStr = "Fail to Upload";
                Globalfunction.WriteSystemLog(ex.Message);

            }
            return returnStr;
        }

    }
}