using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate.Transform;

namespace Ace.Cbs.Pfm.Dao
{
    /// <summary>
    /// Tlf Dao
    /// </summary>
    public class PFMDAO00054 : DataRepository<PFMORM00054>, IPFMDAO00054
    {
        #region Constant Properties
        const string LB = "LB";
        const string PG = "PG";
        const string PL = "PL";
        const string HP = "HP";
        const string GJ = "GJ";
        #endregion

        [Transaction(TransactionPropagation.Required)]
        public int SelectMaxId()
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectMaxId");
            PFMDTO00054 dto = query.UniqueResult<PFMDTO00054>();
            return dto.Id;
        }

        public IList<PFMDTO00054> SelectTlfInfoByEnoandDate(string entryNo, string tranCodecredit, string tranCodedebit, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTlfInfoByEnoandDate");
            query.SetString("entryNo", entryNo);
            query.SetString("debit", tranCodedebit);
            query.SetString("credit", tranCodecredit);
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00054> tlfdto = query.List<PFMDTO00054>();
            return tlfdto;
        }

        public PFMDTO00054 SelectTlfForReversal(string accountNo, string receiptNo, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTlfForReversal");
            query.SetString("accountNo", accountNo);
            query.SetString("receiptNo", receiptNo);
            query.SetString("sourceBr", sourceBranch);
            return query.List<PFMDTO00054>()[0];
        }

        public IList<PFMDTO00054> SelectForReversal(string eno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectForReversal");
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00054> dto = query.List<PFMDTO00054>();
            return dto;
        }

        public IList<PFMDTO00054> GetTlfInfoByEntryNo(string eno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTLFInfoByEno");
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            IList<PFMDTO00054> TLFInfo = query.List<PFMDTO00054>();

            return TLFInfo;
        }

        public PFMDTO00054 SelectTlfInfoByEnoandDate(string entryNo)
        {
            PFMDTO00054 ss = new PFMDTO00054();
            return ss;
        }

        [Transaction(TransactionPropagation.Required)]
        public void DeleteTlfByEno(string eno)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.DeleteTlfByEno");
            query.SetString("eno", eno);
            query.ExecuteUpdate();
        }


        /*Select From TLF. To Bind Grid View of Clearing Posting*/
        public IList<PFMDTO00054> SelectTlfInfoList(string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTlfForClearingPosting");
            query.SetString("datetime", DateTime.Now.ToString("yyyy/MM/dd"));
            query.SetString("status", "LCD");
            query.SetString("sourceBr", sourceBranch);
            string sql = this.GetSQLString(query.QueryString);
            IList<PFMDTO00054> TLFInfoList = query.List<PFMDTO00054>();
            return TLFInfoList;
        }

        /*Select From TLF*/
        public IList<PFMDTO00054> SelectTlfInfoByLGNo(string lgno , string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTlfInfoByLGNo");
            query.SetString("lgNo", lgno);
            query.SetString("sourceBr", sourceBranch);
            string sql = this.GetSQLString(query.QueryString);
            IList<PFMDTO00054> TLFInfoList = query.List<PFMDTO00054>();
            return TLFInfoList;
        }

        /*Select From TLF. To Save Debit Transaction.*/
        public PFMDTO00054 SelectTlfInfoListInService(string sourceBranch, string eno)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTlfForClearingPostingInService");
            query.SetString("datetime", DateTime.Now.ToString("yyyy/MM/dd"));
            query.SetString("eno", eno);
            query.SetString("status", "LCD");
            query.SetString("sourceBr", sourceBranch);

            string sql = this.GetSQLString(query.QueryString);

            return query.UniqueResult<PFMDTO00054>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateTlfByDRegisterNo(string oldDregisterNo, string newDregisterNo, string sourcebr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateDRegisterNo");
            query.SetString("newRegisterNo", newDregisterNo);
            query.SetString("oldReisterNo", oldDregisterNo);
            query.SetString("sourceBr", sourcebr);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateTlfRegisterNoToAddC(string registerNo, string newRegNo, string sourcebr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateDRegisterNoC");
            query.SetString("registerNo", registerNo);
            query.SetString("sourceBr", sourcebr);
            query.SetString("modifyRegisterNo", newRegNo);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public PFMDTO00054 GetTlfInfo(string entryNo, string sourceBr, string tranCode)  // for TCMSVE00007(to check eno)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTlfInfo");
            query.SetString("entryNo", entryNo);
            query.SetString("sourceBr", sourceBr);
            query.SetString("tranCode", tranCode);
            //PFMDTO00054 TLFInfo = query.UniqueResult<PFMDTO00054>();
            //return TLFInfo;
            return query.UniqueResult<PFMDTO00054>();

        }

        [Transaction(TransactionPropagation.Required)]  //Delivered Edit
        public bool UpdateTlf(string eno, decimal amount, decimal homeAmount, string paidBank, string otherBankChq, string narration, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateTlfDeliver");
            query.SetString("eno", eno);
            query.SetDecimal("amount", amount);
            query.SetDecimal("homeAmount", homeAmount);
            query.SetString("paidBank", paidBank);
            query.SetString("otherBankChq", otherBankChq);
            query.SetString("narration", narration);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool Delete(string eno, int updatedUserId, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.Delete");
            query.SetString("eno", eno);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00054> SelectByERegisterNo(string eRegisterNo, string sourceBr, DateTime Date)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTlfInfoByEregisterNoAndSourceBr");

            query.SetString("eRegisterNo", eRegisterNo);
            query.SetString("sourceBr", sourceBr);
            query.SetString("Date", Date.Date.ToString("yyyy/MM/dd"));
            return query.List<PFMDTO00054>();
        }

        public IList<PFMDTO00054> SelectByDRegisterNo(string dRegisterNo, string sourceBr, DateTime Date)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTlfInfoByDregisterNoAndSourceBr");
            query.SetString("dRegisterNo", dRegisterNo);
            query.SetString("sourceBr", sourceBr);
            query.SetString("Date", Date.Date.ToString("yyyy/MM/dd"));
            return query.List<PFMDTO00054>();
        }

        public IList<PFMDTO00054> SelectTLFInfoForReversalByEntryNo(string entryno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTLFInfoForReversalByEntryNo");
            query.SetString("eno", entryno);
            query.SetString("sourcebr", sourceBr);
            query.SetString("tranCode", "ACCINT%");
            return query.List<PFMDTO00054>();
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateTLFForSavingInterestWithdrawReversal(string orgneno, string orgntrancode, DateTime updateddate, int updateduserid,
            string eno, string transactioncode, string sourcecurrency, string sourcebr, byte[] ts)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateTLFForSavingInterestWithdrawReversal");
            query.SetString("orgneno", orgneno);
            query.SetString("orgntrancode", orgntrancode);
            query.SetDateTime("updatedDate", updateddate);
            query.SetInt32("updatedUserId", updateduserid);
            query.SetString("eno", eno);
            query.SetString("transactioncode", transactioncode);
            query.SetString("sourcecurrency", sourcecurrency);
            query.SetString("sourcebr", sourcebr);
            query.SetParameter("ts", ts);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateTlfByOrgnEno(string orgnEno, string orgnTranCode, string poNo, string sourceBranch, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateTlfByOrgnEno");
            query.SetString("orgnEno", orgnEno);
            query.SetString("orgnTranCode", orgnTranCode);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("poNo", poNo);
            query.SetString("sourceBranch", sourceBranch);
            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00054> SelectTlfDataByPONo(string poNo, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.SelectTlfDataByPONo");
            query.SetString("poNo", poNo);
            query.SetString("sourceBranch", sourceBranch);
            return query.List<PFMDTO00054>();
        }

        public bool UpdateTlfByRefVno(string registerNo, string refVno, string refType, string sourceBranch, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateTlfByRefVno");
            query.SetString("registerNo", registerNo);
            query.SetString("refVno", refVno);
            query.SetString("refType", refType);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("sourceBranch", sourceBranch);
            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00054> SelectTlfForPORefundReversal(string poNo, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTlfForPORefundReversal");
            query.SetString("poNo", poNo);
            query.SetString("sourceBranch", sourceBranch);
            query.SetString("transactionCode", "POR");
            return query.List<PFMDTO00054>();
        }

        public IList<PFMDTO00054> SelectTlfForPORegisterByTransferReversal(string poNo, string sourceBranch)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTlfForPORegisterByTransferReverse");
            query.SetString("poNo", poNo);
            query.SetString("sourceBranch", sourceBranch);
            return query.List<PFMDTO00054>();
        }


        public bool UpdateTlfByPONo(string poNo, string orgnEno, string sourceBranch, int updatedUserId, DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateTlfByPONo");
            query.SetString("poNo", poNo);
            query.SetString("transactionCode", "POR");
            query.SetString("orgnEno", orgnEno);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("sourceBranch", sourceBranch);
            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00054> GetNarrationByEno(string eno)
        {
            IQuery query = this.Session.GetNamedQuery("SelectNarrationByEno.DenoEdit");
            query.SetString("eno", eno);
            return query.List<PFMDTO00054>();
        }

        /*Select * From TLF. -> For Cash Payment Denomination Entry.*/
        public PFMDTO00054 SelectTlfDataByEntryNo(string sourceBranch, string eno)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTLFDataByEntryNo");
            query.SetString("datetime", DateTime.Now.ToString("yyyy/MM/dd"));
            query.SetString("eno", eno);
            query.SetString("status", "CD%");
            query.SetString("sourceBr", sourceBranch);
            //string sql = this.GetSQLString(query.QueryString);
            return query.UniqueResult<PFMDTO00054>();
        }

        /*Select * From TLF. -> For Cash Payment Denomination Entry.*/
        public IList<PFMDTO00054> SelectTlfListDataByEntryNo(string sourceBranch, string eno)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTLFDataByEntryNo");
            query.SetString("datetime", DateTime.Now.ToString("yyyy/MM/dd"));
            query.SetString("eno", eno);
            query.SetString("status", "CD%");
            query.SetString("sourceBr", sourceBranch);
            //string sql = this.GetSQLString(query.QueryString);
            return query.List<PFMDTO00054>();
        }

        /// <summary>
        /// Added by ASDA
        /// </summary>
        /// <param name="eno"></param>
        /// <param name="settlementDate"></param>
        /// <returns></returns>
        public IList<PFMDTO00054> GetTlfInfoForWithdrawEntry(string eno, DateTime settlementDate)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.SelectTlfInfoForWithdrawEntry");
            query.SetString("entryNo", eno);
            query.SetString("settlementDate", settlementDate.ToString("yyyy/MM/dd"));
            //string sql = this.GetSQLString(query.QueryString);
            return query.List<PFMDTO00054>();
        }

        /// <summary>
        /// Added by ASDA
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool UpdateTlfHomeAmt(int id, decimal amount)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.UpdateTlfHomeAmt");
            query.SetInt32("id", id);
            query.SetDecimal("amount", amount);
            //string sql = this.GetSQLString(query.QueryString);
            return query.ExecuteUpdate() > 0;
        }

        /// <summary>
        /// Added by ASDA
        /// Updated by HPP
        /// </summary>
        /// <param name="loanNo">Loan No</param>
        /// <returns>boolean</returns>        
        public bool UpdateCloseDateForLoan(string loanNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateCloseDateForLoan");
            query.SetDateTime("closeDate", DateTime.Now);
            query.SetString("loanNo", loanNo);
            return query.ExecuteUpdate() > 0;
        }

        /// <summary>
        /// Added by ASDA
        /// Updated by HPP
        /// </summary>
        /// <param name="loanNo">Loan No</param>
        /// <returns>boolean</returns>        
        public bool UpdateCloseDateForLI(string loanNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateCloseDateForLI");
            query.SetDateTime("closeDate", DateTime.Now);
            query.SetString("loanNo", loanNo);
            return query.ExecuteUpdate() > 0;
        }

        public bool UpdateCloseDateForOI(string loanNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateCloseDateForOI");
            query.SetDateTime("closeDate", DateTime.Now);
            query.SetString("loanNo", loanNo);
            return query.ExecuteUpdate() > 0;
        }
        /// <summary>
        /// Added by ASDA
        /// Updated by HPP
        /// </summary>
        /// <param name="loanNo">Loan No</param>
        /// <returns>boolean</returns>        
        public bool UpdateCloseDateForLMT9900(string loanNo)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00054.UpdateCloseDateForLMT9900");
            query.SetDateTime("closeDate", DateTime.Now);
            query.SetString("loanNo", loanNo);
            return query.ExecuteUpdate() > 0;
        }

        /// <summary>
        /// Update CloseDate By LoanType
        /// Added by HPP
        /// </summary>
        /// <param name="loanType">Loan Type</param>
        /// <param name="loanNo">Loan No. from Service Layer</param>
        /// <returns>boolean</returns>
        public bool UpdateCloseDateByLoanType(string loanType, string loanNo)
        {
            bool result = false;
            switch (loanType)
            {
                case LB:
                    result = UpdateCloseDateForCustomLoanType("PFMDAO00054.UpdateCloseDateForLand_Bld", loanNo);
                    break;
                case PG:
                    result = UpdateCloseDateForCustomLoanType("PFMDAO00054.UpdateCloseDateForPer_Guan", loanNo);
                    break;
                case PL:
                    result = UpdateCloseDateForCustomLoanType("PFMDAO00054.UpdateCloseDateForPledge", loanNo);
                    break;
                case HP:
                    result = UpdateCloseDateForCustomLoanType("PFMDAO00054.UpdateCloseDateForHypo", loanNo);
                    break;
                case GJ:
                    result = (UpdateCloseDateForCustomLoanType("PFMDAO00054.UpdateCloseDateForGJKind", loanNo) == UpdateCloseDateForCustomLoanType("PFMDAO00054.UpdateCloseDateForGJType", loanNo));
                    break;
            }
            return result;
        }

        /// <summary>
        /// Update CloseDate by Custom LoanType
        /// Added by HPP
        /// </summary>
        /// <param name="queryName">NHibernate QueryString Name</param>
        /// <param name="loanNo">Loan No. from Service Layer</param>
        /// <returns>boolean</returns>
        public bool UpdateCloseDateForCustomLoanType(string queryName, string loanNo)
        {
            IQuery query = this.Session.GetNamedQuery(queryName);
            query.SetDateTime("closeDate", DateTime.Now);
            query.SetString("loanNo", loanNo);
            return query.ExecuteUpdate() > 0;
        }

        public bool UpdateTlfByLnoAndRepayNo(string loanNo, string eno, string sourceBr, int updatedUserID)
        {
            IQuery query = this.Session.GetNamedQuery("TLFDAO.UpdateTlfByLnoAndRepayNo");
            query.SetString("repayNo", eno);
            query.SetString("loanNo", loanNo);
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserID);
            string sql = this.GetSQLString(query.QueryString);
            return query.ExecuteUpdate() > 0;
        }

        /// <summary>
        /// Multiple Withdraw and Deposit Reversal Added By ZMS
        /// </summary>
        /// <param name="eno"></param>
        /// <param name="sourceBr"></param>
        /// <returns></returns>
        public PFMDTO00054 SelectGroupAmountForMultipleReversal(string groupNo, string sourceBr)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SP_GetGroupAmount_MultipleWithdrawAndDepositReversal");
                query.SetString("groupNo", groupNo);
                query.SetString("sourceBr", sourceBr);

                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00054)));
                PFMDTO00054 dto = query.UniqueResult<PFMDTO00054>();
                return dto;
            }
            catch { throw; }
        }

        //Added By AAM (23-Jan-2018)
        public string Check_EntryNo_Individual_DepWdwReverse(string eno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Check_EntryNo_Individual_DepWdwReverse");
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            query.SetString("ERRMESSAGE", string.Empty);
            
            return query.UniqueResult().ToString();
        }

        //Added By HMW (29-May-2019) : Reversal Validation For Seperating EOD
        public string Check_EntryNo_Multiple_DepWdwReverse(string groupNo, string eno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_Check_EntryNo_Multiple_DepWdwReverse");
            query.SetString("groupNo", groupNo);
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);
            query.SetString("ERRMESSAGE", string.Empty);

            return query.UniqueResult().ToString();
        }

        public IList<PFMDTO00054> GetTransactionInfoByEnoANDGroupNo(string groupNo, string eno, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SP_GetTransactionInfoByEnoANDGroupNo");
            query.SetString("groupNo", groupNo);
            query.SetString("eno", eno);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00054)));
            IList<PFMDTO00054> TLFInfo = query.List<PFMDTO00054>();
            return TLFInfo;
        }

    }
}