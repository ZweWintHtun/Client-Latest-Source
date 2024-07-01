//----------------------------------------------------------------------
// <copyright file="MNMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>12/27/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Dmd;
using System.Windows.Forms;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Mnm.Ptr
{
    class MNMCTL00092 : AbstractPresenter, IMNMCTL00092
    {
        #region Properties

        private IMNMVEW00092 view;
        public IMNMVEW00092 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(IMNMVEW00092 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetREEntity());
            }
        }

        #endregion

        public MNMDTO00010 GetREEntity()
        {
            MNMDTO00010 reportEntity = new MNMDTO00010();
            return reportEntity;
        }

        //Added by HMW at 28-08-2019 : [Seperating EOD Process] to show reconcile date (system date)
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }
    }
}
