using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_storagecharges")]
    public class StorageCharges : BaseModel
    {
        public int storagechargeID { get; set; }

        public int customerID { get; set; }
        public int productID { get; set; }
        public double charges { get; set; }
        public bool inactive { get; set; }

        public DateTime modifieddate { get; set; }

    }

}