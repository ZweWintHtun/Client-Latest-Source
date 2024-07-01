using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00091 : AbstractPresenter, ILOMCTL00091
    {
        #region Properties

        ILOMVEW00091 view;
        public ILOMVEW00091 View
        {
            set { this.wierTo(value); }
            get { return this.view; }
        }

        private void wierTo(ILOMVEW00091 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        public LOMDTO00078 GetEntity()
        {
            LOMDTO00078 entity = new LOMDTO00078();
            return entity;
        }

        #endregion

        public void CalculateInterestFromMonthToMonth(string budgetyear, DateTime startDate, DateTime endDate)//(budget year,start date, end date)
        {
            try
            {
                CXClientWrapper.Instance.Invoke<ILOMSVE00085>(x => x.CalculateInterestFromMonthToMonth(budgetyear, startDate, endDate));
                CXUIMessageUtilities.ShowMessageByCode("MI30005");//Saving Interest Successful
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI30006"); //Saving Interest Fail.
            }
        }

        //New Logic (Updated Date - 27/Feb/2017 By HWKO)
        public bool CalculateFarmLoanInterestByMonth(IList<LOMDTO00085> farmLiList, DateTime startDate, DateTime endDate)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00085, bool>(x => x.CalculateFarmLoanInterestByMonth(farmLiList, startDate, endDate));
        }

        //New Logic (Updated Date - 27/Feb/2017 By HWKO)
        public IList<LOMDTO00085> SelectFarmLiCloseDateIsNull(string sourceBr, string budgetYear)
        {
            IList<LOMDTO00085> liList = CXClientWrapper.Instance.Invoke<ILOMSVE00085, IList<LOMDTO00085>>(x => x.SelectFarmLiCloseDateIsNull(sourceBr, budgetYear));
            return liList;
        }
    }
}
