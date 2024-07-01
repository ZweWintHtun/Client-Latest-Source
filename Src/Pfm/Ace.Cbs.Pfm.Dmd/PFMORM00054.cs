using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Transaction Log File ORM Entity
    /// </summary>
    [Serializable]
    public class PFMORM00054 : EntityBase<PFMORM00054>
    {
        //TLF Entity
        public PFMORM00054() { }

        public virtual string Eno { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string Acode { get; set; }
        public virtual System.Nullable<decimal> HomeAmount { get; set; }
        public virtual System.Nullable<decimal> HomeAmt { get; set; }
        public virtual System.Nullable<decimal> HomeOAmt { get; set; }
        public virtual System.Nullable<decimal> LocalAmount { get; set; }
        public virtual System.Nullable<decimal> LocalAmt { get; set; }
        public virtual System.Nullable<decimal> LocalOAmt { get; set; }
        public virtual string SourceCurrency { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string Cheque { get; set; }
        public virtual string PaymentOrderNo { get; set; }
        public virtual string DRegisterNo { get; set; }
        public virtual string ERegisterNo { get; set; }
        public virtual string LgNo { get; set; }
        public virtual string Lno { get; set; }
        public virtual string Description { get; set; }
        public virtual string Narration { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual string Status { get; set; }
        public virtual string TransactionCode { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual string DOMBankPost { get; set; }
        public virtual string CLRPostStatus { get; set; }
        public virtual string OrgnEno { get; set; }
        public virtual string OrgnTransactionCode { get; set; }
        public virtual string OrgnCheque { get; set; }
        public virtual string OrgnPaymentOrderNo { get; set; }
        public virtual string OrgnDRegister { get; set; }
        public virtual string OrgnERegister { get; set; }
        public virtual string OrgnLgNo { get; set; }
        public virtual string OrgnLNo { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string ContraENo { get; set; }
        public virtual string ContraLNo { get; set; }
        public virtual System.Nullable<DateTime> ContraDateTime { get; set; }
        public virtual string OtherBank { get; set; }
        public virtual bool DeliverReturn { get; set; }
        public virtual string ReceiptNo { get; set; }
        public virtual string OtherBankChq { get; set; }
        public virtual System.Nullable<DateTime> CheckTime { get; set; }
        public virtual string OtherBankAcctNo { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string GChequeNo { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual System.Nullable<decimal> Rate { get; set; }
        public virtual System.Nullable<DateTime> SettlementDate { get; set; }
        public virtual string Channel { get; set; }
        public virtual string ReferenceVoucherNo { get; set; }
        public virtual string ReferenceType { get; set; }
        public virtual string BankName { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Phone { get; set; }
        public virtual string ReceivedBank { get; set; }
        //public virtual TLMORM00009 DepoDeno { get; set; }
    }
}
