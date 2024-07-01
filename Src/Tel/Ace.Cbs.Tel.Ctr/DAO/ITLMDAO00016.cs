//----------------------------------------------------------------------
// <copyright file="ITLMCTL00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-07</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00016 : IDataRepository<TLMORM00016>
    {
        bool UpdatePOByPONo(DateTime issueDate, string status, string budget, int updatedUserId, string poNo, string userNo);
        bool UpdatePORefundByPONoAndBudgetYear(DateTime issueDate, DateTime refundDate, string status, string budget, string poNo,string toacctno, int updatedUserId);
        IList<TLMDTO00016> GetPOOutstandingReport(IList<string> acodelist, IList<string> toaccountnolist);
        bool CheckExist(string pono);
        IList<TLMDTO00016> SelectPOByPOOutstandingNormal(string SourceBranchCode);
        IList<TLMDTO00016> SelectPO(string SourceBranchCode);
        IList<TLMDTO00016> SelectByPoNOforRE(string SourceBranchCode);
        void DeletePO(string SourceBranchCode);
        IList<TLMDTO00016> SelectSumPOAmount(string SourceBranchCode);
        bool UpdateIDateAndStatus(string poNo, int updatedUesrId);
        TLMDTO00016 SelectPOByPONoandBudgetYear(string pono, string budgetyear, string sourceBr);
        TLMDTO00016 SelectPOByPONoAndSourceBrAndCurAndBudgetYear(string pono, string sourceBr, string cur, string budgetyear);
        bool DeletePOByActive(string pono, string sourceBr, int updatedUserId);
        IList<TLMDTO00016> SelectPOInfoByAcctno(string acctno, string sourceBr);
        TLMDTO00016 GetPOData(string poNo, string budget, string sourceBranch);
       IList<TLMDTO00016> POData(string poNo, string budget, string sourceBranch);
        bool DeletePOData(string poNo, string budget, string sourceBranch,int updatedUserId,DateTime updatedDate);
        bool UpdatePOByAmount(string poNo, string budget, string sourceBranch, decimal amount, decimal charges, int updatedUserId, DateTime updatedDate);

        bool UpdateIDateAndRefundSDate(string poNo, string budget, string sourceBranch, int updatedUesrId);

        //For Budget End Flexible By HMW 2019/04/25
        string GetBudget_Month_Year_Quarter(Int32 service, DateTime pDate, string branchCode, string Return);
    }
}
