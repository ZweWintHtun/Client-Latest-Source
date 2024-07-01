//----------------------------------------------------------------------
// <copyright file="TLMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung </CreatedUser>
// <CreatedDate>18.6.2013</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Loan.Dmd.DTO; // Added by AAM (16-Jan-2018)
using Ace.Cbs.Loan.Ctr.Sve; // Added by AAM (16-Jan-2018)
using Ace.Cbs.Loan.Sve; // Added by AAM (16-Jan-2018)
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00001 : AbstractPresenter, ITLMCTL00001
    {
        #region Properties
        // Added By AAM (16-Jan-2018)
        public int index;
        public string brCode;
        public string acType;
        public string serialNo;
        public string description;
        public string desp;
        public string headCodeDesp;
        public string acctNo;


        private ITLMVEW00001 view;
        public ITLMVEW00001 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        public TLMDTO00041 domesticVoucherDTO { get; set; }
        public string transactionCode { get; set; }
        public string status { get; set; }
        public CXDTO00001 denoDTO { get; set; }
        #endregion

        #region Methods
        private void WireTo(ITLMVEW00001 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetDomesticData());
            }
        }

        public void ClearControls()
        {
            this.view.VoucherNo = string.Empty;
            //this.view.CurrencyCode = string.Empty;
            this.view.DomesticAccountNo = string.Empty;
            this.view.Description = string.Empty;
            this.view.Narration = string.Empty;
            this.view.Amount = 0;
        }
        
        public TLMDTO00041 GetDomesticData()
        {
            domesticVoucherDTO = new TLMDTO00041();
            domesticVoucherDTO.CurrencyCode = this.view.CurrencyCode;
            domesticVoucherDTO.AccountNo = this.view.DomesticAccountNo;
            domesticVoucherDTO.Description = this.view.Description;
            domesticVoucherDTO.Narration = this.view.Narration;
            domesticVoucherDTO.Amount = this.view.Amount;
            domesticVoucherDTO.Status = this.view.Status;  
            return domesticVoucherDTO;
        }

        public void Save()
        {
            domesticVoucherDTO = this.GetDomesticData();
            if (this.ValidateForm(domesticVoucherDTO))
            {
                if (this.view.Status == "Credit Amount :")
                {
                    transactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashCreditType);
                    status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);
                }
                else
                {
                    transactionCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashDebitType);
                    status = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCashStatus);
                }

                domesticVoucherDTO.Acode = domesticVoucherDTO.AccountNo;
                domesticVoucherDTO.TranscationCode = transactionCode;
                domesticVoucherDTO.CashStatus = status;
                domesticVoucherDTO.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                domesticVoucherDTO.CreatedUserId = CurrentUserEntity.CurrentUserID;
                domesticVoucherDTO.SourceBranchCode = CurrentUserEntity.BranchCode;
                domesticVoucherDTO.Status = domesticVoucherDTO.Status;  //For Dr/Cr

                CXDMD00008 transactionStatus = (domesticVoucherDTO.CashStatus == "P") ? CXDMD00008.Payment : CXDMD00008.Received;

                if (this.view.Status == "Credit Amount :")
                {

                    if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { View.Amount, View.CurrencyCode, transactionStatus, View.ParentFormId }) == DialogResult.OK)
                    {
                        denoDTO = CXUIScreenTransit.GetData<CXDTO00001>(View.ParentFormId);
                        if (denoDTO != null)
                        {
                            domesticVoucherDTO.DenoDetail = denoDTO.DenoString;
                            domesticVoucherDTO.DenoRate = denoDTO.DenoRateString;
                            domesticVoucherDTO.DenoRefundDetail = denoDTO.RefundString;
                            domesticVoucherDTO.DenoRefundRate = denoDTO.RefundRateString;
                            domesticVoucherDTO.AdjustAmount = denoDTO.AdjustAmount;
                            domesticVoucherDTO.TotalAmount = denoDTO.TotalAmount;
                            domesticVoucherDTO.CounterNo = denoDTO.CounterNo;
                        }
                        else
                        {
                            //Error Occur becoz user don't enter deno but close the form.
                            this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                            return;
                        }
                    }
                    else
                    { return; }
                }  
                else   //Debit Voucher
                {
                    domesticVoucherDTO.TotalAmount = domesticVoucherDTO.Amount;
                }
                string voucher = CXClientWrapper.Instance.Invoke<ITLMSVE00001, string>(x => x.SaveDomesticVoucher(domesticVoucherDTO));
                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                {
                    if (this.view.Status == "Credit Amount :")
                    {
                        string[] logItemForDeno = new string[14];
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Deno
                        logItemForDeno[0] = voucher;//Tlf_Eno
                        logItemForDeno[1] = domesticVoucherDTO.AccountNo;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = domesticVoucherDTO.TotalAmount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = domesticVoucherDTO.DenoDetail;//Deno_Detail
                        logItemForDeno[6] = domesticVoucherDTO.DenoRefundDetail;//DenoRefund_Detail
                        logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = domesticVoucherDTO.SourceBranchCode;//sourcebr
                        logItemForDeno[10] = domesticVoucherDTO.CurrencyCode;//cur
                        logItemForDeno[11] = domesticVoucherDTO.DenoRate;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), domesticVoucherDTO.SourceBranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(domesticVoucherDTO.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString(); ;//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Domestic Credit Commit Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);

                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = voucher;//EntryNo
                        logItemForTlf[2] = domesticVoucherDTO.AccountNo;//AcctNo
                        logItemForTlf[3] = string.Empty;//ACode(from COASetUp)
                        logItemForTlf[4] = domesticVoucherDTO.TotalAmount.ToString();//LocalAmount
                        logItemForTlf[5] = domesticVoucherDTO.CurrencyCode;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), domesticVoucherDTO.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = string.Empty;//Status
                        logItemForTlf[10] = domesticVoucherDTO.SourceBranchCode;//SourceBr
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
                        logItemForTlf[21] = string.Empty;//PoNo
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Domestic Credit Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                    }
                    else
                    {
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = voucher;//EntryNo
                        logItemForTlf[2] = domesticVoucherDTO.AccountNo;//AcctNo
                        logItemForTlf[3] = string.Empty;//ACode(from COASetUp)
                        logItemForTlf[4] = domesticVoucherDTO.TotalAmount.ToString();//LocalAmount
                        logItemForTlf[5] = domesticVoucherDTO.CurrencyCode;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), domesticVoucherDTO.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = string.Empty;//Status
                        logItemForTlf[10] = domesticVoucherDTO.SourceBranchCode;//SourceBr
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
                        logItemForTlf[21] = string.Empty;//PoNo
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Domestic Debit Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
 
                    }
                    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion
                #region Successful
                else
                {
                    if (this.view.Status == "Credit Amount :")
                    {
                        string[] logItemForDeno = new string[14];
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Deno
                        logItemForDeno[0] = voucher;//Tlf_Eno
                        logItemForDeno[1] = domesticVoucherDTO.AccountNo;//AcType
                        logItemForDeno[2] = string.Empty;//FromType
                        logItemForDeno[3] = domesticVoucherDTO.TotalAmount.ToString();//Amount
                        logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        logItemForDeno[5] = domesticVoucherDTO.DenoDetail;//Deno_Detail
                        logItemForDeno[6] = domesticVoucherDTO.DenoRefundDetail;//DenoRefund_Detail
                        logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        logItemForDeno[8] = "0";//REVERSE
                        logItemForDeno[9] = domesticVoucherDTO.SourceBranchCode;//sourcebr
                        logItemForDeno[10] = domesticVoucherDTO.CurrencyCode;//cur
                        logItemForDeno[11] = domesticVoucherDTO.DenoRate;//DenoRate
                        logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), domesticVoucherDTO.SourceBranchCode).ToString();//SettlementDate
                        logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(domesticVoucherDTO.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString(); ;//Rate
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Domestic Credit Commit Deno", CurrentUserEntity.BranchCode,
                        logItemForDeno);

                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = voucher;//EntryNo
                        logItemForTlf[2] = domesticVoucherDTO.AccountNo;//AcctNo
                        logItemForTlf[3] = string.Empty;//ACode(from COASetUp)
                        logItemForTlf[4] = domesticVoucherDTO.TotalAmount.ToString();//LocalAmount
                        logItemForTlf[5] = domesticVoucherDTO.CurrencyCode;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), domesticVoucherDTO.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = string.Empty;//Status
                        logItemForTlf[10] = domesticVoucherDTO.SourceBranchCode;//SourceBr
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
                        logItemForTlf[21] = string.Empty;//PoNo
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Domestic Credit Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                    }
                    else
                    {
                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = voucher;//EntryNo
                        logItemForTlf[2] = domesticVoucherDTO.AccountNo;//AcctNo
                        logItemForTlf[3] = string.Empty;//ACode(from COASetUp)
                        logItemForTlf[4] = domesticVoucherDTO.TotalAmount.ToString();//LocalAmount
                        logItemForTlf[5] = domesticVoucherDTO.CurrencyCode;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), domesticVoucherDTO.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = string.Empty;//Status
                        logItemForTlf[10] = domesticVoucherDTO.SourceBranchCode;//SourceBr
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
                        logItemForTlf[21] = string.Empty;//PoNo
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Domestic Debit Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);

                    }
                    this.View.VoucherNo = voucher;                    

                    this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, voucher);

                    //Readded by HWKO (04-Dec-2017)
                    if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00016) == DialogResult.Yes)
                    {
                        // Added By AAM (16-Jan-2018)
                        IList<LOMDTO00236> lst_Domestic_Vou_Print = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00236>>(x => x.Get_BL_LimitVou_Lists(voucher));
                        string headCodeDesp = lst_Domestic_Vou_Print[0].HeadACName;
                        string acctNo = lst_Domestic_Vou_Print[0].AcctNo;
                        string description = lst_Domestic_Vou_Print[0].Desp;
                        index = acctNo.IndexOf("0");
                        acType = acctNo.Substring(0, index);
                        serialNo = acctNo.Substring(index, acctNo.Length - index);
                        desp = headCodeDesp + "," +" " +description + " "+"(" + acType + "-" + serialNo + ")"; 

                        if (this.view.Status == "Credit Amount :")
                        {
                            //CXUIScreenTransit.Transit("frmTLMVEW00082", true, new object[] { domesticVoucherDTO.Description + " - " + domesticVoucherDTO.AccountNo, domesticVoucherDTO.TotalAmount, domesticVoucherDTO.Narration, voucher }); // Comment By AAM (16-Jan-2018)
                            CXUIScreenTransit.Transit("frmTLMVEW00082", true, new object[] { desp, domesticVoucherDTO.TotalAmount, domesticVoucherDTO.Narration, voucher });// Added By AAM (16-Jan-2018)
                        }
                        else
                        {
                            //CXUIScreenTransit.Transit("frmTLMVEW00083", true, new object[] { domesticVoucherDTO.Description + " - " + domesticVoucherDTO.AccountNo, domesticVoucherDTO.TotalAmount, domesticVoucherDTO.Narration, voucher });// Comment By AAM (16-Jan-2018)
                            CXUIScreenTransit.Transit("frmTLMVEW00083", true, new object[] { desp, domesticVoucherDTO.TotalAmount, domesticVoucherDTO.Narration, voucher });// Added By AAM (16-Jan-2018)
                        }
                    }
                    //Endregion

                    this.ClearControls();
                }
                #endregion
            }
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
        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                // Validate account code by account code format(Regular Expression...)
                // And validate checkdigit of account code by account checkdigit formula
                try
                {
                    Nullable<CXDMD00011> accountType;
                    if (CXCLE00012.Instance.IsValidAccountNo(this.view.DomesticAccountNo, out accountType) && (accountType == CXDMD00011.DomesticAccountType))
                    {
                       ChargeOfAccountDTO coa=CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName",new object[] { this.view.DomesticAccountNo, CurrentUserEntity.BranchCode,true});
                        if (coa != null)
                        {
                            if (!string.IsNullOrEmpty(coa.AccountName))
                            {
                                this.view.Description = coa.AccountName;
                            }
                            else
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00175);//Account No Not Found. 
                            }
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), "MV00175");//Account No Not Found.
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                }
            }
            else
            {
                return;
                //this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
            }
        }
        #endregion
    }
}
    



               
        
    


