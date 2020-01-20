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
    public class DemandOrderMobileController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public static IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;


        public DemandOrderMobileController(IRepositoryWrapper RW, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repositoryWrapper = RW;
        }

        [HttpPost("GetMobileDriverCombo", Name = "GetMobileDriverCombo")]

       public dynamic GetMobileDriverCombo([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            string Message = "";
            try
            {
                string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                    
                var query = _repositoryWrapper.Driver.GetDriverCombo();
                objresponse = new { data = query };
                Message = "Successfully!";
                objresponse = new{ status = 1, message = "Successfully!", data = query};
                return objresponse; 
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
                objresponse = new { status = 0, message = "Sorry! Please Try Again " };
            }

            return objresponse;
        }

        [HttpPost("GetMobileBowserCombo", Name = "GetMobileBowserCombo")]

        public dynamic GetMobileBowserCombo([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            string Message = "";
            try
            {
                string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                    var query = _repositoryWrapper.Bowser.GetBowserCombo();
                    objresponse = new { data = query };
                    Message = "Successfully!";
                    objresponse = new{ status = 1, message = "Successfully!",data = query};
                    return objresponse;
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
                objresponse = new {status = 0, message = "Sorry! Please Try Again"};
            }
            return objresponse;
        }

        [HttpPost("GetMobileCompartment", Name = "GetMobileCompartment")]

        public dynamic GetMobileCompartment([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            int BowserID = objParamInfo.BowserID;
            dynamic objresponse = null;
            string Message = "";
            try
            {
                 string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                    var query = _repositoryWrapper.Compartment.GetCompartment(BowserID);
                    objresponse = new { data = query };
                    Message = "Successfully!";
                    objresponse = new{ status = 1, message = "Successfully!", data = query};
                    return objresponse;
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
                objresponse = new {status = 0, message = "Sorry! Please Try Again"};
            }
            return objresponse;

            }
        [HttpPost("GetMobileOrderProduct", Name = "GetMobileOrderProduct")]

        public dynamic GetMobileOrderProduct([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            string Message = "";
            try
            {
                 string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                    var query = _repositoryWrapper.Product.GetProductCombo();
                    objresponse = new { data = query };
                    Message = "Successfully!";
                    objresponse = new{ status = 1, message = "Successfully!", data = query};
                    return objresponse;
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
                objresponse = new {status = 0, message = "Sorry! Please Try Again"};
            }
            return objresponse;

            }

            [HttpPost("GetMobileDemandOrderData", Name = "GetMobileDemandOrderData")]

             public dynamic GetMobileDemandOrderData([FromBody] Newtonsoft.Json.Linq.JObject param)
            {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            string Message = "";
            string DemandOrderID = objParamInfo.DemandOrderID;
            try
            {
                 string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                   var query = _repositoryWrapper.DemandOrder.GetDemandOrderData(DemandOrderID);
                    objresponse = new { data = query };
                    Message = "Successfully!";
                    objresponse = new{ status = 1, message = "Successfully!", data = query};
                    return objresponse;
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
                objresponse = new {status = 0, message = "Sorry! Please Try Again"};
            }
            return objresponse;

            }


     [HttpPost("SaveMobileDemandOrder", Name = "SaveMobileDemandOrder")]
    
        public dynamic SaveMobileDemandOrder([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            dynamic objresponse = null;
            string DemandOrderID = objParamInfo.DemandOrderID != null ? objParamInfo.DemandOrderID : "0";
            string CustomerID = objParamInfo.CustomerID;
            DateTime deliveryorderDate = objParamInfo.deliveryorderDate;
            DateTime deliveryDate = objParamInfo.deliveryDate;
            int driverID = objParamInfo.driverID;
            int bowserID = objParamInfo.bowserID; 
            string remark = objParamInfo.remark;
            DateTime Date = DateTime.Now;
            try
            {
                string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                    var sobj = _repositoryWrapper.DemandOrder.FindByString(DemandOrderID);
                    if (sobj != null)
                    {
                    
                    sobj.demandorderID = objParamInfo.DemandOrderID;
                    sobj.deliveryorderDate = objParamInfo.deliveryorderDate;
                    sobj.deliveryDate = objParamInfo.deliveryDate;
                    sobj.driverID = objParamInfo.driverID;
                    sobj.bowserID = objParamInfo.bowserID;
                    sobj.customerID = objParamInfo.CustomerID;
                    sobj.createuser = Convert.ToInt32(CustomerID);
                    sobj.userType = true;
                    sobj.remark = objParamInfo.remark;
                    sobj.modifieddate = System.DateTime.Now;
                    sobj.inactive = true;
                    _repositoryWrapper.DemandOrder.Update(sobj);
                    
                    for (int i = 0; i < objParamInfo.data.Count; i++)
                    {
                        string DemandOrderDetailID = objParamInfo.data[i].DemandOrderDetailID;
                        var dobj = _repositoryWrapper.DemandOrderDetail.FindByString(DemandOrderDetailID);
                        dobj.orderdetailID = DemandOrderDetailID;
                        dobj.demandorderID = DemandOrderID;
                        dobj.productID = objParamInfo.data[i].id;
                        dobj.compartmentID = objParamInfo.data[i].CompartmentID;
                        dobj.orderliter = objParamInfo.data[i].OrderLiter;
                        dobj.modifieddate = System.DateTime.Now;
                        dobj.inactive = true;
                        _repositoryWrapper.DemandOrderDetail.Update(dobj);
                    }

                }
                else
                {
                    DemandOrderID = _repositoryWrapper.DemandOrder.GetDemandOrderNo();
                    var newobj = new DemandOrder();
                    newobj.demandorderID = DemandOrderID;
                    newobj.customerID = Convert.ToInt32(CustomerID);
                    newobj.deliveryorderDate = deliveryorderDate;
                    newobj.deliveryDate = deliveryDate;
                    newobj.driverID = driverID;
                    newobj.bowserID = bowserID; 
                    newobj.status = 2;
                    sobj.createuser = Convert.ToInt32(CustomerID);
                    sobj.userType = true;
                    newobj.modifieddate = Date;
                    newobj.inactive = true;
                    newobj.remark = remark;
                    _repositoryWrapper.DemandOrder.Create(newobj);

                    for (int i = 0; i < objParamInfo.data.Count; i++)
                    {
                        string DemandOrderDetailID = _repositoryWrapper.DemandOrderDetail.GetDemandOrderDetailNo();
                        var dobj = new DemandOrderDetail();
                        dobj.orderdetailID = DemandOrderDetailID;
                        dobj.demandorderID = DemandOrderID;
                        dobj.productID = objParamInfo.data[i].id;
                        dobj.compartmentID = objParamInfo.data[i].CompartmentID;
                        dobj.orderliter = objParamInfo.data[i].OrderLiter;
                        dobj.modifieddate = System.DateTime.Now;
                        dobj.inactive = true;
                        _repositoryWrapper.DemandOrderDetail.Create(dobj);

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
                
                objresponse = new {status = 0, message = "Sorry! Please Try Again"};
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }

        [HttpPost("DeleteMobileDemandOrder", Name = "DeleteMobileDemandOrder")]
        
        public dynamic DeleteMobileDemandOrder([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            string DemandOrderID = objParamInfo.DemandOrderID;
            dynamic objresponse = null;
            bool result = false;
            string Message = "";

            try
            {
                string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                var newobj = _repositoryWrapper.DemandOrder.FindByString(DemandOrderID);
                newobj.inactive = false;
                _repositoryWrapper.DemandOrder.Update(newobj);
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
                //objresponse = new {status = 0, message = "Sorry! Please Try Again"};
            }
            
            return objresponse;
        }

        [HttpPost("GetAllMobileDemandOrderList" , Name = "GetAllMobileDemandOrderList")]
        public dynamic GetAllMobileDemandOrderList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objParamInfo = param;
            string CustomerID = objParamInfo.CustomerID;
            dynamic objresponse = null;
            string demandorderID = objParamInfo.demandorderID;
            string Message = "";
            try
            {
                string customerId = _session.GetString("LoginUserID");
                if(CustomerID == customerId)
                {
                    
                    var query = _repositoryWrapper.DemandOrder.GetAllDemandOrderListMoblie();
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

       

       


