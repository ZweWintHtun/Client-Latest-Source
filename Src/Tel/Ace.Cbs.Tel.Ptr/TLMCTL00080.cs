using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tel.Ctr.Sve;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00080 : AbstractPresenter, ITLMCTL00080
    {
        #region Prorerties

        private ITLMVEW00080 view;
        public IList<PFMDTO00001> AccountInformationList { get; set; }
        int printedLine = 0;

        public ITLMVEW00080 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00080 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.View.DepositEntity);
            }
        }

        #endregion

        #region UI Logic Method

        public void ClearControls(bool isGird)
        {
            if (isGird)
            {
                this.View.EnableControlsforView("Curreny.Enable");
                //this.view.Currency = string.Empty;
                this.View.DenoCollection.Clear();
                this.View.BindData();
                this.view.TotalAmount = 0;
                View.SetCursor("Currency");
                this.View.BranchCode = string.Empty;
                this.View.DisableControlsforView("Deposit.Disable");
                this.View.VoucherLabel = "VoucherNo :";
                this.View.VoucherNo = string.Empty;
            }
            this.view.AccountNo = string.Empty;
            this.view.Name = string.Empty;
            this.view.NRC = string.Empty;
            this.view.Amount = 0;
            this.view.Commissions = 0;
            this.view.CommunicationCharges = 0;
            this.view.Narration = string.Empty;
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
                if (e.HasXmlBaseError)
                    return;
                // Checking Account in Grid.
                var data = from x in this.View.DenoCollection where x.AccountNo == this.View.AccountNo select x;
                int i = data.ToList<TLMDTO00038>() == null ? 0 : data.ToList<TLMDTO00038>().Count;

                if (this.View.DenoCollection.Count > 0 && i > 0 && this.View.Status == "Add")
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV90001); // Data Already Exits.
                    return;
                }
                // AccountNo Checking (Code Format and CheckDigit,etc.)
                Nullable<CXDMD00011> accountType;

                if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
                {
                    AccountInformationList = CXClientWrapper.Instance.Invoke<ITLMSVE00080, IList<PFMDTO00001>>(x => x.SelectByAccountNumber(this.View.AccountNo));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }
                    else if (AccountInformationList != null)
                    {
                        //this.View.Name = AccountInformationList[0].Name;  //Comment by HMW at 06-May-2019

                        //Modified by HMW at 06-May-2019 for "Company Account"
                        if (AccountInformationList[0].AccountSign.EndsWith("C") == true)
                        {
                            this.view.Name = AccountInformationList[0].Name;
                        }
                        //Modified by HMW at 06-May-2019 for "Joint Account" and "Individual Account"
                        else
                        {
                            this.view.Name = "";
                            for (int j = 0; j < AccountInformationList.Count; j++)
                            {
                                if (AccountInformationList.Count == j + 1)
                                {
                                    this.view.Name += AccountInformationList[j].Name;                                    
                                }
                                else
                                {
                                    this.view.Name += AccountInformationList[j].Name + ", ";                                    
                                }
                            }
                        }

                        //Comment & Modified by HMW at 29-July-2019 : to show all "NRC"
                        //this.View.NRC = AccountInformationList[0].NRC;
                        this.view.NRC = "";
                        for (int k = 0; k < AccountInformationList.Count; k++)
                        {
                            if (!string.IsNullOrEmpty(AccountInformationList[k].NRC))
                            {
                                if (AccountInformationList.Count == k + 1)
                                {
                                    this.view.NRC += AccountInformationList[k].NRC;
                                }
                                else
                                {
                                    this.view.NRC += AccountInformationList[k].NRC + ", ";
                                }
                            }
                        }
                        
                        this.View.CurrentBalance = AccountInformationList[0].CurrentBal;
                        this.View.AccountSign = AccountInformationList[0].AccountSign;
                        //if (this.view.AccountSign.Substring(0, 1) == "C")
                        //{
                        //    this.view.Disable();
                        //}
                        //else
                        //    this.view.GetEnablePrintStaus(true);
                        if (AccountInformationList[0].CurrencyCode != this.View.Currency)
                        {
                            // Invalid Currency
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00086, new object[] { this.View.Currency });
                            return;
                        }
                        else if (this.View.DenoCollection.Count == 0)
                        {
                            this.View.LocationTransactions = this.View.LocalBranchCode.Equals(AccountInformationList[0].SourceBranch) ? true : false;
                            if (!this.View.LocationTransactions) this.View.EnableControlsforView("Deposit.EnableOnlineTransactions");
                        }
                        else
                        {
                            if (this.View.LocationTransactions)
                            {
                                if (this.View.LocalBranchCode != AccountInformationList[0].SourceBranch)
                                {
                                    // Invalid Branch Code
                                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00165, new object[] { "Local Branch " });
                                    return;
                                }
                            }
                            else
                            {
                                if (this.View.LocalBranchCode == AccountInformationList[0].SourceBranch)
                                {
                                    // Invalid Branch Code
                                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00165, new object[] { "Other Branch " });
                                    return;
                                }
                            }
                        }
                        this.View.BranchCode = AccountInformationList[0].SourceBranch;
                    }
                }
                else
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }

        public void txtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError || !this.View.DepositEntity.IsCheckCustomAccountValidation)
                    return;
                //else if (!this.View.LocationTransactions)
                //{
                //    bool isActive = true;
                //    TLMDTO00029 remitBranchDTO = CXCLE00002.Instance.GetScalarObject<TLMDTO00029>("RemitBranchIBL.Client.Select", new object[] { this.View.Currency, this.View.BranchCode, this.View.LocalBranchCode });
                //    IList<TLMDTO00030> IBlDrawingRateList = CXCLE00002.Instance.GetClientDataList<TLMDTO00030>("IBLDrawingRate.Client.Select", new object[] { this.View.Currency, this.View.BranchCode, this.View.LocalBranchCode, isActive });

                //    foreach (TLMDTO00030 info in IBlDrawingRateList)
                //    {
                //        if (info.StartNo <= this.View.Amount && info.EndNo >= this.View.Amount)
                //            this.View.Commissions = info.FixAmount.Value;
                //        else if (info.StartNo <= this.View.Amount && info.StartNo == 0)
                //            this.View.Commissions = (this.View.Amount / 800) * info.Rate.Value;
                //    }

                //    this.View.CommunicationCharges = remitBranchDTO.TelaxCharges;
                //    this.View.DepositEntity.CommissionAccount = remitBranchDTO.IBSComAccount;
                //    this.View.DepositEntity.CommunicationAccount = remitBranchDTO.TelaxAccount;
                //}
                //else
                //{
                //    CXCLE00006.Instance.UpdateAfterPrintingForCS(info.AccountNo, prnLineNo, CurrentUserEntity.CurrentUserID);
                //}
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), ex.Message);
            }
        }       
        public bool ValidateAdd()
        {
            return this.ValidateForm(this.View.DepositEntity);
        }

        public bool Save()
        {
            if (this.View.Status != "Add")
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00170);
                return false;
            }
            else if (this.View.DenoCollection.Count == 0)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00107);
                return false;
            }
            else
            {
                if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { this.View.TotalAmount, this.View.Currency, CXDMD00008.Received, "frmTLMVEW00011" }) == DialogResult.OK)
                {
                    this.View.DenoInfo = CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00011");

                    this.View.DepositEntity = this.GetDepositInfoToSave(this.View.DepositEntity);

                    string VoucherNo = string.Empty;
                    //if (this.View.DepositEntity.HomeExchangeRate == 0)
                    //{
                    //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00013);
                    //    this.View.DepositEntity.HomeExchangeRate = 1;
                    //    return false;
                    //}

                    IList<PFMDTO00054> Tlf_List = new List<PFMDTO00054>();
                    if (this.View.LocationTransactions)
                        Tlf_List = CXClientWrapper.Instance.Invoke<ITLMSVE00080, IList<PFMDTO00054>>(x => x.SaveDepositLocal(this.View.DenoCollection, this.View.DepositEntity));
                    //else
                    //    Tlf_List = CXClientWrapper.Instance.Invoke<ITLMSVE00080, IList<PFMDTO00054>>(x => x.SaveDepositOnline(this.View.DenoCollection, this.View.DepositEntity, CurrentUserEntity.BranchCode));


                    #region ErrorOccurred
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        //For LocalTransactions
                        if (this.View.LocationTransactions)
                        {
                            string[] logItemForDeno = new string[14];
                            string[] logItemForTlf = new string[35];
                            //ClientLog For Deno
                            if (this.View.DenoCollection.Count > 1)
                            {
                                logItemForDeno[0] = Tlf_List[0].Description;//Tlf_Eno
                                logItemForDeno[1] = string.Empty;//AcType
                            }
                            else
                            {
                                logItemForDeno[0] = Tlf_List[0].Eno;//Tlf_Eno
                                logItemForDeno[1] = this.View.DenoCollection[0].AccountNo;//AcType
                            }
                            logItemForDeno[2] = string.Empty;//FromType
                            logItemForDeno[3] = this.View.DepositEntity.TotalAmount.ToString();//Amount
                            logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                            logItemForDeno[5] = this.View.DepositEntity.DenoString;//Deno_Detail
                            logItemForDeno[6] = this.View.DepositEntity.RefundString;//DenoRefund_Detail
                            logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = this.View.DepositEntity.FromBranchCode;//sourcebr
                            logItemForDeno[80] = this.View.DepositEntity.Currency;//cur
                            logItemForDeno[11] = this.View.DepositEntity.DenoRate;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DepositEntity.FromBranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.DepositEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Local Deposit Fail Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);

                            //ClientLog For Tlf
                            for (int i = 0; i < this.View.DenoCollection.Count; i++)
                            {
                                if (this.View.DenoCollection.Count > 1)
                                    logItemForTlf[0] = Tlf_List[0].Description;//GroupNo
                                else
                                    logItemForTlf[0] = string.Empty;//GroupNo
                                logItemForTlf[1] = Tlf_List[i].Eno;//EntryNo
                                logItemForTlf[2] = this.View.DenoCollection[i].AccountNo;//AcctNo
                                if (this.View.DenoCollection[i].AccountSign.Length > 0)
                                {
                                    if (this.View.DenoCollection[i].AccountSign.StartsWith("C"))
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("S"))
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("L"))
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("F"))
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                                }
                                else
                                {
                                    logItemForTlf[3] = this.View.DenoCollection[i].AccountNo;//ACode(from COASetUp)
                                }
                                logItemForTlf[4] = this.View.DenoCollection[i].Amount.ToString();//LocalAmount
                                logItemForTlf[5] = this.View.DenoCollection[i].Currency;//SourceCur
                                logItemForTlf[6] = this.View.DenoCollection[i].ChequeNo;//Cheque
                                logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DepositEntity.FromBranchCode).ToString();//SettlementDate
                                logItemForTlf[9] = Tlf_List[i].SourceCurrency;//Status
                                logItemForTlf[80] = this.View.DenoCollection[i].BranchCode;//SourceBr
                                logItemForTlf[11] = string.Empty;//Rno
                                logItemForTlf[12] = string.Empty;//Duration
                                logItemForTlf[13] = string.Empty;//LasintDate
                                logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                                logItemForTlf[25] = this.View.DenoCollection[i].Commissions.ToString();//Income
                                logItemForTlf[26] = string.Empty;//Budget
                                logItemForTlf[27] = this.View.DepositEntity.FromBranchCode;//FromBranch
                                logItemForTlf[28] = this.View.DenoCollection[i].BranchCode;//ToBranch
                                logItemForTlf[29] = string.Empty;//Inout
                                logItemForTlf[30] = string.Empty;//Success
                                logItemForTlf[31] = this.View.DenoCollection[i].CommunicationCharges.ToString();//COMMUCHARGE
                                logItemForTlf[32] = string.Empty;//IncomeType
                                logItemForTlf[33] = string.Empty;//OtherBank
                                logItemForTlf[34] = string.Empty;//OtherBankChq
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Local Deposit Fail Transaction", CurrentUserEntity.BranchCode,
                                logItemForTlf);
                            }
                        }

                        #region //For OnlineTransactions
                        //else
                        //{
                        //    string[] logItemForDeno = new string[14];
                        //    string[] logItemForTlf = new string[35];
                        //    //ClientLog For Deno
                        //    if (this.View.DenoCollection.Count > 1)
                        //    {
                        //        logItemForDeno[0] = Tlf_List[0].Description;//Tlf_Eno
                        //        logItemForDeno[1] = string.Empty;//AcType
                        //    }
                        //    else
                        //    {
                        //        logItemForDeno[0] = Tlf_List[0].Eno;//Tlf_Eno
                        //        logItemForDeno[1] = this.View.DenoCollection[0].AccountNo;//AcType
                        //    }
                        //    logItemForDeno[2] = string.Empty;//FromType
                        //    logItemForDeno[3] = this.View.DepositEntity.TotalAmount.ToString();//Amount
                        //    logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        //    logItemForDeno[5] = this.View.DepositEntity.DenoString;//Deno_Detail
                        //    logItemForDeno[6] = this.View.DepositEntity.RefundString;//DenoRefund_Detail
                        //    logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        //    logItemForDeno[8] = "0";//REVERSE
                        //    logItemForDeno[9] = this.View.DepositEntity.FromBranchCode;//sourcebr
                        //    logItemForDeno[80] = this.View.DepositEntity.Currency;//cur
                        //    logItemForDeno[11] = this.View.DepositEntity.DenoRate;//DenoRate
                        //    logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DepositEntity.FromBranchCode).ToString();//SettlementDate
                        //    logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.DepositEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//Rate
                        //    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Online Deposit Fail Deno", CurrentUserEntity.BranchCode,
                        //    logItemForDeno);

                        //    //ClientLog For Tlf
                        //    for (int i = 0; i < this.View.DenoCollection.Count; i++)
                        //    {
                        //        if (this.View.DenoCollection.Count > 1)
                        //            logItemForTlf[0] = Tlf_List[0].Description;//GroupNo
                        //        else
                        //            logItemForTlf[0] = string.Empty;//GroupNo
                        //        logItemForTlf[1] = Tlf_List[i].Eno;//EntryNo
                        //        logItemForTlf[2] = this.View.DenoCollection[i].AccountNo;//AcctNo
                        //        if (this.View.DenoCollection[i].AccountSign.Length > 0)
                        //        {
                        //            if (this.View.DenoCollection[i].AccountSign.StartsWith("C"))
                        //                logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                        //            else if (this.View.DenoCollection[i].AccountSign.StartsWith("S"))
                        //                logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                        //            else if (this.View.DenoCollection[i].AccountSign.StartsWith("L"))
                        //                logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                        //            else if (this.View.DenoCollection[i].AccountSign.StartsWith("F"))
                        //                logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                        //        }
                        //        else
                        //        {
                        //            logItemForTlf[3] = this.View.DenoCollection[i].AccountNo;//ACode(from COASetUp)
                        //        }
                        //        logItemForTlf[4] = this.View.DenoCollection[i].Amount.ToString();//LocalAmount
                        //        logItemForTlf[5] = this.View.DenoCollection[i].Currency;//SourceCur
                        //        logItemForTlf[6] = this.View.DenoCollection[i].ChequeNo;//Cheque
                        //        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        //        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DepositEntity.FromBranchCode).ToString();//SettlementDate
                        //        logItemForTlf[9] = Tlf_List[i].SourceCurrency;//Status
                        //        logItemForTlf[80] = this.View.DenoCollection[i].BranchCode;//SourceBr
                        //        logItemForTlf[11] = string.Empty;//Rno
                        //        logItemForTlf[12] = string.Empty;//Duration
                        //        logItemForTlf[13] = string.Empty;//LasintDate
                        //        logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
                        //        logItemForTlf[15] = string.Empty;//Accured
                        //        logItemForTlf[16] = string.Empty;//BudenAcc
                        //        logItemForTlf[17] = string.Empty;//Draccured
                        //        logItemForTlf[18] = string.Empty;//AccuredStatus
                        //        logItemForTlf[19] = string.Empty;//ToAccountNo
                        //        logItemForTlf[20] = string.Empty;//FirstRno
                        //        logItemForTlf[21] = string.Empty;//PoNo
                        //        logItemForTlf[22] = string.Empty;//ADate
                        //        logItemForTlf[23] = string.Empty;//IDate
                        //        logItemForTlf[24] = string.Empty;//ToAcctNo
                        //        logItemForTlf[25] = this.View.DenoCollection[i].Commissions.ToString();//Income
                        //        logItemForTlf[26] = string.Empty;//Budget
                        //        logItemForTlf[27] = this.View.DepositEntity.FromBranchCode;//FromBranch
                        //        logItemForTlf[28] = this.View.DenoCollection[i].BranchCode;//ToBranch
                        //        logItemForTlf[29] = "0";//Inout
                        //        logItemForTlf[30] = "1";//Success
                        //        logItemForTlf[31] = this.View.DenoCollection[i].CommunicationCharges.ToString();//COMMUCHARGE
                        //        logItemForTlf[32] = "1";//IncomeType
                        //        logItemForTlf[33] = string.Empty;//OtherBank
                        //        logItemForTlf[34] = string.Empty;//OtherBankChq
                        //        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Online Deposit Fail Transaction", CurrentUserEntity.BranchCode,
                        //        logItemForTlf);
                        //    }
                        //}
                        #endregion

                        if (!CXClientWrapper.Instance.ServiceResult.MessageCode.Contains(","))
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                        else
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode.Split(',')[0], CXClientWrapper.Instance.ServiceResult.MessageCode.Split(',')[1]);
                        return false;
                    }
                    #endregion

                    #region Successful Transcation
                    else
                    {
                        //For LocalTransactions
                        if (this.View.LocationTransactions)
                        {
                            string[] logItemForDeno = new string[14];
                            string[] logItemForTlf = new string[35];
                            //ClientLog For Deno
                            if (this.View.DenoCollection.Count > 1)
                            {
                                logItemForDeno[0] = Tlf_List[0].Description;//Tlf_Eno
                                logItemForDeno[1] = string.Empty;//AcType
                            }
                            else
                            {
                                logItemForDeno[0] = Tlf_List[0].Eno;//Tlf_Eno
                                logItemForDeno[1] = this.View.DenoCollection[0].AccountNo;//AcType
                            }
                            logItemForDeno[2] = string.Empty;//FromType
                            logItemForDeno[3] = this.View.DepositEntity.TotalAmount.ToString();//Amount
                            logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                            logItemForDeno[5] = this.View.DepositEntity.DenoString;//Deno_Detail
                            logItemForDeno[6] = this.View.DepositEntity.RefundString;//DenoRefund_Detail
                            logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = this.View.DepositEntity.FromBranchCode;//sourcebr
                            logItemForDeno[10] = this.View.DepositEntity.Currency;//cur
                            logItemForDeno[11] = this.View.DepositEntity.DenoRate;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DepositEntity.FromBranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.DepositEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Local Deposit Commit Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);

                            //ClientLog For Tlf
                            for (int i = 0; i < this.View.DenoCollection.Count; i++)
                            {
                                if (this.View.DenoCollection.Count > 1)
                                    logItemForTlf[0] = Tlf_List[0].Description;//GroupNo
                                else
                                    logItemForTlf[0] = string.Empty;//GroupNo
                                logItemForTlf[1] = Tlf_List[i].Eno;//EntryNo
                                logItemForTlf[2] = this.View.DenoCollection[i].AccountNo;//AcctNo
                                if (this.View.DenoCollection[i].AccountSign.Length > 0)
                                {
                                    if (this.View.DenoCollection[i].AccountSign.StartsWith("C"))
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("S"))
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("L"))
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                                    else if (this.View.DenoCollection[i].AccountSign.StartsWith("F"))
                                        logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                                }
                                else
                                {
                                    logItemForTlf[3] = this.View.DenoCollection[i].AccountNo;//ACode(from COASetUp)
                                }
                                logItemForTlf[4] = this.View.DenoCollection[i].Amount.ToString();//LocalAmount
                                logItemForTlf[5] = this.View.DenoCollection[i].Currency;//SourceCur
                                logItemForTlf[6] = this.View.DenoCollection[i].ChequeNo;//Cheque
                                logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                                logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DepositEntity.FromBranchCode).ToString();//SettlementDate
                                logItemForTlf[9] = Tlf_List[i].SourceCurrency;//Status
                                logItemForTlf[8] = this.View.DenoCollection[i].BranchCode;//SourceBr
                                logItemForTlf[11] = string.Empty;//Rno
                                logItemForTlf[12] = string.Empty;//Duration
                                logItemForTlf[13] = string.Empty;//LasintDate
                                logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                                logItemForTlf[25] = this.View.DenoCollection[i].Commissions.ToString();//Income
                                logItemForTlf[26] = string.Empty;//Budget
                                logItemForTlf[27] = this.View.DepositEntity.FromBranchCode;//FromBranch
                                logItemForTlf[28] = this.View.DenoCollection[i].BranchCode;//ToBranch
                                logItemForTlf[29] = string.Empty;//Inout
                                logItemForTlf[30] = string.Empty;//Success
                                logItemForTlf[31] = this.View.DenoCollection[i].CommunicationCharges.ToString();//COMMUCHARGE
                                logItemForTlf[32] = string.Empty;//IncomeType
                                logItemForTlf[33] = string.Empty;//OtherBank
                                logItemForTlf[34] = string.Empty;//OtherBankChq
                                TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Local Deposit Commit Transaction", CurrentUserEntity.BranchCode,
                                logItemForTlf);
                            } 
                        }

                        #region //For OnlineTransactions
                        //else
                        //{
                        //    string[] logItemForDeno = new string[14];
                        //    string[] logItemForTlf = new string[35];
                        //    //ClientLog For Deno
                        //    if (this.View.DenoCollection.Count > 1)
                        //    {
                        //        logItemForDeno[0] = Tlf_List[0].Description;//Tlf_Eno
                        //        logItemForDeno[1] = string.Empty;//AcType
                        //    }
                        //    else
                        //    {
                        //        logItemForDeno[0] = Tlf_List[0].Eno;//Tlf_Eno
                        //        logItemForDeno[1] = this.View.DenoCollection[0].AccountNo;//AcType
                        //    }
                        //    logItemForDeno[2] = string.Empty;//FromType
                        //    logItemForDeno[3] = this.View.DepositEntity.TotalAmount.ToString();//Amount
                        //    logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                        //    logItemForDeno[5] = this.View.DepositEntity.DenoString;//Deno_Detail
                        //    logItemForDeno[6] = this.View.DepositEntity.RefundString;//DenoRefund_Detail
                        //    logItemForDeno[7] = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCashStatus);//Status
                        //    logItemForDeno[8] = "0";//REVERSE
                        //    logItemForDeno[9] = this.View.DepositEntity.FromBranchCode;//sourcebr
                        //    logItemForDeno[80] = this.View.DepositEntity.Currency;//cur
                        //    logItemForDeno[11] = this.View.DepositEntity.DenoRate;//DenoRate
                        //    logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DepositEntity.FromBranchCode).ToString();//SettlementDate
                        //    logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(this.View.DepositEntity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//Rate
                        //    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "Online Deposit Commit Deno", CurrentUserEntity.BranchCode,
                        //    logItemForDeno);

                        //    //ClientLog For Tlf
                        //    for (int i = 0; i < this.View.DenoCollection.Count; i++)
                        //    {
                        //        if (this.View.DenoCollection.Count > 1)
                        //            logItemForTlf[0] = Tlf_List[0].Description;//GroupNo
                        //        else
                        //            logItemForTlf[0] = string.Empty;//GroupNo
                        //        logItemForTlf[1] = Tlf_List[i].Eno;//EntryNo
                        //        logItemForTlf[2] = this.View.DenoCollection[i].AccountNo;//AcctNo
                        //        if (this.View.DenoCollection[i].AccountSign.Length > 0)
                        //        {
                        //            if (this.View.DenoCollection[i].AccountSign.StartsWith("C"))
                        //                logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                        //            else if (this.View.DenoCollection[i].AccountSign.StartsWith("S"))
                        //                logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                        //            else if (this.View.DenoCollection[i].AccountSign.StartsWith("L"))
                        //                logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)

                        //            else if (this.View.DenoCollection[i].AccountSign.StartsWith("F"))
                        //                logItemForTlf[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), this.View.DenoCollection[i].BranchCode, this.View.DenoCollection[i].Currency).ToString();//ACode(from COASetUp)
                        //        }
                        //        else
                        //        {
                        //            logItemForTlf[3] = this.View.DenoCollection[i].AccountNo;//ACode(from COASetUp)
                        //        }
                        //        logItemForTlf[4] = this.View.DenoCollection[i].Amount.ToString();//LocalAmount
                        //        logItemForTlf[5] = this.View.DenoCollection[i].Currency;//SourceCur
                        //        logItemForTlf[6] = this.View.DenoCollection[i].ChequeNo;//Cheque
                        //        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        //        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.DepositEntity.FromBranchCode).ToString();//SettlementDate
                        //        logItemForTlf[9] = Tlf_List[i].SourceCurrency;//Status
                        //        logItemForTlf[80] = this.View.DenoCollection[i].BranchCode;//SourceBr
                        //        logItemForTlf[11] = string.Empty;//Rno
                        //        logItemForTlf[12] = string.Empty;//Duration
                        //        logItemForTlf[13] = string.Empty;//LasintDate
                        //        logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
                        //        logItemForTlf[15] = string.Empty;//Accured
                        //        logItemForTlf[16] = string.Empty;//BudenAcc
                        //        logItemForTlf[17] = string.Empty;//Draccured
                        //        logItemForTlf[18] = string.Empty;//AccuredStatus
                        //        logItemForTlf[19] = string.Empty;//ToAccountNo
                        //        logItemForTlf[20] = string.Empty;//FirstRno
                        //        logItemForTlf[21] = string.Empty;//PoNo
                        //        logItemForTlf[22] = string.Empty;//ADate
                        //        logItemForTlf[23] = string.Empty;//IDate
                        //        logItemForTlf[24] = string.Empty;//ToAcctNo
                        //        logItemForTlf[25] = this.View.DenoCollection[i].Commissions.ToString();//Income
                        //        logItemForTlf[26] = string.Empty;//Budget
                        //        logItemForTlf[27] = this.View.DepositEntity.FromBranchCode;//FromBranch
                        //        logItemForTlf[28] = this.View.DenoCollection[i].BranchCode;//ToBranch
                        //        logItemForTlf[29] = "0";//Inout
                        //        logItemForTlf[30] = "1";//Success
                        //        logItemForTlf[31] = this.View.DenoCollection[i].CommunicationCharges.ToString();//COMMUCHARGE
                        //        logItemForTlf[32] = "1";//IncomeType
                        //        logItemForTlf[33] = string.Empty;//OtherBank
                        //        logItemForTlf[34] = string.Empty;//OtherBankChq
                        //        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Online Deposit Commit Transaction", CurrentUserEntity.BranchCode,
                        //        logItemForTlf);
                        //    }
                        //}
                        #endregion



                        if (this.View.DenoCollection.Count >1)
                        {
                            this.View.VoucherNo = Tlf_List[0].Description;
                            this.view.Successful(CXMessage.MI00051, "Group No", Tlf_List[0].Description);
                        }
                       
                       else
                        {
                            this.View.VoucherNo = Tlf_List[0].Eno;
                            this.view.Successful(CXMessage.MI00051, "Voucher No", Tlf_List[0].Eno);
                        }
                        this.View.VoucherLabel = this.View.DenoCollection.Count == 1 ? "VoucherNo :" : "GroupNo :";

                        //Added by HWKO (06-Dec-2017)
                        if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00016) == DialogResult.Yes)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00085", true, new object[] { this.view.DenoCollection,this.View.VoucherNo });
                        }
                        //Endregion

                        return true;
                    }
                    #endregion
                }
            }
            return false;
        }       

        public void CalculateTotalAmount()
        {
            this.View.TotalAmount = 0;
            foreach (TLMDTO00038 entity in this.View.DenoCollection)
                this.View.TotalAmount += entity.Amount + entity.Commissions + entity.CommunicationCharges;
        }

        private TLMDTO00038 GetDepositInfoToSave(TLMDTO00038 depositEntity)
        {
            depositEntity.TotalAmount = this.View.TotalAmount;
            depositEntity.AdjustAmount = this.View.DenoInfo.AdjustAmount;
            depositEntity.CounterNo = this.View.DenoInfo.CounterNo;
            depositEntity.DenoRate = this.View.DenoInfo.DenoRateString;
            depositEntity.DenoString = this.View.DenoInfo.DenoString;
            depositEntity.RefundRate = this.View.DenoInfo.RefundRateString;
            depositEntity.RefundString = this.View.DenoInfo.RefundString;
            depositEntity.UpdatedUserId = depositEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            depositEntity.FromBranchCode = this.View.LocalBranchCode.Trim();
            depositEntity.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
            depositEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;

            return depositEntity;
        }
        public void Call_AccountInformationEnquiry()
        {
            CXUIScreenTransit.Transit("frmTLMVEW00042", true, new object[] { "frmTLMVEW00080", this.View.AccountNo });
        }

        //public void Call_RemittanceCalculator()
        //{
        //    CXUIScreenTransit.Transit("frmTLMVEW00008", true, new object[] { "frmTLMVEW00080", this.View.Amount });
        //}
        
        //public void gvDeposit_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (this.view.DenoCollection.Count < 1 && this.view.DepositEntity.IsCheckGridview)
        //    {
        //        // Do Data to deposit.
        //        this.SetCustomErrorMessage(this.GetControl("gvDepositInformation"), CXMessage.MV00807);
        //    }
        //}
        //public void Printing()
        //{
        //    try
        //    {
        //        IList<PFMDTO00043> PintFileList = new List<PFMDTO00043>();
        //        List<string[]> printingList;

        //        var list = from x in this.View.DenoCollection where x.IsPrintTransaction == true select x.AccountNo;

        //        if (list.Count<string>() == 0)
        //            return;

        //        PintFileList = CXCLE00006.Instance.SelectAllPrintingDataForCSAccounts(list.ToArray<string>());
        //        foreach (TLMDTO00038 info in this.View.DenoCollection)
        //        {
        //            var query = from z in PintFileList where z.AccountNo == info.AccountNo orderby z.CreatedDate select z;
        //            printingList = new List<string[]>();

        //            for (int i = 0; i < query.Count<PFMDTO00043>(); i++)
        //            {
        //                PFMDTO00043 prnFile = query.ElementAt(i);
        //                string dateTime = CXCOM00006.Instance.GetDateFormat(prnFile.DATE_TIME.Value).ToString();
        //                string[] prnFileStrArr = { dateTime, prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };
        //                //string[] prnFileStrArr = { prnFile.DATE_TIME.Value.ToString("yyyy/mm/dd"), prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

        //                printingList.Add(prnFileStrArr);
        //            }
        //            if (query.Count<PFMDTO00043>() > 0)
        //            {
        //                if (this.view.AccountSign.Substring(0, 1) == "S")  //Added by ASDA
        //                {
        //                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { info.AccountNo });
        //                }
        //                else
        //                {
        //                    if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00016) == DialogResult.No) //Do you want to print Transactions?
        //                        return;
        //                } //end------------------------------------  

        //                CXCLE00005.Instance.StartLineNo = (int)query.ToList<PFMDTO00043>()[0].PrintLineNo == 0 ? 1 : (int)query.ToList<PFMDTO00043>()[0].PrintLineNo;
        //                int prnLineNo = 0;
        //                prnLineNo = CXCLE00005.Instance.StartLineNo;
        //                PFMDTO00043 prnFile = query.ElementAt(0);

        //                CXUIScreenTransit.Transit("frmPFMVEW00009", true, new object[] { true, prnLineNo, prnFile, false });

        //                //CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true, out prnLineNo);

        //                //if (!CXCLE00006.Instance.UpdateAfterPrintingForCS(info.AccountNo, prnLineNo, CurrentUserEntity.CurrentUserID))
        //                //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
        //                int lineNo = printingList.Count;
        //                if (!CXClientWrapper.Instance.Invoke<ITLMSVE00080, bool>(x => x.UpdateCleadgerPrintLineNoandDeletePrnFile(info.AccountNo, CurrentUserEntity.CurrentUserID, lineNo)))
        //                { Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode); }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
        //    }
        //    finally
        //    {
        //        this.ClearControls(true);
        //    }
        //}

        //Added by HMW at 29-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 22-08-2019 : [Seperating EOD Process] 
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }
        #endregion

    }
}
