//----------------------------------------------------------------------
// <copyright file="LOMCTL00021.cs" company="ACE Data Systems">
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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00021 : AbstractPresenter, ILOMCTL00021
    {
        #region "Variable"
        private bool isSave = false;
        #endregion

        #region "WireTo"
        private ILOMVEW00021 legalprocesseditingView;
        public ILOMVEW00021 LegalProcessEditingView
        {
            get
            {
                return this.legalprocesseditingView;
            }
            set
            {
                this.WireTo(value);
            }
        }
        private void WireTo(ILOMVEW00021 view)
        {
            if (this.legalprocesseditingView == null)
            {
                this.legalprocesseditingView = view;
                this.Initialize(this.legalprocesseditingView, this.GetViewData());
            }
        }
        #endregion

        #region Validation
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            try
            {
                TLMDTO00018 LoanDTO = new TLMDTO00018();
                if (e.HasXmlBaseError == true)
                {
                    return;
                }
                else
                {
                    LOMDTO00013 LegalDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00021, LOMDTO00013>(x => x.SelectLegalInfoByLoanNo(this.LegalProcessEditingView.LoansNo, CurrentUserEntity.BranchCode));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        this.SetFocus("txtLoanNo");
                    }
                    else
                    {
                        this.LegalProcessEditingView.GetTitle();
                        this.LegalProcessEditingView.AccountNo = LegalDTO.AcctNo;
                        this.LegalProcessEditingView.LedgerBalance = LegalDTO.Bal.Value;
                        this.LegalProcessEditingView.AdvanceType = LegalDTO.AcType;
                        this.LegalProcessEditingView.SanctionAmount = LegalDTO.SAmt == null ? 0 : LegalDTO.SAmt.Value;
                        if (!isSave)
                        {
                            this.LegalProcessEditingView.InterestRate = LegalDTO.IntRate == null ? 0 : LegalDTO.IntRate.Value;
                        }
                        this.LegalProcessEditingView.Interest = LegalDTO.Interest == null ? 0 : LegalDTO.Interest.Value;
                        this.LegalProcessEditingView.ServiceCharges = LegalDTO.OldScharge == null ? 0 : LegalDTO.OldScharge.Value;
                        this.LegalProcessEditingView.ExtraCharges = LegalDTO.OldExtra == null ? 0 : LegalDTO.OldExtra.Value;
                        this.LegalProcessEditingView.LegalCaseLawyer = LegalDTO.LegalLawyer;
                        this.LegalProcessEditingView.EnableInfo(true);
                        this.LegalProcessEditingView.DiableControls();
                    }
                    //else
                    //{
                    //    this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), CXMessage.MV90055);
                    //}
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException + ex.Message);
            }
        }
        #endregion

        #region "Private Method"
        private LOMDTO00013 GetViewData()
        {
            try
            {
                LOMDTO00013 LegalDTO = new LOMDTO00013();
                LegalDTO.Lno = this.LegalProcessEditingView.LoansNo;
                LegalDTO.AcctNo = this.LegalProcessEditingView.AccountNo;
                LegalDTO.Bal = this.LegalProcessEditingView.LedgerBalance;
                LegalDTO.IntRate = this.LegalProcessEditingView.InterestRate;
                LegalDTO.LegalCase = this.LegalProcessEditingView.LgSCase;
                LegalDTO.LegalLawyer = this.LegalProcessEditingView.LegalCaseLawyer;
                return LegalDTO;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException+ex.Message);
            }
        }
        #endregion

        #region "Public Method"
        public void Save()
        {
            try
            {
                isSave = true;
                LOMDTO00013 lgdto = this.GetViewData();
                if (this.ValidateForm(lgdto))
                {
                    CXClientWrapper.Instance.Invoke<ILOMSVE00021, bool>(x => x.Update(lgdto.Lno, CurrentUserEntity.BranchCode, lgdto.IntRate.Value, lgdto.LegalLawyer, CurrentUserEntity.CurrentUserID));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                    {
                        this.LegalProcessEditingView.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.LegalProcessEditingView.Successful(CXMessage.MI20002);
                        isSave = false;
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
