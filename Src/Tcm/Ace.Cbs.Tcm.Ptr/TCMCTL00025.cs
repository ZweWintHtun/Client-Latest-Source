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
    public class TCMCTL00025:AbstractPresenter,ITCMCTL00025
    {
        #region Properties
        private ITCMVEW00025 view;
        public ITCMVEW00025 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
        #endregion

        #region Methods
        private void WireTo(ITCMVEW00025 view)
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
            ViewData.StartDate = this.view.Date;
            ViewData.CurCode = this.view.Currency;
            ViewData.IsWithReversal = this.view.IsWithReversal;
            ViewData.WorkStationId = CurrentUserEntity.WorkStationId;
            ViewData.Status = "S";
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
            if (this.ValidateForm(GetViewData()))
            {
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.Date))
                {
                    IList<PFMDTO00042> PrintDataLists = new List<PFMDTO00042>();
                    PFMDTO00042 DataDTO = this.GetViewData();
                    PrintDataLists = CXClientWrapper.Instance.Invoke<ITCMSVE00025, IList<PFMDTO00042>>(x => x.GetReportData(DataDTO));
                    string header = string.Empty;

                    if (PrintDataLists.Count > 0)
                    {

                        string Date = view.Date.ToString("dd/MM/yyyy");
                        if (this.view.IsWithReversal == true)
                        {
                            header = "Cash Declaration Report With Reversal By Date";
                            CXUIScreenTransit.Transit("frmTCMCashDeclerationReport", true, new object[] { PrintDataLists, header, Date, view.Currency });
                        }
                        else
                        {
                            header = "Cash Declaration Report Without Reversal By Date";
                            CXUIScreenTransit.Transit("frmTCMCashDeclerationReport", true, new object[] { PrintDataLists, header, Date, view.Currency });
                        }

                    }
                    else
                    {
                        //if PrintDataLists is null
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Print.
                    }
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.view.Date);//Require Date is not greater than today.
                    return;
                }
            }
        }
        #endregion
    }
}
