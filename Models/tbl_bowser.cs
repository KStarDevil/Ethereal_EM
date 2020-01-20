using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_bowser")]
    public class Bowser : BaseModel
    {
        public int bowserID { get; set; }

        public string bowserName { get; set; }
        public string ownerName { get; set; }
        public string address { get; set; }
        public string carNo { get; set; }
        public string phone { get; set; }
        public int status { get; set; }
        public int createuser { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }
        public bool user_type { get; set; }

    }

}