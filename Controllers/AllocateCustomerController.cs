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
using Kendo.Mvc.Extensions;
using System.ComponentModel.DataAnnotations;


namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class AllocateCustomerController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;


        public AllocateCustomerController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpPost("GetAllocateSupplierOrderList", Name = "GetAllocateSupplierOrderList")]
        [Authorize]
        public dynamic GetAllocateSupplierOrderList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            DateTime date = System.DateTime.Now;
            dynamic objresponse = null;
            dynamic lstResult = new List<dynamic>();
            dynamic lstResultAdd = new List<dynamic>();
            List<dynamic> lstFinalresult = new List<dynamic>();
            dynamic obj = param;
            int productID = obj.data.productID;
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            var SupplierOrderIDList = _repositoryWrapper.Supplierorder.FindByCondition(x => x.inactive == true).Select(x => x.supplierOrderID).ToList();
            for (int i = 0; i < SupplierOrderIDList.Count; i++)
            {
                string SupplierOrderID = SupplierOrderIDList[i];
                var SupplierOrderDetail = _repositoryWrapper.Supplierorder.GetAllocateOrderList(SupplierOrderID, param);
                var productName = _repositoryWrapper.Product.GetProductName(obj);
                foreach (var item in SupplierOrderDetail)
                {
                    int ProductID = item.ProductID;
                    // int CustomerID = item.CustomerID;
                    SupplierorderRepository.SupplierOrderDetailData result = new SupplierorderRepository.SupplierOrderDetailData();
                    result.SupplierOrderID = SupplierOrderID;
                    result.SupplierName = item.SupplierName;
                    result.ArrivalDate = item.arrivaldate;
                    result.ProductName = _repositoryWrapper.Product.FindByCondition(x => x.productID == ProductID).Select(x => x.productName).FirstOrDefault();
                    // result.Status = item.status == 1 ? "New" : item.status == 2 ? "Pending" : "Delivered";
                    result.Shipment = item.Shipment;
                    result.ProductID = item.ProductID;
                    // result.Week3 = item.Week3;
                    // result.Week4 = item.Week4;
                    result.Liter = item.Liter;
                    lstResult.Add(result);
                }
                lstResultAdd = _repositoryWrapper.Supplierorder.GetProductNameForSupplierOrder(productName, lstResult);
                if (lstResultAdd != null)
                {
                    lstFinalresult.Add(lstResultAdd);
                    lstResult = new List<dynamic>();
                }
            }
            //lstFinalresult=lstFinalresult.Where(x =>x.productID==productID).ToList();
            DataSourceResult list = lstFinalresult.ToDataSourceResult(request);
            if (list == null)
            {
                objresponse = new { data = "", dataFoundRowsCount = 0 };
            }
            else
                objresponse = new { data = list.Data, total = list.Total };

            return objresponse;
        }


        [HttpPost("GetAllocateProductHeaderList", Name = "GetAllocateProductHeaderList")]
        [Authorize]
        public dynamic GetAllocateProductHeaderList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            var query = _repositoryWrapper.CustomerOrder.GetHeaderList(obj);
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetProductComboList", Name = "GetAllocateProductComboList")]
        [Authorize]
        public dynamic GetProductComboList()
        {
            var query = _repositoryWrapper.Product.GetProductCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpPost("GetCustomerOrderByMonth", Name = "GetCustomerOrderByMonth")]
        [Authorize]
        public dynamic GetCustomerOrderByMonth([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.CustomerOrder.GetCustomerOrderByMonth(param);

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

        [HttpPost("GetCustomerAssignOrderByMonth", Name = "GetCustomerAssignOrderByMonth")]
        [Authorize]
        public dynamic GetCustomerAssignOrderByMonth([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.CustomerOrder.GetCustomerAssignOrderByMonth(param);

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
        [HttpPost("GetAssignData", Name = "GetAssignData")]
        [Authorize]
        public dynamic GetAssignData([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.CustomerAssign.GetCustomerAssignData(param);

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

        [HttpPost("SaveCustomerAssign", Name = "SaveCustomerAssign")]
        [Authorize]
        public dynamic SaveCustomerAssign([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int CustomerAssignID = 0;
            // string CustomerOrderID = obj.CustomerOrderID != null ? obj.CustomerOrderID : "0";
            string CompanyID = _tokenData.CompanyID;
            try
            {
                var newobj = new CustomerAssign();
                newobj.productID = obj.productID;
                newobj.assignweek = obj.AssignWeek;
                newobj.supplierorderID = obj.SupplierOrderID;
                newobj.modifieddate = System.DateTime.Now;
                newobj.inactive = true;
                _repositoryWrapper.CustomerAssign.Create(newobj);
                _repositoryWrapper.EventLog.Insert(newobj);
                CustomerAssignID = newobj.customerassignID;
                for (int i = 0; i < obj.item.Count; i++)
                {
                    var dobj = new CustomerAssignDetail();
                    dobj.customerassignID = CustomerAssignID;
                    dobj.customerOrderID = obj.item[i].CustomerOrderID;
                    dobj.orderliter = obj.item[i].OrderLiter;
                    dobj.assignliter = obj.item[i].AssignLiter;
                    dobj.modifieddate = System.DateTime.Now;
                    dobj.inactive = true;
                    _repositoryWrapper.CustomerAssignDetail.Create(dobj);
                    _repositoryWrapper.EventLog.Insert(dobj);

                }

                objresponse = new { data = CustomerAssignID };
            }
            catch (ValidationException vex)
            {
                _repositoryWrapper.EventLog.Error("CustomerOrder Controller/ Save CustomerOrder", vex.Message);
                objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }

        [HttpDelete("DeleteCustomerAssign/{CustomerAssignID}", Name = "DeleteCustomerAssign")]
        [Authorize]
        public dynamic DeleteCustomerAssign(int CustomerAssignID)
        {
            dynamic objresponse = null;
            bool result = false;
            try
            {
                var newobj = _repositoryWrapper.CustomerAssign.FindByID(CustomerAssignID);
                newobj.inactive = false;
                _repositoryWrapper.CustomerAssign.Update(newobj);
                _repositoryWrapper.EventLog.Update(newobj);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { ex.Message };
            }
            objresponse = new { data = result };
            return objresponse;
        }
        [HttpGet("GetSupplierOrderData/{SupplierOrderID}", Name = "GetSupplierOrderData1")]
        [Authorize]
        public dynamic GetSupplierOrderData(string SupplierOrderID)
        {
            var query = _repositoryWrapper.Supplierorder.GetSupplierOrderData(SupplierOrderID);
            dynamic objresponse = new { data = query };
            return objresponse;
        }

        [HttpPost("GetGainLossData", Name = "GetGainLossData")]
        [Authorize]
        public dynamic GetGainLossData([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            dynamic obj = param;
            List<dynamic> mainQuery = new List<dynamic>();
            string SupplierOrderID = obj.data;
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            var movement = _repositoryWrapper.MovementTransaction.GetMovementProductData(SupplierOrderID);
            mainQuery = _repositoryWrapper.CustomerAssign.GetGainLossData(param, movement);
            DataSourceResult list = mainQuery.ToDataSourceResult(request);
            if (mainQuery == null)
            {
                objresponse = new { data = "", dataFoundRowsCount = 0 };
            }
            else
            {
                objresponse = new { data = list.Data, total = list.Total };
            }
            return objresponse;
        }
    }
}