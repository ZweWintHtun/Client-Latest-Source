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
    class LOMCTL00229 : AbstractPresenter, ILOMCTL00229
    {
        private ILOMVEW00229 view;
        public ILOMVEW00229 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00229 view)
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

        public void Print(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr, string businessType)
        {
            IList<LOMDTO00226> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00226>>(x => x.BL_AutoPay_Sufficient_Listing(startDate,endDate,currency,sourceBr,businessType));
            if (DTOList == null || DTOList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
            else //if (DTOList.Count > 0)
            {
                string header = "Business Loans Installment Auto Payment Sufficient Listing";
                string sourcebranch = this.view.SourceBr.ToString();
                if (businessType == "")
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), currency, header, sourcebranch, rptName, "ALL" });
                else
                {
                    businessType = DTOList[0].BusinessType;
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), currency, header, sourcebranch, rptName, businessType });
                }
            }
        }

    }
}
