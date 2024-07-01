using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00016:AbstractPresenter,IMNMCTL00016
    {
        #region Properties
        private IMNMVEW00016 view;
        public IMNMVEW00016 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        public string sourceBranch = CurrentUserEntity.BranchCode;
        public TLMDTO00016 singlePO { get; set; }
        public TLMDTO00015 cashDenoDTO { get; set; }
        //public decimal OldAmount = 0;
        public decimal Charges = 0;
        //public TLMDTO00016 po = new TLMDTO00016();
        public decimal denoAmount = 0;
        public decimal groupAmount = 0;
        public decimal cashAmount = 0;
        public IList<PFMDTO00054> TLFList { get; set; }
        //public CXDTO00001 denoData { get; set; }
       // public TLMDTO00041 data { get; set; }

        #endregion

        #region Methods
        private void WireTo(IMNMVEW00016 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetPOData());
            }
        }

        public void ClearControls()
        {
            this.view.GroupNo = string.Empty;
            this.view.PaymentOrderNo = string.Empty;
            this.view.BudgetYear = string.Empty;
            //this.view.Currency = string.Empty;
            this.view.Amount = 0;
            this.view.CreditedAccountNo = string.Empty;
            this.view.Name = string.Empty;
            //this.view.MultiCheck = false;
        }

        public TLMDTO00041 GetPOData()
        {
            TLMDTO00041 paymentOrderDTO = new TLMDTO00041();

            paymentOrderDTO.GroupNo = this.view.GroupNo;
            paymentOrderDTO.PaymentOrderNo = this.view.PaymentOrderNo;
            paymentOrderDTO.BudgetYear = this.view.BudgetYear;
            paymentOrderDTO.CurrencyCode = this.view.Currency;
            paymentOrderDTO.Amount = this.view.Amount;
            paymentOrderDTO.AccountNo = this.view.CreditedAccountNo;
            paymentOrderDTO.Name = this.view.Name;
            //paymentOrderDTO.MultiCheck = this.view.MultiCheck;
            return paymentOrderDTO;
        }

        public void Save()
        {

            TLMDTO00041 data = GetPOData();
            data.CreatedUserId = CurrentUserEntity.CurrentUserID;
            data.SourceBranchCode = CurrentUserEntity.BranchCode;
            
            if (this.ValidateForm(data))
            {
               
                if (singlePO.Status == "C")
                {
                    decimal amount = this.view.Amount;
                    if (amount > 0) 
                    {
                        if (string.IsNullOrEmpty(this.view.GroupNo))
                        {
                            //TLMDTO00015 cashDenoDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00016, TLMDTO00015>(x => x.GetCashDenoForPOReversal(this.singlePO.Tlf_ENo, sourceBranch));//check CashDeno
                            data.DenoDetail = cashDenoDTO.DenoDetail;
                            data.DenoRate = cashDenoDTO.DenoRate;
                            data.DenoRefundDetail = cashDenoDTO.DenoRefundDetail;
                            data.DenoRefundRate = cashDenoDTO.DenoRefundRate;
                            data.AdjustAmount = Convert.ToDecimal(cashDenoDTO.AdjustAmount);
                            data.TotalAmount = cashDenoDTO.Amount;
                            data.CounterNo = cashDenoDTO.CounterNo;
                        }
                        else
                        {
                            groupAmount = singlePO.CashDenoDTO.DepoDenoAmount;
                            cashAmount = groupAmount + this.view.Amount + Convert.ToDecimal(singlePO.Charges);
                            if (cashAmount > (this.view.Amount + Convert.ToDecimal(singlePO.Charges)))
                            {
                                denoAmount = cashAmount - (this.view.Amount + Convert.ToDecimal(singlePO.Charges));
                            }
                            if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { denoAmount, data.CurrencyCode, CXDMD00008.Payment, View.ParentFormId }) == DialogResult.OK)
                            {
                                CXDTO00001 denoDTO = CXUIScreenTransit.GetData<CXDTO00001>(View.ParentFormId);
                                if (denoDTO != null)
                                {
                                    data.DenoDetail = denoDTO.DenoString;
                                    data.DenoRate = denoDTO.DenoRateString;
                                    data.DenoRefundDetail = denoDTO.RefundString;
                                    data.DenoRefundRate = denoDTO.RefundRateString;
                                    data.AdjustAmount = denoDTO.AdjustAmount;
                                    data.TotalAmount = denoDTO.TotalAmount;
                                    data.CounterNo = denoDTO.CounterNo;
                                }
                            }
                            else
                            {
                                //Error Occur becoz user don't enter deno but close the form.
                                this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                                return;
                            }
                        }
                    }
                }
                data.Status = singlePO.Status;
                  
                //data.Actype = cashDenoDTO.AccountType;     

                TLFList = CXClientWrapper.Instance.Invoke<IMNMSVE00016, IList<PFMDTO00054>>(x => x.SaveRefundPO(data));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                {
                    string[] logItemForTlf = new string[35];
                    logItemForTlf[0] = this.View.GroupNo;//GroupNo
                    logItemForTlf[1] = this.View.PaymentOrderNo;//EntryNo
                    logItemForTlf[2] = TLFList[0].AccountNo;//AcctNo
                    logItemForTlf[3] = TLFList[0].Acode; //Acode
                    logItemForTlf[4] = TLFList[0].Amount.ToString();//LocalAmount
                    logItemForTlf[5] = TLFList[0].SourceCurrency;//SourceCur
                    logItemForTlf[6] = string.Empty;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.sourceBranch).ToString();//SettlementDate
                    logItemForTlf[9] = TLFList[0].Status;//Status
                    logItemForTlf[10] = this.sourceBranch;//SourceBr
                    logItemForTlf[11] = TLFList[0].Eno;//Rno
                    logItemForTlf[12] = string.Empty;//Duration
                    logItemForTlf[13] = string.Empty;//LasintDate
                    logItemForTlf[14] = string.Empty;//intRate
                    logItemForTlf[15] = string.Empty;//Accured
                    logItemForTlf[16] = string.Empty;//BudenAcc
                    logItemForTlf[17] = string.Empty;//Draccured
                    logItemForTlf[18] = string.Empty;//AccuredStatus
                    logItemForTlf[19] = singlePO.ToAccountNo;//ToAccountNo
                    logItemForTlf[20] = string.Empty;//FirstRno
                    logItemForTlf[21] = TLFList[0].PaymentOrderNo;//PoNo
                    logItemForTlf[22] = string.Empty;//ADate
                    logItemForTlf[23] = string.Empty;//IDate
                    logItemForTlf[24] = string.Empty;//ToAcctNo
                    logItemForTlf[25] = string.Empty;//Income
                    logItemForTlf[26] = string.Empty;//Budget
                    logItemForTlf[27] = string.Empty;//FromBranch
                    logItemForTlf[28] = string.Empty;//ToBranch
                    logItemForTlf[29] = string.Empty;//Inout
                    logItemForTlf[30] = string.Empty;//Success
                    logItemForTlf[31] = string.Empty;//COMMUCHARGE
                    logItemForTlf[32] = string.Empty;//IncomeType
                    logItemForTlf[33] = string.Empty;//OtherBank
                    logItemForTlf[34] = string.Empty;//OtherBankChq
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Refund Reversal By Fail Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);

                    string[] logItemForDeno = new string[14];
                    //ClientLog For Deno
                    logItemForDeno[0] = TLFList[0].Eno;//Tlf_Eno
                    logItemForDeno[1] = this.View.PaymentOrderNo;//AcType
                    logItemForDeno[2] = string.Empty;//FromType
                    logItemForDeno[3] = this.View.Amount.ToString();//AmountString();//Cash_Date
                    logItemForDeno[5] = data.DenoDetail;//Deno_Detail
                    logItemForDeno[4] = System.DateTime.Now.ToString();
                    logItemForDeno[6] = data.DenoRefundDetail;//DenoRefund_Detail
                    logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                    logItemForDeno[8] = "0";//REVERSE
                    logItemForDeno[9] = TLFList[0].SourceBranchCode;//sourcebr
                    logItemForDeno[10] = this.View.Currency;//cur
                    logItemForDeno[11] = data.DenoRate;//DenoRate
                    logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), CurrentUserEntity.BranchCode).ToString();//SettlementDate
                    logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "PO Refund Reversal Fail Deno", CurrentUserEntity.BranchCode,
                    logItemForDeno);


                    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                else
                {
                       
                    string[] logItemForTlf = new string[35];
                    logItemForTlf[0] = this.View.GroupNo;//GroupNo
                    logItemForTlf[1] = this.View.PaymentOrderNo;//EntryNo
                    logItemForTlf[2] = TLFList[0].AccountNo;//AcctNo
                    logItemForTlf[3] = TLFList[0].Acode; //Acode
                    logItemForTlf[4] = TLFList[0].Amount.ToString();//LocalAmount
                    logItemForTlf[5] = TLFList[0].SourceCurrency;//SourceCur
                    logItemForTlf[6] = string.Empty;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate),this.sourceBranch).ToString();//SettlementDate
                    logItemForTlf[9] = TLFList[0].Status;//Status
                    logItemForTlf[10] = this.sourceBranch;//SourceBr
                    logItemForTlf[11] = TLFList[0].Eno;//Rno
                    logItemForTlf[12] = string.Empty;//Duration
                    logItemForTlf[13] = string.Empty;//LasintDate
                    logItemForTlf[14] = string.Empty;//intRate
                    logItemForTlf[15] = string.Empty;//Accured
                    logItemForTlf[16] = string.Empty;//BudenAcc
                    logItemForTlf[17] = string.Empty;//Draccured
                    logItemForTlf[18] = string.Empty;//AccuredStatus
                    logItemForTlf[19] = singlePO.ToAccountNo;//ToAccountNo
                    logItemForTlf[20] = string.Empty;//FirstRno
                    logItemForTlf[21] = TLFList[0].PaymentOrderNo;//PoNo
                    logItemForTlf[22] = string.Empty;//ADate
                    logItemForTlf[23] = string.Empty;//IDate
                    logItemForTlf[24] = string.Empty;//ToAcctNo
                    logItemForTlf[25] = string.Empty;//Income
                    logItemForTlf[26] = string.Empty;//Budget
                    logItemForTlf[27] = string.Empty;//FromBranch
                    logItemForTlf[28] = string.Empty;//ToBranch
                    logItemForTlf[29] = string.Empty;//Inout
                    logItemForTlf[30] = string.Empty;//Success
                    logItemForTlf[31] = string.Empty;//COMMUCHARGE
                    logItemForTlf[32] = string.Empty;//IncomeType
                    logItemForTlf[33] = string.Empty;//OtherBank
                    logItemForTlf[34] = string.Empty;//OtherBankChq
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Refund Reversal By Commit Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);


                    string[] logItemForDeno = new string[14];
                    //ClientLog For Deno
                    logItemForDeno[0] = TLFList[0].Eno;//Tlf_Eno
                    logItemForDeno[1] = this.View.PaymentOrderNo;//AcType
                    logItemForDeno[2] = string.Empty;//FromType
                    logItemForDeno[3] = this.View.Amount.ToString();//Amount
                    logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                    logItemForDeno[5] = data.DenoDetail;//Deno_Detail
                    logItemForDeno[6] = data.DenoRefundDetail;//DenoRefund_Detail
                    logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                    logItemForDeno[8] = "0";//REVERSE
                    logItemForDeno[9] = TLFList[0].SourceBranchCode;//sourcebr
                    logItemForDeno[10] = this.View.Currency;//cur
                    logItemForDeno[11] = data.DenoRate;//DenoRate
                    logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), CurrentUserEntity.BranchCode).ToString();//SettlementDate
                    logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType)).ToString();//Rate
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "PO Refund Reversal Commit Deno", CurrentUserEntity.BranchCode,
                    logItemForDeno);


                    this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    this.ClearControls();
                    this.view.VisibleCurrency(false);
                }
            }
        }
        //Added by HMW at 26-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }
        
        #endregion

        #region Validation Logic
        public void txtGroupNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if (!this.View.GroupNo.Length.Equals(Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.GroupFormat))))
                {
                    this.SetCustomErrorMessage(this.GetControl("txtGroupNo"), "MV30020");//Invalid Group No.
                }
                else
                {
                    IList<TLMDTO00015> cashDenoDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00014, IList<TLMDTO00015>>(x => x.GetDepoDenoAndCashDeno(this.View.GroupNo, sourceBranch));//check
                    if (cashDenoDTO.Count > 0)
                    {
                        string cashdate = Convert.ToDateTime(cashDenoDTO[0].CashDate).ToShortDateString();
                        string todaydate = DateTime.Now.ToShortDateString();

                        if (cashdate != todaydate && cashDenoDTO[0].CashDate.Value != System.DateTime.MinValue)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtGroupNo"), "ME30002"); //Not Allowed Back Date Transaction!

                        }

                        else if (cashDenoDTO[0].CashDate.Value == System.DateTime.MinValue)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtGroupNo"), "MV90093");//1st,Please Insert For Cash Payment Denomination Entry
                        }
                        else if (cashdate == todaydate && cashDenoDTO[0].Status == "R")
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtGroupNo"), "MV30029"); //Multiple PO Refund Reversal Group No. Only
                            //CXUIMessageUtilities.ShowMessageByCode("MV30029");//Multiple PO Refund Reversal Group No. Only
                            return;
                        }
                    }

                    else if (cashDenoDTO.Count <= 0)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtGroupNo"), "MV90093"); //Multiple PO Refund Reversal Group No. Only
                        //CXUIMessageUtilities.ShowMessageByCode("MV90093");//Multiple PO Refund Reversal Group No. Only
                        return;
                    }                                   
                   
                }
            }
        }


        public void txtPaymentOrderNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if (!this.View.PaymentOrderNo.Length.Equals(Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POFromat))))
                {
                    this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MV00103");//Invalid Payment Order No.
                }
                else
                {
                    if (string.IsNullOrEmpty(this.View.GroupNo))
                    {
                        singlePO = CXClientWrapper.Instance.Invoke<IMNMSVE00016, TLMDTO00016>(x => x.GetPOData(this.View.PaymentOrderNo, this.View.BudgetYear, this.sourceBranch));
                    }
                    else 
                    {
                        singlePO = CXClientWrapper.Instance.Invoke<IMNMSVE00016, TLMDTO00016>(x => x.GetDepoDenoData(this.View.GroupNo, this.View.PaymentOrderNo, this.View.BudgetYear, this.sourceBranch));
                    }

                    if (singlePO == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV30023")
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MV00219", new object[] { "Invalid" });//Invalid PO No. for this Group No.
                            return;
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                            //this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);//
                            return;
                        }
                        
                    }
                    if (singlePO != null)
                    {

                        if (Convert.ToDateTime(singlePO.IDate).ToShortDateString() == DateTime.Now.ToShortDateString())
                        {
                            //For Single PO
                            if (string.IsNullOrEmpty(this.View.GroupNo))
                            {
                                //Chk CashDeno Table
                                cashDenoDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00016, TLMDTO00015>(x => x.GetCashDenoForPOReversal(this.singlePO.Tlf_ENo, sourceBranch));
                                if (singlePO.Status == "J")
                                {
                                    this.view.VisibleCurrency(true);
                                    this.view.Currency = singlePO.Currency;
                                    this.view.Amount = singlePO.Amount;
                                    this.view.VisibleTransferRefund(true);
                                    this.view.CreditedAccountNo = singlePO.ToAccountNo;
                                    this.view.Name = singlePO.CustomerName;//Customer Name For Current/Saving AC
                                }
                                else
                                {
                                    if (cashDenoDTO.CashDate != null && cashDenoDTO.CashDate.Value != System.DateTime.MinValue)
                                    {
                                        this.view.VisibleCurrency(true);
                                        this.view.Currency = singlePO.Currency;
                                        this.view.Amount = singlePO.Amount;
                                        if (singlePO.Status == "J")
                                        {
                                            this.view.VisibleTransferRefund(true);
                                            this.view.CreditedAccountNo = singlePO.ToAccountNo;
                                            this.view.Name = singlePO.CustomerName;//Customer Name For Current/Saving AC
                                        }
                                    }
                                    else
                                        this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MV90093");//1st,Please Insert For Cash Payment Denomination Entry
                                }
                            }
                            //For MultiPO
                            else
                            {
                                this.view.VisibleCurrency(true);
                                this.view.Currency = singlePO.Currency;
                                this.view.Amount = singlePO.Amount;
                                if (singlePO.Status == "J")
                                {
                                    this.view.VisibleTransferRefund(true);
                                    this.view.CreditedAccountNo = singlePO.ToAccountNo;
                                    this.view.Name = singlePO.CustomerName;//Customer Name For Current/Saving AC
                                }
                            }

                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "ME30002"); //Not Allowed Back Date Transaction!
                        }
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "ME30002"); //Not Allowed Back Date Transaction!
                    }
                }
            }
        }
    }
        #endregion
}
