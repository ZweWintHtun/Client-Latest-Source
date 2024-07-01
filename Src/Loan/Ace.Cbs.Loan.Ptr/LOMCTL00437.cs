using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00437 : AbstractPresenter, ILOMCTL00437
    {
        private ILOMVEW00437 view;
        public ILOMVEW00437 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ILOMVEW00437 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public IList<LOMDTO00429> SelectAllWarningListsForRemove()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, IList<LOMDTO00429>>(x => x.SelectAllWarningListsForRemove());

        }
        public String SaveWarningListsRemove()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, String>(x => x.SaveWarningListsRemove(this.View.idArray, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, this.View.remove));

        }
        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, LOMDTO00427>(x => x.SelectUserMakerCheckerApproveByUserId(CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
        }
    }
}
