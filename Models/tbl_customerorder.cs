using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_customerorder")]
    public class CustomerOrder : BaseModel
    {
        public string customerOrderID { get; set; }

        public int customerID { get; set; }

        public DateTime ordermonth { get; set; }
        public int status { get; set; }
        public bool userType { get; set; }
        public int createuser { get; set; }
        public bool inactive { get; set; }
        public string remark { get; set; }
        public DateTime modifieddate { get; set; }

    }

}