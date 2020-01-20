using System;

namespace Ethereal_EM
{
     [System.ComponentModel.DataAnnotations.Schema.Table("tbl_lane")]
    public class Lane: BaseModel
    {
        public int laneID { get; set; }
       
        public string laneName { get; set; }
       
        public bool inactive { get; set; }

        public DateTime modifieddate {get;set;}

    }
    
}