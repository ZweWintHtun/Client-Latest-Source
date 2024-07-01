//----------------------------------------------------------------------
// <copyright file="TLMCTL00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>AK</CreatedUser>
// <CreatedDate></CreatedDate>
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
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using System.Linq;
using System.Collections;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00003 : AbstractPresenter, ITLMCTL00003
    {
        #region Properties

        private ITLMVEW00003 view;
        decimal d1, d2;
        private IList<PFMDTO00001> customerInformation;
        public IList<PFMDTO00001> CustomerInformation 
        { 
            get
            {
                if (this.customerInformation == null)
                    this.customerInformation = new List<PFMDTO00001>();
                return customerInformation;
            }
            set
            { this.customerInformation = value; }
        }
        public ITLMVEW00003 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00003 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.View.TransferEntity);
            }
        }
        private CXDMD00010 permissionEntity;
        public CXDMD00010 PermissionEntity
        {
            get 
            {
                if (permissionEntity == null)
                    permissionEntity = new CXDMD00010();
                return permissionEntity;
            }
            set
            {
                permissionEntity = value;
            }
        }
        int printedLine;

        #endregion

        #region UI Logic Method      

        public void ClearControls(bool isGird)
        {
            if (isGird)
            {
                this.View.DisableControlsforView("Curreny.Enable");
                this.View.VoucherNo = string.Empty;
                //this.view.Currency = string.Empty;
                this.View.DenoCollection.Clear();
                this.View.BindData();
                View.SetCursor("Currency");
                this.View.BranchCode = string.Empty;
                this.View.IsDebitTransaction = true;
                this.view.Commissions = 0;
                this.view.CommunicationCharges = 0;                
                this.View.TransactionForControls(true, true,false);
            }
            this.View.IsVIP = false;
            this.view.AccountNo = string.Empty;
            this.view.Description = string.Empty;
            this.view.Narration = string.Empty;
            this.View.ChequeNo = string.Empty;
            this.view.Amount = 0;            
            this.view.InputIncomeAmount = false;
            this.view.PrintTransactions = false;
            this.View.Status = "Add";
            this.ClearErrors();
        }

        public void cboCurrency_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError || string.IsNullOrEmpty(this.View.Currency))
                return;
            else
                this.View.DisableControlsforView("Curreny.Disable");
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError || !this.View.TransferEntity.IsCheckCustomAccountValidation)
                    return;
                //if (this.View.DenoCollection.Count > 0)
                //{
                //    foreach (TLMDTO00038 info in this.View.DenoCollection)
                //        if (info.AccountNo == this.View.AccountNo && this.View.Status == "Add")
                //        {
                //            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV90001); // Data Already Exits.
                //            return;
                //        }
                //}
                CustomerInformation.Clear();
                Nullable<CXDMD00011> accountType;
                Decimal CBalAmount = 0;
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    CustomerInformation = CXClientWrapper.Instance.Invoke<ITLMSVE00003, IList<PFMDTO00001>>(x => x.SelectByAccountNumber(this.View.AccountNo,DateTime.Now));
                    this.View.AllowedPrinting = true;
                    
                    //Added By AAM (31_July_2018)
                    if (this.view.IsCreditTransaction== true && (this.View.Status == "Add" || this.View.Status == "Update") && this.View.Amount != 0)
                    {
                        CustomerInformation = CXClientWrapper.Instance.Invoke<ITLMSVE00003, IList<PFMDTO00001>>(x => x.SelectByAccountNumber_ForAllowCrTrans(this.View.AccountNo, DateTime.Now));
                    }

                    if (view.IsDebitTransaction == true && (this.View.Status == "Add" || this.View.Status == "Update") && this.View.Amount != 0)
                    {
                        CBalAmount =CXClientWrapper.Instance.Invoke<ICXSVE00006, PFMDTO00028>(x => x.SelectCurrentBalanceByAccountNo(this.View.AccountNo)).CurrentBal;
                        if (CBalAmount < view.Amount)//Checking Insufficient Amount
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtAmount"), CXMessage.MV00109);
                            return;
                        }
                    }

                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }
                    else 
                    {
                        if (this.CustomerInformation[0].SourceBranch == CurrentUserEntity.BranchCode)
                        { 
                            this.view.DisableEnableControl(false);
                          //this.View.LocationTransactions = true;
                        }
                        else 
                        { 
                            this.view.DisableEnableControl(true);
                        //this.View.LocationTransactions = false;
                        }
                    }
                }
                else if (accountType == CXDMD00011.DomesticAccountType)
                {
                    this.view.LocationTransactions = true;
                    ChargeOfAccountDTO COAinfo = CXCLE00002.Instance.GetClientData<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { this.View.AccountNo, this.View.LocalBranchCode, true });
                    if (COAinfo == null)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                        return;
                    }
                    else if (!this.View.LocationTransactions)
                    {
                        // Invalid Branch Code
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00165, new object[] { "Local or Other Branch " });
                        return;
                    }
                    this.View.AllowedPrinting = false;
                    this.View.LocationTransactions = true;
                    this.View.IsDomesticAccount = true;
                    PFMDTO00001 CustomerInfo = new PFMDTO00001();
                    CustomerInfo.Name = COAinfo.AccountName;
                    CustomerInfo.AccountSign = string.Empty;
                    CustomerInfo.SourceBranch = this.View.LocalBranchCode;
                    CustomerInfo.CurrencyCode = this.View.Currency;
                    this.CustomerInformation.Add(CustomerInfo);
                    this.View.BranchCode = CustomerInfo.SourceBranch;
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                    return;
                }

                if (CustomerInformation != null || customerInformation.Count > 0)
                {
                    //Added by ZMS  for Pristine Requirements (even loans are expired ,they wanted to make transfer )
                    if (CustomerInformation[0].ExpiredStatus == true)
                    {                      
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90059);///This loan no. is expired!                                      
                    }

                    //Added by HMW to show all customer names at Grid View (15-05-2019)
                    this.view.Description=null;
                    for (int i = 0; i <= customerInformation.Count-1; i++)
                    {
                        //this.View.Description = CustomerInformation[0].Name;
                        if (this.view.Description == null || this.view.Description == "")
                        {
                            this.view.Description += customerInformation[i].Name;
                        }
                        else
                        {
                            this.view.Description += ", "+customerInformation[i].Name;
                        }
                    }
                    this.View.CurrentBalance = CustomerInformation[0].CurrentBal;
                    this.view.IsCurrentAccount = string.IsNullOrEmpty(CustomerInformation[0].AccountSign) ? false : (CustomerInformation[0].AccountSign.Substring(0, 1).Equals("C") ? true : false);
                    this.View.AccountSign = CustomerInformation[0].AccountSign;
                    this.View.BranchCode = CustomerInformation[0].SourceBranch;

                    if (CustomerInformation[0].CurrencyCode != this.View.Currency)
                    {
                        // Invalid Currency
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00086, new object[] { this.View.Currency });
                        return;
                    }
                    else if (this.View.DenoCollection.Count == 0)
                    {
                        this.View.LocationTransactions = this.View.LocalBranchCode.Equals(CustomerInformation[0].SourceBranch) ? true : false;
                    }
                    else if (this.View.DenoCollection.Count == 1 && this.View.LocationTransactions && !this.View.IsDomesticAccount)
                    {
                        this.View.LocationTransactions = this.View.BranchCode == this.View.LocalBranchCode ? true : false;
                    }
                    else if (this.View.DenoCollection.Count == 2)//add by ksw
                    {
                        var debit = from value in View.DenoCollection where value.IsDebit == true select value;
                        var credit = from value in View.DenoCollection where value.IsCredit == true select value;

                        //TLMDTO00038 debitTransactionInfo = debit.ToList<TLMDTO00038>()[0];
                        //TLMDTO00038 creditTransactionInfo = credit.ToList<TLMDTO00038>()[0];
                        //debitTransactionInfo = debit.ToList<TLMDTO00038>()[0];
                        //creditTransactionInfo = credit.ToList<TLMDTO00038>()[0];
                        // if (!this.View.IsDomesticAccount)
                        //{
                        //    this.View.LocationTransactions = debitTransactionInfo.BranchCode == this.View.BranchCode && creditTransactionInfo.BranchCode == this.View.BranchCode ? true : false;
                        //}

                        TLMDTO00038 creditTransactionInfo=null;
                        TLMDTO00038 debitTransactionInfo = null;
                        int crCount = 0, drCount = 0;
                        if (debit.ToList<TLMDTO00038>().Count >= 1)
                        {
                            if (debit.ToList<TLMDTO00038>()[0].IsDebit == true)
                            {
                                drCount = drCount+1;
                                debitTransactionInfo = debit.ToList<TLMDTO00038>()[0];
                            }
                        }
                        if (credit.ToList<TLMDTO00038>().Count >= 1)
                        {
                            if (credit.ToList<TLMDTO00038>()[0].IsCredit == true)
                            {
                                crCount = crCount+1;
                                creditTransactionInfo = credit.ToList<TLMDTO00038>()[0];
                            }
                        }

                         if (!this.View.IsDomesticAccount)
                        {
                            if (crCount > 0 && drCount > 0)
                            {
                                this.View.LocationTransactions = debitTransactionInfo.BranchCode == this.View.BranchCode && creditTransactionInfo.BranchCode == this.View.BranchCode ? true : false;
                            }
                        }
                    }
                    else
                    {
                        if (this.View.FormName == "TrLocal")
                        {
                            if (this.View.LocationTransactions)
                            {
                                if (this.View.LocalBranchCode != CustomerInformation[0].SourceBranch)
                                {
                                    // Invalid Branch Code
                                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00165, new object[] { this.View.LocationTransactions ? "Local Branch " : "Other Branch" });
                                    return;
                                }
                            }
                        }
                    }
                    this.View.TransactionForControls(this.View.IsDebitTransaction ? true : false, this.View.LocationTransactions, this.View.AllowedPrinting);
                }
                else
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }

        public void txtChequeNo_Validating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError)
                    return;
                else
                    this.view.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), ex.Message);
            }
        }

        public bool ValidateAdd()
        {
            return this.ValidateForm(this.View.TransferEntity);
        }

        public bool Save()
        {
            if (this.View.FormName == "TrOnline") //add by ksw
            {

                if (this.View.Status != "Add")
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00170);
                    return false;
                }
                var debit = from value in View.DenoCollection where value.IsDebit == true select value;
                var credit = from value in View.DenoCollection where value.IsCredit == true select value;

                TLMDTO00038 debitTransactionInfo = debit.ToList<TLMDTO00038>()[0];
                TLMDTO00038 creditTransactionInfo = credit.ToList<TLMDTO00038>()[0];
                string sourceBr = CurrentUserEntity.BranchCode;

                if (debitTransactionInfo.AccountNo.Substring(0, 3) == sourceBr && creditTransactionInfo.AccountNo.Substring(0, 3) == sourceBr)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30039); //Invalid Branch Transaction.Please Check Branch Code.
                    return false;
                }

            }

            if (this.View.Status != "Add")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00170);
                return false;
            }
            else if (this.View.DenoCollection.Count != 0 || this.ValidateForm(this.View.TransferEntity))
            {

                if (CXUIScreenTransit.Transit("frmCXCLE00016", true, new object[] { "frmTLMVEW00003", CXDMD00006.Other, PermissionEntity, false }) == DialogResult.OK)
                {
                    string VoucherNo = string.Empty;
                    this.PermissionEntity = CXUIScreenTransit.GetData<CXDMD00010>("frmTLMVEW00003");

                    if (this.CheckDebitCharges())
                    {
                        //if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.View.Commissions + this.View.CommunicationCharges, this.View.Currency, CXDMD00008.Received, "frmTLMVEW00003" }) == DialogResult.OK)
                        //{
                        //    this.View.DenoInfo = CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00003");

                        //this.View.DenoCollection = this.GetDenoData(this.View.DenoInfo, this.View.DenoCollection);
                        //}
                        //else
                        //    return false;
                    }

                    this.View.DenoCollection = this.GetDepositInfoToSave(this.View.DenoCollection);

                    if (this.View.TransferEntity.HomeExchangeRate == 0)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00013);
                        this.View.TransferEntity.HomeExchangeRate = 1;
                        return false;
                    }

                    if (this.View.LocationTransactions)
                        VoucherNo = CXClientWrapper.Instance.Invoke<ITLMSVE00003, string>(x => x.SaveLocalTransfer(this.View.DenoCollection));
                    else
                        VoucherNo = CXClientWrapper.Instance.Invoke<ITLMSVE00003, string>(x => x.SaveOnlineTransfer(this.View.DenoCollection));

                    #region ErrorOccurred
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        //ClientLog For Local Transfer
                        if (this.View.LocationTransactions)
                        {
                            IList<TLMDTO00038> TransferInfoList = new List<TLMDTO00038>();
                            for (int i = 0; i < this.View.DenoCollection.Count; i++)
                            {
                                string[] logItem = new string[35];
                                this.View.DenoCollection[i].NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DenoCollection[i].SourceBranch);
                                logItem[0] = string.Empty;//GroupNo
                                logItem[1] = VoucherNo;//EntryNo
                                logItem[2] = this.View.DenoCollection[i].AccountNo;//AcctNo
                                if (this.View.DenoCollection[i].AccountSign.Length > 0)
                                {
                                    if (this.View.DenoCollection[i].AccountSign.StartsWith("C"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("S"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("L"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("F"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                                }
                                else
                                {
                                    logItem[3] = this.View.DenoCollection[i].AccountNo;//ACode(from COASetUp)
                                }
                                logItem[4] = this.View.DenoCollection[i].TotalAmount.ToString();//LocalAmount
                                logItem[5] = this.View.DenoCollection[i].Currency;//SourceCur
                                logItem[6] = this.View.DenoCollection[i].ChequeNo;//Cheque
                                logItem[7] = System.DateTime.Now.ToString();//Date_Time
                                logItem[8] = this.View.DenoCollection[i].NextSettlementDate.ToString();//SettlementDate
                                if (this.View.DenoCollection[i].VoucherType.StartsWith("D"))
                                {
                                    string tranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucherCode);
                                    logItem[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tranCode }).Status;//TRDEBIT;//Status
                                }
                                else if (this.View.DenoCollection[i].VoucherType.StartsWith("C"))
                                {
                                    string tranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucherCode);
                                    logItem[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tranCode }).Status;//TRCREDIT;//Status
                                }
                                else
                                    logItem[9] = string.Empty;//Status
                                logItem[10] = this.View.DenoCollection[i].BranchCode;//SourceBr
                                logItem[11] = string.Empty;//Rno
                                logItem[12] = string.Empty;//Duration
                                logItem[13] = string.Empty;//LasintDate
                                logItem[14] = CXCOM00010.Instance.GetExchangeRate(this.View.DenoCollection[i].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//intRate
                                logItem[15] = string.Empty;//Accured
                                logItem[16] = string.Empty;//BudenAcc
                                logItem[17] = string.Empty;//Draccured
                                logItem[18] = string.Empty;//AccuredStatus
                                logItem[19] = string.Empty;//ToAccountNo
                                logItem[20] = string.Empty;//FirstRno
                                logItem[21] = string.Empty;//PoNo
                                logItem[22] = string.Empty;//ADate
                                logItem[23] = string.Empty;//IDate
                                logItem[24] = string.Empty;//ToAcctNo
                                logItem[25] = this.View.DenoCollection[i].Commissions.ToString();//Income
                                logItem[26] = string.Empty;//Budget
                                logItem[27] = this.View.DenoCollection[i].FromBranchCode;//FromBranch
                                logItem[28] = this.View.DenoCollection[i].BranchCode;//ToBranch
                                logItem[29] = string.Empty;//Inout
                                logItem[30] = string.Empty;//Success
                                logItem[31] = this.View.DenoCollection[i].CommunicationCharges.ToString();//COMMUCHARGE
                                logItem[32] = string.Empty;//IncomeType
                                logItem[33] = string.Empty;//OtherBank
                                logItem[34] = string.Empty;//OtherBankChq
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Local Transfer Fail Transaction", CurrentUserEntity.BranchCode,
                                logItem);
                            }
                        }
                        //ClientLog For Online Transfer
                        else
                        {
                            for (int i = 0; i < this.View.DenoCollection.Count; i++)
                            {
                                string[] logItem = new string[35];
                                this.View.DenoCollection[i].NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DenoCollection[i].SourceBranch);
                                logItem[0] = string.Empty;//GroupNo
                                logItem[1] = VoucherNo;//EntryNo
                                logItem[2] = this.View.DenoCollection[i].AccountNo;//AcctNo
                                if (this.View.DenoCollection[i].AccountSign.Length > 0)
                                {
                                    if (this.View.DenoCollection[i].AccountSign.StartsWith("C"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("S"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("L"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("F"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                                }
                                else
                                {
                                    logItem[3] = this.View.DenoCollection[i].AccountNo;//ACode(from COASetUp)
                                }
                                logItem[4] = this.View.DenoCollection[i].TotalAmount.ToString();//LocalAmount
                                logItem[5] = this.View.DenoCollection[i].Currency;//SourceCur
                                logItem[6] = this.View.DenoCollection[i].ChequeNo;//Cheque
                                logItem[7] = System.DateTime.Now.ToString();//Date_Time
                                logItem[8] = this.View.DenoCollection[i].NextSettlementDate.ToString();//SettlementDate
                                if (this.View.DenoCollection[i].VoucherType.StartsWith("D"))
                                {
                                    string tranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucherCode);
                                    logItem[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tranCode }).Status;//TRDEBIT;//Status
                                }
                                else if (this.View.DenoCollection[i].VoucherType.StartsWith("C"))
                                {
                                    string tranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucherCode);
                                    logItem[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tranCode }).Status;//TRCREDIT;//Status
                                }
                                else
                                    logItem[9] = string.Empty;//Status
                                logItem[10] = this.View.DenoCollection[i].BranchCode;//SourceBr
                                logItem[11] = string.Empty;//Rno
                                logItem[12] = string.Empty;//Duration
                                logItem[13] = string.Empty;//LasintDate
                                logItem[14] = CXCOM00010.Instance.GetExchangeRate(this.View.DenoCollection[i].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//intRate
                                logItem[15] = string.Empty;//Accured
                                logItem[16] = string.Empty;//BudenAcc
                                logItem[17] = string.Empty;//Draccured
                                logItem[18] = string.Empty;//AccuredStatus
                                logItem[19] = string.Empty;//ToAccountNo
                                logItem[20] = string.Empty;//FirstRno
                                logItem[21] = string.Empty;//PoNo
                                logItem[22] = string.Empty;//ADate
                                logItem[23] = string.Empty;//IDate
                                logItem[24] = string.Empty;//ToAcctNo
                                logItem[25] = this.View.DenoCollection[i].Commissions.ToString();//Income
                                logItem[26] = string.Empty;//Budget
                                logItem[27] = this.View.DenoCollection[i].FromBranchCode;//FromBranch
                                logItem[28] = this.View.DenoCollection[i].BranchCode;//ToBranch
                                logItem[29] = string.Empty;//Inout
                                logItem[30] = "1";//Success
                                logItem[31] = this.View.DenoCollection[i].CommunicationCharges.ToString();//COMMUCHARGE
                                logItem[32] = string.Empty;//IncomeType
                                logItem[33] = string.Empty;//OtherBank
                                logItem[34] = string.Empty;//OtherBankChq
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Online Transfer Fail Transaction", CurrentUserEntity.BranchCode,
                                logItem);
                            }
                        }
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return false;
                    }
                    #endregion

                    #region Successful Transcation
                    else
                    {
                        //ClientLog For Local Transfer
                        if (this.View.LocationTransactions)
                        {
                            for (int i = 0; i < this.View.DenoCollection.Count; i++)
                            {
                                string[] logItem = new string[35];
                                this.View.DenoCollection[i].NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DenoCollection[i].SourceBranch);
                                logItem[0] = string.Empty;//GroupNo
                                logItem[1] = VoucherNo;//EntryNo
                                logItem[2] = this.View.DenoCollection[i].AccountNo;//AcctNo
                                if (this.View.DenoCollection[i].AccountSign.Length > 0)
                                {
                                    if (this.View.DenoCollection[i].AccountSign.StartsWith("C"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("S"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("L"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("F"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                                }
                                else
                                {
                                    logItem[3] = this.View.DenoCollection[i].AccountNo;//ACode(from COASetUp)
                                }
                                logItem[4] = this.View.DenoCollection[i].TotalAmount.ToString();//LocalAmount
                                logItem[5] = this.View.DenoCollection[i].Currency;//SourceCur
                                logItem[6] = this.View.DenoCollection[i].ChequeNo;//Cheque
                                logItem[7] = System.DateTime.Now.ToString();//Date_Time
                                logItem[8] = this.View.DenoCollection[i].NextSettlementDate.ToString();//SettlementDate
                                if (this.View.DenoCollection[i].VoucherType.StartsWith("D"))
                                {
                                    string tranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucherCode);
                                    logItem[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tranCode }).Status;//TRDEBIT;//Status
                                }
                                else if (this.View.DenoCollection[i].VoucherType.StartsWith("C"))
                                {
                                    string tranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucherCode);
                                    logItem[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tranCode }).Status;//TRCREDIT;//Status
                                }
                                else
                                    logItem[9] = string.Empty;//Status
                                logItem[10] = this.View.DenoCollection[i].BranchCode;//SourceBr
                                logItem[11] = string.Empty;//Rno
                                logItem[12] = string.Empty;//Duration
                                logItem[13] = string.Empty;//LasintDate
                                logItem[14] = CXCOM00010.Instance.GetExchangeRate(this.View.DenoCollection[i].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//intRate
                                logItem[15] = string.Empty;//Accured
                                logItem[16] = string.Empty;//BudenAcc
                                logItem[17] = string.Empty;//Draccured
                                logItem[18] = string.Empty;//AccuredStatus
                                logItem[19] = string.Empty;//ToAccountNo
                                logItem[20] = string.Empty;//FirstRno
                                logItem[21] = string.Empty;//PoNo
                                logItem[22] = string.Empty;//ADate
                                logItem[23] = string.Empty;//IDate
                                logItem[24] = string.Empty;//ToAcctNo
                                logItem[25] = this.View.DenoCollection[i].Commissions.ToString();//Income
                                logItem[26] = string.Empty;//Budget
                                logItem[27] = this.View.DenoCollection[i].FromBranchCode;//FromBranch
                                logItem[28] = this.View.DenoCollection[i].BranchCode;//ToBranch
                                logItem[29] = string.Empty;//Inout
                                logItem[30] = string.Empty;//Success
                                logItem[31] = this.View.DenoCollection[i].CommunicationCharges.ToString();//COMMUCHARGE
                                logItem[32] = string.Empty;//IncomeType
                                logItem[33] = string.Empty;//OtherBank
                                logItem[34] = string.Empty;//OtherBankChq
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Local Transfer Commit Transaction", CurrentUserEntity.BranchCode,
                                logItem);
                            }
                        }
                        //ClientLog For Online Transfer
                        else
                        {
                            for (int i = 0; i < this.View.DenoCollection.Count; i++)
                            {
                                string[] logItem = new string[35];
                                this.View.DenoCollection[i].NextSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DenoCollection[i].SourceBranch);
                                logItem[0] = string.Empty;//GroupNo
                                logItem[1] = VoucherNo;//EntryNo
                                logItem[2] = this.View.DenoCollection[i].AccountNo;//AcctNo
                                if (this.View.DenoCollection[i].AccountSign.Length > 0)
                                {
                                    if (this.View.DenoCollection[i].AccountSign.StartsWith("C"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("S"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("L"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("F"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                                }
                                else
                                {
                                    logItem[3] = this.View.DenoCollection[i].AccountNo;//ACode(from COASetUp)
                                }
                                logItem[4] = this.View.DenoCollection[i].TotalAmount.ToString();//LocalAmount
                                logItem[5] = this.View.DenoCollection[i].Currency;//SourceCur
                                logItem[6] = this.View.DenoCollection[i].ChequeNo;//Cheque
                                logItem[7] = System.DateTime.Now.ToString();//Date_Time
                                logItem[8] = this.View.DenoCollection[i].NextSettlementDate.ToString();//SettlementDate
                                if (this.View.DenoCollection[i].VoucherType.StartsWith("D"))
                                {
                                    string tranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferDebitVoucherCode);
                                    logItem[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tranCode }).Status;//TRDEBIT;//Status
                                }
                                else if (this.View.DenoCollection[i].VoucherType.StartsWith("C"))
                                {
                                    string tranCode = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferCreditVoucherCode);
                                    logItem[9] = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tranCode }).Status;//TRCREDIT;//Status
                                }
                                else
                                    logItem[9] = string.Empty;//Status
                                logItem[10] = this.View.DenoCollection[i].BranchCode;//SourceBr
                                logItem[11] = string.Empty;//Rno
                                logItem[12] = string.Empty;//Duration
                                logItem[13] = string.Empty;//LasintDate
                                logItem[14] = CXCOM00010.Instance.GetExchangeRate(this.View.DenoCollection[i].Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//intRate
                                logItem[15] = string.Empty;//Accured
                                logItem[16] = string.Empty;//BudenAcc
                                logItem[17] = string.Empty;//Draccured
                                logItem[18] = string.Empty;//AccuredStatus
                                logItem[19] = string.Empty;//ToAccountNo
                                logItem[20] = string.Empty;//FirstRno
                                logItem[21] = string.Empty;//PoNo
                                logItem[22] = string.Empty;//ADate
                                logItem[23] = string.Empty;//IDate
                                logItem[24] = string.Empty;//ToAcctNo
                                logItem[25] = this.View.DenoCollection[i].Commissions.ToString();//Income
                                logItem[26] = string.Empty;//Budget
                                logItem[27] = this.View.DenoCollection[i].FromBranchCode;//FromBranch
                                logItem[28] = this.View.DenoCollection[i].BranchCode;//ToBranch
                                logItem[29] = string.Empty;//Inout
                                logItem[30] = "1";//Success
                                logItem[31] = this.View.DenoCollection[i].CommunicationCharges.ToString();//COMMUCHARGE
                                logItem[32] = string.Empty;//IncomeType
                                logItem[33] = string.Empty;//OtherBank
                                logItem[34] = string.Empty;//OtherBankChq
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Online Transfer Commit Transaction", CurrentUserEntity.BranchCode,
                                logItem);
                            }
                        }
                        this.View.VoucherNo = VoucherNo;
                        //this.View.Successful(CXMessage.MI00051,this.view.DenoCollection.Count > 2 ? "Voucher No" : "Group No",VoucherNo);
                        this.View.Successful(CXMessage.MI00051,  "Voucher No", VoucherNo);

                        //Added by HWKO (05-Dec-2017)
                        if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00016) == DialogResult.Yes)//Do you want to print Transactions?
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00084", true, new object[] { this.view.DenoCollection, VoucherNo });
                        }
                        //Endregion

                        return true;
                    }
                    #endregion
                }
            }
            return false;
        }

        public bool DebitAccountInformationChecking()
        {
            bool isLinkAccount=false;
            if (this.View.TransferEntity.IsCredit)
                return true;
            else
            {
                isLinkAccount=CXClientWrapper.Instance.Invoke<ITLMSVE00003, bool>(x => x.DebitInformationCheckingAndLink(this.View.TransferEntity));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return false;
                }
                else
                {
                    if (isLinkAccount)
                        if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00009) != DialogResult.Yes)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00109); // Insufficient Amount.
                            return false;
                        }
                        else
                        {
                            this.View.IsAutoLink = true;
                            return true;
                        }
                }
            }
            return true;
        }

        public void txtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError || !this.View.TransferEntity.IsCheckCustomAccountValidation)
                    return;
                if (this.View.FormName == "TrOnline") 
                {
                    if ((this.View.Commissions + this.View.CommunicationCharges) == 0 && this.View.InputIncomeAmount == false && this.view.IsDebitTransaction == true)
                    {
                        bool isActive = true;
                        //TLMDTO00029 remitBranchDTO = CXCLE00002.Instance.GetScalarObject<TLMDTO00029>("RemitBranchIBL.Client.Select", new object[] { this.View.Currency,/*this.View.BranchCode commented by YMA*/"002", this.View.LocalBranchCode });
                        TLMDTO00029 remitBranchDTO = CXCLE00002.Instance.GetScalarObject<TLMDTO00029>("RemitBranchIBL.Client.Select", new object[] { this.View.Currency,this.view.BranchCode, this.View.LocalBranchCode });
                                    IList<TLMDTO00030> IBlDrawingRateList = CXCLE00002.Instance.GetClientDataList<TLMDTO00030>("IBLDrawingRate.Client.Select", new object[] { this.View.Currency, this.View.BranchCode, this.View.LocalBranchCode, isActive });

                        foreach (TLMDTO00030 info in IBlDrawingRateList)
                        {
                            if (info.StartNo <= this.View.Amount && info.EndNo >= this.View.Amount)
                                this.View.Commissions = info.FixAmount.Value;
                            else if (info.StartNo <= this.View.Amount && info.StartNo == 0)
                                this.View.Commissions = (this.View.Amount / 100) * info.Rate.Value;
                        }

                        this.View.CommunicationCharges = remitBranchDTO.TelaxCharges;
                        this.View.TransferEntity.CommissionAccount = remitBranchDTO.IBSComAccount;
                        this.View.TransferEntity.CommunicationAccount = remitBranchDTO.TelaxAccount;
                    }
                    else
                    {
                        this.View.Commissions = this.view.Commissions;
                        this.View.CommunicationCharges = this.view.CommunicationCharges;
                    }

                }

                else
                {
                    this.View.Commissions = this.view.Commissions;
                    this.View.CommunicationCharges = this.view.CommunicationCharges;
                }
                
              }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), ex.Message);
            }
        }

        public void gvTransferInformation_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.DenoCollection.Count < 1 && this.View.TransferEntity.IsCheckGridview)
            {
                // Do Data to transfer.
                this.SetCustomErrorMessage(this.GetControl("gvTransferInformation"), CXMessage.MV00046);
            }
        }

        public void Call_RemittanceCalculator()
        {
            CXUIScreenTransit.Transit("frmTLMVEW00008", true, new object[] { "frmTLMVEW00003", this.View.Amount});
        }

        public void Call_Enquiry()
        {
            CXUIScreenTransit.Transit("frmTLMVEW00042", true, new object[] { "frmTLMVEW00003", this.View.AccountNo });
        }

        public void Printing()
        {
            try
            {
                IList<PFMDTO00043> PintFileList = new List<PFMDTO00043>();
                List<string[]> printingList;

                var list = from x in this.view.DenoCollection where x.IsPrintTransaction == true select x.AccountNo;

                if (list.Count<string>() == 0)
                    return;

                PintFileList = CXCLE00006.Instance.SelectAllPrintingDataForCSAccounts(list.ToArray<string>());

                foreach (TLMDTO00038 info in this.View.DenoCollection)
                {
                    var query = from z in PintFileList where z.AccountNo == info.AccountNo orderby z.CreatedDate select z;
                    printingList = new List<string[]>();

                    for (int i = 0; i < query.Count<PFMDTO00043>(); i++)
                    {
                        PFMDTO00043 prnFile = query.ElementAt(i);

                        string[] prnFileStrArr = { prnFile.DATE_TIME.Value.ToString("yyyy/mm/dd"), prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

                        printingList.Add(prnFileStrArr);
                    }
                    if (query.Count<PFMDTO00043>() > 0)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { info.AccountNo });

                        CXCLE00005.Instance.StartLineNo = (int)query.ToList<PFMDTO00043>()[0].PrintLineNo == 0 ? 1 : (int)query.ToList<PFMDTO00043>()[0].PrintLineNo;
                        printedLine = CXCLE00005.Instance.StartLineNo;
                        CXUIScreenTransit.Transit("frmPFMVEW00009", true, new object[] { true, printedLine });

                        CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true, out printedLine);


                        if (!CXCLE00006.Instance.UpdateAfterPrintingForCS(info.AccountNo, printedLine, CurrentUserEntity.CurrentUserID))
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
                    }

                }
            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
            }
        }

        public bool ChecKLocalDrCr() //add by ksw
        {
            string sourceBr = CurrentUserEntity.BranchCode;
            if (this.View.AccountNo.Length == 15)
            {
                if (this.View.TransferEntity.AccountNo.Substring(0, 3) != sourceBr)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30039);
                    return false;
                }
            }
            return true;
        }
        public bool ChecKOnlineDrCr() //add by ksw
        {
            if (this.View.AccountNo.Length == 6)
            {
                
                   Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30040);
                   this.View.IsDomesticAccount = false;
                    return false;
            }
            return true;
        }

        //Added by HMW at 14-08-2019 : [Seperating EOD Process] To show system date (not PC date) at UI
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }
     
        #endregion

        #region private Methods

        private IList<TLMDTO00038> GetDenoData(CXDTO00001 denoRefundRateEntity, IList<TLMDTO00038> transferCollection)
        {
            foreach (TLMDTO00038 transferEntity in transferCollection)
            {
                transferEntity.DenoRate = denoRefundRateEntity.DenoRateString;
                transferEntity.DenoString = denoRefundRateEntity.DenoString;
                transferEntity.RefundRate = denoRefundRateEntity.RefundRateString;
                transferEntity.RefundString = denoRefundRateEntity.RefundString;
                transferEntity.AdjustAmount = denoRefundRateEntity.AdjustAmount;
                transferEntity.TotalAmount = denoRefundRateEntity.TotalAmount;
                transferEntity.CounterNo = CurrentUserEntity.CounterList[0].CounterNo;
            }
            return transferCollection;
        }

        private IList<TLMDTO00038> GetDepositInfoToSave(IList<TLMDTO00038> transferCollection)
        {
            foreach (TLMDTO00038 transferEntity in transferCollection)
            {
                transferEntity.UpdatedUserId = transferEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                transferEntity.FromBranchCode = this.View.LocalBranchCode;
                transferEntity.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                transferEntity.Commissions = this.View.Commissions;
                transferEntity.CommunicationCharges = this.View.CommunicationCharges;
            }
            return transferCollection;
        }

        public bool CheckAmount(IList<TLMDTO00038> transferCollection)
        {
            d1 = 0;
            d2 = 0;

            foreach (TLMDTO00038 transfer in transferCollection)
            {
                if (transfer.IsCredit)
                    d1 += transfer.Amount;
                else
                    d2 += transfer.Amount;
            }

            return d1 == d2 ? true : false;
        }

        private bool CheckDebitCharges()
        {
            if (this.View.IsIncomeByCash)
                return this.View.Commissions + this.View.CommunicationCharges > 0;
            else
                return false;
        }
        //Added by AAM (31_July_2018)
        public IList<PFMDTO00001> SelectByAccountNumber_ForNotAllowDrTrans(string acctNo,DateTime todayDate)
        {
            return CXClientWrapper.Instance.Invoke<ITLMSVE00003, IList<PFMDTO00001>>(x => x.SelectByAccountNumber(acctNo,DateTime.Now));
        }
        #endregion

    }
}
