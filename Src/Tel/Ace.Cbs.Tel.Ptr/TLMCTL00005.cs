//----------------------------------------------------------------------
// <copyright file="TLMCTL00005.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate>07/12/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
   public class TLMCTL00005 : AbstractPresenter, ITLMCTL00005
    
    {
        private decimal AdjustAmount { get ; set ;}
        private ITLMVEW00005 view;

        public ITLMVEW00005 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }


        private void WireTo(ITLMVEW00005 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view,this.view.ViewData);
              

            }
        }

        public void ClearControls()
        {
            this.view.EntryNo = string.Empty;
            //this.view.CurrencyCode = string.Empty;
            this.view.Amount = 0;

        }        

        private TLMDTO00015 GetCounterWithdrawEntity(CXDTO00001 getdenostring)
        {
            TLMDTO00015 counterWithdrawl = new TLMDTO00015();
            if (getdenostring != null)
            {
                counterWithdrawl.FromType = this.view.Center;
                counterWithdrawl.CounterNo = this.view.CounterNo;
                counterWithdrawl.Amount = this.view.Amount;
                counterWithdrawl.AdjustAmount = getdenostring.AdjustAmount;
                counterWithdrawl.Currency = this.view.CurrencyCode;
                counterWithdrawl.SourceBranchCode = CXCOM00007.Instance.BranchCode;
                counterWithdrawl.CreatedUserId = CurrentUserEntity.CurrentUserID;
                counterWithdrawl.CreatedDate = DateTime.Now;
                counterWithdrawl.DenoDetail = getdenostring.DenoString;
                counterWithdrawl.DenoRate = getdenostring.DenoRateString;
                counterWithdrawl.DenoRefundDetail = getdenostring.RefundString;
                counterWithdrawl.DenoRefundRate = getdenostring.RefundRateString;
                counterWithdrawl.AdjustAmount = this.AdjustAmount;
                counterWithdrawl.UserNo = Convert.ToString(CurrentUserEntity.CurrentUserID);

            }
            return counterWithdrawl;
        }

        public void Save()
        {
            if (!this.ValidateForm(this.view.ViewData)) 
                return;
            if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.view.Amount, this.View.CurrencyCode, CXDMD00008.Received, "frmTLMVEW00005" }) == DialogResult.OK)
            {                
                TLMDTO00015 counterWithdrawlEntity = this.GetCounterWithdrawEntity(CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00005"));
                decimal AdjustAmount = counterWithdrawlEntity.AdjustAmount.Value;
                string EntrtyNo = CXClientWrapper.Instance.Invoke<ITLMSVE00005, string>(x => x.Save(counterWithdrawlEntity));
                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    string[] logItemForDeno = new string[14];
                    //ClientLog For Deno
                    logItemForDeno[0] = EntrtyNo;//Tlf_Eno
                    logItemForDeno[1] = counterWithdrawlEntity.AccountNo;//AcType
                    logItemForDeno[2] = counterWithdrawlEntity.FromType;//FromType
                    logItemForDeno[3] = counterWithdrawlEntity.Amount.ToString();//Amount
                    logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                    logItemForDeno[5] = counterWithdrawlEntity.DenoDetail;//Deno_Detail
                    logItemForDeno[6] = counterWithdrawlEntity.DenoRefundDetail;//DenoRefund_Detail
                    logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);//Status
                    logItemForDeno[8] = "0";//REVERSE
                    logItemForDeno[9] = counterWithdrawlEntity.SourceBranchCode;//sourcebr
                    logItemForDeno[10] = counterWithdrawlEntity.Currency;//cur
                    logItemForDeno[11] = counterWithdrawlEntity.DenoRate;//DenoRate
                    logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), counterWithdrawlEntity.SourceBranchCode).ToString();//SettlementDate
                    logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(counterWithdrawlEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Counter Withdrawl Fail Deno", CurrentUserEntity.BranchCode,
                    logItemForDeno);
                    this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion

                #region Successful
                else
                {
                    string[] logItemForDeno = new string[14];
                    //ClientLog For Deno
                    logItemForDeno[0] = EntrtyNo;//Tlf_Eno
                    logItemForDeno[1] = counterWithdrawlEntity.AccountNo;//AcType
                    logItemForDeno[2] = counterWithdrawlEntity.FromType;//FromType
                    logItemForDeno[3] = counterWithdrawlEntity.Amount.ToString();//Amount
                    logItemForDeno[4] = counterWithdrawlEntity.CreatedDate.ToString();//Cash_Date
                    logItemForDeno[5] = counterWithdrawlEntity.DenoDetail;//Deno_Detail
                    logItemForDeno[6] = counterWithdrawlEntity.DenoRefundDetail;//DenoRefund_Detail
                    logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);//Status
                    logItemForDeno[8] = "0";//REVERSE
                    logItemForDeno[9] = counterWithdrawlEntity.SourceBranchCode;//sourcebr
                    logItemForDeno[10] = counterWithdrawlEntity.Currency;//cur
                    logItemForDeno[11] = counterWithdrawlEntity.DenoRate;//DenoRate
                    logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), counterWithdrawlEntity.SourceBranchCode).ToString();//SettlementDate
                    logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(counterWithdrawlEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Counter Withdrawl Commit Deno", CurrentUserEntity.BranchCode,
                    logItemForDeno);
                    this.view.EntryNo = EntrtyNo;
                    this.view.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion
                this.ClearControls();
            }
            else
                return;
        }

        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 26-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }
      
   }
}

