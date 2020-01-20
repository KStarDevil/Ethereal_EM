using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using Ethereal_EM.Repository;
using Kendo.Mvc.UI;
using System.Linq;

namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class CompanyController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CompanyController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpPost("GetCompany", Name = "GetCompany")]
        [Authorize]
        public dynamic GetCompany([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.Company.GetAllCompany(param);

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

        [HttpPost("SaveCompany", Name = "SaveCompany")]
        [Authorize]
        public dynamic SaveCompany([FromBody] Newtonsoft.Json.Linq.JObject param)
        {

            dynamic obj = param;
            dynamic objresponse = null;
            string companyName = obj.companyName;
            string Message = "Save Unsuccessfully";
            int companyID = obj.companyID != null ? obj.companyID : 0;
            int LogInUserID = Int32.Parse(_tokenData.Userlevelid);
            try
            {
                Company newobj = new Company();
                newobj.name = obj.CompanyName;
                newobj.code = obj.Code;
                newobj.phone = obj.Phone;
                newobj.address = obj.Address;
                newobj.township = obj.Townshipid;
                newobj.state = obj.Stateid;
                newobj.modifieddate = DateTime.Now;
                newobj.inactive = true;
                _repositoryWrapper.Company.Create(newobj);
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
        [HttpPost("CheckDuplicateCompany", Name = "CheckDuplicateCompany")]
        [Authorize]
        public dynamic CheckDuplicateCompany([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresult = null;
            int CompanyID = obj.CompanyID != null ? obj.CompanyID : 0;
            string code = obj.Code;
            string CompanyName = obj.CompanyName;
            string Phone = obj.Phone;

            var duplicatedCode = _repositoryWrapper.Company.CheckDuplicateCode(CompanyID, code);
            var duplicateusername = _repositoryWrapper.Company.CheckDuplicateName(CompanyID, CompanyName);
            var duplicatedPhone = _repositoryWrapper.Company.CheckDuplicatePhone(CompanyID, Phone);
            objresult = new
            {
                Code = duplicatedCode > 0 ? 1 : 0,
                Name = duplicateusername > 0 ? 1 : 0,
                Phone = duplicatedPhone > 0 ? 1 : 0
            };

            dynamic objresponse = new { data = objresult };
            return objresponse;
        }
        [HttpGet("GetCompanyUpdate/{companyID}", Name = "GetCompanyUpdate")]
        [Authorize]
        public dynamic GetCompanyUpdate(int companyID)
        {
            dynamic objresponse = null;
            try
            {
                var query = _repositoryWrapper.Company.GetCompanyList(companyID);
                objresponse = new { data = query };
                return objresponse;
            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }

        [HttpPost("UpdateCompany", Name = "UpdateCompany")]
        [Authorize]
        public dynamic UpdateCompany([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int companyID = obj.CompanyID != null ? obj.CompanyID : 0;
            string companyName = obj.CompanyName;
            string Message = "Update Unsuccessfully";
            try
            {

                var newobj = _repositoryWrapper.Company.FindByID(companyID);
                newobj.companyID = obj.CompanyID;
                newobj.name = obj.CompanyName;
                newobj.code = obj.Code;
                newobj.phone = obj.Phone;
                newobj.address = obj.Address;
                newobj.township = obj.Townshipid;
                newobj.state = obj.Stateid;
                newobj.modifieddate = DateTime.Now;
                newobj.inactive = true;
                _repositoryWrapper.Company.Update(newobj);
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


        [HttpDelete("DeleteCompany/{companyID}", Name = "DeleteCompany")]
        [Authorize]
        public dynamic DeleteCompany(int companyID)
        {
            dynamic objresponse = null;
            string Message = "Delete Unsuccessfully!";
            try
            {

                var newobj = _repositoryWrapper.Company.FindByID(companyID);
                newobj.inactive = false;
                _repositoryWrapper.Company.Update(newobj);
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

        [HttpGet("GetStateListForCompany", Name = "GetStateListForCompany")]
        [Authorize]
        public dynamic GetStateListForCompany()
        {
            var query1 = Enumerable.Repeat(new
            {
                Stateid = default(int),
                State = default(string),

            }, 0).AsQueryable();
            dynamic objresult = null;
            query1 = _repositoryWrapper.Company.GetStateListForCompany();
            objresult = (query1.ToList()).Distinct();

            dynamic objresponse = new { data = objresult };
            return objresponse;
        }



        [HttpGet("GetTownshipList/{stateID}", Name = "GetTownshipList")]
        [Authorize]
        public dynamic GetTownshipList(int stateID)
        {
            dynamic objresult = null;
            var query1 = _repositoryWrapper.Company.GetTownshipList(stateID);
            objresult = query1;

            dynamic objresponse = new { data = objresult };
            return objresponse;

        }

    }
}
