using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Ptr
{

    public class MNMCTL00079 : AbstractPresenter, IMNMCTL00079
    {

        #region Properties

        private IMNMVEW00079 view;
        public IMNMVEW00079 View
        {
            get { return view; }
            set { this.WireTo(value); }
        }

        IList<PFMDTO00042> PrintDataList { get; set; }

        #endregion

        #region Helper Method
        private void WireTo(IMNMVEW00079 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        private PFMDTO00042 GetViewData()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();
            ViewData.StartDate = this.view.StartDate;
            ViewData.EndDate = this.view.EndDate;
            return ViewData;
        }
        #endregion    

        public void Print()
        {
            string sourceBranchCode = CurrentUserEntity.BranchCode;
            PrintDataList = CXClientWrapper.Instance.Invoke<IMNMSVE00079, IList<PFMDTO00042>>(x => x.GetReportDataPOWithdrawlEncash(this.View.StartDate, this.View.EndDate, this.View.FormName,sourceBranchCode));

            if (PrintDataList != null && PrintDataList.Count > 0)
            {

                if (this.View.FormName.Contains("PO Withdrawl(Encash) By Cash Listing"))
                {
                    CXUIScreenTransit.Transit("frmMNMVEW00149", new object[] { PrintDataList, this.View.StartDate, this.View.EndDate, this.View.FormName});
                }
                else if (this.View.FormName.Contains("PO Withdrawl(Encash) By Transfer Listing"))
                {
                    CXUIScreenTransit.Transit("frmMNMVEW00150", new object[] { PrintDataList, this.View.StartDate, this.View.EndDate, this.View.FormName });
                }
                else if (this.View.FormName.Contains("PO Withdrawl(Encash) All Listing"))
                {
                    CXUIScreenTransit.Transit("frmMNMVEW00151", new object[] { PrintDataList, this.View.StartDate, this.View.EndDate, this.View.FormName });
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data for Report
            }
        }




    }
}
