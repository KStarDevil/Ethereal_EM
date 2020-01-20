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
    public class FileSavingController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;

        public FileSavingController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpPost("filesaving", Name = "filesaving")]
        public dynamic filesaving([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            
            // string save ="";
            // try{

            dynamic dd = param;
            int id = dd.id;

            // var file = dd.file;
            
            // FileSaveModel fsm = new FileSaveModel();
            // fsm.id =id;
            // fsm.file=file;

            // _repositoryWrapper.FileSavingRepo.Create(fsm);

            // save ="Save Successfully";
            
            // }catch(Exception ex){
            //     save = ex.Message;
            // }
            // return save;
            var imageDataByteArray = Convert.FromBase64String(dd.file);
            var imageDataStream = new MemoryStream(imageDataByteArray);
            imageDataStream.Position=0;
            return (imageDataByteArray,"image/png");
        }
    }
}