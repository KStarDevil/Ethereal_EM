using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_driver")]
    public class Driver : BaseModel
    {
        public int driverID { get; set; }

        public string name { get; set; }
        public string phone { get; set; }
        public int nrcNo { get; set; }
        public int nrcDivisionCode { get; set; }
        public int nrcTownshipCode { get; set; }
        public int nrcCitizenCode { get; set; }
        public string license { get; set; }
        public string address { get; set; }
        public int township { get; set; }
        public string photo { get; set; }
        public int state { get; set; }
        public string cardNo { get; set; }
        public int status { get; set; }
        public int createuser { get; set; }
        public bool usertype { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}