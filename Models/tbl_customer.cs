using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_customer")]
    public class Customer : BaseModel
    {
        public int customerID { get; set; }

        public string customername { get; set; }
        public string code { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public int login_fail_count { get; set; }
        public int access_status { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public int township { get; set; }
        public int state { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}