//----------------------------------------------------------------------
// <copyright file="TCMCTL00003.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
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
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    /// <summary>
    /// PO Issue By Transfer Controller
    /// </summary>
    public class MNMCTL00020 : AbstractPresenter, IMNMCTL00020
    {
        #region "Properties"

        private bool IsLinkTransaction { get; set; }
        private bool IsVIP { get; set; }
        private bool _IsInsufficient { get; set; }
        private string[] PoNo { get; set; }
        public IList<TLMDTO00043> POIssueList { get; set; }
        public TLMDTO00016 poDto { get; set; }
        public TLMDTO00043 POIssue;
        private bool isValidate = false;
        public string acsign { get; set; }

        private IMNMVEW00020 view;
        public IMNMVEW00020 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00020 poissuebytransferview)
        {
            if (this.view == null)
            {
                this.view = poissuebytransferview;
                this.Initialize(this.view, this.GetEntity());
            }
        }
        #endregion

        #region "Methods"

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void FormCleaning()
        {
            this.view.ViewDataList = new List<TLMDTO00043>();
            this.view.TempData = new TLMDTO00043();
            this.view.BindTempDataListToGridview();
            this.view.AccountNo = string.Empty;
            this.view.PaymentOrderNo = string.Empty;
            this.view.Currency = string.Empty;
            this.view.ChequeNo = string.Empty;
            this.view.Charges = 0;
            this.view.POAmount = 0;
            this.view.TotalAmount = 0;
            this.ClearAllCustomErrorMessage();
            this.isValidate = false;
        }

        public TLMDTO00043 BindDataToTemp()
        {
            this.view.TempData = new TLMDTO00043();
            this.view.TempData.Amount = this.view.POAmount;
            this.view.TempData.Charges = this.view.Charges;

            return this.view.TempData;
        }

        public TLMDTO00043 GetEntity()
        {
            TLMDTO00043 poEntity = new TLMDTO00043();
            poEntity.AccountNo = this.view.AccountNo;
            poEntity.PONo = this.view.PaymentOrderNo;
            poEntity.Amount = this.view.POAmount;
            poEntity.AccountSign = this.view.ACSign;
            poEntity.CheckNo = this.view.ChequeNo;
            poEntity.Charges = this.view.Charges;
            poEntity.Currency = this.view.Currency;
            poEntity.AdjustmentAmount = this.view.TotalAmount;
            poEntity.SourceBranch = CurrentUserEntity.BranchCode;
            poEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            return poEntity;
        }

        private void CheckPaymentOrderNo()
        {
            if(isValidate == false)
            {
            
                if (string.IsNullOrEmpty(this.view.PaymentOrderNo))
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00219); //PO No. Not Found.
            
                if (this.view.ViewDataList.Count > 0)
                {
                    var duplicateRecord = this.view.ViewDataList.Where(x => x.PONo == this.view.PaymentOrderNo).ToList<TLMDTO00043>();
                   if (duplicateRecord.Count() > 0)
                   {
                    //This P.O No. {0} is already exist in this grid.
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00150, new object[] { this.view.PaymentOrderNo });
                    this.SetFocus("mtxtPaymentOrderNo");
                    return;
                   }

                }
                bool flag = false;
                IList<TLMDTO00016> poInfoList = CXClientWrapper.Instance.Invoke<ITCMSVE00003, IList<TLMDTO00016>>(x => x.CheckForPO(this.view.AccountNo, CurrentUserEntity.BranchCode));
                if(poInfoList.Count > 0)
                {
                    foreach (TLMDTO00016 poinfo in poInfoList)
                    {
                        if (poinfo.PONo == this.view.PaymentOrderNo)
                        {
                            if (poinfo.Budget != this.view.BudgetYear)
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00104); //Invalid Budget For this PO.
                                this.SetFocus("mtxtPaymentOrderNo");
                                return;
                             
                            }
                            else if (!string.IsNullOrEmpty(poinfo.IDate.ToString()))
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00143, new object[] { this.view.PaymentOrderNo }); //This P.O No. {0}  is already received.
                                this.SetFocus("mtxtPaymentOrderNo");
                                return;
                              
                            }
                            else if (poinfo.Currency != this.view.Currency)
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00151, new object[] { this.view.Currency }); //The currency of this P.O No. is not {0}.
                                this.SetFocus("mtxtPaymentOrderNo");
                                return;

                            }
                            else
                            {
                                this.view.POAmount = poinfo.Amount;
                                this.view.Charges = Convert.ToDecimal(poinfo.Charges);
                                if (acsign != "S")
                                {
                                    this.SetEnableDisable("txtChequeNo", true);
                                    this.SetFocus("txtChequeNo");
                                }
                                this.SetEnableDisable("txtAmount", true);
                                flag = true;
                            }
                        }
                    }

                    if (!flag)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00219); //PO No. Not Found.
                        this.SetFocus("mtxtPaymentOrderNo");
                    }                    
                }
                else
                {
                     Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00219); //PO No. Not Found.
                     this.SetFocus("mtxtPaymentOrderNo");
                }
            }       
                                      
        }
       
        public bool AddPOIssue()
        {
            TLMDTO00043 poIssueEntity = this.GetEntity();
            string accountDescription = CXClientWrapper.Instance.Invoke<IMNMSVE00020, string>(x => x.GetDescriptionByAccountNo(this.view.AccountNo));
            poIssueEntity.Description = accountDescription;
            if (this.ValidateForm(poIssueEntity))
            {
                this.View.ViewDataList.Add(poIssueEntity);
                return true;
            }
            else
                return false;
        }

        public decimal CalculateNetAmount()
        {
            decimal netAmount = 0;
            for (int i = 0; i < this.view.ViewDataList.Count; i++)
                netAmount += (view.ViewDataList[i].Amount + view.ViewDataList[i].Charges);
            return netAmount;
        }

        private void BindPONotoGridView()
        {
            for (int i = 0; i < this.View.ViewDataList.Count; i++)
            {
                this.View.ViewDataList[i].PONo = this.PoNo[i];
            }
            this.View.BindTempDataListToGridview();
        }

        public void SavePOIssueTransfer(IList<TLMDTO00043> POIssueLists)
        {
            CXClientWrapper.Instance.Invoke<IMNMSVE00020>(x => x.DeleteOldPONoByActive(POIssueLists, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
           this.PoNo = CXClientWrapper.Instance.Invoke<ITCMSVE00003, string[]>(x => x.SavePOIssueEntry(this.View.ViewDataList));
           #region ErrorOccurred
           if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                string[] logItemForTlf = new string[35];
                for (int i = 0; i < this.View.ViewDataList.Count; i++)
                {
                    //ClientLog For Tlf
                    logItemForTlf[0] = string.Empty;//GroupNo
                    logItemForTlf[1] = PoNo[this.View.ViewDataList.Count + i];//EntryNo
                    logItemForTlf[2] = this.View.ViewDataList[i].AccountNo;//AcctNo
                    logItemForTlf[3] = string.Empty;//ACode(from COASetUp)
                    logItemForTlf[4] = this.View.ViewDataList[i].AdjustmentAmount.ToString();//LocalAmount
                    logItemForTlf[5] = this.View.ViewDataList[i].Currency;//SourceCur
                    logItemForTlf[6] = this.View.ViewDataList[i].CheckNo;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.ViewDataList[i].SourceBranch).ToString();//SettlementDate
                    logItemForTlf[9] = string.Empty;//Status
                    logItemForTlf[10] = this.View.ViewDataList[i].SourceBranch;//SourceBr
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
                    logItemForTlf[21] = PoNo[i];//PoNo
                    logItemForTlf[22] = System.DateTime.Now.ToString();//ADate
                    logItemForTlf[23] = string.Empty;//IDate
                    logItemForTlf[24] = string.Empty;//ToAcctNo
                    logItemForTlf[25] = this.View.ViewDataList[i].Charges.ToString();//Income
                    logItemForTlf[26] = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode).ToString();//Budget
                    logItemForTlf[27] = string.Empty;//FromBranch
                    logItemForTlf[28] = string.Empty;//ToBranch
                    logItemForTlf[29] = string.Empty;//Inout
                    logItemForTlf[30] = string.Empty;//Success
                    logItemForTlf[31] = string.Empty;//COMMUCHARGE
                    logItemForTlf[32] = string.Empty;//IncomeType
                    logItemForTlf[33] = string.Empty;//OtherBank
                    logItemForTlf[34] = string.Empty;//OtherBankChq
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Edit(Issue ByTransfer) Fail Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);
                }
                this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
           #endregion

           #region Successful
           else
            {
                if (this.view.PODTO.AcSign.StartsWith(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign)))
                {
                    PFMDTO00043 PrintDTO = new PFMDTO00043();
                    PrintDTO.AccountNo = this.view.PODTO.AccountNo;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { this.view.AccountNo });
                    CXUIScreenTransit.Transit("frmPFMVEW00009", true, new object[] { this.View.GetMenuIDPermission(), PrintDTO, this.View.PODTO.AcSign, false });
                }
                string[] logItemForTlf = new string[35];
                for (int i = 0; i < this.View.ViewDataList.Count; i++)
                {
                    //ClientLog For Tlf
                    logItemForTlf[0] = string.Empty;//GroupNo
                    logItemForTlf[1] = PoNo[this.View.ViewDataList.Count + i];//EntryNo
                    logItemForTlf[2] = this.View.ViewDataList[i].AccountNo;//AcctNo
                    logItemForTlf[3] = string.Empty;//ACode(from COASetUp)
                    logItemForTlf[4] = this.View.ViewDataList[i].AdjustmentAmount.ToString();//LocalAmount
                    logItemForTlf[5] = this.View.ViewDataList[i].Currency;//SourceCur
                    logItemForTlf[6] = this.View.ViewDataList[i].CheckNo;//Cheque
                    logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                    logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.ViewDataList[i].SourceBranch).ToString();//SettlementDate
                    logItemForTlf[9] = string.Empty;//Status
                    logItemForTlf[10] = this.View.ViewDataList[i].SourceBranch;//SourceBr
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
                    logItemForTlf[21] = PoNo[i];//PoNo
                    logItemForTlf[22] = System.DateTime.Now.ToString();//ADate
                    logItemForTlf[23] = string.Empty;//IDate
                    logItemForTlf[24] = string.Empty;//ToAcctNo
                    logItemForTlf[25] = this.View.ViewDataList[i].Charges.ToString();//Income
                    logItemForTlf[26] = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode).ToString();//Budget
                    logItemForTlf[27] = string.Empty;//FromBranch
                    logItemForTlf[28] = string.Empty;//ToBranch
                    logItemForTlf[29] = string.Empty;//Inout
                    logItemForTlf[30] = string.Empty;//Success
                    logItemForTlf[31] = string.Empty;//COMMUCHARGE
                    logItemForTlf[32] = string.Empty;//IncomeType
                    logItemForTlf[33] = string.Empty;//OtherBank
                    logItemForTlf[34] = string.Empty;//OtherBankChq
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Edit(Issue ByTransfer) Commit Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);
                }
                if (this.View.ViewDataList.Count > 1)
                {
                    for (int i = 0; i < this.View.ViewDataList.Count; i++)
                    {
                        this.View.ViewDataList[i].PONo = PoNo[i];
                    }
                    this.BindPONotoGridView();
                    this.View.Successful(CXMessage.MI90001);
                    this.FormCleaning();
                }
                else
                {
                    this.View.ViewDataList[0].PONo = PoNo[0];
                    this.BindPONotoGridView();
                    this.View.PODTO.PONo = PoNo[0];
                    this.View.Successful(CXMessage.MI90001);
                    this.FormCleaning();
                }
            }
           #endregion
           this.ClearErrors();
        }

        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }
        #endregion

        #region "CustomValidating"

        public void mtxtAccountNo_CustomValiding(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            else
            {
                if (string.IsNullOrEmpty(this.view.AccountNo))
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);//Invalid Account No.
                    this.SetFocus("mtxtAccountNo");
                }
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType2 || accountType == CXDMD00011.DomesticAccountType))
                {
                    if (this.view.AccountNo.Substring(0, 3) == CurrentUserEntity.BranchCode)
                    {
                        string workstation = CurrentUserEntity.WorkStationId.ToString();
                        this.view.PODTO = CXClientWrapper.Instance.Invoke<ITCMSVE00003, TLMDTO00016>(x => x.CheckAccountNo(this.view.AccountNo, this.view.IsVIPCustomer, this.view.isWithIncome,workstation,CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode));
                        if (this.view.PODTO == null)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                            this.view.Currency = this.view.PODTO.Currency;
                            acsign = this.view.ACSign = this.view.PODTO.AcSign;
                            if (this.view.ACSign == "S")
                            {
                                this.view.DisableChequeNo();                             
                            }                            

                            this.SetEnableDisable("mtxtPaymentOrderNo", true);
                            this.SetFocus("mtxtPaymentOrderNo");                          
                        }

                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { CurrentUserEntity.BranchCode });

                    }
                }
                else
                {
                    this.View.InitializeControls();
                }
            }

        }

        public void mtxtPaymentOrderNo_CustomValiding(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            else
            {
                //POTextBoxFormat
                if (!this.View.PaymentOrderNo.Length.Equals(Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POFromat))))
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtPaymentOrderNo"), "MV00103");
                    return;
                }
              
                this.CheckPaymentOrderNo();
               
            }

        }

        public void txtChequeNo_CustomValiding(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            else
            {
                this.view.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
                if (this.view.ACSign == "C")
                {
                    if (this.view.ChequeNo == string.Empty)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), CXMessage.MV00059);
                        return;
                    }
                    else
                    {
                        string branch = this.view.AccountNo.Substring(0, 3).Trim();
                        bool result = CXClientWrapper.Instance.Invoke<IMNMSVE00020, bool>(x => x.CheckingChequeNo(this.view.AccountNo, this.view.ChequeNo, branch));
                            
                        if (result == false)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                            return;
                        }                          

                    }
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), string.Empty);
                }               

            }
        }

        public void txtPoAmount_CustomValiding(object sender, ValidationEventArgs e)
        {

            if (e.HasXmlBaseError)
            {

                return;
            }
            else
            {
                decimal charges = CXCLE00010.Instance.CalculatePOrate(this.view.POAmount, this.view.Currency);
                if (charges != 0)
                {
                    this.view.PODTO.Rate = charges;
                    this.view.Charges = (!this.view.Texts.Contains("No")) ? this.view.PODTO.Rate.Value : 0;
                    this.view.TotalAmount = this.view.Charges + this.view.POAmount;
                }
                else
                    this.SetCustomErrorMessage(this.GetControl("txtAmount"), CXMessage.ME00036);
                return;
            }
        }

        public bool CheckChequeNoAndAmount(string accountNo, string chequeNo, decimal amount, bool isMinBalCheck, bool isVIP, bool isDebit)
        {
            CXDTO00009 IsValid = CXClientWrapper.Instance.Invoke<ITCMSVE00003, CXDTO00009>(service => service.CheckChequeNoAndAmount(accountNo, chequeNo, amount, true, true, isDebit, CurrentUserEntity.BranchCode));
            if (!String.IsNullOrEmpty(IsValid.MessageCode))
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(IsValid.MessageCode);
                this._IsInsufficient = true;
                this.View.ChequeNo = string.Empty;
                return this._IsInsufficient;
            }
            else
                this.IsLinkTransaction = IsValid.IsLink;
            return this.IsLinkTransaction;
        }

        public void txtCharges_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            else
            {
                this.view.TotalAmount = this.view.POAmount + this.view.Charges;
            }
        }
        #endregion

      
    }
}
