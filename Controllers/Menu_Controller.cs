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
        [HttpGet("GetMenu", Name = "GetMenu")]
        public dynamic GetMenu([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic jsondata = null;
            try
            {
                // dynamic dd = param;
                // int id = dd.id;
                List<tbl_menu> menulist = _repositoryWrapper.Menu_Repository.GetMenu();
                List<tbl_menu> Verified_menu = new List<tbl_menu>();
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
                        if(sub_menu.Count > 0){
                             Verified_menu.Add(item);
                        }
                        foreach (var item1 in sub_menu)
                        {
                            Verified_menu.Add(item1);
                        }
                    }
                }
                dynamic mainQuery = _repositoryWrapper.Menu_Repository.GetMenu();
                if (Verified_menu == null)
                {
                    jsondata = new { data = new { Verified_menu = "No Data" } };
                }
                else
                {
                    jsondata = new { data = new { Verified_menu } };
                }
            }
            catch (Exception ex)
            {
                jsondata = new { data = new { msg = ex.Message } };
            }
            return jsondata;
        }
    }
}