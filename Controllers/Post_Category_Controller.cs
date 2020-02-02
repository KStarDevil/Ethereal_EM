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
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json;

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

        [HttpGet("FilterPostCategory", Name = "FilterPostCategory")]
        public dynamic FilterPostCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            dynamic cat = param;
            int[] category_id = cat.category_id.ToObject<int[]>();
            int filter_method = cat.filter_method;

            try
            {
                dynamic PostData = _repositoryWrapper.Post_Category_Repository.GetPostByCategoryID(category_id, filter_method);

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
                string category_id = dd.category_id;
                int post_id = dd.post_id;
                tbl_post_category c = new tbl_post_category();
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
                string category_id = dd.category_id;
                int post_id = dd.post_id;

                // tbl_category c = new tbl_category();
                dynamic c = _repositoryWrapper.Post_Category_Repository.GetPostByPostID(post_id);
                tbl_post_category category = c as tbl_post_category;
                category.category_id = category_id;
                category.post_id = post_id;

                _repositoryWrapper.Post_Category_Repository.Update(category);

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
                string category_id = dd.category_id;
                int post_id = dd.post_id;

                // tbl_category c = new tbl_category();
                dynamic c = _repositoryWrapper.Post_Category_Repository.GetPostByPostID(post_id);
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