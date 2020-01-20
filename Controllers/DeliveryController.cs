using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Ethereal_EM.Repository;
using Kendo.Mvc.UI;
using System.ComponentModel.DataAnnotations;


namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class DeliveryController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;


        public DeliveryController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpGet("GetBowserDeliveryCombo/{DriverID}", Name = "GetBowserDeliveryCombo")]
        [Authorize]
        public dynamic GetBowserDeliveryCombo(int DriverID)
        {
            var query = _repositoryWrapper.Bowser.GetBowserComboData(DriverID);
            dynamic objresponse = new { data = query };
            return objresponse;
        }

        [HttpGet("GetDriverName/{Name}", Name = "GetDriverName")]
        [Authorize]
        public dynamic GetDriverName(string Name)
        {
            var query = _repositoryWrapper.Driver.GetDriverName(Name);
            dynamic objresponse = new { data = query };
            return objresponse;
        }

        [HttpPost("GetAllDeliveryOrderList", Name = "GetAllDeliveryOrderList")]
        [Authorize]
        public dynamic GetAllDeliveryOrderList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.DemandOrder.GetAllDemandOrderListByCar(param);

            if (mainQuery == null)
            {
                objresponse = new { data = "", dataFoundRowsCount = 0 };
            }
            else
            {
                objresponse = new { data = mainQuery.Data, total = mainQuery.Total };
            }
            return objresponse;
        }


    }
}