using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd.DTO
{
    [Serializable]
   public class TCMDTO00011:EntityBase<TCMDTO00011>
    {
       public TCMDTO00011() { }
       //public int Id { get; set; }
       public string Cur { get; set; }
       public decimal ReceiptCash { get; set; }
       public decimal ReceiptCashVou { get; set; }
       public decimal ReceiptTransfer { get; set; }
       public decimal ReceiptTransferVou { get; set; }
       public decimal ReceiptClearing { get; set; }
       public decimal ReceiptClearingVou { get; set; }
       public decimal PaymentCash { get; set; }
       public decimal PaymentCashVou { get; set; }
       public decimal PaymentTransfer { get; set; }
       public decimal PaymentTransferVou { get; set; }
       public decimal PaymentClearing { get; set; }
       public decimal PaymentClearingVou { get; set; }
       public decimal DrawingCash { get; set; }
       public decimal DrawingCashVou { get; set; }
       public decimal DrawingTransfer { get; set; }
       public decimal DrawingTransferVou { get; set; }
       public decimal EncashCash { get; set; }
       public decimal EncashCashVou { get; set; }
       public decimal EncashTransfer { get; set; }
       public decimal EncashTransferVou { get; set; }
       public decimal CashInHand { get; set; }
       public decimal CashWithCBM { get; set; }
       public decimal ACWithOthBank { get; set; }
       public decimal CurOpened { get; set; }
       public decimal CurClosed { get; set; }
       public decimal CurTotal { get; set; }
       public decimal CurOBal { get; set; }
       public decimal CurDep { get; set; }
       public decimal CurWith { get; set; }
       public decimal SavOpened { get; set; }
       public decimal SavClosed { get; set; }
       public decimal SavTotal { get; set; }
       public decimal SavOBal { get; set; }
       public decimal SavDep { get; set; }
       public decimal SavWith { get; set; }      
       public decimal CalOpened { get; set; }
       public decimal CalClosed { get; set; }
       public decimal CalTotal { get; set; }
       public decimal CalOBal { get; set; }
       public decimal CalWith { get; set; }
       public decimal FixOpened { get; set; }
       public decimal FixClosed { get; set; }
       public decimal FixTotal { get; set; }
       public decimal FixOBal { get; set; }
       public decimal FixDep { get; set; }
       public decimal FixWith { get; set; }
       public DateTime Date_Time { get; set; }

    }
}
