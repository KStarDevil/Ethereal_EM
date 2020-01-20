using System;
using System.IO;
using System.Linq;
using System.Text;
// using Max_Member_API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Ethereal_EM.Repository;

namespace Ethereal_EM
{
    [Route("mobile/[controller]")]
    public class FileServiceController : BaseController
    {
        
        private readonly IHostingEnvironment _hostingEnvironment;
        private IRepositoryWrapper _repositoryWrapper;
         public FileServiceController(IHostingEnvironment hostingEnvironment, IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
            _hostingEnvironment = hostingEnvironment; 
        }
        

       

        // [HttpGet("Download/{functionname}/{param}", Name = "Download")]
        // //[Authorize]
        // public dynamic DownLoadFile(string functionname, string param)
        // {
        //     List<dynamic> porofile = new List<dynamic>();
        //     string path = "";
        //     string ext = "";
        //     byte[] data = Convert.FromBase64String(param);
        //     string decodedString = Encoding.UTF8.GetString(data);
        //     Char delimiter = '/';
        //     String[] substrings = decodedString.Split(delimiter);
        //     if (substrings.Length >= 2)
        //     {
        //         path = substrings[0];
        //         ext = substrings[1]; 
        //     }

        //     string webRootPath = _hostingEnvironment.WebRootPath;
        //     var appsettingbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        //     var Configuration = appsettingbuilder.Build();
        //     // string baseDirecotry = Configuration.GetSection("appSettings:downloadPath").Value;
        //     string folderPath = "";
        //     //string customerName = "";
        //     //string CompanyName = "";


        //     folderPath = Configuration.GetSection("appSettings:downloadMemberProfile").Value;
        //     // folderPath = baseDirecotry + folderPath + "//";
        //     folderPath=Path.Combine(webRootPath,folderPath);

        //     // find extension by file name
        //     string existingFile = Directory.EnumerateFiles(folderPath, path + ".*").FirstOrDefault();
        //     string extension = "";
        //     if (!string.IsNullOrEmpty(existingFile))
        //         extension = Path.GetExtension(existingFile);
        //     //
        //     string pathwithimg=Path.Combine(folderPath,path);
        //     string fullPath = pathwithimg + extension;
        //     if (!System.IO.File.Exists(fullPath))
        //     {
        //         int lstindex = fullPath.LastIndexOf(".");
        //         string subString = fullPath.Substring(lstindex + 1, fullPath.Length - (lstindex + 1));
        //         string concatStr = "0.jpg";
        //         lstindex = fullPath.LastIndexOf(@"\");
        //         subString = fullPath.Substring(0, lstindex + 1);
        //         fullPath = subString + concatStr;
        //     }
        //     try
        //     {
        //         if (ext == "mp4" || ext == "flv")
        //         {
        //             string vdoname = path + "." + ext;
        //             return vdoname;
        //         }
        //         else
        //         {
        //             //fullPath = "dfd";
        //             dynamic fformat = "png";
        //             if (ext != "png")
        //                 fformat = "jpeg";
        //             byte[] m_Bytes = ReadToEnd(new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read));
        //             Response.ContentType = "application/json";
        //             string imageBase64Data = Convert.ToBase64String(m_Bytes);
        //             //string imageDataURL = string.Format("data:image/" + fformat + ";base64,{0}", imageBase64Data);
        //             var image = new { imageString = imageBase64Data}; 
        //             porofile.Add(image);
        //             dynamic objResponse = new { data = porofile}; 
                  
        //             return objResponse;
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         Globalfunction.WriteSystemLog(ex.Message);
        //         Response.StatusCode = 500;
        //         return null;
        //     }

        // }

        // [HttpPost("Upload/{functionname}/{fileparam}", Name = "Upload")]
        // [Authorize]
        // public dynamic FileUpload(String functionname, string fileparam)
        // {
        //     List<dynamic> porofile = new List<dynamic>();
        //     string filename = "";
        //     string ext = "";
        //     byte[] data = Convert.FromBase64String(fileparam);
        //     string decodedString = Encoding.UTF8.GetString(data);
        //     Char delimiter = '/';
        //     String[] substrings = decodedString.Split(delimiter);
            
        //     // if (substrings.Length >= 2)
        //     // {
        //     //     path = substrings[0];
        //     //     ext = substrings[1]; 
        //     // }
        //     if (substrings.Length >= 1)
        //         filename = substrings[0];
        //     if (substrings.Length >= 2)
        //         ext = substrings[1];
        //     string returnStr = "Fail to Upload";
        //     string retfilename = "";
        //     try
        //     {
              
        //         var files = Request.Form.Files;
        //         string webRootPath = _hostingEnvironment.WebRootPath;
        //         var appsettingbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        //         var Configuration = appsettingbuilder.Build();
        //         // string baseDirecotry = Configuration.GetSection("appSettings:downloadPath").Value;
        //         string folderPath = "";
        //         //string customerName = "";
        //         //string CompanyName = "";
        //         folderPath = Configuration.GetSection("appSettings:uploadMemberProfile").Value;
        //         // folderPath = baseDirecotry + folderPath + "//";
        //         folderPath=Path.Combine(webRootPath,folderPath);

        //         string existingFile = Directory.EnumerateFiles(folderPath, filename + ".*").FirstOrDefault();
        //             string extension = "";
        //             if (!string.IsNullOrEmpty(existingFile))
        //                 extension = Path.GetExtension(existingFile);
        //             string oldPath = folderPath + filename + extension;
        //                         // delete old photo
        //             if (System.IO.File.Exists(oldPath)) // Read data when file exists.
        //             {
        //                 System.IO.File.Delete(oldPath);
        //             }
        //             folderPath = folderPath + filename + "." + ext;
        //             retfilename = filename + "." + ext;

        //             // Save the file
        //             var file = files[0];
        //             if (file.Length > 0)
        //             {
        //                 using (var fileStream = new FileStream(folderPath, FileMode.OpenOrCreate))
        //                 {
        //                     file.CopyTo(fileStream);
        //                 }
        //             }
        //             Response.ContentType = "application/json";
        //             returnStr = "Succesfully Upload" + retfilename;
            
        //     }
        //     catch (Exception ex)
        //     {
        //         Globalfunction.WriteSystemLog(ex.Message);
        //         Response.StatusCode = 500;
        //         return null;

        //     }
        //     return returnStr;
        // }

        

        [HttpGet("Download/{functionname}/{param}", Name = "Download")]
        //[Authorize]
        public dynamic DownLoadFile(string functionname, string param)
        {

            string path = "";
            string ext = "";
            String[] substrings;
            string pic = param;
            dynamic objresponse = null;
            if (pic.Contains(",jpg"))
            {
                substrings = pic.Split(',');
                path = substrings[0];
                ext = substrings[1];
            }
            else if(pic.Contains(".jpg"))
            {
                substrings = pic.Split('.');
                path = substrings[0];
                ext = substrings[1];
            }
            else if(pic.Contains("/jpg"))
            {
                substrings = pic.Split('/');
                path = substrings[0];
                ext = substrings[1];
            }
            else
            {
                byte[] data = Convert.FromBase64String(param);
                string decodedString = Encoding.UTF8.GetString(data);
                Char delimiter = '/';
                if(decodedString.Contains('/'))
                {
                    delimiter ='/';
                }
                else if(decodedString.Contains('.')){
                    delimiter='.';
                }
                substrings = decodedString.Split(delimiter);
                if (substrings.Length >= 2)
                {
                    path = substrings[0];
                    ext = substrings[1];
                    // Download to show on Oninit() function in Anglar
                    if (path == 0.ToString())
                    {
                        path = 0.ToString();
                        ext = "jpg";
                    }
                }

            }
            // List<dynamic> porofile = new List<dynamic>();
            // string path = "";
            // string ext = "";
            // byte[] data = Convert.FromBase64String(param);
            // string decodedString = Encoding.UTF8.GetString(data);
            // Char delimiter = '/';
            // String[] substrings = decodedString.Split(delimiter);
            // if (substrings.Length >= 2)
            // {
            //     path = substrings[0];
            //     ext = substrings[1]; 
            // }

            // string webRootPath = _hostingEnvironment.WebRootPath;
            var appsettingbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var Configuration = appsettingbuilder.Build();
            string baseDirecotry = Configuration.GetSection("appSettings:downloadPath").Value;
            string Defaul_Direcotry = baseDirecotry;
            string folderPath = "";
            //string customerName = "";
            //string CompanyName = "";


            folderPath = Configuration.GetSection("appSettings:downloadMemberProfile").Value;
            // folderPath = baseDirecotry + folderPath + "/";
            folderPath = baseDirecotry;
            // folderPath=Path.Combine(webRootPath,folderPath);

            // find extension by file name
            string existingFile = Directory.EnumerateFiles(folderPath, path + ".*").FirstOrDefault();
            string extension = "";
            if (!string.IsNullOrEmpty(existingFile))
                extension = Path.GetExtension(existingFile);
            //
            // 
            string fullPath = folderPath + path + "." + ext;
            if (!System.IO.File.Exists(fullPath))
            {
                // [Original Code Get From its associated folder of 0.jpg file]
                // int lstindex = fullPath.LastIndexOf(".");
                // string subString = fullPath.Substring(lstindex + 1, fullPath.Length - (lstindex + 1));
                // string concatStr = "0.jpg";
                // lstindex = fullPath.LastIndexOf(@"\");
                // subString = fullPath.Substring(0, lstindex + 1);
                // fullPath = subString + concatStr;
                string concatStr = "0.jpg";
                fullPath = Defaul_Direcotry + concatStr;
            }
            try
            {
                if (ext == "mp4" || ext == "flv")
                {
                    string vdoname = path + "." + ext;
                    return vdoname;
                }
                else
                {
                    // fullPath = "dfd";
                    var fformat = "png";
                    if (ext != fformat)
                        fformat = "jpeg";
                    byte[] m_Bytes = ReadToEnd(new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read));
                    Response.ContentType = "application/json";
                   
                    // string imageBase64Data = Convert.ToBase64String(m_Bytes);
                    // imageBase64Data = imageBase64Data.Replace('-', '+').Replace('_', '/').PadRight(4*((imageBase64Data.Length+3)/4), '=');
                    // string imageDataURL = string.Format("data:image/" + fformat + ";base64,{0}", imageBase64Data);
                    // objresponse = new { status = 1, messages = imageBase64Data };

                    // string imageDataURL = string.Format(imageBase64Data);
                    objresponse = new { status = 1, messages = m_Bytes };
                    
                    // Globalfunction.WriteSystemLog(BitConverter.ToString(m_Bytes));
                    return objresponse;
                }
            }
            catch (Exception ex)
            {
                // Globalfunction.WriteSystemLog(ex.Message);
                if(ex.Message.Contains("The input is not a valid Base-64 string as it contains a non-base 64 character,"))
                {
                    Response.StatusCode = 500;
                    dynamic uu = null;
                    objresponse = new { status = 0, messages = uu };
                    return objresponse;
                }else
                 {
                    Response.StatusCode = 500;
                    dynamic uu = null;
                    objresponse = new { status = 0, messages = uu };
                    // _repositoryWrapper.EventLog.Error("fileDownload(Exception) : " , ex.Message, "", "");
                    return objresponse;
                 }
                
            }

        }

        [HttpPost("Upload/{functionname}/{fileparam}", Name = "Upload")]
        // [Authorize]
        public dynamic FileUpload(String functionname, string fileparam)
        {
        
            string filename = "";
            string ext = "";
            byte[] data = Convert.FromBase64String(fileparam);
            string decodedString = Encoding.UTF8.GetString(data);
            Char delimiter = '/';
            String[] substrings = decodedString.Split(delimiter);
            dynamic objresponse = null;
            
            // if (substrings.Length >= 2)
            // {
            //     path = substrings[0];
            //     ext = substrings[1]; 
            // }
            if (substrings.Length >= 1)
                filename = substrings[0];
            if (substrings.Length >= 2)
                ext = substrings[1];

            string returnStr = "Fail to Upload";
            string retfilename = "";
            try
            {
              
                var files = Request.Form.Files;
                var appsettingbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
                var Configuration = appsettingbuilder.Build();
                string baseDirecotry = Configuration.GetSection("appSettings:downloadPath").Value;
                string folderPath = "";
                //string customerName = "";
                //string CompanyName = "";
                folderPath = Configuration.GetSection("appSettings:uploadMemberProfile").Value;
                // folderPath = baseDirecotry + folderPath + "/";
                folderPath = baseDirecotry;
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                // folderPath=Path.Combine(webRootPath,folderPath);

                string existingFile = Directory.EnumerateFiles(folderPath, filename + ".*").FirstOrDefault();
                    string extension = "";
                    if (!string.IsNullOrEmpty(existingFile))
                        extension = Path.GetExtension(existingFile);
                    string oldPath = folderPath + filename + extension;
                                // delete old photo
                    if (System.IO.File.Exists(oldPath)) // Read data when file exists.
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    folderPath = folderPath + filename + "." + ext;
                    retfilename = filename + "." + ext;
                    //Member newMemberobj = _repositoryWrapper.Member.FindByID(Convert.ToInt32(filename));

                    // newMemberobj.loginname = newMemberobj.loginname;
                    // newMemberobj.memberphone = newMemberobj.memberphone;
                    // newMemberobj.memberdob = newMemberobj.memberdob;
                    // newMemberobj.memberaddress = newMemberobj.memberaddress;
                    // newMemberobj.password = newMemberobj.password;
                    // newMemberobj.email = newMemberobj.email;

                    // newMemberobj.membercardnumber = newMemberobj.membercardnumber;
                    // newMemberobj.membername = newMemberobj.membername;;
                    // newMemberobj.pointbalance = newMemberobj.pointbalance;
                    // newMemberobj.totalpointbalance = newMemberobj.totalpointbalance;
                    // newMemberobj.cardtypekwid = newMemberobj.cardtypekwid;
                    // newMemberobj.embossstatus = newMemberobj.embossstatus;
                    // newMemberobj.branchcode = newMemberobj.branchcode; 
                    // newMemberobj.expireddate = newMemberobj.expireddate;
                    // newMemberobj.issuedate = newMemberobj.issuedate;
                    // newMemberobj.memberdob = newMemberobj.memberdob;
                    //newMemberobj.photo = decodedString;
                    // newMemberobj.openingpoint = newMemberobj.openingpoint;
                    // newMemberobj.isactive = newMemberobj.isactive;
                    // newMemberobj.partnerid = newMemberobj.partnerid;
                    // newMemberobj.createdate = newMemberobj.createdate;
                    // newMemberobj.createuser = newMemberobj.createuser;; //! need to ask ?
                    // newMemberobj.nrc = newMemberobj.nrc;
                    // newMemberobj.nrctype = newMemberobj.nrctype;
                    // newMemberobj.customer_type = newMemberobj.customer_type;
                    // newMemberobj.openingpointamount = newMemberobj.openingpointamount;
                    // newMemberobj.totalpointamount = newMemberobj.totalpointamount;
                    // newMemberobj.version = newMemberobj.version;
                    // newMemberobj.amount = newMemberobj.amount;
                    // newMemberobj.liter = newMemberobj.liter;

                    //_repositoryWrapper.Member.Update(newMemberobj);

                    // Save the file
                    var file = files[0];
                    if (file.Length > 0)
                    {
                        using (var fileStream = new FileStream(folderPath, FileMode.OpenOrCreate))
                        {
                            file.CopyTo(fileStream);
                        }
                    }
                    Response.ContentType = "application/json";
                    returnStr = "Succesfully Upload  " + retfilename;
                    objresponse = new { status = 1, messages = returnStr };
            
            }
            catch (Exception ex)
            {
                Globalfunction.WriteSystemLog(ex.Message);
                // _repositoryWrapper.EventLog.Error("fileUpload(Exception) : " , ex.Message, "", "");
                Response.StatusCode = 500;
                dynamic uu = null;
                objresponse = new { status = 0, messages = uu };
                return objresponse;
                // return null;

            }
            
            return objresponse;
        }

        public static byte[] ReadToEnd(System.IO.Stream inputStream)
        {
            if (!inputStream.CanRead)
            {
                throw new ArgumentException();
            }

            // This is optional
            if (inputStream.CanSeek)
            {
                inputStream.Seek(0, SeekOrigin.Begin);
            }

            byte[] output = new byte[inputStream.Length];
            int bytesRead = inputStream.Read(output, 0, output.Length);
            inputStream.Dispose();//.Close();
            //Debug.Assert(bytesRead == output.Length, "Bytes read from stream matches stream length");
            return output;
        }
    }
}