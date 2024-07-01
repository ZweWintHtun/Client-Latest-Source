//----------------------------------------------------------------------
// <copyright file="TLMDAO00018.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-07-08</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using System;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using System.Collections;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Spring.Stereotype;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using NHibernate.Transform;
using System.Data.SqlClient;using System.Data;


namespace Ace.Cbs.Tel.Dao
{
    /// <summary>
    /// Loan DAO
    /// </summary>
    public class TLMDAO00018 : DataRepository<TLMORM00018>, ITLMDAO00018
    {
        public bool UpdateLoanInfoByLoanNoAndSourceBr(TLMDTO00018 loanDto)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00018.UpdateLoanInfoByLoanNoAndSourceBr");
            query.SetString("assessor", loanDto.Assessor);
            query.SetString("lawer", loanDto.Lawer);
            query.SetString("btype", loanDto.BType);
            query.SetDateTime("edate", Convert.ToDateTime(loanDto.ExpireDate));      
            query.SetString("lno", loanDto.Lno);
            query.SetDecimal("rate", String.IsNullOrEmpty(loanDto.IntRate.ToString()) ? 0 : Convert.ToDecimal(loanDto.IntRate));
            query.SetDecimal("unUsedRate", String.IsNullOrEmpty(loanDto.UnUsedRate.ToString()) ? 0 : Convert.ToDecimal(loanDto.UnUsedRate));
            query.SetDecimal("useOverRate", String.IsNullOrEmpty(loanDto.UsedOverRate.ToString()) ? 0 : Convert.ToDecimal(loanDto.UsedOverRate));
            query.SetString("sourcebr", loanDto.SourceBranchCode);
            query.SetDateTime("updatedDate", loanDto.CreatedDate);
            query.SetInt32("updatedUserId", loanDto.CreatedUserId);
            query.SetInt32("reversalStatus", loanDto.ReversalStatus);
            return query.ExecuteUpdate() > 0;
        }

        public bool UpdateLoanForLoanVoucherByLoanNoAndSourceBr(TLMDTO00018 loanDto)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00018.UpdateLoanForLoanVoucherByLoanNoAndSourceBr");
            query.SetBoolean("vouchered", loanDto.Vouchered);
            query.SetDateTime("vDate", Convert.ToDateTime(loanDto.VoucherDate));
            query.SetDecimal("samt", Convert.ToDecimal(loanDto.SAmount));
            query.SetBoolean("partial", Convert.ToBoolean(loanDto.Partial));
            query.SetString("lno", loanDto.Lno);
            query.SetDecimal("serviceCharges", Convert.ToDecimal(loanDto.ServiceCharges));
            query.SetString("sourcebr", loanDto.SourceBranchCode);
            query.SetDateTime("updatedDate", loanDto.CreatedDate);
            query.SetInt32("updatedUserId", loanDto.CreatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public TLMDTO00018 SelectLoanAccountInfo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("LOMSVE00011.SelectLoanAccountInfo");
            query.SetString("accountNo", accountNo);
            return query.UniqueResult<TLMDTO00018>();
        }

        public TLMDTO00018 GetExpireAmount(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMSVR00042.SelectExpireAmountByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.UniqueResult<TLMDTO00018>();
        }

        //Added by HWKO (07-Jun-2017)
        public IList<TLMDTO00018> GetExpireAmountByAcctNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMSVR00042.SelectExpireAmountByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.List<TLMDTO00018>();
        }

        //Added by HWKO (07-Jun-2017)
        public IList<TLMDTO00018> GetOverdraftExpireAmountByAcctNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMSVR00042.SelectOverdraftExpireAmountByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.List<TLMDTO00018>();
        }

        //Added by HWKO (07-Jun-2017)
        public IList<TLMDTO00018> GetLoansExpireAmountByAcctNo(string accountNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMSVR00042.SelectLoansExpireAmountByAccountNo");
            query.SetString("accountNo", accountNo);
            return query.List<TLMDTO00018>();
            //update
        }

        public TLMDTO00018 SelectForOverDraftPosting(string accountNo)             //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00018.SelectForOverDraftPosting");
            query.SetString("accountNo", accountNo);
            return query.UniqueResult<TLMDTO00018>();
        }

        public IList<TLMDTO00018> SelectLoansByCloseDate(string sourceBr)                  //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00018.SelectLoansByCloseDate");
            query.SetString("sourceBr", sourceBr);
            return query.List<TLMDTO00018>();
        }

        public IList<TLMDTO00018> SelectAll(string SourceBranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00018.SelectAll");
            query.SetString("SourceBranchCode", SourceBranchCode);
            return query.List<TLMDTO00018>();

        }

        public bool UpdateLastIntDate(string lno,int updatedUserId)                                   //NLKK
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00018.UpdateLastIntDate");
            query.SetDateTime("lastIntDate", DateTime.Now);
            query.SetString("lno", lno);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public IList<TLMDTO00018> SelectLoanBetweenSysDateandToday(string sourcebr,DateTime sysdate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00010.SelectLoanBetweenSysDateandToday");
            query.SetString("sourcebr", sourcebr);
            query.SetDateTime("sysdate", sysdate);
            query.SetDateTime("today", DateTime.Now.AddDays(-1));
            return query.List<TLMDTO00018>(); 
        }

        public IList<TLMDTO00018> SelectLoanLessthanSysDate(string sourcebr, DateTime sysdate)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00010.SelectLoanLessthanSysDate");
            query.SetString("sourcebr", sourcebr);
            query.SetDateTime("sysdate", sysdate);       
            return query.List<TLMDTO00018>();
        }

        public IList<TLMDTO00018> SelectInsuranceExpiredLoans(string sourcebr, DateTime sysdate)
        {
            IQuery query = this.Session.GetNamedQuery("SelectInsuranceExpiredLoans");
            query.SetString("SourceBr", sourcebr);
            query.SetDateTime("sysdate", sysdate);
            return query.List<TLMDTO00018>(); 
        }

        public IList<TLMDTO00018> SelectInterestRate(string accountNo, string acType1,string acType2)
        {
            IQuery query = this.Session.GetNamedQuery("TCMDAO00009.SelectInterestRate");
            query.SetString("accountNo", accountNo);
            query.SetString("acType1", acType1);
            query.SetString("acType2", acType2);
            return query.List<TLMDTO00018>();
        }

        #region LOMSVE00012 (OD Change Limit Entry)
        public TLMDTO00018 GetLoansAccountInformation(string loanNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMORM00018.GetLoansAccountInformation");
            query.SetString("loanNo", loanNo);
            query.SetString("sourceBr", sourceBr);           
            return query.UniqueResult<TLMDTO00018>();
        }

        public TLMDTO00018 GetLoansByLoansNo(string loanNo)
        {
            IQuery query = this.Session.GetNamedQuery("TLMORM00018.GetLoansByLoanNo");
            query.SetString("loanNo", loanNo);
            return query.UniqueResult<TLMDTO00018>();
        }

        public bool UpdateChargesstatus(string chargesStatus, string loanNo, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMORM00018.UpdateChargesstatus");
            query.SetString("chargesStatus", chargesStatus);
            query.SetString("loanNo", loanNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;           
        }

        public bool UpdateSamtAndFirstSamt(decimal newODLimit, string loanNo, string sourceBranchCode, string accountNo, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMORM00018.UpdateSamtAndFirstSamt");
            query.SetDecimal("newODLimit", newODLimit);
            query.SetString("loanNo", loanNo);
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetString("accountNo", accountNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public bool UpdateLoansForNPLCase(string lno, string userName, string sourceBr, int updatedUserId , bool Isrelease)
        {
            IQuery query = this.Session.GetNamedQuery("TLMORM00018.UpdateLoansForNPLCase");            
            query.SetString("loanNo", lno);
            if(Isrelease == true)
                query.SetBoolean("nplCase",false);            
            else
                query.SetBoolean("nplCase", true);   
            query.SetString("userName", userName);
            query.SetString("sourceBranchCode", sourceBr);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;           
        }


        public TLMDTO00018 GetLoansAccountInformationWithInterest(string loanNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("SpGetLoanInformationWithInterest");
            query.SetString("loanNo", loanNo);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TLMDTO00018)));
            return query.UniqueResult<TLMDTO00018>();  
        }

        public TLMDTO00018 GetLoanInformationForRepaymentEdit(string loanNo, string sourceBr)
        {
     
            IQuery query = this.Session.GetNamedQuery("SpGetLoanInformationForRepaymentEdit");
            query.SetString("loanNo", loanNo);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TLMDTO00018)));
            return query.UniqueResult<TLMDTO00018>();


        }


        public TLMDTO00018 RepayLoan(bool fullSettlement, string lno, string accountNo, decimal repaymentAmount, decimal interest, string userNo, int userId, string sourceBr,string vouno)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SpRepayLoan");
                query.SetInt32("FullSettlement", (fullSettlement)? 1:0);
                query.SetString("LoanNo", lno);
                query.SetString("AccountNo", accountNo);
                query.SetDecimal("RepayAmount", repaymentAmount);              
                query.SetString("UserNo", userNo);
                query.SetInt32("UserId", userId);
                query.SetString("BranchCode", sourceBr);
                query.SetString("VoucherNo", vouno);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TLMDTO00018)));
                return query.UniqueResult<TLMDTO00018>();
                
            }
            catch (Exception)
            {
                return null;

            }
            
            
        }

        public TLMDTO00018 RepayLoanEdit(bool fullSettlement, string lno, string accountNo, string repayNo, decimal repaymentAmount, string userNo, int userId, decimal newRepaymenAmount, string reno, string sourceBr,string voucherNo)
        {
            try
            {
                IQuery query = this.Session.GetNamedQuery("SpRepayLoanEdit");
                query.SetInt32("FullSettlement", (fullSettlement) ? 1 : 0);
                query.SetString("LoanNo", lno);
                query.SetString("AccountNo", accountNo);
                query.SetString("RepayNo", repayNo);
                query.SetDecimal("LastRepayAmount", repaymentAmount);
                query.SetString("UserNo", userNo);
                query.SetInt32("UserId", userId);
                query.SetDecimal("NewRepayAmount", newRepaymenAmount);
                query.SetString("Reno", reno);                
                query.SetString("BranchCode", sourceBr);
                query.SetString("VoucherNo", voucherNo);
                query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TLMDTO00018)));
                return query.UniqueResult<TLMDTO00018>();

            }
            catch (Exception)
            {
                return null;

            }


        }


        [Transaction(TransactionPropagation.Required)]
        public bool UpdateLegaLawyer(string legaLawyer, string loanNo, string sourceBr, int updatedUserId)
        {

            IQuery query = this.Session.GetNamedQuery("TLMDAO00018.UpdateLegaLawyer");
            query.SetString("legalawyer", legaLawyer);
            query.SetString("lno",loanNo);
            query.SetString("sourceBr", sourceBr);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        #endregion

        public TLMDTO00018 SelectIntRateByAcType(string acctNo, string sourceBr, string atype)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00018.SelectIntRateByAtype");
            query.SetString("accountNo", acctNo);
            query.SetString("sourceBr", sourceBr);
            query.SetString("atype", atype);
            return query.UniqueResult<TLMDTO00018>();
        }

        /// <summary>
        /// Select By Loan No
        /// </summary>
        /// <param name="loanNo"></param>
        /// <param name="sourceBr"></param>
        /// <returns></returns>
        public TLMDTO00018 SelectByLoanNo(string loanNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00018.SelectByLoanNo");
            query.SetString("loanNo", loanNo);
            query.SetString("sourceBr", sourceBr);
            return query.UniqueResult<TLMDTO00018>();
        }

        #region LOMSVE00016 (Legal Case)


        public IList<TLMDTO00018> SelectLoansAccountInfoByAccountNo(string accountNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMORM00018.GetLoansAccountInfoByAccountNo");
            query.SetString("accountNo", accountNo);
            query.SetString("sourceBr", sourceBr);
            return query.List<TLMDTO00018>(); 
        }

        public bool UpdateLoansForLegalCase(string lno, string sourceBr, string markLegalUser, string legalCaseLawyer, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMORM00018.UpdateLoansForLegalCase");
            query.SetString("lno", lno);
            query.SetDateTime("legalDate", DateTime.Now);
            query.SetString("markLegalUser", markLegalUser);
            query.SetString("legalCaseLawyer", legalCaseLawyer);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }

        public bool UpdateLoansForLegalReleaseCase(string lno, string sourceBr, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMORM00018.UpdateLoansForLegalReleaseCase");
            query.SetString("lno", lno);           
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetString("LegalReleaseUser", updatedUserId.ToString());
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetString("sourceBr", sourceBr);
            return query.ExecuteUpdate() > 0;
        }


        #endregion

        #region LOMVEW00025 (BL Loans Repay Entry For Limit Decrease)
        public bool UpdateSamtByLnoAndAcctno_Decrease(decimal newODLimit, string loanNo, string sourceBranchCode, string accountNo,string repayNo, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMORM00018.UpdateSamtByLnoAndAcctnoLMIDecrease");
            query.SetDecimal("newODLimit", newODLimit);
            query.SetString("loanNo", loanNo);
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetString("accountNo", accountNo);
            query.SetString("repayNo", repayNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        #endregion

        #region LOMVEW00025 (BL Loans Repay Entry For Limit Increase)
        public bool UpdateSamtByLnoAndAcctno_Increase(decimal newODLimit, string loanNo, string sourceBranchCode, string accountNo, string repayNo, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("TLMORM00018.UpdateSamtByLnoAndAcctnoLMIncrease");
            query.SetDecimal("newODLimit", newODLimit);
            query.SetString("loanNo", loanNo);
            query.SetString("sourceBranchCode", sourceBranchCode);
            query.SetString("accountNo", accountNo);
            query.SetString("repayNo", repayNo);
            query.SetDateTime("updatedDate", DateTime.Now);
            query.SetInt32("updatedUserId", updatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        #endregion
        #region BL Schedule Info By BLNO
        public IList<TLMDTO00018> SelectBusinessLoansNoBySourceBr(string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00018.SelectBusinessLoansNo");
            query.SetString("sourceBr", sourceBr);
            return query.List<TLMDTO00018>();
        }
        #endregion

        // Currently, No Use. Htet Mon Win replaced this one with "SP_BindLoansRepayInformationByRepaymentAmount_LC_Increase" script calling  at 18-05-2023.
        /*        
        public TLMDTO00018 (string intRate, string Lno, decimal RepayAmt, string sourceBr)
        {
            TLMDTO00018 result;
            IQuery query = this.Session.GetNamedQuery("SP_GetNewInterestForNewRateLCIncrease");
            query.SetString("intRate", intRate);
            query.SetString("lno", Lno);
            query.SetDecimal("RepayAmt", RepayAmt);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TLMDTO00018)));
            result = query.UniqueResult<TLMDTO00018>();
            return result;
        }
        */

        public TLMDTO00018 CountofLoan_byAccountNo(string accountNo, string TranName)
        {
            IQuery query = this.Session.GetNamedQuery("SP_CountofLoan_byAccountNo");
            query.SetString("Acctno", accountNo);
            query.SetString("TranName", TranName);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TLMDTO00018)));
            TLMDTO00018 Result = query.UniqueResult<TLMDTO00018>();
            return Result;
        }
       
        //Added by SHO (22-Nov-2021) //For Business Loans Limit change entry
        /*public TLMDTO00018 SelectBusinessLoansType(string loanNo, string sourceBr)
        {
            IQuery query = this.Session.GetNamedQuery("TLMDAO00018.SelectBusinessLoansType");
            query.SetString("loanNo", loanNo);
            query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(TLMDTO00018)));
            TLMDTO00018 Result = query.UniqueResult<TLMDTO00018>();
            return Result;
            
        }*/
    }


}
