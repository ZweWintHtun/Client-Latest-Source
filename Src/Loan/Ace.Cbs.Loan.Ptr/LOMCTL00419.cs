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
    public class LOMCTL00419 : AbstractPresenter, ILOMCTL00419
    {
        string filterStatus;
        private ILOMVEW00419 view;
        public ILOMVEW00419 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00419 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName, DateTime startDate, DateTime endDate, string acctno, string sourceBr)
        {
            IList<LOMDTO00406> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<LOMDTO00406>>(x => x.BLAbsentHistoryListing(startDate, endDate, acctno, sourceBr));
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                string header = "Business Loans Repayment History Listing";
                string sourcebranch = this.view.SourceBr.ToString();
                CXUIScreenTransit.Transit("frmLOMVEW00420.ReportViewer", true, new object[] { DTOList, header, sourcebranch, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName });
            }
        }
    }
}
