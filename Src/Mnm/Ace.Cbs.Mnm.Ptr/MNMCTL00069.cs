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
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
//using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Ptr
{

    class MNMCTL00069 : AbstractPresenter, IMNMCTL00069
    {
        #region Properties

        IList<PFMDTO00029> lintACList { get; set; }
        private IMNMVEW00069 view;
        public IMNMVEW00069 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion

        #region Helper Methods

        private void WireTo(IMNMVEW00069 view)
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

        public void Print(string type)
        {
            lintACList = CXClientWrapper.Instance.Invoke<IMNMSVE00069, IList<PFMDTO00029>>(x => x.SelectLinkACInfo(type,CurrentUserEntity.BranchCode));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                CXUIScreenTransit.Transit("frmMNMVEW00118LinkAccountReprot", true, new object[] { this.lintACList,type});
            }
        }

        #endregion
    }
}