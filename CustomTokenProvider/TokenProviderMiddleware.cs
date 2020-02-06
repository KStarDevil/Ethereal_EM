using System.Dynamic;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Ethereal_EM;
using System.Linq;
using System.Text;
using Ethereal_EM.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace CustomTokenAuthProvider
{
    public class TokenProviderMiddleware : IMiddleware
    {
        private IRepositoryWrapper _repository;
        //private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private readonly JsonSerializerSettings _serializerSettings;
        public static IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            return Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }));
        }
        public TokenProviderMiddleware(IHttpContextAccessor httpContextAccessor, ILoggerFactory DepLoggerFactory, IRepositoryWrapper repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
            var requestPath = _httpContextAccessor.HttpContext.Request.Path.ToString();
            Log._logger = DepLoggerFactory.CreateLogger(requestPath);
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            var appsettingbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var Configuration = appsettingbuilder.Build();
            double expiretimespan = Convert.ToDouble(Configuration.GetSection("TokenAuthentication:TokenExpire").Value);
            TimeSpan expiration = TimeSpan.FromMinutes(expiretimespan);
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));

            _options = new TokenProviderOptions
            {
                Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
                Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                IdentityResolver = GetIdentity,
                Expiration = expiration
            };
        }
        public async Task ResponseMessage(dynamic data, HttpContext context, int code = 400)
        {
            var response = new
            {
                status = data.status,
                message = data.message
            };
            context.Response.StatusCode = code;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
        }

        private async Task GenerateToken(HttpContext context)
        {
            //var username = context.Request.Form["username"]; //admin
            //var password = context.Request.Form["password"]; //gwtsoft
            //var _loginType = context.Request.Form["LoginType"];
            LoginDataModel loginData = new LoginDataModel();
            string username = "";
            string password = "";
            string _loginType = "";
            string MemberID = "";
            string MemberNo = "";

            try
            {
                using (var reader = new System.IO.StreamReader(context.Request.Body))
                {
                    var request_body = reader.ReadToEnd();
                    loginData = JsonConvert.DeserializeObject<LoginDataModel>(request_body, _serializerSettings);
                    if (loginData.username == null) loginData.username = "";
                    if (loginData.password == null) loginData.password = "";
                    if (loginData.LoginType == null) loginData.LoginType = "";
                    username = loginData.username;
                    password = loginData.password;
                    _loginType = loginData.LoginType;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            string ipaddress = "127.0.0.1";
            // set ipaddress
            if (context.Connection.RemoteIpAddress != null) ipaddress = context.Connection.RemoteIpAddress.ToString();

            string clienturl = context.Request.Headers["Referer"];

            dynamic result = null;
            string ipaddresslist = "";


            if (_loginType == "1")
            {
                result = doAdminTypeloginValidation(username, password, clienturl, ipaddress);

                if (result == null || result.Count <= 0)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid username or password.");
                    return;
                }
                if (result[0].access_status == 1)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("This user account is deleted.");
                    return;
                }

                if (result[0].access_status == 2)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("This user account is locked.Please check your email to unlock your account!!!");
                    return;
                }
                ipaddresslist = result[0].restricted_iplist;
            }
            else if (_loginType == "2")
            {
                result = doCustomerTypeloginValidation(username, password, clienturl, ipaddress);
                if (result == null || result.Count <= 0)
                {
                    context.Response.StatusCode = 400;
                    string Message = "Invalid username or password.";
                    var objresponse = new { status = 0, messages = Message };
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(objresponse));
                    // await context.Response.WriteAsync("Invalid username or password.");
                    return;
                }
                if (result[0].access_status == 1)
                {
                    context.Response.StatusCode = 400;
                    string Message = "This user account is deleted.";
                    var objresponse = new { status = 0, messages = Message };
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(objresponse));
                    // await context.Response.WriteAsync("This user account is deleted.");
                    return;
                }

                if (result[0].access_status == 2)
                {
                    context.Response.StatusCode = 400;
                    string Message = "This user account is locked.Please check your email to unlock your account!!!";
                    var objresponse = new { status = 0, messages = Message };
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(objresponse));
                    // await context.Response.WriteAsync("This user account is locked.Please check your email to unlock your account!!!");
                    return;
                }

            }
            else
            {
                // result = (_repository.Member.GetMemberLoginValidation(username)).ToList();

                if (result.Count > 0)
                {
                    MemberID = result[0].memberID.ToString();
                    MemberNo = result[0].memberNo;
                }
                if (result == null || result.Count <= 0)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid username or password.");
                    return;
                }
                if (result[0].access_status == 1)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("This user account is deleted.");
                    return;
                }

                if (result[0].access_status == 2)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("This user account is locked.Please check your email to unlock your account!!!");
                    return;
                }


            }


            Boolean sameip = true;
            if (ipaddresslist != "" && ipaddresslist != null)
            {
                sameip = false;
                string[] ipaddressarr = ipaddresslist.Split(',');
                for (int ip_index = 0; ip_index < ipaddressarr.Length; ip_index++)
                {
                    if (ipaddress == ipaddressarr[ip_index].Trim())
                    {
                        sameip = true;
                        break;
                    }
                }
            }
            if (sameip == false)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Your IP Address is invalid for this account.");
                return;
            }

            if (_loginType == "1")
            {
                string userID = result[0].AdminID.ToString();
                var now = DateTime.UtcNow;
                var _tokenData = new TokenData();
                _tokenData.Sub = result[0].AdminName;
                _tokenData.Jti = await _options.NonceGenerator();
                _tokenData.Iat = new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString();
                _tokenData.UserID = userID;
                _tokenData.Userlevelid = result[0].AdminLevelID.ToString();
                _tokenData.CompanyID = result[0].CompanyID;
                // _tokenData.branchID = result[0].branchID;
                _tokenData.LoginType = _loginType.ToString();
                _tokenData.TicketExpireDate = now.Add(_options.Expiration);
                var claims = Globalfunction.GetClaims(_tokenData);

                // Create the JWT and write it to a string
                var jwt = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(_options.Expiration),
                    signingCredentials: _options.SigningCredentials);
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var settingresult = (_repository.Setting.GetPasswordValidation()).ToList();
                var pwdlength = settingresult[0].Value;

                var response = new
                {
                    access_token = encodedJwt,
                    expires_in = (int)_options.Expiration.TotalSeconds,
                    UserID = userID,
                    LoginType = _loginType,
                    userLevelID = result[0].AdminLevelID,
                    displayName = result[0].AdminName,
                    CompanyID = result[0].CompanyID,
                    //branchID = result[0].branchID,
                    MemberID = MemberID,
                    userImage = result[0].ImagePath,
                    PWDLength = pwdlength.ToString()
                };
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
            }
            else if (_loginType == "2")
            {
                string userID = result[0].customerID.ToString();
                var now = DateTime.UtcNow;
                var _tokenData = new TokenData();
                _tokenData.Sub = result[0].customername;
                _tokenData.Jti = await _options.NonceGenerator();
                _tokenData.Iat = new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString();
                _tokenData.UserID = userID;
                // _tokenData.branchID = result[0].branchID;
                _tokenData.LoginType = _loginType.ToString();
                _tokenData.TicketExpireDate = now.Add(_options.Expiration);
                var claims = Globalfunction.GetClaims(_tokenData);

                // Create the JWT and write it to a string
                var jwt = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(_options.Expiration),
                    signingCredentials: _options.SigningCredentials);
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var settingresult = (_repository.Setting.GetPasswordValidation()).ToList();
                var pwdlength = settingresult[0].Value;

                var response = new
                {
                    access_token = encodedJwt,
                    expires_in = (int)_options.Expiration.TotalSeconds,
                    UserID = userID,
                    LoginType = Convert.ToInt32(_loginType),
                    displayName = result[0].customername,
                    CustomerID = result[0].customerID,
                    LoginName = result[0].username,
                    Customercode = result[0].customercode,
                    PWDLength = pwdlength.ToString()
                };

                var objresponse = new { status = 1, messages = "success", data = response };

                context.Response.ContentType = "application/json";
                // await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
                await context.Response.WriteAsync(JsonConvert.SerializeObject(objresponse, _serializerSettings));
            }
            else
            {
                string memberID = result[0].memberID.ToString();
                var now = DateTime.UtcNow;
                var _tokenData = new TokenData();
                _tokenData.Sub = result[0].memberName;
                _tokenData.Jti = await _options.NonceGenerator();
                _tokenData.Iat = new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString();
                _tokenData.UserID = memberID;

                // _tokenData.Userlevelid = result[0].AdminLevelID.ToString();
                //_tokenData.LoginType = _loginType.ToString();
                _tokenData.TicketExpireDate = now.Add(_options.Expiration);
                var claims = Globalfunction.GetClaims(_tokenData);

                // Create the JWT and write it to a string
                var jwt = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(_options.Expiration),
                    signingCredentials: _options.SigningCredentials);
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var settingresult = (_repository.Setting.GetPasswordValidation()).ToList();
                var pwdlength = settingresult[0].Value;

                var response = new
                {
                    access_token = encodedJwt,
                    expires_in = (int)_options.Expiration.TotalSeconds,
                    // UserID = userID,
                    // LoginType = _loginType,
                    // userLevelID = result[0].AdminLevelID,
                    displayName = result[0].memberName,
                    MemberID = MemberID,
                    MemberNo = MemberNo,
                    //userImage = result[0].ImagePath,
                    PWDLength = pwdlength.ToString()
                };
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _serializerSettings));
            }


            // Serialize and return the response

        }


        dynamic doAdminTypeloginValidation(string username, string password, string clienturl, string ipaddress)
        {

            dynamic result = null;
            try
            {
                result = (_repository.Admin_Repository.GetAdminLoginValidation(username)).ToList();
                if (result.Count <= 0)
                {
                    return null;
                }
                //To set for Session Data
                string LoginUserID = result[0].AdminID.ToString();
                _session.SetString("LoginUserID", LoginUserID);
                _session.SetString("LoginRemoteIpAddress", ipaddress);
                _session.SetString("LoginTypeParam", "1");


                string oldhash = result[0].Password; //"wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt";  //gwtsoft
                string oldsalt = result[0].Salt; //"/SApKtKXpIa6YnHCjKLxQJAeb279BlX8";
                bool flag = Operational.Encrypt.SaltedHash.Verify(oldsalt, oldhash, password);
                if (flag == false)
                {

                    //increase login_failure count 
                    Admin objAdmin = _repository.Admin_Repository.FindById(result[0].AdminID);
                    bool accLock = false;
                    if (objAdmin != null)
                    {
                        var newfailcount = result[0].login_fail_count + 1;
                        var settingresult = (_repository.Setting.GetAllowLoginFailCount()).ToList();
                        var settingfailcount = settingresult[0].Value;

                        //change access_status to 2 if login_failure_count = 'Allow Login Failure Count' from setting table
                        if (newfailcount.ToString() == settingfailcount)
                        {
                            objAdmin.access_status = 2;
                            accLock = true;

                            //send email to unlock
                            var emailtemplateresult = (_repository.EmailTemplate.GetEmailTemplate("Account Lock Notification")).ToList();
                            var settingResult = _repository.EmailTemplate.GetSettingResult();
                            string Message = emailtemplateresult[0].template_content;
                            string Subject = emailtemplateresult[0].subject;
                            string Variable = emailtemplateresult[0].variable;
                            string FromEmail = emailtemplateresult[0].from_email;
                            string Email = result[0].Email;
                            string Account_Name = result[0].AdminName.ToString();
                            string Login_Name = result[0].LoginName.ToString();

                            var plainTextBytes = Encoding.UTF8.GetBytes(result[0].AdminID.ToString());
                            string ID = Convert.ToBase64String(plainTextBytes).Replace("=", "%3D"); ;
                            string unlock_url = "#/unlock/" + ID;
                            string body = Message.Replace("[Account Name]", Account_Name).Replace("[Login Name]", Login_Name).Replace("[Unlock URL]", unlock_url).Replace("\n", "<br/>");
                            Globalfunction.SendEmailAsync(settingResult, Email, FromEmail, Subject, body, true);

                        }

                        objAdmin.login_fail_count = newfailcount;
                    
                        tbl_admin update_admin =_repository.Admin_Repository.GetAdminbyid(objAdmin.AdminID) as tbl_admin;
                        update_admin.admin_login_fail_count = objAdmin.login_fail_count;
                        _repository.Admin_Repository.Update(update_admin);
                        //_repository.EventLog.Info("Login failed for this account UserName : " + username + " , Password : " + password);

                        if (accLock == true)
                        {
                            result = (_repository.Admin.GetAdminLoginValidation(username)).ToList();
                            return result;
                        }

                    }
                    return null;
                }
                else
                {
                    //reset login_failure count
                    Admin objAdmin = _repository.Admin_Repository.FindById(result[0].AdminID);
                    if (objAdmin != null)
                    {
                        objAdmin.login_fail_count = 0;
                        _repository.Admin.Update(objAdmin);

                        _repository.EventLog.Info("Successful login for this account UserName : " + username);
                        result = (_repository.Admin.GetAdminLoginValidation(username)).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        dynamic doCustomerTypeloginValidation(string username, string password, string clienturl, string ipaddress)
        {

            var result = _repository.Customer.GetCustomerLoginMobile(username);


            if (result.Count <= 0)
            {
                return null;
            }
            //To set for Session Data
            string LoginUserID = result[0].customerID.ToString();
            _session.SetString("LoginUserID", LoginUserID);
            _session.SetString("LoginRemoteIpAddress", ipaddress);
            _session.SetString("LoginTypeParam", "1");


            string oldhash = result[0].password; //"wlaf1//SXWsJp/2+Mo8+1wnmxbmZ5ZAt";  //gwtsoft
            string oldsalt = result[0].salt; //"/SApKtKXpIa6YnHCjKLxQJAeb279BlX8";
            bool flag = Operational.Encrypt.SaltedHash.Verify(oldsalt, oldhash, password);
            if (flag == false)
            {

                //increase login_failure count 
                Customer objCustomer = _repository.Customer.FindById(result[0].customerID);
                bool accLock = false;
                if (objCustomer != null)
                {
                    var newfailcount = result[0].login_fail_count + 1;
                    var settingresult = (_repository.Setting.GetAllowLoginFailCount()).ToList();
                    var settingfailcount = settingresult[0].Value;

                    //change access_status to 2 if login_failure_count = 'Allow Login Failure Count' from setting table
                    if (newfailcount.ToString() == settingfailcount)
                    {
                        objCustomer.access_status = 2;
                        accLock = true;

                        //send email to unlock
                        var emailtemplateresult = (_repository.EmailTemplate.GetEmailTemplate("Account Lock Notification")).ToList();
                        var settingResult = _repository.EmailTemplate.GetSettingResult();
                        string Message = emailtemplateresult[0].template_content;
                        string Subject = emailtemplateresult[0].subject;
                        string Variable = emailtemplateresult[0].variable;
                        string FromEmail = emailtemplateresult[0].from_email;
                        string Email = result[0].Email;
                        string Account_Name = result[0].customername;
                        string Login_Name = result[0].username;

                        var plainTextBytes = Encoding.UTF8.GetBytes(result[0].customerID.ToString());
                        string ID = Convert.ToBase64String(plainTextBytes).Replace("=", "%3D"); ;
                        string unlock_url = "#/unlock/" + ID;
                        string body = Message.Replace("[Account Name]", Account_Name).Replace("[Login Name]", Login_Name).Replace("[Unlock URL]", unlock_url).Replace("\n", "<br/>");
                        Globalfunction.SendEmailAsync(settingResult, Email, FromEmail, Subject, body, true);

                    }

                    objCustomer.login_fail_count = newfailcount;
                    _repository.Customer.Update(objCustomer);
                    _repository.EventLog.Info("Login failed for this account UserName : " + username + " , Password : " + password);

                    if (accLock == true)
                    {
                        result = _repository.Customer.GetCustomerLoginMobile(username);
                        return result;
                    }

                }
                return null;
            }
            else
            {
                //reset login_failure count
                Customer objCustomer = _repository.Customer.FindById(result[0].customerID);
                if (objCustomer != null)
                {
                    objCustomer.login_fail_count = 0;
                    _repository.Customer.Update(objCustomer);

                    _repository.EventLog.Info("Successful login for this account UserName : " + username);
                    result = _repository.Customer.GetCustomerLoginMobile(username);
                }
            }

            return result;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string ipaddress = "127.0.0.1";
            if (context.Connection.RemoteIpAddress != null) ipaddress = context.Connection.RemoteIpAddress.ToString();
            _session.SetString("LoginUserID", "0");
            _session.SetString("LoginRemoteIpAddress", ipaddress);
            _session.SetString("LoginTypeParam", "1");

            TokenData _tokenData = null;
            var access_token = "";
            var hdtoken = context.Request.Headers["Authorization"];
            if (hdtoken.Count > 0)
            {
                access_token = hdtoken[0];
                access_token = access_token.Replace("Bearer ", "");
                var handler = new JwtSecurityTokenHandler();
                var tokenS = handler.ReadToken(access_token) as JwtSecurityToken;
                _tokenData = Globalfunction.GetTokenData(tokenS);
            }
            else
            {
                //TODO for some
            }
            //  _objdb = DB;
            if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
            {
                await next(context);
                // var methodName = context.Request.Path.ToString().Split("/")[3];
                // if (methodName == "checkDuplicateMemberPublic" || methodName == "SaveMemberPublic" || methodName == "GetMemberTypeComboDataPublic" || methodName == "GetMemberRegister" || methodName == "GetNews" || methodName == "GetImageForWebsite" || methodName == "GetEventForWebsite")
                // {
                //     await next(context);
                // }
                // else
                // {
                //     //Regenerate newtoken for not timeout at running
                //     string newToken = "";
                //     try
                //     {
                //         var pathstr = context.Request.Path.ToString();
                //         string[] patharr = pathstr.Split('/');
                //         int prequest = Array.IndexOf(patharr, "public");
                //         int trequest = Array.IndexOf(patharr, "testapi");
                //         int flowrequest = Array.IndexOf(patharr, "TLG");
                //           int customerrequest = Array.IndexOf(patharr, "CutomerMobile");

                //         if (prequest < 1 && trequest < 1 && flowrequest < 1 && customerrequest < 1)
                //         {
                //             var handler = new JwtSecurityTokenHandler();

                //             var allow = false;

                //             var tokenS = handler.ReadToken(access_token) as JwtSecurityToken;


                //             //check userlevel permission
                //             if (patharr[1].ToString() == "api")
                //             {
                //                 var isadmin = false;
                //                 Adminlevel objAdminLevel = null;
                //                 if (_tokenData.Userlevelid != "")
                //                 {
                //                     objAdminLevel = _repository.AdminLevel.FindAdminLevel(int.Parse(_tokenData.Userlevelid));
                //                 }
                //                 else
                //                 {
                //                     isadmin = true;
                //                 }
                //                 //var objAdminLevel = _repository.AdminLevel.FindAdminLevel(int.Parse(_tokenData.Userlevelid));

                //                 if (objAdminLevel != null)
                //                 {
                //                     isadmin = objAdminLevel.IsAdministrator;
                //                 }
                //                 if (isadmin || patharr[3] == "GetAdminLevelMenuData" || patharr[3] == "checkPassword" || patharr[3] == "PassChange" || patharr[3] == "GetTransactionMenuData")
                //                     allow = true;
                //                 else
                //                 {
                //                     // string ipaddress = context.Connection.RemoteIpAddress.ToString();
                //                     // allow = checkURLPermission(_tokenData, patharr[2], patharr[3], ipaddress);
                //                     string controllername = patharr[2];
                //                     string functionname = patharr[3];
                //                     string ServiceUrl = controllername + "/" + functionname;
                //                     AdminMenuUrl _AdminMenuUrl = _repository.AdminMenuUrl.GetAdminMenuUrlByServiceUrl(ServiceUrl);
                //                     if (_AdminMenuUrl != null)
                //                     {
                //                         Adminlevelmenu _Adminlevelmenu = _repository.Adminlevelmenu.GetAdminlevelmenuByAdminLevelIDAdminMenuID(int.Parse(_tokenData.Userlevelid), _AdminMenuUrl.AdminMenuID);
                //                         if (_Adminlevelmenu != null)
                //                         {
                //                             allow = true;
                //                         }

                //                     }
                //                 }
                //             }
                //             if (patharr[1].ToString() == "mobile")
                //             {

                //                     allow = true;

                //             }

                //             if (allow)
                //             {
                //                 // check token expired   
                //                 double expireTime = Convert.ToDouble(_options.Expiration.TotalMinutes);
                //                 DateTime issueDate = _tokenData.TicketExpireDate.AddMinutes(-expireTime);
                //                 DateTime NowDate = DateTime.UtcNow;
                //                 if (issueDate > NowDate || _tokenData.TicketExpireDate < NowDate)
                //                 {
                //                     // return "-2";
                //                     newToken = "-2";
                //                 }
                //                 // end of token expired check

                //                 var now = DateTime.UtcNow;
                //                 _tokenData.Jti = new DateTimeOffset(now).ToUniversalTime().ToUnixTimeSeconds().ToString();
                //                 _tokenData.Jti = await _options.NonceGenerator();

                //                 var claims = Globalfunction.GetClaims(_tokenData);
                //                 // Create the JWT and write it to a string
                //                 var jwt = new JwtSecurityToken(
                //                     issuer: _options.Issuer,
                //                     audience: _options.Audience,
                //                     claims: claims,
                //                     notBefore: now,
                //                     expires: now.Add(_options.Expiration),
                //                     signingCredentials: _options.SigningCredentials);
                //                 var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                //                 //  return encodedJwt;
                //                 newToken = encodedJwt;
                //                 _session.SetString("LoginUserID", _tokenData.UserID);
                //                 _session.SetString("LoginRemoteIpAddress", ipaddress);
                //                 _session.SetString("LoginTypeParam", "1");
                //                 if (patharr[1].ToString() == "mobile")
                //                 {

                //                     _session.SetString("LoginUserID", _tokenData.UserID);
                //                     _session.SetString("LoginRemoteIpAddress", ipaddress);
                //                     _session.SetString("LoginTypeParam", "mobile");

                //                 }
                //             }
                //             else
                //                 //return "-1";
                //                 newToken = "-1";
                //         }
                //         else
                //         {
                //             // if request is public, let pass without token.
                //             await next(context);
                //         }
                //     }
                //     catch (Exception ex)
                //     {
                //         Globalfunction.WriteSystemLog(ex.Message);
                //     }

                //     if (newToken == "-1")
                //     {
                //         _repository.EventLog.Info("Not include Authorization Header, Access Denied");
                //         context.Response.StatusCode = 400;
                //         await ResponseMessage(new { status = "fail", message = "Access Denied" }, context, 400);

                //     }
                //     else if (newToken == "-2")
                //     {
                //         context.Response.StatusCode = 400;
                //         await ResponseMessage(new { status = "fail", message = "The Token has expired" }, context, 400);
                //     }
                //     else if (newToken != "")
                //     {
                //         context.Response.Headers.Add("Access-Control-Expose-Headers", "newToken");
                //         context.Response.Headers.Add("newToken", newToken);
                //         await next(context);
                //     }
                // }

            }
            else
                // return GenerateToken(context);
                await GenerateToken(context);
        }
    }
}