using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00422 : AbstractPresenter, ILOMCTL00422
    {
        private ILOMVEW00422 view;
        public ILOMVEW00422 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00422 view)
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
    }
}

