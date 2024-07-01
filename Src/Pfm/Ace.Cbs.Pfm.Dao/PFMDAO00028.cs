using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System.Collections.Generic;
using NHibernate.Criterion;
using System.Linq;
using NHibernate.Transform;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Pfm.Dao
{
    // Cledger dao 
    public class PFMDAO00028 : DataRepository<PFMORM00028>, IPFMDAO00028
    {
        #region IPFMDAO00028 Members

        public bool IsValidCustomerId(string customerID)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.IsValidCustomerId");
            query.SetString("id", customerID);
            PFMDTO00028 cledgerDTO = query.UniqueResult<PFMDTO00028>();
            return cledgerDTO == null ? false : true;
        }

        public PFMDTO00028 SelectACSignByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectACSignByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.UniqueResult<PFMDTO00028>();
            
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateForClosing(string accountNo, System.Nullable<DateTime> closeDate, decimal currentBalance, decimal minimumBalance, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateForClosing");
            query.SetString("accountNo", accountNo);
            query.SetDateTime("closeDate", closeDate.HasValue ? closeDate.Value : DateTime.Now);            
            query.SetDecimal("currentBalance", currentBalance);
            query.SetDecimal("minimumBalance", minimumBalance);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public PFMDTO00028 SelectMinimumBalanceByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectMinimumBalanceByAccountNo");
            query.SetString("accountNo", accountNo);
            string sql = this.GetSQLString(query.QueryString);
            return query.UniqueResult<PFMDTO00028>();
        }

        //Select AccountNo For Saving Account
        public PFMDTO00028 SelectAccountNoByCustomerId(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectAccountNoByCustomerId");
            query.SetString("accountNo", accountNo);                     
            return query.UniqueResult<PFMDTO00028>(); 
        }

        //Update PrintLine Number.
        [Transaction(TransactionPropagation.Required)]
        public bool UpdatePrintLine(string accountNo,int lineNo,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdatePrintLineNo");
            query.SetString("accountNo", accountNo);
            query.SetInt32("lineNo", lineNo);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public int GetPrintLineNumberByAccountNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectPrintLineNo");
            query.SetString("accountNo", accountNo);
            int val = Convert.ToInt32(query.UniqueResult<PFMDTO00028>().PrintLineNo);
            return val;
        }

        public PFMDTO00028 GetLoansInformation(string accountNo, string sourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("SelectLoanInfoFromCledgerByAccountNo");
            query.SetAnsiString("accountNo", accountNo);
            query.SetString("sourcebranch", sourceBranchCode);
            //return query.UniqueResult<PFMDTO00028>();
            PFMDTO00028 dto = query.UniqueResult<PFMDTO00028>();
            return dto == null ? null : query.UniqueResult<PFMDTO00028>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCurrentBalance(string accountNo, decimal currentBalance, decimal tCount, int updatedUserId,string updatedUserNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateCurrentBalance");
            query.SetString("accountNo", accountNo);
            query.SetDecimal("currentBalance", currentBalance);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("updatedUserNo",updatedUserNo);
            query.SetDecimal("transactionCount", tCount);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateMinBal(string accountNo, decimal minBal, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateMinimumBalance");
            query.SetString("accountNo", accountNo);
            query.SetDecimal("minBal", minBal);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.ExecuteUpdate();
        }


        public IList<PFMDTO00028> SelectCbalTCount(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectCbalTCount");
            query.SetString("SourceBranchCode", SourceBranchCode);
            IList<PFMDTO00028> res = query.List<PFMDTO00028>();
            return res;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateDOBal(string branchCode, DateTime updatedDate, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateDOBal");
            query.SetString("branchCode", branchCode);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate()>0;
        }

        [Transaction(TransactionPropagation.Required)]
        public void  UpdateTcount(string SourceBranchCode,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateTcount");
            query.SetString("SourceBranchCode", SourceBranchCode);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.ExecuteUpdate();
        }

        public IList<string> SelectCurrencyByACSign()           //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectCurrency");
            return query.List<string>();
        }

        [Transaction(TransactionPropagation.Required)]
        public void UpdateCBal(decimal cBal, string accountNo, int updatedUserId)               //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateCbal");
            query.SetDecimal("cBal", cBal);
            query.SetString("accountNo", accountNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.ExecuteUpdate();
        }

        public IList<PFMDTO00028> SelectTotalBalanceByCurrency(string sourceBr)                 //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectTotalBalanceByCurrency");
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00028> List = query.List<PFMDTO00028>();
            return List;
        }

        public IList<PFMDTO00028> SelectForOverDraftPosting(string sourceBr)                    //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectForOverDraftPosting");
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00028> List = query.List<PFMDTO00028>();
            return List;
        }

        #endregion


        public IList<PFMDTO00028> SelectSumDoBal(string sourcebr, string accountsign)
        {
            
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectSumDayOfBalance");           
            query.SetString("sourcebr", sourcebr);
            query.SetString("accountsign", accountsign + '%');
            IList<PFMDTO00028> cledger =  query.List<PFMDTO00028>();
            return cledger;           
        }

        public IList<PFMDTO00028> SelectSumDoBalForOD(string accountsign, string sourcebr)
        {
            
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectSumDayOfBalanceForOD");
            query.SetString("accountsign", accountsign);
            query.SetString("sourcebr", sourcebr);

            IList<PFMDTO00028> cledger = query.List<PFMDTO00028>();

            return cledger;
        }

        public PFMDTO00028 SelectByAccountNoAndSourceBr(string accountno,string sourcebr)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectByAccountNoAndSourceBr");
            query.SetString("accountNo", accountno);
            query.SetString("sourcebr", sourcebr);
           PFMDTO00028 cledger = query.UniqueResult<PFMDTO00028>();
            return cledger;
 
        }


        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCBalForPORefundReversal(string accountNo, decimal currentBalance, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateCBalForPORefundReversal");
            query.SetString("accountNo", accountNo);
            query.SetDecimal("cBal", currentBalance);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("userNo", updatedUserId.ToString());
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateTransactionCount(string accountNo, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateTransactionCount");
            query.SetString("accountNo", accountNo);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("userNo", updatedUserId.ToString());
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdatePrnLineNoByAccountNo(string accountNo, int updatedUserId,int lineNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdatePrnLineNoByAccountNo");
            query.SetInt32("lineNo", lineNo);
            query.SetString("accountNo", accountNo);
            query.SetInt32("updatedUserId", updatedUserId);         
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]   //LOMSVE00012  (OD Change Limit Entry)
        public bool UpdateOVDLimitInCledger(decimal oVDLimit, string sourceBranchCode, string accountNo,int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateOVDLimitInCledger");
            query.SetDecimal("oVDLimit", oVDLimit);
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetString("accountNo", accountNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);            
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]   //LOMSVE00011  (Loan Registration Entry) For Loan
        public bool UpdateLoansCountForLoan( string sourceBranchCode, string accountNo, int updatedUserId,DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateLoansCountForLoan");
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetString("accountNo", accountNo);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]   //LOMSVE00011  (Loan Registration Entry) For Loan
        public bool UpdateLoansCountForCledger(string sourceBranchCode, string accountNo, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateLoansCountForCledger");
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetString("accountNo", accountNo);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }



        [Transaction(TransactionPropagation.Required)]   //LOMSVE00011  (Loan Registration Entry) For OD 
        public bool UpdateLoansCountForOD(string sourceBranchCode, string accountNo, int updatedUserId, DateTime updatedDate,decimal rate,decimal amount)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateLoansCountForOD");
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetString("accountNo", accountNo);
            query.SetDecimal("usedrate", rate);
            query.SetDecimal("samount", amount);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]   //LOMSVE00016  (Legal Case)
        public PFMDTO00033 SelectAccountInfoFromCledgerAndBal(string BudYear, DateTime endOfMonth, string accountNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.SelectAccountInfoFromCledgerAndBal");           
            query.SetString("budget", BudYear);
            query.SetDateTime("endOfMonth", endOfMonth);
           // query.SetString("acSign", "C%");
            query.SetString("accountNo", accountNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<PFMDTO00033>();
        }

        [Transaction(TransactionPropagation.Required)]   //LOMSVE00027  (Legal Loan Repayment Entry)
        public bool UpdateCledgerCBalByAccountNo(string accountNo,decimal cledgerCBal, string sourceBr, int workStationId, int currentUserId)
        {
            //Getting System Startup Date
            TCMDTO00001 startDTO = CXServiceWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));

            IQuery query = this.Session.GetNamedQuery("PFMDAO00028.UpdateCledgerCBalByAccountNo");            
            query.SetDecimal("cledgerCBal", cledgerCBal);
            query.SetString("userNo", workStationId.ToString());
            query.SetString("accountNo", accountNo);
            query.SetString("sourceBr", sourceBr);            
            query.SetDateTime("updatedDate", Convert.ToDateTime(startDTO.Date.ToShortDateString()));
            query.SetInt32("updatedUserId", currentUserId);
            return query.ExecuteUpdate() > 0;
        }
        public IList<PFMDTO00028> SelectAccountInfoFromCledgerForPLContractPrinting(string accountNo, string sourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("SP_SelectAccountInfoFromCledgerForPLContractPrinting");
            query.SetString("acctNo", accountNo);
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00028)));
            return query.List<PFMDTO00028>();
        }
    }
}