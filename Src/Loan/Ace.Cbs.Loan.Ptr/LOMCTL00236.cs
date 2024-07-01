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
    class LOMCTL00236 : AbstractPresenter, ILOMCTL00236
    {
        private ILOMVEW00238 view;
        public ILOMVEW00238 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00238 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Transfer_Transaction_Listing(string rptName, string dateOption, DateTime startDate, DateTime endDate, string voucherStatus, string requiredType, int reverseStatus, string currency, string sourceBr)
        {
            IList<LOMDTO00232> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00232>>(x => x.Transfer_Transaction_Listing(dateOption, startDate, endDate, voucherStatus, requiredType, reverseStatus, currency, sourceBr));
            if (DTOList.Count > 0)
            {
                string transName="";
                string showDate = "";
                string chkreversalStatus = "";
                string byDateOption = "";

                if (reverseStatus == 0) chkreversalStatus = "Without Reversal";
                else chkreversalStatus = "With Reversal";

                if (startDate.ToString("yyyyMMdd") == endDate.ToString("yyyyMMdd"))
                    showDate = "At " + startDate.ToString("dd/MM/yyyy");
                else showDate = "From " + startDate.ToString("dd/MM/yyyy") + " To " + endDate.ToString("dd/MM/yyyy");

                if (voucherStatus == "TRCR") transName = "Credit";
                else if (voucherStatus == "ALL") transName = "Transfer";
                else transName = "Debit";

                string header = transName + " Voucher Listing (By " + dateOption + ")";

                CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, header, rptName, dateOption, voucherStatus, reverseStatus, currency, sourceBr, showDate, chkreversalStatus });
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
            }
        }
    }
}
