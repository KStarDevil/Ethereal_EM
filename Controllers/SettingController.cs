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
using OfficeOpenXml;

namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class SettingController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public SettingController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;

        }

        [HttpPost("GetSetting", Name = "GetSetting")]
        [Authorize]
        public dynamic GetSetting([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            var mainQuery = Enumerable.Repeat(new
            {
                SettingID = default(int),
                Name = default(string),
                Value = default(string)
            }, 0).AsQueryable();

            int currentPage = obj.skip;
            int rowsPerPage = obj.take;
            string sortField = null;
            string sortBy = "";

            if (obj.sort.Count > 0)
            {
                var sort = obj.sort[0];
                sortBy = sort.dir == null ? sortBy : sort.dir.Value;
                sortField = sort.field.Value;
            }
            if (sortField == null || sortField == "")
                sortField = "Name";
            if (sortBy == null || sortBy == "")
                sortBy = "desc";

            mainQuery = _repositoryWrapper.Setting.GetSettingData();
            var a = mainQuery.ToList();


            var objSort = new SortModel();
            objSort.ColId = sortField;
            objSort.Sort = sortBy;
            var sortList = new System.Collections.Generic.List<SortModel>();
            sortList.Add(objSort);
            mainQuery = mainQuery.OrderBy(sortList);
            var tmpList = PaginatedList<dynamic>.Create(mainQuery, currentPage, rowsPerPage);
            var objtotal = tmpList.TotalRecords;
            var objresult = tmpList.Select(x =>
               new
               {
                   SettingID = x.SettingID,
                   Name = x.Name,
                   Value = x.Value
               }).ToList();



            dynamic objresponse = new { data = objresult, dataFoundRowsCount = objtotal };
            return objresponse;
        }

        [HttpPost("AddSetting", Name = "AddSetting")]
        [Authorize]
        public dynamic AddSetting([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            string errmsg = "";
            int Id = 0;
            //string name = obj.Name.Value;
            string value = obj.Value.Value;
            Id = obj.SettingID;
            errmsg = "";
            dynamic objresponse;
            
            var objSetting = _repositoryWrapper.Setting.FindById(Id);
            if (objSetting != null)
            {
               // objSetting.Name = obj.Name.ToString();
                objSetting.Value = obj.Value.ToString();
                if (objSetting.Name != "")
                {
                    _repositoryWrapper.Setting.Update(objSetting);
                    errmsg += "Update Successfully";
                    _repositoryWrapper.EventLog.Update(objSetting);

                }
                else
                {
                    errmsg = "is needed";
                }

            }
           

            errmsg = "\r\n";


            objresponse = new { data = errmsg, id = Id };
            return objresponse;
        }

    }
}
