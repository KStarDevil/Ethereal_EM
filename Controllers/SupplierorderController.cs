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
    public class SupplierorderController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;


        public SupplierorderController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        [HttpPost("GetAllSupplierOrderList", Name = "GetAllSupplierOrderList")]
        [Authorize]
        public dynamic GetAllSupplierOrderList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.Supplierorder.GetAllSupplierOrderList(param);

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

        [HttpGet("GetOrderProduct", Name = "GetOrderProduct")]
        [Authorize]
        public dynamic GetOrderProduct()
        {
            var query = _repositoryWrapper.Customer.GetProduct();
            dynamic objresponse = new { data = query };
            return objresponse;
        }

        [HttpPost("SaveSupplierOrder", Name = "SaveSupplierOrder")]
        [Authorize]
        public dynamic SaveSupplierOrder([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            string SupplierOrderID = obj.SupplierOrderID != null ? obj.SupplierOrderID : "0";
            string CompanyID = _tokenData.CompanyID;
            try
            {
                var sobj = _repositoryWrapper.Supplierorder.FindByString(SupplierOrderID);
                if (sobj != null)
                {
                    sobj.suppliername = obj.supplierName;
                    sobj.shipment = obj.shipment;
                    sobj.arrivaldate = obj.ArrivalDate;
                    sobj.modifieddate = System.DateTime.Now;
                    sobj.inactive = true;
                    _repositoryWrapper.Supplierorder.Update(sobj);
                    _repositoryWrapper.EventLog.Update(sobj);

                    for (int i = 0; i < obj.data.Count; i++)
                    {
                        string SupplierOrderDetailID = obj.data[i].ID;
                        var dobj = _repositoryWrapper.SupplierOrderDetail.FindByString(SupplierOrderDetailID);
                        dobj.supplierorderdetailID = SupplierOrderDetailID;
                        dobj.supplierorderID = SupplierOrderID;
                        dobj.productID = obj.data[i].ProductID;
                        dobj.liter = obj.data[i].Liter;
                        dobj.price = obj.data[i].Price;
                        dobj.modifieddate = System.DateTime.Now;
                        dobj.inactive = true;
                        _repositoryWrapper.SupplierOrderDetail.Update(dobj);
                        _repositoryWrapper.EventLog.Update(dobj);

                    }

                }
                else
                {
                    SupplierOrderID = _repositoryWrapper.Supplierorder.GetSupplierOrderNo();
                    var newobj = new SupplierOrder();
                    newobj.supplierOrderID = SupplierOrderID;
                    newobj.shipment = obj.shipment;
                    newobj.suppliername = obj.supplierName;
                    newobj.arrivaldate = obj.ArrivalDate;
                    newobj.modifieddate = System.DateTime.Now;
                    newobj.inactive = true;
                    _repositoryWrapper.Supplierorder.Create(newobj);
                    _repositoryWrapper.EventLog.Insert(newobj);

                    for (int i = 0; i < obj.data.Count; i++)
                    {
                        string SupplierOrderDetailID = _repositoryWrapper.SupplierOrderDetail.GetSupplierOrderDetailNo();
                        var dobj = new SupplierOrderDetail();
                        dobj.supplierorderdetailID = SupplierOrderDetailID;
                        dobj.supplierorderID = SupplierOrderID;
                        dobj.productID = obj.data[i].ProductID;
                        dobj.liter = obj.data[i].Liter;
                        dobj.price = obj.data[i].Price;
                        dobj.modifieddate = System.DateTime.Now;
                        dobj.inactive = true;
                        _repositoryWrapper.SupplierOrderDetail.Create(dobj);
                        _repositoryWrapper.EventLog.Insert(dobj);

                    }

                }
                objresponse = new { data = SupplierOrderID };
            }
            catch (ValidationException vex)
            {
                _repositoryWrapper.EventLog.Error("Customer Controller/ Save Customer", vex.Message);
                objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }

        [HttpGet("GetSupplierOrderData/{SupplierOrderID}", Name = "GetSupplierOrderData")]
        [Authorize]
        public dynamic GetSupplierOrderData(string SupplierOrderID)
        {
            dynamic objresponse = null;
            try
            {
                var query = _repositoryWrapper.Supplierorder.GetSupplierOrderData(SupplierOrderID);
                objresponse = new { data = query };
                return objresponse;
            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }
        [HttpDelete("DeleteSupplierOrder/{SupplierOrderID}", Name = "DeleteSupplierOrder")]
        [Authorize]
        public dynamic DeleteSupplierOrder(string SupplierOrderID)
        {
            dynamic objresponse = null;
            bool result = false;
            try
            {
                var newobj = _repositoryWrapper.Supplierorder.FindByString(SupplierOrderID);
                newobj.inactive = false;
                _repositoryWrapper.Supplierorder.Update(newobj);
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
        [HttpGet("GetSupplierOrderInfo/{SupplierOrderID}", Name = "GetSupplierOrderInfo")]
        [Authorize]
        public dynamic GetSupplierOrderInfo(string SupplierOrderID)
        {
            dynamic objresponse = null;
            try
            {
                var query = _repositoryWrapper.Supplierorder.GetSupplierOrderData(SupplierOrderID);
                objresponse = new { data = query };
                return objresponse;
            }
            catch (Exception ex)
            {

                _repositoryWrapper.EventLog.Error("", ex.Message);
            }
            return objresponse;
        }
        [HttpGet("GetProductCombo/{ID}", Name = "GetMovementProductCombo")]
        [Authorize]
        public dynamic GetProductCombo(int ID)
        {
            var query = _repositoryWrapper.Tank.GetProductName(ID);
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetProductCombo1", Name = "GetProductCombo1")]
        [Authorize]
        public dynamic GetProductCombo1()
        {
            var query = _repositoryWrapper.Product.GetProductCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetTankCombo", Name = "GetTankCombo")]
        [Authorize]
        public dynamic GetTankCombo()
        {
            var query = _repositoryWrapper.Tank.GetTankCombo();
            dynamic objresponse = new { data = query };
            return objresponse;
        }
        [HttpGet("GetProductName/{TankID}", Name = "GetProductName")]
        [Authorize]
        public dynamic GetProductName(int TankID)
        {
            var query = _repositoryWrapper.Tank.GetProductName(TankID);
            dynamic objresponse = new { data = query };
            return objresponse;
        }

        [HttpPost("SaveMovement", Name = "SaveMovement")]
        [Authorize]
        public dynamic SaveMovement([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int MovementID = obj.MovementID != null ? obj.MovementID : "0";
            string CompanyID = _tokenData.CompanyID;
            try
            {
                var mobj = _repositoryWrapper.MovementTransaction.FindByID(MovementID);
                if (mobj != null)
                {
                    mobj.supplierOrderID = obj.SupplierOrderID;
                    mobj.tankID = obj.tankID;
                    mobj.productID = obj.productID;
                    mobj.movementDate = obj.MovementDate;
                    mobj.modifieddate = System.DateTime.Now;
                    mobj.inactive = true;
                    _repositoryWrapper.MovementTransaction.Update(mobj);
                    _repositoryWrapper.EventLog.Update(mobj);

                }
                else
                {

                    var newobj = new MovementTransaction();
                    newobj.supplierOrderID = obj.SupplierOrderID;
                    newobj.tankID = obj.tankID;
                    newobj.productID = obj.productID;
                    newobj.movementDate = obj.MovementDate;
                    newobj.modifieddate = System.DateTime.Now;
                    newobj.inactive = true;
                    _repositoryWrapper.MovementTransaction.Create(newobj);
                    _repositoryWrapper.EventLog.Insert(newobj);
                    MovementID = newobj.movementID;


                }
                objresponse = new { data = MovementID };
            }
            catch (ValidationException vex)
            {
                _repositoryWrapper.EventLog.Error("Customer Controller/ Save Customer", vex.Message);
                objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }

        [HttpPost("GetMovementTransaction", Name = "GetMovementTransaction")]
        [Authorize]
        public dynamic GetMovementTransaction([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.MovementTransaction.GetMovementTransaction(param);

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

        [HttpDelete("DeleteMovement/{MovementID}", Name = "DeleteMovement")]
        [Authorize]
        public dynamic DeleteMovement(int MovementID)
        {
            dynamic objresponse = null;
            bool result = false;
            try
            {
                var newobj = _repositoryWrapper.MovementTransaction.FindByID(MovementID);
                newobj.inactive = false;
                _repositoryWrapper.MovementTransaction.Update(newobj);
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

        [HttpPost("SaveTLG", Name = "SaveTLG")]
        [Authorize]
        public dynamic SaveTLG([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int MovementID = obj.MovementID != null ? obj.MovementID : "0";
            string CompanyID = _tokenData.CompanyID;
            try
            {
                var mobj = _repositoryWrapper.MovementTransaction.FindByID(MovementID);
                if (mobj != null)
                {
                    mobj.flowmeter = obj.FlowMeter;
                    mobj.TLG_Start = obj.TLGStart;
                    mobj.TLG_End = obj.TLGEnd;
                    mobj.TLG_Volume = obj.TLGVolume;
                    mobj.modifieddate = System.DateTime.Now;
                    mobj.inactive = true;
                    _repositoryWrapper.MovementTransaction.Update(mobj);
                    _repositoryWrapper.EventLog.Update(mobj);

                }
        
                objresponse = new { data = MovementID };
            }
            catch (ValidationException vex)
            {
                _repositoryWrapper.EventLog.Error("Movemnent Controller/ Save Movemnent", vex.Message);
                objresponse = new { data = 0, error = vex.ValidationResult.ErrorMessage };
                Console.WriteLine(vex.Message);
            }

            return objresponse;
        }

    }
}