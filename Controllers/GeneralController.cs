using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using Ethereal_EM.Repository;

namespace Ethereal_EM
{
    [Route("api/[controller]")]
    public class GeneralController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GeneralController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }



        [HttpGet("GetGeneralTypeComboData", Name = "GetGeneralTypeComboData")]
        [Authorize]
        public dynamic GetGeneralTypeComboData()
        {
            var query1 = Enumerable.Repeat(new
            {
                type = default(string)
            }, 0).AsQueryable();
            dynamic objresult = null;
            query1 = _repositoryWrapper.General.GetAllGeneral();
            objresult = (query1.ToList()).Distinct();

            dynamic objresponse = new { data = objresult };
            return objresponse;
        }


        [HttpPost("GetGeneralType", Name = "GetGeneralType")]
        [Authorize]
        public dynamic GetGeneralType([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            var mainQuery = Enumerable.Repeat(new
            {
                id = default(int),
                stateid = default(int?),
                name = default(string),
                type = default(string),
                isactive = default(bool)
            }, 0).AsQueryable();

            int currentPage = Convert.ToInt32(obj.gridState.skip.Value);
            int rowsPerPage = Convert.ToInt32(obj.gridState.take.Value);
            string sortField = null;
            string sortBy = "";

            if (obj.gridState.sort.Count > 0)
            {
                var sort = obj.gridState.sort[0];
                sortBy = sort.dir == null ? sortBy : sort.dir.Value;
                sortField = sort.field.Value;
            }
            if (sortField == null || sortField == "")
                sortField = "Name";
            if (sortBy == null || sortBy == "")
                sortBy = "desc";

            mainQuery = _repositoryWrapper.General.GetGeneralTypes();

            if (obj.type.ToString() != "")
            {
                string type = obj.type.Value.ToString();
                mainQuery = mainQuery.Where(m => m.type == type);
            }

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
                   id = x.id,
                   stateid = x.stateid,
                   type = x.type,
                   Name = x.name,
                   isactive = x.isactive
               }).ToList();
            dynamic objresponse = new { data = objresult, dataFoundRowsCount = objtotal };
            return objresponse;
        }

        [HttpPost("GetTownshipType", Name = "GetTownshipType")]
        [Authorize]
        public dynamic GetTownshipType([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            var mainQuery = Enumerable.Repeat(new
            {
                id = default(int),
                stateid = default(int?),
                name = default(string),
                type = default(string),
                isactive = default(bool)
            }, 0).AsQueryable();

            int currentPage = Convert.ToInt32(obj.gridState.skip.Value);
            int rowsPerPage = Convert.ToInt32(obj.gridState.take.Value);
            string sortField = null;
            string sortBy = "";

            if (obj.gridState.sort.Count > 0)
            {
                var sort = obj.gridState.sort[0];
                sortBy = sort.dir == null ? sortBy : sort.dir.Value;
                sortField = sort.field.Value;
            }
            if (sortField == null || sortField == "")
                sortField = "Name";
            if (sortBy == null || sortBy == "")
                sortBy = "desc";

            mainQuery = _repositoryWrapper.General.GetGeneralTypes();

            if (obj.type.Value != 0)
            {
                int stateid = Convert.ToInt32(obj.type.Value);
                mainQuery = mainQuery.Where(m => m.stateid == stateid);
            }
            else if (obj.type.Value == 0)
            {
                int stateid = Convert.ToInt32(obj.type.Value);
                mainQuery = mainQuery.Where(m => m.stateid != null);
            }
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
                   id = x.id,
                   stateid = x.stateid,
                   type = x.type,
                   Name = x.name,
                   isactive = x.isactive
               }).ToList();
            dynamic objresponse = new { data = objresult, dataFoundRowsCount = objtotal };
            return objresponse;
        }


        [HttpPost("AddGeneral", Name = "AddGeneral")]
        [Authorize]
        public dynamic AddGeneral([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            string errmsg = "";
            int Id = 0;
            int stateid = obj.stateid == null ? 0 : 1;
            string name = obj.Name.Value;
            string type = obj.type.Value;
            Id = Convert.ToInt32(obj.id.Value);
            errmsg = "";
            dynamic objresponse;
            var GeneralNamelist = _repositoryWrapper.General.CheckDuplicateGeneralName(Id, name);

            if (GeneralNamelist > 0)
            {
                errmsg += " Name is already use.";
                return objresponse = new { data = errmsg, id = Id };
            }
            var objGeneral = _repositoryWrapper.General.FindByid(Id);
            if (objGeneral != null)
            {
                objGeneral.name = obj.Name.ToString();
                objGeneral.type = obj.type.ToString();
                objGeneral.stateid = obj.stateid;
                objGeneral.isactive = true;
                if (objGeneral.name != "")
                {
                    _repositoryWrapper.General.Update(objGeneral);
                    errmsg += "Update Successfully";
                    _repositoryWrapper.EventLog.Update(objGeneral);

                }
                else
                {
                    errmsg = "is needed";
                }

            }
            else
            {
                var newobj = new General();
                newobj.name = obj.Name.Value;
                newobj.type = obj.type.Value;
                newobj.stateid = obj.stateid;
                newobj.isactive = true;
                if (newobj.name != "")
                {
                    _repositoryWrapper.General.Create(newobj);

                    errmsg += "Save Successfully";
                    _repositoryWrapper.EventLog.Insert(newobj);
                    Id = newobj.id;

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

        [HttpPost("DeleteGeneral", Name = "DeleteGeneral")]
        [Authorize]
        public dynamic DeleteGeneral([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            int Id = obj.id;
            dynamic objresponse = null;
            var objGeneral = _repositoryWrapper.General.FindByid(Id);
            if (objGeneral != null)
            {
                objGeneral.isactive = false;
                _repositoryWrapper.General.Update(objGeneral);
            }
            _repositoryWrapper.EventLog.Delete(objGeneral);

            objresponse = new { data = true };
            return objresponse;
        }

        [HttpGet("GetStateList", Name = "GetStateList")]
        [Authorize]
        public dynamic GetStateList()
        {
            var query1 = Enumerable.Repeat(new
            {
                name = default(string),
                stateid = default(int),
            }, 0).AsQueryable();
            dynamic objresult = null;
            query1 = _repositoryWrapper.General.GetStateList();
            objresult = (query1.ToList()).Distinct();

            dynamic objresponse = new { data = objresult };
            return objresponse;
        }

    }
}
