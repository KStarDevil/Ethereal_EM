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
    public class Menu_Controller : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public Menu_Controller(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpPost("GetMenu", Name = "GetMenu")]
        [Authorize]
        public dynamic GetMenu([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic result = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                int LogInUserID = Int32.Parse(_tokenData.UserID);
                List<tbl_menu> menulist = _repositoryWrapper.Menu_Repository.Get_Menu_By_Amdin_ID(LogInUserID);
                List<tbl_menu> Verified_menu = new List<tbl_menu>();
                List<tbl_menu> Unverified_menu = new List<tbl_menu>();
                foreach (var item in menulist)
                {
                    if (item.sub_menu_id == 0)
                    {
                        // foreach (var item1 in menulist)
                        // {
                        //     if (item.menu_id == item1.sub_menu_id)
                        //     {
                        //         Verified_menu.Add(item1);
                        //     }
                        // }
                        List<tbl_menu> sub_menu = menulist.Where(x => x.sub_menu_id == item.menu_id).ToList();
                        if (sub_menu.Count > 0)
                        {
                            Verified_menu.Add(item);
                        }
                        else
                        {
                            Unverified_menu.Add(item);
                        }
                        foreach (var item1 in sub_menu)
                        {
                            Verified_menu.Add(item1);
                        }
                    }
                    Verified_menu.AddRange(Unverified_menu);
                }
                dynamic mainQuery = _repositoryWrapper.Menu_Repository.GetMenu();
                if (Verified_menu == null || Verified_menu.Count <= 0)
                {
                    result = new { Status = 0, Message = "No Data", data = new { } };
                }
                else
                {
                    result = new { Status = 1, Message = "Success", data = new { Verified_menu } };
                }
            }
            catch (Exception ex)
            {
                result = new { Status = 0, Message = "Fail", data = new { } };
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}