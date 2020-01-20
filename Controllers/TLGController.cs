using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text;
using Operational.Encrypt;
using Microsoft.Extensions.Configuration;
using Ethereal_EM.Repository;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using OfficeOpenXml;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;

namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class TLGController : BaseController
    {
        private IRepositoryWrapper _repositoryWrapper;
        public TLGController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }



        [HttpGet("ReadFlowMeter", Name = "ReadFlowMeter")]
        public dynamic ReadFlowMeter()
        {
            try
            {
                double flowmeter = 1000;
                //dynamic objres = _repositoryWrapper.AdminLevel.FindByID(1);
                return flowmeter;
            }
            catch
            {
                return "Fail Database Connection";
            }
        }
        [HttpGet("ReadTLGStart", Name = "ReadTLGStart")]
        public dynamic ReadTLGStart()
        {
            try
            {
                double tlgstart = 200;
                //dynamic objres = _repositoryWrapper.AdminLevel.FindByID(1);
                return tlgstart;
            }
            catch
            {
                return "Fail Database Connection";
            }
        }
        [HttpGet("ReadTLGEnd", Name = "ReadTLGEnd")]
        public dynamic ReadTLGEnd()
        {
            try
            {
                double tlgend = 600;
                //dynamic objres = _repositoryWrapper.AdminLevel.FindByID(1);
                return tlgend;
            }
            catch
            {
                return "Fail Database Connection";
            }
        }
    }
}