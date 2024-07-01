//----------------------------------------------------------------------
// <copyright file="TCMCTL00061.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-12-09</CreatedDate>
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
using Ace.Cbs.Tel.Dmd;
namespace Ace.Cbs.Tcm.Ptr
{
   public class TCMCTL00061:AbstractPresenter,ITCMCTL00061
    {
        #region "WireTo"
        private ITCMVEW00061 poprintingreportview;
        public ITCMVEW00061 POPrintingReportView
        {
            get { return this.poprintingreportview; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00061 view)
        {
            if (this.poprintingreportview == null)
            {
                this.poprintingreportview = view;
                this.Initialize(this.poprintingreportview, POPrintingReportView);
            }
        }
        #endregion

        #region "Methods"
        public IList<TLMDTO00001> SelectPOReportLists(IList<TLMDTO00001> relists)
        {
            int currentUserId = CurrentUserEntity.CurrentUserID;
            IList<TLMDTO00001> polists = new List<TLMDTO00001>();
            IList<TLMDTO00001> pos = CXClientWrapper.Instance.Invoke<ITCMSVE00061, IList<TLMDTO00001>>(service => service.SelectPOPrintingList(relists, currentUserId));
            
            return pos;
        }

      
        #endregion

    }
}
