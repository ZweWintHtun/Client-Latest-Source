using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Print File DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00043 : Supportfields<PFMDTO00043>
    {
        public PFMDTO00043() { }

        public PFMDTO00043(int id,decimal Credit,decimal Debit, decimal Balance,string Reference,DateTime CreatedDate)
        {
            this.Id = id;
            this.Credit = Credit;
            this.Debit = Debit;
            this.Balance = Balance;
            this.Reference = Reference;
            this.CreatedDate = CreatedDate;
        }

        public PFMDTO00043(int id, decimal Credit, decimal Debit, decimal Balance, string Reference, DateTime CreatedDate, DateTime DateTime)
        {
            this.Id = id;
            this.Credit = Credit;
            this.Debit = Debit;
            this.Balance = Balance;
            this.Reference = Reference;
            this.CreatedDate = CreatedDate;
            this.DATE_TIME = DateTime;
        }
        public PFMDTO00043(string accountNo, DateTime dateTime, decimal debit, decimal credit, decimal balance, string reference)
        {
            this.AccountNo = accountNo;
            this.DATE_TIME = dateTime;
            this.Debit = debit;
            this.Credit = credit;            
            this.Balance = balance;
            this.Reference = reference;           
        }


        public virtual int Id { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual System.Nullable<DateTime> DATE_TIME { get; set; }
        public virtual string UserNo { get; set; }
        public virtual decimal Credit { get; set; }
        public virtual decimal Debit { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual string Channel { get; set; }
        public virtual string Reference { get; set; }
        public virtual decimal PrintLineNo { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string IsDoPrinting { get; set; }
        public virtual bool IsCledgerAccountStatus { get; set; }
        public virtual int LedgerPrintLineNo { get; set; }
    }
}