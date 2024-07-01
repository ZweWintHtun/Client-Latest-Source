//----------------------------------------------------------------------
// <copyright file="TLMCTL00009.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Yu Thandar Aung</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// Fixed Deposit DepositEntry Presenter
    /// </summary>
    public class TLMCTL00009 : AbstractPresenter, ITLMCTL00009
    {
        #region Properties
        private ITLMVEW00009 view;
        public ITLMVEW00009 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        TLMDTO00041 fixedDepositEntity { get; set; }
        IList<PFMDTO00001> customerInfo { get; set; }
        IList<PFMDTO00032> receiptNoList { get; set; }
        IList<PFMDTO00032> freceipt { get; set; }
        PFMDTO00032 receipt { get; set; }
        public CXDTO00001 denoDTO { get; set; }
        public string voucherNo { get; set; }
        public string Status { get; set; }
        public string accountNo { get; set; }

        #endregion

        #region Methods
        private void WireTo(ITLMVEW00009 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetFixedDepositEntity());
            }
        }

        public void ClearControls()
        {
            this.view.AccountNo = string.Empty;
            this.view.ReceiptNo = string.Empty;
            this.view.Duration = string.Empty;
            this.view.Amount = 0;
            this.view.Photo = null;
            this.view.Signature = null;
            this.view.FReceiptList = null;
        }

        public bool Save()
        {
            this.Status = "Save";
            fixedDepositEntity = this.GetFixedDepositEntity();
            //this.accountNo = fixedDepositEntity.AccountNo;
           
            if (this.ValidateForm(fixedDepositEntity))
            {
                
                fixedDepositEntity = this.BindFixedDepositEntity();
                fixedDepositEntity.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                if(!String.IsNullOrEmpty(this.Status))
                {
                    if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { fixedDepositEntity.Amount, View.CurrencyCode, CXDMD00008.Received, View.ParentFormId }) == DialogResult.OK)
                    {
                        denoDTO = CXUIScreenTransit.GetData<CXDTO00001>(View.ParentFormId);
                        if (denoDTO != null)
                        {
                            fixedDepositEntity.DenoDetail = denoDTO.DenoString;
                            fixedDepositEntity.DenoRate = denoDTO.DenoRateString;
                            fixedDepositEntity.DenoRefundDetail = denoDTO.RefundString;
                            fixedDepositEntity.DenoRefundRate = denoDTO.RefundRateString;
                            fixedDepositEntity.CounterNo = denoDTO.CounterNo;
                            fixedDepositEntity.TotalAmount = denoDTO.TotalAmount;
                            fixedDepositEntity.AdjustAmount = denoDTO.AdjustAmount;
                        }
                        else
                        {
                            this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                            return false;
                        }
                        TLMDTO00005 voucher = CXClientWrapper.Instance.Invoke<ITLMSVE00009, TLMDTO00005>(x => x.SaveFixedDeposit(fixedDepositEntity));
                        #region ErrorOccurred
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                        {
                            string[] logItemForDeno = new string[14];
                            string[] logItemForTlf = new string[35];
                            //ClientLog For Deno
                            logItemForDeno[0] = voucher.Narration;//Tlf_Eno
                            logItemForDeno[1] = fixedDepositEntity.AccountNo;//AcType
                            logItemForDeno[2] = string.Empty;//FromType
                            logItemForDeno[3] = fixedDepositEntity.Amount.ToString();//Amount
                            logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                            logItemForDeno[5] = fixedDepositEntity.DenoDetail;//Deno_Detail
                            logItemForDeno[6] = fixedDepositEntity.DenoRefundDetail;//DenoRefund_Detail
                            logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = fixedDepositEntity.SourceBranchCode;//sourcebr
                            logItemForDeno[10] = fixedDepositEntity.CurrencyCode;//cur
                            logItemForDeno[11] = fixedDepositEntity.DenoRate;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fixedDepositEntity.SourceBranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00011.Instance.GetScalarObject<PFMDTO00075>("RateInfo.Rate.Select", new object[] { fixedDepositEntity.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType), true, fixedDepositEntity.CurrencyCode, true }).ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "FixedDeposit Deposit Fail Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);

                            //ClientLog For Tlf
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = voucher.Narration;//EntryNo
                            logItemForTlf[2] = fixedDepositEntity.AccountNo;//AcctNo
                            logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fixedDepositEntity.CurrencyCode, fixedDepositEntity.SourceBranchCode, true });//ACode(from COASetUp)
                            logItemForTlf[4] = fixedDepositEntity.Amount.ToString();//LocalAmount
                            logItemForTlf[5] = fixedDepositEntity.CurrencyCode;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fixedDepositEntity.SourceBranchCode).ToString();//SettlementDate
                            logItemForTlf[9] = voucher.Status;//Status
                            logItemForTlf[10] = fixedDepositEntity.SourceBranchCode;//SourceBr
                            logItemForTlf[11] = "ReceiptNo: " + fixedDepositEntity.ReceiptNo;//Rno
                            logItemForTlf[12] = string.Empty;//Duration
                            logItemForTlf[13] = string.Empty;//LasintDate
                            logItemForTlf[14] = CXCOM00011.Instance.GetScalarObject<PFMDTO00075>("RateInfo.Rate.Select", new object[] { fixedDepositEntity.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType), true, fixedDepositEntity.CurrencyCode, true }).ToString();//intRate
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
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "FixedDeposit Deposit Fail Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);
                            this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        #endregion 

                        #region Successful
                        else
                        {
                            string[] logItemForDeno = new string[14];
                            string[] logItemForTlf = new string[35];
                            //ClientLog For Deno
                            logItemForDeno[0] = voucher.Narration;//Tlf_Eno
                            logItemForDeno[1] = fixedDepositEntity.AccountNo;//AcType
                            logItemForDeno[2] = string.Empty;//FromType
                            logItemForDeno[3] = fixedDepositEntity.Amount.ToString();//Amount
                            logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                            logItemForDeno[5] = fixedDepositEntity.DenoDetail;//Deno_Detail
                            logItemForDeno[6] = fixedDepositEntity.DenoRefundDetail;//DenoRefund_Detail
                            logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = fixedDepositEntity.SourceBranchCode;//sourcebr
                            logItemForDeno[10] = fixedDepositEntity.CurrencyCode;//cur
                            logItemForDeno[11] = fixedDepositEntity.DenoRate;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fixedDepositEntity.SourceBranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00011.Instance.GetScalarObject<PFMDTO00075>("RateInfo.Rate.Select", new object[] { fixedDepositEntity.CurrencyCode, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType), true, fixedDepositEntity.CurrencyCode, true }).Rate.ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "FixedDeposit Deposit Commit Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);

                            //ClientLog For Tlf
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = voucher.Narration;//EntryNo
                            logItemForTlf[2] = fixedDepositEntity.AccountNo;//AcctNo
                            logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fixedDepositEntity.CurrencyCode, fixedDepositEntity.SourceBranchCode, true });//ACode(from COASetUp)
                            logItemForTlf[4] = fixedDepositEntity.Amount.ToString();//LocalAmount
                            logItemForTlf[5] = fixedDepositEntity.CurrencyCode;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fixedDepositEntity.SourceBranchCode).ToString();//SettlementDate
                            logItemForTlf[9] = voucher.Status;//Status
                            logItemForTlf[10] = fixedDepositEntity.SourceBranchCode;//SourceBr
                            logItemForTlf[11] = ";ReceiptNo=>"+fixedDepositEntity.ReceiptNo;//Rno
                            logItemForTlf[12] = fixedDepositEntity.RegisterDuration;//Duration
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
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "FixedDeposit Deposit Commit Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);

                            this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, voucher.Narration);
                            return true;
                        }
                        #endregion
                    }
                }
            }

                   
            return false;
        }
   

        public PFMDTO00032 BindReceiptInfo()
        {
            var receiptInfo = from value in this.view.FReceiptList
                              where value.ReceiptNo == view.ReceiptNo
                              select value;
            foreach (var item in receiptInfo)
            {
                receipt = new PFMDTO00032();
                receipt.Amount = item.Amount;
                receipt.Duration = item.Duration;
                receipt.CurrencyCode = item.CurrencyCode;
            }
            return receipt;
        }

        public TLMDTO00041 GetFixedDepositEntity()
        {
            fixedDepositEntity = new TLMDTO00041();
            fixedDepositEntity.AccountNo = this.view.AccountNo;
            fixedDepositEntity.ReceiptNo = this.view.ReceiptNo;
            fixedDepositEntity.RegisterDuration = this.view.Duration;
            fixedDepositEntity.Amount = this.view.Amount;
            string currencyCode = this.view.CurrencyCode;
            return fixedDepositEntity;
        }

        public TLMDTO00041 BindFixedDepositEntity()
        {
            fixedDepositEntity = new TLMDTO00041();
            fixedDepositEntity.AccountSignature = (customerInfo[0].AccountSign!=null)?customerInfo[0].AccountSign:null;
            fixedDepositEntity.Description = (customerInfo[0].Name!=null)?customerInfo[0].Name:null;
            fixedDepositEntity.AccountNo = this.view.AccountNo;
            fixedDepositEntity.ReceiptNo = this.view.ReceiptNo;
            fixedDepositEntity.RegisterDuration = this.view.Duration;
            fixedDepositEntity.Amount = this.view.Amount;
            fixedDepositEntity.CurrencyCode = this.view.CurrencyCode;
            fixedDepositEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            fixedDepositEntity.SourceBranchCode = CurrentUserEntity.BranchCode;

            return fixedDepositEntity;

        }

        public void Printing()
        {
            try
            {
                IList<PFMDTO00058> FPrintFileList = new List<PFMDTO00058>();
                List<string[]> printingList;

                FPrintFileList = CXCLE00006.Instance.SelectAllPrintingDataForFixedAccounts(new String[] { this.view.AccountNo });
                printingList = new List<string[]>();

                for (int i = 0; i < FPrintFileList.Count<PFMDTO00058>(); i++)
                {
                    PFMDTO00058 fprnFile = FPrintFileList.ElementAt(i);
                  
                    string[] fprnFileStrArr = { fprnFile.CreatedDate.ToString("dd/MM/yyyy"), fprnFile.Reference, fprnFile.Credit.ToString(), fprnFile.Debit.ToString(), fprnFile.Balance.ToString(), fprnFile.Id.ToString() };

                    printingList.Add(fprnFileStrArr);
                }

                if (FPrintFileList.Count<PFMDTO00058>() > 0)
                {
                    CXCLE00005.Instance.StartLineNo = (int)FPrintFileList.ToList<PFMDTO00058>()[0].lineNo == 0 ? 1 : (int)FPrintFileList.ToList<PFMDTO00058>()[0].lineNo;
                    int printedLine = CXCLE00005.Instance.StartLineNo;
                    CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true, out printedLine);

                    if (!CXCLE00006.Instance.UpdateAfterPrintingForFixed(this.view.AccountNo, printedLine, CurrentUserEntity.CurrentUserID))
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
                        this.ClearControls();
                    }
                }

            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
            }
        }
       

        #endregion

        #region Validation Logic
        
        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            
            if(e.HasXmlBaseError!=false)
                return;    

                try
                {
                   
                    Nullable<CXDMD00011> accountType;
                    IList<PFMDTO00001> customer = new List<PFMDTO00001>();
                    PFMDTO00001 Customer = new PFMDTO00001();
                    if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        string branch=this.view.AccountNo.Substring(0, 3);
                        if (branch != CurrentUserEntity.BranchCode)
                        {
                            //this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode });//Invalid Account No for Branch {0}.
                        }
                        else
                        {
                            customerInfo = CXClientWrapper.Instance.Invoke<ITLMSVE00009, IList<PFMDTO00001>>(x => x.GetCustomerInfoandDepositReceiptNoByAccountNo(this.view.AccountNo));
                            if (customerInfo.Count > 0)
                            {
                                foreach (PFMDTO00001 info in customerInfo)
                                {
                                    if (info.CustomerId != null)
                                    {                                        
                                        Customer = CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00001>(x => x.GetCustomerByCustomerId(info.CustomerId));  //to get Customer Photo and Signature from CustomerId table
                                        info.Signature = Customer.Signature;
                                        //info.CustPhoto.CustPhotos = Customer.CustPhoto.CustPhotos;                                        
                                        info.CustPhotos = Customer.CustPhoto.CustPhotos;
                                        customer.Add(info);
                                    }
                                }
                                this.view.gvCustomer_DataBind(customer);
                                freceipt = customerInfo[0].FreceiptInfo;
                                if (freceipt.Count > 0)
                                {

                                    if (this.Status != "Save")
                                    {
                                        this.accountNo = this.view.AccountNo;
                                        this.view.FReceiptList = freceipt;
                                        this.view.BindReceiptNo();
                                        this.Status = string.Empty;
                                    }
                                    else
                                    {
                                        if (this.view.AccountNo != accountNo)
                                        {
                                            this.view.FReceiptList = freceipt;
                                            this.view.BindReceiptNo();
                                            this.Status = string.Empty;
                                            this.accountNo = this.view.AccountNo;
                                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                                        }
                                    }

                                }
                                else
                                {
                                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00088);//There is no Receipt No to Deposit in this Account.
                                    this.Status = string.Empty;
                                    this.view.DisableControls();
                                }


                            }
                            else
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
                                this.Status = string.Empty;
                            }
                        }
                    }
                    //else
                    //{
                    //    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
                    //}


                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                }
        }
        
        #endregion

    }
}


