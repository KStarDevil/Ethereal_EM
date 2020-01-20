using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ethereal_EM.Repository;
using System.Linq;
using Kendo.Mvc.UI;
using System;

namespace Ethereal_EM
{
    [Route("api/[controller]")]
    public class SaleInvoiceController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;

        public SaleInvoiceController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpGet("GetCustomerComboSlaeInvoice", Name = "GetCustomerComboSlaeInvoice")]
        [Authorize]
        public dynamic GetCustomerComboSlaeInvoice()
        {
            var query = _repositoryWrapper.Customer.GetCustomerCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpPost("GetAllSaleInvoiceList", Name = "GetAllSaleInvoiceList")]
        [Authorize]
        public dynamic GetAllSaleInvoiceList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;

            DataSourceResult mainQuery = _repositoryWrapper.SaleInvoice.GetAllSaleInvoiceList(param);

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

        [HttpPost("SaveInvoice", Name = "SaveInvoice")]
        [Authorize]
        public dynamic SaveInvoice([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            dynamic obj = param;
            try
            {
                SaleInvoice newobj = new SaleInvoice();
            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }

        [HttpPost("UpdateInvoice", Name = "UpdateInvoice")]
        [Authorize]
        public dynamic UpdateInvoice([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            dynamic obj = param;
            string saleinvoiceID = obj.saleinvoiceID;
            try
            {

            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }

        [HttpPost("DeleteInvoice", Name = "DeleteInvoice")]
        [Authorize]
        public dynamic DeleteInvoice([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            dynamic obj = param;
            string saleinvoiceID = obj.saleinvoiceID;
            try
            {

            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }
    }
}