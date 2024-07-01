using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00104 : AbstractPresenter, ILOMCTL00104
    {
        #region "Wire To"
        public LOMDTO00078 FarmLoanDTO { get; set; }
        private ILOMVEW00104 view;
        public ILOMVEW00104 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00104 view)
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
                    else if (Convert.ToDecimal(this.view.TotalOutstanding) < Convert.ToDecimal(this.view.RepaymentAmount))
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90094);
                        this.SetFocus("txtRepaymentAmount");
                        return;
                    }
                    else
                    {
                        this.view.TotalInterest = Convert.ToDecimal(this.GetInterestAmount(this.view.LoanNo, this.view.startDate));
                        if (this.view.TotalInterest != 0)
                        {
                            this.SetEnableDisable("txtInterest", true);
                        }
                        else {
                            this.SetEnableDisable("txtInterest", false);
                        }
                        this.view.Penalties = Convert.ToDecimal(this.GetPenalFee());
                        if (this.view.Penalties != 0)
                        {
                            this.SetEnableDisable("txtPenalties", true);
                        }
                        else {
                            this.SetEnableDisable("txtPenalties", false);
                        }
                        this.view.TotalAmount = this.view.RepaymentAmount + this.view.TotalInterest + this.view.Penalties;
                        this.SetEnableDisable("txtTotalAmount", false);
                    }
                }
                catch
                {
                    this.SetCustomErrorMessage(this.GetControl("txtRepaymentAmount"), "MV90079"); //Invalid Repayment Amount
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
                this.view.startDate = FarmLoanDTO.StartDate;
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
        #endregion

    }
}
