using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using Ethereal_EM.Repository;
using Kendo.Mvc.UI;
using System.Linq;

namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class CashReceiptController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CashReceiptController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpPost("GetAllCashRecriptList", Name = "GetAllCashRecriptList")]
        [Authorize]
        public dynamic GetAllCashRecriptList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;

            try
            {
                DataSourceResult mainQuery = _repositoryWrapper.CashReceipt.GetAllCashRecriptList(param);

                if (mainQuery == null)
                {
                    objresponse = new { data = "", dataFoundRowsCount = 0 };
                }
                else
                {
                    objresponse = new { data = mainQuery.Data, total = mainQuery.Total };
                }

            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }

            return objresponse;
        }

        [HttpGet("GetCashReceiptEditList/{cashreceiptid}", Name = "GetCashReceiptEditList")]
        [Authorize]
        public dynamic GetCashReceiptEditList(string cashreceiptid)
        {

            dynamic objresponse = null;


            try
            {
                var query = _repositoryWrapper.CashReceipt.GetCashReceiptEditList(cashreceiptid);
                objresponse = new { data = query };

            }

            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
            }

            return objresponse;
        }

    }
}