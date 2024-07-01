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
using Ace.Cbs.Sam.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Client.Utt;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00068 : AbstractPresenter, ITCMCTL00068
    {

        #region Form Initializer

        private ITCMVEW00068 view;
        public ITCMVEW00068 View
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

        private void WireTo(ITCMVEW00068 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        #endregion

        public void BindSettlementDate()
        {
            //Sys001.SelectSettlementDate
            string nextDate = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate);
            PFMDTO00056 sysDTO = CXClientWrapper.Instance.Invoke<IMNMSVE00004, PFMDTO00056>(x => x.SelectSysDate(nextDate, this.View.SourceBranchCode));
            DateTime tempdate = sysDTO.SysDate.Value;
            //DateTime tempdate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.View.SourceBranchCode);
            this.View.CurrentSettlementDate = tempdate;

            IList<SAMDTO00003> holidayEntity = CXClientWrapper.Instance.Invoke<ITCMSVE00068, SAMDTO00003>(x => x.SelectAllByDate());
            DateTime nextSettlementDate = tempdate.AddDays(1);
            foreach (SAMDTO00003 nextSettlementDateInfo in holidayEntity)
            {
                if (nextSettlementDateInfo.DATE.ToString("yyyy/MM/dd") == nextSettlementDate.ToString("yyyy/MM/dd"))
                    nextSettlementDate = nextSettlementDate.AddDays(1);
            }
            this.View.NextSettlementDate = nextSettlementDate;

            string nexdate = tempdate.ToShortDateString();
            string getdate = DateTime.Now.ToShortDateString();

            if (nexdate != getdate)
            {
                this.View.CutoffStatus = false;
            }

        }

        public void Process()
        {
            //Added by ASDA**
            PFMDTO00056 PreviousSys001Dto = new PFMDTO00056();
            DateTime GetLastSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { "LAST_SETTLEMENT_DATE", this.view.SourceBranchCode ,true});
            DateTime GetNextSettlementDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), this.view.SourceBranchCode ,true});
            PreviousSys001Dto.CurrentSettlementDate = GetLastSettlementDate;
            PreviousSys001Dto.NextSettlementDate = GetNextSettlementDate;
            PreviousSys001Dto.BranchCode = this.view.SourceBranchCode;

            PFMDTO00056 Sys001Entity = new PFMDTO00056();
            Sys001Entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            Sys001Entity.CurrentSettlementDate = this.view.CurrentSettlementDate;
            Sys001Entity.NextSettlementDate = this.view.NextSettlementDate;
            Sys001Entity.BranchCode = this.view.SourceBranchCode;


            IList<DataVersionChangedValueDTO> dvcvList = GetChangedValueOfObject.GetChangedValueList(PreviousSys001Dto, Sys001Entity);
            //end**

            //CXClientWrapper.Instance.Invoke<ITCMSVE00068>(x => x.CutOff(this.View.SourceBranchCode, this.View.NextSettlementDate, this.View.CurrentSettlementDate, CurrentUserEntity.CurrentUserID));
            //CXClientWrapper.Instance.Invoke<ITCMSVE00068>(x => x.CutOff(this.View.SourceBranchCode, this.View.NextSettlementDate, this.View.CurrentSettlementDate, CurrentUserEntity.CurrentUserID, dvcvList));

            #region Added and Modified by HMW (24-May-2019)
            DateTime newNextSettlementDate = Convert.ToDateTime(this.view.NextSettlementDate.ToShortDateString()+ " " + DateTime.Now.TimeOfDay);
            DateTime newLastSettlementDate = Convert.ToDateTime(this.view.CurrentSettlementDate.ToShortDateString() + " " + DateTime.Now.TimeOfDay);
            CXClientWrapper.Instance.Invoke<ITCMSVE00068>(x => x.CutOff(this.View.SourceBranchCode, newNextSettlementDate, newLastSettlementDate, CurrentUserEntity.CurrentUserID, dvcvList));
            #endregion


            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30056); // Cut off process is successful
            }

        }

        //public void Process()
        //{
            
        //    CXClientWrapper.Instance.Invoke<ITCMSVE00068>(x => x.CutOff(this.View.SourceBranchCode, this.View.NextSettlementDate, this.View.CurrentSettlementDate, CurrentUserEntity.CurrentUserID));

        //    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
        //        CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
        //    else
        //        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30056); // Cut off process is successful
            
        //}

        //Added by HMW at 21-08-2019 : [Seperating EOD Process]
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }


    }
}
