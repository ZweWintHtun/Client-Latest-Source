using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00026 : AbstractPresenter, ITLMCTL00026
    {
        private ITLMVEW00026 view;
        public ITLMVEW00026 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00026 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetDepositBygradeEntity());
            }
        }

        public PFMDTO00042 GetDepositBygradeEntity()
        {
            PFMDTO00042 deposit = new PFMDTO00042();
            deposit.MinimumAmount = this.view.MinimumAmount;
            deposit.MaximumAmount = this.view.MaximumAmount;
            return deposit; 
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public bool Validate()
        {
            return this.ValidateForm(this.GetDepositBygradeEntity());
        }

    }
}
