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
    public class LOMCTL00090 : AbstractPresenter, ILOMCTL00090
    {
        #region Properties

        ILOMVEW00090 view;
        public ILOMVEW00090 View
        {
            set { this.wierTo(value); }
            get { return this.view; }
        }

        private void wierTo(ILOMVEW00090 view)
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

        public void CalculateInterestMonthly(string budgetyear, DateTime startDate, DateTime endDate)//(budget year,start date, end date)
        {
            try
            {
                CXClientWrapper.Instance.Invoke<ILOMSVE00085>(x => x.CalculateInterestMonthly(budgetyear, startDate, endDate));
                CXUIMessageUtilities.ShowMessageByCode("MI30005");//Saving Interest Successful
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI30006"); //Saving Interest Fail.
            }
        }

        //New Logic (Updated Date - 23/Feb/2017 By HWKO)
        public bool CalculateFarmLoanInterestMonth(IList<LOMDTO00085> farmLiList, DateTime startDate, DateTime endDate, string budgetYear)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00085, bool>(x => x.CalculateFarmLoanInterestMonthly(farmLiList,startDate,endDate,budgetYear)); 
        }

        //New Logic (Updated Date - 23/Feb/2017 By HWKO)
        public IList<LOMDTO00085> SelectFarmLiCloseDateIsNull(string sourceBr, string budgetYear)
        {
            IList<LOMDTO00085> liList = CXClientWrapper.Instance.Invoke<ILOMSVE00085, IList<LOMDTO00085>>(x => x.SelectFarmLiCloseDateIsNull(sourceBr,budgetYear));
            return liList;
        }
    }
}
