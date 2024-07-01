using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00428 : AbstractPresenter, ILOMCTL00428
    {
        private ILOMVEW00428 view;
        public ILOMVEW00428 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ILOMVEW00428 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public string SaveBlackLists_ExternalCust(int userId, string branchCode)
        {
            LOMDTO00427 BLLists = new LOMDTO00427();
            BLLists.Name = this.View.Name;
            BLLists.NRC = this.View.NRC;
            BLLists.FatherName = this.View.FName;
            BLLists.CompanyName = this.View.CName;
            BLLists.DOB = Convert.ToDateTime(this.View.DOB);
            BLLists.Address = this.View.Address;
            BLLists.CreatedUserId = userId;
            BLLists.BranchCode = branchCode;
            BLLists.Address = this.View.Address;

            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, string>(x => x.SaveBlackLists_ExternalCust(BLLists));

        }
        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, LOMDTO00427>(x => x.SelectUserMakerCheckerApproveByUserId(CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
        }
    }
}
