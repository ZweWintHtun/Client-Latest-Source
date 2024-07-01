//----------------------------------------------------------------------
// <copyright file="TLMCTL00046.cs" company="ACE Data Systems">
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
using System.Linq;

namespace Ace.Cbs.Tel.Ptr
{
    /// <summary>
    /// IBL Transaction Listing By Branch Controller
    /// </summary>
    public class TLMCTL00046 : AbstractPresenter, ITLMCTL00046
    {
        #region View & Properties
        private ITLMVEW00046 view;
        public ITLMVEW00046 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }        
        private void WireTo(ITLMVEW00046 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetIBLTLFEntity());
            }
        }
        public TLMDTO00004 GetIBLTLFEntity()
        {
            TLMDTO00004 ibltlfEntity = new TLMDTO00004();
            return ibltlfEntity;
        }
        IList<TLMDTO00004> iblTLFList { get; set; }
        #endregion

        #region UI Logic
        public IList<TLMDTO00004> HomeTransactionListingByBranch()
        {
            this.iblTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00046, IList<TLMDTO00004>>(x => x.HomeTransactionListinByBranch(this.view.StartDate, this.view.EndDate, this.view.TranType, this.view.BranchCode, CurrentUserEntity.BranchCode, this.view.IsReversal));
            return this.iblTLFList;
        }
        public IList<TLMDTO00004> ActiveTransactionListingByBranch()
        {
            this.iblTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00046, IList<TLMDTO00004>>(x => x.ActiveTransactionListinByBranch(this.view.StartDate, this.view.EndDate, this.view.TranType, this.view.BranchCode, CurrentUserEntity.BranchCode, this.view.IsReversal));
            return this.iblTLFList;
        }
        #endregion
    }
}
