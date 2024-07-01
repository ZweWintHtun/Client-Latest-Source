//----------------------------------------------------------------------
// <copyright file="ITLMDAO00017.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nay Lin Ko Ko, Khin Phyu Lin</CreatedUser>
// <CreatedDate>2013-06-19</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Cx.Com.Dto;

namespace Ace.Cbs.Tel.Ctr.Dao
{
    public interface ITLMDAO00017 : IDataRepository<TLMORM00017>
    {
        string SelectRegisterNo(string RegisterNo);
        IList<TLMDTO00017> SelectRegisterNoBySendDate(string order, string sourceBr, DateTime datetime);
        TLMDTO00017 SelectDrawingInfoByRegisterNo(string registerNo);
        bool UpdateRDByRegisterNo(string registerNo, System.DateTime sendDate, int updatedUserId, DateTime updatedDate);
        IList<TLMDTO00017> SelectAllRegisterNo(string sourceBranchCode, string type);
        IList<TLMDTO00017> SelectAllRegisterNoForFX(string sourceBranchCode, string type);

        decimal SelectTestKeyByRegisterNo(string registerNo);

        IList<TLMDTO00017> SelectDrawingDataForIBLReconcile(DateTime date_time, string type, string branchcode, string sourcebranchcode);
        TLMDTO00017 SelectDrawingDataForIBLReconcileSide(DateTime date_time, string type, string branchcode);

        IList<TLMDTO00017> SelectAllRDQTR(string qSDATE, string qEDATE, string SourceBranchCode);
        void DeleteRDQTR(string qSDATE, string qEDATE, string SourceBranchCode);
        IList<TLMDTO00017> SelectAllRD(string SourceBranchCode);
        void DeleteRD(string SourceBranchCode);

       // TLMDTO00017 SelectDrawingDataByRegisterNo(string RegisterNo);
        bool UpdateRDByRegisterNoAndSourceBr(DateTime sendDate, int UpdateUserId, DateTime updateDate, string registerNo1, string registerNo2, string sourceBr);
        bool UpdateRDRegisterNoToAddC(string registerNo, string newRegNo, string sourcebr, int updatedUserId);
        TLMDTO00017 SelectByRegisterNo(string registerNo, string sourceBr);
        bool UpdateRDPersonalInformation(string name, string nrc, string address, string phoneNo, string narration, string toAccountNo, string toName, string toNRC, string toAddress, string toPhoneNo, int updatedUserId, string registerNo, string sourceBr);
        bool DeleteByRegisterNo(string registerNo, string sourceBr, int updatedUserId);
        bool UpdateRDImportantDataByRegisterNo(decimal testKey,decimal amount, decimal commission, decimal tlxCharges, string incomeType, string accountNo, string name, string nrc, string address, string checkNo, string phoneNo, string narration, string acSign, string rdType, string deno_status, int updatedUserId, string registerNo, string sourceBr);
        bool UpdateRDVoucher(DateTime receiptDate, DateTime incomeDate, DateTime settlementDate, string registerNo, string sourceBranch, int updatedUserId, DateTime updatedDate);

        TLMDTO00017 SelectDrawingDataByRegisterNo(string RegisterNo, string sourceBr);

        IList<TLMDTO00017> SelectRDDataListByGroupNo(string groupNo, string sourceBranch, bool isRD);
       // IList<TLMDTO00017> SelectRDandAmountListInDrawingCashDepositDenominationEntry(string groupNo, string sourceBranch);
        bool UpdateDenoStatusByRegisterNo(string groupNo, string sourceBranch, int updatedUserId, DateTime updatedDate);

    }
}
