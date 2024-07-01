using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using System.Windows.Forms;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00078 : AbstractPresenter, ITLMCTL00078
    {
        #region "Wire To"
        private ITLMVEW00078 view;
        public ITLMVEW00078 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00078 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        #endregion

        #region "Validation Methods"

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void txtEntryNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    PFMDTO00054 tlDTO = CXClientWrapper.Instance.Invoke<ITLMSVE00075, PFMDTO00054>(x => x.isValidEntryNo(this.View.Eno, CurrentUserEntity.BranchCode));
                    if (tlDTO == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }
                    else if (tlDTO.Amount == 0)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), "MI30016");
                        return;
                    }
                    else
                    {
                        this.view.AccountNo = tlDTO.AccountNo;
                        this.view.Description = tlDTO.ReceiptNo;
                        this.view.PoNo = tlDTO.OtherBankChq;
                        this.view.Currency = tlDTO.OtherBank;
                        this.view.Amount = tlDTO.Amount;
                        this.view.status = tlDTO.Status;

                        this.view.EnableDisableControls(false);
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), "MI30016"); //Invalid Entry No.
                }

                // this.SetFocus("txtEntryNo");
            }
            else
            { return; }
        }

        #endregion

        #region "Private Methods"
        private PFMDTO00054 GetCashPaymentDenomination()
        {
            PFMDTO00054 cashdenoEntity = new PFMDTO00054();
            try
            {
                cashdenoEntity.Eno = this.view.Eno;
                cashdenoEntity.AccountNo = this.view.AccountNo;
                cashdenoEntity.Description = this.view.Description;
                cashdenoEntity.PaymentOrderNo = this.view.PoNo;
                cashdenoEntity.CurrencyCode = this.view.Currency;
                cashdenoEntity.Amount = this.view.Amount;
                cashdenoEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                cashdenoEntity.SourceBranchCode = CurrentUserEntity.BranchCode;
                //cashdenoEntity.UserNo = CurrentUserEntity.CurrentUserName;
                cashdenoEntity.UserNo = CurrentUserEntity.CurrentUserID.ToString();
            }
            catch
            {
                throw new Exception(CXMessage.ME00021);
            }
            return cashdenoEntity;
        }

        private PFMDTO00054 GetEntity()
        {
            PFMDTO00054 cashdenoEntity = new PFMDTO00054();
            cashdenoEntity.Eno = this.view.Eno;
            return cashdenoEntity;
        }

        private CXDTO00001 GetDenoList()
        {
            //if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.view.Amount, this.view.Currency, CXDMD00008.Payment, "frmTLMVEW00016" }) == DialogResult.OK)
            //{
            //    return CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00016");

            //}
            if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.view.Amount, this.view.Currency, CXDMD00008.Payment, "TLMVEW00078" }) == DialogResult.OK)
            {
                return CXUIScreenTransit.GetData<CXDTO00001>("TLMVEW00078");
            }
            else
            {
                ////Error Occur becoz user don't enter deno entry but close the deno form.
                this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                return null;
            }
        }
        #endregion

        #region "Public Methods"

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

        public void Save()
        {
            PFMDTO00054 cashdenoDTO = this.GetCashPaymentDenomination();
            cashdenoDTO.VoucherStatus = this.view.status;
            if (this.ValidateForm(GetEntity()))
            {
                CXDTO00001 denoString = this.GetDenoList();
                if (denoString == null)
                    return;
                else
                {
                    // PFMDTO00054 cashdenoDTO = this.GetCashPaymentDenomination();
                    CXClientWrapper.Instance.Invoke<ITLMSVE00075>(x => x.SaveorUpdate(cashdenoDTO, denoString));
                    #region Failure Transcation
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        string[] logItemForDeno = new string[14];

                        //ClientLog For Deno
                        logItemForDeno[0] = cashdenoDTO.Eno;//Tlf_Eno
                        logItemForDeno[1] = cashdenoDTO.AccountNo;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = cashdenoDTO.Amount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = denoString.DenoString;//Deno_Detail
                        logItemForDeno[6] = denoString.RefundString;//DenoRefund_Detail
                        logItemForDeno[7] = string.Empty;//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = cashdenoDTO.SourceBranchCode;//sourcebr
                        logItemForDeno[10] = cashdenoDTO.CurrencyCode;//cur
                        logItemForDeno[11] = denoString.DenoRateString;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), cashdenoDTO.SourceBranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(cashdenoDTO.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "CashPayment Fail Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);
                        //Saving Error.
                        this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    #endregion

                    #region Successful Transcation
                    else
                    {
                        string[] logItemForDeno = new string[14];

                        //ClientLog For Deno
                        logItemForDeno[0] = cashdenoDTO.Eno;//Tlf_Eno
                        logItemForDeno[1] = cashdenoDTO.AccountNo;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = cashdenoDTO.Amount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = denoString.DenoString;//Deno_Detail
                        logItemForDeno[6] = denoString.RefundString;//DenoRefund_Detail
                        logItemForDeno[7] = string.Empty;//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = cashdenoDTO.SourceBranchCode;//sourcebr
                        logItemForDeno[10] = cashdenoDTO.CurrencyCode;//cur
                        logItemForDeno[11] = denoString.DenoRateString;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), cashdenoDTO.SourceBranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(cashdenoDTO.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "CashPayment Commit Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);
                        //Saving Successful.
                        this.View.Successful(CXMessage.MI90001);
                    }
                    #endregion
                    //this.View.InitailizeControls();
                }
                //}
                //else
                //{
                //    this.view.EntryNoSetFocus();
                //}          
            }
            this.view.EnableDisableControls(true);
        }
        #endregion
    }
}
