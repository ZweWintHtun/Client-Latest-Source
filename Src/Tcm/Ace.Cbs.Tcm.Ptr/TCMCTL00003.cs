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
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;

namespace Ace.Cbs.Tcm.Ptr
{
    /// <summary>
    /// PO Issue By Transfer Controller
    /// </summary>
    public class TCMCTL00003 : AbstractPresenter, ITCMCTL00003
    {
        #region "Properties"
        private bool IsLinkTransaction { get; set; }
        private bool IsVIP { get; set; }
        public bool IsAddValidate{get;set;}
        private bool _IsInsufficient { get; set; }       
        private string[] PoNo { get; set; }
        public IList<TLMDTO00043> POIssueList { get; set; }
        public TLMDTO00043 POIssue;
        

        private ITCMVEW00003 view;
        public ITCMVEW00003 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITCMVEW00003 poissuebytransferview)
        {
            if (this.view == null)
            {
                this.view = poissuebytransferview;
               this.Initialize(this.view, this.GetViewData());
            }
        }
        #endregion

        #region "Methods"
        public void FormCleaning()
        {         
            this.view.ViewDataList = new List<TLMDTO00043>();
            this.view.TempData = new TLMDTO00043();
            this.view.BindTempDataListToGridview();
            this.view.AccountNo = string.Empty;            
            this.view.Currency = string.Empty;
            this.view.ChequeNo = string.Empty;
            this.view.Charges = 0;  
            this.view.POAmount = 0;
            this.view.TotalAmount = 0;
            this.ClearAllCustomErrorMessage();
        }

        public TLMDTO00043 BindDataToTemp()
        {
            this.view.TempData = new TLMDTO00043();
            this.view.TempData.Amount = this.view.POAmount;
            this.view.TempData.Charges = this.view.Charges;

            return this.view.TempData;
        }

        public TLMDTO00043 GetViewData()
        {
            TLMDTO00043 poEntity = new TLMDTO00043();
            poEntity.AccountNo = this.view.AccountNo;
            poEntity.Amount = this.view.POAmount;
            poEntity.AccountSign = this.view.ACSign;
            poEntity.CheckNo = this.view.ChequeNo;
            poEntity.Charges = this.view.Charges;            
            poEntity.Currency = this.view.Currency;
            poEntity.AdjustmentAmount = this.view.TotalAmount;
            poEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            poEntity.SourceBranch = CurrentUserEntity.BranchCode;           
            return poEntity;
        }

        public bool AddPOIssue()
        {
            TLMDTO00043 poIssueEntity = this.GetViewData();
            poIssueEntity.Description = this.GetDescriptionByAccountNo(this.view.AccountNo);

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
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Issue(ByTransfer) Fail Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);
                }
                this.view.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            #endregion

            #region Successful
            else
            {
                #region Print Line
                if (this.view.PODTO.AcSign.StartsWith(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.SavingAccountSign)))
                {
                    PFMDTO00043 PrintDTO = new PFMDTO00043();
                    PrintDTO.AccountNo = this.view.PODTO.AccountNo;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { this.view.AccountNo });
                    CXUIScreenTransit.Transit("frmPFMVEW00009", true, new object[] { this.View.GetMenuIDPermission(), PrintDTO, this.View.PODTO.AcSign, false });
                }
                #endregion
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
                    TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "PO Issue(ByTransfer) Commit Transaction", CurrentUserEntity.BranchCode,
                    logItemForTlf);
                }
                if (this.View.ViewDataList.Count > 1)
                {
                    for (int i = 0; i < this.View.ViewDataList.Count; i++)
                    {
                        this.View.ViewDataList[i].PONo = PoNo[i];
                    }
                    this.BindPONotoGridView();
                    this.View.Successful("MI00032");
                    this.FormCleaning();
                    
                }
                else
                {
                    this.View.ViewDataList[0].PONo = PoNo[0];
                    this.BindPONotoGridView();
                    this.View.PODTO.PONo = PoNo[0];
                    //this.View.ChangeControlName(true);
                    this.View.Successful("MI30043");                   
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
                  Nullable<CXDMD00011> accountType;
                  if (CXCLE00012.Instance.IsValidAccountNo(this.view.AccountNo, out accountType) && (accountType == CXDMD00011.AccountNoType2 || accountType == CXDMD00011.DomesticAccountType))
                  {
                      if (this.view.AccountNo.Substring(0, 3) == CurrentUserEntity.BranchCode)
                      {
                          //if (this.view.AccountNo.Substring(4, 1) == "2")
                          //{
                              
                          //}
                              string workstation = CurrentUserEntity.WorkStationId.ToString();
                              this.view.PODTO = CXClientWrapper.Instance.Invoke<ITCMSVE00003, TLMDTO00016>(x => x.CheckAccountNo(this.view.AccountNo, this.view.IsVIP, this.view.isWithIncome, workstation, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
                              if (this.view.PODTO == null)
                              {
                                  this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                              }
                              else
                              {
                                  this.view.Currency = this.view.PODTO.Currency;
                                  this.view.ACSign = this.view.PODTO.AcSign;
                                  if (this.view.ACSign == "S")
                                  {
                                      this.view.DisableChequeNo();
                                  }
                              }
                         

                      }
                      else
                      {
                          this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00091, new object[] { this.view.AccountNo , CurrentUserEntity.BranchCode });

                      }                     
                  }
                  else
                  {
                      this.View.InitializeControls();
                  }
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
                        bool result = CXClientWrapper.Instance.Invoke<ITCMSVE00003, bool>(x => x.CheckingChequeNo(this.view.AccountNo, this.view.ChequeNo, branch));

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
            if (e.HasXmlBaseError  || this.IsAddValidate)
            {
            
                return;
            }
            else
            {
                    decimal charges = CXCLE00010.Instance.CalculatePOrate(this.view.POAmount, this.view.Currency);
                    if (charges != 0)
                    {
                        this.view.PODTO.Rate = charges;
                        this.view.Charges = (this.view.Texts == "P.O Issue By Transfer (Income)") ? this.view.PODTO.Rate.Value : 0;
                        this.view.TotalAmount = this.view.Charges + this.view.POAmount;
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtPoAmount"), "ME00036"); //PO rate not found.
                        return;
                    }
            }            
        }

        public bool[] CheckChequeNoAndAmount(string accountNo, string chequeNo, decimal amount, bool isMinBalCheck, bool isVIP, bool isDebit)
        {
            bool[] check = { false, false };
            CXDTO00009 IsValid = CXClientWrapper.Instance.Invoke<ITCMSVE00003, CXDTO00009>(service => service.CheckChequeNoAndAmount(accountNo, chequeNo, amount, true, true, isDebit, CurrentUserEntity.BranchCode));
            if (!String.IsNullOrEmpty(IsValid.MessageCode))
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(IsValid.MessageCode);
                //this._IsInsufficient = true;
                check[0] = true;
                if (IsValid.MessageCode == "MV00109")
                {
                    this.View.ChequeNo = this.View.ChequeNo;
                    check[1] = false;
                }
                else
                {
                    this.View.ChequeNo = string.Empty;
                    check[1] = true;
                }
                return check;
            }
            else
                check[0] = IsValid.IsLink;
            return check;
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

        public string GetDescriptionByAccountNo(string accountNo)
        {
            string customerDescription = string.Empty;
            customerDescription=  CXClientWrapper.Instance.Invoke<ITCMSVE00003, string>(x => x.GetDescriptionByAccountNo(accountNo));
            return customerDescription; 
        }
    }
}
