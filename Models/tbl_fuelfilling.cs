using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_fuelfilling")]
    public class FuelFilling : BaseModel
    {
        public int fillingID { get; set; }
        public string deliveryID { get; set; }
        public int compartmentID { get; set; }
        public int productID { get; set; }
        public int laneID { get; set; }
        public int hoseID { get; set; }
        public bool assignliter { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}