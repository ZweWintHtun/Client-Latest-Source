//----------------------------------------------------------------------
// <copyright file="LOMCTL00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2015-02-03</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using System.Windows.Forms;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00020 : AbstractPresenter, ILOMCTL00020
    {       
        #region "WireTo"
        private ILOMVEW00020 loansinteresteditingView;
        public ILOMVEW00020 LoansInterestEditingView
        {
            get
            {
                return this.loansinteresteditingView;
            }
            set
            {
                this.WireTo(value);
            }
        }
        private void WireTo(ILOMVEW00020 view)
        {
            if (this.loansinteresteditingView == null)
            {
                this.loansinteresteditingView = view;
                this.Initialize(this.loansinteresteditingView, this.GetViewData());
            }
        }
        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }
        #endregion             

        #region "Validation Method"
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            //bool isValidLNo=false;
            TLMDTO00018 LoanDTO=new TLMDTO00018();
            if (e.HasXmlBaseError == true)
            {
                return;
            }
            else
            {
                 LoanDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00020, TLMDTO00018>(x => x.isValidLoanNo(this.LoansInterestEditingView.LoansNo, CurrentUserEntity.BranchCode));
                 
                 if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                 {
                    // string message = CXClientWrapper.Instance.ServiceResult.MessageCode;

                    // if (message == "MV90100") //Invalid Account No {0} for Branch {1}.
                    // {
                        this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                       //  this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90100", new object[] { this.LoansInterestEditingView.LoansNo, CurrentUserEntity.BranchCode }); //Invalid Account No. {0} for Branch {1}. (add by hmw)
                    // }

                    return;

                 }
                 else
                 {
                     this.LoansInterestEditingView.EnableTextBox();
                     this.LoansInterestEditingView.AccountNo = LoanDTO.AccountNo;
                     this.LoansInterestEditingView.SanctionAmount = LoanDTO.SAmount == null ? 0 : LoanDTO.SAmount.Value;
                     this.LoansInterestEditingView.Rate = LoanDTO.IntRate == null ? 0 : LoanDTO.IntRate.Value;
                     this.LoansInterestEditingView.QuarterInterestAmount = LoanDTO.FirstSAmount == null ? 0 : LoanDTO.FirstSAmount.Value;
                     this.LoansInterestEditingView.DisableTextBox();
                     this.LoansInterestEditingView.TextFcus();
                 }
            }
        }
        public void Focus()
        {
            this.LoansInterestEditingView.TextFcus();  
        }
        # endregion

        #region "Private Methods"
        private LOMDTO00021 GetViewData()
        {
            try
            {
                LOMDTO00021 liDTO = new LOMDTO00021();
                liDTO.LNo = this.LoansInterestEditingView.LoansNo;
                liDTO.Acctno = this.LoansInterestEditingView.AccountNo;
                liDTO.PrincipalAmount = this.LoansInterestEditingView.SanctionAmount;
                liDTO.IntRate = this.LoansInterestEditingView.Rate;
                liDTO.InterestAmount = this.LoansInterestEditingView.QuarterInterestAmount;
                liDTO.SourceBr = CurrentUserEntity.BranchCode;
                liDTO.UpdatedDate = DateTime.Now;
                liDTO.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                return liDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException +ex.Message);
            }
        }
        #endregion

        #region "Public Methods"
        public string GetInterestQuarter()
        {
            try
            {
                string budgetquarter = CXCOM00010.Instance.GetBudgetMonth4();
                return budgetquarter;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException + ex.Message);
            }
        }
        public void Update()
        {
            try
            {
                LOMDTO00021 lidto = this.GetViewData();
               
                if (this.ValidateForm(lidto))
                {

                   // CXClientWrapper.Instance.Invoke<ILOMSVE00020, bool>(x => x.Update(lidto.LNo, lidto.SourceBr, lidto.InterestAmount.Value, CurrentUserEntity.CurrentUserID));
                  
                     if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                     {
           
                           this.LoansInterestEditingView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }

                   else if (lidto.Acctno == null || lidto.Acctno == string.Empty )
                   {
                      // CXUIMessageUtilities.ShowMessageByCode("MV90101");
                       this.SetFocus("txtLoanNo");
                      // return;
                   }
                    else if(CXUIMessageUtilities.ShowMessageByCode("MC90005") == DialogResult.Yes)
                    {
                        CXClientWrapper.Instance.Invoke<ILOMSVE00020, bool>(x => x.Update(lidto.LNo, lidto.SourceBr, lidto.InterestAmount.Value, CurrentUserEntity.CurrentUserID));
               
                        this.LoansInterestEditingView.Successful(CXMessage.MI20002);
                       // CXUIMessageUtilities.ShowMessageByCode("MC90005");

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException + ex.Message);
            }
        }
        #endregion
    }    
}
