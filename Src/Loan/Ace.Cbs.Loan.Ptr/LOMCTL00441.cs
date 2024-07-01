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
    public class LOMCTL00441 : AbstractPresenter, ILOMCTL00441
    {
        private ILOMVEW00441 view;
        public ILOMVEW00441 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ILOMVEW00441 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public IList<LOMDTO00219> GetLateFeeInfoByACNo(string AccountNo, string SourceBr)
        {
            //return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00219>>(x => x.GetLateFeeInfoByACNo(this.View.AccountNo));
            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00219>>(x => x.GetLateFeeInfoByACNo(AccountNo,SourceBr));
        }

        public string SaveLateFeeExceptionInfo(IList<LOMDTO00219> LateFeeInfoListToSave)
        {
            //LOMDTO00219 latefeeInfo = new LOMDTO00219();
            //latefeeInfo.Acctno = this.View.AccountNo;

            return CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.SaveLateFeeExceptionInfo(LateFeeInfoListToSave));
        }

        public LOMDTO00427 SelectUserMakerCheckerApproveByUserId()
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00435, LOMDTO00427>(x => x.SelectUserMakerCheckerApproveByUserId(CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode));
        }
    }
}
