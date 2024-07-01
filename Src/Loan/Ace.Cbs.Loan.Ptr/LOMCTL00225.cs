using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00225 : AbstractPresenter, ILOMCTL00225
    {
        private ILOMVEW00225 view;
        public ILOMVEW00225 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00225 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public IList<string> GetAllPersonalLoansCompanyName(string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<string>>(x => x.GetAllPersonalLoansCompanyName(sourceBr));
        }

        public void Print(string rptName, string sourceBr, string companyName)
        {
            IList<LOMDTO00223> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00223>>(x => x.PL_DailyPosition_Listing(sourceBr,companyName));
            if (DTOList.Count > 0)
            {
                string currency = this.view.Currency.ToString();
                string header = "Personal Loans Daily Position Listing";
                if (companyName == "")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, rptName, "ALL" });
                else
                {
                    companyName = DTOList[0].CompanyName;
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, rptName, companyName });
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }
    }
}
