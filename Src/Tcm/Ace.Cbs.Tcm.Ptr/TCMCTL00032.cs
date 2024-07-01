using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00032:AbstractPresenter,ITCMCTL00032
    {
        #region Properties
        private ITCMVEW00032 view;
        public ITCMVEW00032 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
        #endregion

        #region Methods
        private void WireTo(ITCMVEW00032 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        public PFMDTO00042 GetViewData()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();
            ViewData.StartDate = this.view.StartDate;
            ViewData.EndDate = this.view.EndDate;
            ViewData.CreatedUserId = CurrentUserEntity.CurrentUserID;
            ViewData.SourceBranch = CurrentUserEntity.BranchCode;
            return ViewData;
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void Print()
        {
                //if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.StartDate))
                //{
                //    if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.EndDate))
                //    {
                        bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.view.StartDate, this.view.EndDate);
                        
                        if (date == false)
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
                        }
                        //if (this.view.StartDate > this.view.EndDate)
                        //{
                        //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
                        //}
                        else
                        {
                            IList<PFMDTO00020> PrintDataLists = new List<PFMDTO00020>();
                            PFMDTO00042 DataDTO = this.GetViewData();
                            PrintDataLists = CXClientWrapper.Instance.Invoke<ITCMSVE00032, IList<PFMDTO00020>>(x => x.GetReportData(DataDTO));

                            if (PrintDataLists.Count > 0)
                            {
                                string StartDate = view.StartDate.ToString("dd/MM/yyyy");
                                string EndDate = view.EndDate.ToString("dd/MM/yyyy");

                                CXUIScreenTransit.Transit("frmTCMWithdrawalChequeReport", true, new object[] { PrintDataLists, StartDate, EndDate });
                            }
                            else
                            {
                                //if PrintDataLists is null
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Print.
                            }
                        }
                //    }
                //    else
                //    {
                //        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00130");//End Date must not be greater than today.
                //    }
                //}
                //else
                //{
                //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00129");//Start Date must not be greater than today.
                //}
          
            
        }
        #endregion
    }
}

