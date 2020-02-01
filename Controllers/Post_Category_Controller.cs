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
    public class Post_Category_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Post_Category_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpGet("GetPostCategory", Name = "GetPostCategory")]
        public dynamic GetPostCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                dynamic PostData = _repositoryWrapper.Post_Category_Repository.GetPostCategory();

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

        [HttpPost("SavePostCategory", Name = "SavePostCategory")]
        public dynamic SaveCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic save = null;
            try
            {
                dynamic dd = param;
                int post_category_id = dd.post_category_id;
                int category_id = dd.category_id;
                int post_id = dd.post_id;

                tbl_post_category c = new tbl_post_category();

                c.post_category_id = post_category_id;
                c.category_id = category_id;
                c.post_id = post_id;

                _repositoryWrapper.Post_Category_Repository.Create(c);

            }
            catch (Exception ex)
            {
                save = new { status = 0, Message = ex.Message };
            }
            save = new { status = 1, Message = "Save Successfully" };
            return save;
        }

        [HttpPost("UpdatePostCategory", Name = "UpdatePostCategory")]
        public dynamic UpdateCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic Update = null;
            try
            {
                dynamic dd = param;
                int post_category_id = dd.post_category_id;
                int category_id = dd.category_id;
                int post_id = dd.post_id;

                // tbl_category c = new tbl_category();
                dynamic c = _repositoryWrapper.Post_Category_Repository.GetPostCategoryID(post_category_id);

                c.post_category_id = post_category_id;
                c.category_id = category_id;
                c.post_id = post_id;

                _repositoryWrapper.Post_Category_Repository.Update(c);

            }
            catch (Exception ex)
            {
                Update = new { status = 0, Message = ex.Message };
            }
            Update = new { status = 1, Message = "Update Successfully" };
            return Update;
        }

        [HttpPost("DeletePostCategory", Name = "DeletePostCategory")]
        public dynamic DeleteCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic Delete = null;
            try
            {
                dynamic dd = param;
                int post_category_id = dd.post_category_id;
                int category_id = dd.category_id;
                int post_id = dd.post_id;

                // tbl_category c = new tbl_category();
                dynamic c = _repositoryWrapper.Post_Category_Repository.GetPostCategoryID(post_category_id);

                c.post_category_id = post_category_id;
                c.category_id = category_id;
                c.post_id = post_id;

                _repositoryWrapper.Post_Category_Repository.Delete(c);

            }
            catch (Exception ex)
            {
                Delete = new { status = 0, Message = ex.Message };
            }
            Delete = new { status = 1, Message = "Delete Successfully" };
            return Delete;
        }
    }
}