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

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00403 : AbstractPresenter, ILOMCTL00403
    {
        private ILOMVEW00403 view;
        public ILOMVEW00403 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00403 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public string BusinessLoansLateFeesCalculationProcess(string sourceBr, int createdUserId, string userName)
        {
            PFMDTO00056 PreviousSys001Dto = new PFMDTO00056();
            DateTime GetLateFeeDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "BLLateFees_AutoRun", sourceBr, true });
            PreviousSys001Dto.BLInterestDate = GetLateFeeDate;
            PreviousSys001Dto.BranchCode = sourceBr;

            PFMDTO00056 Sys001Entity = new PFMDTO00056();
            Sys001Entity.UpdatedUserId = createdUserId;
            Sys001Entity.BLInterestDate = DateTime.Now;
            Sys001Entity.BranchCode = sourceBr;
            IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(PreviousSys001Dto, Sys001Entity);

            string str = CXClientWrapper.Instance.Invoke<ILOMSVE00403, string>(x => x.BusinessLoansLateFeesCalculationProcess(sourceBr, createdUserId, userName, dvcvList,this.view.nextSettlementdate.AddDays(-1)));
            return str;
        }
    }
}
