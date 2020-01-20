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
    public class BowserMobileController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public static IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;


        public BowserMobileController(IRepositoryWrapper RW, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repositoryWrapper = RW;
        }

        [HttpPost("GetAllMobileBowserList", Name = "GetAllMobileBowserList")]
        [Authorize]
        public dynamic GetAllMobileBowserList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            dynamic Mobile_BowserList = null;
            dynamic BowserList = null;

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {

                    Mobile_BowserList = _repositoryWrapper.Bowser.GetAllBowserListMoblie();
                    if (Mobile_BowserList.Count == 0)
                    {
                        BowserList = "Sorry!! There is no record";
                        // objresponse = new { data = BowserList };
                        objresponse = new { status = 0, messages = BowserList };

                    }
                    else
                    {
                        // objresponse = new { data = Mobile_BowserList };
                        objresponse = new { status = 1, messages = "success", data = Mobile_BowserList };
                    }

                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    // objresponse = new { data = Message };
                    objresponse = new { status = 0, messages = Message };
                }


            }

            catch (Exception ex)
            {
                // _repositoryWrapper.EventLog.Error("", ex.Message);
                // objresponse = new { error = ex.Message };
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }

            return objresponse;
        }

        [HttpPost("GetMobileBowserData", Name = "GetMobileBowserData")]
        [Authorize]
        public dynamic GetMobileBowserData([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            int BowserID = objParamInfo.BowserID;
            dynamic objresponse = null;
            dynamic BowserData = null;

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {

                    var query = _repositoryWrapper.Bowser.GetBowserData(BowserID);
                    if (query == null)
                    {
                        BowserData = "Sorry!! There is no record";
                        // objresponse = new { data = BowserData };
                        objresponse = new { status = 0, messages = BowserData };

                    }
                    else
                    {
                        // objresponse = new { data = query };
                        objresponse = new { status = 1, messages = "success", data = query };
                    }

                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    // objresponse = new { data = Message };
                    objresponse = new { status = 0, messages = Message };
                }


            }

            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                // objresponse = new { error = ex.Message };
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }

            return objresponse;
        }

        [HttpPost("SaveMobileBowser", Name = "SaveMobileBowser")]
        [Authorize]
        public dynamic SaveMobileBowser([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            dynamic objresponse = null;
            // int CustomerID = Int32.Parse(_tokenData.UserID);
            int CustomerID = objParamInfo.CustomerID;
            string Message = "";
            int BowserID = objParamInfo.BowserID != null ? objParamInfo.BowserID : 0;
            string bowsername = objParamInfo.bowsername;
            string carno = objParamInfo.carno;
            string ownerName = objParamInfo.ownername;
            string address = objParamInfo.address;
            string phone = objParamInfo.phone;
            // string CompanyID = _tokenData.CompanyID;
            try
            {
                string customerId = _session.GetString("LoginUserID");
                // if(CustomerID == customerId)
                if (Convert.ToString(CustomerID) == customerId)
                {
                    var bobj = _repositoryWrapper.Bowser.FindByID(BowserID);
                    if (bobj != null)
                    {
                        bobj.bowserName = objParamInfo.bowsername;
                        bobj.carNo = objParamInfo.carno;
                        bobj.ownerName = objParamInfo.ownername;
                        bobj.address = objParamInfo.address;
                        bobj.phone = objParamInfo.phone;
                        //bobj.status = objParamInfo.status;
                        bobj.createuser = CustomerID;
                        bobj.user_type = true;
                        bobj.modifieddate = System.DateTime.Now;
                        bobj.inactive = true;
                        _repositoryWrapper.Bowser.Update(bobj);
                        // _repositoryWrapper.EventLog.Update(bobj);
                        if (objParamInfo.deleteitem.Count > 0)
                        {
                            for (int i = 0; i < objParamInfo.deleteitem.Count; i++)
                            {
                                int compartmentID = objParamInfo.deleteitem[i].ID;
                                var updateobj = _repositoryWrapper.Compartment.FindByID(compartmentID);
                                if (updateobj != null)
                                {
                                    updateobj.inactive = false;
                                    updateobj.modifieddate = System.DateTime.Now;
                                    _repositoryWrapper.Compartment.Update(updateobj);
                                    // _repositoryWrapper.EventLog.Update(updateobj);
                                }
                            }
                        }
                        for (int i = 0; i < objParamInfo.item.Count; i++)
                        {
                            int compartmentID = objParamInfo.item[i].ID;
                            var updateobj = _repositoryWrapper.Compartment.FindByID(compartmentID);
                            if (updateobj != null)
                            {
                                updateobj.bowserID = BowserID;
                                updateobj.calibration = objParamInfo.item[i].Calibration;
                                updateobj.capacity = objParamInfo.item[i].Size;
                                updateobj.name = objParamInfo.item[i].Name;
                                updateobj.inactive = true;
                                updateobj.modifieddate = System.DateTime.Now;
                                _repositoryWrapper.Compartment.Update(updateobj);
                                // _repositoryWrapper.EventLog.Update(updateobj);
                            }
                            else
                            {
                                var newcobj = new Compartment();
                                newcobj.bowserID = BowserID;
                                newcobj.calibration = objParamInfo.item[i].Calibration;
                                newcobj.capacity = objParamInfo.item[i].Size;
                                newcobj.name = objParamInfo.item[i].Name;
                                newcobj.inactive = true;
                                newcobj.modifieddate = System.DateTime.Now;
                                _repositoryWrapper.Compartment.Create(newcobj);
                                // _repositoryWrapper.EventLog.Insert(newcobj);
                            }
                        }
                        Message = "Update Successfully! ";

                    }
                    else
                    {
                        var newobj = new Bowser();
                        newobj.bowserName = objParamInfo.bowsername;
                        newobj.carNo = objParamInfo.carno;
                        newobj.ownerName = objParamInfo.ownername;
                        newobj.address = objParamInfo.address;
                        newobj.phone = objParamInfo.phone;
                        newobj.modifieddate = System.DateTime.Now;
                        newobj.inactive = true;
                        newobj.status = 0;
                        newobj.createuser = CustomerID;
                        newobj.user_type = true;
                        _repositoryWrapper.Bowser.Create(newobj);
                        BowserID = newobj.bowserID;

                        for (int i = 0; i < objParamInfo.item.Count; i++)
                        {
                            var newcobj = new Compartment();
                            newcobj.bowserID = BowserID;
                            newcobj.calibration = objParamInfo.item[i].Calibration;
                            newcobj.capacity = objParamInfo.item[i].Size;
                            newcobj.name = objParamInfo.item[i].Name;
                            newcobj.inactive = true;
                            newcobj.modifieddate = System.DateTime.Now;
                            _repositoryWrapper.Compartment.Create(newcobj);

                        }
                        Message = "Save Successfully!";
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

                // objresponse = new { error = ex.Message };
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }

            return objresponse;
        }
        [HttpPost("CheckDuplicateBowserMobile", Name = "CheckDuplicateBowserMobile")]
        [Authorize]
        public dynamic CheckDuplicateBowserMobile([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresult = null;
            int BowserID = obj.BowserID != null ? obj.BowserID : 0;
            string carno = obj.carno;
            string Phone = obj.phone;
            string CustomerID = obj.CustomerID;
            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {
                    var duplicatedCarno = _repositoryWrapper.Bowser.CheckDuplicateCarNo(BowserID, carno);
                    var duplicatedPhone = _repositoryWrapper.Bowser.CheckDuplicatePhone(BowserID, Phone);
                    objresult = new
                    {
                        CarNo = duplicatedCarno > 0 ? 1 : 0,
                        Phone = duplicatedPhone > 0 ? 1 : 0
                    };
                    List<dynamic> list = new List<dynamic>();
                    list.Add(objresult);
                    objresult = new { status = 1, messages = "success", data = list };
                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    objresult = new { status = 0, messages = Message };
                }
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresult = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }
            return objresult;
        }
        [HttpPost("DeleteMobileBowser", Name = "DeleteMobileBowser")]
        [Authorize]
        public dynamic DeleteMobileBowser([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            int BowserID = objParamInfo.BowserID;
            dynamic objresponse = null;
            String Message = "";

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if (CustomerID == customerId)
                {

                    var newobj = _repositoryWrapper.Bowser.FindByID(BowserID);
                    newobj.inactive = false;
                    _repositoryWrapper.Bowser.Update(newobj);
                    // _repositoryWrapper.EventLog.Update(newobj);
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
                // _repositoryWrapper.EventLog.Error("", ex.Message);
                // objresponse = new { status = 0, error = ex.Message };
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages = "Oh! Something Wrong.Please try again!" };
            }

            return objresponse;
        }


    }
}