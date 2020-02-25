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
            dynamic result = null;
            try
            {
                dynamic Post_Category = _repositoryWrapper.Post_Category_Repository.GetPostCategory();

                if (Post_Category == null)
                {
                    result = new { Status = 0, Message = "No Data", data = new { Post_Category } };
                }
                else
                {
                    result = new { Status = 1, Message = "Success", data = new { Post_Category } };
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        [HttpPost("Filter_Post_Category", Name = "Filter_Post_Category")]
        public dynamic Filter_Post_Category([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            dynamic cat = param;
            try
            {
                int filter_method = cat.filter_method;
                int[] category_id = new int[] { };
                string search_text = cat.search_text;
                int currentPage = 0;
                int rowsPerPage = 5;
                if (cat.currentPage == null || cat.rowsPerPage == null)
                {
                    currentPage = 0;
                    rowsPerPage = 5;
                }
                else
                {
                    currentPage = cat.currentPage;
                    rowsPerPage = cat.rowsPerPage;
                }
                if (rowsPerPage <= 0)
                {
                    rowsPerPage = 5;
                }
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
                var Post_Data_List = _repositoryWrapper.Post_Category_Repository.Data_To_List();

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
                    result = new { Status = 0, Message = "No Data", data = new { PostData, Total_Page_Post = 0 } };
                }
                else
                {
                    int Total_Page_Post = (int)Math.Ceiling(Post_Data_List.Count / (double)rowsPerPage);
                    if (PostData.Count == 0)
                    {
                        result = new { Status = 0, Message = "No Data", data = new { PostData, Total_Page_Post } };
                    }
                    else
                    {
                        result = new { Status = 1, Message = "Success", data = new { PostData, Total_Page_Post } };
                    }

                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        [HttpPost("SavePostCategory", Name = "SavePostCategory")]
        public dynamic SaveCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                string category_id = dd.category_id;
                int post_id = dd.post_id;
                tbl_post_category c = new tbl_post_category();
                c.category_id = category_id;
                c.post_id = post_id;

                _repositoryWrapper.Post_Category_Repository.Create(c);
                result = new { Status = 1, Message = "Save Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Save Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        [HttpPost("UpdatePostCategory", Name = "UpdatePostCategory")]
        public dynamic UpdateCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
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
                result = new { Status = 1, Message = "Update Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Update Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        [HttpPost("DeletePostCategory", Name = "DeletePostCategory")]
        public dynamic DeleteCategory([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
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
                result = new { Status = 1, Message = "Delete Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Delete Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}