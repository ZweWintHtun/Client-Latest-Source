using System;
using Ace.Windows.Core.DataModel;
namespace Ace.Cbs.Tel.Dmd
{
     /// <summary>
    /// CashDenoHistory Entity
    /// </summary>
    [Serializable]
    public class TLMORM00056 : EntityBase<TLMORM00056>
    {
     public TLMORM00056() { }
        public virtual int Id { get; set; }
        public virtual string DenoEntryNo { get; set; }
        public virtual string TlfEntryNo { get; set; }
        public virtual string AccountType { get; set; }
        public virtual string FromType { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string ReceiptNo { get; set; }
        public virtual System.Nullable<decimal> Amount { get; set; }
        public virtual System.Nullable<decimal> AdjustAmount { get; set; }
        public virtual System.Nullable<DateTime> CashDate { get; set; }
        public virtual string DenoDetail { get; set; }
        public virtual string DenoRefundDetail { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string CounterNo { get; set; }
        public virtual string Status { get; set; }
        public virtual System.Nullable<bool> Reverse { get; set; }
        public virtual string UniqueId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string Currency { get; set; }
        public virtual string DenoRate { get; set; }
        public virtual string DenoRefundRate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual string AllDenoRate { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual TLMORM00009 DepoDeno { get; set; }
        public virtual TLMORM00004 IblTlf { get; set; }
    }
}
