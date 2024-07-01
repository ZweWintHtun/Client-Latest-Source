//----------------------------------------------------------------------
// <copyright file="TCMCTL00033.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00033 : AbstractPresenter, ITCMCTL00033
    {
        #region Initialize View
        private ITCMVEW00033 view;
        public ITCMVEW00033 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00033 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, new object());
            }
        }   

        #endregion       

        #region UI Logic

        public void DeliveredChequeNotYetPosted()
        {
            try
            {
                IList<PFMDTO00042> reporttlfs = CXClientWrapper.Instance.Invoke<ITCMSVE00033, IList<PFMDTO00042>>(x => x.SelectNotYetPostedDeliveredCheque(CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, this.view.StartDate, this.view.EndDate,this.workstation ));
                if (reporttlfs.Count > 0)
                {
                    CXUIScreenTransit.Transit("frmTCMVEW00054", true, new object[] { this.view.FormName, this.view.StartDate, this.view.EndDate, reporttlfs });
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00039); //No data for Report.
                }
            }
            catch 
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00039);  //No data for Report.
            }           
        }

        public void DeliveredChequePosted()
        {
            IList<PFMDTO00042> reporttlfs = CXClientWrapper.Instance.Invoke<ITCMSVE00033, IList<PFMDTO00042>>(x => x.SelectPostedDeliveredCheque(CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, this.view.StartDate, this.view.EndDate, this.workstation));
            if (reporttlfs.Count > 0)
            {
                CXUIScreenTransit.Transit("frmTCMVEW00054", true, new object[] {this.view.FormName , this.view.StartDate, this.view.EndDate, reporttlfs });
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00039);  //No data for Report.
            }
        }

         #endregion

        #region Helper Property and Method
        private string workstation = Convert.ToString(CurrentUserEntity.WorkStationId);

        public bool CheckDate()
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.View.StartDate, this.View.EndDate);
            if (date == false)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00123");
            }
            return date;
        }
        #endregion

    }
}
