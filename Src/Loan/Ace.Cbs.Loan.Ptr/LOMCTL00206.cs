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
    class LOMCTL00206 : AbstractPresenter, ILOMCTL00206
	{
        #region Properties
        private ILOMVEW00206 view;
        public ILOMVEW00206 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00206 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        #endregion

        public void Print(string rptName, string month, string year,int createdUserId,string sourceBr)
        {
                string str1 = month.Substring(0, 1);
                string str2 = month.Substring(1, month.Length - 1);

                IList<LOMDTO00206> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00206>>(x => x.GetBLInterestListing(str1, year, sourceBr, createdUserId));
                if (DTOList.Count > 0)
                {
                    string currency = this.view.Currency.ToString();
                    string header = "Business Loan Interest Listing";
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, str2, year, rptName });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
        }
	}
}
