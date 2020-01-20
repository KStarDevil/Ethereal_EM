using System.ComponentModel;
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

    [Route("mobile/[controller]")]

    public class DriverMobileController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public static IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;


        public DriverMobileController(IRepositoryWrapper RW, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repositoryWrapper = RW;
        }

        [HttpPost("GetAllMobileDriverList", Name = "GetAllMobileDriverList")]
        [Authorize]
        public dynamic GetAllMobileDriverList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            dynamic DriverList = null;

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {
                    var Mobile_DriverList = _repositoryWrapper.Driver.GetAllMobileDriverList();
                    if (Mobile_DriverList.Count == 0)
                    {
                        DriverList = "Sorry!! There is no record";
                        objresponse = new { status = 0, messages = DriverList };
                    }
                    else
                    {
                        objresponse = new { status = 1, messages = "success", data = Mobile_DriverList };
                    }
                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, messages = Message };
                }
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }

            return objresponse;
        }

        [HttpPost("GetMobileDriverTownshipCombo", Name = "GetMobileDriverTownshipCombo")]
        [Authorize]
        public dynamic GetMobileDriverTownshipCombo([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            dynamic Township = null;

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {
                    Township = _repositoryWrapper.General.GetTownshipCombo();
                    objresponse = new { status = 1, messages = "success", data = Township };
                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, messages = Message };
                }
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }
            return objresponse;
        }

        [HttpPost("GetMobileDriverStateCombo", Name = "GetMobileDriverStateCombo")]
        [Authorize]
        public dynamic GetMobileDriverStateCombo([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            dynamic Township = null;

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {
                    Township = _repositoryWrapper.General.GetStateList();
                    objresponse = new { status = 1, messages = "success", data = Township };
                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, messages = Message };
                }
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }
            return objresponse;
        }
        [HttpPost("GetMobileDriverNRCDivisionCombo", Name = "GetMobileDriverNRCDivisionCombo")]
        [Authorize]
        public dynamic GetMobileDriverNRCDivisionCombo([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            dynamic Division = null;

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {
                    Division = _repositoryWrapper.General.GetDivisionCodeCombo();
                    objresponse = new { status = 1, messages = "success", data = Division };
                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, messages = Message };
                }
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }
            return objresponse;
        }
        [HttpPost("GetMobileDriverTownshipCodeCombo", Name = "GetMobileDriverTownshipCodeCombo")]
        [Authorize]
        public dynamic GetMobileDriverTownshipCodeCombo([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            dynamic TownshipCode = null;

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {
                    TownshipCode = _repositoryWrapper.General.GetTownshipCodeCombo();
                    objresponse = new { status = 1, messages = "success", data = TownshipCode };
                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, messages = Message };
                }
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }
            return objresponse;
        }

        [HttpPost("GetMobileDriverCitizenCodeCombo", Name = "GetMobileDriverCitizenCodeCombo")]
        [Authorize]
        public dynamic GetMobileDriverCitizenCodeCombo([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            dynamic CitizenCode = null;

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {
                    CitizenCode = _repositoryWrapper.General.GetCitizenCodeCombo();
                    objresponse = new { status = 1, messages = "success", data = CitizenCode };
                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, messages = Message };
                }
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }
            return objresponse;
        }
        [HttpPost("CheckDuplicateMobileDriver", Name = "CheckDuplicateMobileDriver")]
        [Authorize]
        public dynamic CheckDuplicateMobileDriver([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            int DriverID = objParamInfo.DriverID != null ? objParamInfo.DriverID : 0;
            string cardno = objParamInfo.cardNo;
            int nrc = objParamInfo.nrc;
            string License = objParamInfo.license;
            string Phone = objParamInfo.phone;
            dynamic objresponse = null;
            dynamic objresult = null;

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {
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
                    List<dynamic> list = new List<dynamic>();
                    list.Add(objresult);
                    objresponse = new { status = 1, messages = "success", data = list };
                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, messages = Message };
                }
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }
            return objresponse;
        }

        [HttpPost("GetMobileDriverData", Name = "GetMobileDriverData")]
        [Authorize]
        public dynamic GetMobileDriverData([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            int DriverID = objParamInfo.DriverID;
            dynamic objresponse = null;
            dynamic Mobile_DriverData = null;
            dynamic DriverData = null;

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {

                    Mobile_DriverData = _repositoryWrapper.Driver.GetDriverData(DriverID);
                    if (Mobile_DriverData == null)
                    {
                        DriverData = "Sorry!! There is no record";
                        objresponse = new { status = 0, messages = DriverData };
                    }
                    else
                    {
                        objresponse = new { status = 1, messages = "success", data = Mobile_DriverData };
                    }
                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, messages = Message };
                }
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }

            return objresponse;
        }

        [HttpPost("SaveMobileDriver", Name = "SaveMobileDriver")]
        [Authorize]

        public dynamic SaveMobileDriver([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            dynamic objresponse = null;
            int DriverID = objParamInfo.DriverID != null ? objParamInfo.DriverID : 0;
            string CustomerID = objParamInfo.CustomerID;
            string Name = objParamInfo.name;
            int nrc = objParamInfo.nrc;
            int divisioncode = objParamInfo.divisioncode;
            int townshipcode = objParamInfo.townshipcode;
            int citizencode = objParamInfo.citizencode;
            string license = objParamInfo.license;
            string cardNo = objParamInfo.cardNo;
            int township = objParamInfo.township;
            int state = objParamInfo.state;
            string address = objParamInfo.address;
            string phone = objParamInfo.phone;
            DateTime Date = System.DateTime.Now;
            String Message = "";
            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {
                    var dobj = _repositoryWrapper.Driver.FindByID(DriverID);
                    if (dobj != null)
                    {
                        dobj.name = Name;
                        dobj.nrcNo = nrc;
                        dobj.nrcDivisionCode = divisioncode;
                        dobj.nrcTownshipCode = townshipcode;
                        dobj.nrcCitizenCode = citizencode;
                        dobj.license = license;
                        dobj.cardNo = cardNo;
                        dobj.township = township;
                        dobj.state = state;
                        dobj.address = address;
                        dobj.phone = phone;
                        dobj.createuser = Int32.Parse(customerId);
                        dobj.usertype = true;
                        dobj.modifieddate = Date;
                        dobj.inactive = true;
                        _repositoryWrapper.Driver.Update(dobj);
                        Message = "Update Successfully! ";

                    }
                    else
                    {

                        var duplicatedCard = _repositoryWrapper.Driver.CheckDuplicateCard(DriverID, cardNo);

                        var duplicateNRC = _repositoryWrapper.Driver.CheckDuplicateNRC(DriverID, nrc);

                        var duplicatedLicense = _repositoryWrapper.Driver.CheckDuplicateLicense(DriverID, license);

                        var duplicatedPhone = _repositoryWrapper.Driver.CheckDuplicatePhone(DriverID, phone);

                        if(duplicatedCard == 0 || duplicateNRC == 0 || duplicatedLicense==0 || duplicatedPhone==0 ){
                        var newobj = new Driver();
                        newobj.name = Name;
                        newobj.nrcNo = nrc;
                        newobj.nrcDivisionCode = divisioncode;
                        newobj.nrcTownshipCode = townshipcode;
                        newobj.nrcCitizenCode = citizencode;
                        newobj.license = license;
                        newobj.cardNo = cardNo;
                        newobj.township = township;
                        newobj.state = state;
                        newobj.status = 0;
                        newobj.address = address;
                        newobj.phone = phone;
                        newobj.modifieddate = Date;
                        newobj.createuser = Int32.Parse(customerId);
                        newobj.usertype = true;
                        newobj.inactive = true;
                        _repositoryWrapper.Driver.Create(newobj);
                        Message = "Save Successfully! ";
                    }
                    }
                    objresponse = new { status = 1, messages = Message };
                }
                else
                {
                    Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, messages = Message };
                }
            }
            catch (ValidationException ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }

            return objresponse;
        }

        [HttpPost("DeleteMobileDriver", Name = "DeleteMobileDriver")]
        [Authorize]
        public dynamic DeleteMobileDriver([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            int DriverID = objParamInfo.DriverID;
            dynamic objresponse = null;
            String Message = "";

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {

                    var newobj = _repositoryWrapper.Driver.FindByID(DriverID);
                    newobj.inactive = false;
                    _repositoryWrapper.Driver.Update(newobj);
                    Message = "Delete Successfully!";
                    objresponse = new { status = 1, messages = Message };

                }
                else
                {
                    Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, messages = Message };

                }

            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }

            return objresponse;
        }



    }
}