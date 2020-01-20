using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_demandorder")]
    public class DemandOrder : BaseModel
    {
        public string demandorderID { get; set; }

        public DateTime deliveryorderDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public int customerID { get; set; }
        public int driverID { get; set; }
        public int bowserID { get; set; }
        public int status { get; set; }
        public int createuser { get; set; }
        public bool userType { get; set; }
        public string remark { get; set; }

        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}