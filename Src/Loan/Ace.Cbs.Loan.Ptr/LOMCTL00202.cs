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
    class LOMCTL00202 : AbstractPresenter, ILOMCTL00202
    {
        string showDate;
        private ILOMVEW00202 view;
        public ILOMVEW00202 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00202 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        
        public void Print(string rptName,string sourceBr,string currency,DateTime startDate,DateTime endDate)
        {
            IList<LOMDTO00202> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00202>>(x => x.GetHPOverDraftListing(sourceBr, currency, startDate, endDate));
                if (DTOList.Count > 0)
                {
                    string header = "Hire Purchase Overdrawn A/C Listing";
                    string sourcebranch = this.view.SourceBr.ToString();
                    if (startDate.ToString("yyyyMMdd") == endDate.ToString("yyyyMMdd"))
                        showDate = "At " + startDate.ToString("dd/MM/yyyy");
                    else
                        showDate = "From " + startDate.ToString("dd/MM/yyyy") + " To " + endDate.ToString("dd/MM/yyyy");

                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, rptName, showDate });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
        }
    }
}
