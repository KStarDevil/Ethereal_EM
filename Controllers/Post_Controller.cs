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
    public class Post_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Post_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpPost("Get_Post", Name = "GetPost")]
        public dynamic Get_Post([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                // int id = dd.id;
                int currentPage = 0;
                int rowsPerPage = 5;
                if (dd.currentPage == null || dd.rowsPerPage == null)
                {
                    currentPage = 0;
                    rowsPerPage = 5;
                }
                else
                {
                    currentPage = dd.currentPage;
                    rowsPerPage = dd.rowsPerPage;
                }
                if (rowsPerPage <= 0)
                {
                    rowsPerPage = 5;
                }
                dynamic PostData = _repositoryWrapper.Post_Repository.GetPost();
                dynamic PostDetailData = _repositoryWrapper.Post_Detail_Repository.GetPostDetail();
                var Post_Data_List = _repositoryWrapper.Post_Repository.Data_To_List();
                var Post_Data_Detail_List = _repositoryWrapper.Post_Detail_Repository.Data_To_List();
                IEnumerable<dynamic> tamplist = PaginatedList<dynamic>.Create(PostData, currentPage, rowsPerPage);
                var PostData1 = tamplist.Select(x =>
                                new
                                {
                                    post_id = x.post_id,
                                    user_photo = x.user_photo,
                                    uploader_id = x.uploader_id,
                                    content_text = x.content_text,
                                    photo_count = x.photo_count,
                                    created_date = x.created_date,

                                }).ToList();

                IEnumerable<dynamic> tamplist1 = PaginatedList<dynamic>.Create(PostDetailData, currentPage, rowsPerPage);
                var PostDetailData1 = tamplist1.Select(x =>
                                new
                                {
                                    post_detail_id = x.post_detail_id,
                                    post_id = x.post_id,
                                    content_text = x.content_text,
                                    photo = x.photo,
                                }).ToList();

                if (PostData1 == null && PostDetailData1 == null)
                {
                    result = new { Status = 0, Message = "No Data", data = new { PostData1, Total_Page_Post = 0, PostDetailData1, Total_Page_Post_Detail = 0 } };
                }
                else
                {
                    int Total_Page_Post = (int)Math.Ceiling(Post_Data_List.Count / (double)rowsPerPage);
                    int Total_Page_Post_Detail = (int)Math.Ceiling(Post_Data_Detail_List.Count / (double)rowsPerPage);
                    if (PostData1.Count == 0 && PostDetailData1.Count == 0)
                    {
                        result = new { Status = 0, Message = "No Data", data = new { PostData1, Total_Page_Post, PostDetailData1, Total_Page_Post_Detail } };
                    }
                    else
                    {
                        result = new { Status = 1, Message = "Success", data = new { PostData1, Total_Page_Post, PostDetailData1, Total_Page_Post_Detail } };
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

        [HttpPost("SavePost", Name = "SavePost")]
        public dynamic SavePost([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int id = dd.post_id;

                string user_photo = dd.user_photo;
                int uploader_id = dd.uploader_id;
                string content_text = dd.content_text;
                int photo_count = dd.photo_count;
                DateTime created_date = DateTime.Now;

                int post_detail_id = dd.post_detail_id;
                string photo = dd.photo;


                tbl_post p = new tbl_post();
                tbl_post_detail pd = new tbl_post_detail();

                p.post_id = id;
                p.user_photo = user_photo;
                p.uploader_id = uploader_id;
                p.content_text = content_text;
                p.photo_count = photo_count;
                p.created_date = created_date;

                pd.post_detail_id = post_detail_id;
                pd.post_id = id;
                pd.content_text = content_text;
                pd.photo = photo;

                _repositoryWrapper.Post_Repository.Create(p);
                _repositoryWrapper.Post_Detail_Repository.Create(pd);
                result = new { Status = 1, Message = "Save Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Save Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        [HttpPost("UpdatePost", Name = "UpdatePost")]
        public dynamic UpdatePost([FromBody] Newtonsoft.Json.Linq.JObject param)
        {

            dynamic result = null;
            try
            {
                dynamic dd = param;
                int id = dd.post_id;

                string user_photo = dd.user_photo;
                int uploader_id = dd.uploader_id;
                string content_text = dd.content_text;
                int photo_count = dd.photo_count;

                int post_detail_id = dd.post_detail_id;
                string photo = dd.photo;
                DateTime created_date = DateTime.Now;

                // tbl_post p = new tbl_post();
                // tbl_post_detail pd = new tbl_post_detail();
                dynamic p = _repositoryWrapper.Post_Repository.GetPostByID(id);
                dynamic pd = _repositoryWrapper.Post_Detail_Repository.GetPostDetailByID(post_detail_id);

                p.post_id = id;
                p.user_photo = user_photo;
                p.uploader_id = uploader_id;
                p.content_text = content_text;
                p.photo_count = photo_count;
                p.created_date = created_date;

                pd.post_detail_id = post_detail_id;
                pd.post_id = id;
                pd.content_text = content_text;
                pd.photo = photo;

                _repositoryWrapper.Post_Repository.Update(p);
                _repositoryWrapper.Post_Detail_Repository.Update(pd);
                result = new { Status = 1, Message = "Update Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Delete Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        [HttpPost("DeletePost", Name = "DeletePost")]
        public dynamic DeletePost([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                dynamic dd = param;
                int id = dd.post_id;

                string user_photo = dd.user_photo;
                int uploader_id = dd.uploader_id;
                string content_text = dd.content_text;
                int photo_count = dd.photo_count;
                DateTime created_date = DateTime.Now;

                int post_detail_id = dd.post_detail_id;
                string photo = dd.photo;

                dynamic main1 = _repositoryWrapper.Post_Repository.GetPostByID(id);
                tbl_post p = main1 as tbl_post;
                _repositoryWrapper.Post_Repository.Delete(p);
                List<Post_Detail_Repository> main2 = _repositoryWrapper.Post_Detail_Repository.GetPostDetailByPostID(id);
                foreach (var item in main2)
                {
                    _repositoryWrapper.Post_Detail_Repository.Delete(item);
                };
                result = new { Status = 1, Message = "Delete Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Delete Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;

        }

        [HttpPost("Approve", Name = "Approve")]
        public dynamic Approve([FromBody] Newtonsoft.Json.Linq.JObject param)
        {

            dynamic result = null;
            try
            {
                dynamic dd = param;
                int id = dd.post_id;



                int status = dd.status;
                DateTime approved_rejected_date = DateTime.Now;

                // tbl_post p = new tbl_post();
                // tbl_post_detail pd = new tbl_post_detail();
                dynamic p = _repositoryWrapper.Post_Repository.GetPostByID(id);


                p.post_id = id;


                p.status = status;
                p.approved_rejected_date = approved_rejected_date;


                _repositoryWrapper.Post_Repository.Update(p);

                result = new { Status = 1, Message = "Approve Successfully", data = new { } };
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Approve Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }

            return result;
        }
    }
}