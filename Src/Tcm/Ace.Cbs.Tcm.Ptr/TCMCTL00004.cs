//----------------------------------------------------------------------
// <copyright file="TCMCTL00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khaing Su Wai</CreatedUser>
// <CreatedDate>12/09/2013</CreatedDate>
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
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;


namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00004 : AbstractPresenter, ITCMCTL00004
    {
        private ITCMVEW00004 view;
        public ITCMVEW00004 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00004 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetPoForEncashmentEntity());
            }
        }
        #region Variable

        private string[] PONo { get; set; }
        public TLMDTO00001 RE_Info { get; set; }
        #endregion

        #region UI Logic

        public void ClearControls()
        {
            this.ClearTextBox();
            this.View.RegisterNo = string.Empty;
            //this.View.Currency = string.Empty;
            this.View.Amount = 0;
            this.View.BudgetYear = string.Empty ;
            this.View.Name = string.Empty;
            this.View.PONo = string.Empty;
            this.ClearAllCustomErrorMessage();
        }
        public void ClearTextBox()
        {
            this.View.BudgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);           
        }
        public void Save()
        {
              TLMDTO00043 poIssueEncash = this.GetPoForEncashmentEntity();
              if (this.ValidateForm(poIssueEncash))
              {

                  poIssueEncash.CoaSetupAccountNo1 = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "IBSIR", poIssueEncash.Currency, poIssueEncash.SourceBranch, true });
                  poIssueEncash.COAACName1 = CXCLE00001.Instance.GetCOAAccountNameByCoaSetupAccountNo(poIssueEncash.CoaSetupAccountNo1, poIssueEncash.SourceBranch);
                  poIssueEncash.CoaSetupAccountNo2 = CXCOM00011.Instance.GetScalarObject<string>("COASetup.Server.Select", new object[] { "POR", poIssueEncash.Currency, poIssueEncash.SourceBranch, true });
                  poIssueEncash.COAACName2 = CXCLE00001.Instance.GetCOAAccountNameByCoaSetupAccountNo(poIssueEncash.CoaSetupAccountNo2, poIssueEncash.SourceBranch);

                PONo = CXClientWrapper.Instance.Invoke<ITCMSVE00004, string []>(x => x.Save(poIssueEncash));
                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    string[] logItemForTlf = new string[35];
                    //ClientLog For Tlf
                    logItemForTlf[0] = string.Empty;//GroupNo
                    logItemForTlf[1] = PONo[1];//EntryNo
                    logItemForTlf[2] = poIssueEncash.CoaSetupAccountNo2;//AcctNo
                    logItemForTlf[3] = poIssueEncash.CoaSetupAccountNo2;//ACode(from COASetUp)
                    logItemForTlf[4] = poIssueEncash.Amount.ToString();//LocalAmount
                    logItemForTlf[5] = poIssueEncash.Currency;//SourceCur
                    logItemForTlf[6] = string.Empty;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), poIssueEncash.SourceBranch).ToString();//SettlementDate
                    logItemForTlf[9] = string.Empty;//Status
                    logItemForTlf[10] = poIssueEncash.SourceBranch;//SourceBr
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
                    logItemForTlf[21] = PONo[0];//PoNo
                    logItemForTlf[22] = System.DateTime.Now.ToString();//ADate
                    logItemForTlf[23] = string.Empty;//IDate
                    logItemForTlf[24] = string.Empty;//ToAcctNo
                    logItemForTlf[25] = string.Empty;//Income
                    logItemForTlf[26] = poIssueEncash.Budget;//Budget
                    logItemForTlf[27] = string.Empty;//FromBranch
                    logItemForTlf[28] = string.Empty;//ToBranch
                    logItemForTlf[29] = string.Empty;//Inout
                    logItemForTlf[30] = string.Empty;//Success
                    logItemForTlf[31] = string.Empty;//COMMUCHARGE
                    logItemForTlf[32] = string.Empty;//IncomeType
                    logItemForTlf[33] = string.Empty;//OtherBank
                    logItemForTlf[34] = string.Empty;//OtherBankChq
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Issue(ForEncashment) Fail Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);

                    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion

                #region Successful
                else
                {
                    string[] logItemForTlf = new string[35];
                    //ClientLog For Tlf
                    logItemForTlf[0] = string.Empty;//GroupNo
                    logItemForTlf[1] = PONo[1];//EntryNo
                    logItemForTlf[2] = poIssueEncash.CoaSetupAccountNo2;//AcctNo
                    logItemForTlf[3] = poIssueEncash.CoaSetupAccountNo2;//ACode(from COASetUp)
                    logItemForTlf[4] = poIssueEncash.Amount.ToString();//LocalAmount
                    logItemForTlf[5] = poIssueEncash.Currency;//SourceCur
                    logItemForTlf[6] = string.Empty;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), poIssueEncash.SourceBranch).ToString();//SettlementDate
                    logItemForTlf[9] = string.Empty;//Status
                    logItemForTlf[10] = poIssueEncash.SourceBranch;//SourceBr
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
                    logItemForTlf[21] = PONo[0];//PoNo
                    logItemForTlf[22] = System.DateTime.Now.ToString();//ADate
                    logItemForTlf[23] = string.Empty;//IDate
                    logItemForTlf[24] = string.Empty;//ToAcctNo
                    logItemForTlf[25] = string.Empty;//Income
                    logItemForTlf[26] = poIssueEncash.Budget;//Budget
                    logItemForTlf[27] = string.Empty;//FromBranch
                    logItemForTlf[28] = string.Empty;//ToBranch
                    logItemForTlf[29] = string.Empty;//Inout
                    logItemForTlf[30] = string.Empty;//Success
                    logItemForTlf[31] = string.Empty;//COMMUCHARGE
                    logItemForTlf[32] = string.Empty;//IncomeType
                    logItemForTlf[33] = string.Empty;//OtherBank
                    logItemForTlf[34] = string.Empty;//OtherBankChq
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Issue(ForEncashment) Commit Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);
                    View.PONo = PONo[0];
                    this.View.Successful(CXMessage.MI90001);
                }
                #endregion
              }





        }

        #endregion

        #region Helper Methods
        private TLMDTO00043 GetPoForEncashmentEntity()
        {
            TLMDTO00043 poForEncashment = new TLMDTO00043();
            poForEncashment.Currency = this.view.Currency;
            poForEncashment.Amount = this.view.Amount;
            poForEncashment.SourceBranch = this.view.SourceBranchCode;
            poForEncashment.RegisterNo = this.view.RegisterNo;
            poForEncashment.CreatedUserId = CurrentUserEntity.CurrentUserID;
            poForEncashment.CreatedDate = DateTime.Now;
            poForEncashment.UserNo = Convert.ToString(CurrentUserEntity.CurrentUserID);
            poForEncashment.Budget = this.view.BudgetYear;
            return poForEncashment;
        }
        #endregion

        #region Validation
        public void txtRegisterNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                if (String.IsNullOrEmpty(this.View.RegisterNo))
                {
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo"), "MV00168");
                    return;
                }
                
                    TLMDTO00001 reDTO = CXClientWrapper.Instance.Invoke<ITCMSVE00004, TLMDTO00001>(x => x.GetREInfoByRegisterNo(this.View.RegisterNo));
                    this.RE_Info = reDTO;
                    //string issueDate = reDTO.IssueDate.ToString();
            
             
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                   
                }
                else if (reDTO == null)
                {
                    this.View.Failure(CXMessage.MV00218);//Invalid RegisterNo.
                    this.View.SetFocusOnRegisterNo();
                }
                //else if (reDTO.IssueDate != null)
                else if (!string.IsNullOrEmpty(reDTO.IssueDate.ToString()))
                {
                    this.View.Failure(CXMessage.MV00217, this.View.RegisterNo);//This Register No. {0} is already received.
                    this.View.SetFocusOnRegisterNo();

                }
                //else if (reDTO.ToAccountNo != null)
                else if (!string.IsNullOrEmpty(reDTO.ToAccountNo))
                {
                    this.View.Failure(CXMessage.MV00218);//Invalid RegisterNo.
                    this.View.SetFocusOnRegisterNo();

                }
                else
                {

                    this.View.Name = reDTO.Name;
                    this.View.Currency = reDTO.Currency;
                    this.View.Amount = reDTO.Amount;
                }
                
                   
            }
        }
        #endregion 
    }
}
