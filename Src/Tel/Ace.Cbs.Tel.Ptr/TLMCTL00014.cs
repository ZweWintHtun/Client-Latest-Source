//----------------------------------------------------------------------
// <copyright file="TLMCTL00014.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>2013-06-07</CreatedDate>
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
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using System.Windows.Forms;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// Withdrawl Entry Controller
    /// </summary>

    public class TLMCTL00014 : AbstractPresenter, ITLMCTL00014
    {
        #region Initialize View
        private ITLMVEW00014 view;
        public ITLMVEW00014 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }


        private void WireTo(ITLMVEW00014 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetWithdrawalEntity());
            }
        }
        #endregion

        #region Properties

        TLMDTO00047 withdrawDTO { get; set; }
        public string accountSign { get; set; }
        int printedLine;
        decimal Charges=0;
        bool IsCloseAccount = false;
        int flag = 0;

        decimal editedcommissioncharges = 0;
        decimal editedcommunicationcharges = 0;
        //IList<TLMDTO00047> withdrawList = new List<TLMDTO00047>();
        public string BranchCode { get; set; }
        private readonly TransactionLogUtilities  ClientLog = new TransactionLogUtilities();
        #endregion

        #region HelperMethod
        public TLMDTO00047 GetWithdrawalEntity()
        {          
            TLMDTO00047 withdrawalEntity = new TLMDTO00047();
            withdrawalEntity.GroupNo = this.view.GroupNo;
            withdrawalEntity.CurrencyCode = this.view.CurrencyCode;
            withdrawalEntity.AccountNo = this.view.AccountNo;
            withdrawalEntity.Amount = this.view.Amount;
            withdrawalEntity.ChequeNo = this.view.ChequeNo;
            withdrawalEntity.NoOfPersonSign = this.view.NoOfPersonSign;
            withdrawalEntity.JoinType = this.view.JoinType;
            withdrawalEntity.Commission = this.view.Comissions;
            withdrawalEntity.CommunicationCharges = this.view.CommunicationCharges;
            if (this.view.IsEdit == true)  //added by ASDA**
            {
                editedcommissioncharges = this.view.Comissions;
                editedcommunicationcharges = this.view.CommunicationCharges;
                this.view.IsEdit = false;
            }  //End**
            withdrawalEntity.IsVIP = this.view.VIPCustomer;
            withdrawalEntity.PrintTransactionStatus = this.view.PrintStatus;
            withdrawalEntity.Name = this.view.Name;
            withdrawalEntity.TotalAmount = this.view.TotalAmount;
            withdrawalEntity.LocalWithdrawType = this.view.LocalWithdrawType;
            withdrawalEntity.OnlineWithdrawType = this.view.OnlineWithdrawType;
            withdrawalEntity.IsIncomeByCash = this.view.IncomeByCash;
            withdrawalEntity.IsIncomeByTransfer = this.view.IncomeByTransfer;
            withdrawalEntity.LocalBranchCode = this.view.LocalBranchCode;
            withdrawalEntity.ToBranch = this.View.ToBranch;
            withdrawalEntity.AccountSing = this.accountSign;
            withdrawalEntity.CurrentAccountSign = this.view.CurrentAccountSign;
            withdrawalEntity.SavingAccountSign = this.view.SavingAccountSign;
            
            if (this.IsCloseAccount == true)  //Added by ASDA
                withdrawalEntity.IsLastWithdrawal = true;
            else
                withdrawalEntity.IsLastWithdrawal = this.View.IsLastWithdrawal;   //end------------
            return withdrawalEntity;  
        }
        public TLMDTO00047 AddWithdrawInfo()
        {           
            TLMDTO00047 withdrawdto = new TLMDTO00047();
            this.View.IsAutoLink = false;

            if (!this.DebitAccountInformationChecking(this.GetWithdrawalEntity()))
                return null;
            else
            {
                withdrawdto.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                withdrawdto.AccountNo = this.view.AccountNo;
                withdrawdto.Amount = this.view.Amount;
                withdrawdto.CurrencyCode = this.view.CurrencyCode;
                withdrawdto.TotalAmount = this.view.TotalAmount;
                withdrawdto.FromBranch = this.view.LocalBranchCode;
                withdrawdto.CreatedUserId = CurrentUserEntity.CurrentUserID;
                withdrawdto.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                if (string.IsNullOrEmpty(this.view.JoinType))
                { this.view.JoinType = Convert.ToString(0); }
                withdrawdto.NoOfPerSignJoinType = Convert.ToString(this.view.NoOfPersonSign) + "/" + this.view.JoinType;
                withdrawdto.AccountSing = this.accountSign;
                withdrawdto.CurrentAccountSign = this.view.CurrentAccountSign;
                withdrawdto.SavingAccountSign = this.view.SavingAccountSign;
                withdrawdto.UserNo = Convert.ToString(CurrentUserEntity.CurrentUserID);
                withdrawdto.SourceBranchCode = CurrentUserEntity.BranchCode;
                withdrawdto.ToBranch = this.view.ToBranch;
                withdrawdto.ChequeNo = this.view.ChequeNo;
                if (this.view.InputIncomeAmount)  //added by ASDA **
                {
                    withdrawdto.Commission = editedcommissioncharges;
                    withdrawdto.CommunicationCharges = editedcommunicationcharges;
                }
                else
                {
                    withdrawdto.Commission = this.View.Comissions;
                    withdrawdto.CommunicationCharges = this.view.CommunicationCharges;
                }   //End**
                withdrawdto.IsVIP = this.view.VIPCustomer;
                withdrawdto.PrintTransactionStatus = this.view.PrintStatus;
                //withdrawdto.CommunicationCharges = this.View.CommunicationCharges;
                withdrawdto.TotalAmount = this.view.TotalAmount;
                withdrawdto.IsAutoLink = this.View.IsAutoLink;
                withdrawdto.IncomeType = this.view.IncomeByCash ? "1" : "2";
                withdrawdto.IncomeByCashStatus = this.view.IncomeByCash;
                withdrawdto.IncomeByTransferStatus = this.view.IncomeByTransfer;

                withdrawdto.TotalCharges +=  this.view.TotalCharges;
               
                //Added by ASDA
                if (this.IsCloseAccount == true)
                    withdrawdto.IsLastWithdrawal = true;
                else
                    withdrawdto.IsLastWithdrawal = this.View.IsLastWithdrawal;
                //end-----------
            }
            return withdrawdto;
        }

         //Added by ASDA
        //private CXDTO00001 GetDenoList(decimal amount, CXDMD00008 status,IList<TLMDTO00047> withdraws)
        //{
        //    IList<TLMDTO00047> withdrawList = withdraws;
        //    if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { amount, withdrawList[0].CurrencyCode, status, "frmTLMVEW00014" }) == DialogResult.OK)
        //    {
        //        return CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00014");
        //    }
        //    else
        //        //Error Occur becoz user don't enter deno entry but close the deno form.
        //        //this.View.Failure(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
        //        return null;
        //}
        public void Printing(IList<TLMDTO00047> withdraws)
        {
            try
            {
                IList<PFMDTO00043> PintFileList = new List<PFMDTO00043>();
                List<string[]> printingList;

                var list = from x in withdraws where x.PrintTransactionStatus == true select x.AccountNo;

                if (list.Count<string>() == 0)
                    return;

                PintFileList = CXCLE00006.Instance.SelectAllPrintingDataForCSAccounts(list.ToArray<string>());
                foreach (TLMDTO00047 info in withdraws )
                {
                    var query = from z in PintFileList where z.AccountNo == info.AccountNo orderby z.CreatedDate select z;
                    printingList = new List<string[]>();

                    for (int i = 0; i < query.Count<PFMDTO00043>(); i++)
                    {
                        PFMDTO00043 prnFile = query.ElementAt(i);
                        string date = CXCOM00006.Instance.GetDateFormat(prnFile.DATE_TIME.Value).ToString();
                        string[] prnFileStrArr = { date, prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };
                        //string[] prnFileStrArr = { prnFile.DATE_TIME.Value.ToString("dd/MM/yyyy"), prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

                        printingList.Add(prnFileStrArr);
                    }
                     
                    if (query.Count<PFMDTO00043>() > 0)
                    {
                        if (this.accountSign.Substring(0, 1) == "S")  //Added by ASDA
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { info.AccountNo });
                        }
                        else
                        {
                            if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00016) == DialogResult.No) //Do you want to print Transactions?
                                return;
                        }   //end------------------------------------                      

                        CXCLE00005.Instance.StartLineNo = (int)query.ToList<PFMDTO00043>()[0].PrintLineNo == 0 ? 1 : (int)query.ToList<PFMDTO00043>()[0].PrintLineNo;
                        printedLine = CXCLE00005.Instance.StartLineNo;
                        CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true,out printedLine);

                        //if (!CXCLE00006.Instance.UpdateAfterPrintingForCS(info.AccountNo, printedLine, CurrentUserEntity.CurrentUserID))
                        //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
                        int lineNo = printingList.Count;
                        if (!CXClientWrapper.Instance.Invoke<ITLMSVE00014, bool>(x => x.UpdateCleadgerPrintLineNoandDeletePrnFile(info.AccountNo, CurrentUserEntity.CurrentUserID,lineNo)))
                        { Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode); }
                    }
                }
            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
            }
            finally
            {
                this.ClearControls(true);
            }
        }  
        #endregion

        #region UI Logic

        public void cboCurrency_CustomValidating(object sender, ValidationEventArgs e)
        {

            if (e.HasXmlBaseError || string.IsNullOrEmpty(this.View.CurrencyCode))
            {
                this.SetFocus("cboCurrency");
                return;
            }
            else
                this.View.DisableControlsforView("Curreny.Disable");
        }

        public void ClearControls(bool isCancel)
        {
            this.view.GroupNo = string.Empty;
            this.view.AccountNo = string.Empty;
            this.view.Amount = 0;
            this.view.ChequeNo = string.Empty;
            this.view.NoOfPersonSign = 0;
            this.view.Comissions = 0;
            this.view.CommunicationCharges = 0;
            this.view.VIPCustomer = false;
            this.view.PrintStatus = false;
            this.view.InputIncomeAmount = false;
            this.view.IncomeByCash = false;
            this.view.IncomeByTransfer = false;
            this.view.JoinType = string.Empty;
            this.view.Status = "";         
            this.view.EnableControlsForController("Withdraw.Local.EnableControls");

            if (isCancel)
            {
                this.view.WithdrawLists.Clear();
                this.view.BindgvMultiAccountWithdrawlInformation(this.view.WithdrawLists);
                this.View.TotalCharges = 0;
            }
        }

        public bool SaveWithdraw(IList<TLMDTO00047> withdrawList)
        {
                IList<PFMDTO00054> Tlf_List = new List<PFMDTO00054>();
                string voucherNo = string.Empty;
                bool returnValue = false;
                withdrawList[0].TotalAmount = this.view.TotalAmount;
                withdrawList[0].TotalCharges = this.view.TotalCharges;
                for(int i = 0; i  < withdrawList.Count; i++)    
                {
                    if (flag == 1) withdrawList[i].Active = true; //  For Last Withdraw Narration
                    else withdrawList[i].Active = false;
                }
                if (this.view.LocalWithdrawType)
                {
                    Tlf_List = CXClientWrapper.Instance.Invoke<ITLMSVE00014, IList<PFMDTO00054>>(x => x.SaveWithdrawLocal(withdrawList));                     
                }
                else
                {
                    Tlf_List = CXClientWrapper.Instance.Invoke<ITLMSVE00014, IList<PFMDTO00054>>(x => x.SaveWithdrawOnline(withdrawList, CurrentUserEntity.BranchCode));
                }

                #region Error Occur
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    //ClientLog For LocalWithdrawType
                    if (this.view.LocalWithdrawType)
                    {
                        for (int i = 0; i < withdrawList.Count; i++)
                        {
                            string[] logItem = new string[35];
                            withdrawList[i].SettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), withdrawList[i].SourceBranchCode);
                            if (withdrawList.Count > 1)
                                logItem[0] = Tlf_List[0].Description;//GroupNo
                            else
                                logItem[0] = string.Empty;//GroupNo
                            logItem[1] = Tlf_List[i].Eno;//EntryNo
                            logItem[2] = withdrawList[i].AccountNo;//AcctNo
                            if (withdrawList[i].AccountSing.Length > 0)
                            {
                                if (withdrawList[i].AccountSing.StartsWith("C"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("S"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("L"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("F"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)
                                
                                else if (withdrawList[i].AccountSing.StartsWith("B"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("P"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("H"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HPControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("D"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)
                            }
                            else
                            {
                                logItem[3] = withdrawList[i].AccountNo;//ACode(from COASetUp)
                            }
                            logItem[4] = withdrawList[i].Amount.ToString();//LocalAmount
                            logItem[5] = withdrawList[i].CurrencyCode;//SourceCur
                            logItem[6] = withdrawList[i].ChequeNo;//Cheque
                            logItem[7] = System.DateTime.Now.ToString();//Date_Time
                            logItem[8] = withdrawList[i].SettlementDate.ToString();//SettlementDate
                            logItem[9] = Tlf_List[i].SourceCurrency;//Status
                            logItem[10] = withdrawList[i].SourceBranchCode;//SourceBr
                            logItem[11] = string.Empty;//Rno
                            logItem[12] = string.Empty;//Duration
                            logItem[13] = string.Empty;//LasintDate
                            logItem[14] = Tlf_List[i].Rate.ToString();//intRate
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
                            logItem[25] = withdrawList[i].Commission.ToString();//Income
                            logItem[26] = string.Empty;//Budget
                            logItem[27] = withdrawList[i].FromBranch;//FromBranch
                            logItem[28] = withdrawList[i].ToBranch;//ToBranch
                            logItem[29] = string.Empty;//Inout
                            logItem[30] = string.Empty;//Success
                            logItem[31] = withdrawList[i].CommunicationCharges.ToString();//COMMUCHARGE
                            logItem[32] = withdrawList[i].IncomeType;//IncomeType
                            logItem[33] = string.Empty;//OtherBank
                            logItem[34] = string.Empty;//OtherBankChq
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Local Withdraw Fail Transcation", CurrentUserEntity.BranchCode,
                            logItem);
                        }
                    }
                    //ClientLog For OnlineWithdrawType
                    else
                    {
                        for (int i = 0; i < withdrawList.Count; i++)
                        {
                            string[] logItem = new string[35];
                            withdrawList[i].SettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), withdrawList[i].SourceBranchCode);
                            if (withdrawList.Count > 1)
                                logItem[0] = Tlf_List[i].Description;//GroupNo
                            else
                                logItem[0] = string.Empty;//GroupNo
                            logItem[1] = Tlf_List[i].Eno;//EntryNo
                            logItem[2] = withdrawList[i].AccountNo;//AcctNo
                            if (withdrawList[i].AccountSing.Length > 0)
                            {
                                if (withdrawList[i].AccountSing.StartsWith("C"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("S"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("L"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("F"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("B"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("P"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("H"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HPControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("D"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)
                            }
                            else
                            {
                                logItem[3] = withdrawList[i].AccountNo;//ACode(from COASetUp)
                            }
                            logItem[4] = withdrawList[i].Amount.ToString();//LocalAmount
                            logItem[5] = withdrawList[i].CurrencyCode;//SourceCur
                            logItem[6] = withdrawList[i].ChequeNo;//Cheque
                            logItem[7] = System.DateTime.Now.ToString();//Date_Time
                            logItem[8] = withdrawList[i].SettlementDate.ToString();//SettlementDate
                            logItem[9] = Tlf_List[i].SourceCurrency;//Status
                            logItem[10] = withdrawList[i].SourceBranchCode;//SourceBr
                            logItem[11] = string.Empty;//Rno
                            logItem[12] = string.Empty;//Duration
                            logItem[13] = string.Empty;//LasintDate
                            logItem[14] = Tlf_List[i].Rate.ToString();//intRate
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
                            logItem[25] = withdrawList[i].Commission.ToString();//Income
                            logItem[26] = string.Empty;//Budget
                            logItem[27] = withdrawList[i].FromBranch;//FromBranch
                            logItem[28] = withdrawList[i].ToBranch;//ToBranch
                            logItem[29] = "0";//Inout
                            logItem[30] = "1";//Success
                            logItem[31] = withdrawList[i].CommunicationCharges.ToString();//COMMUCHARGE
                            logItem[32] = withdrawList[i].IncomeType;//IncomeType
                            logItem[33] = string.Empty;//OtherBank
                            logItem[34] = string.Empty;//OtherBankChq
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Online Withdraw Fail Transcation", CurrentUserEntity.BranchCode,
                            logItem);
                        }
 
                    }
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    returnValue = false;
                }
                #endregion

                #region Successful Transcation
                else
                {
                    //ClientLog For LocalWithdrawType
                    if (this.view.LocalWithdrawType)
                    {
                        for (int i = 0; i < withdrawList.Count; i++)
                        {
                            string[] logItem = new string[35];
                            withdrawList[i].SettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), withdrawList[i].SourceBranchCode);
                            if (withdrawList.Count>1)
                                logItem[0] = Tlf_List[0].Description;//GroupNo
                            else
                                logItem[0] = string.Empty;//GroupNo
                            logItem[1] = Tlf_List[i].Eno;//EntryNo
                            logItem[2] = withdrawList[i].AccountNo;//AcctNo
                            if (withdrawList[i].AccountSing.Length > 0)
                            {
                                if (withdrawList[i].AccountSing.StartsWith("C"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("S"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("L"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("F"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)
                                
                                else if (withdrawList[i].AccountSing.StartsWith("B"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("P"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("H"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HPControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("D"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)
                            }
                            else
                            {
                                logItem[3] = withdrawList[i].AccountNo;//ACode(from COASetUp)
                            }
                            logItem[4] = withdrawList[i].Amount.ToString();//LocalAmount
                            logItem[5] = withdrawList[i].CurrencyCode;//SourceCur
                            logItem[6] = withdrawList[i].ChequeNo;//Cheque
                            logItem[7] = System.DateTime.Now.ToString();//Date_Time
                            logItem[8] = withdrawList[i].SettlementDate.ToString();//SettlementDate
                            logItem[9] = Tlf_List[i].SourceCurrency;//Status
                            logItem[10] = withdrawList[i].SourceBranchCode;//SourceBr
                            logItem[11] = string.Empty;//Rno
                            logItem[12] = string.Empty;//Duration
                            logItem[13] = string.Empty;//LasintDate
                            logItem[14] = Tlf_List[i].Rate.ToString();//intRate
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
                            logItem[25] = withdrawList[i].Commission.ToString();//Income
                            logItem[26] = string.Empty;//Budget
                            logItem[27] = withdrawList[i].FromBranch;//FromBranch
                            logItem[28] = withdrawList[i].ToBranch;//ToBranch
                            logItem[29] = string.Empty;//Inout
                            logItem[30] = string.Empty;//Success
                            logItem[31] = withdrawList[i].CommunicationCharges.ToString();//COMMUCHARGE
                            logItem[32] = withdrawList[i].IncomeType;//IncomeType
                            logItem[33] = string.Empty;//OtherBank
                            logItem[34] = string.Empty;//OtherBankChq
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Local Withdraw Commit Transaction", CurrentUserEntity.BranchCode,
                            logItem);
                        }
                    }
                    //ClientLog For OnlineWithdrawType
                    else
                    {
                        for (int i = 0; i < withdrawList.Count; i++)
                        {
                            string[] logItem = new string[35];
                            withdrawList[i].SettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), withdrawList[i].SourceBranchCode);
                            if (withdrawList.Count > 1)
                                logItem[0] = Tlf_List[0].Description;//GroupNo
                            else
                                logItem[0] = string.Empty;//GroupNo
                            logItem[1] = Tlf_List[i].Eno;//EntryNo
                            logItem[2] = withdrawList[i].AccountNo;//AcctNo
                            if (withdrawList[i].AccountSing.Length > 0)
                            {
                                if (withdrawList[i].AccountSing.StartsWith("C"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("S"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("L"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CalControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("F"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.FixControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("B"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.BLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("P"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("H"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.HPControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)

                                else if (withdrawList[i].AccountSing.StartsWith("D"))
                                    logItem[3] = CXCOM00010.Instance.GetCoaSetupAccountNo(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.DLControl), withdrawList[i].SourceBranchCode, withdrawList[i].CurrencyCode).ToString();//ACode(from COASetUp)
                            }
                            else
                            {
                                logItem[3] = withdrawList[i].AccountNo;//ACode(from COASetUp)
                            }
                            logItem[4] = withdrawList[i].Amount.ToString();//LocalAmount
                            logItem[5] = withdrawList[i].CurrencyCode;//SourceCur
                            logItem[6] = withdrawList[i].ChequeNo;//Cheque
                            logItem[7] = System.DateTime.Now.ToString();//Date_Time
                            logItem[8] = withdrawList[i].SettlementDate.ToString();//SettlementDate
                            logItem[9] = Tlf_List[i].SourceCurrency;//Status
                            logItem[10] = withdrawList[i].SourceBranchCode;//SourceBr
                            logItem[11] = string.Empty;//Rno
                            logItem[12] = string.Empty;//Duration
                            logItem[13] = string.Empty;//LasintDate
                            logItem[14] = Tlf_List[i].Rate.ToString();//intRate
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
                            logItem[25] = withdrawList[i].Commission.ToString();//Income
                            logItem[26] = string.Empty;//Budget
                            logItem[27] = withdrawList[i].FromBranch;//FromBranch
                            logItem[28] = withdrawList[i].ToBranch;//ToBranch
                            logItem[29] = "0";//Inout
                            logItem[30] = "1";//Success
                            logItem[31] = withdrawList[i].CommunicationCharges.ToString();//COMMUCHARGE
                            logItem[32] = withdrawList[i].IncomeType;//IncomeType
                            logItem[33] = string.Empty;//OtherBank
                            logItem[34] = string.Empty;//OtherBankChq
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Online Withdraw Commit Transcation", CurrentUserEntity.BranchCode,
                            logItem);
                        }

                    }
                    this.ClearErrors();
                    if (withdrawList.Count > 1)
                    {
                        this.View.GroupNo = Tlf_List[0].Description;
                        this.view.Successful(CXMessage.MI00051, "Group No", Tlf_List[0].Description);
                    }
                    else
                    {
                        this.View.GroupNo = Tlf_List[0].Eno;
                        this.view.Successful(CXMessage.MI00051, "Voucher No", Tlf_List[0].Eno);
                    }
                    returnValue = true;
                    this.ClearErrors();
                }
                #endregion

                return returnValue;                     
        }

        public bool DebitAccountInformationChecking(TLMDTO00047 withdrawInfo)
        {
            bool isLinkAccount = false;

            isLinkAccount = CXClientWrapper.Instance.Invoke<ITLMSVE00014, bool>(x => x.DebitInformationCheckingAndLink(withdrawInfo));
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

            return true;
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
            if (e.HasXmlBaseError)
                return;
            try
            {
                this.view.IsCloseAccount = false;
                
                Nullable<CXDMD00011> accountType;
                // Checking Account in Grid.
                var data = from x in this.view.WithdrawLists where x.AccountNo == this.View.AccountNo select x;
                int i = data.ToList<TLMDTO00047>() == null ? 0 : data.ToList<TLMDTO00047>().Count;

                if (this.view.WithdrawLists.Count > 0 && i > 0 && this.view.Status != "Update")
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV90001); // Data Already Exits.
                    return;
                }
                 if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2) == true)
                {
                    IList<PFMDTO00001> customer = CXClientWrapper.Instance.Invoke<ITLMSVE00014, IList<PFMDTO00001>>(x => x.GetAccountInfoByAccountNo(this.view.AccountNo, this.view.VIPCustomer,this.View.LocalBranchCode,DateTime.Now));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        return;
                    }
                    // customer hasn't
                    if (customer.Count == 0)
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.AccountNo });
                        return;
                    }
                    else if (customer.Count > 0)
                    {
                        // close account
                        //Added by ZMS  
                        foreach (PFMDTO00001 item in customer)
                        {
                            if (Convert.ToString(item.CloseDate) != "null" && Convert.ToString(item.CloseDate) != "NULL" && Convert.ToString(item.CloseDate) != string.Empty)
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00044);///Account No has been closed.
                                return;
                            }
                        }
                        //Added by ZMS  for Pristine Requirements (even loans are expired ,they wanted to make transfer )
                        if (customer[0].ExpiredStatus == true)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90059);///This loan no. is expired!                                      
                        }
                        // UI Bind Field                    
                        this.view.NoOfPersonSign = customer[0].NoOfPersonSign;
                        this.view.JoinType = customer[0].JoinType;
                        this.view.Name = customer[0].Name;
                        this.accountSign = customer[0].AccountSign;
                        this.view.CheckedJoinType();
                        this.BranchCode = customer[0].SourceBranch;
                        this.View.ToBranch = customer[0].SourceBranch;

                        //Check UI Currency with Account Currency
                        if (this.view.CurrencyCode != customer[0].CurrencyCode)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00086, new object[] { this.view.CurrencyCode });
                            return;
                        }
                        else if (this.view.WithdrawLists.Count == 0)
                        {
                            this.view.LocalWithdrawType = this.view.LocalBranchCode.Equals(customer[0].SourceBranch) ? true : false;
                            this.view.OnlineWithdrawType = this.view.LocalBranchCode.Equals(customer[0].SourceBranch) ? false : true;
                            this.view.EnableControlsForController(this.view.LocalWithdrawType ? "Withdraw.Local.EnableControls" : "Withdraw.Online.EnableControls");
                            this.view.ToBranch = customer[0].SourceBranch;
                        }
                        //Check Account No is Local or Online Account                    
                        else if (this.view.LocalWithdrawType && CurrentUserEntity.BranchCode != customer[0].SourceBranch)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00165, new object[] { "Local Bank " });
                            return;
                        }
                        else if (this.view.OnlineWithdrawType && CurrentUserEntity.BranchCode == customer[0].SourceBranch)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00165, new object[] { "Other Bank " });
                            return;
                        }
                        this.view.EnableControlsForController(this.view.LocalWithdrawType ? "Withdraw.Local.EnableControls" : "Withdraw.Online.EnableControls");

                        //Check Account is Current Or Saving  Account
                        if (customer[0].IsLastWithdrawal)// Check this acctno is IsLastWithDraw or not
                        {
                            this.IsCloseAccount = true;     //added by ASDA
                            //Commented by AAM(12_Sep_2018) ,According to pristine requirements.
                            //if (flag == 0)
                            //{
                            //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00061);
                            //    flag = 1;
                            //    this.IsCloseAccount = false;
                            //} 
                            this.View.ChequeNo = customer[0].ChequeNo;
                            this.View.Amount = customer[0].CurrentBal;
                            this.view.IsCloseAccount = true;
                            this.view.DisableControlsForController("WithdrawEntry.LastTimeDisableControls");
                            //Added by AAM(12_Sep_2018)
                            this.view.IsCloseAccount = true;

                        }
                        else if (this.view.SavingAccountSign == customer[0].AccountSign.Substring(0, 1))
                            this.view.DisableControlsForController("Withdraw.ChequeNo.DisableControls");

                    }
                }

            }
            catch(Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);               
            }
        }

        public void txtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
                return;
            //else if (!string.IsNullOrEmpty(this.view.Status))    //comment by ASDA
            //    return;

            TLMDTO00047 withdrawdto = new TLMDTO00047();
            withdrawdto.AccountNo = this.view.AccountNo;
            withdrawdto.Amount = this.view.Amount;
            withdrawdto.IsVIP = this.view.VIPCustomer;
            bool isActive = true;          
            if (this.view.OnlineWithdrawType)
            {
                TLMDTO00029 remitBranchDTO = CXCLE00002.Instance.GetScalarObject<TLMDTO00029>("RemitBranchIBL.Client.Select", new object[] { this.view.CurrencyCode, this.BranchCode, CurrentUserEntity.BranchCode });
                IList<TLMDTO00030> IBlDrawingRateList = CXCLE00002.Instance.GetClientDataList<TLMDTO00030>("IBLDrawingRate.Client.Select", new object[] { this.view.CurrencyCode, this.BranchCode, CurrentUserEntity.BranchCode, isActive });

                foreach (TLMDTO00030 info in IBlDrawingRateList)
                {
                    if (info.StartNo <= this.View.Amount && info.EndNo >= this.View.Amount)
                        this.view.Comissions = info.FixAmount.Value;
                    else if (info.StartNo <= this.View.Amount && info.StartNo == 0)
                        this.view.Comissions = (this.View.Amount / 100) * info.Rate.Value;
                }
                this.view.CommunicationCharges = remitBranchDTO.TelaxCharges;
            }
        }

        public bool Validate()
        {
            return this.ValidateForm(this.GetWithdrawalEntity());
        }
        public bool ValidateAdd()
        {
            return this.ValidateForm(this.GetWithdrawalEntity());
        }              
        public void txtChequeNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                if (e.HasXmlBaseError)
                    return;
                else
                {
                    if (IsCloseAccount == false)
                    {
                        //Added by ASDA
                        if (!this.view.ChequeNo.Equals(string.Empty))
                        {
                            this.view.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
                            string branch = this.view.AccountNo.Substring(0, 3).Trim();
                            bool result = CXClientWrapper.Instance.Invoke<ITLMSVE00014, bool>(x => x.CheckingChequeNo(this.view.AccountNo, this.view.ChequeNo, branch));
                            {
                                if (result == false)
                                {
                                    this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                                }
                            }
                        }
                        //end-----------------
                    }
                }
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), ex.Message);
            }
        }
        
        #endregion
    }
}
