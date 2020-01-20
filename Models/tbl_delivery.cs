using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_delivery")]
    public class Delivery : BaseModel
    {
        public int deliveryID { get; set; }
        public string cardNo { get; set; }
        public string carNo { get; set; }
        public string token { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}