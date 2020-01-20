using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_tankimport")]
    public class TankImport : BaseModel
    {
        public int ID { get; set; }

        public int typeID { get; set; }
        public int tankID { get; set; }

        public double gallon { get; set; }
        public double liter { get; set; }

        public int level { get; set; }
    
        public bool inactive { get; set; }

        public DateTime modifieddate { get; set; }

    }

}