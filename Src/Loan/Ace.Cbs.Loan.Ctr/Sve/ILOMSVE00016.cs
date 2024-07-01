//----------------------------------------------------------------------
// <copyright file="ILOMSVE000165" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>16.01.2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00016 : IBaseService
    {
        #region Legal Case
        IList<PFMDTO00072> CheckCustomerInformation(string loanNo, string sourceBr);
        IList<MNMDTO00012> GetLegalIntList(string[] typelist,string loanNo, string branchCode);
        bool GetLoanInterestAndUpdateLI(string loanNo, int daysInYear, DateTime qStartDate, DateTime qEndDate, int period, decimal amount, string curQtr, string sourceBr, int updatedUserId);
       // LOMDTO00021 GetLI_Info(string accountNo,string loanNo, string sourceBr);
        IList<LOMDTO00021> GetLI_Info(string accountNo, string loanNo, string sourceBr);
        MNMDTO00008 GetOI_Info(string accountNo, string loanNo,string mMonth,string sourceBr);        
        //Nullable<decimal> GetLoanSCharges(string loanNo, int daysInYear, DateTime qStartDate, DateTime qEndDate, int CurQtr, decimal amount);
        LOMDTO00021 CalculateLoanScharge(string loanNo, int daysInYear, DateTime qStartDate, DateTime qEndDate, string termNo,string sourceBr, int updatedUserId);
        PFMDTO00033 GetAccountInfoFromCledgerAndBal(string budYear,DateTime endOfMonth,string accountNo,string sourceBr);
        IList<TLMDTO00018> GetLoansAccountInfoByAccountNo(string accountNo, string sourceBr);
        IList<PFMDTO00042> GetDataFromReportTlf(string accountNo, DateTime startOfMonth, DateTime endOfMonth, int workStationId, string sourceBr);
        MNMDTO00027 GetSCharge(string InterestMonths,string budmth,string accountNo,string lno, string sourceBr);
        void SaveLegalCase(LOMDTO00013 Legaldto, string markLegalUser, string legalCaseLawyer);
        
        #endregion

        #region Legal Release

        IList<LOMDTO00013> isLegalLoanNo(string loanNo, string sourceBr);
        void ReleaseLegalSueCase(string loanNo, string sourceBr, string currentUserName, int currentUserId);

        #endregion
    }
}
