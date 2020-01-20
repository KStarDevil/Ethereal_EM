using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ethereal_EM.Repository;
using Kendo.Mvc.UI;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Ethereal_EM
{
    [Route("api/[controller]")]
    public class TankController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TankController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }


        [HttpPost("GetTankDataList", Name = "GetTankDataList")]
        [Authorize]
        public dynamic GetTankDataList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            dynamic mainQuery = _repositoryWrapper.Tank.GetTankDataList(param);

            if (mainQuery == null)
            {
                objresponse = new { data = "", dataFoundRowsCount = 0 };
            }
            else
            {
                objresponse = new { data = mainQuery.Data, total = mainQuery.Total };
            }
            return objresponse;
        }

        [HttpGet("GetListPetrol", Name = "GetListPetrol")]
        [Authorize]
        public dynamic GetListPetrol()
        {
            dynamic objresponse = null;
            dynamic mainQuery = _repositoryWrapper.Tank.GetListPetrol();
            objresponse = new { data = mainQuery };
            return objresponse;
        }



        [HttpPost("SaveTank", Name = "SaveTank")]
        [Authorize]
        public dynamic SaveTank([FromBody] Newtonsoft.Json.Linq.JObject param)
        {

            dynamic obj = param;
            dynamic objresponse = null;

            string Message = "Save Unsuccessfully";
            int tankID = obj.tankID != null ? obj.tankID : 0;

            try
            {
                Tank newobj = new Tank();
                newobj.tankname = obj.TankName;
                newobj.productID = obj.PetrolType;
                newobj.TLG_Address = obj.TLGAddress;
                newobj.temperatureAddress = obj.TempperatureAddress;
                newobj.temperature = 0;
                newobj.gauge = 0;
                newobj.modifieddate = DateTime.Now;
                newobj.inactive = true;
                _repositoryWrapper.Tank.Create(newobj);
                _repositoryWrapper.EventLog.Insert(newobj);


                Message = "Save Successfully";
                objresponse = new { data = Message };
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                Console.WriteLine(ex.Message);

            }
            return objresponse;
        }

        [HttpGet("GetTankUpdate/{tankID}", Name = "GetTankUpdate")]
        [Authorize]
        public dynamic GetTankUpdate(int tankID)
        {
            dynamic objresponse = null;
            dynamic mainQuery = _repositoryWrapper.Tank.GetTankUpdate(tankID);
            objresponse = new { data = mainQuery };
            return objresponse;
        }



        [HttpPost("UpdateTank", Name = "UpdateTank")]
        [Authorize]
        public dynamic UpdateTank([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int tankID = obj.tankID != null ? obj.tankID : 0;

            string Message = "Update Unsuccessfully";
            try
            {

                var newobj = _repositoryWrapper.Tank.FindByID(tankID);
                newobj.tankname = obj.TankName;
                newobj.productID = obj.PetrolType;
                newobj.TLG_Address = obj.TLGAddress;
                newobj.temperatureAddress = obj.TempperatureAddress;
                newobj.temperature = 0;
                newobj.gauge = 0;
                newobj.modifieddate = DateTime.Now;
                newobj.inactive = true;
                _repositoryWrapper.Tank.Update(newobj);
                _repositoryWrapper.EventLog.Update(newobj);

                Message = "Update Successfully";
                objresponse = new { data = Message };
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                Console.WriteLine(ex.Message);

            }
            return objresponse;
        }


        [HttpDelete("DeleteTank/{tankID}", Name = "DeleteTank")]
        [Authorize]
        public dynamic DeleteTank(int tankID)
        {
            dynamic objresponse = null;
            string Message = "Delete Unsuccessfully!";
            try
            {


                var newobj = _repositoryWrapper.Tank.FindByID(tankID);
                newobj.inactive = false;
                _repositoryWrapper.Tank.Update(newobj);
                _repositoryWrapper.EventLog.Update(newobj);
                Message = "Delete Successfully";
                objresponse = new { data = Message };


            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { ex.Message };
            }

            return objresponse;

        }

        [HttpPost("ImportFile", Name = "ImportFile")]
        [Authorize]
        public dynamic ImportFile()
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

                        using (var fileStream = file.OpenReadStream())
                        {
                            using (ExcelPackage package = new ExcelPackage(fileStream))
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
                            }
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

        [HttpPost("saveImport", Name = "saveImport")]
        [Authorize]

        public dynamic saveImport([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;


            bool save = false;
            int LogInUserID = Int32.Parse(_tokenData.Userlevelid);
            List<dynamic> dd = new List<dynamic>();
                int ID = 0;
                int tankID = obj.TankID;
                 int typeID = obj.ProductID;
            for (int i = 0; i < obj.data.Count; i++)
            {

                double gallon = (Convert.ToDouble(obj.data[i].gallon.Value));
                double liter =(Convert.ToDouble(obj.data[i].liter.Value)); 
                int level = (Convert.ToInt32( obj.data[i].level.Value));

                var newobj = new TankImport();

                newobj.ID = ID;
                 newobj.tankID = tankID;
                 newobj.typeID = typeID;
                newobj.gallon = gallon;
                newobj.liter = liter;
                newobj.level = level;
                newobj.inactive = true;
                newobj.modifieddate = DateTime.Now;

                _repositoryWrapper.TankImport.Create(newobj);

                _repositoryWrapper.EventLog.Insert(newobj);
                save = true;


            }
            dynamic objresponse = new { result = save };
            return objresponse;

        }


    }

}