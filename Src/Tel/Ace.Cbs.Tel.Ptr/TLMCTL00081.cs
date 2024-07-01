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
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00081 : AbstractPresenter, ITLMCTL00081
    {
        #region Properties

        private ITLMVEW00081 view;
        public ITLMVEW00081 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00081 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.View.TransferEntity);
            }
        }

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

        decimal d1, d2;

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
                this.View.SetCursor("Currency");
                this.View.BranchCode = string.Empty;
                this.View.IsDebitTransaction = true;
                this.View.TransactionForControls(true, true, false);
            }
            this.view.AccountNo = string.Empty;
            this.view.Description = string.Empty;
            this.view.Narration = string.Empty;
            this.view.Amount = 0;
            this.View.Status = "Add";
            this.ClearErrors();
        }

        public void Call_Enquiry()
        {
            CXUIScreenTransit.Transit("frmTLMVEW00042", true, new object[] { "frmTLMVEW00003", this.View.AccountNo });
        }

        public bool ChecKLocalDrCr() 
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

        public bool ChecKOnlineDrCr() 
        {
            if (this.View.AccountNo.Length == 6)
            {

                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30040);
                this.View.IsDomesticAccount = false;
                return false;
            }
            return true;
        }

        public bool ValidateAdd()
        {
            return this.ValidateForm(this.View.TransferEntity);
        }

        public ChargeOfAccountDTO GetCOAByAcode(string acode, string sourcebr)
        {
            return CXClientWrapper.Instance.Invoke<ITLMSVE00003, ChargeOfAccountDTO>(x => x.GetCOAByAcode(acode,sourcebr));
        }

        public bool DebitAccountInformationChecking()
        {
            bool isLinkAccount = false;
            if (this.View.TransferEntity.IsCredit)
                return true;
            else
            {
                isLinkAccount = CXClientWrapper.Instance.Invoke<ITLMSVE00003, bool>(x => x.DebitInformationCheckingAndLink(this.View.TransferEntity));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return false;
                }
                else
                {
                    if (isLinkAccount)
                    {
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
            }
            return true;
        }

        //Added by HWKO (14-Sep-2017) //For HP Int Prepayment Voucher Entry
        public bool CheckInterestAmountByAcctNo()
        {
            bool result;
            if (this.View.TransferEntity.IsDebit)
            {
                return false;
            }
            else // Credit Transaction
            {
                result = CXClientWrapper.Instance.Invoke<ITLMSVE00003, bool>(x => x.CheckInterestAmountByAcctNo(this.View.TransferEntity));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    return false;
                }
                else 
                {
                    if (!result)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90184); // Credit amount must equal to interest amount of related account.
                        return false;
                    }
                }
            }
            return true;
        }

        public void gvTransferInformation_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (this.view.DenoCollection.Count < 1 && this.View.TransferEntity.IsCheckGridview)
            {
                // Do Data to transfer.
                this.SetCustomErrorMessage(this.GetControl("gvTransferInformation"), CXMessage.MV00046);
            }
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError || !this.View.TransferEntity.IsCheckCustomAccountValidation)
                    return;
                
                CustomerInformation.Clear();
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    CustomerInformation = CXClientWrapper.Instance.Invoke<ITLMSVE00003, IList<PFMDTO00001>>(x => x.SelectByAccountNumber(this.View.AccountNo, DateTime.Now));
                    //this.View.AllowedPrinting = true;

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
                    //this.View.AllowedPrinting = false;
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
                    this.View.Description = CustomerInformation[0].Name;
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

                        TLMDTO00038 debitTransactionInfo = debit.ToList<TLMDTO00038>()[0];
                        TLMDTO00038 creditTransactionInfo = credit.ToList<TLMDTO00038>()[0];

                        if (!this.View.IsDomesticAccount)
                        {
                            this.View.LocationTransactions = debitTransactionInfo.BranchCode == this.View.BranchCode && creditTransactionInfo.BranchCode == this.View.BranchCode ? true : false;
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
                    this.View.TransactionForControls(this.View.IsDebitTransaction ? true : false, this.View.LocationTransactions, false);
                }
                else
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }

        public void cboCurrency_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError || string.IsNullOrEmpty(this.View.Currency))
                return;
            else
                this.View.DisableControlsforView("Curreny.Disable");
        }

        public void txtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError || !this.View.TransferEntity.IsCheckCustomAccountValidation)
                    return;
                if (this.View.FormName == "TrOnline")
                {
                    if (this.view.IsDebitTransaction == true)
                    {
                        //bool isActive = true;
                        ////TLMDTO00029 remitBranchDTO = CXCLE00002.Instance.GetScalarObject<TLMDTO00029>("RemitBranchIBL.Client.Select", new object[] { this.View.Currency,/*this.View.BranchCode commented by YMA*/"002", this.View.LocalBranchCode });
                        //TLMDTO00029 remitBranchDTO = CXCLE00002.Instance.GetScalarObject<TLMDTO00029>("RemitBranchIBL.Client.Select", new object[] { this.View.Currency, this.view.BranchCode, this.View.LocalBranchCode });
                        //IList<TLMDTO00030> IBlDrawingRateList = CXCLE00002.Instance.GetClientDataList<TLMDTO00030>("IBLDrawingRate.Client.Select", new object[] { this.View.Currency, this.View.BranchCode, this.View.LocalBranchCode, isActive });

                        //foreach (TLMDTO00030 info in IBlDrawingRateList)
                        //{
                        //    if (info.StartNo <= this.View.Amount && info.EndNo >= this.View.Amount)
                        //        this.View.Commissions = info.FixAmount.Value;
                        //    else if (info.StartNo <= this.View.Amount && info.StartNo == 0)
                        //        this.View.Commissions = (this.View.Amount / 100) * info.Rate.Value;
                        //}

                        //this.View.CommunicationCharges = remitBranchDTO.TelaxCharges;
                        //this.View.TransferEntity.CommissionAccount = remitBranchDTO.IBSComAccount;
                        //this.View.TransferEntity.CommunicationAccount = remitBranchDTO.TelaxAccount;
                    }
                }

            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), ex.Message);
            }
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

        private IList<TLMDTO00038> GetDepositInfoToSave(IList<TLMDTO00038> transferCollection)
        {
            foreach (TLMDTO00038 transferEntity in transferCollection)
            {
                transferEntity.UpdatedUserId = transferEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
                transferEntity.FromBranchCode = this.View.LocalBranchCode;
                transferEntity.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                //transferEntity.Commissions = this.View.Commissions;
                //transferEntity.CommunicationCharges = this.View.CommunicationCharges;
            }
            return transferCollection;
        }

        public bool Save()        
        {
            if (this.View.Status != "Add")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00170); //It cannot save now.\n First edit.
                return false;
            }
            else if (this.View.DenoCollection.Count != 0 || this.ValidateForm(this.View.TransferEntity))
            {
                if (CXUIScreenTransit.Transit("frmCXCLE00016", true, new object[] { "frmTLMVEW00081", CXDMD00006.Other, PermissionEntity, false }) == DialogResult.OK)
                {
                    string VoucherNo = string.Empty;
                    this.PermissionEntity = CXUIScreenTransit.GetData<CXDMD00010>("frmTLMVEW00081");

                    this.View.DenoCollection = this.GetDepositInfoToSave(this.View.DenoCollection);

                    if (this.View.TransferEntity.HomeExchangeRate == 0)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00013);
                        this.View.TransferEntity.HomeExchangeRate = 1;
                        return false;
                    }

                    
                    VoucherNo = CXClientWrapper.Instance.Invoke<ITLMSVE00003, string>(x => x.SaveHPIntPrepaymentVoucher(this.View.DenoCollection));                   

                    #region ErrorOccurred
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
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
                                    //Added by HWKO (14-Sep-2017)
                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("B"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("P"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("H"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HPControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("D"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                                    //End Region
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
                                    
                                        //Added by HWKO (14-Sep-2017)
                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("B"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("P"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("H"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HPControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("D"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                                    //End Region
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

                                    //Added by HWKO (14-Sep-2017)
                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("B"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("P"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("H"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HPControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("D"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                                    //End Region
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

                                    //Added by HWKO (14-Sep-2017)
                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("B"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("P"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("H"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HPControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("D"))
                                        logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DLControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                                    //End Region
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
                        this.View.Successful(CXMessage.MI00051, "Voucher No", VoucherNo);
                        return true;
                    }
                    #endregion
                }
            }
            return false;
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
    }
}
