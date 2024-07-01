using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd.DTO;


namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00425 : AbstractPresenter,ILOMCTL00425
    {
        private ILOMVEW00425 view;
        public ILOMVEW00425 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00425 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public IList<LOMDTO00423> GetAllCustomerInformation()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<LOMDTO00423>>(x => x.GetAllCustomerInformation(this.View.Name,this.View.NRC,this.View.NameExact,this.View.NrcExact,this.View.ACType,this.View.searchType));
        }
    }
}
