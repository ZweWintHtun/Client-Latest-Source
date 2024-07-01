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
    class LOMCTL00234 : AbstractPresenter, ILOMCTL00234
    {
        private ILOMVEW00234 view;
        public ILOMVEW00234 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00234 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00230> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00230>>(x => x.BL_TOD_Repayment_Listing(startDate,endDate,currency,sourceBr));
            if (DTOList.Count > 0)
            {
                string header = "Business Loans TOD Repayment Listing";

                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { currency, header, rptName, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), DTOList, sourceBr });
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }

    }
}
