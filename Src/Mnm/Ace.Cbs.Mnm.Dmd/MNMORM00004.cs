using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    /// <summary>
    /// History Cash Deno Entity
    /// </summary>
    [Serializable]
    public class MNMORM00004 : EntityBase<MNMORM00004>
    {
        public MNMORM00004() { }

        public virtual int Id { get; set; }
        public virtual string DenoEntryNo { get; set; }
        public virtual string TLFEntryNo { get; set; }
        public virtual string AccountType { get; set; }
        public virtual string FromType { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string ReceiptNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal AdjustmentAmount { get; set; }
        public virtual DateTime CashDate { get; set; }
        public virtual string DenoDetail { get; set; }
        public virtual string DenoRefundDetail { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual string Status { get; set; }
        public virtual bool Reverse { get; set; }
        public virtual string UId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string Currency { get; set; }
        public virtual string DenoRate { get; set; }
        public virtual string DenoRefundRate { get; set; }
        public virtual DateTime SettlementDate { get; set; }
        public virtual string AllDenoRate { get; set; }
        public virtual decimal Rate { get; set; }
        
    }
}



