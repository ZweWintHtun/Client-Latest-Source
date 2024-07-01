using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00423 : AbstractPresenter, ILOMCTL00423
    {
        private ILOMVEW00423 view;
        public ILOMVEW00423 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00423 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public void Print(string rptName, string bCode, string cur, string loanGroup)
        {
            IList<LOMDTO00423> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<LOMDTO00423>>(x => x.GetBLDailyPositionListing(loanGroup, bCode));
            if (DTOList.Count > 0)
            {
                string currency = this.view.cur.ToString();
                string header = "";

                if (loanGroup == "")
                {
                    //CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, rptName,showDate, "ALL" });// searchDate.ToString("dd/MM/yyyy")
                    header = "Business Loans Daily Position Listing All";
                    CXUIScreenTransit.Transit("frmLOMVEW00424.ReportViewer", true, new object[] { DTOList, currency, header, bCode, rptName, "ALL" });// searchDate.ToString("dd/MM/yyyy")
                }
                else
                {
                    header = "Business Loans Daily Position Listing For " + loanGroup;
                    CXUIScreenTransit.Transit("frmLOMVEW00424.ReportViewer", true, new object[] { DTOList, currency, header, bCode, rptName, loanGroup });// searchDate.ToString("dd/MM/yyyy")
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }
        public IList<LOMDTO00001> GetAllBLTypes()
        {
            IList<LOMDTO00001> BLType = CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<LOMDTO00001>>(x => x.GetAllBLType());
            return BLType;
        }
    }
}
