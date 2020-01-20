using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_demandorderdetail")]
    public class DemandOrderDetail : BaseModel
    {
        public string orderdetailID { get; set; }

        public string demandorderID { get; set; }

        public int compartmentID { get; set; }
        public int productID { get; set; }
        public double orderliter { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}