//----------------------------------------------------------------------
// <copyright file="TLMCTL00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>09/06/2013</CreatedDate>
// <UpdatedUser>Hsu Wai Htoo</UpdatedUser>
// <UpdatedDate>2013-10-11</UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// Vault Withdrawl Denomination Entry Controller
    /// </summary>
    public class TLMCTL00004 : AbstractPresenter, ITLMCTL00004
    {
        #region "Wire To"
        private ITLMVEW00004 view;
        public ITLMVEW00004 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00004 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.CashDeno);
            }
        }
        #endregion

        #region Variable
        private decimal DebitAdjustAmount { get; set; }
        private decimal CreditAdjustAmount { get; set; }
        private CXDTO00001 DebitDenoString { get; set; }
        private CXDTO00001 CreditDenoString { get; set; }       
        private string _counterNo { get; set; }
        #endregion

        #region UI Logic
        public void ClearControls()
        {
            this.View.DebitEno = string.Empty;
            this.View.CreditEno = string.Empty;
            //this.View.Currency = string.Empty;
            this.View.DebitFrom = string.Empty; 
            this.View.DebitAmount = 0;
            this.View.CreditAmount = 0;
            this.View.CreditTo = string.Empty; 
            this.View.EnableDisableSaveButton(true);
            this.ClearAllCustomErrorMessage();
        }

        /* This Method is used to define Payment or Received in Deno Form Load */
        private CXDTO00001 GetDenoList(decimal amount, CXDMD00008 status)
        {
            if (CXUIScreenTransit.Transit("frmTLMVEW00011",true, new object[] { amount, this.View.Currency,status, "frmTLMVEW00004" }) == DialogResult.OK)
            {
                return CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00004");
            }
            else
            {
                //Error Occur becoz user don't enter deno entry but close the deno form.
                this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                return null;
            }
        }
        public void Save()
        {
            if (this.ValidateForm(this.View.CashDeno))
            { 
            if (View.DebitAmount <= 0 || View.CreditAmount <= 0 || View.Currency == null || View.DebitFrom == null || View.CreditTo == null)
            {
               
            }
            else
            {
                try
                {
                    this.DebitDenoString = this.GetDenoList(this.View.DebitAmount, CXDMD00008.Payment);

                    this.DebitAdjustAmount = this.DebitDenoString.AdjustAmount;
                    if (this.DebitDenoString.Equals(null))
                        return;

                    if (this.View.CreditAmount > 0 && (this.View.CreditAmount != this.View.DebitAmount))
                    {
                        if (this.View.CreditAmount < this.View.DebitAmount || this.View.DebitAmount < this.View.CreditAmount)
                        {
                            this.CreditDenoString = this.GetDenoList(this.View.CreditAmount, CXDMD00008.Received);
                        }
                        else
                        {
                            this.CreditDenoString = this.GetDenoList(this.View.CreditAmount, CXDMD00008.Non);
                        }
                        this.CreditAdjustAmount = this.CreditDenoString.AdjustAmount;
                        if (this.CreditDenoString.Equals(null))
                            return;
                    }
                    IList<TLMDTO00015> cashDenoList = this.GetCashDenoEntity();
                    TLMDTO00015 cashDenoEno = CXClientWrapper.Instance.Invoke<ITLMSVE00004, TLMDTO00015>(x => x.Save(cashDenoList));

                    #region ErrorOccurred
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        for (int i = 0; i < cashDenoList.Count; i++)
                        {

                            string paymentCashStatus = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);
                            string[] logItemForDeno = new string[14];

                            //ClientLog For Deno
                            if (cashDenoList[i].Status.Equals(paymentCashStatus))
                                logItemForDeno[0] = cashDenoList[i].DebitEno;//Tlf_Eno
                            else if (cashDenoList[i].Status != (paymentCashStatus))
                                logItemForDeno[0] = cashDenoList[i].CreditEno;//Tlf_Eno
                            logItemForDeno[1] = cashDenoList[i].AccountType;//AcType
                            logItemForDeno[2] = cashDenoList[i].FromType;//FromType
                            logItemForDeno[3] = cashDenoList[i].Amount.ToString();//Amount
                            logItemForDeno[4] = string.Empty;//Cash_Date
                            logItemForDeno[5] = cashDenoList[i].DenoDetail;//Deno_Detail
                            logItemForDeno[6] = cashDenoList[i].DenoRefundDetail;//DenoRefund_Detail
                            logItemForDeno[7] = cashDenoList[i].Status;//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = cashDenoList[i].SourceBranchCode;//sourcebr
                            logItemForDeno[10] = cashDenoList[i].Currency;//cur
                            logItemForDeno[11] = cashDenoList[i].DenoRate;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), cashDenoList[i].SourceBranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(cashDenoList[0].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Vault Withdrawl Fail Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);
                        }
                        this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    #endregion

                    #region
                    else
                    {
                        for (int i = 0; i < cashDenoList.Count; i++)
                        {

                            string paymentCashStatus = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);
                            string[] logItemForDeno = new string[14];

                            //ClientLog For Deno
                            if (cashDenoList[i].Status.Equals(paymentCashStatus))
                                logItemForDeno[0] = cashDenoEno.DebitEno;//Tlf_Eno
                            else if (cashDenoList[i].Status != (paymentCashStatus))
                                logItemForDeno[0] = cashDenoEno.CreditEno;//Tlf_Eno
                            logItemForDeno[1] = cashDenoList[i].AccountType;//AcType
                            logItemForDeno[2] = cashDenoList[i].FromType;//FromType
                            logItemForDeno[3] = cashDenoList[i].Amount.ToString();//Amount
                            logItemForDeno[4] = cashDenoList[i].CashDate.ToString();//Cash_Date
                            logItemForDeno[5] = cashDenoList[i].DenoDetail;//Deno_Detail
                            logItemForDeno[6] = cashDenoList[i].DenoRefundDetail;//DenoRefund_Detail
                            logItemForDeno[7] = cashDenoList[i].Status;//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = cashDenoList[i].SourceBranchCode;//sourcebr
                            logItemForDeno[10] = cashDenoList[i].Currency;//cur
                            logItemForDeno[11] = cashDenoList[i].DenoRate;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), cashDenoList[i].SourceBranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(cashDenoList[0].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Vault Withdrawl Commit Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);
                        }
                        //Bind Generated Entry No
                        this.View.DebitEno = cashDenoEno.DebitEno;
                        this.View.CreditEno = cashDenoEno.CreditEno;

                        //Saving Successful.
                        this.View.Successful(CXMessage.MI90001);

                        // Clear all controls
                        this.ClearControls();
                    }
                    #endregion
                }
                catch
                {
                }
            }
          }
            
        }
        #endregion
      
        #region Helper Methods        
        
        private IList<TLMDTO00015> GetCashDenoEntity()
        {
            IList<TLMDTO00015> cashDenoList = new List<TLMDTO00015>();
            IList<TLMDTO00013> creditlist = new List<TLMDTO00013>();
            creditlist = this.View.FfromCashSetupList;
          
            TLMDTO00015 debitFromEntity = new TLMDTO00015();
            debitFromEntity.AccountType = this.view.isDebitCounterCheck ? null : this.View.DebitFrom;
            debitFromEntity.FromType = this.view.isCreditCounterCheck ? this.View.DebitFrom : this.View.ToTypeSelectedText;

            #region "Comments"
            //if (this.view.isDebitCounterCheck == true)
            //{
            //    debitFromEntity.AccountType = null;
            //}
            //else
            //{
            //    debitFromEntity.AccountType = this.View.DebitFrom;
            //}

            //if (this.view.isCreditCounterCheck == false)
            //{
            //    debitFromEntity.FromType = this.View.ToTypeSelectedText;
            //}
            //else
            //{
            //    debitFromEntity.FromType = this.View.DebitFrom;
            //}
            #endregion

            for (int i = 0; i < creditlist.Count; i++)
            {
                if (debitFromEntity.FromType == creditlist[i].CashCode)
                {
                    debitFromEntity.FromType = creditlist[i].Description;
                }
            }
            if (this.view.isCreditCounterCheck == true && this.view.isDebitCounterCheck == false)
            {
                debitFromEntity.FromType = this.View.ToTypeSelectedText;
                //Payment Cashier's Transit Book to Box Balance Register (Vault Withdraw Denomination Entry)
                if (this.view.ToTypeSelectedText == "VB0000")
                {
                    for (int i = 0; i < creditlist.Count; i++)
                    {
                        if (this.view.ToTypeSelectedText == creditlist[i].CashCode)
                        {
                            debitFromEntity.FromType = creditlist[i].Description;
                        }
                    }
                }                
            }
            debitFromEntity.Amount = this.View.DebitAmount;
            debitFromEntity.Currency = this.View.Currency;
            debitFromEntity.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);
            debitFromEntity.SourceBranchCode = this.View.BranchCode;
            debitFromEntity.CounterNo = this.View.isDebitCounterCheck ? this.View.DebitFrom : string.Empty;           
            debitFromEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            debitFromEntity.DenoDetail = this.DebitDenoString.DenoString;
            debitFromEntity.DenoRate = this.DebitDenoString.DenoRateString;
            debitFromEntity.DenoRefundDetail = this.DebitDenoString.RefundString;
            debitFromEntity.DenoRefundRate = this.DebitDenoString.RefundRateString;
            debitFromEntity.AdjustAmount = this.DebitAdjustAmount;
            cashDenoList.Add(debitFromEntity);
            if (this.View.CreditAmount > 0)
            {
                IList<TLMDTO00013> debitlist = new List<TLMDTO00013>();
                IList<CounterInfoDTO> debitlistCounter = new List<CounterInfoDTO>(); 
                debitlist = this.View.FfromCashSetupList;
                debitlistCounter = this.View.toCashSetupList;
                TLMDTO00015 creditToEntity = new TLMDTO00015();
                creditToEntity.FromType = this.View.FromTypeSelectedText;
                if (this.view.isCreditCounterCheck == true && this.view.isDebitCounterCheck == false)
                {
                    creditToEntity.FromType = this.View.DebitFrom;
                    for (int i = 0; i < debitlist.Count; i++)
                    {
                        if (creditToEntity.FromType == debitlist[i].CashCode)
                        {
                            creditToEntity.FromType = debitlist[i].Description;
                        }
                    }
                }

                for (int i = 0; i < debitlistCounter.Count; i++)
                {
                    if (creditToEntity.FromType == debitlistCounter[i].CounterNo)
                    {
                        creditToEntity.FromType = debitlistCounter[i].Description;
                    }
                }

                if (this.view.isCreditCounterCheck == true)
                {
                    debitlistCounter = this.View.toCashSetupList;
                    creditToEntity.AccountType = null;
                    if (debitFromEntity.Status == "P" && debitFromEntity.FromType == "Box Balance Register")
                    {
                        creditToEntity.AccountType = this.view.CreditTo;
                    }                    
                }             

                else
                {
                    for (int i = 0; i < debitlist.Count; i++)
                    {
                        if (creditToEntity.FromType == debitlist[i].CashCode)
                        {
                            creditToEntity.FromType = debitlist[i].Description;
                        }
                    }
                    creditToEntity.AccountType = this.View.CreditTo;
                    if (this.view.isCreditCounterCheck == false && this.view.isBranchCheck==true)
                    {
                        creditToEntity.AccountType = null;
                    }
                }
               
                creditToEntity.Amount = this.View.CreditAmount;
                creditToEntity.Currency = this.View.Currency;
                creditToEntity.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);
                creditToEntity.SourceBranchCode = this.View.BranchCode;
                creditToEntity.CounterNo = this.View.isCreditCounterCheck ? this.View.CreditTo : string.Empty;

                #region "Comments"
                //if (this.View.isCreditCounterCheck)
                //    creditToEntity.CounterNo = this.View.CreditTo;
                //else
                //    creditToEntity.CounterNo = string.Empty;
                #endregion

                creditToEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                creditToEntity.AdjustAmount = this.CreditAdjustAmount;
                if (this.View.CreditAmount != this.View.DebitAmount)
                {
                    creditToEntity.DenoDetail = this.CreditDenoString.DenoString;
                    creditToEntity.DenoRate = this.CreditDenoString.DenoRateString;
                    creditToEntity.DenoRefundDetail = this.CreditDenoString.RefundString;
                    creditToEntity.DenoRefundRate = this.CreditDenoString.RefundRateString;
                }
                else
                {
                    creditToEntity.DenoDetail = this.DebitDenoString.DenoString;
                    creditToEntity.DenoRate = this.DebitDenoString.DenoRateString;
                    creditToEntity.DenoRefundDetail = this.DebitDenoString.RefundString;
                    creditToEntity.DenoRefundRate = this.DebitDenoString.RefundRateString;
                }
                cashDenoList.Add(creditToEntity);
            }
            return cashDenoList;
        }

        //To get All Counters by Source Branch Code in database.
        public IList<CounterInfoDTO> GetAllCounterListBySourceBranchCode(string sourceBranchCode)
        {
            IList<CounterInfoDTO> CounterList = new List<CounterInfoDTO>();
            CounterList = CXClientWrapper.Instance.Invoke<ITLMSVE00004, CounterInfoDTO>(x => x.GetAllCounterInfoListBySourceBranchCode(sourceBranchCode));
            return CounterList;
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
        #endregion

        #region Validation Logic

        public void ntxtDebitFromAmount_CustomValidate(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
               // this.View.BindToComboBox();
                this.View.CboToEnable = true;
            }

        }
        public void ntxtDebitFromAmount_CustomValidate()
        {
            if (this.view.DebitAmount.ToString().StartsWith(decimal.Zero.ToString()) && !String.IsNullOrEmpty(this.view.DebitAmount.ToString()))
            {
                this.SetCustomErrorMessage(this.GetControl("ntxtDebitFromAmount"), CXMessage.MV00098);//Invalid  Register No.
 
                return;
            }
            else
            { 
                this.View.CboToEnable = true;  
                this.ClearErrors();
            }

        }
        public void ntxtCreditToAmount_CustomValidate()
        {
            if (this.view.CreditAmount.ToString().StartsWith(decimal.Zero.ToString()) && !String.IsNullOrEmpty(this.view.CreditAmount.ToString()))
            {
                this.SetCustomErrorMessage(this.GetControl("ntxtDebitFromAmount"), CXMessage.MV00206);//Invalid  Register No.

                return;
            }
            else
            {
                this.View.CboToEnable = true;
                this.ClearErrors();
            }

        }

        //public void cboFrom_CustomValidate(object sender, ValidationEventArgs e)
        //{
        //    if (e.HasXmlBaseError == false)
        //    {
        //    }
        //       // if (this.view.Currency != null)
        //        //{
        //        //    if (this.View.DebitFrom == null)
        //        //        return;
        //        //    this.View.EnableDisabledToCombo(false);
        //        //    this.View.EnableDisableSaveButton(true);
        //        //    if (View.isDebitVaultCheck)
        //        //    {
        //        //        if ((View.DebitFrom == this._boxBalanceRegisterCashCode) || (this.DebitFrom == this._centerTableCashCode))
        //        //        {
        //        //            this.rdoCreditVault.Enabled = true;
        //        //            View.isCreditVaultCheck= true;
        //        //            this.rdoCreditCounter.Enabled = false;
        //        //            this.rdoCreditBranch.Enabled = false;
        //        //        }
        //        //        else if (View.DebitFrom == this._receiveCashierTransitBookCashCode)
        //        //        {
        //        //            this.rdoCreditCounter.Enabled = true;
        //        //            this.rdoCreditCounter.Checked = true;
        //        //            this.rdoCreditBranch.Enabled = false;
        //        //            this.rdoCreditVault.Enabled = false;
        //        //        }
        //        //        else if (this.DebitFrom == this._paymentCashierTransitBookCashCode)
        //        //        {
        //        //            this.rdoCreditCounter.Enabled = true;
        //        //            this.rdoCreditCounter.Checked = true;
        //        //            this.rdoCreditBranch.Enabled = false;
        //        //            this.rdoCreditVault.Enabled = true;
        //        //        }
        //        //        else if (this.DebitFrom == this._totalVaultBookCashCode)
        //        //        {
        //        //            this.rdoCreditVault.Enabled = true;
        //        //            if (this.rdoCreditBranch.Checked == true)
        //        //            {
        //        //                this.rdoCreditBranch.Checked = true;
        //        //            }
        //        //            else
        //        //            {
        //        //                this.rdoCreditVault.Checked = true;
        //        //            }
        //        //            this.rdoCreditCounter.Enabled = false;
        //        //            this.rdoCreditBranch.Enabled = true;
        //        //        }
        //        //    }
        //        //    else if (this.rdoDebitCounter.Checked)
        //        //    {
        //        //        this.rdoCreditVault.Enabled = true;
        //        //        this.rdoCreditVault.Checked = true;
        //        //        this.rdoCreditCounter.Enabled = false;
        //        //        this.rdoCreditBranch.Enabled = false;
        //        //    }
        //        //    this.ntxtDebitFromAmount.Focus();
        //        //}
            
        //   // }
        //}
        

        #endregion
    }
}
