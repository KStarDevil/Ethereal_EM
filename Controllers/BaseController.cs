using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Ethereal_EM
{

    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        public TokenData _tokenData = new TokenData();
        public string _ipaddress = "";
        public string _clienturl = "";
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            string Source = context.HttpContext.Request.Path.ToString().Split(new char[] { '/' })[1].ToString();
            string ControllerAction = context.ActionDescriptor.DisplayName.ToString().Replace("Ethereal_EM.", "");
            
            Request.HttpContext.Session.Set("ApiSource",System.Text.Encoding.ASCII.GetBytes(Source));
            Request.HttpContext.Session.Set("ControllerAction",System.Text.Encoding.ASCII.GetBytes(ControllerAction));
            //_ipaddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            _ipaddress = "127.0.0.1";
			if(context.HttpContext.Connection.RemoteIpAddress != null) _ipaddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
			_clienturl = context.HttpContext.Request.Headers["Referer"];
            setDefaultDataFromToken();
        }
        public void setDefaultDataFromToken()
        {
            try
            {
                string access_token = "";
                var hdtoken = Request.Headers["Authorization"];
                if (hdtoken.Count > 0)
                {
                    access_token = hdtoken[0];
                    access_token = access_token.Replace("Bearer ", "");
                    var handler = new JwtSecurityTokenHandler();
                    var tokenS = handler.ReadToken(access_token) as JwtSecurityToken;
                    _tokenData = Globalfunction.GetTokenData(tokenS);
                }
            }
            catch (Exception ex)
            {
                Globalfunction.WriteSystemLog(ex.Message);
            }
        }
    }
}