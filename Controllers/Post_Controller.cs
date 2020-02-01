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

        [HttpGet("GetPost", Name = "GetPost")]
        public dynamic GetPost([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                dynamic PostData = _repositoryWrapper.Post_Repository.GetPost();
                dynamic PostDetailData = _repositoryWrapper.Post_Detail_Repository.GetPostDetail();
                if (PostData == null && PostDetailData == null)
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

        [HttpPost("SavePost", Name = "SavePost")]
        public dynamic SavePost([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic save = null;
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

                tbl_post p = new tbl_post();
                tbl_post_detail pd = new tbl_post_detail();

                p.post_id = id;
                p.user_photo = user_photo;
                p.uploader_id = uploader_id;
                p.content_text = content_text;
                p.photo_count = photo_count;

                pd.post_detail_id = post_detail_id;
                pd.post_id = id;
                pd.content_text = content_text;
                pd.photo = photo;

                _repositoryWrapper.Post_Repository.Create(p);
                _repositoryWrapper.Post_Detail_Repository.Create(pd);
            }
            catch (Exception ex)
            {
                save = new { status = 0, Message = ex.Message };
            }
            save = new { status = 1, Message = "Save Successfully" };
            return save;
        }

        [HttpPost("UpdatePost", Name = "UpdatePost")]
        public dynamic UpdatePost([FromBody] Newtonsoft.Json.Linq.JObject param)
        {

            dynamic update = null;
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

                // tbl_post p = new tbl_post();
                // tbl_post_detail pd = new tbl_post_detail();
                dynamic p = _repositoryWrapper.Post_Repository.GetPostByID(id);
                dynamic pd = _repositoryWrapper.Post_Detail_Repository.GetPostDetailByID(post_detail_id);

                p.post_id = id;
                p.user_photo = user_photo;
                p.uploader_id = uploader_id;
                p.content_text = content_text;
                p.photo_count = photo_count;

                pd.post_detail_id = post_detail_id;
                pd.post_id = id;
                pd.content_text = content_text;
                pd.photo = photo;

                _repositoryWrapper.Post_Repository.Update(p);
                _repositoryWrapper.Post_Detail_Repository.Update(pd);
            }
            catch (Exception ex)
            {
                update = new { status = 0, Message = ex.Message };
            }
            update = new { status = 1, Message = "Update Successfully" };
            return update;
        }

        [HttpPost("DeletePost", Name = "DeletePost")]
        public dynamic DeletePost([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
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

                    dynamic main1 = _repositoryWrapper.Post_Repository.GetPostByID(id);
                    tbl_post p = main1 as tbl_post;
                    _repositoryWrapper.Post_Repository.Delete(p);
                    List<Post_Detail_Repository> main2 = _repositoryWrapper.Post_Detail_Repository.GetPostDetailByPostID(id);
                    foreach (var item in main2)
                    {
                        _repositoryWrapper.Post_Detail_Repository.Delete(item);
                    };



                    result =  new { status = 0, Message = "Delete Successfully" };
                }
                catch (Exception ex)
                {
                    jsondata = new { status = 0, Message = ex.Message };
                }
                return result;
            }
            catch (Exception ex)
            {
                jsondata = new { status = 0, Message = ex.Message };
            }
            return jsondata;
        }
    }
}