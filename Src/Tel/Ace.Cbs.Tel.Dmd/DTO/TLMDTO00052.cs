using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Tel.Dmd
{
     [Serializable]
   public class TLMDTO00052
    {
       public TLMDTO00052() { }

      
       public string VoucherNo { get; set; }
       public string RegisterNo { get; set; }
       public string DBank { get; set; }
       public string AccountNo { get; set; }
       public decimal Amount { get; set; }
       public decimal Commission { get; set; }
       public decimal TlxCharges { get; set; }
       public string Name { get; set; }
       public string IncomeType { get; set; }
       public decimal TestKey { get; set; }
       public string CheckNo { get; set; }
       public string RDType { get; set; }
       public string AccountSign { get; set; }
       public string LoanSerial { get; set; }
       public string Currency { get; set; }
       public string ManagerId { get; set; }
       public bool ChkClose { get; set; }
       public bool TrueLink { get; set; }
       public string ExchangeRateString { get; set; }
       public string DenoRateString { get; set; }
       public string BranchCode { get; set; }
       public string SettlementDate { get; set; }
       public string Channel { get; set; }
    }
}
