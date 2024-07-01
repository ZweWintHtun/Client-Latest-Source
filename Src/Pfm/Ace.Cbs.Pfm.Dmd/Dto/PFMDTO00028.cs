using System;
using Ace.Windows.Core.DataModel;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Cledger DTO
    /// </summary>
    [Serializable]
    public class PFMDTO00028 : Supportfields<PFMDTO00028>
    {
        public PFMDTO00028() { }

        public PFMDTO00028(decimal totalBal, string cur)
        {
            this.CurrencyCode = cur;
            this.TotalBalance = totalBal;
        }

        public PFMDTO00028(string accountSign,DateTime closeDate, decimal minBal,decimal currentBal,decimal ovdLimit,string currencyCode,string sourcebranchcode)
        {
            this.AccountSign = accountSign;
            this.CloseDate = closeDate;
            this.MinimumBalance = minBal;
            this.CurrentBal = currentBal;
            this.OverdraftLimit = ovdLimit;
            this.CurrencyCode = currencyCode;
            this.SourceBranchCode = sourcebranchcode;
        }
        public PFMDTO00028(string accountNo)
        {
            this.AccountNo = accountNo;
        }

        public PFMDTO00028(decimal PrintLineNo)
        {
            this.PrintLineNo = PrintLineNo;
        }

        public PFMDTO00028(decimal minimumBalance, decimal currentBalance)
        {
            this.MinimumBalance = minimumBalance;
            this.CurrentBal = currentBalance;
        }

        public PFMDTO00028(string accountNo, string customerId)
        {
            this.AccountNo = accountNo;           
            this.CustomerId = customerId;
        }

        public PFMDTO00028(string accountNo,string accountSign,decimal overdraftLimit,decimal loansCount, decimal tempOverdraftLimit)
        {
            this.AccountNo = accountNo;

            this.AccountSign = accountSign;
            this.OverdraftLimit = overdraftLimit;
            this.TemporaryOverdraftLimit = tempOverdraftLimit;
            this.LoansCount = loansCount;
        }

        public PFMDTO00028(decimal minimumBalance, decimal currentBalance, string accountSign)
        {
            this.MinimumBalance = minimumBalance;
            this.CurrentBal = currentBalance;
            this.AccountSign = accountSign;
        }

        public PFMDTO00028(string accountNo, decimal currentBal, decimal overdraftLimit, decimal minimumBalance, Nullable<DateTime> overdraftDate, string accountSign,
                            decimal loansCount, decimal savingInterestRate, decimal transactionCount, decimal monthOpeningBalance, System.Nullable<DateTime> closeDate,
                            decimal printLineNo, string clinAcctno, System.Nullable<decimal> usedRate, System.Nullable<decimal> unUsedRate, string lastUserNo,
                            decimal temporaryOverdraftLimit, string customerId, string currencyCode, string sourceBranchCode)
        {
            this.AccountNo = accountNo;
            this.CurrentBal = currentBal;
            this.OverdraftLimit = overdraftLimit;
            this.MinimumBalance = minimumBalance;
            this.OverdraftDate = overdraftDate;
            this.AccountSign = accountSign;
            this.LoansCount = loansCount;
            this.SavingInterestRate = savingInterestRate;
            this.TransactionCount = transactionCount;
            this.MonthOpeningBalance = monthOpeningBalance;
            this.CloseDate = closeDate;
            this.PrintLineNo = printLineNo;
            this.CLINACCTNO = clinAcctno;
            this.UsedRate = usedRate;
            this.UnUsedRate = unUsedRate;
            this.LastUserNo =lastUserNo;
            this.TemporaryOverdraftLimit = temporaryOverdraftLimit;
            this.CustomerId = customerId;
            this.CurrencyCode = currencyCode;
            this.SourceBranchCode = sourceBranchCode;
        }

        public PFMDTO00028(string accountNo, decimal currentBal, decimal overdraftLimit, decimal minimumBalance, Nullable<DateTime> overdraftDate, string accountSign,
                            decimal loansCount, decimal savingInterestRate, decimal transactionCount, decimal monthOpeningBalance, System.Nullable<DateTime> closeDate,
                            decimal printLineNo, string clinAcctno, System.Nullable<decimal> usedRate, System.Nullable<decimal> unUsedRate,
                            string code, Nullable<DateTime> dateTime, string userNo, Nullable<DateTime> lastDate, string lastUserNo,
                            decimal temporaryOverdraftLimit, string customerId, string currencyCode, string sourceBranchCode)
        {
            this.AccountNo = accountNo;
            this.CurrentBal = currentBal;
            this.OverdraftLimit = overdraftLimit;
            this.MinimumBalance = minimumBalance;
            this.OverdraftDate = overdraftDate;
            this.AccountSign = accountSign;
            this.LoansCount = loansCount;
            this.SavingInterestRate = savingInterestRate;
            this.TransactionCount = transactionCount;
            this.MonthOpeningBalance = monthOpeningBalance;
            this.CloseDate = closeDate;
            this.PrintLineNo = printLineNo;
            this.CLINACCTNO = clinAcctno;
            this.UsedRate = usedRate;
            this.UnUsedRate = unUsedRate;
            this.Code = code;
            this.Date_Time = dateTime;
            this.UserNo = userNo;
            this.LastDate = lastDate;
            this.LastUserNo = lastUserNo;
            this.TemporaryOverdraftLimit = temporaryOverdraftLimit;
            this.CustomerId = customerId;
            this.CurrencyCode = currencyCode;
            this.SourceBranchCode = sourceBranchCode;
        }

        public PFMDTO00028(string accountSign, DateTime closeDate)
        {
            this.AccountSign = accountSign;
            this.CloseDate = closeDate;
        }


        public PFMDTO00028(string accountNo, decimal transactionCount, decimal cbal)
        {
            this.AccountNo = accountNo;
            this.TransactionCount = transactionCount;
            this.CurrentBal = cbal;
        }

        public PFMDTO00028(string accountNo, decimal cbal)
        {
            this.AccountNo = accountNo;
            this.CurrentBal = cbal;
        }

        public PFMDTO00028(string accountNo, decimal usedRate, decimal unUsedRate, decimal overDraftLimit, decimal curBal,string cur)
        {
            this.AccountNo = accountNo;
            this.UsedRate = usedRate;
            this.UnUsedRate = unUsedRate;
            this.OverdraftLimit = overDraftLimit;
            this.CurrentBal = curBal;
            this.CurrencyCode = cur;
        }


        public PFMDTO00028(string currency, decimal dobal,string acsign)
        {
            this.CurrencyCode = currency;
            this.DayOfBalance = dobal;
            this.AccountSign = acsign;
        }


        public PFMDTO00028(string custId, string acctno, decimal cbal, string acsign, System.Nullable<DateTime> closedate)
        {
            this.CustomerId = custId;
            this.AccountNo = acctno;
            this.CurrentBal = cbal;
            this.AccountSign = acsign;
            this.CloseDate = closedate;
        }

        public PFMDTO00028(string accountSign, string currencyCode, string sourceBranchCode, decimal currentBal, decimal overdraftLimit, decimal minimumBalance, Nullable<DateTime> overdraftDate, 
                          decimal loansCount, decimal savingInterestRate, decimal transactionCount, decimal monthOpeningBalance, System.Nullable<DateTime> closeDate,
                          decimal printLineNo, string clinAcctno, System.Nullable<decimal> usedRate, System.Nullable<decimal> unUsedRate,
                          string code, Nullable<DateTime> dateTime, string userNo, Nullable<DateTime> lastDate, string lastUserNo,
                          decimal temporaryOverdraftLimit, string customerId, string name, string nrc, string business)
        {
            this.AccountSign = accountSign;
            this.CurrencyCode = currencyCode;
            this.SourceBranchCode = sourceBranchCode;            
            this.CurrentBal = currentBal;
            this.OverdraftLimit = overdraftLimit;
            this.MinimumBalance = minimumBalance;
            this.OverdraftDate = overdraftDate;            
            this.LoansCount = loansCount;
            this.SavingInterestRate = savingInterestRate;
            this.TransactionCount = transactionCount;
            this.MonthOpeningBalance = monthOpeningBalance;
            this.CloseDate = closeDate;
            this.PrintLineNo = printLineNo;
            this.CLINACCTNO = clinAcctno;
            this.UsedRate = usedRate;
            this.UnUsedRate = unUsedRate;
            this.Code = code;
            this.Date_Time = dateTime;
            this.UserNo = userNo;
            this.LastDate = lastDate;
            this.LastUserNo = lastUserNo;
            this.TemporaryOverdraftLimit = temporaryOverdraftLimit;
            this.CustomerId = customerId;
            this.Name = name;
            this.NRC = nrc;
            this.Business = business;
        }

        //Primary Key
        public virtual string AccountNo { get; set; }
        public virtual decimal CurrentBal { get; set; }
        public virtual decimal OverdraftLimit { get; set; }
        public virtual decimal MinimumBalance { get; set; }
        public virtual Nullable<DateTime> OverdraftDate { get; set; }
        public virtual decimal DayOfBalance { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual decimal LoansAccount { get; set; }
        public virtual decimal SavingInterestRate { get; set; }
        public virtual decimal TransactionCount { get; set; }
        public virtual decimal MonthOpeningBalance { get; set; }
        public virtual System.Nullable<DateTime> CloseDate { get; set; }
        public virtual decimal PrintLineNo { get; set; }
        public virtual System.Nullable<decimal> UsedRate { get; set; }
        public virtual System.Nullable<decimal> UnUsedRate { get; set; }
        public virtual string Code { get; set; }
        public virtual System.Nullable<DateTime> Date_Time { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> LastDate { get; set; }
        public virtual string LastUserNo { get; set; }
        public virtual decimal TemporaryOverdraftLimit { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string CurrencyCode { get; set; }
        public virtual string CLINACCTNO { get; set; }
        public virtual decimal LoansCount { get; set; }
        public virtual decimal TotalBalance { get; set; }
        public virtual decimal GL { get; set; }
        public virtual decimal Sub { get; set; }
        public virtual decimal Diff { get; set; }
        public virtual string Staus { get; set; }
        // CustomerId Relation
        public virtual PFMDTO00001 Customer { get; set; }       

        //Source Branch Relation
        public virtual BranchDTO Branch { get; set; }

        //Currency Relation
        public virtual CurrencyDTO Currency { get; set; }

        public virtual string Name { get; set; }
        public virtual string NRC { get; set; }
        public virtual string Business { get; set; }


        public string AccountSignature { get; set; }
    }
}