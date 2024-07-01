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
    class LOMCTL00421 : AbstractPresenter, ILOMCTL00421
    {
        string resultStr;
        private ILOMVEW00421 view;
        public ILOMVEW00421 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00421 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public IList<LOMDTO00406> BlAbsentHistory_Enquiry(string acctNo, string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<LOMDTO00406>>(x => x.BLAbsentHistory_Enquiry(acctNo, sourceBr));
        }

        public void Print(string rptName, string acctNo, string sourceBr)
        {
            IList<LOMDTO00406> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<LOMDTO00406>>(x => x.BLAbsentHistory_Enquiry(acctNo, sourceBr));
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            if (DTOList.Count > 0)
            {
                string header = "Business Laons Repayment History Enquiry List";
                string sourcebranch = sourceBr;
                CXUIScreenTransit.Transit("frmLOMVEW00420.ReportViewer", true, new object[] { DTOList, header, sourcebranch, rptName });
            }
        }
    }
}

