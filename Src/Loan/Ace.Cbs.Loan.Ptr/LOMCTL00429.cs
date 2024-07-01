using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00429 : AbstractPresenter, ILOMCTL00429
    {
        private ILOMVEW00429 view;
        public ILOMVEW00429 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ILOMVEW00429 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public IList<LOMDTO00429> SelectAllBlackListsForApproveReject()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, IList<LOMDTO00429>>(x => x.SelectAllBlackListsForApproveReject());

        }
        public String SaveBlackListsApproveReject()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, String>(x => x.SaveBlackListsApproveReject(this.View.idArray, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, this.View.approveReject));

        }
        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, LOMDTO00427>(x => x.SelectUserMakerCheckerApproveByUserId(CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
        }

    }
}
