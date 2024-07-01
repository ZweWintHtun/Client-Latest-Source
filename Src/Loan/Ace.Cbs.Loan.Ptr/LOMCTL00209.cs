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
    class LOMCTL00209 : AbstractPresenter, ILOMCTL00209
    {
        public string showDate;
        private ILOMVEW00209 view;
        public ILOMVEW00209 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00209 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        //public void Print(string rptName, string stockGroupCode,DateTime startDate,DateTime endDate,string sourceBr)
        public void Print(string rptName, string stockGroupCode,string sourceBr)
        {
            //IList<LOMDTO00208> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00208>>(x => x.GetHPDailyPositionListing(stockGroupCode,startDate,endDate,sourceBr));
            IList<LOMDTO00208> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00208>>(x => x.GetHPDailyPositionListing(stockGroupCode, sourceBr));
            if (DTOList.Count > 0)
            {
                string currency = this.view.Currency.ToString();
                string header = "Hire Purchase Daily Position Listing";

                //if (startDate.ToString("yyyyMMdd") == endDate.ToString("yyyyMMdd"))
                //    showDate = "At " + startDate.ToString("dd/MM/yyyy");
                //else
                //    showDate = "From " + startDate.ToString("dd/MM/yyyy") + " To " + endDate.ToString("dd/MM/yyyy");

                if (stockGroupCode == "")
                    //CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, rptName,showDate, "ALL" });// searchDate.ToString("dd/MM/yyyy")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, rptName,"ALL" });// searchDate.ToString("dd/MM/yyyy")
                else
                {
                    stockGroupCode = DTOList[0].StockGroup;
                    //CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, rptName, showDate, stockGroupCode });// searchDate.ToString("dd/MM/yyyy")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, rptName, stockGroupCode });// searchDate.ToString("dd/MM/yyyy")
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }
    }
}
