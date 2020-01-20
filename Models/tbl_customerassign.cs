using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_customerassign")]
    public class CustomerAssign : BaseModel
    {
        public int customerassignID { get; set; }

        public int productID { get; set; }
        public string supplierorderID { get; set; }
        public DateTime assignweek { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}