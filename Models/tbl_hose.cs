using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_hose")]
    public class Hose : BaseModel
    {
        public int hoseID { get; set; }

        public int laneID { get; set; }
        public string hoseNumber { get; set; }
        public int productID { get; set; }
        public string flowmeter { get; set; }
        public bool inactive { get; set; }

        public DateTime modifieddate { get; set; }

    }

}