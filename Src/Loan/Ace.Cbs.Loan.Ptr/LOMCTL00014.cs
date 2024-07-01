//----------------------------------------------------------------------
// <copyright file="LOMCTL00014" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>ASDA</CreatedUser>
// <CreatedDate>13.01.2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00014 : AbstractPresenter, ILOMCTL00014
    {
        #region "Wire To"
        private ILOMVEW00014 view;
        public ILOMVEW00014 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00014 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }        

        private TLMDTO00018 GetEntity()
        {
            TLMDTO00018 LoanEntity = new TLMDTO00018();
            LoanEntity.Lno = this.view.LoanNo;
            return LoanEntity;
        }
        #endregion

        #region MainMethod
        public void Save()   
        {
            if (!this.ValidateForm(GetEntity()))
                return;
            else
            {
                CXClientWrapper.Instance.Invoke<ILOMSVE00014, bool>(x => x.UpdateLoansForNPLCase(this.View.LoanNo, CurrentUserEntity.CurrentUserName, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == true)
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);  //Saving Successful
            }
        }
        #endregion

        #region validation
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    TLMDTO00018 LoanDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00014, TLMDTO00018>(x => x.isValidLoanNo(this.View.LoanNo, CurrentUserEntity.BranchCode));

                    if (LoanDTO == null || CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXMessage.MV90055);  //Invalid Loan No.
                        return;
                    }
                    else
                    {
                        if (LoanDTO.NPLCase == true)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXMessage.MV90064); //NPL Case Is Already Exist.
                            return;
                        }
                        else if (!string.IsNullOrEmpty(LoanDTO.CloseDate.ToString()))
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXMessage.MV90057); //Loans No. Already Closed!
                            return;
                        }
                        else
                        {
                            this.view.AccountNo = LoanDTO.AccountNo;
                            this.view.AdvanceType = LoanDTO.AType;
                            this.view.SanctionAmount = LoanDTO.SAmount == null ? 0 : LoanDTO.SAmount.Value ;
                            this.view.IntRateUsed = LoanDTO.IntRate == null ? 0 : LoanDTO.IntRate.Value ;
                            this.view.IntRateUnused = LoanDTO.UnUsedRate == null ? 0 : LoanDTO.UnUsedRate.Value ;
                            this.view.SetFocus();                            
                        }
                    }
                    //this.SetFocus("txtLoanNo");
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Entry No.
                }
            }
            else
            { return; }
        }
        #endregion
    }
}
