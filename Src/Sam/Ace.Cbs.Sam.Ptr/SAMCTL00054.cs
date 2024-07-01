using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Sam.Ctr.PTR;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Sam.Ctr.SVE;

namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00054 : AbstractPresenter, ISAMCTL00054
    {
         #region Properties
        public SAMCTL00054() { }
        private ISAMVEW00054 view;
        public ISAMVEW00054 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00054 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        public StateDTO GetViewData()
        {
            StateDTO stateDTO = new StateDTO();
            stateDTO.StateCode = this.view.StateCode;
            return stateDTO;
        }

        #endregion

        public IList<BranchDTO> SelectBranch()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00054, IList<BranchDTO>>(x => x.SelectBranch());
            
        }

        public IList<TLMDTO00032> SelectRmitRate()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00054, IList<TLMDTO00032>>(x => x.SelectRmitRate());
        }


    }
}
