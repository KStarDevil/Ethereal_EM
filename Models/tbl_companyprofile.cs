using System;

namespace Ethereal_EM
{
     [System.ComponentModel.DataAnnotations.Schema.Table("tbl_companyprofile")]
    public class Company: BaseModel
    {
        public int companyID { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int township {get; set;}
         public int state {get; set;}
         public DateTime modifieddate{get;set;}
        public bool inactive { get; set; }
    }
    
}