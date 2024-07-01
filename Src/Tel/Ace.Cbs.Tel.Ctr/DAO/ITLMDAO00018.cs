//----------------------------------------------------------------------
// <copyright file="ITLMDAOE00018.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-07-01</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using System;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00018 :  IDataRepository<TLMORM00018>
    {
        TLMDTO00018 SelectLoanAccountInfo(string accountNo);
        TLMDTO00018 GetExpireAmount(string accountNo);
        TLMDTO00018 SelectForOverDraftPosting(string accountNo);
        IList<TLMDTO00018> SelectLoansByCloseDate(string sourceBr);
        IList<TLMDTO00018> SelectAll(string SourceBranchCode);
        bool UpdateLastIntDate(string lno, int updatedUserId);
        IList<TLMDTO00018> SelectLoanBetweenSysDateandToday(string sourcebr, DateTime sysdate);
        IList<TLMDTO00018> SelectLoanLessthanSysDate(string sourcebr, DateTime sysdate);
        IList<TLMDTO00018> SelectInsuranceExpiredLoans(string sourcebr, DateTime sysdate);
        IList<TLMDTO00018> SelectInterestRate(string accountNo, string acType1,string acType2);
        TLMDTO00018 GetLoansAccountInformation(string loanNo, string sourceBr); // (call from LOMSVE00012- OD Change Limit)            
        bool UpdateChargesstatus(string chargesStatus, string loanNo, int updatedUserId); // (call from LOMSVE00012- OD Change Limit)            
        bool UpdateSamtAndFirstSamt(decimal newODLimit, string loanNo, string sourceBranchCode, string accountNo, int updatedUserId);  // (call from LOMSVE00012- OD Change Limit)   
        bool UpdateLoansForNPLCase(string lno, string userName, string sourceBr, int updatedUserId, bool IsRelease); // (call from LOMSVE00014- Non-Performance Loan Case)       
        IList<TLMDTO00018> SelectLoansAccountInfoByAccountNo(string accountNo, string sourceBr);
        bool UpdateLoansForLegalCase(string Lno, string sourceBr,string markLegalUser,string legalCaseLawyer,int updatedUserId); //LOMSVE00016 - LegalCaseEntry
        bool UpdateLoansForLegalReleaseCase(string lno, string sourceBr, int updatedUserId);        
        bool UpdateLoanInfoByLoanNoAndSourceBr(TLMDTO00018 loanDto); // For Loan Registration Editting
        bool UpdateLoanForLoanVoucherByLoanNoAndSourceBr(TLMDTO00018 loanDto); //For Loan Voucher
        bool UpdateLegaLawyer(string legaLawyer, string loanNo, string sourceBr, int updatedUserId);
        TLMDTO00018 SelectIntRateByAcType(string acctNo, string sourceBr, string atype);
        TLMDTO00018 SelectByLoanNo(string loanNo, string sourceBr);
        TLMDTO00018 GetLoansByLoansNo(string loanNo);

        TLMDTO00018 GetLoanInformationForRepaymentEdit(string loanNo, string sourceBr);
        TLMDTO00018 GetLoansAccountInformationWithInterest(string loanNo, string sourceBr);
        TLMDTO00018 RepayLoan(bool fullSettlement, string lno, string accountNo, decimal repaymentAmount, decimal interest, string userNo, int userId, string sourceBr,string vouno);
        TLMDTO00018 RepayLoanEdit(bool fullSettlement, string lno, string accountNo, string repayNo, decimal repaymentAmount, string userNo, int userId, decimal newRepaymenAmount, string reno, string sourceBr,string vouno);
        
        IList<TLMDTO00018> GetExpireAmountByAcctNo(string accountNo); //Added by HWKO (07-Jun-2017)
        IList<TLMDTO00018> GetOverdraftExpireAmountByAcctNo(string accountNo); //Added by HWKO (07-Jun-2017)
        IList<TLMDTO00018> GetLoansExpireAmountByAcctNo(string accountNo); //Added by HWKO (07-Jun-2017) 

        bool UpdateSamtByLnoAndAcctno_Decrease(decimal newODLimit, string loanNo, string sourceBranchCode, string accountNo, string repayNo, int updatedUserId);//BL Loans Repay Entry 
        IList<TLMDTO00018> SelectBusinessLoansNoBySourceBr( string sourceBr);
        bool UpdateSamtByLnoAndAcctno_Increase(decimal newODLimit, string loanNo, string sourceBranchCode, string accountNo, string repayNo, int updatedUserId);//BL Loans Repay Entry 

        //Comment by HMW (21-05-2023) : Currently, No Use. Htet Mon Win replaced this one with "SP_BindLoansRepayInformationByRepaymentAmount_LC_Increase" script calling.
        //TLMDTO00018 GetNewInterestForNewRateLCIncrease(string intRate, string Lno,decimal RepayAmt, string sourceBr);
        TLMDTO00018 CountofLoan_byAccountNo(string accountNo, string TranName);
        //TLMDTO00018 SelectBusinessLoansType(string loanNo, string sourceBr); //Added by SHO (22-Nov-2021) //For Business Loans Limit change entry

    }
}
