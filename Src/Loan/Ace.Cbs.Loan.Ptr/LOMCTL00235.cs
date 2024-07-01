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
    class LOMCTL00235 : AbstractPresenter, ILOMCTL00235
    {
        private ILOMVEW00235 view;
        public ILOMVEW00235 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00235 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print_HP_AccountClosed_Listing(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00231> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00231>>(x => x.HP_AccountClosed_Listing(startDate, endDate, currency, sourceBr));
            if (DTOList.Count > 0)
            {
                string header = "Hire Purchase Account Closed Listing";

                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, sourceBr, currency, header, rptName, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy") });
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }

        public void Print_PL_AccountClosed_Listing(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00231> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00231>>(x => x.PL_AccountClosed_Listing(startDate, endDate, currency, sourceBr));
            if (DTOList.Count > 0)
            {
                string header = "Personal Loans Account Closed Listing";

                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, sourceBr,currency, header, rptName, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy") });
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }

        public void Print_BL_AccountClosed_Listing(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00231> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00231>>(x => x.BL_AccountClosed_Listing(startDate, endDate, currency, sourceBr));
            if (DTOList.Count > 0)
            {
                string header = "Business Loans Account Closed Listing";

                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, sourceBr, currency, header, rptName, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy") });
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }


    }
}
