using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using NHibernate.Transform;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00401 : DataRepository<LOMORM00401>, ILOMDAO00401
    {
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00401.SelectMaxId");
            LOMDTO00401 dto = query.UniqueResult<LOMDTO00401>();
            return dto.Id;
        }
        public bool UpdateFirstDueDate(string lno, string soucrBr, decimal curSamtAmt, DateTime currentSamtDate, DateTime firstDueDate, DateTime updatedDate, int updatedUserId)
        {
            IQuery query = Session.GetNamedQuery("LOMDAO00401.UpdateOutstandingBalFirstDueDate");
            query.SetString("lno", lno);
            query.SetString("soucrBr", soucrBr);
            query.SetDecimal("curSamtAmt", curSamtAmt);
            query.SetDateTime("currentSamtDate", currentSamtDate);
            query.SetDateTime("firstDueDate", firstDueDate);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public LOMDTO00401 GetLoansInterestLateFeeTODByRepayAmt_LCDecrease(string loanNo, decimal RepayAmount, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BindLoansRepayInformationByRepaymentAmount");
            if (DateTime.IsLeapYear(DateTime.Now.Year))
                query.SetInt32("DaysInyear", (366));
            else
                query.SetInt32("DaysInyear", (365));
            query.SetString("Lno", loanNo);
            query.SetDecimal("RepayAmount", RepayAmount);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00401)));
            return query.UniqueResult<LOMDTO00401>();
        }
        public LOMDTO00401 GetLoansInterestLateFeeTODByRepayAmt_LCIncrease(string loanNo, decimal RepayAmount,decimal rate, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BindLoansRepayInformationByRepaymentAmount_LC_Increase");
            if (DateTime.IsLeapYear(DateTime.Now.Year))
                query.SetInt32("DaysInyear", (366));
            else
                query.SetInt32("DaysInyear", (365));
            query.SetString("Lno", loanNo);
            query.SetDecimal("RepayAmount", RepayAmount);
            query.SetDecimal("rate", rate);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00401)));
            return query.UniqueResult<LOMDTO00401>();
        }

        //public bool UpdateOutstandingBalByRepaymentAmt(string lno, string acctno, string soucrBr, decimal curSamtAmt, DateTime currentSamtDate, decimal totalInt, DateTime intPaidDate,
        //                               decimal totalLateFee, DateTime latefeePaidDate, decimal tODAmt, DateTime tODPaidDate, DateTime firstDueDate, 
        //                               DateTime updatedDate, int updatedUserId)
        public bool UpdateOutstandingBalByRepaymentAmt(string lno, string acctno, string soucrBr, decimal curSamtAmt, decimal repayInt, DateTime intPaidDate, DateTime updatedDate, int updatedUserId)
        {
            IQuery query = Session.GetNamedQuery("LOMDAO00401.UpdateOutstandingBalByRepaymentAmt");
            query.SetString("lno", lno);
            query.SetString("acctno", acctno);
            query.SetString("soucrBr", soucrBr);
            query.SetDecimal("curSamtAmt", curSamtAmt);
            //query.SetDateTime("currentSamtDate", currentSamtDate);
            query.SetDecimal("repayInt", repayInt);
            query.SetDateTime("intPaidDate", intPaidDate);
            //query.SetDateTime("latefeePaidDate", latefeePaidDate);
            //query.SetDecimal("tODAmt", tODAmt);
            //query.SetDateTime("tODPaidDate", tODPaidDate);
            //query.SetDateTime("firstDueDate", firstDueDate);
            //string nplReleaseUser =  updatedUserId.ToString();
            //query.SetString("nplReleaseUser",nplReleaseUser);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }
        public IList<LOMDTO00401> SelectBusinessLoansDueForInterest(DateTime startDate,DateTime endDate,string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("LOMDAO00401.SelectBusinessLoansDueForInterest");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("sourceBranchCode", sourceBr);
            IList<LOMDTO00401> BLList = query.List<LOMDTO00401>();
            return BLList;
        }
    }
}
