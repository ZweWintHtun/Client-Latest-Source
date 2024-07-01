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
    class LOMCTL00210 : AbstractPresenter, ILOMCTL00210
    {
        private ILOMVEW00210 view;
        public ILOMVEW00210 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00210 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName, DateTime startDate, DateTime endDate, string stockGroup, string sourceBr)
        {
            IList<LOMDTO00209> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00209>>(x => x.GetHPInformationListing(startDate, endDate,stockGroup, sourceBr));
            if (DTOList.Count > 0)
            {
                string currency = this.view.Currency.ToString();
                string header = "Hire Purchase Information Listing";
                if (stockGroup == "")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, "ALL" });// searchDate.ToString("dd/MM/yyyy")
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
