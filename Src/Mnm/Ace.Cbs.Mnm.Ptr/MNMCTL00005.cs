using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
  public  class MNMCTL00005 : AbstractPresenter, IMNMCTL00005
    {
        #region Properties

        public MNMCTL00005() { }

        private IMNMVEW00005 view;
        public IMNMVEW00005 ViewData
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(IMNMVEW00005 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view,null);
            }
        }
        #endregion

        #region Method
        public void DailyPosting()
        {
            string workStation=CurrentUserEntity.WorkStationId.ToString();
            int userNo=CurrentUserEntity.CurrentUserID;
            view.ProgressBar =50;
            CXClientWrapper.Instance.Invoke<IMNMSVE00005>(x => x.Posting(view.StartDate, view.Date_time.Value,workStation,userNo, CurrentUserEntity.BranchCode));
            view.ProgressBar = 80;
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {

                view.ProgressBar = 100;
                this.ViewData.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.Clear();
            }
            else
            {
                if (!CXClientWrapper.Instance.ServiceResult.MessageCode.Contains(","))
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                else
                {
                    string[] name = CXClientWrapper.Instance.ServiceResult.MessageCode.Split(",".ToCharArray());
                    
                    CXUIMessageUtilities.ShowMessageByCode(name[0], new object[] { name[1] });
                }
                this.Clear();
            }
        }

        public void Clear()
        {
            this.view.ProgressBar = 0;
            this.view.Progressstatus = false;

        }
       
        #endregion
    }
}
