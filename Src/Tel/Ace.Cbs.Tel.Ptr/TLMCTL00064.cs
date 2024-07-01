using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Linq;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00064 : AbstractPresenter, ITLMCTL00064
    {
        #region Properties
        private ITLMVEW00064 view;
        public ITLMVEW00064 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }


        private void WireTo(ITLMVEW00064 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetReportTLFEntity());
            }
        }
        #endregion

        public PFMDTO00042 GetReportTLFEntity()
        {
            PFMDTO00042 reportEntity = new PFMDTO00042();
            reportEntity.StartDate = this.view.StartDate;
            reportEntity.EndDate = this.view.EndDate;
            return reportEntity;

        }


        public IList<PFMDTO00042> ShowDepositByAccountNoReport()
        {
            string workstation = Convert.ToString(CurrentUserEntity.CurrentUserID);
            IList<PFMDTO00042> reportTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00064, IList<PFMDTO00042>>(x => x.SelectDepositListingByAccountNo(this.view.AccountNo, this.view.StartDate, this.view.EndDate, workstation,CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode));

            return reportTLFList;
        }
    }
}
