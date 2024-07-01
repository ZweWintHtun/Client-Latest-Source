//----------------------------------------------------------------------
// <copyright file="TLMCTL00043.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate> 2013-06-18</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Tel.Ptr
{
  public class TLMCTL00043 : AbstractPresenter, ITLMCTL00043
  {
      #region"Wire To"
      private ITLMVEW00043 denoOutstandingReportview;
        public ITLMVEW00043 DenoOutstandingReportView
        {
            get { return this.denoOutstandingReportview; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00043 view)
        {
            if (this.denoOutstandingReportview == null)
            {
                this.denoOutstandingReportview = view;
                this.Initialize(this.denoOutstandingReportview, new PFMDTO00054());
            }
        }
      #endregion

      #region"Method"
        public IList<PFMDTO00054> GetPrintData()
        {
            string sourceBr = CurrentUserEntity.BranchCode;

            IList<PFMDTO00054> DenoOutstandingReportList = new List<PFMDTO00054>();
            DenoOutstandingReportList = CXClientWrapper.Instance.Invoke<ITLMSVE00043, PFMDTO00054>(x => x.SelectAllView(sourceBr));
            return DenoOutstandingReportList;
        }
        #endregion
  }
}
