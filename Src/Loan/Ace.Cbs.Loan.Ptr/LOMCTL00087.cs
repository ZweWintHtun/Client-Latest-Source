using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00087 : AbstractPresenter, ILOMCTL00087
    {
        private ILOMVEW00087 view;

        public ILOMVEW00087 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00087 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.GroupNo);
            }
        }

        public IList<PFMDTO00078> SelectSolidarityByGroupNo(string groupNo)
        {
            return CXClientWrapper.Instance.Invoke<IPFMSVE00078, IList<PFMDTO00078>>(service => service.SelectByGroupNo(groupNo));
        }

        public IList<LOMDTO00078> SelectFarmLoanByGroupNo(string groupNo)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00078, IList<LOMDTO00078>>(service => service.SelectByGroupNo(groupNo));
        }
    }
}
