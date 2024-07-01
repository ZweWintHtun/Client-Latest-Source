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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    /// <summary>
    /// Controller
    /// </summary>
    public class MNMCTL00019 : AbstractPresenter, IMNMCTL00019
    {

        #region "Constructor"

        public MNMCTL00019()
        {
            this.BranchCode = CXCOM00007.Instance.BranchCode;
        }

        #endregion

        #region "Property"

        private string BranchCode { get; set; }
        private bool isValidateForm = false;
        private bool isSaveValidate = false;
       public IList<TLMDTO00001> reList { get; set; }
        public string registerNo = string.Empty;
        public IList<PFMDTO00054> TLFList { get; set; }
        public TLMDTO00001 poEntity { get; set; }

        private IMNMVEW00019 view;
        public IMNMVEW00019 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion "Property"

        #region "WireTo"

        private void WireTo(IMNMVEW00019 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.ViewEntity());
            }
        }

        #endregion WireTo

        #region "UI Logic"

        private TLMDTO00001 ViewEntity()
        {
            TLMDTO00001 poEntity = new TLMDTO00001();
            poEntity.RegisterNo = this.view.RegisterNo;
            return poEntity;
        }

        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }  

        #endregion "UI Logic"

        #region "Main Method"

        public void Save()
        {
            TLMDTO00043 entity = this.GetPoForEncashmentEntity();                                         // Get Input Data
            this.isValidateForm = true;

            if (this.ValidateForm(entity))                                                         // Validation Logic
            {
                // Saving Logic                
                if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes)    //confirm to save
                {
                   // string PoNo = CXClientWrapper.Instance.Invoke<IMNMSVE00019, string>(x => x.Save(entity));          // save to server
                    TLFList = CXClientWrapper.Instance.Invoke<IMNMSVE00019, IList<PFMDTO00054>>(x => x.Save(entity));          // save to server
                    this.view.InitializeControls();
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        for (int i = 0; i < TLFList.Count(); i++)
                        {
                            string[] logItemForTlf = new string[35];
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = this.registerNo;//EntryNo
                            logItemForTlf[2] = TLFList[i].AccountNo;//AcctNo
                            logItemForTlf[3] = TLFList[i].Acode; //Acode
                            logItemForTlf[4] = TLFList[i].Amount.ToString();//LocalAmount
                            logItemForTlf[5] = this.reList[0].Currency;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranch).ToString();//SettlementDate
                            logItemForTlf[9] = TLFList[i].Status;//Status
                            logItemForTlf[10] = reList[0].SourceBranchCode;//SourceBr
                            logItemForTlf[11] = TLFList[i].Eno;//Rno
                            logItemForTlf[12] = string.Empty;//Duration
                            logItemForTlf[13] = string.Empty;//LasintDate
                            logItemForTlf[14] = string.Empty;//intRate
                            logItemForTlf[15] = string.Empty;//Accured
                            logItemForTlf[16] = string.Empty;//BudenAcc
                            logItemForTlf[17] = string.Empty;//Draccured
                            logItemForTlf[18] = string.Empty;//AccuredStatus
                            logItemForTlf[19] = reList[0].ToAccountNo;//ToAccountNo
                            logItemForTlf[20] = string.Empty;//FirstRno
                            logItemForTlf[21] = TLFList[i].PaymentOrderNo;//PoNo
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
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Issue By Encash Fail Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);
                            this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode); 
                        }
                       
                    }
                    else
                    {
                        for (int i = 0; i < TLFList.Count(); i++)
                        {
                            string[] logItemForTlf = new string[35];
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = this.registerNo;//EntryNo
                            logItemForTlf[2] = TLFList[i].AccountNo;//AcctNo
                            logItemForTlf[3] = TLFList[i].Acode; //Acode
                            logItemForTlf[4] = TLFList[i].Amount.ToString();//LocalAmount
                            logItemForTlf[5] = reList[0].Currency;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranch).ToString();//SettlementDate
                            logItemForTlf[9] = TLFList[i].Status;//Status
                            logItemForTlf[10] = reList[0].SourceBranchCode;//SourceBr
                            logItemForTlf[11] = TLFList[i].Eno;//Rno
                            logItemForTlf[12] = string.Empty;//Duration
                            logItemForTlf[13] = string.Empty;//LasintDate
                            logItemForTlf[14] = string.Empty;//intRate
                            logItemForTlf[15] = string.Empty;//Accured
                            logItemForTlf[16] = string.Empty;//BudenAcc
                            logItemForTlf[17] = string.Empty;//Draccured
                            logItemForTlf[18] = string.Empty;//AccuredStatus
                            logItemForTlf[19] = reList[0].ToAccountNo;//ToAccountNo
                            logItemForTlf[20] = string.Empty;//FirstRno
                            logItemForTlf[21] = TLFList[i].PaymentOrderNo;//PoNo
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
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Issue By Encash Commit Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);

                            this.View.Successful(CXMessage.MI00051, TLFList[i].PaymentOrderNo);         //Saving Successful                       
                        }



                    }
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.RegisterNo });
                }
            }

            this.isValidateForm = false;
        }

        #endregion "Main Method"

        #region "Helper Methods"

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void txtRegisterNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false && isSaveValidate == false)
            {
                try
                {
                    registerNo = this.View.RegisterNo;
                    if (string.IsNullOrEmpty(registerNo))
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00167); //Blank Registerno not allowed.
                    }
                    else
                    {                      
                        reList = this.SelectPOinformationByRegisterNo(registerNo);
                        this.SetFocus("txtRegisterNo");
                        this.view.Amount = reList[0].Amount;
                        this.view.Currency = reList[0].Currency;
                        this.view.PoNo = reList[0].ToAccountNo;
                        this.view.Name_forPO = reList[0].Name;
                        this.SetEnableDisable("txtRegisterNo", false);                        
                    }

                    isSaveValidate = true;
                }

                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtRegisterNo"), ex.Message);
                }

            
            }
        }

        public IList<TLMDTO00001> SelectPOinformationByRegisterNo(string registerNo)
        {
            reList = CXClientWrapper.Instance.Invoke<IMNMSVE00019, IList<TLMDTO00001>>(x => x.SelectReInformationByRegisterNo(registerNo, CurrentUserEntity.BranchCode));
           
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.RegisterNo });//Receipt No {0}  has Already Withdrawn.                                            
            }
           
            return reList;
         }

        private TLMDTO00043 GetPoForEncashmentEntity()
        {
            TLMDTO00043 poForEncashment = new TLMDTO00043();
            poForEncashment.Currency = this.view.Currency;
            poForEncashment.Amount = this.view.Amount;
            poForEncashment.SourceBranch = CurrentUserEntity.BranchCode;
            poForEncashment.RegisterNo = this.view.RegisterNo;
            poForEncashment.CreatedUserId = CurrentUserEntity.CurrentUserID;
            poForEncashment.CreatedDate = DateTime.Now;
            poForEncashment.UserNo = Convert.ToString(CurrentUserEntity.CurrentUserID);
            poForEncashment.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            return poForEncashment;
        }


        #endregion "Helper Methods"


    }
}