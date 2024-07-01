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
    public class LOMCTL00433 : AbstractPresenter, ILOMCTL00433
    {
        private ILOMVEW00433 view;
        public ILOMVEW00433 View
        {
            get { return this.view; }
            set { this.view = value; }
        }
        private void WriteTo(ILOMVEW00433 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public IList<LOMDTO00427> BindUser()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, IList<LOMDTO00427>>(x => x.SelectAllUser(CurrentUserEntity.BranchCode));
        }

        public IList<LOMDTO00427> BindBlackListApprover()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, IList<LOMDTO00427>>(x => x.SelectAllBlackListMakerCheckerUser(CurrentUserEntity.BranchCode));

        }
        public string DeleteBlackListUser()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, string>(x => x.DeleteBlackListUser(this.View.idArray, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));

        }
        public string SaveBlackListUser()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, string>(x => x.SaveBlackListUser(this.View.UserName, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, this.View.ApproveType));

        }
    }
}
