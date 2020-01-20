using System;
using System.Collections.Generic;
using Ethereal_EM.Repository;

namespace Ethereal_EM.Repository
{
    public interface ICashReceiptRepository : IRepositoryBase<CashReceipt>
    {
          dynamic GetAllCashRecriptList (dynamic param);
         dynamic GetCashReceiptEditList(string cashreceiptid);
    }
}