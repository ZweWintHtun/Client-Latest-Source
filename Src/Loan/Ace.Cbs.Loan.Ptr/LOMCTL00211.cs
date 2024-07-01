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
    class LOMCTL00211 : AbstractPresenter, ILOMCTL00211
    {
        private ILOMVEW00211 view;
        public ILOMVEW00211 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00211 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName,DateTime startDate,DateTime endDate,string stockGroup,string cur,string sourceBr)
        {
            IList<LOMDTO00210> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00210>>(x => x.GetHPPaymentListing(startDate,endDate,stockGroup,cur,sourceBr));
            if (DTOList.Count > 0)
            {
                string currency = this.view.Currency.ToString();
                string header = "Hire Purchase Payment Listing";
                if (stockGroup == "")
                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, header, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), currency, sourceBr, rptName,"ALL" });
                else
                {
                    stockGroup = DTOList[0].StockGroup;
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, header, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), currency, sourceBr, rptName, stockGroup });
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }
    }
}
