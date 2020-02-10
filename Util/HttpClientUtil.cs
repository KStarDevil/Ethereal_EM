using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;

namespace billing_api
{
    public class HttpClientUtil
    {

        /// <summary>
        /// To Access API for POST Method
        /// </summary>
        /// <param name="ServiceURL">The ServiceURL you want to access</param>
        /// <param name="PostDataObject">Data for POST Request, have to be in JObject</param>
        /// <param name="AllowToken">true to authorize, false to not</param>
        /// <param name="Headers">Your Additional Headers</param>
        /// <returns>Return JSON data string if success, else return false</returns>
        public static async Task<dynamic> HttpPost(string ServiceURL, dynamic PostDataObject = null)
        {
            HttpResponseMessage result;
            string ResultContent = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    client.BaseAddress = new Uri(ServiceURL);

                    //#Headers Start
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //#Headers End
                    if (PostDataObject != null)
                    {
                        string stringData = Newtonsoft.Json.JsonConvert.SerializeObject(PostDataObject);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        result = client.PostAsync(ServiceURL, contentData).Result;

                        // result =await client.PostAsync("", contentData).ConfigureAwait(false);

                    }
                    else
                    {
                        result = client.PostAsync("", null).Result;
                    }

                    //#validate statuscode have to 200, else exception
                    if (result.IsSuccessStatusCode)
                    {
                        ResultContent = await result.Content.ReadAsStringAsync();
                    }
                    else
                        ResultContent = "false";
                }

                //return ResultContent;
                return new { status = "success", message = ResultContent };
            }
            catch (Exception ex)
            {
                return new { status = "fail", message = ex.Message };
            }
        }


        public static async Task<(object, string, string)> PostWebApi(object model)
        {
            //var dir = "";//_session.GetString(SessionsKeys.Directory);
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/CAService/ReadPubKeyServiceRequest/DFB9017FE8F97B6670AAB1ADF804E6B2861BAAE8");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                string stringData = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync("", contentData).Result;//dir + "/", contentData).Result;
                var msg = await response.Content.ReadAsStringAsync();
                var theresponse = response.IsSuccessStatusCode.ToString();
                return (model, msg, theresponse);
            }
        }

          public static async Task<dynamic> OTPHttpPost(string ServiceURL, dynamic PostDataObject = null, Dictionary<string, string> HeadersParam = null, bool readFailRequestdata = false)
        {
            try
            {
                HttpResponseMessage result;
                string ResultContent = "";
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(5);
                    client.BaseAddress = new Uri(ServiceURL);
                    //#Headers Start
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string[] SP = new string[1];
                    SP = ServiceURL.Split("/");
                    if (SP[SP.Length - 1] == "deliveryInfos")
                    {
                       
                        foreach (var header in HeadersParam)
                        {
                            if (header.Key == "Authorization")
                            {
                                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("AUTH", header.Value);
                                //client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", header.Value);
                            }
                            else
                                client.DefaultRequestHeaders.Add("Host", "www.sdp.orange.ci");
                        }
                    }
                    else
                    {
                        if (HeadersParam != null)
                        {
                            foreach (var header in HeadersParam)
                            {
                                if (header.Key == "Authorization")
                                {

                                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("AUTH", header.Value);
                                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", header.Value);

                                }
                                else
                                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                            }
                        }
                    }

                    //#Headers End
                    if (PostDataObject != null)
                    {
                        string stringData = Newtonsoft.Json.JsonConvert.SerializeObject(PostDataObject);
                        var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                        result = client.PostAsync("", contentData).Result;
                        // result =await client.PostAsync("", contentData).ConfigureAwait(false);
                    }
                    else
                    {
                         await Task.Delay(3000);
                        //var contentData = new StringContent(null, System.Text.Encoding.UTF8, "application/json");
                        result = client.GetAsync("").Result;
                    }

                    //#validate statuscode have to 200, else exception
                    if (result.IsSuccessStatusCode)
                    {
                        ResultContent = await result.Content.ReadAsStringAsync();
                    }
                    else if (readFailRequestdata)
                    {
                        ResultContent = await result.Content.ReadAsStringAsync();
                    }
                    else
                        ResultContent = "false";
                }

                //return ResultContent;
                return new { status = "success", message = ResultContent };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new { status = "fail", message = ex.Message };
            }
        }

    }
}