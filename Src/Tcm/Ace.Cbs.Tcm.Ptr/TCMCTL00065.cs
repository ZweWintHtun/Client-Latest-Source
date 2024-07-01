//----------------------------------------------------------------------
// <copyright file="TCMCTL00065.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-02-10</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
namespace Ace.Cbs.Tcm.Ptr
{
   public class TCMCTL00065:AbstractPresenter,ITCMCTL00065
    {
        #region INITIALIZE VIEW
        private ITCMVEW00065 view;
        public ITCMVEW00065 DailyReportListingModifyView
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00065 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }
        #endregion

        #region Methods
        public TCMDTO00052 GetDailyReport(bool isFormLoad,TCMDTO00052 drDTO)
        {
            TCMDTO00052 dailyReportDTO = new TCMDTO00052();
            string bUDMONTH = "M" + Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode,this.DailyReportListingModifyView.PostDate));           
            if (isFormLoad == true)
            {
                dailyReportDTO = CXClientWrapper.Instance.Invoke<ITCMSVE00065, TCMDTO00052>(x => x.SelectDailyReport(drDTO, this.DailyReportListingModifyView.PostDate,this.DailyReportListingModifyView.Currency, bUDMONTH,CurrentUserEntity.CurrentUserID));
            }
            else
            {
               CXClientWrapper.Instance.Invoke<ITCMSVE00065>(x => x.SaveorUpdateDailyReport(drDTO, this.DailyReportListingModifyView.PostDate,this.DailyReportListingModifyView.Currency,bUDMONTH,false,CurrentUserEntity.CurrentUserID));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            }           
            return dailyReportDTO;
        }
        public TCMDTO00052 GetViewData()
        {
            TCMDTO00052 dailyreportDTO = new TCMDTO00052();
            dailyreportDTO.RECEIPTCASH = this.DailyReportListingModifyView.ReceivingCashAmount;
            dailyreportDTO.RECEIPTCASHVOU = this.DailyReportListingModifyView.ReceivingCashVoucher;
            dailyreportDTO.CUR = this.DailyReportListingModifyView.Currency;               
            dailyreportDTO.RECEIPTTRANSFER=this.DailyReportListingModifyView.ReceivingTransferAmount;
            dailyreportDTO.RECEIPTTRANSFERVOU=this.DailyReportListingModifyView.ReceivingTransferVoucher;
            dailyreportDTO.RECEIPTCLEARING=this.DailyReportListingModifyView.ReceivingClearingAmount;
            dailyreportDTO.RECEIPTCLEARINGVOU=this.DailyReportListingModifyView.ReceivingClearingVoucher;
            dailyreportDTO.DRAWINGCASH=this.DailyReportListingModifyView.DrawingCashAmount;
            dailyreportDTO.DRAWINGCASHVOU=this.DailyReportListingModifyView.DrawingCashVoucher;
            dailyreportDTO.DRAWINGTRANSFER=this.DailyReportListingModifyView.DrawingTransferAmount;
            dailyreportDTO.DRAWINGTRANSFERVOU=this.DailyReportListingModifyView.DrawingTransferVoucher;
            dailyreportDTO.PAYMENTCASH=this.DailyReportListingModifyView.PaymentCashAmount;
            dailyreportDTO.PAYMENTCASHVOU=this.DailyReportListingModifyView.PaymentCashVoucher;
            dailyreportDTO.PAYMENTTRANSFER=this.DailyReportListingModifyView.PaymentTransferAmount;
            dailyreportDTO.PAYMENTTRANSFERVOU=this.DailyReportListingModifyView.PaymentTransferVoucher;
            dailyreportDTO.PAYMENTCLEARING=this.DailyReportListingModifyView.PaymentClearingAmount;
            dailyreportDTO.PAYMENTCLEARINGVOU=this.DailyReportListingModifyView.PaymentClearingVoucher;
            dailyreportDTO.ENCASHCASH=this.DailyReportListingModifyView.EncashCashAmount;
            dailyreportDTO.ENCASHCASHVOU=this.DailyReportListingModifyView.EncashCashVoucher;

            dailyreportDTO.CASHINHAND = this.DailyReportListingModifyView.CashInHand;
            dailyreportDTO.CASHWITHCBM=this.DailyReportListingModifyView.CashWithCBM;
            dailyreportDTO.ACWITHOTHBANK=this.DailyReportListingModifyView.CashWithOtherBank;
            dailyreportDTO.CUROPENED=this.DailyReportListingModifyView.CurrentACOpen;
            dailyreportDTO.CURCLOSED=this.DailyReportListingModifyView.CurrentACClose;
            dailyreportDTO.CURTOTAL=this.DailyReportListingModifyView.CurrentACTotal;
            dailyreportDTO.CUROBAL=this.DailyReportListingModifyView.OpeningBalanceCurrent;
            dailyreportDTO.CURDEP=this.DailyReportListingModifyView.DepositCurrent;
            dailyreportDTO.CURWITH=this.DailyReportListingModifyView.WithdrawalCurrent;
            dailyreportDTO.SAVOPENED=this.DailyReportListingModifyView.SavingACOpen;
            dailyreportDTO.SAVCLOSED=this.DailyReportListingModifyView.SavingACClose;
            dailyreportDTO.SAVTOTAL=this.DailyReportListingModifyView.SavingACTotal;
            dailyreportDTO.SAVOBAL=this.DailyReportListingModifyView.OpeningBalanceSaving;
            dailyreportDTO.SAVDEP=this.DailyReportListingModifyView.DepositSaving;
            dailyreportDTO.SAVWITH=this.DailyReportListingModifyView.WithdrawalSaving;
            dailyreportDTO.CALOPENED=this.DailyReportListingModifyView.CallDepositACOpen;
            dailyreportDTO.CALCLOSED=this.DailyReportListingModifyView.CallDepositACCLose;
            dailyreportDTO.CALTOTAL=this.DailyReportListingModifyView.CallDepositTotal;
            dailyreportDTO.CALOBAL=this.DailyReportListingModifyView.OpeningBanlaceCallDeposit;
            dailyreportDTO.CALDEP=this.DailyReportListingModifyView.DepositCallDeposit;
            dailyreportDTO.CALWITH=this.DailyReportListingModifyView.WithdrawalCallDeposit;
            dailyreportDTO.FIXOPENED=this.DailyReportListingModifyView.FixDepositACOpen;
            dailyreportDTO.FIXCLOSED=this.DailyReportListingModifyView.FixedDepositACClose;
            dailyreportDTO.FIXTOTAL=this.DailyReportListingModifyView.FixedDepositTotal;
            dailyreportDTO.FIXOBAL=this.DailyReportListingModifyView.OpeningBalanceFixedDeposit;
            dailyreportDTO.FIXDEP=this.DailyReportListingModifyView.DepositFixedDeposit;
            dailyreportDTO.FIXWITH=this.DailyReportListingModifyView.WithdrawalFixedDeposit;
            dailyreportDTO.DATE_TIME = this.DailyReportListingModifyView.PostDate;
            dailyreportDTO.UpdatedDate = DateTime.Now;
            dailyreportDTO.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            return dailyreportDTO;
        }
        #endregion
    }
}
