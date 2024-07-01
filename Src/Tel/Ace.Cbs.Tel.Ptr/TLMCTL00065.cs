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
    public class TLMCTL00065 : AbstractPresenter, ITLMCTL00065
    {
        #region Properties
        private ITLMVEW00065 view;
        public ITLMVEW00065 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }


        private void WireTo(ITLMVEW00065 view)
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


        public IList<PFMDTO00042> ShowDepositByAccountTypeReport()
        {
            string workstation = Convert.ToString(CurrentUserEntity.WorkStationId);
            string userNo = Convert.ToString(CurrentUserEntity.CurrentUserID);
            IList<PFMDTO00042> reportTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00065, IList<PFMDTO00042>>(x => x.SelectDepositListingByAccountType(workstation, userNo, this.view.StartDate, this.view.EndDate, this.view.AccountSign,CurrentUserEntity.BranchCode,CurrentUserEntity.CurrentUserID));

            return reportTLFList;
        }
    }
}
