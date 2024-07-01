using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com;
using Ace.Cbs.Cx.Com.Dto;
//using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr ;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Ctr.Sve;
using System.Windows.Forms;
//using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00007 : AbstractPresenter ,ITCMCTL00007
    {     
        #region Properties

        private ITCMVEW00007 view;
        public ITCMVEW00007 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        PFMDTO00054 tlfInfo { get; set; }
        IList<TLMDTO00015> CashDenoInfo { get; set; }        
    private CXDTO00001 DenoDTO{get; set;}
     TLMDTO00015 CashDenoEntity { get; set; }
    
        
        #endregion

        #region Main Method

        private void WireTo(ITCMVEW00007 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetLastPaymentInfo());  //get data from UI Controls
            }
        }
        public void ClearControls()
        {
             this.view.EntryNo  = string.Empty;
            this.view.AccountNo  = string.Empty;
            this.view.Description = string.Empty;
            //this.view.Currency = string.Empty;         
            this.view.Amount = 0;
        }
        public PFMDTO00054 GetLastPaymentInfo()    // get data from tlf
        {
            PFMDTO00054 lastPaymentData = new PFMDTO00054();
            lastPaymentData.Eno = this.view.EntryNo;
            lastPaymentData.AccountNo = this.view.AccountNo;
            lastPaymentData.Description = this.view.Description;
            lastPaymentData.SourceCurrency = this.view.Currency;
            lastPaymentData.Amount = this.view.Amount;
            lastPaymentData.SourceBranchCode = CurrentUserEntity.BranchCode;
            lastPaymentData.CreatedUserId = CurrentUserEntity.CurrentUserID;

            return lastPaymentData;
        }
        public void Save()
        {
            PFMDTO00054 PaymentData = this.GetLastPaymentInfo();

            if (this.ValidateForm(this.GetLastPaymentInfo()))
            {
                //to call Deno from and save denostring               
                if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { View.Amount, View.Currency, CXDMD00008.Payment, "TCMVEW00007" }) == DialogResult.OK)
                {
                   this. DenoDTO = CXUIScreenTransit.GetData<CXDTO00001>("TCMVEW00007");
                   
                    if (DenoDTO != null)
                    {
                        TLMDTO00015 CashDenoEntity = new TLMDTO00015();
                        CashDenoEntity.DenoDetail = DenoDTO.DenoString;
                        CashDenoEntity.DenoRate = DenoDTO.DenoRateString;
                        CashDenoEntity.DenoRefundDetail = DenoDTO.RefundString;
                        CashDenoEntity.DenoRefundRate = DenoDTO.RefundRateString;
                        CashDenoEntity.AdjustAmount = DenoDTO.AdjustAmount;
                        CashDenoEntity.Amount = DenoDTO.TotalAmount;
                        CashDenoEntity.CounterNo = DenoDTO.CounterNo;
                     
                        CXClientWrapper.Instance.Invoke<ITCMSVE00007>(x => x.Save(CashDenoEntity, PaymentData));

                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                        {
                            string[] logItemForDeno = new string[14];
                            //ClientLog For Deno
                            logItemForDeno[0] = this.View.EntryNo;//Tlf_Eno
                            logItemForDeno[1] = this.View.AccountNo;//AcType
                            logItemForDeno[2] = string.Empty;//FromType
                            logItemForDeno[3] = this.View.Amount.ToString();//Amount
                            logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                            logItemForDeno[5] = this.DenoDTO.DenoString; ;//Deno_Detail
                            logItemForDeno[6] = this.DenoDTO.RefundString;//DenoRefund_Detail
                            logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = CurrentUserEntity.BranchCode;//sourcebr
                            logItemForDeno[10] = this.View.Currency;//cur
                            logItemForDeno[11] = this.DenoDTO.DenoRateString;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), CurrentUserEntity.BranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Last Payment Fail Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);



                            this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {

                            string[] logItemForDeno = new string[14];
                            //ClientLog For Deno
                            logItemForDeno[0] = this.View.EntryNo;//Tlf_Eno
                            logItemForDeno[1] = this.View.AccountNo;//AcType
                            logItemForDeno[2] = string.Empty;//FromType
                            logItemForDeno[3] = this.View.Amount.ToString();//Amount
                            logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                            logItemForDeno[5] = this.DenoDTO.DenoString;//Deno_Detail
                            logItemForDeno[6] = this.DenoDTO.RefundString;//DenoRefund_Detail
                            logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = CurrentUserEntity.BranchCode;//sourcebr
                            logItemForDeno[10] = this.View.Currency;//cur
                            logItemForDeno[11] = this.DenoDTO.DenoRateString;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), CurrentUserEntity.BranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Last Payment Commit Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);


                            
                          this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                            
                          this.ClearControls();
                        }
                    }
                    //else
                    //{
                    //    //Error Occur becoz user don't enter deno but close the form.
                    //    this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                    //    return;
                    //}
                }

            }
        }
      
        #endregion

        #region Validation Logic
        public void txtEntryNo_CustomValidating(object sender, ValidationEventArgs e)  // Check EntryNo and AccountNo
        {
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    if (!string.IsNullOrEmpty(this.view.EntryNo))
                    {
                        //Check EntryNo from Tlf
                        tlfInfo = CXClientWrapper.Instance.Invoke<ITCMSVE00007, PFMDTO00054>(x => x.Check_EntryNo(this.view.EntryNo, CurrentUserEntity.BranchCode, "WITHDRAW"));                        
                        if ((tlfInfo == null) || (tlfInfo.RecordCount  < 0) )
                            this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), "MI30016");// Invalid Entry No
                        else 
                        {
                            if (tlfInfo.Status == "CDV" || tlfInfo.Status == "CDW")
                            {
                                //Check EntryNo from CashDeno
                                CashDenoInfo = CXClientWrapper.Instance.Invoke<ITCMSVE00007, TLMDTO00015>(x => x.Check_DenoEno(this.view.EntryNo, "P", CurrentUserEntity.BranchCode));
                                if (CashDenoInfo.Count > 0)
                                {
                                    if (CashDenoInfo[0].CashDate != null && CashDenoInfo[0].CashDate != System.DateTime.MinValue)
                                        this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), "MI00140");// This Entry No. has already made Denomination Entry                                    
                                    else 
                                    {   // Check AccountNo from Cledger
                                        this.View.AccountNo = tlfInfo.AccountNo;
                                        if (CXCOM00006.Instance.Validate(this.view.AccountNo, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
                                        {
                                            if (CXClientWrapper.Instance.Invoke<ICXSVE00006, bool>(x => x.IsClosedAccountForCLedger(this.view.AccountNo)))
                                                this.view.FillData(tlfInfo); //If Entry No and AccountNo Valid , Fill Data
                                            else
                                                this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), "MI00141");//Last WithDrawal A/C Only!
                                        }
                                    }
                                   
                                }
                            } 
                        }
                    }
                    else
                    { 
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90027); // Invalid Entry No
                    }
                }
                 catch (Exception ex)
                {
                    // Set Error Message to Control.               
                    CXUIMessageUtilities.ShowMessageByCode(ex.Message.ToString());
                }
            }          
        }   

        #endregion
    }    
}
