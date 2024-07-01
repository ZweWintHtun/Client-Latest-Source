//----------------------------------------------------------------------
// <copyright file="MNMCTL00008.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KTRHMS</CreatedUser>
// <CreatedDate>11/04/2013</CreatedDate>
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
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    /// <summary>
    /// Controller
    /// </summary>
    public class MNMCTL00008 : AbstractPresenter, IMNMCTL00008
    {

        #region "Constructor"

        public MNMCTL00008()
        {
            this.BranchCode = CXCOM00007.Instance.BranchCode;
        }

        #endregion 

        #region "Property"
        DateTime dateInTlf { get; set; }
        private string BranchCode { get; set; }
        private bool isValidateForm = false;
        private bool isSaveValidate = false;
        IList<PFMDTO00054> cashlist = new List<PFMDTO00054>();

        public string eno = string.Empty;

        private IMNMVEW00008 view;
        public IMNMVEW00008 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion "Property"

        #region "WireTo"

        private void WireTo(IMNMVEW00008 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, view.ViewEntity);
            }
        }

        #endregion WireTo

        #region "UI Logic"

        public void ClearControls()
        {            
            this.view.EntryNo= string.Empty;
            this.view.Narration = string.Empty;            
        }   
                
        #endregion "UI Logic"

        #region "Main Method"

        public void Save()
        {
            PFMDTO00054 entity = this.GetCashInfoEntity();    // Get Input Data
            entity.DateTime = dateInTlf;
            this.isValidateForm = true;

            if (this.ValidateForm(entity))                    // Validation Logic
            {
                // Saving Logic                
                if(CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes)    //confirm to save
                {
                    entity.SourceBranchCode = this.BranchCode;
                   // CXClientWrapper.Instance.Invoke<IMNMSVE00008>(x => x.Save_CashVoucher(entity));
                    string vouncherNo = CXClientWrapper.Instance.Invoke<IMNMSVE00008, string>(x => x.Save_CashVoucher(entity)); //save to server
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        string[] logItemForTlf = new string[35];
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = this.view.EntryNo;//EntryNo
                        logItemForTlf[2] = this.cashlist[0].AccountNo;//AcctNo
                        logItemForTlf[3] = this.cashlist[0].Acode;//Acode
                        logItemForTlf[4] = cashlist[0].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = cashlist[0].SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = string.Empty;//Status
                        logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = vouncherNo;//Rno
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Cash Vouncher Reversal Fail Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);
                        this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        string accountCode = this.view.EntryNo;

                        string[] logItemForTlf = new string[35];
                        logItemForTlf[0] = string.Empty;//GroupNo
                        logItemForTlf[1] = this.view.EntryNo;//EntryNo
                        logItemForTlf[2] = this.cashlist[0].AccountNo;//AcctNo
                        logItemForTlf[3] = string.Empty;
                        logItemForTlf[4] = cashlist[0].Amount.ToString();//LocalAmount
                        logItemForTlf[5] = cashlist[0].SourceCurrency;//SourceCur
                        logItemForTlf[6] = string.Empty;//Cheque
                        logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                        logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                        logItemForTlf[9] = string.Empty;//Status
                        logItemForTlf[10] = entity.SourceBranchCode;//SourceBr
                        logItemForTlf[11] = vouncherNo;//Rno
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
                        TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "Cash Vouncher Reversal Commit Transaction", CurrentUserEntity.BranchCode,
                        logItemForTlf);

                        this.View.Successful(CXMessage.MI30040, accountCode);//Reverse Successfully!
                        this.ClearControls();
                        this.View.EnableDisable(true, false);
                    }
                }
                else
                {
                  
                    this.SetCustomErrorMessage(this.GetControl("mtxtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.EntryNo });
                }
            }

            this.isValidateForm = false;
        }

        #endregion "Main Method"

        #region "Helper Methods"       

        public void mtxtEntryNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false || isSaveValidate == false)
            {
                try
                {
                    eno = this.View.EntryNo;
                    
                    if (string.IsNullOrEmpty(eno))
                    {                        
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90027);
                        
                    }
                    else
                    {
                        cashlist = this.GetAllCashVoucherInfoByEno();   // to get cash voucher information by entry no and trancode
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtEntryNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {

                            string accountno = string.Empty;

                            if (cashlist == null)
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90027);
                            }

                            else
                            {
                                string cashdate = Convert.ToDateTime(cashlist[0].SettlementDate).ToShortDateString();
                                dateInTlf = Convert.ToDateTime(cashlist[0].SettlementDate);
                                string todaydate = DateTime.Now.ToShortDateString();
                                if (cashdate == todaydate)
                                {
                                    accountno = cashlist[0].AccountNo;
                                    Nullable<CXDMD00011> accountType;              //To check accountno in TLF acountno must be exist in COA
                                    if (CXCLE00012.Instance.IsValidAccountNo(accountno, out accountType) && (accountType == CXDMD00011.DomesticAccountType))
                                    {
                                        //to bind Grid View
                                        for (int i = 0; i < cashlist.Count; i++)
                                        {
                                            if (cashlist[i].Status.Substring(1, 1) == "C") cashlist[i].TransactionCode = "Credit";
                                            else if (cashlist[i].Status.Substring(1, 1) == "D") cashlist[i].TransactionCode = "Debit";
                                        }
                                    }
                                    else
                                    {
                                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00175); //Message "Account No. Not Found."
                                    }
                                    this.view.Narration = cashlist[0].Narration;                   // bind narration to UI
                                    this.View.BindCashVoucherGrid(cashlist);                       // bind data to grid view
                                    this.view.EnableDisable(false, true);
                                }

                                else
                                {
                                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("ME30002"); //Not Allowed Back Date Transaction
                                    this.ClearControls();
                                }

                            }

                        }
                }

                    isSaveValidate = true;
                     
                 }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtEntryNo"), ex.Message);
                }
            }
        }

        private PFMDTO00054 GetCashInfoEntity()
        {
            PFMDTO00054 tlfEntity = new PFMDTO00054();

            tlfEntity.Eno = this.View.EntryNo;
            tlfEntity.Narration = this.View.Narration;
            tlfEntity.CashInfoList = this.cashlist;
            tlfEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            tlfEntity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            return tlfEntity;
        }

        public IList<PFMDTO00054> GetAllCashVoucherInfoByEno()
        {
            string Dtype = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashDebitType);
            string Ctype = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashCreditType);
            return CXClientWrapper.Instance.Invoke<IMNMSVE00008, IList<PFMDTO00054>>(x => x.SelectTlfInfoByEntryNoandDateTime(this.view.EntryNo, Dtype, Ctype, this.BranchCode));
           
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
        #endregion "Helper Methods"

      
    }
}