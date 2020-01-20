using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_supplierorder")]
    public class SupplierOrder : BaseModel
    {
        public string supplierOrderID { get; set; }
        public string suppliername { get; set; }
        public string shipment { get; set; }
        public DateTime arrivaldate { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}