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
    class LOMCTL00203 : AbstractPresenter, ILOMCTL00203
    {
        private ILOMVEW00203 view;
        public ILOMVEW00203 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00203 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName, string month)
        {
                string str1 = month.Substring(0, 2);
                string str2 = month.Substring(2, month.Length - 2);

                IList<LOMDTO00203> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00203>>(x => x.GetHPInsufficientListing(this.view.SourceBr, this.view.Currency, str1));
                if (DTOList.Count > 0)
                {
                    string currency = this.view.Currency.ToString();
                    string header = "Hire Purchase Insufficient Listing";
                    string sourcebranch = this.view.SourceBr.ToString();
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, str2, rptName });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
        }
    }
}
