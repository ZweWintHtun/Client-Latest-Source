using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00435 : AbstractPresenter, ILOMCTL00435
    {
        private ILOMVEW00435 view;
        public ILOMVEW00435 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00435 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public string SaveWarningLists(int userId, string branchCode, string DOB)
        {
            LOMDTO00427 WLLists = new LOMDTO00427();
            WLLists.AccountNo = this.View.AccountNo;
            WLLists.Name = this.View.Name;
            WLLists.NRC = this.View.NRC;
            WLLists.FatherName = this.View.FName;
            WLLists.CompanyName = this.View.CName;
            WLLists.AbsentTerm = this.View.AbsentTerm;
            WLLists.CreatedUserId = userId;
            WLLists.BranchCode = branchCode;
            WLLists.Address = this.View.Address;
            return CXClientWrapper.Instance.Invoke<ILOMSVE00435, string>(x => x.SaveWarningLists(WLLists, DOB));
        }

        public IList<LOMDTO00427> GetLoansAccountInfoByACNo()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00435, IList<LOMDTO00427>>(x => x.GetLoansAccountInfoByACNo(this.View.AccountNo));
        }

        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00435, LOMDTO00427>(x => x.SelectUserMakerCheckerApproveByUserId(CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
        }
    }
}
