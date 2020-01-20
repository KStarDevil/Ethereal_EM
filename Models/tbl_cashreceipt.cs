using System;

namespace Ethereal_EM
{
    [System.ComponentModel.DataAnnotations.Schema.Table("tbl_cashreceipt")]

    public class CashReceipt : BaseModel
    {
        public string cashreceiptID { get; set; }
        public string saleinvoiceID { get; set;}
        public int customerID { get; set; }
        public double netAmount { get; set; }
        public double balance { get; set; }
        public DateTime paymentDate { get; set; }
        public double paidAmount { get; set; }
        public bool inactive { get; set; }
        public bool status { get; set; }
        public DateTime modifieddate { get; set; }

    }
}