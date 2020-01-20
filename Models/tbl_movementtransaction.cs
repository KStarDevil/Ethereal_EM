using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_movementtransaction")]
    public class MovementTransaction : BaseModel
    {
        public int movementID { get; set; }
        public string supplierOrderID { get; set; }
        public DateTime movementDate { get; set; }
        public int tankID { get; set; }
        public int productID { get; set; }
        public double? flowmeter { get; set; }
        public double? TLG_Start { get; set; }
        public double? TLG_End { get; set; }
        public double? TLG_Volume { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}