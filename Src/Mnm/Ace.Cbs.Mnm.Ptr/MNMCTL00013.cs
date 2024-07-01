//----------------------------------------------------------------------
// <copyright file="MNMCTL00013.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>11/21/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Ace.Cbs.Cx.Com;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using System.Windows.Forms;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
namespace Ace.Cbs.Mnm.Ptr
{
    /// <summary>
    /// Controller
    /// Saving Interest Withdrawal Reversal
    /// </summary>
    public class MNMCTL00013 : AbstractPresenter, IMNMCTL00013
    {
        #region Iitialize View
        private IMNMVEW00013 view;
        public IMNMVEW00013 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00013 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetSavingInterestWithdrawEntity());
            }
        }
        #endregion

        #region Private Variables
        bool isCash = true;
        private IList<PFMDTO00054> tlf { get; set; }
        #endregion

        #region  Validation Logic
        public bool Validate()
        {
            return this.ValidateForm(this.GetSavingInterestWithdrawEntity());
        }
        public void txtEntryNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            this.BindSavingInterestWithdrawReversal();
        }
        #endregion

        #region Helper Methods
        
        private PFMDTO00054 GetSavingInterestWithdrawEntity()
        {
            PFMDTO00054 tlfdto = new PFMDTO00054();
            tlfdto.Eno = this.view.EntryNo;
            tlfdto.Narration = this.view.Narration;
            return tlfdto;
        }

        private IList<PFMDTO00054> SetTLFValue()
        {
            IList<PFMDTO00054> tlfdto = new List<PFMDTO00054>();
            foreach (PFMDTO00054 item in this.tlf)
            {
                PFMDTO00054 TLF = new PFMDTO00054();
                TLF.AccountNo = item.AccountNo;
                TLF.Eno = item.Eno;
                TLF.Acode = item.Acode;
                TLF.Amount = item.Amount;
                TLF.HomeAmount = item.HomeAmount;
                TLF.HomeAmt = item.HomeAmt;
                TLF.HomeOAmt = item.HomeOAmt;
                TLF.LocalAmount = item.LocalAmount;
                TLF.LocalAmt = item.LocalAmt;
                TLF.LocalOAmt = item.LocalOAmt;
                TLF.Narration = this.view.Narration;
                TLF.OrgnEno = item.OrgnEno;
                TLF.OrgnTransactionCode = item.OrgnTransactionCode;
                TLF.UserNo = Convert.ToString(CurrentUserEntity.CurrentUserID);
                TLF.SourceCurrency = item.SourceCurrency;
                TLF.Rate = item.Rate;
                TLF.TransactionCode = item.TransactionCode;
                TLF.CreatedUserId = CurrentUserEntity.CurrentUserID;
                TLF.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                TLF.SourceBranchCode = CurrentUserEntity.BranchCode;
                TLF.Channel = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel);
                TLF.Cheque = item.Cheque;
                TLF.SourceCurrency = item.SourceCurrency;
                TLF.Rate = item.Rate;
                TLF.SettlementDate = item.SettlementDate;
                TLF.TS = item.TS;
                TLF.AccountSign = item.AccountSign;
                TLF.Description = item.Description;
                if (isCash)
                {
                    TLF.VoucherStatus = "C";
                }
                else
                {
                    TLF.VoucherStatus = "D";
                }
                tlfdto.Add(TLF);
            }
            return tlfdto;
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

        #region Printing Logic
        public void PrintTransaction(string accountSign)
        {
            try
            {
                if (accountSign.Substring(0, 1) == "S" || accountSign.Substring(0, 1) == "L")
                {
                    IList<PFMDTO00043> printtransaction = new List<PFMDTO00043>();
                    List<string[]> printingList = new List<string[]>();
                    string[] AccountNo;
                    int printedLine = 0;

                    AccountNo = new string[] { this.tlf[0].AccountNo };
                    printtransaction = CXCLE00006.Instance.SelectAllPrintingDataForCSAccounts(AccountNo);

                    foreach (PFMDTO00043 prnFile in printtransaction)
                    {
                        string dateTime = CXCOM00006.Instance.GetDateFormat(prnFile.DATE_TIME.Value).ToString();
                        string[] prnFileStrArr = { dateTime, prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };
                        printingList.Add(prnFileStrArr);
                    }
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { this.tlf[0].AccountNo });
                    CXCLE00005.Instance.StartLineNo = printtransaction[0].PrintLineNo == 0 ? 1 : Convert.ToInt32(printtransaction[0].PrintLineNo);
                    printedLine = CXCLE00005.Instance.StartLineNo;
                    PFMDTO00043 Print = printtransaction.ElementAt(0);

                    CXUIScreenTransit.Transit("frmPFMVEW00009", true, new object[] { true, printedLine, Print, false });
                    int lineNo = printingList.Count;
                    if (!CXClientWrapper.Instance.Invoke<ITLMSVE00010, bool>(x => x.UpdateCleadgerPrintLineNoandDeletePrnFile(this.tlf[0].AccountNo, CurrentUserEntity.CurrentUserID, lineNo)))
                    { 
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode); 
                    }

                    this.ClearControls();

                }
            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00010);

            }

        }
        #endregion

        #region UI Logic
        public void ClearControls()
        {
            this.view.EntryNo = string.Empty;
            this.view.Narration = string.Empty;
            this.view.InterestAccount = string.Empty;
            this.view.Narration = string.Empty;
            this.view.WithdrawBy = string.Empty;
            this.view.GridViewDatasource = null;
            this.ClearErrors();
        }
        public void BindSavingInterestWithdrawReversal()
        {
            IList<PFMDTO00054> tlfdto = CXClientWrapper.Instance.Invoke<IMNMSVE00013, IList<PFMDTO00054>>(x => x.SelectSavingInterestWithdrawReversalByEntryNo(this.view.EntryNo, CurrentUserEntity.BranchCode));
            this.tlf = tlfdto;
            if (tlfdto.Count > 1)
            {
                for (int i = 0; i < tlfdto.Count; i++)
                {
                    if (tlfdto[i].Status.Substring(1, 1) == "C")
                    {
                        tlfdto[i].DebitCredit = "Credit";
                    }
                    else if (tlfdto[i].Status.Substring(1, 1) == "D")
                    {
                        tlfdto[i].DebitCredit = "Debit";
                    }
                }
                this.view.GridViewDatasource = new List<PFMDTO00054>();
                this.view.GridViewDatasource = tlfdto;
                this.view.BindgvSavingInterestWithReversalGridView();//Bind in GridView
                this.view.InterestAccount = "Interest to : " + tlfdto[0].AccountNo;
                if (tlfdto[0].Status.Substring(0, 1) == "C")
                {
                    isCash = true;
                    this.view.WithdrawBy = "Withdraw By Cash";
                }
                else
                {
                    isCash = false;
                    this.view.WithdrawBy = "Withdraw By Transfer";
                }

                this.view.EnableDisablePrintButton(this.isCash);
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }
        public void Save()
        {
            if (this.Validate())
            {
                IList<PFMDTO00054> tlfdto = this.SetTLFValue();
               

                string ReversalNo = CXClientWrapper.Instance.Invoke<IMNMSVE00013, string>(x => x.Save(tlfdto, this.isCash));

                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    for (int i = 0; i < tlfdto.Count; i++)
                    {

                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = ReversalNo;//EntryNo
                        logItemForTlf[2] = tlfdto[i].AccountNo;//AcctNo
                        logItemForTlf[3] = tlfdto[i].Acode;//ACode(from COASetUp)
                        logItemForTlf[4] = tlfdto[i].LocalAmount.ToString();//LocalAmount
                        logItemForTlf[5] = tlfdto[i].SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), tlfdto[i].SourceBranchCode).ToString();//SettlementDate
                        if (isCash)
                        {
                            TLMDTO00005 TranType = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tlfdto[i].TransactionCode, true });
                            if (TranType != null)
                            {
                                TLMDTO00005 trantype = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { TranType.RVReference, true });
                                if (trantype != null)
                                {
                                    logItemForTlf[9] = trantype.Status;//Status
                                }
                            }
                            else
                                logItemForTlf[9] = string.Empty;//Status
                        }
                        else
                        {
                            logItemForTlf[9] = string.Empty;//Status
                        }
                        logItemForTlf[10] = tlfdto[i].SourceBranchCode;//SourceBr
                        logItemForTlf[11] = tlfdto[i].Eno;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = string.Empty;//intRate
                        logItemForTlf[15] = tlfdto[i].Amount.ToString();//Accured
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
                        if (isCash)
                        {
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Saving Interest Withdrawl(By Cash) Reverse Fail Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);
                        }
                        else
                        {
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Saving Interest Withdrawl(By Transfer) Reverse Fail Transaction", CurrentUserEntity.BranchCode,
                           logItemForTlf);
 
                        }
                    }

                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion

                #region Successful
                else
                {
                    for (int i = 0; i < tlfdto.Count; i++)
                    {

                        string[] logItemForTlf = new string[35];
                        //ClientLog For Tlf
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = ReversalNo;//EntryNo
                        logItemForTlf[2] = tlfdto[i].AccountNo;//AcctNo
                        logItemForTlf[3] = tlfdto[i].Acode;//ACode(from COASetUp)
                        logItemForTlf[4] = tlfdto[i].LocalAmount.ToString();//LocalAmount
                        logItemForTlf[5] = tlfdto[i].SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), tlfdto[i].SourceBranchCode).ToString();//SettlementDate
                        if (isCash)
                        {
                            TLMDTO00005 TranType = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { tlfdto[i].TransactionCode, true });
                            if (TranType != null)
                            {
                                TLMDTO00005 trantype = CXCOM00011.Instance.GetScalarObject<TLMDTO00005>("TranType.Server.SelectByTranCode", new object[] { TranType.RVReference, true });
                                if (trantype != null)
                                {
                                    logItemForTlf[9] = trantype.Status;//Status
                                }
                            }
                            else
                                logItemForTlf[9] = string.Empty;//Status
                        }
                        else
                        {
                            logItemForTlf[9] = string.Empty;//Status
                        }
                        logItemForTlf[10] = tlfdto[i].SourceBranchCode;//SourceBr
                        logItemForTlf[11] = tlfdto[i].Eno;//Rno
                        logItemForTlf[12] = string.Empty;//Duration
                        logItemForTlf[13] = string.Empty;//LasintDate
                        logItemForTlf[14] = string.Empty;//intRate
                        logItemForTlf[15] = tlfdto[i].Amount.ToString();//Accured
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
                        if (isCash)
                        {
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Saving Interest Withdrawl(By Cash) Reverse Commit Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);
                        }
                        else 
                        {
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Saving Interest Withdrawl(By Transfer) Reverse Commit Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);
                        }
                    }
                    
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00002) == DialogResult.Yes)
                    {
                        this.Print();
                    }
                    this.ClearControls();
                    this.view.SetGridViewDataSourceNull();
                }
                #endregion
            }
        }
   
        public void Print()
        {
            //this.Save();
           this.PrintTransaction(this.tlf[0].AccountSign);
        }
        #endregion
    }
}