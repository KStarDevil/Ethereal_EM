using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_compartment")]
    public class Compartment : BaseModel
    {
        public int compartmentID { get; set; }
        public int bowserID { get; set; }
        public string name { get; set; }
        public double capacity { get; set; }
        public string calibration { get; set; }
        public bool inactive { get; set; }

        public DateTime modifieddate { get; set; }

    }

}