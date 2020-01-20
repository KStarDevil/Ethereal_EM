using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_customerassigndetail")]
    public class CustomerAssignDetail : BaseModel
    {
        public int assigndetailID { get; set; }

        public int customerassignID { get; set; }
        public string customerOrderID { get; set; }
        public double orderliter { get; set; }
        public double assignliter { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}