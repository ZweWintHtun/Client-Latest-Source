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
    class LOMCTL00230 : AbstractPresenter, ILOMCTL00230
    {
        private ILOMVEW00230 view;
        public ILOMVEW00230 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00230 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr)
        {
            IList<LOMDTO00227> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00227>>(x => x.BL_Overdrawn_Listing(startDate,endDate,currency,sourceBr));
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                string header = "Business Loans Overdrawn Listing";
                string sourcebranch = this.view.SourceBr.ToString();
                    
                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), currency, header, sourcebranch, rptName});
            }
        }

    }
}
