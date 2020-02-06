using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_admin")]
    public class tbl_admin : BaseModel
    {
        public int admin_id { get; set; }
        public string admin_name { get; set; }
        public string admin_password { get; set; }
        public string admin_photo_path { get; set; }
        public string admin_salt { get; set; }
        public int admin_access_status { get; set; }
        public int admin_login_fail_count { get; set; }
        public string admin_login_name { get; set; }
        public DateTime admin_created_date { get; set; }
        public DateTime admin_modified_date { get; set; }
        public string admin_email { get; set; }
        public int admin_role_id { get; set; }
    }
}