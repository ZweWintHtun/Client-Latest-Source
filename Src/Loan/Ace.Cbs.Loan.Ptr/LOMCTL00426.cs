using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00426 : AbstractPresenter, ILOMCTL00426
    {
        private ILOMVEW00426 view;
        public ILOMVEW00426 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00426 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public void CallingForm()
        {
            if(this.View.indexOfCombo == 0 )
                CXUIScreenTransit.Transit("frmLOMVEW00425.BusinessLoan", true, new object[] { View.indexOfCombo});
            else if (this.View.indexOfCombo == 1)
                CXUIScreenTransit.Transit("frmLOMVEW00425.Dealer", true, new object[] { View.indexOfCombo});
            else if (this.View.indexOfCombo == 2)
                CXUIScreenTransit.Transit("frmLOMVEW00425.HirePurchase", true, new object[] { View.indexOfCombo});
            else if (this.View.indexOfCombo == 3)
                CXUIScreenTransit.Transit("frmLOMVEW00425.PersonalLoan", true, new object[] { View.indexOfCombo});
        }
    }
}
