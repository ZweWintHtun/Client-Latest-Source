using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00018 : AbstractPresenter, ITCMCTL00018
    {
        #region "Property"
        private ITCMVEW00018 _view;
        public ITCMVEW00018 View
        {
            get { return this._view; }
            set { this.WireTo(value); }
        }
        #endregion "Property"
        private void WireTo(ITCMVEW00018 view)
        {
            if (this._view == null)
            {
                this._view = view;
                this.Initialize(this._view, GetNoteChangeDeposit());
            }
        }

        private TLMDTO00015 GetNoteChangeDeposit()
        {
            TLMDTO00015 cashdenodto = new TLMDTO00015();
            cashdenodto.Currency = this.View.Currency;
            cashdenodto.Amount = this.View.Amount;
            return cashdenodto;
        }

        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 26-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }

        public void ClearingForm()
        {
            this.View.Currency = string.Empty;
            this.View.Amount = 0;
            //this.CounterNo = string.Empty;
            this.View.DenoAmount = 0;
            this.View.TotalAmount = 0;
            this.View.DenoData = null;
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public bool ValidateAmount()
        {
            if (this.View.Amount != this.View.TotalAmount)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00037");
                return false;
            }
            return true;
        }
    }
}
