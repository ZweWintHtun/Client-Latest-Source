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
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;


namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00418 : AbstractPresenter, ILOMCTL00418
    {
        private ILOMVEW00418 view;
        public ILOMVEW00418 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00418 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public string BusinessLoansLateFeesAutoPayVoucherProcess(string eno, string sourceBr, int createdUserId, string userName)
        {
            PFMDTO00056 PreviousSys001Dto = new PFMDTO00056();
            DateTime GetBLLateFeesAutoVoucherDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "BLMonthly_AutoPay", sourceBr, true });
            PreviousSys001Dto.BLLateFeesVoucherDate = GetBLLateFeesAutoVoucherDate;
            PreviousSys001Dto.BranchCode = sourceBr;

            DateTime LastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "LAST_SETTLEMENT_DATE", CurrentUserEntity.BranchCode, true });

            PFMDTO00056 Sys001Entity = new PFMDTO00056();
            Sys001Entity.UpdatedUserId = createdUserId;
            Sys001Entity.BLLateFeesVoucherDate = LastSettlementDate;
            Sys001Entity.BranchCode = sourceBr;
            IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(PreviousSys001Dto, Sys001Entity);

            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00403, string>(x => x.BusinessLoansLateFeesAutoPayVoucherProcess(eno, sourceBr, createdUserId, userName, dvcvList));
            return str;
        }

        //Added by HMW at 29-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        //public DateTime GetSystemDate(string sourceBr)
        //{
        //    TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
        //    DateTime systemDate = systemStartInfo.Date;
        //    return systemDate;
        //}

    }
}
