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
    class LOMCTL00207 : AbstractPresenter, ILOMCTL00207
    {
        private ILOMVEW00207 view;
        public ILOMVEW00207 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00207 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public void Print(string rptName, DateTime startDate, DateTime endDate)
        {
            IList<LOMDTO00207> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00207>>(x => x.GetPersonalLoanNPLCaseListing(startDate, endDate, this.view.SourceBr));
            if (DTOList.Count > 0)
            {
                string currency = this.view.Currency.ToString();
                string header = "Personal Loans In Non Performance Listing";
                string sourcebranch = this.view.SourceBr.ToString();
                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName });
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }
    }
}
