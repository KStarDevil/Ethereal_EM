using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Ethereal_EM.Repository;
using Kendo.Mvc.UI;
using System.ComponentModel.DataAnnotations;


namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class DriverController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;


        public DriverController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpPost("GetAllDriverList", Name = "GetAllDriverList")]
        [Authorize]
        public dynamic GetAllDriverList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.Driver.GetAllDriverList(param);

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
        [HttpGet("GetDriverTownshipCombo", Name = "GetDriverTownshipCombo")]
        [Authorize]
        public dynamic GetDriverTownshipCombo()
        {
            var query = _repositoryWrapper.General.GetTownshipCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetDivisionCodeCombo", Name = "GetDivisionCodeCombo")]
        [Authorize]
        public dynamic GetDivisionCodeCombo()
        {
            var query = _repositoryWrapper.General.GetDivisionCodeCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetTownshipCodeCombo", Name = "GetTownshipCodeCombo")]
        [Authorize]
        public dynamic GetTownshipCodeCombo()
        {
            var query = _repositoryWrapper.General.GetTownshipCodeCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetCitizenCodeCombo", Name = "GetCitizenCodeCombo")]
        [Authorize]
        public dynamic GetCitizenCodeCombo()
        {
            var query = _repositoryWrapper.General.GetCitizenCodeCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetDriverStateCombo", Name = "GetDriverStateCombo")]
        [Authorize]
        public dynamic GetDriverStateCombo()
        {
            var query = _repositoryWrapper.General.GetStateList();
            dynamic objresponse = new { data = query };
            return objresponse;
        }

        [HttpPost("CheckDuplicateDriver", Name = "CheckDuplicateDriver")]
        [Authorize]
        public dynamic CheckDuplicateDriver([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresult = null;
            int DriverID = obj.DriverID != null ? obj.DriverID : 0;
            string cardno = obj.cardno;
            int nrc = obj.nrc;
            string License = obj.License;
            string Phone = obj.Phone;

            var duplicatedCard = _repositoryWrapper.Driver.CheckDuplicateCard(DriverID, cardno);
            var duplicateNRC = _repositoryWrapper.Driver.CheckDuplicateNRC(DriverID, nrc);
            var duplicatedLicense = _repositoryWrapper.Driver.CheckDuplicateLicense(DriverID, License);
            var duplicatedPhone = _repositoryWrapper.Driver.CheckDuplicatePhone(DriverID, Phone);
            objresult = new
            {
                Card = duplicatedCard > 0 ? 1 : 0,
                NRC = duplicateNRC > 0 ? 1 : 0,
                License = duplicatedLicense > 0 ? 1 : 0,
                Phone = duplicatedPhone > 0 ? 1 : 0
            };

            List<dynamic> dd = new List<dynamic>();
            dd.Add(objresult);
            dynamic objresponse = new { data = dd };
            return objresponse;
        }
        [HttpGet("GetDriverData/{DriverID}", Name = "GetDriverData")]
        [Authorize]
        public dynamic GetDriverData(int DriverID)
        {
            dynamic objresponse = null;
            try
            {
                var query = _repositoryWrapper.Driver.GetDriverData(DriverID);
                objresponse = new { data = query };
                return objresponse;
            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }

        [HttpPost("changeStatusDriver", Name ="changeStatusDriver")]
        [Authorize]
        public dynamic changeStatusDriver([FromBody] Newtonsoft.Json.Linq.JValue param)
        {
            dynamic objresponse = null;
            dynamic obj=param;
            int DriverID=obj;

            try
            {
                var dobj = _repositoryWrapper.Driver.FindByID(DriverID);
                if(dobj.status == 0){
                    dobj.status = 1;
                }
                 _repositoryWrapper.Driver.Update(dobj.status);
                return objresponse;
            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }
        
        
        [HttpPost("SaveDriver", Name = "SaveDriver")]
        [Authorize]
        public dynamic SaveDriver([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int LoginID = Int32.Parse(_tokenData.UserID);
            int DriverID = obj.DriverID != null ? obj.DriverID : 0;
            string CompanyID = _tokenData.CompanyID;
            try
            {
                var dobj = _repositoryWrapper.Driver.FindByID(DriverID);
                if (dobj != null)
                {
                    dobj.name = obj.name;
                    dobj.nrcNo = obj.nrc;
                    dobj.nrcDivisionCode = obj.divisioncode;
                    dobj.nrcTownshipCode = obj.townshipcode;
                    dobj.nrcCitizenCode = obj.citizencode;
                    dobj.license = obj.License;
                    dobj.cardNo = obj.cardno;
                    dobj.township = obj.TownshipID;
                    dobj.state = obj.StateID;
                    dobj.address = obj.Address;
                    dobj.phone = obj.Phone;
                    dobj.createuser = LoginID;
                    dobj.usertype = false;
                    dobj.modifieddate = System.DateTime.Now;
                    dobj.inactive = true;
                    _repositoryWrapper.Driver.Update(dobj);
                    _repositoryWrapper.EventLog.Update(dobj);

                }
                else
                {
                    var newobj = new Driver();
                    newobj.name = obj.name;
                    newobj.nrcNo = obj.nrc;
                    newobj.nrcDivisionCode = obj.divisioncode;
                    newobj.nrcTownshipCode = obj.townshipcode;
                    newobj.nrcCitizenCode = obj.citizencode;
                    newobj.license = obj.License;
                    newobj.cardNo = obj.cardno;
                    newobj.township = obj.TownshipID;
                    newobj.state = obj.StateID;
                    newobj.status=1;
                    newobj.address = obj.Address;
                    newobj.phone = obj.Phone;
                    newobj.createuser = LoginID;
                    newobj.usertype = false;
                    newobj.modifieddate = System.DateTime.Now;
                    newobj.inactive = true;
                    _repositoryWrapper.Driver.Create(newobj);
                    _repositoryWrapper.EventLog.Update(newobj);

                    DriverID = newobj.driverID;
                    _repositoryWrapper.EventLog.Insert(newobj);
                }
                objresponse = new { data = DriverID };
            }
            catch (ValidationException vex)
            {
                _repositoryWrapper.EventLog.Error("Driver Controller/ Save Driver", vex.Message);
                objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }

        [HttpDelete("DeleteDriver/{DriverID}", Name = "DeleteDriver")]
        [Authorize]
        public dynamic DeleteDriver(int DriverID)
        {
            dynamic objresponse = null;
            bool result = false;
            try
            {
                var newobj = _repositoryWrapper.Driver.FindByID(DriverID);
                newobj.inactive = false;
                _repositoryWrapper.Driver.Update(newobj);
                _repositoryWrapper.EventLog.Update(newobj);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { ex.Message };
            }
            objresponse = new { data = result };
            return objresponse;
        }

        [HttpGet("GetTownshipListByState/{stateID}", Name = "GetTownshipListByState")]
        [Authorize]
        public dynamic GetTownshipListByState(int stateID)
        {
            dynamic objresult = null;
            var query1 = _repositoryWrapper.Company.GetTownshipList(stateID);
            objresult = query1;

            dynamic objresponse = new { data = objresult };
            return objresponse;
        }

        [HttpPost("SaveImagePath", Name = "DriverSaveImagePath")]
        [Authorize]
        public dynamic SaveImagePath([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;

            int DriverID = Convert.ToInt32(obj.ID.Value);
            string FileName = obj.FileName.Value;
            string ext = obj.FileName.Value.Replace(".", "");
            string ImagePath = DriverID.ToString() + '.' + ext;
            var objDriver = _repositoryWrapper.Driver.FindByID(DriverID);
            dynamic objresponse;

            if (objDriver != null)
            {
                objDriver.photo = ImagePath;
                _repositoryWrapper.Driver.Update(objDriver);
                _repositoryWrapper.EventLog.Update(objDriver);
                objresponse = new { data = true };
            }
            else
                // objDriver.photo = ImagePath;
                // _repositoryWrapper.Driver.Create(objDriver);
                objresponse = new { data = false };
            return objresponse;
        }
    
        
        
    }
}