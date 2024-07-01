using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    /// <summary>
    /// OutstandingLoanBalance DTO
    /// </summary>
    [Serializable]
    public class LOMDTO00401 : EntityBase<LOMDTO00401>
    {
        public LOMDTO00401() { }

         public LOMDTO00401(int id) 
        {
            this.Id = id;
        }

        public LOMDTO00401(int id,string lno, string acctno, Nullable<decimal> currentSamt, Nullable<DateTime> currentSamtDate, Nullable<decimal> totalInt,
                           Nullable<decimal> lastInt, Nullable<DateTime> lastIntDate, Nullable<DateTime> IntPaidDate, Nullable<decimal> totalLateFee,
                           Nullable<decimal> lastLateFee,Nullable<DateTime> lastLateFeeDate,Nullable<DateTime> lastLastFeePaidDate,Nullable<decimal> todAmount,
                           Nullable<DateTime> todDate,Nullable<DateTime> todPaidDate,Nullable<DateTime> closeDate,Nullable<DateTime> firstDueDate,string uid,string sourcebr,string cur
                           ,bool active, byte[] tS, DateTime createdDate, int createdUserId,
                          System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId) 
        {
            this.Id = Id;
            this.LNo = lno;
            this.AccountNo = acctno;
            this.CurrentSanAmt = currentSamt;
            this.CurrentSanDate = currentSamtDate;
            this.TotalInt = totalInt;
            this.LastInt = lastInt;
            this.LastIntDate = lastIntDate ;
            this.IntPaidDate = IntPaidDate;
            this.TotalLateFee = totalLateFee;
            this.LastLateFee = lastLateFee;
            this.LastLatefeeDate = lastLateFeeDate;
            this.LatefeePaidDate = LatefeePaidDate;
            this.TODAmt = TODAmt;
            this.TODPaidDate = todPaidDate;
            this.CloseDate = closeDate ;
            this.FirstDueDate = firstDueDate;
            this.UniqueId = uid;
            this.SourceBranchCode = sourcebr;
            this.Currency = cur;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public LOMDTO00401(int id, string lno, string acctno, Nullable<decimal> currentSamt,  Nullable<decimal> totalInt,
                          Nullable<decimal> lastInt, Nullable<decimal> totalLateFee,
                          Nullable<decimal> lastLateFee, Nullable<decimal> todAmount,
                           string uid, string sourcebr, string cur
                          , DateTime createdDate, int createdUserId)
        {
            this.Id = Id;
            this.LNo = lno;
            this.AccountNo = acctno;
            this.CurrentSanAmt = currentSamt;
            this.TotalInt = totalInt;
            this.LastInt = lastInt;
            this.TotalLateFee = totalLateFee;
            this.LastLateFee = lastLateFee;
            this.TODAmt = TODAmt;
            this.UniqueId = uid;
            this.SourceBranchCode = sourcebr;
            this.Currency = cur;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
        }
        public LOMDTO00401(Nullable<decimal> interestOnSamt, Nullable<decimal> currentSanAmt,
                           Nullable<decimal> totalLateFee, Nullable<decimal> tODAmt, Nullable<DateTime> curSDate,string repayNo,
                           String loanGLCode, String resultCode)
        {
            this.InterestOnSamt = interestOnSamt;
            this.CurrentSanAmt = currentSanAmt;
            this.TotalLateFee = totalLateFee;
            this.TODAmt = tODAmt;
            this.CurrentSanDate = curSDate;
            this.RepayNo = repayNo;
            this.LoanGLCode = loanGLCode; //added by SHO [22-Nov-21] for Project loan type separate
            this.ResultCode = resultCode;
        }
        public LOMDTO00401(string lno, Nullable<DateTime> firstDueDate)
        {
            this.LNo= lno;
            this.FirstDueDate = firstDueDate;
        }
        public LOMDTO00401(DateTime sDate,DateTime eDate,string sourceBr)
        {
            this.startDate = sDate;
            this.endDate = eDate;
            this.SourceBranchCode = sourceBr;
        }
         public virtual int Id { get; set; }
         public virtual string LNo { get; set; }
         public virtual string AccountNo { get; set; }
         public virtual Nullable<decimal> CurrentSanAmt { get; set; }
         public virtual Nullable<DateTime> CurrentSanDate { get; set; }
         public virtual Nullable<decimal> TotalInt { get; set; }
         public virtual Nullable<decimal> LastInt { get; set; }
         public virtual Nullable<DateTime> LastIntDate { get; set; }
         public virtual Nullable<DateTime> IntPaidDate { get; set; }
         public virtual Nullable<decimal> TotalLateFee { get; set; }
         public virtual Nullable<decimal> LastLateFee { get; set; }
         public virtual Nullable<DateTime> LastLatefeeDate { get; set; }
         public virtual Nullable<DateTime> LatefeePaidDate { get; set; }
         public virtual Nullable<decimal> TODAmt { get; set; }
         public virtual Nullable<DateTime> TOD_Date { get; set; }
         public virtual Nullable<DateTime> TODPaidDate { get; set; }
         public virtual Nullable<DateTime> CloseDate { get; set; }
         public virtual Nullable<DateTime> FirstDueDate { get; set; }
         public virtual string UniqueId { get; set; }        
         public virtual string SourceBranchCode { get; set; }
         public virtual string Currency { get; set; }

         public virtual Nullable<decimal> InterestOnSamt { get; set; }
         public virtual string ResultCode { get; set; }
         public virtual Nullable<decimal> TOD { get; set; }
         public virtual string RepayNo { get; set; }

         public virtual DateTime startDate { get; set; }
         public virtual DateTime endDate { get; set; }
         public virtual int TermNo { get; set; }
        
         public virtual Nullable<decimal> IntRate { get; set; }
         public virtual string LoanGLCode { get; set; }//added by SHO [22-Nov-21] for Project loan type separate
         public virtual Nullable<decimal> Old_IntRate { get; set; }//Added by HMW (06/04/2023) 
         public virtual Nullable<decimal> New_IntRate { get; set; }//Added by HMW (06/04/2023) 
    }
}
