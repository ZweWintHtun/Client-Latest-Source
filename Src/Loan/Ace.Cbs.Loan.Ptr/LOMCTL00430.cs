using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00430 : AbstractPresenter, ILOMCTL00430
    {
        private ILOMVEW00430 view;
        public ILOMVEW00430 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ILOMVEW00430 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public IList<LOMDTO00429> SelectAllBlackListsForRemove()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, IList<LOMDTO00429>>(x => x.SelectAllBlackListsForRemove());

        }
        public String SaveBlackListsRemove()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, String>(x => x.SaveBlackListsRemove(this.View.idArray, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, this.View.remove));

        }
        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, LOMDTO00427>(x => x.SelectUserMakerCheckerApproveByUserId(CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
        }

    }
}
