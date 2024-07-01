//----------------------------------------------------------------------
// <copyright file="ITLMDAO00015.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    /// <summary>
    /// CashDeno DAO Interface
    /// </summary>
    public interface ITLMDAO00015 : IDataRepository<TLMORM00015>
    {
        IList<TLMDTO00015> GetDepoDenoAndCashDenoForDrawingVoucher(string registerNo, string sourceBranch);
        //IList<TLMDTO00015> GetCenterTableDataDTOList(string status, string receiptno);
        IList<TLMDTO00015> GetCenterTableDataDTOList(string status, string receiptno,string sourcebr);
        TLMDTO00015 SaveCashDenoData(TLMDTO00015 cashdenoparameter);        
        bool UpdateReceiptReversal(TLMDTO00015 cashdenoInfo);

        //IList<TLMDTO00015> SelectOnlineCashDenoData_DepoDeno();
       // IList<TLMDTO00015> SelectOnlineCashDenoData_IblTlf();
        IList<TLMDTO00015> SelectOnlineCashDenoData(string sourceBr);
        bool CheckEntryNo(string EntryNo);
        bool UpdateCashDeno(string entryno, CXDTO00001 denodto, string counterno, int updatedUserId, decimal rate);
        IList<TLMDTO00015> SelectHomeAmountByBranch(string branchCode, string currency, DateTime settlementDate, string accountType, string counterNo);

        IList<TLMDTO00015> GetCashDenoInfo(string tlfeno, string status, string sourceBr);    // for TCMSVE00007

        IList<TLMDTO00015> SelectAll(string SourceBranchCode);
        void DeleteCashDeno(string SourceBranchCode);
        string SelectCounterNoByAcType(string acType, string sourceBr);
        TLMDTO00015 SelectByAcTypeAndNotReverse(string acType, string sourceBr);
        bool DeleteByACType(string acType, string sourceBr, int updatedUserId);
        bool DeleteByTlfEno(string tlfEno, string sourceBr, int updatedUserId);
        bool UpdateCashDenoByTlfEno(CXDTO00001 deno, int updatedUserId, string sourceBr, string tlfEno, decimal cashAmount);
        bool UpdateCashDenoByACType(CXDTO00001 deno, int updatedUserId, string sourceBr, string acType, decimal cashAmount);
        decimal SelectAmountByTlfEno(string tlfEno, string sourceBr);
        decimal SelectAmountByACType(string acType, string sourceBr);
        bool UpdateCashDenoByTlfEnoAndCashDate(string eno, int updatedUserId, string tlfEno, string sourceBr);
        TLMDTO00015 SelectCashDenoInfoByACType(string RegisterNo, string SourceBranchCode);

        //IndividualDenomination Delete
        TLMDTO00015 GetCashDenoByEntryNo(string entryNo, string brnachCode);
        void DeleteCashDenoByEntryNo(string entryNo, string brnachCode);

        bool UpdateReceiptNoInCenterTableApprove(string tlfEno, int updatedUserId, string sourceBr);

        IList<TLMDTO00015> GetDepoDenoAndCashDeno(string groupNo, string sourceBranch);
        TLMDTO00015 GetCashDenoForPOReversal(string groupNo, string sourceBranch);
        TLMDTO00015 GetSinglePO(string poNo, string sourceBranch);
        TLMDTO00015 GetMultiPO(string groupNo, string poNo, string sourceBranch,string status);
        TLMDTO00015 SelectByEno(string eno, string sourceBranch);
        bool UpdateCashDenoByDenoEntryNo(string voucherNo, string orgnEno, string poNo, string sourceBranch, int updatedUserId, DateTime updatedDate);
        bool UpdateCashDenoByTlfEntryNo(string voucherNo, string groupNo, string sourceBranch, int updatedUserId, DateTime updatedDate,string status);

        TLMDTO00015 SelectCashDenoByTlfEnoForDenoEdit(string tlfeno, string sourcebranchcode);
        bool UpdateCashDenoEdit(string tlfeno, TLMDTO00015 cashdenodto);
        bool UpdateCashDenoByAccountType(string voucherNo, string poNo, string sourceBranch, int updatedUserId, DateTime updatedDate);

        IList<TLMDTO00015> SelectCashDenoBySourcebrAndDatetimeAndStatus(string sourcebr, DateTime startDate, DateTime endDate, string status);
        IList<TLMDTO00015> SelectCashDenoBySourcebrAndDatetime(string sourcebr, DateTime startDate, DateTime endDate);
        void DeleteCashDenoByDatetimeAndStatus(string sourcebr, DateTime startDate, DateTime endDate, string status);
        void DeleteCashDenoByDatetime(string sourcebr, DateTime startDate, DateTime endDate);

        IList<TLMDTO00015> GetCashDenoInfoByIsNotNullCashDate(string tlfeno, string status, string sourceBr);
        int SelectMaxId();
        bool UpdateCashDenoByGroupNo(TLMDTO00015 cashdenodto);
        TLMDTO00015 SelectCashDenoByAccountTypeOrTLFEno(string accountType, string sourcebranchcode);

        bool UpdateCashDenoForReversalDelete(string voucherNo, int updatedUserId, string tlfEno, string sourceBr);//Added by ASDA
        bool UpdateCashDenoByForAmountEdit(string voucherNo,int updatedUserId, string tlfEno, string sourceBr); //added by ASDA
        bool UpdateCashDenoByCashDateNull(int updatedUserId, string tlfEno, string sourceBr); //added by ASDA
    }
}
