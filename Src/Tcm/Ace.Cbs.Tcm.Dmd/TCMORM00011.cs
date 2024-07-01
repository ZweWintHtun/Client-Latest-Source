using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
    [Serializable]
    public class TCMORM00011 : EntityBase<TCMORM00011>
    {
        public virtual string Cur { get; set; }
        public virtual decimal ReceiptCash { get; set; }
        public virtual decimal ReceiptCashVou { get; set; }
        public virtual decimal ReceiptTransfer { get; set; }
        public virtual decimal ReceiptTransferVou { get; set; }
        public virtual decimal ReceiptClearing { get; set; }
        public virtual decimal ReceiptClearingVou { get; set; }
        public virtual decimal PaymentCash { get; set; }
        public virtual decimal PaymentCashVou { get; set; }
        public virtual decimal PaymentTransfer { get; set; }
        public virtual decimal PaymentTransferVou { get; set; }
        public virtual decimal PaymentClearing { get; set; }
        public virtual decimal PaymentClearingVou { get; set; }
        public virtual decimal DrawingCash { get; set; }
        public virtual decimal DrawingCashVou { get; set; }
        public virtual decimal DrawingTransfer { get; set; }
        public virtual decimal DrawingTransferVou { get; set; }
        public virtual decimal EncashCash { get; set; }
        public virtual decimal EncashCashVou { get; set; }
        public virtual decimal EncashTransfer { get; set; }
        public virtual decimal EncashTransferVou { get; set; }
        public virtual decimal CashInHand { get; set; }
        public virtual decimal CashWithCBM { get; set; }
        public virtual decimal ACWithOthBank { get; set; }
        public virtual decimal CurOpened { get; set; }
        public virtual decimal CurClosed { get; set; }
        public virtual decimal CurTotal { get; set; }
        public virtual decimal CurOBal { get; set; }
        public virtual decimal CurDep { get; set; }
        public virtual decimal CurWith { get; set; }
        public virtual decimal SavOpened { get; set; }
        public virtual decimal SavClosed { get; set; }
        public virtual decimal SavTotal { get; set; }
        public virtual decimal SavOBal { get; set; }
        public virtual decimal SavDep { get; set; }
        public virtual decimal SavWith { get; set; }
        public virtual decimal CalOpened { get; set; }
        public virtual decimal CalClosed { get; set; }
        public virtual decimal CalTotal { get; set; }
        public virtual decimal CalOBal { get; set; }
        public virtual decimal CalDep { get; set; }
        public virtual decimal CalWith { get; set; }
        public virtual decimal FixOpened { get; set; }
        public virtual decimal FixClosed { get; set; }
        public virtual decimal FixTotal { get; set; }
        public virtual decimal FixOBal { get; set; }
        public virtual decimal FixDep { get; set; }
        public virtual decimal FixWith { get; set; }
        public virtual DateTime Date_Time { get; set; }
    }
}
