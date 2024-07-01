using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;

namespace Ace.Cbs.Tcm.Ptr
{
  public class TCMCTL00054 : AbstractPresenter,ITCMCTL00054
    {
        #region Initialize View
        private ITCMVEW00054 view;
        public ITCMVEW00054 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITCMVEW00054 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, new object());
            }
        }

        #endregion

    }
}
