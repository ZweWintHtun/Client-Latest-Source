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
using Ace.Cbs.Tcm.Ctr;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00220 : AbstractPresenter, ILOMCTL00220
    {
        public string showDate;
        public string searchFilter;
        private ILOMVEW00220 view;
        public ILOMVEW00220 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00220 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName, string currency, string sourceBr,DateTime startDate,DateTime endDate,int searchBy)
        {
            IList<LOMDTO00218> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00218>>(x => x.HP_LateFees_Outstanding_Listing(currency,sourceBr,startDate,endDate,searchBy));
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                string header = "Hire Purchase Late Fees Outstanding Listing";
                if (startDate.ToString("yyyyMMdd") == endDate.ToString("yyyyMMdd"))
                    showDate = "At " + startDate.ToString("dd/MM/yyyy");
                else
                    showDate = "From " + startDate.ToString("dd/MM/yyyy") + " To " + endDate.ToString("dd/MM/yyyy");
                if (searchBy == 0) searchFilter = "ALL";
                else searchFilter = "DATE";

                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, rptName, showDate, searchFilter });
            }
        }

        //Added by HMW at 29-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }
    }
}
