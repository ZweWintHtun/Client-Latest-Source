using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Linq;

namespace Ace.Cbs.Tel.Ptr
{
   public class TLMCTL00057 : AbstractPresenter, ITLMCTL00057
    {
       #region Properties
        private ITLMVEW00057 view;
        public ITLMVEW00057 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }


        private void WireTo(ITLMVEW00057 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetRDEntity());
            }
        }
      
        public TLMDTO00017 GetRDEntity()
        {
            TLMDTO00017 rdEntity = new TLMDTO00017();
            return rdEntity;
        }
       #endregion

        public IList<TLMDTO00017> ShowDrawingOutstandingReport()
        {
            IList<TLMDTO00017> rdDTO = CXClientWrapper.Instance.Invoke<ITLMSVE00057, IList<TLMDTO00017>>(x => x.SelectDrawingOutStanding(CurrentUserEntity.BranchCode));
            return rdDTO;
        }

        public IList<TLMDTO00017> ShowDrawingOutStandingByIncomeOutstand()
        {
            IList<TLMDTO00017> rdDTO = CXClientWrapper.Instance.Invoke<ITLMSVE00057, IList<TLMDTO00017>>(x => x.SelectDrawingOutStandingByIncomeOutstand(CurrentUserEntity.BranchCode));
            return rdDTO;
        }

        public IList<TLMDTO00017> ShowDrawingOutStandingByDrawingAmountOutstand()
        {
            IList<TLMDTO00017> rdDTO = CXClientWrapper.Instance.Invoke<ITLMSVE00057, IList<TLMDTO00017>>(x => x.SelectDrawingOutStandingByDrawingAmountOutstand(CurrentUserEntity.BranchCode));
            return rdDTO;
        }
    }
}
