//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="IMNMDAO00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Banking</CreatedUser>
// <CreatedDate>11/15/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ctr.Dao
{
    /// <summary>
    /// MNMDAO00017 Interface
    /// </summary>
    public interface IMNMDAO00017 : IDataRepository<MNMORM00017>
    {
        int SelectMaxId();
        IList<LOMDTO00021> SelectAll(string SourceBranchCode);
        IList<LOMDTO00021> SelectLiInfoForLoanInterest(string lno, string SourceBranchCode);
        bool UpdateQBal(int samt, string lno, string quater_month, string SourceBranchCode, int updatedUserId);
        bool UpdateLI(decimal month, string budget, string SourceBranchCode, int updatedUserId);
        bool Update_LI_InfoByLoanNoAndSourceBr(LOMDTO00021 liDto);
        //LOMSVE00016 (Legal Case Entry)
        LOMDTO00021 SelectByAccountNo(string accountNo);  
        bool UpdateLoanInterestInLI(string loanNo, string currentQtr, decimal returnLaonInterest, string branchCode, int updatedUserId);
        //LOMDTO00021 SelectByAccountNoAndLoanNo(string accountNo, string loanNo, string sourceBr);
        //
        IList<LOMDTO00021> GetLiInfo(string lNo, string sourceBr);
        bool UpdateLoansInterest(string lNo, string sourceBr, decimal q4Amount, int updateUserId);
        //2017
        //bool Update_LI_PrincipalAmount(string lno, decimal principalamount, string sourcebr, int userid, DateTime datetime);
        
        IList<LOMDTO00021> SelectByAccountNoAndLoanNo(string accountNo, string loanNo, string sourceBr);
        IList<LOMDTO00021> CheckIntCalculateDate(string year, DateTime Smonth, DateTime Emonth);
      
        //string UpdateLoanInterest(LOMDTO00021 liList);
        IList<LOMDTO00021> SelectByLoanNo(string accountNo, string loanNo);
        IList<LOMDTO00021> SelectLoansInterestByQuater(string qno, string budget, string sourceBr, string cur);
        IList<LOMDTO00054> SelectODInterestByQuater(string mno, string budget, string sourceBr, string cur);
        
        //For Loans Interest Calculation
        string CalculateLoansInterestForQuarter(DateTime sDate, DateTime eDate, int period, string branchCode);
        string CalculateLoansInterestForMonthly(DateTime sDate, DateTime eDate, int period, string branchCode);
        string CalculateBusinessLoansInterestForDaily(DateTime sDate, DateTime eDate, string branchCode,int userid);
    }
}