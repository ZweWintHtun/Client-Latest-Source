using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00071 : AbstractPresenter, IMNMCTL00071
    {
        #region Properties
        private IMNMVEW00071 view;
        public IMNMVEW00071 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00071 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, GetSavingAccruedInterestEntity());
            }
        }

        public MNMDTO00071 GetSavingAccruedInterestEntity()
        {
            MNMDTO00071 obj = new MNMDTO00071();
            obj.StartDate = this.view.StartDate;
            obj.EndDate = this.view.EndDate;
            return obj;
        }
       
        #endregion

        public IList<MNMDTO00071> SelectSavingAccuredInterestAll()
        {
            return CXClientWrapper.Instance.Invoke<IMNMSVE00071, IList<MNMDTO00071>>(x => x.SelectSavingAccuredInterestAll());
        }

        public IList<MNMDTO00071> SelectSavingAccuredInterestBetweenStartDateandEndDate()
        {
            return CXClientWrapper.Instance.Invoke<IMNMSVE00071, IList<MNMDTO00071>>(x => x.SelectSavingAccuredInterestByStartDateandEndDate(this.view.StartDate,this.view.EndDate));
        }

        public IList<MNMDTO00071> SelectSavingAccuredInterestByCash()
        {
            return CXClientWrapper.Instance.Invoke<IMNMSVE00071, IList<MNMDTO00071>>(x => x.SelectSavingAccuredByCash(this.view.StartDate, this.view.EndDate));
        }

        public IList<MNMDTO00071> SelectSavingAccuredInterestByTransfer()
        {
            return CXClientWrapper.Instance.Invoke<IMNMSVE00071, IList<MNMDTO00071>>(x => x.SelectSavingAccuredByTransfer(this.view.StartDate, this.view.EndDate));
        }       
    }
}
