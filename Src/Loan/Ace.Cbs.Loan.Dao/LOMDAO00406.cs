using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using NHibernate.Transform;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00406 : DataRepository<LOMORM00405>, ILOMDAO00406
    {
        [Transaction(TransactionPropagation.Required)]
        public string SaveBLDetailsVoucher(string Lno,string Acctno, decimal FirstAmt, DateTime FirstMDueDate, int DAYSINYEAR,
                                         int CreatedUserId,string username,string soucrBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_SaveBLDetails_Voucher");
                query.SetString("Lno", Lno);
                query.SetString("Acctno", Acctno);
                query.SetDecimal("FirstAmt", FirstAmt);
                query.SetDateTime("FirstMDueDate", FirstMDueDate);
                if (DateTime.IsLeapYear(DateTime.Now.Year))
                    query.SetDecimal("DAYSINYEAR", (366));
                else
                    query.SetDecimal("DAYSINYEAR", (365));
                query.SetInt32("CreatedUserId", CreatedUserId);
                query.SetString("UserName", username);
                query.SetString("SourceBr", soucrBr);
                query.SetString("Message", "0");
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        [Transaction(TransactionPropagation.Required)]
        public string UpdateBLDetailsLCDecrease(string Lno, string Acctno, decimal LimitChangeAmt, bool LimitChangeState,int LCTermNo,decimal interestForBeforeLC,
                                         int CreatedUserId, string username, string soucrBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_BL_UpdateBLDetails_LimitChangeDecrease");
                query.SetString("Lno", Lno);
                query.SetString("Acctno", Acctno);
                query.SetDecimal("LimitChangeAmt", LimitChangeAmt);
                query.SetBoolean("LimitChangeState", LimitChangeState);
                if (DateTime.IsLeapYear(DateTime.Now.Year))
                    query.SetDecimal("DAYSINYEAR", (366));
                else
                    query.SetDecimal("DAYSINYEAR", (365));
                query.SetInt32("LCTermNo", LCTermNo);
                query.SetDecimal("interestForBeforeLC", interestForBeforeLC);
                query.SetInt32("CreatedUserId", CreatedUserId);
                query.SetString("UserName", username);
                query.SetString("SourceBr", soucrBr);
                query.SetString("Message", "0");
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        [Transaction(TransactionPropagation.Required)]
        public string UpdateBLDetailsLCIncrease(string Lno, string Acctno, string Eno, decimal LimitChangeAmt, bool LimitChangeState, int LCTermNo,
                                                decimal ServiceCharges, decimal NewIntRate, decimal DocFee, decimal interestForBeforeLC,
                                         int CreatedUserId, string username, string soucrBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_BL_UpdateBLDetails_LimitChangeIncrease");
                query.SetString("Lno", Lno);
                query.SetString("Acctno", Acctno);
                query.SetString("Eno", Eno);
                query.SetDecimal("LimitChangeAmt", LimitChangeAmt);
                query.SetBoolean("LimitChangeState", LimitChangeState);
                if (DateTime.IsLeapYear(DateTime.Now.Year))
                    query.SetDecimal("DAYSINYEAR", (366));
                else
                    query.SetDecimal("DAYSINYEAR", (365));
                query.SetInt32("LCTermNo", LCTermNo);
                query.SetDecimal("ServiceCharges", ServiceCharges);
                query.SetDecimal("NewIntRate", NewIntRate);
                query.SetDecimal("DocFee", DocFee);
                query.SetDecimal("interestForBeforeLC", interestForBeforeLC);
                query.SetInt32("CreatedUserId", CreatedUserId);
                query.SetString("UserName", username);
                query.SetString("SourceBr", soucrBr);
                query.SetString("Message", "0");
                return query.UniqueResult().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        //For LF Auto Voucher
        [Transaction(TransactionPropagation.Required)]
        public string BusinessLoansLateFeesAutoPayVoucherProcess(string sourceBr, int createdUserId, string userName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_BL_LateFeesAutoPay_Voucher_ALLBLTOD");            
            query.SetString("sourceBr", sourceBr);
            query.SetInt32("createdUserId", createdUserId);
            query.SetString("userName", userName);
            query.SetTimeout(10000); // set transaction timeout values,by AAM(16_July_2018).
            return query.UniqueResult().ToString();
        }

        //For BL Repayment History Listing
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00406> BLAbsentHistoryListing(DateTime startDate, DateTime endDate, string acctno, string sourceBr)
        {
            IList<LOMDTO00406> result;
            IQuery query = this.Session.GetNamedQuery("SP_BLAbsentHistoryListing");
            query.SetDateTime("startDate", startDate);
            query.SetDateTime("endDate", endDate);
            query.SetString("acctNo", acctno);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00406)));
            result = query.List<LOMDTO00406>();
            return result;
        }
        //For BL Repayment History Enquiry
        [Transaction(TransactionPropagation.Required)]
        public IList<LOMDTO00406> BLAbsentHistory_Enquiry(string acctno, string sourceBr)
        {
            IList<LOMDTO00406> result;
            IQuery query = this.Session.GetNamedQuery("SP_BLAbsentHistory_Enquiry");
            query.SetString("acctNo", acctno);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00406)));
            result = query.List<LOMDTO00406>();
            return result;
        }

        //Added By AAM(10_Sep_2018)
        [Transaction(TransactionPropagation.Required)]
        public string CheckingCasesBLLimitChange(string blNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_CheckODLimitChange");
            query.SetString("blNo", blNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult().ToString();
        }
    }
}
