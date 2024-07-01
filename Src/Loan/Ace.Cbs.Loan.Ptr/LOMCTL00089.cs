using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00089 : AbstractPresenter, ILOMCTL00089
    {
        #region Properties

        private ILOMVEW00089 view;
        public ILOMVEW00089 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00089 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view,this.view.WithdrawDate);
            }
        }

        #endregion

        #region Main Methods

        public void CalculateInterest()
        {
            if (this.CheckBudgetYear())
                {
                    string budgetYear = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode); 
                    IList<LOMDTO00085> farmLiList = this.SelectFarmLiCloseDateIsNull(CurrentUserEntity.BranchCode, budgetYear);
                    if (farmLiList != null && farmLiList.Count > 0)
                    {
                        if (this.CalculateFarmLoanInterestByDate(farmLiList, this.View.WithdrawDate, this.View.RepaymentDate))
                        {
                            this.View.Successful(CXMessage.MI90024);
                        }
                        else
                        {
                            this.View.Failure(CXMessage.MI90025);
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90078);                        
                    }
                    //try
                    //{
                    //    CXClientWrapper.Instance.Invoke<ILOMSVE00089>(x => x.CalculateInterest(this.View.WithdrawDate,this.View.RepaymentDate));
                    //    CXUIMessageUtilities.ShowMessageByCode("MI30005");//Saving Interest Successful                        
                    //}
                    //catch(Exception ex)
                    //{
                    //    CXUIMessageUtilities.ShowMessageByCode("MI30006"); //Saving Interest Fail.
                    //}
                    
                }
        }

        //New Logic (Updated Date - 23/Feb/2017 By HWKO)
        public IList<LOMDTO00085> SelectFarmLiCloseDateIsNull(string sourceBr, string budgetYear)
        {
            IList<LOMDTO00085> liList = CXClientWrapper.Instance.Invoke<ILOMSVE00085, IList<LOMDTO00085>>(x => x.SelectFarmLiCloseDateIsNull(sourceBr, budgetYear));
            return liList;
        }

        //New Logic (Updated Date - 23/Feb/2017 By HWKO)
        public bool CalculateFarmLoanInterestByDate(IList<LOMDTO00085> farmLiList, DateTime startDate, DateTime endDate)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00085, bool>(x => x.CalculateFarmLoanInterestByDate(farmLiList, startDate, endDate));
        }

        #endregion

        #region Validation Methods

        private bool CheckBudgetYear()
        {
            string CurBudYear = CXCOM00010.Instance.GetBudgetYear1("");
            string WithdrawBudYear = string.Empty;

            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);
            int month = Convert.ToInt32(value.ToString());

            if (this.View.WithdrawDate.Month < month)
            {
                WithdrawBudYear = (this.View.WithdrawDate.Year - 1).ToString() + "/" + this.View.WithdrawDate.Year.ToString();
            }
            else
            {
                WithdrawBudYear = this.View.WithdrawDate.Year.ToString() + "/" + (this.View.WithdrawDate.Year + 1).ToString();
            }

            if (Convert.ToInt32(WithdrawBudYear.Substring(0, 4)) < Convert.ToInt32(CurBudYear.Substring(0, 4)))
            {
                CXUIMessageUtilities.ShowMessageByCode("MI30008");  //Not allow to calculate previous budget
                return false;
            }
            else if (Convert.ToInt32(WithdrawBudYear.Substring(0, 4)) > Convert.ToInt32(CurBudYear.Substring(0, 4)))
            {
                CXUIMessageUtilities.ShowMessageByCode("MI30009");  //Saving interest calculation allows only current budget
                return false;
            }
            else if (IsOverToday())
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00130");  //End Date must not be greater than today.
                return false;
            }
            else if (CheckStartDateEndDate())
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00131");  //Start Date must not be greater than End Date.
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsOverToday()
        {
            if (this.View.RepaymentDate.Year > DateTime.Today.Year)
            {
                return true;
            }
            else
            {
                if (this.View.RepaymentDate.Month > DateTime.Today.Month && this.View.RepaymentDate.Year == DateTime.Today.Year)
                {
                    return true;
                }
                else
                {
                    if (this.View.RepaymentDate.Day > DateTime.Today.Day && this.View.RepaymentDate.Month == DateTime.Today.Month)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        private bool CheckStartDateEndDate()
        {
            if (this.View.WithdrawDate.Year > this.View.RepaymentDate.Year)
            {
                return true;
            }
            else
            {
                if (this.View.WithdrawDate.Month > this.View.RepaymentDate.Month && this.View.WithdrawDate.Year == this.View.RepaymentDate.Year)
                {
                    return true;
                }
                else
                {
                    if (this.View.WithdrawDate.Day > this.View.RepaymentDate.Day && this.View.WithdrawDate.Month == this.View.RepaymentDate.Month)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        #endregion
    }
}
