//----------------------------------------------------------------------
// <copyright file="ITLMDAO00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013.8.22 </CreatedDate>
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
    public interface ITLMDAO00009 : IDataRepository<TLMORM00009>
    {
        TLMDTO00009 SelectGroupNoByEno(string eno, string sourceBr);

        IList<TLMDTO00009> SelectAllDepoDeno(string SourceBranchCode);
        void DeleteDepodeno(string SourceBranchCode);

        IList<TLMDTO00009> SelectChargesByGroupNo(string groupno);
        TLMDTO00009 SelectSumAmountByGroupNo(string groupno, string eno, string sourcebr);
        string SelectGroupNoByAcType(string acType, string sourceBr);
        decimal SelectOtherAmountByGroupNo(string groupNo, string acType, string sourceBr);
        bool DeleteByGroupNoAndACType(string acType, string sourceBr, int updatedUserId, string groupNo);
        bool UpdateByGroupNoAndACType(string acType, string sourceBr, int updatedUserId, string groupNo, decimal amount);


        TLMDTO00009 SelectDepoDeno(string groupNo, string poNo, string sourceBranch);
        decimal SumAmountByPONo(string groupNo, string poNo, string sourceBranch);
        bool UpdateDepoDenoByReverseStatus(string groupNo, string poNo, string sourceBranch, int updatedUserId, DateTime updatedDate, bool isUpdate);  //edited by ASDA

        IList<TLMDTO00009> SelectAccountNoByGroupNo(string groupno, string status, string sourcebranch);
        IList<TLMDTO00009> SelectDepoDenoForCheckSinglePO(string poNo, string Tlf_Eno, string sourceBranch);//For Single PO Refund Reversal

        void DeleteDataFromDepoDeno(string sourcebr, DateTime startDate, DateTime endDate);
        IList<TLMDTO00009> SelectAccountTypesByGroupNo(string eno, string sourceBr);
        IList<TLMDTO00009> SelectAccountTypesByTlf_Eno(string eno, string sourceBr);
        decimal SelectAmountByGroupNo(string groupNo, string acType, string sourceBr);

        string Check_GroupNo_ValidOrNot_MultipleDepReversal(string groupNo, string sourceBr);// Added by AAM (19-Jan-2018)
        
        //string Check_EntryNo_ValidOrNot_MultipleDepReversal(string eno, string sourceBr);// Added by AAM (22-Jan-2018)

        //string Check_EntryNo_ValidOrNot_MultipleDepReversal(string eno, string sourceBr,string groupNo);// Updated by ZMS (15.11.18), Commented by HMW (10-June-2019)
        string Check_EntryNo_ValidOrNot_MultipleDepWdwReversal(string groupNo, string eno, string sourceBr);
    }
}
