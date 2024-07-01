//----------------------------------------------------------------------
// <copyright file="TLMCTL00049.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate>09/06/2013</CreatedDate>
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
    public class TLMCTL00049 : AbstractPresenter, ITLMCTL00048
    {
        #region Properties
        private ITLMVEW00048 view;
        public ITLMVEW00048 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ITLMVEW00048 view)
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

        public IList<TLMDTO00004> HomeIncomeListingByAllBranch()
        {
            this.iblTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00048, IList<TLMDTO00004>>(x => x.HomeIncomeListingByAllBranch(this.view.StartDate, this.view.EndDate,CurrentUserEntity.BranchCode,CXCOM00007.Instance.BranchCode));

            if (this.iblTLFList.Count > 0)
            {
                if (!string.IsNullOrEmpty(this.view.BranchCode))
                {
                    var homeIncomeListingByBranch = (from value in this.iblTLFList
                                                     where value.ToBranch == this.view.BranchCode
                                                     select value).ToList();
                    return homeIncomeListingByBranch;
                }
                else
                    return this.iblTLFList;
            }
            else
            { return null; }
        }

        public IList<TLMDTO00004> ActiveIncomeListingByAllBranch()
        {
            this.iblTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00048, IList<TLMDTO00004>>(x => x.ActiveIncomeListingByAllBranch(this.view.StartDate, this.view.EndDate,CurrentUserEntity.BranchCode, CXCOM00007.Instance.BranchCode));

            if (this.iblTLFList.Count > 0)
            {
                if (!string.IsNullOrEmpty(this.view.BranchCode))
                {
                    var activeIncomeListingByBranch = (from value in this.iblTLFList
                                                       where value.ToBranch == this.view.BranchCode
                                                       select value).ToList();
                    return activeIncomeListingByBranch;
                }
                else
                    return this.iblTLFList;
            }
            else
            { return null; }
        }

    }
}
