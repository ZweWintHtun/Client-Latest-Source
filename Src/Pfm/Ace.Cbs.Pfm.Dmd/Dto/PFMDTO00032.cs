using System;
using System.Collections.Generic;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //FReceipt DTO
    [Serializable] 
    public class PFMDTO00032 : EntityBase<PFMDTO00032>
    {
        public PFMDTO00032() { }


        public PFMDTO00032(decimal accruedInterest)
        {
            this.AccuredInterest = accruedInterest;
        }

        public PFMDTO00032(string receiptNo)
        {
            this.ReceiptNo = receiptNo;
        }

        public PFMDTO00032(string accountNo, string receiptNo)
        {
            this.AccountNo = accountNo;
            this.ReceiptNo = receiptNo;
        }

        public PFMDTO00032(string receiptNo, decimal amount, decimal duration, string currencyCode)
        {
            this.ReceiptNo = receiptNo;
            this.Amount = amount;
            this.Duration = duration;
            this.CurrencyCode = currencyCode;
        }


        public PFMDTO00032(decimal amount, decimal duration, DateTime rDate, string currencyCode)
        {
            this.Amount = amount;
            this.Duration = duration;
            this.RDate = rDate;
            this.CurrencyCode = currencyCode;
        }

        public PFMDTO00032(DateTime withdrawDate, int updatedUserId, DateTime updatedDate)
        {
            this.WithdrawDate = withdrawDate;
            this.UpdatedUserId = updatedUserId;
            this.UpdatedDate = updatedDate;
        }

        public PFMDTO00032(string accountNo, string receiptNo, DateTime lastInterestDate, DateTime WithdrawDate)
        {
            this.AccountNo = accountNo;
            this.ReceiptNo = receiptNo;
            this.LastInterestDate = lastInterestDate;
            this.WithdrawDate = WithdrawDate;
        }
        public PFMDTO00032(string receiptNo, decimal amount, decimal duration, string currencyCode, DateTime lastInterestDate, decimal accrued,string accuredStatus, decimal interestRate)
        {
            this.ReceiptNo = receiptNo;
            this.Amount = amount;
            this.Duration = duration;
            this.CurrencyCode = currencyCode;
            this.LastInterestDate = lastInterestDate;
            this.Accrued = accrued;
            this.AccuredStatus = accuredStatus;
            this.InterestRate = interestRate;
        }
        
        public PFMDTO00032(string receiptNo,string acSign, decimal amount, decimal duration, string currencyCode, DateTime lastInterestDate,DateTime withdrawalDate, string accuredStatus, decimal interestRate,string sourceBranchCode)
        {
            this.ReceiptNo = receiptNo;
            this.AccountSign = acSign;
            this.Amount = amount;
            this.Duration = duration;
            this.CurrencyCode = currencyCode;
            this.LastInterestDate = lastInterestDate;
            this.WithdrawDate = withdrawalDate;
            this.AccuredStatus = accuredStatus;
            this.InterestRate = interestRate;
            this.SourceBranchCode = sourceBranchCode;
        }
        public PFMDTO00032(string receiptNo, string acSign, decimal amount, decimal duration, string currencyCode, DateTime lastInterestDate, DateTime withdrawalDate, string accuredStatus, decimal interestRate, string sourceBranchCode, string toAccountNo)
        {
            this.ReceiptNo = receiptNo;
            this.AccountSign = acSign;
            this.Amount = amount;
            this.Duration = duration;
            this.CurrencyCode = currencyCode;
            this.LastInterestDate = lastInterestDate;
            this.WithdrawDate = withdrawalDate;
            this.AccuredStatus = accuredStatus;
            this.InterestRate = interestRate;
            this.SourceBranchCode = sourceBranchCode;
            this.ToAccountNo = toAccountNo;
        }
       
        public PFMDTO00032(string acctNo, string receiptNo, decimal amount, decimal duration, DateTime rDate, DateTime wDate, DateTime lastIntDate, decimal budEndAcct, decimal accrued, string acSign, decimal intRate, string accuredStatus, string toAcctNo, string cur)
        {
            this.AccountNo = acctNo;
            this.ReceiptNo = receiptNo;
            this.Amount = amount;
            this.Duration = duration;
            this.RDate = rDate;
            this.WithdrawDate = wDate;
            this.LastInterestDate = lastIntDate;
            this.BudgetEndAccount = budEndAcct;
            this.Accrued = accrued;
            this.AccountSign = acSign;
            this.InterestRate = intRate;
            this.AccuredStatus = accuredStatus;
            this.ToAccountNo = toAcctNo;
            this.CurrencyCode = cur;
        }

        public PFMDTO00032(string acctNo, string receiptNo, decimal amount, decimal duration, DateTime rDate, DateTime wDate, DateTime lastIntDate, decimal budEndAcct, decimal accrued, string acSign, decimal intRate, string accuredStatus, string toAcctNo, string cur, decimal debitAccrued)
        {
            this.AccountNo = acctNo;
            this.ReceiptNo = receiptNo;
            this.Amount = amount;
            this.Duration = duration;
            this.RDate = rDate;
            this.WithdrawDate = wDate;
            this.LastInterestDate = lastIntDate;
            this.BudgetEndAccount = budEndAcct;
            this.Accrued = accrued;
            this.AccountSign = acSign;
            this.InterestRate = intRate;
            this.AccuredStatus = accuredStatus;
            this.ToAccountNo = toAcctNo;
            this.CurrencyCode = cur;
            this.DebitAccrued = debitAccrued;
        }

        //Coming Accrue      //ASDA
        public PFMDTO00032(string acctNo, string name,string receiptNo, decimal amount, decimal duration, DateTime wDate, DateTime lastIntDate, decimal intRate, string accuredStatus,string toAcctNo, DateTime rDate,string cur)
        {
            this.AccountNo = acctNo;
            this.Name = name;
            this.ReceiptNo = receiptNo;
            this.Amount = amount;
            this.Duration = duration;
            this.WithdrawDate = wDate;
            this.LastInterestDate = lastIntDate;
            this.InterestRate = intRate;
            this.AccuredStatus = accuredStatus;
            this.ToAccountNo = toAcctNo;
            this.RDate = rDate;
            this.CurrencyCode = cur;            
        }

        //fixed prev interest
        public PFMDTO00032(int id,string acctno,string receiptNo,decimal amount,decimal duration,DateTime wdate,DateTime lastintdate,int prntime,decimal lastprnbal,decimal budendacc,decimal budendtax,decimal accured,decimal draccured,string aperson,string acsign,decimal intrate,string accurstatus,string fstrecepitno,string toaccno,DateTime rdate,string userno,string sourcebr,string cur,DateTime lastaccurdate,bool active,DateTime createdate,int createId,DateTime updateDate,int updateId) 
        {
            this.Id = id;
            this.AccountNo = acctno;
            this.ReceiptNo = receiptNo;
            this.Amount = amount;
            this.Duration = duration;
            this.WithdrawDate = wdate;
            this.LastInterestDate = lastintdate;
            this.PrintTime = prntime;
            this.LastPrintBalance = lastprnbal;
            this.BudgetEndAccount = budendacc;
            this.BudgetEndTax = budendtax;
            this.Accrued = accured;
            this.DebitAccrued = draccured;
            this.AuthorizedPerson = aperson;
            this.AccountSign = acsign;
            this.InterestRate = intrate;
            this.AccuredStatus = accurstatus;
            this.FirstReceiptNo = fstrecepitno;
            this.ToAccountNo = toaccno;
            this.RDate = rdate;
            this.UserNo = userno;
            this.SourceBranchCode = sourcebr;
            this.CurrencyCode = cur;
            this.LastAccruedDate = lastaccurdate;
            this.Active = active;
            this.CreatedDate = createdate;
            this.CreatedUserId = createId;
            this.UpdatedDate = updateDate;
            this.UpdatedUserId = updateId;

        }



        public PFMDTO00032(string acctno, string rNo, DateTime rDate, string desp, DateTime mDate, decimal amount, string renstat, string toaccountno)
       {
         this.AccountNo = acctno;
         this.ReceiptNo = rNo;
         this.RDate = rDate;
         this.Desp = desp;
         this.MatureDate = mDate;
        this.Amount = amount;
        this.Renstat = renstat;
        this.ToAccountNo = toaccountno;
        
       }

        public virtual string ReceiptNo { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual decimal Duration { get; set; }
        public virtual System.Nullable<DateTime> WithdrawDate { get; set; }
        public virtual System.Nullable<DateTime> LastInterestDate { get; set; }
        public virtual int PrintTime { get; set; }
        public virtual decimal LastPrintBalance { get; set; }
        public virtual decimal BudgetEndAccount { get; set; }
        public virtual decimal BudgetEndTax { get; set; }
        public virtual decimal Accrued { get; set; }
        public virtual decimal DebitAccrued { get; set; }
        public virtual string AuthorizedPerson { get; set; }
        public virtual string AccountSign { get; set; }
        public virtual decimal InterestRate { get; set; }
        public virtual string AccuredStatus { get; set; }
        public virtual string FirstReceiptNo { get; set; }
        public virtual string JoinType { get; set; }
        public virtual string UserNo { get; set; }
        public virtual System.Nullable<DateTime> RDate { get; set; }
        public virtual string Status { get; set; }

        public virtual string CurrencyCode { get; set; } 
        public virtual string SourceBranchCode { get; set; }
        public virtual string ToAccountNo { get; set; }
        public virtual string AccountNo { get; set; }
        public virtual bool AutoRenewal { get; set; }
        public bool IsMainMenu { get; set; }
        public bool IsReversalTransaction { get; set; }

        public virtual string DebitAccountNo { get; set; }
        public virtual string CreditAccountNo { get; set; }
        public virtual string ChequeNo { get; set; }
        public virtual decimal AccuredInterest { get; set; }
        public virtual string Nrc { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<PFMDTO00001> CustomerInfo { get; set; }
        public virtual string OldReceiptNo { get; set; }

        public virtual string TownshipCode { get; set; }
        public virtual string TownshipDescription { get; set; }
        public virtual string DurationTime { get; set; }
        public virtual string Address { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual string Description { get; set; }
        public virtual System.Nullable<DateTime> LastAccruedDate { get; set; }
        public virtual string Desp { get; set; }
        public virtual DateTime MatureDate { get; set; }
        public virtual string Renstat { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual System.Nullable<decimal> ClosingBalance { get; set; }
        
    }
}