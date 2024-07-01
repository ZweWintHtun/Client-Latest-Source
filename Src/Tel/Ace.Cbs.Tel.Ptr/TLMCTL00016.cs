//----------------------------------------------------------------------
// <copyright file="TLMCTL00016.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Su Su Wai</CreatedUser>
// <CreatedDate>09/06/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
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
using Ace.Cbs.Tcm.Dmd;
namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// PO Refund By Cash Entry Controller
    /// </summary>
    public class TLMCTL00016 : AbstractPresenter, ITLMCTL00016
    {
        private ITLMVEW00016 view;
        public ITLMVEW00016 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00016 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetPaymentOrderEntity());
            }
        }

        #region Variable
        public decimal _totalAmt { get; set; }
        private string _counterNo { get; set; }
        #endregion

        #region UI Logic
        public void ClearControls()
        {
            this.ClearTextBox();
            this.View.GroupNo = string.Empty;           
            //this.View.CurrencyCode = string.Empty;
            this.View.VoucherNoLabel = "Voucher No :";
            this.View.EditRowIndex = -1;           
            this.View.PaymentOrderDataSource = null;
            this.View.TotalAmount = 0;
            this.View.BindPaymentOrder();
            this.ClearAllCustomErrorMessage();
        }
        public void ClearTextBox()
        {
            //this.View.BudgetYear = string.Empty;//CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            this.View.PaymentOrderNo = string.Empty;
            this.View.RegisterNo = string.Empty;
            this.View.Amount = 0;
        }

       /*If u want to load Deno Form, Open following method Comments.By HWH*/
        //private CXDTO00001 GetDenoList()
        //{
        //    if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.View.TotalAmount, this.View.CurrencyCode, CXDMD00008.Payment, "frmTLMVEW00016" }) == DialogResult.OK)
        //    {
        //        return CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00016");
        //    }
        //    else
        //    {
        //        ////Error Occur becoz user don't enter deno entry but close the deno form.
        //        //this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
        //        return null;
        //    }
        //}

        public bool AddPaymentOrder()
        {
            TLMDTO00041 paymentOrderEntity = this.GetPaymentOrderEntity();

            if (this.ValidateForm(paymentOrderEntity) && !this.View.HasNotToAdd)
            {
                paymentOrderEntity.Amount = Convert.ToDecimal(this.View.Amount);
                if (this.View.PaymentOrderNo.Substring(0, 2).Equals("IR"))
                {
                    TLMDTO00001 redto = CXClientWrapper.Instance.Invoke<ITLMSVE00020, TLMDTO00001>(x => x.GetRegisterNo(this.View.PaymentOrderNo));
                    if (redto != null)
                        paymentOrderEntity.RegisterNo = redto.RegisterNo;
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00103");
                        //this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MV00103");
                        this.View.FocusOnPOTextBox();
                        return false;
                    }
                }
                if (this.View.PaymentOrderDataSource.Count > 0)
                {
                    var duplicateRecord = this.View.PaymentOrderDataSource.Where(x => x.PaymentOrderNo == paymentOrderEntity.PaymentOrderNo).ToList<TLMDTO00041>();
                    if (duplicateRecord.Count() > 0)
                    {
                        //This P.O No. {0} is already exist in this grid.
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00150, new object[] { paymentOrderEntity.PaymentOrderNo });
                        return false;
                    }
                    this.View.VoucherNoLabel = "Group No :";
                }
                this.View.PaymentOrderDataSource.Add(paymentOrderEntity);
                this._totalAmt = Convert.ToDecimal(this.View.TotalAmount);
                return true;
            }
            else
                return false;
        }
        public bool EditPaymentOrder(int editRowIndex)
        {
            TLMDTO00041 paymentOrderEntity = this.GetPaymentOrderEntity();
            if (this.ValidateForm(paymentOrderEntity))
            {
                int alreadyExistIndex = this.View.PaymentOrderDataSource.ToList().FindIndex(x => x.PaymentOrderNo.Equals(paymentOrderEntity.PaymentOrderNo));
                if (alreadyExistIndex > -1 && (alreadyExistIndex != editRowIndex))
                {
                    //This P.O No. {0} is already exist in this grid.
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00150, new object[] { paymentOrderEntity.PaymentOrderNo });
                    return false;
                }
                this.UpdatePaymentOrderList(editRowIndex, paymentOrderEntity);
                this._totalAmt = Convert.ToDecimal(this.View.TotalAmount);
                return true;
            }
            else
                return false;
        }
        public void Save()
        {
            if (this.HasDataToSave())
            {
                /* Requested by ANS , Modified by HWH.*/
                /* If u want to Load Deno Form, open follow comments.*/

                 //CXDTO00001 denoString = this.GetDenoList();
                 //if (denoString == null)
                 //    return;
                 //else
                 //{                    
                     string voucherNo_Or_groupNo = CXClientWrapper.Instance.Invoke<ITLMSVE00016, string>(x => x.Save(this.View.PaymentOrderDataSource,CurrentUserEntity.BranchCode));

                     #region ErrorOccurred
                     if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                     {
                         string[] logItemForTlf = new string[35];
                         for (int i = 0; i < this.View.PaymentOrderDataSource.Count; i++)
                         {
                             //ClientLog For Tlf
                             if(this.View.PaymentOrderDataSource.Count >1)
                                 logItemForTlf[0] = voucherNo_Or_groupNo;//GroupNo
                             else
                                 logItemForTlf[0] = string.Empty;//GroupNo
                             logItemForTlf[1] = voucherNo_Or_groupNo;//EntryNo
                             logItemForTlf[2] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "Sundry Deposit", this.View.PaymentOrderDataSource[i].CurrencyCode, this.View.PaymentOrderDataSource[i].SourceBranchCode, true });//AcctNo
                             logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "Sundry Deposit", this.View.PaymentOrderDataSource[i].CurrencyCode, this.View.PaymentOrderDataSource[i].SourceBranchCode, true });//ACode(from COASetUp)
                             logItemForTlf[4] = this.View.TotalAmount.ToString();//LocalAmount
                             logItemForTlf[5] = this.View.PaymentOrderDataSource[i].CurrencyCode;//SourceCur
                             logItemForTlf[6] = string.Empty;//Cheque
                             logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                             logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.PaymentOrderDataSource[i].SourceBranchCode).ToString();//SettlementDate
                             logItemForTlf[9] = string.Empty;//Status
                             logItemForTlf[10] = this.View.PaymentOrderDataSource[i].SourceBranchCode;//SourceBr
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
                             logItemForTlf[21] = this.View.PaymentOrderNo;//PoNo
                             logItemForTlf[22] = string.Empty;//ADate
                             logItemForTlf[23] = System.DateTime.Now.ToString();//IDate
                             logItemForTlf[24] = string.Empty;//ToAcctNo
                             logItemForTlf[25] = this.View.PaymentOrderDataSource[i].Charges.ToString();//Income
                             logItemForTlf[26] = this.View.BudgetYear;//Budget
                             logItemForTlf[27] = string.Empty;//FromBranch
                             logItemForTlf[28] = string.Empty;//ToBranch
                             logItemForTlf[29] = string.Empty;//Inout
                             logItemForTlf[30] = string.Empty;//Success
                             logItemForTlf[31] = string.Empty;//COMMUCHARGE
                             logItemForTlf[32] = string.Empty;//IncomeType
                             logItemForTlf[33] = string.Empty;//OtherBank
                             logItemForTlf[34] = string.Empty;//OtherBankChq
                             TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Refund(ByCash) Fail Transaction", CurrentUserEntity.BranchCode,
                             logItemForTlf);
                         }
                         this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode, this.view.PaymentOrderNo);
                     }
                     #endregion

                     #region Successful
                     else
                     {
                         string[] logItemForTlf = new string[35];
                         for (int i = 0; i < this.View.PaymentOrderDataSource.Count; i++)
                         {
                             //ClientLog For Tlf
                             if (this.View.PaymentOrderDataSource.Count > 1)
                                 logItemForTlf[0] = voucherNo_Or_groupNo;//GroupNo
                             else
                                 logItemForTlf[0] = string.Empty;//GroupNo
                             logItemForTlf[1] = voucherNo_Or_groupNo;//EntryNo
                             logItemForTlf[2] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "Sundry Deposit", this.View.PaymentOrderDataSource[i].CurrencyCode, this.View.PaymentOrderDataSource[i].SourceBranchCode, true });//AcctNo
                             logItemForTlf[3] = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "Sundry Deposit", this.View.PaymentOrderDataSource[i].CurrencyCode, this.View.PaymentOrderDataSource[i].SourceBranchCode, true });//ACode(from COASetUp)
                             logItemForTlf[4] = this.View.TotalAmount.ToString();//LocalAmount
                             logItemForTlf[5] = this.View.PaymentOrderDataSource[i].CurrencyCode;//SourceCur
                             logItemForTlf[6] = string.Empty;//Cheque
                             logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                             logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.PaymentOrderDataSource[i].SourceBranchCode).ToString();//SettlementDate
                             logItemForTlf[9] = string.Empty;//Status
                             logItemForTlf[10] = this.View.PaymentOrderDataSource[i].SourceBranchCode;//SourceBr
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
                             logItemForTlf[21] = this.View.PaymentOrderNo;//PoNo
                             logItemForTlf[22] = string.Empty;//ADate
                             logItemForTlf[23] = System.DateTime.Now.ToString();//IDate
                             logItemForTlf[24] = string.Empty;//ToAcctNo
                             logItemForTlf[25] = this.View.PaymentOrderDataSource[i].Charges.ToString();//Income
                             logItemForTlf[26] = this.View.BudgetYear;//Budget
                             logItemForTlf[27] = string.Empty;//FromBranch
                             logItemForTlf[28] = string.Empty;//ToBranch
                             logItemForTlf[29] = string.Empty;//Inout
                             logItemForTlf[30] = string.Empty;//Success
                             logItemForTlf[31] = string.Empty;//COMMUCHARGE
                             logItemForTlf[32] = string.Empty;//IncomeType
                             logItemForTlf[33] = string.Empty;//OtherBank
                             logItemForTlf[34] = string.Empty;//OtherBankChq
                             TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Refund(ByCash) Commit Transaction", CurrentUserEntity.BranchCode,
                             logItemForTlf);
                         }
                         this.View.GroupNo = voucherNo_Or_groupNo;

                         //P.O Refund Process is Successfully finished. Generated Voucher No is {0}.
                         this.View.Successful(CXMessage.MI00033, voucherNo_Or_groupNo);
                     }
                    #endregion
                 //}
            }
            else
            {
                // At least one records must be exist to save. 
                this.View.Failure(CXMessage.MV00107,this.view.PaymentOrderNo);
            }
        }       
        #endregion

        #region Validation Logic

        public void txtBudgetYear_CustomValidating(object sender, ValidationEventArgs e)
        {
           if (e.HasXmlBaseError == false) 
                {
                    if (String.IsNullOrEmpty(this.View.PaymentOrderNo) || !this.View.PaymentOrderNo.Length.Equals(Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POFromat))))
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MV00103");
                        return;
                    }                
                        TLMDTO00016 poDTO = CXClientWrapper.Instance.Invoke<ICXSVE00006, TLMDTO00016>(x => x.GetPOByPoNoandBudgetYear(this.View.PaymentOrderNo, this.View.BudgetYear, CurrentUserEntity.BranchCode));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            
                            this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode, this.view.PaymentOrderNo);
                            this.View.HasNotToAdd = true;
                            if (CXClientWrapper.Instance.ServiceResult.MessageCode == "MV00143")
                            {
                                this.View.FocusOnPOTextBox();                            
                            }                           
                        }
                        else if (poDTO.IDate != null)
                        {
                            this.View.Failure(CXMessage.MV00143, this.View.PaymentOrderNo);//This P.O No. {0} is already received.
                            this.View.HasNotToAdd = true;
                        }
                        else if (poDTO.Currency != this.View.CurrencyCode)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), CXMessage.MV00151, new object[]{"PO" , this.View.CurrencyCode});//The currency of this P.O No. is not {0}.
                            //this.View.Failure(CXMessage.MV00151, "PO", this.View.CurrencyCode);//The currency of this P.O No. is not {0}.
                            this.View.HasNotToAdd = true;
                        }
                        else
                        {
                            this.View.Amount = Convert.ToDouble(poDTO.Amount);                            
                            if (this.View.PaymentOrderDataSource.Count > 0)
                            {
                                if (this.View.EditRowIndex.Equals(-1))
                                    this.View.TotalAmount = Convert.ToDouble(this._totalAmt) + Convert.ToDouble(poDTO.Amount);
                                else
                                {
                                    this.View.TotalAmount = Convert.ToDouble(this.CalculateTotalAmount(poDTO.Amount, this.View.EditRowIndex));
                                }
                            }
                            else
                            {
                                this.View.TotalAmount = Convert.ToDouble(poDTO.Amount);
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
                   this.SetCustomErrorMessage(this.GetControl("txtPaymentOrderNo"), "MV00103");
                   return;
                }
            }
        }

        #endregion

        #region Helper Methods

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

        private bool HasDataToSave()
        {
            return (this.View.PaymentOrderDataSource.Count < 1) ? false : true;
        }

        private TLMDTO00041 GetPaymentOrderEntity()
        {
            TLMDTO00041 paymentOrderEntity = new TLMDTO00041();

            paymentOrderEntity.BudgetYear = this.View.BudgetYear;
            paymentOrderEntity.PaymentOrderNo = this.View.PaymentOrderNo;
            paymentOrderEntity.CurrencyCode = this.View.CurrencyCode;
            paymentOrderEntity.RegisterNo = this.View.RegisterNo;
            paymentOrderEntity.Amount = Convert.ToDecimal(this.View.Amount);           
            paymentOrderEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            paymentOrderEntity.SourceBranchCode = this.View.SourceBranchCode;
            //paymentOrderEntity.CounterNo = CurrentUserEntity.CounterList[0].CounterNo; //Edited by HOW (check for counteruser)
            return paymentOrderEntity;
        }

        private void UpdatePaymentOrderList(int index, TLMDTO00041 paymentOrderEntity)
        {
            this.View.PaymentOrderDataSource[index].BudgetYear = paymentOrderEntity.BudgetYear;
            this.View.PaymentOrderDataSource[index].PaymentOrderNo = paymentOrderEntity.PaymentOrderNo;
            this.View.PaymentOrderDataSource[index].CurrencyCode = paymentOrderEntity.CurrencyCode;
            this.View.PaymentOrderDataSource[index].RegisterNo = paymentOrderEntity.RegisterNo;
            this.View.PaymentOrderDataSource[index].Amount = paymentOrderEntity.Amount;           
        }
        private decimal CalculateTotalAmount(decimal amount, int index)
        {
            decimal totalAmount = 0;
            for (int i = 0; i < this.View.PaymentOrderDataSource.Count; i++)
            {
                if (i == index)
                    totalAmount += amount;
                else
                    totalAmount += this.View.PaymentOrderDataSource[i].Amount;
            }
            return totalAmount;
        }
        
        //Added by HMW for new the budget year change
        public string GetBudYear()
        {
            string Return = string.Empty;                        
            string activeBudget = CXClientWrapper.Instance.Invoke<ITLMSVE00016, string>(x => x.GetBudYear(6, DateTime.Now, CurrentUserEntity.BranchCode));
            return activeBudget;
        }
        #endregion
    }
}
