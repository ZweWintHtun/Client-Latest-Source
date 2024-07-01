using System;
using Ace.Windows.Core.DataModel;


// RAW DTO FOR PrintRecord, PrnFile and FPrnFile
namespace Ace.Cbs.Pfm.Dmd
{
    [System.Serializable]
    public class PFMDTO00068 : EntityBase<PFMDTO00068>
    {
        public PFMDTO00068() { }

        public virtual string AcctNo { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual string UserNo { get; set; }
        public virtual decimal Credit { get; set; }
        public virtual decimal Debit { get; set; }
        public virtual string Channel { get; set; }
        public virtual string CurrencyId { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual string Reference { get; set; }
        public virtual System.Nullable<Int32> PrintLineNo { get; set; }

        public PFMDTO00068(string acctNo, DateTime dateTime, string userNo, decimal credit, decimal debit, string channel, string currencyId, decimal balance, string sourceBr, string reference, System.Nullable<Int32> printLineNo)
        {

            this.AcctNo = acctNo;
            this.DateTime = dateTime;
            this.UserNo = userNo;
            this.Credit = credit;
            this.Debit = debit;
            this.Channel = channel;
            this.CurrencyId = currencyId;
            this.Balance = balance;
            this.SourceBr = sourceBr;
            this.Reference = reference;
            this.PrintLineNo = printLineNo;

        }
    }
}
