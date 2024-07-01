using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00080 : AbstractPresenter, ILOMCTL00080
    {
        private ILOMVEW00080 view;
        public ILOMVEW00080 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00080 view)
        {
            if (this.view == null)
            {
                this.view = view;
              
            }
        }

        public IList<LOMDTO00080> GetAllDealerInformation(string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<LOMDTO00080>>(x => x.GetAllDealerInformation(sourceBr));
        }

        public void DeleteDealerRegistration(string dealerNo, int createdUserId, string sourceBr)
        {
            CXClientWrapper.Instance.Invoke<ILOMSVE00064>(x => x.Delete(dealerNo, createdUserId, sourceBr));
        }        
    }
}
