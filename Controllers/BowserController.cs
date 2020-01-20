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
    public class BowserController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;


        public BowserController(IRepositoryWrapper RW) 
        {
            _repositoryWrapper = RW;
        }
        [HttpPost("GetAllBowserList", Name = "GetAllBowserList")]
        [Authorize]
        public dynamic GetAllBowserList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.Bowser.GetAllBowserList(param);

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

        [HttpPost("CheckDuplicateBowser", Name = "CheckDuplicateBowser")]
        [Authorize]
        public dynamic CheckDuplicateBowser([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresult = null;
            int BowserID = obj.BowserID != null ? obj.BowserID : 0;
            string carno = obj.carno;
            string Phone = obj.phone;

            var duplicatedCarno = _repositoryWrapper.Bowser.CheckDuplicateCarNo(BowserID, carno);
            var duplicatedPhone = _repositoryWrapper.Bowser.CheckDuplicatePhone(BowserID, Phone);
            objresult = new
            {
                CarNo = duplicatedCarno > 0 ? 1 : 0,
                Phone = duplicatedPhone > 0 ? 1 : 0
            };

            List<dynamic> dd = new List<dynamic>();
            dd.Add(objresult);
            dynamic objresponse = new { data = dd };
            return objresponse;
        }
        [HttpGet("GetBowserData/{BowserID}", Name = "GetBowserData")]
        [Authorize]
        public dynamic GetBowserData(int BowserID)
        {
            dynamic objresponse = null;
            try
            {
                var query = _repositoryWrapper.Bowser.GetBowserData(BowserID);
                objresponse = new { data = query };
                return objresponse;
            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }

        [HttpPost("SaveBowser", Name = "SaveBowser")]
        [Authorize]
        public dynamic SaveBowser([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int LoginID = Int32.Parse(_tokenData.UserID);
            int BowserID = obj.BowserID != null ? obj.BowserID : 0;
            string CompanyID = _tokenData.CompanyID;
            try
            {
                var bobj = _repositoryWrapper.Bowser.FindByID(BowserID);
                if (bobj != null)
                {
                    bobj.bowserName = obj.bowsername;
                    bobj.carNo = obj.carno;
                    bobj.ownerName = obj.ownername;
                    bobj.address = obj.address;
                    bobj.phone = obj.phone;
                   // bobj.status = obj.status;
                    bobj.user_type = false;
                    bobj.createuser = LoginID;
                    bobj.modifieddate = System.DateTime.Now;
                    bobj.inactive = true;
                    _repositoryWrapper.Bowser.Update(bobj);
                    _repositoryWrapper.EventLog.Update(bobj);
                    if (obj.deleteitem.Count > 0)
                    {
                        for (int i = 0; i < obj.deleteitem.Count; i++)
                        {
                            int compartmentID = obj.deleteitem[i].ID;
                            var updateobj = _repositoryWrapper.Compartment.FindByID(compartmentID);
                            if (updateobj != null)
                            {
                                updateobj.inactive = false;
                                updateobj.modifieddate = System.DateTime.Now;
                                _repositoryWrapper.Compartment.Update(updateobj);
                                _repositoryWrapper.EventLog.Update(updateobj);
                            }
                        }
                    }
                    for (int i = 0; i < obj.item.Count; i++)
                    {
                        int compartmentID = obj.item[i].ID;
                        var updateobj = _repositoryWrapper.Compartment.FindByID(compartmentID);
                        if (updateobj != null)
                        {
                            updateobj.bowserID = BowserID;
                            updateobj.calibration = obj.item[i].Calibration;
                            updateobj.capacity = obj.item[i].Size;
                            updateobj.name = obj.item[i].Name;
                            updateobj.inactive = true;
                            updateobj.modifieddate = System.DateTime.Now;
                            _repositoryWrapper.Compartment.Update(updateobj);
                            _repositoryWrapper.EventLog.Update(updateobj);
                        }
                        else
                        {
                            var newcobj = new Compartment();
                            newcobj.bowserID = BowserID;
                            newcobj.calibration = obj.item[i].Calibration;
                            newcobj.capacity = obj.item[i].Size;
                            newcobj.name = obj.item[i].Name;
                            newcobj.inactive = true;
                            newcobj.modifieddate = System.DateTime.Now;
                            _repositoryWrapper.Compartment.Create(newcobj);
                            _repositoryWrapper.EventLog.Insert(newcobj);
                        }
                    }

                }
                else
                {
                    var newobj = new Bowser();
                    newobj.bowserName = obj.bowsername;
                    newobj.carNo = obj.carno;
                    newobj.ownerName = obj.ownername;
                    newobj.address = obj.address;
                    newobj.phone = obj.phone;
                    newobj.user_type = false; 
                    newobj.createuser = LoginID;
                    newobj.modifieddate = System.DateTime.Now;
                    newobj.inactive = true;
                    _repositoryWrapper.Bowser.Create(newobj);
                    _repositoryWrapper.EventLog.Insert(newobj);
                    BowserID = newobj.bowserID;

                    for (int i = 0; i < obj.item.Count; i++)
                    {
                        int compartmentID = obj.item[i].ID;
                        var newcobj = new Compartment();
                        newcobj.bowserID = BowserID;
                        newcobj.calibration = obj.item[i].Calibration;
                        newcobj.capacity = obj.item[i].Size;
                        newcobj.name = obj.item[i].Name;
                        newcobj.inactive = true;
                        newcobj.modifieddate = System.DateTime.Now;
                        _repositoryWrapper.Compartment.Create(newcobj);
                        _repositoryWrapper.EventLog.Insert(newcobj);

                    }
                }

                objresponse = new { data = BowserID };
            }
            catch (ValidationException vex)
            {
                _repositoryWrapper.EventLog.Error("Bowser Controller/ Save Bowser", vex.Message);
                objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }

        [HttpDelete("DeleteBowser/{BowserID}", Name = "DeleteBowser")]
        [Authorize]
        public dynamic DeleteBowser(int BowserID)
        {
            dynamic objresponse = null;
            bool result = false;
            try
            {
                var newobj = _repositoryWrapper.Bowser.FindByID(BowserID);
                newobj.inactive = false;
                _repositoryWrapper.Bowser.Update(newobj);
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
        [HttpPost("changeStatusBowser", Name ="changeStatusBowser")]
        [Authorize]
        public dynamic changeStatusBowser([FromBody] Newtonsoft.Json.Linq.JValue param)
        {
            dynamic objresponse = null;
            dynamic obj=param;
            int BowserID=obj;

            try
            {
                var dobj = _repositoryWrapper.Bowser.FindByID(BowserID);
                if(dobj.status == 0){
                    dobj.status = 1;
                }
                 _repositoryWrapper.Bowser.Update(dobj.status);
                return objresponse;
            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }

    }
}