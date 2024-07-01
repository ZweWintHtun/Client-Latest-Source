//----------------------------------------------------------------------
// <copyright file="ITLMSVE00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-06-19</CreatedDate>
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
    /// <summary>
    /// Remittance Encash Service Interface
    /// </summary>
    public interface ITLMDAO00001 : IDataRepository<TLMORM00001>
    {
        TLMDTO00001 SelectREInformationByRegisterNo(string registerNo, string sourcebranchcode);
        IList<TLMDTO00001> SelectREDTOListForPOPrinting(DateTime datetime, string sourcebranchcode);
        IList<TLMDTO00001> SelectRemittanceEncashData(string sourceBr);
        void UpdateREByRegisterNo(string registerNo, System.DateTime issueDate, int updatedUserId);
        bool UpdateRemittanceEncashData(string registerNo, Nullable<DateTime> issueDate, string encashNo, Nullable<DateTime> settlementDate, Nullable<int> updatedUserId, Nullable<DateTime> updatedDate);
        IList<TLMDTO00001> SelectToAcctNoByPONO(IList<string> ponoList);
        bool CheckExistRegisterNo(string registerNo);
        IList<TLMDTO00001> SelectEncashDataForIBLReconcileSide(DateTime datetime, string type, string ebank, string sourcebranchcode);
        IList<TLMDTO00001> SelectPassingEncashRemittanceData(string sourceBranch);
        //IList<TLMDTO00001> SelectPassingEncashRemittanceData();   //Added by ASDA , call from TLMSVE00017(Encash Remittance Passing)
        TLMDTO00001 SelectRegisterNoByPO(string pono);
        IList<TLMDTO00001> SelectRE(IList<string> ponoList, string SourceBranchCode);
        void DeleteRE(IList<string> ponoList, string SourceBranchCode);
        TLMDTO00001 GetREInfoByRegtisterNo(string registerNo);
        bool UpdatePrintStautsByRegisterNo(string registerNo, Nullable<short> printstatus, int updatedUserId);
       // bool UpdateReInfo(string registerNo, string EncashNo, string toAccountNo, DateTime issueDate, DateTime settlementDate, int updatedUserId, DateTime updatedDate);
        bool UpdateReInfo(string registerNo, string EncashNo, string toAccountNo, Nullable<DateTime> issueDate, Nullable<DateTime> settlementDate, Nullable<int> updatedUserId, Nullable<DateTime> updatedDate);
        //bool UpdateReInfo(string p, string p_2, string p_3, DateTime dateTime, DateTime dateTime_2, int? nullable, DateTime? nullable_2);
        //For Encash No Editting
        void UpdateReEntity(string registerNo_new, string registerNo_old, System.Nullable<int> updatedUserId, System.Nullable<DateTime> updatedDate);

        bool UpdateByRegisterNo(TLMDTO00001 entity);
        TLMDTO00001 SelectByRegisterNo(string registerNo, string sourceBr);
        IList<TLMDTO00001> SelectReListByRegisterNo(string registerNo, string sourceBr);

        bool DeleteREbyRegisterNo(string registerNo, string sourceBr, string cur, int updatedUserId);
        //bool UpdateREbyRegisterNoWithAmount(decimal amount, string registerNo, string sourceBr, int updatedUserId);
        bool UpdateREbyRegisterNoWithAmountAndIssueDate(decimal amount, string registerNo, string sourceBr, string name, string address, string nrc, string phono, int updatedUserId);
        bool UpdateIssueDateAndToAcctno(string registerNo, string sourceBr, int updatedUserId);
        IList<TLMDTO00001> SelectRemittanceEncashDataCashType(string sourceBr);
        TLMDTO00001 SelectREForPrinting(string registerNo, string sourceBranch);
        bool UpdateREbyRegisterNoWithAmount(decimal amount, string registerNo, string sourceBr, string name, string address, string nrc, string phono, int updatedUserId);
    }
}
