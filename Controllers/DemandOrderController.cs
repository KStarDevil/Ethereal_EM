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
    public class DemandOrderController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;


        public DemandOrderController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpGet("GetCustomerCombo", Name = "GetCustomerCombo1")]
        [Authorize]
        public dynamic GetCustomerCombo()
        {
            var query = _repositoryWrapper.Customer.GetCustomerCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetDriverCombo", Name = "GetDriverCombo")]
        [Authorize]
        public dynamic GetDriverCombo()
        {
            var query = _repositoryWrapper.Driver.GetDriverCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetBowserCombo", Name = "GetBowserCombo")]
        [Authorize]
        public dynamic GetBowserCombo()
        {
            var query = _repositoryWrapper.Bowser.GetBowserCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetCompartment/{ID}", Name = "GetCompartment")]
        [Authorize]
        public dynamic GetCompartment(int ID)
        {
            var query = _repositoryWrapper.Compartment.GetCompartment(ID);
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetOrderProduct", Name = "GetOrderProduct1")]
        [Authorize]
        public dynamic GetOrderProduct()
        {
            var query = _repositoryWrapper.Product.GetProductCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpPost("GetAllDemandOrderList", Name = "GetAllDemandOrderList")]
        [Authorize]
        public dynamic GetAllDemandOrderList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.DemandOrder.GetAllDemandOrderList(param);

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

        [HttpPost("SaveDemandOrder", Name = "SaveDemandOrder")]
        [Authorize]
        public dynamic SaveDemandOrder([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int LoginID = Int32.Parse(_tokenData.UserID);
            string DemandOrderID = obj.DemandOrderID != null ? obj.DemandOrderID : "0";
            string CompanyID = _tokenData.CompanyID;
            try
            {
                var sobj = _repositoryWrapper.DemandOrder.FindByString(DemandOrderID);
                if (sobj != null)
                {
                    sobj.deliveryorderDate = obj.DeliveryOrderDate;
                    sobj.deliveryDate = obj.DeliveryDate;
                    sobj.customerID = obj.customerID;
                    sobj.bowserID = obj.bowserID;
                    sobj.driverID = obj.driverID;
                    sobj.status = obj.status;
                    sobj.createuser = LoginID;
                    sobj.userType = false;
                    sobj.modifieddate = System.DateTime.Now;
                    sobj.inactive = true;
                    _repositoryWrapper.DemandOrder.Update(sobj);
                    _repositoryWrapper.EventLog.Update(sobj);

                    for (int i = 0; i < obj.data.Count; i++)
                    {
                        string DemandOrderDetailID = obj.data[i].DemandOrderDetailID != null ? obj.data[i].DemandOrderDetailID : "0";
                        //var deleteDetail =_repositoryWrapper.DemandOrde
                        var dobj = _repositoryWrapper.DemandOrderDetail.FindByString(DemandOrderDetailID);
                        if (dobj != null)
                        {
                            dobj.orderdetailID = DemandOrderDetailID;
                            dobj.demandorderID = DemandOrderID;
                            dobj.productID = obj.data[i].id;
                            dobj.compartmentID = obj.data[i].CompartmentId;
                            dobj.orderliter = obj.data[i].OrderLiter;
                            dobj.modifieddate = System.DateTime.Now;
                            dobj.inactive = true;
                            _repositoryWrapper.DemandOrderDetail.Update(dobj);
                            _repositoryWrapper.EventLog.Update(dobj);
                        }
                        else
                        {
                            DemandOrderDetailID = _repositoryWrapper.DemandOrderDetail.GetDemandOrderDetailNo();
                            var ddobj = new DemandOrderDetail();
                            ddobj.orderdetailID = DemandOrderDetailID;
                            ddobj.demandorderID = DemandOrderID;
                            ddobj.productID = obj.data[i].id;
                            ddobj.compartmentID = obj.data[i].CompartmentId;
                            ddobj.orderliter = obj.data[i].OrderLiter;
                            ddobj.modifieddate = System.DateTime.Now;
                            ddobj.inactive = true;
                            _repositoryWrapper.DemandOrderDetail.Create(ddobj);
                            _repositoryWrapper.EventLog.Insert(ddobj);
                        }


                    }

                }
                else
                {
                    DemandOrderID = _repositoryWrapper.DemandOrder.GetDemandOrderNo();
                    var newobj = new DemandOrder();
                    newobj.demandorderID = DemandOrderID;
                    newobj.customerID = obj.customerID;
                    newobj.bowserID = obj.bowserID;
                    newobj.driverID = obj.driverID;
                    newobj.deliveryDate = obj.DeliveryDate;
                    newobj.deliveryorderDate = obj.DeliveryOrderDate;
                    newobj.status = 1;
                    newobj.createuser = LoginID;
                    newobj.userType = false;
                    newobj.modifieddate = System.DateTime.Now;
                    newobj.inactive = true;
                    _repositoryWrapper.DemandOrder.Create(newobj);
                    _repositoryWrapper.EventLog.Insert(newobj);

                    for (int i = 0; i < obj.data.Count; i++)
                    {
                        string DemandOrderDetailID = _repositoryWrapper.DemandOrderDetail.GetDemandOrderDetailNo();
                        var dobj = new DemandOrderDetail();
                        dobj.orderdetailID = DemandOrderDetailID;
                        dobj.demandorderID = DemandOrderID;
                        dobj.productID = obj.data[i].id;
                        dobj.compartmentID = obj.data[i].CompartmentId;
                        dobj.orderliter = obj.data[i].OrderLiter;
                        dobj.modifieddate = System.DateTime.Now;
                        dobj.inactive = true;
                        _repositoryWrapper.DemandOrderDetail.Create(dobj);
                        _repositoryWrapper.EventLog.Insert(dobj);

                    }

                }
                objresponse = new { data = DemandOrderID };
            }
            catch (ValidationException vex)
            {
                _repositoryWrapper.EventLog.Error("DemandOrder Controller/ Save DemandOrder", vex.Message);
                objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }

        [HttpGet("GetDemandOrderData/{DemandOrderID}", Name = "GetDemandOrderData")]
        [Authorize]
        public dynamic GetDemandOrderData(string DemandOrderID)
        {
            var query = _repositoryWrapper.DemandOrder.GetDemandOrderData(DemandOrderID);
            dynamic objresponse = new { data = query };
            return objresponse;
        }










    }
}