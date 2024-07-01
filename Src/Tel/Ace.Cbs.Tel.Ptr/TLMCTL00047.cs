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
    public class TLMCTL00047 : AbstractPresenter, ITLMCTL00047
    {
        #region Properties
        private ITLMVEW00047 view;
        public ITLMVEW00047 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ITLMVEW00047 view)
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

        public IList<TLMDTO00004> HomeOnlineTransactionListingByAllBranch()
        {
            this.iblTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00047, IList<TLMDTO00004>>(x => x.HomeOnlineTransactionListingByAllBranch(this.view.StartDate, this.view.EndDate, this.view.Branch, CurrentUserEntity.BranchCode));
            string sourcebr = CurrentUserEntity.BranchCode;

            if (this.iblTLFList.Count > 0)
            {
                if (!string.IsNullOrEmpty(this.view.BranchCode))
                {
                    var homeOnlineListingByBranch = (from value in this.iblTLFList
                                                     where value.FromBranch == this.view.BranchCode && value.SourceBranchCode == sourcebr
                                                     select value).ToList();
                    return homeOnlineListingByBranch;
                }
                else
                {
                    var homeOnlineListingByBranch = (from value in this.iblTLFList
                                                     where value.SourceBranchCode == sourcebr
                                                     select value).ToList();
                    return homeOnlineListingByBranch;

                   
                }
            }
            else
            { return this.iblTLFList; }
        }

        public IList<TLMDTO00004> ActiveOnlineTransactionListingByAllBranch(string forReversalCase)
        {
            //string forReversalCase = null;
            this.iblTLFList = CXClientWrapper.Instance.Invoke<ITLMSVE00047, IList<TLMDTO00004>>(x => x.ActiveOnlineTransactionListingByAllBranch(this.view.StartDate, this.view.EndDate, this.view.Branch, CurrentUserEntity.BranchCode,forReversalCase));
            string sourcebr = CurrentUserEntity.BranchCode;

            if (this.iblTLFList.Count > 0)
            {
                if (!string.IsNullOrEmpty(this.view.BranchCode))
                {
                    var activeOnlineListingByBranch = (from value in this.iblTLFList
                                                       where value.ToBranch == this.view.BranchCode && value.SourceBranchCode == sourcebr
                                                       select value).ToList();
                    return activeOnlineListingByBranch;
                }
                else
                {

                    var activeOnlineListingByBranch = (from value in this.iblTLFList
                                                       where value.SourceBranchCode == sourcebr
                                                       select value).ToList();
                    return activeOnlineListingByBranch;
                }
            }
            else
            { return this.iblTLFList; }
        }
    }
}
