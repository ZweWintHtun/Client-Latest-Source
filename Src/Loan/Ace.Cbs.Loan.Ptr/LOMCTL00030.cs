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
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Cle;


namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00030 : AbstractPresenter, ILOMCTL00030
    {
        #region "Wire To"
        private ILOMVEW00030 view;
        public ILOMVEW00030 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00030 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        private LOMDTO00025 GetEntity()
        {
            LOMDTO00025 LoanEntity = new LOMDTO00025();
            LoanEntity.LoanNo = this.view.LoanNo;
            LoanEntity.RepaymentAmount = this.view.NewRepaymentAmount;
            return LoanEntity;
        }
        public string Currency { get; set; }
        private TLMDTO00018 LoanDTO { get; set; }
        #endregion

        #region MainMethod
        public bool Save()   
        {
            string acode = CXCLE00002.Instance.GetScalarObject<string>("COASetup.Client.Select", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurControl), Currency, CurrentUserEntity.BranchCode, true });
            LoanDTO = new TLMDTO00018();
            LoanDTO.CreditAccountCode = acode; //LAE001
            LoanDTO.CreditAccountDesp = this.view.CustomerName; //Customer' Name
            LoanDTO.AType = this.view.CreditAccountCode; // AKA003
            LoanDTO.BType = this.view.CreditAccountDesp; // Loans To Construction
            LoanDTO.SAmount = this.view.NewRepaymentAmount;
            LoanDTO.CreatedDate = DateTime.Now;
            LoanDTO.CreatedUserId = CurrentUserEntity.CurrentUserID;
            LoanDTO.SourceBranchCode = CurrentUserEntity.BranchCode;
            LoanDTO.Assessor = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.Channel); //Channel
            LoanDTO.Currency = this.Currency;
            TLMDTO00018 dto = CXClientWrapper.Instance.Invoke<ILOMSVE00030, TLMDTO00018>(x => x.RepayLoanEdit(LoanDTO,this.view.FullSettlement,this.view.LoanNo, this.view.AccountNo,this.view.LastRepaymentNo, this.view.LastRepaymentAmount,CurrentUserEntity.CurrentUserName, CurrentUserEntity.CurrentUserID,this.view.NewRepaymentAmount, CurrentUserEntity.BranchCode));

            if (dto == null)
            {

              CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
              return false;

            }

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Loan No.
                return false;

            }

            this.view.CreditAccountCode = dto.CreditAccountCode;
            this.view.CreditAccountDesp = dto.CreditAccountDesp;
            this.view.InterestAccountCode = dto.InterestAccountCode;
            this.view.InterestAccountDesp = dto.InterestAccountDesp;
            this.view.Interest = (this.view.FullSettlement) ? dto.Interest : 0;


            return true;

        }
        #endregion
      
        #region ValidationMethod

        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    if (GetLoanInformationForRepaymentEdit())
                    {
                        this.SetEnableDisable("txtNewRepaymentAmount", true);
                        this.SetFocus("txtNewRepaymentAmount");
                    }
                    else
                        this.SetFocus("txtLoanNo");
            
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Loan No.
                }
            }
            else
            { return; }
        }

        public void txtRepaymentAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    this.view.RepaymentCheck();
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtRepaymentAmount"), "MV90079"); //Invalid Repayment Amount
                }

                // this.SetFocus("txtRepaymentAmount");
            }
            else
            { return; }
        }

        public bool GetLoanInformationForRepaymentEdit()
        {
            try
            {
                TLMDTO00018 LoanDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00030, TLMDTO00018>(x => x.GetLoanInformationForRepaymentEdit(this.View.LoanNo, CurrentUserEntity.BranchCode));
              
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred) 
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI90069");       // Not Vouchered Yet           
                    return false;
                } 

                else if (LoanDTO == null )
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);// Invalid Loans No In Loans File                                       
                    return false;
                }
                
                string msgcode = string.Empty;
                switch(LoanDTO.ResultCode)
                {
                    case "0001": msgcode = "MV90055"; break;
                    case "0002": msgcode = "MV90085"; break; // Loan Account Type Only.      
                    case "0003": msgcode = "MI90069"; break; // Not Vouchered Yet
                    case "0004": msgcode = "MV90087"; break; // Invalid Repayment Period. 
                    case "0005": msgcode = "MV90096"; break; // Loans Repayment Transaction does not exist with Current Date.     
                }
                if (!String.IsNullOrEmpty(msgcode))
                {
                    CXUIMessageUtilities.ShowMessageByCode(msgcode);       
                    return false;
                }

                this.view.AccountNo = LoanDTO.AccountNo;
                this.view.CustomerName = LoanDTO.Name;
                this.view.LastRepaymentNo = LoanDTO.LastRepaymentNo;
                this.view.LastRepaymentAmount = LoanDTO.LastRepaymentAmount;
                this.view.BeforeLastRepaymentSanctionAmount = LoanDTO.BeforeLastRepaymentSanctionAmount;
                this.view.AfterLastRepaymentSanctionAmount = LoanDTO.AfterLastRepaymentSanctionAmount;
                this.view.FirstSanctionAmount = LoanDTO.FistSanctionAmount;
                this.view.PrevTotalSanctionAmount = LoanDTO.PrevTotalSanctionAmount;
                this.Currency = LoanDTO.Currency;

            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Loan No.
            }
            return true;
        }
      
        #endregion
    }
}
