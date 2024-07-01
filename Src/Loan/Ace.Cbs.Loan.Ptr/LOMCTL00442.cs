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
    public class LOMCTL00442 : AbstractPresenter, ILOMCTL00442
    {
        private ILOMVEW00442 view;
        public ILOMVEW00442 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ILOMVEW00442 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public IList<LOMDTO00219> GetLateFeeInfoAllForChecker()
        {
            //return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00219>>(x => x.GetLateFeeInfoByACNo(this.View.AccountNo));
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00219>>(x => x.GetLateFeeInfoAllForChecker());
        }


        public string UpdateLateFeeExceptionInfo(IList<LOMDTO00219> latefeeinfo, string ApproveReject)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.UpdateLateFeeExceptionInfo(latefeeinfo, ApproveReject));
        }

        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00435, LOMDTO00427>(x => x.SelectUserMakerCheckerApproveByUserId(CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
        }
    }
}
