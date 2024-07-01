using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr 
{
    public class LOMCTL00407 : AbstractPresenter, ILOMCTL00407
    {
        #region Properties

        private ILOMVEW00407 view;
        public ILOMVEW00407 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00407 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.WithdrawDate);
            }
        }

        #endregion

        #region Main Methods

        public void CalculateInterest()
        {
            try
            {
                //if (this.CheckBudgetYear())
                //{
                    string budgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                    string result = CalculateBusinessLoanInterestByDueDate(this.View.WithdrawDate, this.View.RepaymentDate);
                    if (result == "000")
                    {
                        this.View.Successful(CXMessage.MV90176);//Business Loan Daily Interest Calculation Successfully Finished!
                    }
                    else
                    {
                        this.View.Failure(CXMessage.MV90175);//There is no due Business Loans during required days.
                    }                    
                //}
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string CalculateBusinessLoanInterestByDueDate(DateTime startDate, DateTime endDate)
        {
            PFMDTO00056 PreviousSys001Dto = new PFMDTO00056();
            DateTime GetInterestDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "LOAN_INT_CAL_DAILY", this.view.sourceBranch, true });
            PreviousSys001Dto.BLInterestDate = GetInterestDate;
            PreviousSys001Dto.BranchCode =this.view.sourceBranch;

            PFMDTO00056 Sys001Entity = new PFMDTO00056();
            Sys001Entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            Sys001Entity.BLInterestDate = DateTime.Now;
            Sys001Entity.BranchCode = this.view.sourceBranch;

            IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(PreviousSys001Dto, Sys001Entity);

            return CXClientWrapper.Instance.Invoke<IMNMSVE00002, string>(x => x.CalculateBusinessLoansInterestForDaily(startDate, endDate, this.view.sourceBranch, dvcvList, this.view.userName));
        }

        #endregion

        #region Validation Methods

        //private bool CheckBudgetYear()
        //{
        //    string CurBudYear = CXCOM00010.Instance.GetBudgetYear1("");
        //    string WithdrawBudYear = string.Empty;

        //    string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);
        //    int month = Convert.ToInt32(value.ToString());

        //    if (this.View.WithdrawDate.Month < month)
        //    {
        //        WithdrawBudYear = (this.View.WithdrawDate.Year - 1).ToString() + "/" + this.View.WithdrawDate.Year.ToString();
        //    }
        //    else
        //    {
        //        WithdrawBudYear = this.View.WithdrawDate.Year.ToString() + "/" + (this.View.WithdrawDate.Year + 1).ToString();
        //    }

        //    if (Convert.ToInt32(WithdrawBudYear.Substring(0, 4)) < Convert.ToInt32(CurBudYear.Substring(0, 4)))
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode("MI30008");  //Not allow to calculate previous budget
        //        return false;
        //    }
        //    else if (Convert.ToInt32(WithdrawBudYear.Substring(0, 4)) > Convert.ToInt32(CurBudYear.Substring(0, 4)))
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode("MI30009");  //BL Loans interest calculation allows only current budget
        //        return false;
        //    }
        //    else if (IsOverToday())
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode("MV00130");  //End Date must not be greater than today.
        //        return false;
        //    }
        //    else if (CheckStartDateEndDate())
        //    {
        //        CXUIMessageUtilities.ShowMessageByCode("MV00131");  //Start Date must not be greater than End Date.
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private bool IsOverToday()
        //{
        //    if (this.View.RepaymentDate.Year > DateTime.Today.Year)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        if (this.View.RepaymentDate.Month > DateTime.Today.Month && this.View.RepaymentDate.Year == DateTime.Today.Year)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            if (this.View.RepaymentDate.Day > DateTime.Today.Day && this.View.RepaymentDate.Month == DateTime.Today.Month)
        //            {
        //                return true;
        //            }
        //        }

        //    }
        //    return false;
        //}

        //private bool CheckStartDateEndDate()
        //{
        //    if (this.View.WithdrawDate.Year > this.View.RepaymentDate.Year)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        if (this.View.WithdrawDate.Month > this.View.RepaymentDate.Month && this.View.WithdrawDate.Year == this.View.RepaymentDate.Year)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            if (this.View.WithdrawDate.Day > this.View.RepaymentDate.Day && this.View.WithdrawDate.Month == this.View.RepaymentDate.Month)
        //            {
        //                return true;
        //            }
        //        }

        //    }
        //    return false;
        //}

        #endregion
    }
}
