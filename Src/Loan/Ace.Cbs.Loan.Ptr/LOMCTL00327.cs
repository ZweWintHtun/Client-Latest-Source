using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00327 : AbstractPresenter, ILOMCTL00327
    {
        private ILOMVEW00327 view;
        public ILOMVEW00327 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00327 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public string PLLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName)
        {
            PFMDTO00056 PreviousSys001Dto = new PFMDTO00056();
            DateTime GetPLLateFeesAutoVoucherDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "PLLateFees_AutoPay", sourceBr, true });
            PreviousSys001Dto.HPLateFeesAutoVoucherDate = GetPLLateFeesAutoVoucherDate;
            PreviousSys001Dto.BranchCode = sourceBr;

            DateTime LastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "LAST_SETTLEMENT_DATE", CurrentUserEntity.BranchCode, true });

            PFMDTO00056 Sys001Entity = new PFMDTO00056();
            Sys001Entity.UpdatedUserId = createdUserId;
            Sys001Entity.PLLateFeesAutoVoucherDate = LastSettlementDate;
            Sys001Entity.BranchCode = sourceBr;
            IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(PreviousSys001Dto, Sys001Entity);

            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00311, string>(x => x.PLLateFeesAutoPayVoucherProcess(eno, sourceBr, createdUserId, userName, dvcvList));
            return str;
        }
    }
}
