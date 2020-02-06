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

namespace Ethereal_EM
{
    [Route("api/[controller]")]
    public class Category_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Category_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("Get_Category", Name = "Get_Category")]
        public dynamic Get_Category([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic Category_Data = _repositoryWrapper.Category_Repository.GetCategory();

                if (Category_Data == null)
                {
                    result = new { Status = 0, Message = "No Data", data = new { Category_Data } };
                }
                else
                {
                    result = new { Status = 1, Message = "Success", data = new { Category_Data } };
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }
            return result;
        }

        [HttpPost("Save_Category", Name = "Save_Category")]
        public dynamic Save_Category([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int category_id = dd.category_id;
                int category_sub_id = dd.category_sub_id;
                string category_name = dd.category_name;

                tbl_category c = new tbl_category();

                c.category_id = category_id;
                c.category_sub_id = category_sub_id;
                c.category_name = category_name;

                _repositoryWrapper.Category_Repository.Create(c);
                result = new { Status = 1, Message = "Save Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }

            return result;
        }

        [HttpPost("Update_Category", Name = "Update_Category")]
        public dynamic Update_Category([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int category_id = dd.category_id;
                int category_sub_id = dd.category_sub_id;
                string category_name = dd.category_name;

                // tbl_category c = new tbl_category();
                dynamic c = _repositoryWrapper.Category_Repository.GetCategoryID(category_id);

                c.category_id = category_id;
                c.category_sub_id = category_sub_id;
                c.category_name = category_name;

                _repositoryWrapper.Category_Repository.Update(c);
                result = new { Status = 1, Message = "Update Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }

            return result;
        }

        [HttpPost("Delete_Category", Name = "Delete_Category")]
        public dynamic Delete_Category([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int category_id = dd.category_id;
                

                // tbl_category c = new tbl_category();
                dynamic c = _repositoryWrapper.Category_Repository.GetCategoryID(category_id);

                _repositoryWrapper.Category_Repository.Delete(c);
                result = new { Status = 1, Message = "Delete Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = ex.Message, data = new { } };
            }

            return result;
        }
    }
}