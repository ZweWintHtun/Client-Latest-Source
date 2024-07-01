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
    public class TLMCTL00059 : AbstractPresenter,ITLMCTL00059
    {
        #region Properties
        private ITLMVEW00059 view;
        public ITLMVEW00059 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }


        private void WireTo(ITLMVEW00059 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetREEntity());
            }
        }
        #endregion
        public TLMDTO00001 GetREEntity()
        {
            TLMDTO00001 reportEntity = new TLMDTO00001();
             return reportEntity;
        }

        public IList<TLMDTO00001> ShowEncashOutstandingReport(string sourceBr)
        {
            IList<TLMDTO00001> reDTO = CXClientWrapper.Instance.Invoke<ITLMSVE00059, IList<TLMDTO00001>>(x => x.SelectEncashOutStanding(sourceBr));
            return reDTO;
        }

    }
}
