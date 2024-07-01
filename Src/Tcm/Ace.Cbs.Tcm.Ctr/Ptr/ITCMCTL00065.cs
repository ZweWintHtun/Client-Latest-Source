//----------------------------------------------------------------------
// <copyright file="ITCMCTL00065.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2014-02-10 </CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using Ace.Cbs.Tcm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
   public interface ITCMCTL00065
    {
       ITCMVEW00065 DailyReportListingModifyView { get; set; }
       TCMDTO00052 GetDailyReport(bool isFormLoad, TCMDTO00052 drDTO);
       TCMDTO00052 GetViewData();
    }
   public interface ITCMVEW00065
   {
       void Successful(string message);
       void Failure(string message);
       ITCMCTL00065 DailyReportListingModifyController { get; set; }
        DateTime PostDate { get; set; }
        string Currency { get; set; }
         decimal ReceivingCashAmount { get; set; }
         decimal ReceivingCashVoucher { get; set; }
         decimal ReceivingTransferAmount { get; set; }
         decimal ReceivingTransferVoucher { get; set; }
         decimal ReceivingClearingAmount { get; set; }
         decimal ReceivingClearingVoucher { get; set; }
         decimal DrawingCashAmount { get; set; }
         decimal DrawingCashVoucher { get; set; }
         decimal DrawingTransferAmount{ get; set; }
         decimal DrawingTransferVoucher { get; set; }
         decimal PaymentCashAmount { get; set; }
         decimal PaymentCashVoucher { get; set; }
         decimal PaymentTransferAmount { get; set; }
         decimal PaymentTransferVoucher { get; set; }
         decimal PaymentClearingAmount { get; set; }
         decimal PaymentClearingVoucher { get; set; }
         decimal EncashCashAmount { get; set; }
         decimal EncashCashVoucher { get; set; }
         decimal EncashTransferAmount { get; set; }
         decimal EncashTransferVoucher { get; set; }
         decimal CashInHand { get; set; }
         decimal CashWithCBM { get; set; }
         decimal CashWithOtherBank { get; set; }
         decimal CurrentACOpen { get; set; }
         decimal SavingACOpen { get; set; }
         decimal CallDepositACOpen { get; set; }
         decimal FixDepositACOpen{ get; set; }
         decimal CurrentACClose { get; set; }
         decimal SavingACClose { get; set; }
         decimal CallDepositACCLose { get; set; }
         decimal FixedDepositACClose { get; set; }
         decimal CurrentACTotal { get; set; }
         decimal SavingACTotal { get; set; }
         decimal CallDepositTotal { get; set; }
         decimal FixedDepositTotal { get; set; }
         decimal OpeningBalanceCurrent { get; set; }
         decimal OpeningBalanceSaving { get; set; }
         decimal OpeningBanlaceCallDeposit { get; set; }
         decimal OpeningBalanceFixedDeposit { get; set; }
         decimal DepositCurrent { get; set; }
         decimal DepositSaving { get; set; }
         decimal DepositCallDeposit { get; set; }
         decimal DepositFixedDeposit { get; set; }
         decimal WithdrawalCurrent { get; set; }
         decimal WithdrawalSaving { get; set; }
         decimal WithdrawalCallDeposit { get; set; }
         decimal WithdrawalFixedDeposit { get; set; }
   }
}
