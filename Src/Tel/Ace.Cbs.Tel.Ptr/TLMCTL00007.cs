//----------------------------------------------------------------------
// <copyright file="TLMCTL00007.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using System.Linq;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// PO Receipt Controller
    /// </summary>
   public class TLMCTL00007:AbstractPresenter,ITLMCTL00007
   {
       #region "Variable and Properties"

       private decimal exchangeRate = 0;
       private ITLMVEW00007 poreceiptview;
       public ITLMVEW00007 POReceiptView
       {
          get { return this.poreceiptview; }
          set { this.WireTo(value); }
       }
       public TLMDTO00016 PODTO { get; set; }
      
       #endregion

       #region "Wire To"
        private void WireTo(ITLMVEW00007 view)
        {
            if (this.poreceiptview == null)
            {
                this.poreceiptview = view;
                this.Initialize(this.poreceiptview, this.GetPOReceiptEntity());
            }
        }

        #endregion             

       #region "Validation Methods"

        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }
        public void txtBudgetYear_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }           
            if (this.POReceiptView.PaymentOrderNo == "PO")
            {
                this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MV00103");/*Invalid PO No.*/
                return;
            }
           else if (this.GetPOByPoNoandBudgetYear() == null)
            {
                if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00143") /*This P.O No. {0} is already received.*/
                {
                    this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), CXMessage.MV00143, new object[] { this.POReceiptView.PaymentOrderNo });
                }
                else  if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00219")
                {
                    this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), CXMessage.MV00219);/*PO No. Not Found.*/
                }
                else if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00104")/*Invalid Budget for this P.O.*/
                {
                    this.SetCustomErrorMessage(this.GetControl("txtBudgetYear"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.POReceiptView.BudgetYearInitializeControls();
                }
            }    
            else
            {
                this.poreceiptview.Currency = PODTO.Currency;
                //this.poreceiptview.Amount = PODTO.Amount;
            }            
        }

        public void txtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }

            if(this.PODTO.Amount!=this.poreceiptview.Amount)
            {
                this.SetCustomErrorMessage(this.GetControl("txtAmount"),CXMessage.MV00037);
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), string.Empty);
            }          
        }

        #endregion

       #region "Public Methods"

        public void Save()
        {
            try
            {               
                if (this.ValidateForm(this.GetViewData()))
                {
                    TLMDTO00045 POReceipt = this.GetPOReceiptEntity();
                    string PONo = CXClientWrapper.Instance.Invoke<ITLMSVE00007, string>(x => x.Save(POReceipt));
                    #region Failure
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = PONo;//EntryNo
                        logItemForTlf[2] = POReceipt.Acode;//AcctNo
                        logItemForTlf[3] = POReceipt.Acode;//ACode(from COASetUp)
                        logItemForTlf[4] = POReceipt.Amount.ToString();//LocalAmount
                        logItemForTlf[5] = POReceipt.SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), POReceipt.SourceBranch).ToString();//SettlementDate
                        logItemForTlf[9] = POReceipt.Status;//Status
                        logItemForTlf[10] = POReceipt.SourceBranch;//SourceBr
                        logItemForTlf[11] = string.Empty;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = string.Empty;//intRate
                        logItemForTlf[15] = string.Empty;//Accured
                        logItemForTlf[16] = string.Empty;//BudenAcc
                        logItemForTlf[17] = string.Empty;//Draccured
                        logItemForTlf[18] = string.Empty;//AccuredStatus
                        logItemForTlf[19] = string.Empty;//ToAccountNo
                        logItemForTlf[20] = string.Empty;//FirstRno
                        logItemForTlf[21] = POReceipt.PaymentOrderNo;//PoNo
                        logItemForTlf[22] = string.Empty;//ADate
                        logItemForTlf[23] = System.DateTime.Now.ToString();//IDate
                        logItemForTlf[24] = string.Empty;//ToAcctNo
                        logItemForTlf[25] = string.Empty;//Income
                        logItemForTlf[26] = POReceipt.Budget;//Budget
                        logItemForTlf[27] = string.Empty;//FromBranch
                        logItemForTlf[28] = string.Empty;//ToBranch
                        logItemForTlf[29] = string.Empty;//Inout
                        logItemForTlf[30] = string.Empty;//Success
                        logItemForTlf[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf[32] = string.Empty;//IncomeType
                        logItemForTlf[33] = POReceipt.OtherBank;//OtherBank
                        logItemForTlf[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Receipt Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                        this.poreceiptview.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    #endregion

                    #region Successful
                    else
                    {
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = PONo;//EntryNo
                        logItemForTlf[2] = POReceipt.Acode;//AcctNo
                        logItemForTlf[3] = POReceipt.Acode;//ACode(from COASetUp)
                        logItemForTlf[4] = POReceipt.Amount.ToString();//LocalAmount
                        logItemForTlf[5] = POReceipt.SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = POReceipt.SettlementDate.ToString();//SettlementDate
                        logItemForTlf[9] = POReceipt.Status;//Status
                        logItemForTlf[10] = POReceipt.SourceBranch;//SourceBr
                        logItemForTlf[11] = string.Empty;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = string.Empty;//intRate
                        logItemForTlf[15] = string.Empty;//Accured
                        logItemForTlf[16] = string.Empty;//BudenAcc
                        logItemForTlf[17] = string.Empty;//Draccured
                        logItemForTlf[18] = string.Empty;//AccuredStatus
                        logItemForTlf[19] = string.Empty;//ToAccountNo
                        logItemForTlf[20] = string.Empty;//FirstRno
                        logItemForTlf[21] = POReceipt.PaymentOrderNo;//PoNo
                        logItemForTlf[22] = string.Empty;//ADate
                        logItemForTlf[23] = System.DateTime.Now.ToString();//IDate
                        logItemForTlf[24] = string.Empty;//ToAcctNo
                        logItemForTlf[25] = string.Empty;//Income
                        logItemForTlf[26] = POReceipt.Budget;//Budget
                        logItemForTlf[27] = string.Empty;//FromBranch
                        logItemForTlf[28] = string.Empty;//ToBranch
                        logItemForTlf[29] = string.Empty;//Inout
                        logItemForTlf[30] = string.Empty;//Success
                        logItemForTlf[31] = string.Empty;//COMMUCHARGE
                        logItemForTlf[32] = string.Empty;//IncomeType
                        logItemForTlf[33] = POReceipt.OtherBank;//OtherBank
                        logItemForTlf[34] = string.Empty;//OtherBankChq
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Receipt Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                        this.poreceiptview.PaySlipNo = PONo;
                        // Generated PO Receipt No is {0}.
                        this.poreceiptview.Successful(CXMessage.MI00003, this.poreceiptview.PaySlipNo);
                        this.poreceiptview.InitializeControls();
                    }
                    #endregion
                    this.ClearControls();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(CXMessage.ME90000);                
            }
        }

        public void ClearControls()
        {
            this.poreceiptview.PaySlipNo = string.Empty;       
            this.poreceiptview.ReceivedAccountNo = string.Empty;
            this.poreceiptview.OtherBank = string.Empty;
            this.poreceiptview.Amount = 0;
            //this.poreceiptview.BudgetYear = string.Empty;
            //this.poreceiptview.Currency = string.Empty;
            this.poreceiptview.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
        }

        public string GetBudYear()
        {
            string Return = string.Empty;
            //DateTime tempDate = Convert.ToDateTime(this.View.RequireYear + "/" + this.View.RequireMonth + "/" + Convert.ToString(DateTime.Now.Day));

            string activeBudget = CXClientWrapper.Instance.Invoke<ITLMSVE00007, string>(x => x.GetBudYear(6, DateTime.Now, CurrentUserEntity.BranchCode));
            return activeBudget;
        }

         #endregion

       #region "Private Methods"

        /*To Get Exchange Rate using CXCOM00010.Instance.GetExchangeRate*/
        private decimal GetExchangRate()
        {
            return this.exchangeRate = CXCOM00010.Instance.GetExchangeRate(this.poreceiptview.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType));
        }

        /*To Get PO Information By PONO and BudgetYear,when PONo Textbox Customvalidating and Budget Year Textbox Custom Validation*/
        private TLMDTO00016 GetPOByPoNoandBudgetYear()
        {
            TLMDTO00016 POEntity = new TLMDTO00016();
            POEntity = CXClientWrapper.Instance.Invoke<ICXSVE00006, TLMDTO00016>(x => x.GetPOByPoNoandBudgetYear(this.poreceiptview.PaymentOrderNo, this.poreceiptview.BudgetYear,CurrentUserEntity.BranchCode));
            PODTO = POEntity;           
            return PODTO;
        }

        /* To Transfer From ViewData To TLMDTO00045 POReceiptEntity.This Method is used Wire To Function*/
        private TLMDTO00045  GetPOReceiptEntity()
        {
            try
            {
                TLMDTO00045 POReceiptEntity = new TLMDTO00045();
                POReceiptEntity.Amount = this.poreceiptview.Amount;
                POReceiptEntity.PaymentOrderNo = this.poreceiptview.PaymentOrderNo;
                POReceiptEntity.HomeAmount = this.poreceiptview.Amount * this.GetExchangRate();
                POReceiptEntity.HomeAmt = this.poreceiptview.Amount * this.GetExchangRate();
                POReceiptEntity.SourceBranch = CXCOM00007.Instance.BranchCode;
                POReceiptEntity.LocalAmount = this.poreceiptview.Amount;
                POReceiptEntity.LocalAmt = this.poreceiptview.Amount;
                POReceiptEntity.Narration = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingPaymentOrderReference) + this.poreceiptview.PaymentOrderNo;
                POReceiptEntity.DateTime = DateTime.Now;
                POReceiptEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                POReceiptEntity.Status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ClearingDebitPaymentOrder);
                POReceiptEntity.TransactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentOrderRefundClearing);
                POReceiptEntity.OtherBank = this.poreceiptview.OtherBank;
                POReceiptEntity.OtherBankAcctNo = this.poreceiptview.ReceivedAccountNo;
                POReceiptEntity.CLRPostStatus = "Y";
                POReceiptEntity.SourceCurrency = this.poreceiptview.Currency;
                POReceiptEntity.Rate = this.GetExchangRate();
                POReceiptEntity.SettlementDate = CXCLE00002.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), POReceiptEntity.SourceBranch, true });
                POReceiptEntity.ReferenceVoucherNo = this.poreceiptview.PaymentOrderNo;
                POReceiptEntity.Budget = this.poreceiptview.BudgetYear;
                POReceiptEntity.UserNo = CurrentUserEntity.CurrentUserName;
                if (poreceiptview.PaymentOrderNo != string.Empty && poreceiptview.BudgetYear != string.Empty)
                {
                    if (PODTO == null) throw new Exception();
                    POReceiptEntity.AccountNo = this.PODTO.ACode;
                    POReceiptEntity.Acode = POReceiptEntity.AccountNo;
                    IList<ChargeOfAccountDTO> Coa = CXCLE00002.Instance.GetListObject<ChargeOfAccountDTO>("COA.Client.SelectAccountNameList", new object[] { POReceiptEntity.Acode.TrimEnd(), POReceiptEntity.SourceBranch, true });
                    var desp = (from value in Coa select value.AccountName).FirstOrDefault();
                    string desption = Convert.ToString(desp);
                    POReceiptEntity.Description = desption;
                }
                return POReceiptEntity;
            }
            catch(Exception)
            {              
                throw new Exception(CXMessage.ME00021);
            }        
        }

        private TLMDTO00045 GetViewData()
        {
            TLMDTO00045 entity = new TLMDTO00045();
            entity.PaymentOrderNo = this.POReceiptView.PaymentOrderNo;
            entity.OtherBankAcctNo = this.POReceiptView.ReceivedAccountNo;
            entity.OtherBank = this.POReceiptView.OtherBank;
            entity.SourceCurrency = this.POReceiptView.Currency;
            entity.Amount = this.POReceiptView.Amount;
            entity.Budget = this.POReceiptView.BudgetYear;
            return entity;
        }

         #endregion
   }
}
