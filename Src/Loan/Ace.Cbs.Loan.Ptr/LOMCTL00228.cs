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
    class LOMCTL00228 : AbstractPresenter, ILOMCTL00228
    {
        private ILOMVEW00228 view;
        public ILOMVEW00228 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00228 view)
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

        public void Print(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr, string companyName)
        {
            IList<LOMDTO00225> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00225>>(x => x.PL_AutoPay_Sufficient_Listing(startDate, endDate, companyName, currency, sourceBr));
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                string header = "Personal Loans Installment Auto Payment Sufficient Listing";
                string sourcebranch = this.view.SourceBr.ToString();
                if (companyName == "")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), currency, header, sourcebranch, rptName, "ALL" });
                else
                {
                    companyName = DTOList[0].CompanyName;
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), currency, header, sourcebranch, rptName, companyName });
                }
            }
        }

    }
}
