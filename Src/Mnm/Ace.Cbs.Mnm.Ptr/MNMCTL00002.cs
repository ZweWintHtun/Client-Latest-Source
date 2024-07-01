using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using System.Windows.Forms;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00002 : AbstractPresenter, IMNMCTL00002
    {

        #region Properties
        public MNMCTL00002() { }
        private IMNMVEW00002 view;
        public IMNMVEW00002 MonthAfterViewData
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
        private void WireTo(IMNMVEW00002 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetAfterDayCloseEntity());
            }
        }

        private MNMDTO00001 GetAfterDayCloseEntity()
        {
            MNMDTO00001 entity = new MNMDTO00001();
            //entity.Month = view.Month;
            //entity.Year = view.Year;
            entity.Date_time = view.Date_time;

            return entity;
        }
        #endregion

        #region Methods
        public void CheckClosing()
        {
            string sourceBr = CurrentUserEntity.BranchCode;
            MNMDTO00001 syspostDTO = this.GetAfterDayCloseEntity();
            CXClientWrapper.Instance.Invoke<IMNMSVE00002>(x => x.CheckClosing(syspostDTO, sourceBr));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.view.butProcess_Enable = false;
            }
            else
            {
                this.view.butProcess_Enable = true;
            }
        }
        public void MonthAfter()
        {
            MNMDTO00001 syspostDTO = this.GetAfterDayCloseEntity();


            IList<string> MessageList = CXClientWrapper.Instance.Invoke<IMNMSVE00002, IList<string>>(x => x.MonthAfterCalcuate(syspostDTO, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID));
            this.view.ProgressBarStyle = ProgressBarStyle.Blocks;
            view.ProgressBar = 50;
            view.ProgressBar = 75;
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.view.butProcess_Enable = false;
                view.ProgressBar = 100;
                if (MessageList != null || MessageList.Count > 0)
                {
                    foreach (string msg in MessageList)
                    {
                        CXUIMessageUtilities.ShowMessageByCode(msg);
                    }
                }
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90051); //Monthly Closing Successfully Finished.
                //string result = CXClientWrapper.Instance.Invoke<IMNMSVE00002, string>(x => x.DatabaseBackupAfterMonthClose());
                //if (!String.IsNullOrEmpty(result))
                //{
                //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30042);
                //}
                //else
                //{
                    //this.view.butProcess_Enable = false;
                    //if (MessageList != null || MessageList.Count > 0)
                    //{
                    //    foreach (string msg in MessageList)
                    //    {
                    //        CXUIMessageUtilities.ShowMessageByCode(msg);
                    //    }
                    //}
                //}
                this.ProgressClear();
            }
            else
            {
                this.view.butProcess_Enable = false;
                if (MessageList != null || MessageList.Count > 0)
                {
                    foreach (string msg in MessageList)
                    {
                        CXUIMessageUtilities.ShowMessageByCode(msg);
                    }
                }

                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90051); //Monthly Closing Successfully Finished.
                this.ProgressClear();
            }
        }

        public void ProgressClear()
        {
            this.view.ProgressBar = 0;
            this.view.Progressstatus = false;

        }

        //Added by HMW at 16-10-2019 : [Seperating EOD Process] To get system date (not PC date)
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }
        #endregion

    }
}
