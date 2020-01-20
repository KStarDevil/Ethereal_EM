using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_customerorderdetail")]
    public class CustomerOrderDetail : BaseModel
    {
        public string customerorderDetailID { get; set; }

        public string customerOrderID { get; set; }
        public int productID { get; set; }
        public double week1_liter { get; set; }
        public double week2_liter { get; set; }
        public double week3_liter { get; set; }
        public double week4_liter { get; set; }
        public double total { get; set; }
        public string remark { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}