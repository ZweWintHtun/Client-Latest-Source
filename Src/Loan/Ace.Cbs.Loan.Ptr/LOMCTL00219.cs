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
    class LOMCTL00219 : AbstractPresenter, ILOMCTL00219
    {
        string resultStr;
        private ILOMVEW00219 view;
        public ILOMVEW00219 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00219 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public IList<LOMDTO00217> PLAbsentHistory_Enquiry(string acctNo, string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00217>>(x => x.PLAbsentHistory_Enquiry(acctNo,sourceBr));
        }

        public void Print(string rptName, string acctNo, string sourceBr)
        {
            IList<LOMDTO00217> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00217>>(x => x.PLAbsentHistory_Enquiry(acctNo, sourceBr));
            
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if(DTOList.Count > 0)
            {
                string header = "Personal Loan Repayment History Enquiry List";
                string sourcebranch = sourceBr;
                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, header, sourcebranch, rptName });
            }

        }
    }
}
