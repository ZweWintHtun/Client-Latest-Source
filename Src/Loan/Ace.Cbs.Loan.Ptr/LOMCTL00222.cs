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
    class LOMCTL00222 : AbstractPresenter, ILOMCTL00222
    {
        private ILOMVEW00222 view;
        public ILOMVEW00222 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00222 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName, string currency, string sourceBr,string stockGroup)
        {
            IList<LOMDTO00220> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00220>>(x => x.HP_Installment_Listing(currency,sourceBr,stockGroup,this.view.SortType));
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                string header = "Hire Purchase Installment Listing";
                string sourcebranch = this.view.SourceBr.ToString();
                string showDate="";

                DateTime lastSettlementDate = DTOList[0].LastSettlementDate;
                DateTime nextSettlementDate = DTOList[0].NextSettlementDate;

                if (lastSettlementDate.AddDays(1).ToString("yyyyMMdd") == nextSettlementDate.ToString("yyyyMMdd"))
                    showDate = "At " + lastSettlementDate.ToString("dd/MM/yyyy");
                else
                    showDate = "From " + lastSettlementDate.ToString("dd/MM/yyyy") + " To " + nextSettlementDate.AddDays(-1).ToString("dd/MM/yyyy");

                if (stockGroup == "")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, showDate, rptName, "ALL"});
                else
                {
                    stockGroup = DTOList[0].StockGroup;
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, showDate, rptName, stockGroup});
                }
            }
        }

    }
}
