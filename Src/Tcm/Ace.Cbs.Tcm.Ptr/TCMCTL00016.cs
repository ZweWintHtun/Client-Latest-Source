using System;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00016 : AbstractPresenter, ITCMCTL00016
    {
        #region Form Initializer

        private ITCMVEW00016 view;
        public ITCMVEW00016 View
        {
            get
            {
                return this.view;
            }
            set
            {

                this.WireTo(value);
            }
        }

        private void WireTo(ITCMVEW00016 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        #endregion

        #region Main Method

        public void Process()
        {
            //try
            //{
               TLMDTO00012 result = CXClientWrapper.Instance.Invoke<ITCMSVE00016,TLMDTO00012>(x => x.CutOffAndClosing(this.View.SourceBranchCode, this.View.NextSettlementDate, this.View.CurrentSettlementDate, CurrentUserEntity.CurrentUserID));

                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred && String.IsNullOrEmpty(CXClientWrapper.Instance.ServiceResult.MessageCode))
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI900011,new object [] {result.Amount,result.CounterNo});
                else if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred && !String.IsNullOrEmpty(CXClientWrapper.Instance.ServiceResult.MessageCode))
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90010); //Cash closing process is successful!.Please check daily closing reports.
            //}
            //catch (Exception ex)
            //{
            //    CXUIMessageUtilities.ShowMessageByCode(ex.Message);
            //}
        }

        public void BindSettlementDate()
        {
            //Sys001.SelectSettlementDate
            string nextDate = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate);
            PFMDTO00056 sysDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00004, PFMDTO00056>(x => x.SelectSysDate(nextDate, this.View.SourceBranchCode));
            DateTime nexttempdate = sysDTO.SysDate.Value;

            string currDate = "LAST_SETTLEMENT_DATE";
            PFMDTO00056 sysDTO1 = CXClientWrapper.Instance.Invoke<IMNMSVE00004, PFMDTO00056>(x => x.SelectSysDate(currDate, this.View.SourceBranchCode));
            DateTime currttempdate = sysDTO1.SysDate.Value;

            this.View.CurrentSettlementDate = currttempdate;

            this.View.NextSettlementDate = nexttempdate;

        }

        #endregion

    }
}
