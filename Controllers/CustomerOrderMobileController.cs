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
    [Route("mobile/[Controller]")]
    public class CustomerOrderMobileController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public static IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;


        public CustomerOrderMobileController(IRepositoryWrapper RW, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repositoryWrapper = RW;
        }

        [HttpPost("GetMobileCustomerOrderProduct", Name = "GetMobileCustomerOrderProduct")]
    
        public dynamic GetMobileCustomerOrderProduct([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            string Message ="";
            try
            {
                string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                    
                    var query = _repositoryWrapper.CustomerOrder.GetCustomerproduct();
                    // objresponse = new { data = query };
                    Message = " Successfully!";
                    objresponse = new { status = 1, message = "success", data = query  };
                    return objresponse;
                   
                }else
                 {
                    // Message = "Sorry! Please Try Again ";
                    // objresponse = new { data = Message };
                    Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, message = Message };
                 }
                

            }

            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                // objresponse = new { error = ex.Message };
                objresponse = new { status = 0, message = "Sorry! Please Try again!" };
            }

            return objresponse;
        }

        [HttpPost("SaveMobileCustomerOrder", Name = "SaveMobileCustomerOrder")]
    
        public dynamic SaveMobileCustomerOrder([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            dynamic objresponse = null;
            string CustomerOrderID = objParamInfo.CustomerOrderID != null ? objParamInfo.CustomerOrderID : "0";
            string CustomerID = objParamInfo.CustomerID;
            string OrderMonth = objParamInfo.OrderMonth;
            string remark = objParamInfo.Remark;
            DateTime Date = DateTime.Now;
            try
            {
                string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                    var sobj = _repositoryWrapper.CustomerOrder.FindByString(CustomerOrderID);
                    if (sobj != null)
                    {
                    sobj.ordermonth = objParamInfo.OrderMonth;
                    sobj.customerOrderID = objParamInfo.customerOrderID;
                    sobj.customerID = objParamInfo.CustomerID;
                    sobj.remark = objParamInfo.Remark;
                    sobj.createuser = Convert.ToInt32(CustomerID);
                    sobj.userType = true;
                    sobj.status = objParamInfo.status;
                    sobj.modifieddate = System.DateTime.Now;
                    sobj.inactive = true;
                    _repositoryWrapper.CustomerOrder.Update(sobj);
                    for (int i = 0; i < objParamInfo.data.Count; i++)
                    {
                        string CustomerOrderDetailID = objParamInfo.data[i].ID;
                        var dobj = _repositoryWrapper.CustomerOrderDetail.FindByString(CustomerOrderDetailID);
                        dobj.customerorderDetailID = CustomerOrderDetailID;
                        dobj.customerOrderID = CustomerOrderID;
                        dobj.productID = objParamInfo.data[i].ProductID;
                        dobj.week1_liter = objParamInfo.data[i].Week1;
                        dobj.week2_liter = objParamInfo.data[i].Week2;
                        dobj.week3_liter = objParamInfo.data[i].Week3;
                        dobj.week4_liter = objParamInfo.data[i].Week4;
                        dobj.total = objParamInfo.data[i].Total;
                        dobj.remark = objParamInfo.data[i].Remark;
                        dobj.modifieddate = System.DateTime.Now;
                        dobj.inactive = true;
                        _repositoryWrapper.CustomerOrderDetail.Update(dobj);
                    }

                }
                else
                {
                    CustomerOrderID = _repositoryWrapper.CustomerOrder.GetCustomerOrderNo();
                    var newobj = new CustomerOrder();
                    newobj.customerOrderID = CustomerOrderID;
                    newobj.customerID = Convert.ToInt32(CustomerID);
                    newobj.ordermonth = Convert.ToDateTime(OrderMonth);
                    newobj.status = 2;
                    sobj.createuser = Convert.ToInt32(CustomerID);
                    sobj.userType = true;
                    newobj.modifieddate = Date;
                    newobj.inactive = true;
                    newobj.remark = remark;
                    _repositoryWrapper.CustomerOrder.Create(newobj);

                    for (int i = 0; i < objParamInfo.data.Count; i++)
                    {
                        string CustomerOrderDetailID = _repositoryWrapper.CustomerOrderDetail.GetCustomerOrderDetailNo();
                        var dobj = new CustomerOrderDetail();
                        dobj.customerorderDetailID = CustomerOrderDetailID;
                        dobj.customerOrderID = CustomerOrderID;
                        dobj.productID = objParamInfo.data[i].ProductID;
                        dobj.week1_liter = objParamInfo.data[i].Week1;
                        dobj.week2_liter = objParamInfo.data[i].Week2;
                        dobj.week3_liter = objParamInfo.data[i].Week3;
                        dobj.week4_liter = objParamInfo.data[i].Week4;
                        dobj.total = objParamInfo.data[i].Total;
                        dobj.remark = objParamInfo.data[i].Remark;
                        dobj.modifieddate = System.DateTime.Now;
                        dobj.inactive = true;
                        _repositoryWrapper.CustomerOrderDetail.Create(dobj);

                    }

                }
                objresponse = new { status = 1, message = "Success" };
                }
                else
                {
                    String Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, message = Message };
                }
            }
            catch (ValidationException vex)
            {
                //_repositoryWrapper.EventLog.Error("CustomerOrderMobile Controller/ Save CustomerOrderMobile", vex.Message);
                //objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                objresponse = new {status = 0, message = "Sorry! Please Try Again"};
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }

        [HttpPost("DeleteMobileCustomerOrder", Name = "DeleteMobileCustomerOrder")]
        
        public dynamic DeleteMobileCustomerOrder([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            
            bool result = false;

            string CustomerID = objParamInfo.CustomerID;
            string CustomerOrderID = objParamInfo.CustomerOrderID;
            dynamic objresponse = null;
            string Message = "";
            try
            {
                string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                var newobj = _repositoryWrapper.CustomerOrder.FindByString(CustomerOrderID);
                newobj.inactive = false;
                _repositoryWrapper.CustomerOrder.Update(newobj);
                result = true;
                Message = "Delete Successfully!";
                objresponse = new{ status = 1, message = "Delete Successfully!"};
                }
                else
                {
                    
                     Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, message = Message };

                }
                
            }
            catch (Exception ex)  
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                result = false;
                objresponse = new {status = 0, message = "Sorry! Please Try Again"};
            }
            
            return objresponse;
        }

        [HttpPost("GetAllMobileCustomerOrderList" , Name = "GetMobileAllCustomerOrderList")]

        public dynamic GetAllMobileCustomerOrderList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            string customerOrderID = objParamInfo.CustomerOrderID;
            string Message = "";
            try
            {
                string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                    
                    var query = _repositoryWrapper.CustomerOrder.GetAllCustomerOrderListMoblie();
                    objresponse = new { data = query };
                    Message = "Successfully!";
                    objresponse = new{ status = 1, message = "Successfully!", data = query};
                    return objresponse; 
                   
                }else
                 {
                    Message = "Sorry! Please Try Again ";
                    objresponse = new { status = 0, messages = Message };
                 }
                

            }

            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { status = 0, messages =  "Oh! Something Wrong.Please try again!" };

            }
            return objresponse;
        
        }


       
           
    }
}
