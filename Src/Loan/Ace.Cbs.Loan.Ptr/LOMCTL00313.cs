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
    public class LOMCTL00313 : AbstractPresenter, ILOMCTL00313
    {
        private ILOMVEW00313 view;
        public ILOMVEW00313 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00313 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public string PLLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName)
        {
            PFMDTO00056 PreviousSys001Dto = new PFMDTO00056();
            DateTime GetLateFeeDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "PLLateFees_AutoRun", sourceBr, true });
            PreviousSys001Dto.PLMonthlyAutoPayDate = GetLateFeeDate;
            PreviousSys001Dto.BranchCode = sourceBr;
            
            DateTime NextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "NEXT_SETTLEMENT_DATE", CurrentUserEntity.BranchCode, true });

            PFMDTO00056 Sys001Entity = new PFMDTO00056();
            Sys001Entity.UpdatedUserId = createdUserId;
            Sys001Entity.PLMonthlyAutoPayDate = NextSettlementDate.AddDays(-1);
            Sys001Entity.BranchCode = sourceBr;
            IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(PreviousSys001Dto, Sys001Entity);

            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00311, string>(x => x.PLLateFeesCalculationProcess(sourceBr, createdUserId, userName, dvcvList));
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
