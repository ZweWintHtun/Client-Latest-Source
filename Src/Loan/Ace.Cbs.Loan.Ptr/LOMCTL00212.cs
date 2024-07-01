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
    class LOMCTL00212 : AbstractPresenter, ILOMCTL00212
    {
        private ILOMVEW00212 view;
        public ILOMVEW00212 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00212 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName, DateTime startDate, DateTime endDate,string currency,string sourceBr,string stockGroup)
        {
            IList<LOMDTO00211> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00211>>(x => x.GetHPRePaymentListing(startDate, endDate, currency, sourceBr,stockGroup));
            if (DTOList.Count > 0)
            {
                string header = "Hire Purchase Repayment Listing";
                if (stockGroup == "")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, "ALL" });
                else
                {
                    stockGroup = DTOList[0].StockGroup;
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, stockGroup });
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }

    }
}
