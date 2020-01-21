using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_admin11")]
    public class Admin : BaseModel
    {
        public int AdminID { get; set; }
        public sbyte access_status { get; set; }
        public int AdminLevelID { get; set; }
        public string AdminName { get; set; }
        public DateTime created_date { get; set; }
        public string Email { get; set; }
        public string CompanyID { get; set; }
        public string ImagePath { get; set; }
        public int login_fail_count { get; set; }
        public string LoginName { get; set; }
        public DateTime modified_date { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

    }
}