using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Ethereal_EM.Repository;
using System.Linq;
using Kendo.Mvc.UI;

namespace Ethereal_EM
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ProductController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpPost("GetAllProduct", Name = "GetAllProduct")]
        [Authorize]
        public dynamic GetAllProduct([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic objresponse = null;
            DataSourceResult mainQuery = _repositoryWrapper.Product.GetAllProduct(param);

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



        [HttpPost("SaveProduct", Name = "SaveProduct")]
        [Authorize]
        public dynamic SaveProduct([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            string errmsg = "";
            int productID = obj.id != null ? obj.id : 0;
            string productName = obj.Name.Value;
            errmsg = "";
            dynamic objresponse;

            var GeneralNamelist = _repositoryWrapper.Product.CheckDuplicateProductName(productID, productName);

            if (GeneralNamelist > 0)
            {
                errmsg += " Name is already use.";
                return objresponse = new { data = errmsg, id = productID };
            }
            var objProduct = _repositoryWrapper.Product.FindByID(productID);
            if (objProduct != null)
            {
                objProduct.productName = obj.Name.ToString();

                objProduct.inactive = true;
                if (objProduct.productName != "")
                {
                    _repositoryWrapper.Product.Update(objProduct);
                    errmsg += "Update Successfully";
                    _repositoryWrapper.EventLog.Update(objProduct);

                }
                else
                {
                    errmsg = "is needed";
                }

            }
            else
            {
                var newobj = new Product();
                newobj.productName = obj.Name.Value;


                newobj.inactive = true;
                if (newobj.productName != "")
                {
                    _repositoryWrapper.Product.Create(newobj);

                    errmsg += "Save Successfully";
                    _repositoryWrapper.EventLog.Insert(newobj);
                    productID = newobj.productID;

                }
                else
                {
                    errmsg = "is needed";
                }
            }

            errmsg = "\r\n";
            objresponse = new { data = errmsg, id = productID };
            return objresponse;
        }

        [HttpPost("DeleteProduct", Name = "DeleteProduct")]
        [Authorize]
        public dynamic DeleteProduct([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            dynamic obj = param;
            int productID = obj.id;
            dynamic objresponse = null;
            int userresult = _repositoryWrapper.Tank.FindByCondition(x => x.productID == productID && x.inactive == true).Select(x => x.tankID).Count();
             int userresult1 = _repositoryWrapper.Hose.FindByCondition(x => x.productID == productID && x.inactive == true).Select(x => x.laneID).Count();
            if (userresult > 0 || userresult1 >0)
            {
                objresponse = new { data = false };
            }
            else
            {
                var objGeneral = _repositoryWrapper.Product.FindByID(productID);
                if (objGeneral != null)
                {
                    objGeneral.inactive = false;
                    _repositoryWrapper.Product.Update(objGeneral);
                }
                _repositoryWrapper.EventLog.Update(objGeneral);

                objresponse = new { data = true };
            }

            return objresponse;
        }

    }
}
