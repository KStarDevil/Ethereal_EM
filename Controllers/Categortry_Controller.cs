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
    public class Categortry_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Categortry_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("GetCategory", Name = "GetCategory")]
        public dynamic GetCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                dynamic PostData = _repositoryWrapper.Category_Repository.GetCategory();

                if (PostData == null)
                {
                    jsondata = new { status = 0, Message = "No Data", data = new { PostData } };
                }
                else
                {
                    jsondata = new { status = 1, Message = "Success", data = new { PostData } };
                }
            }
            catch (Exception ex)
            {
                jsondata = new { data = new { msg = ex.Message } };
            }
            return jsondata;
        }

        [HttpPost("SaveCategory", Name = "SaveCategory")]
        public dynamic SaveCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic save = null;
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
                save = new { status = 1, Message = "Save Successfully" };
            }
            catch (Exception ex)
            {
                save = new { status = 0, Message = ex.Message };
            }
            
            return save;
        }

        [HttpPost("UpdateCategory", Name = "UpdateCategory")]
        public dynamic UpdateCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic Update = null;
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
                Update = new { status = 1, Message = "Update Successfully" };
            }
            catch (Exception ex)
            {
                Update = new { status = 0, Message = ex.Message };
            }
            
            return Update;
        }

        [HttpPost("DeleteCategory", Name = "DeleteCategory")]
        public dynamic DeleteCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic Delete = null;
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

                _repositoryWrapper.Category_Repository.Delete(c);
                Delete = new { status = 1, Message = "Delete Successfully" };
            }
            catch (Exception ex)
            {
                Delete = new { status = 0, Message = ex.Message };
            }
            
            return Delete;
        }
    }
}