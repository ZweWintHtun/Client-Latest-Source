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
    public class LOMCTL00427 :AbstractPresenter , ILOMCTL00427
    {
        private ILOMVEW00427 view;
        public ILOMVEW00427 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00427 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public IList<LOMDTO00427> GetLoansAccountInfoByACNo()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, IList<LOMDTO00427>>(x => x.GetLoansAccountInfoByACNo(this.View.AccountNo));
        }
        public string SaveBlackLists(int userId, string branchCode,string DOB)
        {
            LOMDTO00427 BLLists = new LOMDTO00427();
            BLLists.AccountNo = this.View.AccountNo;
            BLLists.Name = this.View.Name;
            BLLists.NRC=this.View.NRC;
            BLLists.FatherName =this.View.FName ;
            BLLists.CompanyName = this.View.CName ;
            BLLists.AbsentTerm = this.View.AbsentTerm;
            BLLists.CreatedUserId = userId;
            BLLists.BranchCode = branchCode;
            BLLists.Address = this.View.Address;
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427,string>(x => x.SaveBlackLists(BLLists,DOB));
        }
        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00427, LOMDTO00427>(x => x.SelectUserMakerCheckerApproveByUserId(CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode));
        }
    }
}
