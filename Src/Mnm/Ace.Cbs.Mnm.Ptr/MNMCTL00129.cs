//----------------------------------------------------------------------
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>11/01/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00129 : AbstractPresenter, IMNMCTL00129
    {
        #region Properties

        IList<PFMDTO00029> linkAutoList { get; set; }

        private IMNMVEW00129 view;
        public IMNMVEW00129 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion

        #region Helper Methods

        private void WireTo(IMNMVEW00129 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetVlaidateData());
            }
        }

        private PFMDTO00029 GetVlaidateData()
        {
            PFMDTO00029 ValidateDto = new PFMDTO00029();
            return ValidateDto;
        }

        public IList<PFMDTO00029> SelectLinkAutoPriority(string SourceBr)
        {
            linkAutoList = CXClientWrapper.Instance.Invoke<IMNMSVE00129, IList<PFMDTO00029>>(x => x.SelectLinkAutoPriorityInfo(SourceBr));
           
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            return linkAutoList;
       
        }

        #endregion
    }
}