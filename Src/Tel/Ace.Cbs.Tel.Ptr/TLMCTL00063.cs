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
    public class TLMCTL00063 : AbstractPresenter, ITLMCTL00063
    {
        #region Properties
        private ITLMVEW00063 view;
        public ITLMVEW00063 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
      

        private void WireTo(ITLMVEW00063 view)
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

        public IList<PFMDTO00042> ShowDepositAllReport()
        {
            //string workstation = Convert.ToString(CurrentUserEntity.CurrentUserID);
            string workstation=Convert.ToString(CurrentUserEntity.WorkStationId);
            IList<PFMDTO00042> reportTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00063, IList<PFMDTO00042>>(x => x.SelectDepositListingByAll(this.view.StartDate, this.view.EndDate, CurrentUserEntity.CurrentUserID, workstation, CurrentUserEntity.BranchCode));
            return reportTLFList;
        }

        public IList<PFMDTO00042> ShowDepositByCounterReport()
        {
            string workstation = Convert.ToString(CurrentUserEntity.WorkStationId);
            IList<PFMDTO00042> reportTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00063, IList<PFMDTO00042>>(x => x.SelectDepositListingByCounter(this.view.StartDate, this.view.EndDate, CurrentUserEntity.CurrentUserID, workstation, this.view.CounterNo,CurrentUserEntity.BranchCode));

            return reportTLFList;
        }

        public IList<PFMDTO00042> ShowDepositByGrade()
        {
            string workstation = Convert.ToString(CurrentUserEntity.CurrentUserID);
            IList<PFMDTO00042> reportTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00063, IList<PFMDTO00042>>(x => x.SelectDepositListingByGrade(this.view.StartDate, this.view.EndDate, CurrentUserEntity.CurrentUserID, workstation, this.view.MinimumAmount, this.view.MaximumAmount, this.view.AccountSign,CurrentUserEntity.BranchCode));

            return reportTLFList;
        }
        

        public IList<PFMDTO00042> ShowWithdrawByGrade()
        {
            //string workstation = Convert.ToString(CurrentUserEntity.CurrentUserID);
            int workstation = CurrentUserEntity.WorkStationId;
            IList<PFMDTO00042> reportTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00063, IList<PFMDTO00042>>
                (x => x.SelectWithdrawListingByGrade(this.view.StartDate, this.view.EndDate,
                CurrentUserEntity.CurrentUserID, workstation, this.view.MinimumAmount, this.view.MaximumAmount,
                this.view.AccountSign,CurrentUserEntity.BranchCode));

            return reportTLFList;
        }
        

       
    }
}
