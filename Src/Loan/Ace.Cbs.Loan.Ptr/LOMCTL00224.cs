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
    class LOMCTL00224 : AbstractPresenter, ILOMCTL00224
    {
        private ILOMVEW00224 view;
        public ILOMVEW00224 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00224 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public IList<LOMDTO00001> BindLoansBType()
        {
            IList<LOMDTO00001> LoansBTypeDto = CXClientWrapper.Instance.Invoke<ILOMSVE00011, IList<LOMDTO00001>>(x => x.BindLoansBType());
            return LoansBTypeDto;
        }

        public void Print(string rptName, string currency, string sourceBr, string businessType)
        {
            IList<LOMDTO00222> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00222>>(x => x.BL_Installment_Listing(currency, sourceBr, businessType, this.view.SortType));
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                string header = "Business Loans Installment Listing";
                string sourcebranch = this.view.SourceBr.ToString();
                string showDate = "";

                DateTime lastSettlementDate = DTOList[0].LastSettlementDate;
                DateTime nextSettlementDate = DTOList[0].NextSettlementDate;

                if (lastSettlementDate.AddDays(1).ToString("yyyyMMdd") == nextSettlementDate.ToString("yyyyMMdd"))
                    showDate = "At " + lastSettlementDate.ToString("dd/MM/yyyy");
                else
                    showDate = "From " + lastSettlementDate.ToString("dd/MM/yyyy") + " To " + nextSettlementDate.AddDays(-1).ToString("dd/MM/yyyy");

                if (businessType == "")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, showDate, rptName, "ALL" });
                else
                {
                    businessType = DTOList[0].BusinessType;
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, showDate, rptName, businessType });
                }
            }
        }

    }
}
