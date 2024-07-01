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
    class LOMCTL00227 : AbstractPresenter, ILOMCTL00227
    {
        private ILOMVEW00227 view;
        public ILOMVEW00227 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00227 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName, DateTime startDate,DateTime endDate,string currency, string sourceBr, string stockGroup)
        {
            IList<LOMDTO00224> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00224>>(x => x.HP_AutoPay_Sufficient_Listing(startDate, endDate, stockGroup, currency, sourceBr));
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                string header = "Hire Purchase Installment Auto Payment Sufficient Listing";
                string sourcebranch = this.view.SourceBr.ToString();
                
                if (stockGroup == "")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), currency, header, sourcebranch, rptName, "ALL" });
                else
                {
                    stockGroup = DTOList[0].StockGroup;
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), currency, header, sourcebranch, rptName, stockGroup });
                }
            }
        }

    }
}
