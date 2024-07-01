using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00092 : AbstractPresenter, ILOMCTL00092
    {
        #region "Wire To"
        public LOMDTO00078 FarmLoanDTO { get; set; }
        private ILOMVEW00092 view;
        public ILOMVEW00092 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00092 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        private LOMDTO00078 GetEntity()
        {
            LOMDTO00078 LoanEntity = new LOMDTO00078();
            LoanEntity.Lno = this.view.LoanNo;
            LoanEntity.RepaymentAmount = this.view.RepaymentAmount;
            return LoanEntity;
        }
        #endregion

        #region Validation
        public void txtLoanNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    GetLoanInfo();
                }
                catch
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
                    if (this.view.RepaymentAmount.ToString() == "0.00" || this.view.RepaymentAmount.ToString() == "0")
                    {
                        this.SetFocus("txtRepaymentAmount");
                        return;                        
                    }
                    
                    this.view.RepaymentCheck();
                }
                catch
                {
                    this.SetCustomErrorMessage(this.GetControl("txtRepaymentAmount"), "MV90079"); //Invalid Repayment Amount
                }
            }
            else
            { return; }
        }

        public void cboLoanAcctNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    if (this.view.CreditAccountCode.ToString() == "" || this.view.CreditAccountCode.ToString() == string.Empty)
                    {
                        this.SetFocus("cboLoanAcctNo");
                        return;                        
                    }
                }
                catch
                {
                    this.SetCustomErrorMessage(this.GetControl("cboLoanAcctNo"), "MV90079"); //Invalid Repayment Amount
                }
            }
            else
            { return; }
        }
        #endregion 

        #region MainMethod
        public bool checkFarmLoan(string loanNo)
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ILOMSVE00092, bool>(service => service.checkFarmLoan(loanNo));
            }
            catch { return false; }
        }

        public bool GetLoanInfo()
        {
            try
            {
                FarmLoanDTO = CXClientWrapper.Instance.Invoke<ILOMSVE00092, LOMDTO00078>(x => x.isValidLoanNo(this.View.LoanNo, CurrentUserEntity.BranchCode));

                if (FarmLoanDTO == null || FarmLoanDTO.ResultCode == "0001")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90055);//Invalid Loan No.
                    this.SetFocus("txtLoanNo");
                    return false;
                }

                if (FarmLoanDTO.ResultCode == "0002")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90085);// Loans Account Only 
                    this.SetFocus("txtLoanNo");
                    return false;
                }

                if (FarmLoanDTO.ResultCode == "0003")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90087);// Not vouchered yet 
                    this.SetFocus("txtLoanNo");
                    return false;
                }

                if (FarmLoanDTO.ResultCode == "0004")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90057);// Loans Account Closed 
                    this.SetFocus("txtLoanNo");
                    return false;
                }

                if (FarmLoanDTO.ResultCode == "0005")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90086);//No Sanction Amount
                    this.SetFocus("txtLoanNo");
                    return false;
                }

                if (FarmLoanDTO.ResultCode == "0006")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90086);//This Account is in Legal Case.
                    this.SetFocus("txtLoanNo");
                    return false;
                }

                this.view.AccountNo = FarmLoanDTO.AcctNo;
                this.view.TotalOutstanding = FarmLoanDTO.SAmt.Value;
                //this.view.TotalInterest = FarmLoanDTO.Interest;
                //this.view.Penalties = "0";
                
                
                //if (this.view.TotalInterest > 0)
                //{
                //    this.SetEnableDisable("cboInterestAccNo", true);
                //    this.view.BindInterestAcctNo();
                //    if (this.view.InterestAccountCode == string.Empty || this.view.InterestAccountCode == "")
                //    {
                //        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90087);// Not vouchered yet 
                //        this.SetFocus("cboInterestAccNo");
                //        return false;
                //    }
                //}
                //else
                //    this.SetEnableDisable("cboInterestAccNo", false);

                //if (Convert.ToDecimal(this.view.Penalties) > 0)
                //{
                //    this.SetEnableDisable("cboPenalties", true);
                //    this.view.BindPenalties();
                //    if (this.view.PenalitesAccountCode == string.Empty || this.view.PenalitesAccountCode == "")
                //    {
                //        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90087);// Not vouchered yet 
                //        this.SetFocus("cboPenalties");
                //        return false;
                //    }
                //}
                //else
                //    this.SetEnableDisable("cboPenalties", false);   
                
                this.view.CustomerName = FarmLoanDTO.Name;
                this.view.startDate = FarmLoanDTO.StartDate;
                //this.view.InterestAccountCode = FarmLoanDTO.InterestAccountCode;
                this.view.CreditAccountCode = FarmLoanDTO.AccountName;
                this.view.CreditAccountDesp = ((FarmLoanDTO.LoanType == "111") ? "AGRICULTURAL LOAN to " : "LIVESTOCK LOAN to ");
                this.view.InterestAccountDesp = ((FarmLoanDTO.LoanType == "111") ? "AGRICULTURAL LOAN INTEREST to " : "Interest LIVESTOCK LOAN INTEREST to ");
                this.view.PenalitiesAccountDesp = ((FarmLoanDTO.LoanType == "111") ? "AGRICULTURAL LOAN PENALTIES to " : "Interest LIVESTOCK LOAN PENALTIES to ");
                this.view.Currency = FarmLoanDTO.Cur;
                this.view.DebitAccountCode = FarmLoanDTO.DebitAccountCode;
                this.view.BindAcctNo();
                this.SetEnableDisable("cboLoanAcctNo", true);
                this.SetFocus("cboLoanAcctNo");
            }
            catch
            {
                this.SetCustomErrorMessage(this.GetControl("txtLoanNo"), "MV90055"); //Invalid Entry No.
            }
            return true;
        }

        public double GetInterestAmount(string LoanNo, string startDate)
        {
            string budgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
            double interest = CXClientWrapper.Instance.Invoke<ILOMSVE00092, double>(x => x.GetInterestAmount(this.view.LoanNo, startDate, this.view.RepaymentAmount, budgetYear));
            return interest;
        }

        public double GetPenalFee()
        {
            try
            {
                double penalFees = CXClientWrapper.Instance.Invoke<ILOMSVE00092, double>(x => x.GetPenalFee(this.view.LoanNo, this.view.RepaymentAmount, CurrentUserEntity.BranchCode));
                return penalFees;
            }
            catch { return 0; }
        }

        public LOMDTO00078 Save(decimal penalties)
        {
            FarmLoanDTO.CreatedUserId = CurrentUserEntity.CurrentUserID;
            FarmLoanDTO.SourceBr = CurrentUserEntity.BranchCode;

            LOMDTO00078 dto = CXClientWrapper.Instance.Invoke<ILOMSVE00092, LOMDTO00078>(x => x.RepayFarmLoan(FarmLoanDTO, this.view.LoanNo, this.view.AccountNo, this.view.RepaymentAmount, this.view.TotalInterest, penalties, CurrentUserEntity.CurrentUserName, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, this.view.CreditAccountCode, this.view.InterestAccountCode, this.view.PenalitesAccountCode));
            return dto;
        }

        public IList<LOMDTO00078> getLoanAcctNo(string loanNo, string sourceBr, string type)
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ILOMSVE00092, LOMDTO00078>(x => x.getLoanAcctNo(this.view.LoanNo, CurrentUserEntity.BranchCode, type));
            }
            catch { return null; }
        }

        public double GetHomeAmount(string vrNo)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00092, double>(x => x.GetHomeAmount(this.view.VrNo));
        }
        #endregion
    }
}
