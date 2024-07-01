//----------------------------------------------------------------------
// <copyright file="TLMCTL00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Tel.Ptr
{
    //Fixed Deposit Withdraw Controller
    public class TLMCTL00013 : AbstractPresenter, ITLMCTL00013
    {
        #region Initialize View
        private ITLMVEW00013 view;
        public ITLMVEW00013 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        
        private void WireTo(ITLMVEW00013 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetFixedDepositEntity());
            }
        }
        #endregion

        #region Properties
        PFMDTO00032 receiptInfo { get; set; }
        TLMDTO00041 fixedDepositEntity { get; set; }
        decimal interest { get; set; }
        int count=0;
        public bool validateStatus = true;
        #endregion

        #region UI Logic
        public void ClearControls()
        {
           // this.view.ReceiptNo = (!string.IsNullOrEmpty(this.view.ReceiptNo))? string.Empty: this.view.ReceiptNo;
            this.view.ReceiptNo = string.Empty;
            this.view.AccountNo = string.Empty;
            this.view.VoucherNo = string.Empty;
            this.view.RegisterDuration = string.Empty;
            this.view.RegisterDate = string.Empty;
            this.view.Amount = 0;
            this.view.TotalAmount = 0;
            this.view.AvailableInterestAfterTax = 0;           
            this.view.NoOfPerson = 0;
            this.view.JoinType = string.Empty;
            this.view.Photo = null;
            this.view.Signature = null;
        }

        public TLMDTO00041 fw { get; set; }

        public void SaveFixedDepositWithdraw()
        {
            try
            {
                //if (this.Validate())
                //{
                    if (this.validateStatus == true)//check by hmw to avoid updating the validate mehtod, I don't edit the original validate method. current status is ok for program
                    {
                        IList<TLMDTO00041> fixedDepositEntityList = new List<TLMDTO00041>();
                        TLMDTO00041 fixedDepositEntity = new TLMDTO00041();
                        fixedDepositEntity = GetFixedDepositEntity();
                        fixedDepositEntity.ReceiptNo = this.fw.ReceiptNo;
                        fixedDepositEntity.AccountSignature = this.view.AccountSign;
                        fixedDepositEntity.Description = this.view.Name;
                        fixedDepositEntity.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                        fixedDepositEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                        fixedDepositEntity.SourceBranchCode = CurrentUserEntity.BranchCode;
                        fixedDepositEntity.Amount = fw.Amount;
                        #region oldcode
                        //if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.view.TotalAmount, this.view.CurrencyCode, CXDMD00008.Payment, "frmTLMVEW00013" }) == DialogResult.OK)
                        //{
                        //  //  CXDTO00001 deno = CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00013");
                        //    //if (deno != null)
                        //    //{
                        //    //    fixedDepositEntity.DenoDetail = deno.DenoString;
                        //    //    fixedDepositEntity.DenoRate = deno.DenoRateString;
                        //    //    fixedDepositEntity.DenoRefundDetail = deno.RefundString;
                        //    //    fixedDepositEntity.DenoRefundRate = deno.RefundRateString;
                        //    //    fixedDepositEntity.CounterNo = deno.CounterNo;
                        //    //    fixedDepositEntity.TotalAmount = deno.TotalAmount;
                        //    //    fixedDepositEntity.AdjustAmount = deno.AdjustAmount;
                        //    //}
                        //    //else
                        //    //{
                        //    //    //Error Occur becoz user don't enter deno entry but close the deno form.
                        //    //    this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                                
                        //    //}
                        //}
                        //else
                        //{
                        //    return;
                        //}
                        #endregion
                        fixedDepositEntityList.Add(fixedDepositEntity);

                        if (this.view.AvailableInterestAfterTax > 0)
                        {
                            TLMDTO00041 fixedDepositEntity2 = new TLMDTO00041();
                            fixedDepositEntity2 = GetFixedDepositEntity();
                            fixedDepositEntity2.AccountNo = null;
                            fixedDepositEntity2.AccountSignature = this.view.AccountSign;
                            fixedDepositEntity2.Description = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixedInterestDeposit);
                            fixedDepositEntity2.Amount = fw.TotalAmount;
                            fixedDepositEntityList.Add(fixedDepositEntity2);
                        }                    

                        string voucherNo = CXClientWrapper.Instance.Invoke<ITLMSVE00013, string>(x => x.SaveFixedDepositWithdraw(fixedDepositEntityList));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            string[] logItemForTlf = new string[35];
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = voucherNo;//EntryNo
                            logItemForTlf[2] = fixedDepositEntity.AccountNo;//AcctNo
                            logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fixedDepositEntity.CurrencyCode, fixedDepositEntity.SourceBranchCode, true });//ACode(from COASetUp)
                            logItemForTlf[4] = fixedDepositEntity.Amount.ToString();//LocalAmount
                            logItemForTlf[5] = fixedDepositEntity.CurrencyCode;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fixedDepositEntity.SourceBranchCode).ToString();//SettlementDate
                            logItemForTlf[9] = string.Empty;//Status
                            logItemForTlf[10] = fixedDepositEntity.SourceBranchCode;//SourceBr
                            logItemForTlf[11] = string.Empty;//Rno
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
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "FixedDeposit Withdrawl Fail Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);




                            this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            string[] logItemForTlf = new string[35];
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = voucherNo;//EntryNo
                            logItemForTlf[2] = fixedDepositEntity.AccountNo;//AcctNo
                            logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), fixedDepositEntity.CurrencyCode, fixedDepositEntity.SourceBranchCode, true });//ACode(from COASetUp)
                            logItemForTlf[4] = fixedDepositEntity.Amount.ToString();//LocalAmount
                            logItemForTlf[5] = fixedDepositEntity.CurrencyCode;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), fixedDepositEntity.SourceBranchCode).ToString();//SettlementDate
                            logItemForTlf[9] = string.Empty;//Status
                            logItemForTlf[10] = fixedDepositEntity.SourceBranchCode;//SourceBr
                            logItemForTlf[11] = string.Empty;//Rno
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
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "FixedDeposit Withdrawl Commit Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);

                           //this.view.VoucherNo = voucherNo;
                            this.view.Successful("MI00051", voucherNo);//Saving Successful.
                            if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.Yes)//Are you sure to print?
                            {
                                this.Printing();
                            }
                             this.ClearControls();
                             this.view.gvClearing_DataSourceNull();
                        }
                    }                    
                //}
            }
            catch (Exception ex)
            { }
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

                    if (!CXCLE00006.Instance.UpdateAfterPrintingForFixed(this.view.AccountNo, printedLine,CurrentUserEntity.CurrentUserID))
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
                }
            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
            }
        }
        #endregion

        #region Helper Methods
        private TLMDTO00041 GetFixedDepositEntity()
        {
            //Get View Data
            TLMDTO00041 fixedDepositEntity = new TLMDTO00041();
            fixedDepositEntity.VoucherNo = this.view.VoucherNo;
            fixedDepositEntity.AccountNo = this.view.AccountNo;
            fixedDepositEntity.ReceiptNo = this.view.ReceiptNo;
            fixedDepositEntity.RegisterDuration = this.view.RegisterDuration;
            fixedDepositEntity.RegisterDate = this.view.RegisterDate;
            fixedDepositEntity.Amount = this.view.Amount;
            fixedDepositEntity.TotalAmount = this.view.TotalAmount;
            fixedDepositEntity.AvailableInterestAfterTax = this.view.AvailableInterestAfterTax;
            fixedDepositEntity.CurrencyCode = this.view.CurrencyCode;
            fixedDepositEntity.NoOfPersonSign = this.view.NoOfPerson;
            fixedDepositEntity.JoinType = this.view.JoinType;
            fixedDepositEntity.AccuredStatus = this.view.AccuredStatus;
            fixedDepositEntity.InterestRate = this.view.InterestRate;
            return fixedDepositEntity;
        }
        #endregion

        #region Validation Logic
        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            
            if (e.HasXmlBaseError)
            {
                this.SetFocus("mtxtAccountNo");
                return;
            }
            else
            {
                try
                {
                    //this.view.Select();
                    Nullable<CXDMD00011> accountType;
                    IList<PFMDTO00001> customer = new List<PFMDTO00001>();
                    if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                    {
                        string branch = this.view.AccountNo.Substring(0, 3);
                        if (branch != CurrentUserEntity.BranchCode)
                        {
                            //this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode});//Invalid Account No for Branch {0}.
                            return;
                        }
                        else
                        {
                            IList<PFMDTO00001> customerInfo = CXClientWrapper.Instance.Invoke<ITLMSVE00013, IList<PFMDTO00001>>(x => x.GetCustomerInfoAndWithdrawalReceiptNoByAccountNumber(this.view.AccountNo));
                            if (customerInfo.Count > 0)
                            {
                                foreach (PFMDTO00001 info in customerInfo)
                                {
                                    if (info.CustomerId != null)
                                    {
                                        customer.Add(info);
                                    }
                                }
                                this.view.gvCustomer_DataBind(customer);
                                this.view.Name = customerInfo[0].Name;
                                if (customerInfo.Count == 1)
                                {
                                    this.view.NoOfPerson = 1;
                                }
                                else
                                {
                                    this.view.NoOfPerson = customerInfo[0].NoOfPersonSign;
                                }                                
                                this.view.JoinType = customerInfo[0].JoinType;
                                this.view.AccountSign = customerInfo[0].AccountSign;
                                this.view.Photo = CXClientGlobal.GetImage(customerInfo[0].CustPhotos);
                                this.view.Signature = CXClientGlobal.GetImage(customerInfo[0].Signature);
                                this.view.EnableControls();
                                IList<PFMDTO00032> freceipt = new List<PFMDTO00032>();

                                if (customerInfo[0].FreceiptInfo.Count > 0)
                                {
                                    freceipt = customerInfo[0].FreceiptInfo;
                                    if (string.IsNullOrEmpty(this.view.Status) || this.view.Status == null)
                                    {
                                        this.view.receiptNoList = freceipt;
                                        this.view.BindReceiptNo(this.view.receiptNoList);
                                        count = freceipt.Count;
                                        this.Clear();

                                    }
                                    else
                                    {
                                            if (this.view.AccountNo != null && this.view.ReceiptNo != null)
                                            {
                                                PFMDTO00032 freceiptInfo = CXClientWrapper.Instance.Invoke<ITLMSVE00013, PFMDTO00032>(x => x.CheckReceiptNoNotDepositedOrAlreadyWithdrawn(this.view.AccountNo, this.view.ReceiptNo, CurrentUserEntity.BranchCode));
                                                if (freceiptInfo.LastInterestDate == null || freceiptInfo.LastInterestDate == DateTime.MinValue)
                                                {
                                                    validateStatus = false;
                                                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00145, new object[] { this.view.AccountNo });//Warning… {0} Account has not deposit.                                            
                                                    return;

                                                }
                                                else if (freceiptInfo.WithdrawDate != null && freceiptInfo.WithdrawDate != DateTime.MinValue)
                                                {
                                                    validateStatus = false;
                                                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00147, new object[] { this.view.ReceiptNo });//Receipt No {0}  has Already Withdrawn.                                            
                                                    //this.SetFocus("cboReceiptNo"); 
                                                    this.SetEnableDisable("cboReceiptNo", true);
                                                    return;
                                                }
                                            }
                                            this.view.receiptNoList = freceipt;
                                            this.view.Status = string.Empty;
                                            this.Clear();
                                        }
                                }
                                else
                                {
                                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00088);//There is no Receipt No to Deposit in this Account.  
                                    this.SetEnableDisable("cboReceiptNo", false);                                  
                                    return;
                                }
                            }
                            else
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No. 
                                this.SetEnableDisable("cboReceiptNo", false);       
                                return;
                            }
                        }
                     
                       //this.SetFocus("cboReceiptNo"); 
                       this.SetEnableDisable("cboReceiptNo", true);   
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
                }
            }        
        }

        public void cboReceiptNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError || string.IsNullOrEmpty(this.View.ReceiptNo))
            {
                this.SetFocus("cboReceiptNo");
                return;
            }
                
        }
        
        public bool Validate()
        {
            this.fw =  this.GetFixedDepositEntity();
            return this.ValidateForm(this.fw);    
            //return true;
        
        }

        #endregion


        public void FixInterestCalculation()
        {
            int daysInYear = 0;
            DateTime datetime = DateTime.Now;
            int year = datetime.Year;
            if ((year % 4) == 0)
            {
                daysInYear = 366;
            }
            else
            {
                daysInYear = 365;
            }

            if (this.view.AccuredStatus == "00")
            {
                this.view.MatureStatus = this.MatureStatus(this.view.LastIntDate, this.view.Duration);
                if (this.view.MatureStatus == false)
                {
                    //use sp
                    PFMDTO00042 InterestDTO = CXClientWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetInterest(this.view.LastIntDate, this.view.Amount, CurrentUserEntity.CurrentUserID));
                    this.InterestData(InterestDTO);
                  
                }
                else
                {
                    if (this.view.Duration >= 12)//for Year
                    {
                        this.view.AvailableInterestAfterTax = (this.view.Amount * this.view.InterestRate / 100 * this.view.Duration) + this.view.Accrued;
                    }
                    else if (this.view.Duration >= 1)//for Month
                    {
                        this.view.AvailableInterestAfterTax = (this.view.Amount * this.view.InterestRate / 100 * this.view.Duration / 12) + this.view.Accrued;
                    }
                    else//for Week
                    {
                        this.view.AvailableInterestAfterTax = (this.view.Amount * this.view.InterestRate / 100 / daysInYear * (this.view.Duration * 4) * 7) + this.view.Accrued;
                    }
                }
            }
            else
            {
                //use sp
                this.view.MatureStatus = this.MatureStatus(this.view.LastIntDate, this.view.Duration);
                PFMDTO00042 InterestDTO = CXClientWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetInterest(this.view.LastIntDate, this.view.Amount, CurrentUserEntity.CurrentUserID));
                this.InterestData(InterestDTO);
            }
        }

        public bool MatureStatus(DateTime date, decimal duration)
        {
            bool result = false;
            PFMDTO00042 MatureDTO = CXClientWrapper.Instance.Invoke<ICXSVE00010, PFMDTO00042>(x => x.GetMatureDate(date, duration, date, CurrentUserEntity.CurrentUserID));
            if (MatureDTO.MatureDate > DateTime.Now)
            { result = false; }
            else
            { result = true; }
            return result;
        }

        public void InterestData(PFMDTO00042 InterestDTO)
        {
            string interest = Convert.ToString(InterestDTO.ReturnInterest);
            if (!string.IsNullOrEmpty(interest))
            {
                this.view.AvailableInterestAfterTax = InterestDTO.ReturnInterest;
            }
            else
            {
                this.view.AvailableInterestAfterTax = 0;

            }
        }

        public void Clear()
        {
            this.view.RegisterDuration = string.Empty;
            this.view.Amount = 0;
            this.view.AvailableInterestAfterTax = 0;
            this.view.RegisterDate = string.Empty;
            this.view.TotalAmount = 0;

        }
    }
}












    
