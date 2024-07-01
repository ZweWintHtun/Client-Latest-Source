using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00208 : AbstractPresenter, ILOMCTL00208
    {
        private ILOMVEW00208 view;
        public ILOMVEW00208 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00208 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }
        public string GetHPLateFeesRepayment_Amount(string hpNo, int startTerm, int endTerm, string sourceBr)
        {
            string repayAmount = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.GetHPLateFeesRepayment_Amount(hpNo,startTerm,endTerm,sourceBr));
            return repayAmount;
        }

        public string HPAccountExistsOrValid(string hpNo, string sourceBr)
        {
            string retMsg = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.HPAccountExistsOrValid(hpNo,sourceBr));
            return retMsg;
        }

        public string HPLateFeesRepaymentProcess(string hpNo, int startTerm, int endTerm, decimal totalLateFeesAmount, string eno, string sourceBr, int createdUserId, string userName)
        {
            string retStr = CXClientWrapper.Instance.Invoke<ILOMSVE00096, string>(x => x.HPLateFeesRepaymentProcess(hpNo,startTerm,endTerm,totalLateFeesAmount,eno,sourceBr,createdUserId,userName));
            return retStr;
        }

        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 28-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }
    }
}
