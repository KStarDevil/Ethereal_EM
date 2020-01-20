using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_tank")]
    public class Tank : BaseModel
    {
        public int tankID { get; set; }

        public string tankname { get; set; }
        public int productID { get; set; }

        public string TLG_Address { get; set; }
        public string temperatureAddress { get; set; }

        public double? gauge { get; set; }
        public double? temperature { get; set; }

        public bool inactive { get; set; }

        public DateTime modifieddate { get; set; }

    }

}