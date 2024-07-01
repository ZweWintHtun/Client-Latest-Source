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
    class LOMCTL00201 : AbstractPresenter, ILOMCTL00201
    {
        private ILOMVEW00201 view;
        public ILOMVEW00201 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00201 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public string HPMonthlyAutoPaymentProc(string sourceBr, int createdUserId, string userName)
        {
            PFMDTO00056 PreviousSys001Dto = new PFMDTO00056();
            DateTime GetHPAutoPayDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "HPMonthly_AutoPay", sourceBr, true });
            PreviousSys001Dto.HPMonthlyAutoPayDate = GetHPAutoPayDate;
            PreviousSys001Dto.BranchCode = sourceBr;

            DateTime NextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "NEXT_SETTLEMENT_DATE", CurrentUserEntity.BranchCode, true });

            PFMDTO00056 Sys001Entity = new PFMDTO00056();
            Sys001Entity.UpdatedUserId = createdUserId;
            Sys001Entity.HPMonthlyAutoPayDate = NextSettlementDate.AddDays(-1);
            Sys001Entity.BranchCode = sourceBr;
            IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(PreviousSys001Dto, Sys001Entity);

            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.HPMonthlyAutoPaymentProc(sourceBr, createdUserId, userName, dvcvList));
            return str;
        }

        public bool CheckCutOffForToday()
        {
            DateTime LastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "LAST_SETTLEMENT_DATE", CurrentUserEntity.BranchCode, true });

            if (DateTime.Now.ToShortDateString() == LastSettlementDate.ToShortDateString())
            {
                return true;
            }
            return false;
        }

    }
}
