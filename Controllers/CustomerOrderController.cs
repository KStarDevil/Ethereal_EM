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
    public class CustomerOrderController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;


        public CustomerOrderController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpPost("GetAllCustomerOrderList", Name = "GetAllCustomerOrderList")]
        [Authorize]
        public dynamic GetAllCustomerOrderList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            dynamic lstResult = new List<dynamic>();
            dynamic lstResultAdd = new List<dynamic>();
            List<dynamic> lstFinalresult = new List<dynamic>();
            dynamic obj = param;
            int productID = obj.data.productID;
            DataSourceRequest request = KendoDataSourceRequestUtil.Parse(param);
            var CustomerOrderIDList = _repositoryWrapper.CustomerOrder.FindByCondition(x => x.inactive == true).Select(x => x.customerOrderID).ToList();
            for (int i = 0; i < CustomerOrderIDList.Count; i++)
            {
                string CustomerOrderID = CustomerOrderIDList[i];
                var CustomerOrderDetail = _repositoryWrapper.CustomerOrder.GetAllCustomerOrderList(CustomerOrderID, param);
                var productName = _repositoryWrapper.Product.GetProductName(obj);
                foreach (var item in CustomerOrderDetail)
                {
                    int ProductID = item.ProductID;
                    int CustomerID = item.CustomerID;
                    CustomerOrderRepository.CustomerOrderDetailData result = new CustomerOrderRepository.CustomerOrderDetailData();
                    result.CustomerOrderID = CustomerOrderID;
                    result.OrderMonth = item.ordermonth.ToString("MMMM yyyy");
                    result.CustomerName = _repositoryWrapper.Customer.FindByCondition(x => x.customerID == CustomerID).Select(x => x.customername).FirstOrDefault();
                    result.ProductName = _repositoryWrapper.Product.FindByCondition(x => x.productID == ProductID).Select(x => x.productName).FirstOrDefault();
                    result.Status = item.status == 1 ? "New" : item.status == 2 ? "Pending" : "Delivered";
                    result.Week1 = item.Week1;
                    result.Week2 = item.Week2;
                    result.Week3 = item.Week3;
                    result.Week4 = item.Week4;
                    result.Total = item.Total;
                    lstResult.Add(result);
                }
                lstResultAdd = _repositoryWrapper.CustomerOrder.GetProductNameForCustomerOrder(productName, lstResult);
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

        [HttpGet("GetCustomerOrderProduct", Name = "GetCustomerOrderProduct")]
        [Authorize]
        public dynamic GetCustomerOrderProduct()
        {
            var query = _repositoryWrapper.CustomerOrder.GetCustomerproduct();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpPost("GetHeaderList", Name = "GetHeaderList")]
        [Authorize]
        public dynamic GetHeaderList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            var query = _repositoryWrapper.CustomerOrder.GetHeaderList(obj);
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetProductComboList", Name = "GetProductComboList")]
        [Authorize]
        public dynamic GetProductComboList()
        {
            var query = _repositoryWrapper.Product.GetProductCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }

        [HttpGet("GetCustomerCombo", Name = "GetCustomerCombo")]
        [Authorize]
        public dynamic GetCustomerCombo()
        {
            var query = _repositoryWrapper.Customer.GetCustomerCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }

        [HttpPost("SaveCustomerOrder", Name = "SaveCustomerOrder")]
        [Authorize]
        public dynamic SaveCustomerOrder([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int LoginID = Int32.Parse(_tokenData.UserID);
            string CustomerOrderID = obj.CustomerOrderID != null ? obj.CustomerOrderID : "0";
            string CompanyID = _tokenData.CompanyID;
            try
            {
                var sobj = _repositoryWrapper.CustomerOrder.FindByString(CustomerOrderID);
                if (sobj != null)
                {
                    sobj.ordermonth = obj.OrderMonth;
                    sobj.customerID = obj.customerID;
                    sobj.status = obj.status;
                    sobj.createuser = LoginID;
                    sobj.userType = false;
                    sobj.modifieddate = System.DateTime.Now;
                    sobj.inactive = true;
                    _repositoryWrapper.CustomerOrder.Update(sobj);
                    _repositoryWrapper.EventLog.Update(sobj);

                    for (int i = 0; i < obj.data.Count; i++)
                    {
                        string CustomerOrderDetailID = obj.data[i].ID;
                        var dobj = _repositoryWrapper.CustomerOrderDetail.FindByString(CustomerOrderDetailID);
                        dobj.customerorderDetailID = CustomerOrderDetailID;
                        dobj.customerOrderID = CustomerOrderID;
                        dobj.productID = obj.data[i].ProductID;
                        dobj.week1_liter = obj.data[i].Week1;
                        dobj.week2_liter = obj.data[i].Week2;
                        dobj.week3_liter = obj.data[i].Week3;
                        dobj.week4_liter = obj.data[i].Week4;
                        dobj.total = obj.data[i].Total;
                        dobj.remark = obj.data[i].Remark;
                        dobj.modifieddate = System.DateTime.Now;
                        dobj.inactive = true;
                        _repositoryWrapper.CustomerOrderDetail.Update(dobj);
                        _repositoryWrapper.EventLog.Update(dobj);

                    }

                }
                else
                {
                    CustomerOrderID = _repositoryWrapper.CustomerOrder.GetCustomerOrderNo();
                    var newobj = new CustomerOrder();
                    newobj.customerOrderID = CustomerOrderID;
                    newobj.customerID = obj.customerID;
                    newobj.ordermonth = obj.OrderMonth;
                    newobj.status = 1;
                    newobj.createuser = LoginID;
                    newobj.userType = false;
                    newobj.modifieddate = System.DateTime.Now;
                    newobj.inactive = true;
                    _repositoryWrapper.CustomerOrder.Create(newobj);
                    _repositoryWrapper.EventLog.Insert(newobj);

                    for (int i = 0; i < obj.data.Count; i++)
                    {
                        string CustomerOrderDetailID = _repositoryWrapper.CustomerOrderDetail.GetCustomerOrderDetailNo();
                        var dobj = new CustomerOrderDetail();
                        dobj.customerorderDetailID = CustomerOrderDetailID;
                        dobj.customerOrderID = CustomerOrderID;
                        dobj.productID = obj.data[i].ProductID;
                        dobj.week1_liter = obj.data[i].Week1;
                        dobj.week2_liter = obj.data[i].Week2;
                        dobj.week3_liter = obj.data[i].Week3;
                        dobj.week4_liter = obj.data[i].Week4;
                        dobj.total = obj.data[i].Total;
                        dobj.remark = obj.data[i].Remark;
                        dobj.modifieddate = System.DateTime.Now;
                        dobj.inactive = true;
                        _repositoryWrapper.CustomerOrderDetail.Create(dobj);
                        _repositoryWrapper.EventLog.Insert(dobj);

                    }

                }
                objresponse = new { data = CustomerOrderID };
            }
            catch (ValidationException vex)
            {
                _repositoryWrapper.EventLog.Error("CustomerOrder Controller/ Save CustomerOrder", vex.Message);
                objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }

        [HttpGet("GetCustomerOrderData/{CustomerOrderID}", Name = "GetCustomerOrderData")]
        [Authorize]
        public dynamic GetCustomerOrderData(string CustomerOrderID)
        {
            dynamic objresponse = null;
            try
            {
                var query = _repositoryWrapper.CustomerOrder.GetCustomerOrderData(CustomerOrderID);
                objresponse = new { data = query };
                return objresponse;
            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }
        [HttpDelete("DeleteCustomerOrder/{CustomerOrderID}", Name = "DeleteCustomerOrder")]
        [Authorize]
        public dynamic DeleteCustomerOrder(string CustomerOrderID)
        {
            dynamic objresponse = null;
            bool result = false;
            try
            {
                var newobj = _repositoryWrapper.CustomerOrder.FindByString(CustomerOrderID);
                newobj.inactive = false;
                _repositoryWrapper.CustomerOrder.Update(newobj);
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

    }
}