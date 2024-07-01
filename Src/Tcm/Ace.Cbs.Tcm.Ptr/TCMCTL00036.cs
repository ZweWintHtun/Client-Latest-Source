//----------------------------------------------------------------------
// <copyright file="TCMCTL00046.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-02-06</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;


namespace Ace.Cbs.Tcm.Ptr
{
    /// <summary>
    /// Clearing Delievered Reversal Enquiry Controller
    /// </summary>
   public class TCMCTL00036:AbstractPresenter,ITCMCTL00036
    {
        #region "WireTo"
        private ITCMVEW00036 clearingdeliveredreversallistingView;
        public ITCMVEW00036 ClearingdeliveredReversalView
        {
            get{
                return this.clearingdeliveredreversallistingView; 
            }
            set
            {
                this.WireTo(value);
            }
        }
        private void WireTo(ITCMVEW00036 view)
        {
            if (this.clearingdeliveredreversallistingView == null)
            {
                this.clearingdeliveredreversallistingView = view;
                this.Initialize(this.clearingdeliveredreversallistingView, ClearingdeliveredReversalView);
            }
        }
        #endregion

        #region "Methods"
        public void GetClearingDeliveredReversalListing()
        {
            string userno = CurrentUserEntity.WorkStationId.ToString();
            string clrDeliverReversalListing="Clearing Delivered Reversal Listing Report";
            IList<PFMDTO00042> ReportTLFDTOList = CXClientWrapper.Instance.Invoke<ITCMSVE00036, IList<PFMDTO00042>>(x => x.GetClearingDeliveredReverseService(this.clearingdeliveredreversallistingView.StartDate, this.clearingdeliveredreversallistingView.EndDate,userno,CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode));
            if (ReportTLFDTOList.Count != 0)
            {
                CXUIScreenTransit.Transit("frmTCMVEW00057", true, new object[] { ReportTLFDTOList, this.clearingdeliveredreversallistingView.StartDate, this.clearingdeliveredreversallistingView.EndDate,clrDeliverReversalListing});
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
            }
        }

        void IPresenter.ClearErrors()
        {
            throw new NotImplementedException();
        }

        public bool CheckDate()
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.clearingdeliveredreversallistingView.StartDate, this.clearingdeliveredreversallistingView.EndDate);
            if (date == false)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00123");
            }
            return date;
        }
        #endregion
    }
}
