using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    // Fledger dto
    [Serializable]
    public class PFMDTO00023 : Supportfields<PFMDTO00023>
    {
        public PFMDTO00023() { }

        public PFMDTO00023(int printLineNo)
        {
            this.PrintLineNo = printLineNo;
        }

        public PFMDTO00023(string accountSign,string currencyCode)
        {
            this.AccountSignature = accountSign;
            this.CurrencyCode = currencyCode;
        }

        public PFMDTO00023(string accountSign, string currencyCode,string sourceBr)
        {
            this.AccountSignature = accountSign;
            this.CurrencyCode = currencyCode;
            this.SourceBranchCode = sourceBr;
        }

        public PFMDTO00023(decimal fBal, int updatedUserId, DateTime updatedDate)
        {
            this.FixedBalance = fBal;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;

        }

        public PFMDTO00023(decimal fBal)
        {
            this.FixedBalance = fBal;
        }

        public PFMDTO00023(string accountNo,decimal fixBalance,string accountSignature,decimal linkLimit,string debitAccountNo,int printLineNo,string sourceBr,string currency,DateTime dateTime)
        {
            this.AccountNo = accountNo;
            this.FixedBalance = fixBalance;
            this.AccountSignature = accountSignature;
            this.LinkLimit = linkLimit;
            this.DebitAccountNo = debitAccountNo;
            this.PrintLineNo = printLineNo;
            this.SourceBranchCode = sourceBr;
            this.CurrencyCode = currency;
            this.Date_Time = dateTime;
        }
        public PFMDTO00023(string accountNo, decimal fBal)
        {
            this.AccountNo = accountNo;
            this.FixedBalance = fBal;
        }
        // Primary Key
        public virtual string AccountNo { get; set; }
        public virtual decimal FixedBalance { get; set; }
        public virtual string AccountSignature { get; set; }
        public virtual decimal LinkLimit { get; set; }
        public virtual string DebitAccountNo { get; set; }
        public virtual int PrintLineNo { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string SourceBranchCode { get; set; }
        
    }
}