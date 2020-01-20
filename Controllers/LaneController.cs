using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ethereal_EM.Repository;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;

namespace Ethereal_EM
{
    [Route("api/[controller]")]
    public class LaneController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;

        public LaneController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }


        [HttpPost("GetLaneDataList", Name = "GetLaneDataList")]
        [Authorize]
        public dynamic GetLaneDataList([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            dynamic mainQuery = _repositoryWrapper.Lane.GetLaneDataList(param);

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

        [HttpGet("GetPetrolList", Name = "GetPetrolList")]
        [Authorize]
        public dynamic GetPetrolList()
        {
            dynamic objresponse = null;
            dynamic mainQuery = _repositoryWrapper.Lane.GetPetrolList();
            objresponse = new { data = mainQuery };
            return objresponse;
        }
        [HttpPost("checkDuplicate", Name = "checkDuplicate")]
        [Authorize]
        public dynamic checkDuplicate([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresult = null;
            int LaneID = obj.LaneID != null ? obj.LaneID : "0";
            string name = obj.LaneName;
            var duplicatedName = _repositoryWrapper.Lane.CheckDuplicate(LaneID, name);
            objresult = new
            {
                Name = duplicatedName > 0 ? 1 : 0,
            };

            List<dynamic> dd = new List<dynamic>();
            dd.Add(objresult);
            dynamic objresponse = new { data = dd };
            return objresponse;
        }

        [HttpPost("Save", Name = "Save")]
        [Authorize]
        public dynamic Save([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            dynamic objresponse = null;
            int LaneID = obj.LaneID != null ? obj.LaneID : 0;
            // string CompanyID = _tokenData.CompanyID;
            try
            {
                var LaneObj = _repositoryWrapper.Lane.FindByID(LaneID);
                if (LaneObj != null)
                {

                    LaneObj.laneName = obj.LaneName;
                    LaneObj.modifieddate = DateTime.Now;
                    LaneObj.inactive = true;
                    _repositoryWrapper.Lane.Update(LaneObj);
                    _repositoryWrapper.EventLog.Insert(LaneObj);
                    LaneID = LaneObj.laneID;
                    if (obj.deleteItem.Count > 0)
                    {
                        for (int j = 0; j < obj.deleteItem.Count; j++)
                        {
                            int HoseID = obj.deleteItem[j].hoseID != null ? obj.deleteItem[j].hoseID : 0;
                            var Hoseobj = _repositoryWrapper.Hose.FindByID(HoseID);
                            if (Hoseobj != null)
                            {
                                Hoseobj.inactive = false;
                                //Hoseobj.CompanyID = CompanyID;
                                Hoseobj.modifieddate = DateTime.Now;
                                _repositoryWrapper.Hose.Update(Hoseobj);
                                _repositoryWrapper.EventLog.Insert(Hoseobj);

                            }
                        }
                    }


                    for (int i = 0; i < obj.item.Count; i++)
                    {
                        int HoseID = obj.item[i].hoseID != null ? obj.item[i].hoseID : 0;
                        var Hoseobj = _repositoryWrapper.Hose.FindByID(HoseID);
                        if (Hoseobj != null)
                        {

                            Hoseobj.hoseID = HoseID;
                            Hoseobj.hoseNumber = obj.item[i].HoseNo;
                            Hoseobj.productID = obj.item[i].productID;
                            Hoseobj.flowmeter = obj.item[i].FlowMeterAddress;
                            // Hoseobj.CompanyID = CompanyID;
                            Hoseobj.modifieddate = DateTime.Now;
                            Hoseobj.inactive = true;
                            _repositoryWrapper.Hose.Update(Hoseobj);
                            _repositoryWrapper.EventLog.Insert(Hoseobj);
                        }
                        else
                        {
                            Hose newHose = new Hose();
                            newHose.laneID = LaneID;
                            newHose.hoseID = HoseID;
                            newHose.hoseNumber = obj.item[i].HoseNo;
                            newHose.productID = obj.item[i].productID;
                            newHose.flowmeter = obj.item[i].FlowMeterAddress;
                            // newHose.CompanyID = CompanyID;
                            newHose.modifieddate = DateTime.Now;
                            newHose.inactive = true;
                            _repositoryWrapper.Hose.Create(newHose);
                            _repositoryWrapper.EventLog.Insert(newHose);
                        }

                    }

                }
                else
                {
                    Lane newobj = new Lane();
                    newobj.laneID = LaneID;
                    newobj.laneName = obj.LaneName;
                    // newobj.CompanyID = CompanyID;
                    newobj.modifieddate = DateTime.Now;
                    newobj.inactive = true;
                    _repositoryWrapper.Lane.Create(newobj);
                    _repositoryWrapper.EventLog.Insert(newobj);

                    LaneID = newobj.laneID;

                    for (int i = 0; i < obj.item.Count; i++)
                    {
                        Hose newhose = new Hose();
                        newhose.laneID = LaneID;
                        newhose.hoseID = obj.item[i].hoseID;
                        newhose.hoseNumber = obj.item[i].HoseNo;
                        newhose.productID = obj.item[i].productID;
                        newhose.flowmeter = obj.item[i].FlowMeterAddress;
                        // newhose.CompanyID = CompanyID;
                        newhose.modifieddate = DateTime.Now;
                        newhose.inactive = true;
                        _repositoryWrapper.Hose.Create(newhose);
                        _repositoryWrapper.EventLog.Insert(newhose);
                    }


                }


                objresponse = new { data = LaneID };

            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                Console.WriteLine("error = Error in Unit Header");
            }
            return objresponse;
        }


        [HttpDelete("DeleteList/{ID}", Name = "DeleteList")]
        [Authorize]
        public dynamic DeleteList(int ID)
        {
            dynamic objresponse = null;
            int LaneID = ID;
            bool result = false;
            try
            {
                var newobj = _repositoryWrapper.Lane.FindByID(LaneID);
                newobj.inactive = false;
                newobj.modifieddate = System.DateTime.Now;
                _repositoryWrapper.Lane.Update(newobj);
                _repositoryWrapper.EventLog.Update(newobj);

                var itemobj = _repositoryWrapper.Hose.GetItemData(LaneID);
                for (var i = 0; i < itemobj.Count; i++)
                {
                    int hoseID = itemobj[i].hoseID;
                    var updateObj = _repositoryWrapper.Hose.FindByID(hoseID);
                    updateObj.inactive = false;
                    updateObj.modifieddate = System.DateTime.Now;
                    _repositoryWrapper.Hose.Update(updateObj);
                    _repositoryWrapper.EventLog.Update(updateObj);
                }
                result = true;
                objresponse = new { data = result };

            }
            catch (Exception ex)
            {
                _repositoryWrapper.EventLog.Error("", ex.Message);
                objresponse = new { ex.Message };
            }
            return objresponse;
        }


        [HttpGet("GetLaneEditData/{ID}", Name = "GetLaneEditData")]
        [Authorize]
        public dynamic GetLaneEditData(int ID)
        {
            dynamic objresult = null;
            var query = _repositoryWrapper.Lane.GetLaneEditData(ID);
            objresult = query;
            dynamic objresponse = new { data = objresult };
            return objresponse;
        }
    }
}