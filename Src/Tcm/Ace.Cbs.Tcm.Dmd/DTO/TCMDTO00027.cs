using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Tcm.Dmd
{
     [Serializable]
    public class TCMDTO00027:Supportfields<TCMDTO00027>
    {
        public TCMDTO00027() { }


        public virtual bool isSchdule { get; set; }
        public virtual bool isAbstract { get; set; }
        public virtual bool isScroll { get; set; }
        public virtual bool isTransactionDate { get; set; }
        public virtual bool isSettlementDate { get; set; }
        public virtual DateTime SelectedDateTime { get; set; }
        public virtual bool isReserval { get; set; }
        public virtual string Currency { get; set; }
        public virtual string BankDescription { get; set; }
        public virtual int OtherBankChequeCount { get; set; }
        public virtual int BankChequeCount { get; set; }
        public virtual decimal Receipt { get; set; }
        public virtual decimal Deliver { get; set; }
        public virtual string DeliveredParticular { get; set; }
        public virtual System.Nullable<decimal> DeliveredDebit { get; set; }
        public virtual System.Nullable<decimal> DeliverCredit { get; set; }
        public virtual string ReceiptParticular { get; set; }
        public virtual System.Nullable<decimal> ReceiptDebit { get; set; }
        public virtual System.Nullable<decimal> ReceiptCredit { get; set; }
        public virtual string DeliverSrNo { get; set; }
        public virtual string ReceiptSrNo { get; set; }
    }
}
