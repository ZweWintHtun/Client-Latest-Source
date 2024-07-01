using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00215 : AbstractPresenter, ILOMCTL00215
    {
        private ILOMVEW00215 view;
        public ILOMVEW00215 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00215 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public string HPLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName)
        {
            PFMDTO00056 PreviousSys001Dto = new PFMDTO00056();
            DateTime GetHPLateFeesAutoVoucherDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "HPLateFees_AutoPay", sourceBr, true });
            PreviousSys001Dto.HPLateFeesAutoVoucherDate = GetHPLateFeesAutoVoucherDate;
            PreviousSys001Dto.BranchCode = sourceBr;

            DateTime LastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "LAST_SETTLEMENT_DATE", CurrentUserEntity.BranchCode, true });

            PFMDTO00056 Sys001Entity = new PFMDTO00056();
            Sys001Entity.UpdatedUserId = createdUserId;
            Sys001Entity.HPLateFeesAutoVoucherDate = LastSettlementDate;
            Sys001Entity.BranchCode = sourceBr;
            IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(PreviousSys001Dto, Sys001Entity);

            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.HPLateFeesAutoPayVoucherProcess(eno, sourceBr, createdUserId, userName, dvcvList));
            return str;
        }
    }
}
