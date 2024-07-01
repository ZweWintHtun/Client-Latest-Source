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
    class LOMCTL00221 : AbstractPresenter, ILOMCTL00221
    {
        private ILOMVEW00221 view;
        public ILOMVEW00221 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00221 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName, string currency, string sourceBr)
        {
            IList<LOMDTO00219> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00219>>(x => x.BL_LateFees_Outstanding_Listing(currency,sourceBr));
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }

            else //if (DTOList.Count > 0)
            {
                string header = "Business Loans Late Fees Outstanding Listing";
                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, rptName });
            }

        }
    }
}
