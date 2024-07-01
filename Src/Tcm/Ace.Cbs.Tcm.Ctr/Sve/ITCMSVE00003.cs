//----------------------------------------------------------------------
// <copyright file="ITCMSVE00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>12/09/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tcm.Ctr.Sve
{
   public interface ITCMSVE00003:IBaseService
    {
       string[] SavePOIssueEntry(IList<TLMDTO00043> PoIssueList);
       TLMDTO00016 CheckAccountNo(string accountNo, bool isVIP, bool isWithIncome,string workStation,int createdUserId,string sourceBr);
       //decimal CheckPOAmountAndBindPORate(decimal poamount, string currency);CXDTO00009 CheckChequeNoAndAmount
       IList<TLMDTO00016> CheckForPO(string acctno, string branchno);//Select PO info For MNMVEW00020(PO Editting by Transfer)
       CXDTO00009 CheckChequeNoAndAmount(string accountNo, string chequeNo, decimal amount, bool isMinBalCheck, bool isVIP, bool isDebit, string branchCode);
       string GetDescriptionByAccountNo(string accountNo);
       bool CheckingChequeNo(string accountNo, string chequeNo, string branch);
   }
}
