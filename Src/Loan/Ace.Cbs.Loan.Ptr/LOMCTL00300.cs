using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00300 : AbstractPresenter, ILOMCTL00300
    {
        #region Properties

        private ILOMVEW00300 view;
        public ILOMVEW00300 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00300 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.CalculatedDate);
            }
        }

        #endregion

        #region Main Methods

        public void CalculatePenalFee()
        {
            if (this.CalculateFarmLoanPenalFee())
            {
                this.View.Successful(CXMessage.MI900241);
            }
            else
            {
                this.View.Failure(CXMessage.MI900242);
            }
        }

        public bool CalculateFarmLoanPenalFee()
        {
            try
            {
                CXClientWrapper.Instance.Invoke<ILOMSVE00300>(x => x.CalculateFarmLoanPenalFee(CurrentUserEntity.BranchCode));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        
        #endregion
    }
}
