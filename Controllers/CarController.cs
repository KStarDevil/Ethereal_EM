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
    public class CarController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CarController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

         [HttpPost("SaveCar", Name = "SaveCar")]
        public dynamic SaveCar([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            string Save = "";
            try
            {
                dynamic dd = param;
                int id = dd.id;

                string car_name = dd.car_name;
                DateTime car_produced = dd.car_produced;
                string car_model = dd.car_model;
                Double car_price = dd.car_price;
                bool gasoline = dd.gasoline;
                bool petrol = dd.petrol;
                
                

                carmodel cm = new carmodel();
                
                cm.car_id = id;
                cm.car_name = car_name;
                cm.car_produced = car_produced;
                cm.car_price = car_price;
                cm.car_model = car_model;
                cm.gasoline = gasoline;
                cm.petrol = petrol;

                //mainQuery = Acc;

                _repositoryWrapper.Car.Create(cm);
                Save = "Save Successfully";
            }
            catch (Exception ex)
            {
                Save = ex.Message;
            }
            return Save;
        }

        [HttpGet("ShowCarController", Name = "ShowCarController")]
        public dynamic ShowCarController([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic dd = param;
            int id = dd.id;
            dynamic mainQuery = _repositoryWrapper.Car.ShowCar(id);
            int count = mainQuery.Count;
            dynamic jsondata = new { data = new { Count = count, mainQuery } };
            return jsondata;
        }

         [HttpPost("UpdateCar", Name = "UpdateCar")]
        public dynamic UpdateCar([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            string Update = "";
            try
            {
                dynamic dd = param;
                int id = dd.id;

                string car_name = dd.car_name;
                DateTime car_produced = dd.car_produced;
                string car_model = dd.car_model;
                Double car_price = dd.car_price;
                bool gasoline = dd.gasoline;
                bool petrol = dd.petrol;
                
                dynamic cm = _repositoryWrapper.Car.ShowCarByID(id) ;
                
                cm.car_id = id;
                cm.car_name = car_name;
                cm.car_produced = car_produced;
                cm.car_price = car_price;
                cm.car_model = car_model;
                cm.gasoline = gasoline;
                cm.petrol = petrol;

                //mainQuery = Acc;

                _repositoryWrapper.Car.Update(cm);
                Update = "Update Successfully";
            }
            catch (Exception ex)
            {
                Update = ex.Message;
            }
            return Update;
        }

         [HttpPost("DeleteCar", Name = "DeleteCar")]
        public dynamic DeleteCar([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            string Delete = "";
            try
            {
                dynamic dd = param;
                int id = dd.id;

                
                
                dynamic cm = _repositoryWrapper.Car.ShowCarByID(id) ;
                
                

                //mainQuery = Acc;

                _repositoryWrapper.Car.Delete(cm);
                Delete = "Delete Successfully";
            }
            catch (Exception ex)
            {
                Delete = ex.Message;
            }
            return Delete;
        }
    }
}