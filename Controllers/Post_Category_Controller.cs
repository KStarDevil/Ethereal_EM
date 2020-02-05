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
            try
            {
                int filter_method = cat.filter_method;
                int[] category_id = new int[] { };
                string search_text = cat.search_text;
                int currentPage = cat.currentPage;
                int rowsPerPage = cat.rowsPerPage;
                if (String.IsNullOrEmpty(search_text))
                {
                    search_text = string.Empty;
                }
                if (cat.category_id != null)
                {
                    category_id = cat.category_id.ToObject<int[]>();
                    if (category_id.Contains(0))
                    {
                        filter_method = 0;
                    }
                }
                else
                {
                    category_id = new int[0];
                    filter_method = 0;
                }

                dynamic objresult = _repositoryWrapper.Post_Category_Repository.GetPostByCategoryID(category_id, filter_method, search_text);
                IEnumerable<dynamic> tamplist = PaginatedList<dynamic>.Create(objresult, currentPage, rowsPerPage);
                var PostData = tamplist.Select(x =>
                                new
                                {
                                    post_id = x.post_id,
                                    user_photo = x.user_photo,
                                    uploader_id = x.uploader_id,
                                    content_text = x.content_text,
                                    photo_count = x.photo_count,
                                    created_date = x.created_date
                                }).ToList();
                if (PostData == null)
                {
                    jsondata = new { status = 0, Message = "No Data", data = new { PostData } };
                }
                else
                {
                    if (PostData.Count == 0)
                    {
                        jsondata = new { status = 0, Message = "No Data", data = new { PostData } };
                    }
                    else
                    {
                        jsondata = new { status = 1, Message = "Success", data = new { PostData } };
                    }

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
                save = new { status = 1, Message = "Save Successfully" };

            }
            catch (Exception ex)
            {
                save = new { status = 0, Message = ex.Message };
            }
            
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
                Update = new { status = 1, Message = "Update Successfully" };
            }
            catch (Exception ex)
            {
                Update = new { status = 0, Message = ex.Message };
            }
            
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