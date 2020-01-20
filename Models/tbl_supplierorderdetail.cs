using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_supplierorderdetail")]
    public class SupplierOrderDetail : BaseModel
    {
        public string supplierorderdetailID { get; set; }
        public string supplierorderID { get; set; }
        public int productID { get; set; }
        public double liter { get; set; }
        public double price { get; set; }
        public bool inactive { get; set; }
        public DateTime modifieddate { get; set; }

    }

}