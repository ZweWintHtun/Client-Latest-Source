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
    public class LOMCTL00436 : AbstractPresenter, ILOMCTL00436
    {
        private ILOMVEW00436 view;
        public ILOMVEW00436 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ILOMVEW00436 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public IList<LOMDTO00429> SelectAllWarningListsForApproveReject()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00435, IList<LOMDTO00429>>(x => x.SelectAllWarningListsForApproveReject());

        }
        public String SaveWarningListsApproveReject()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00435, String>(x => x.SaveWarningListsApproveReject(this.View.idArray, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, this.View.approveReject));

        }
        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, LOMDTO00427>(x => x.SelectUserMakerCheckerApproveByUserId(CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
        }
    }
}
