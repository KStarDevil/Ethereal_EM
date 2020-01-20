using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_deliverydetail")]
    public class DeliveryDetail : BaseModel
    {
        public int deliverydetailID { get; set; }
        public int deliveryID { get; set; }
        public string orderNo { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}