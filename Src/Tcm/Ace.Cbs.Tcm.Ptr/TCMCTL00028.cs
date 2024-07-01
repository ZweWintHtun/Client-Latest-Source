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
//using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using System.Windows.Forms;

namespace Ace.Cbs.Tcm.Ptr
{
    class TCMCTL00028 : AbstractPresenter, ITCMCTL00028
    {
        #region Properties
        private ITCMVEW00028 view;
        public ITCMVEW00028 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
        IList<PFMDTO00042> CheckDataList { get; set; }
        IList<PFMDTO00042> PrintDataList { get; set; }
        ICXSVE00010 DataGenerateService { get; set; }

        #endregion

        #region Methods
       
        private void WireTo(ITCMVEW00028 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        public bool Validate()
        {
            return this.ValidateForm(this.GetViewData());
        }

        public PFMDTO00042 GetViewData()
        {
            PFMDTO00042 viewData = new PFMDTO00042();
            viewData.StartDate = this.view.Date;
            viewData.SourceCur = this.view.Currency;
            viewData.SourceBranch = CurrentUserEntity.BranchCode;
            viewData.CreatedUserId = CurrentUserEntity.CurrentUserID;
            return viewData;
        }

        public void ClearCustomErrorMsg()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void Print()
        {
            if (this.Validate())
            {
                IList<PFMDTO00042> printDataList = new List<PFMDTO00042>();
                PFMDTO00042 DataDTO = this.GetViewData();
                string isServiceFalse = "False";

                #region services
                try
                {
                    string workStation = CurrentUserEntity.WorkStationId.ToString();
                    PFMDTO00042 reportData = CXClientWrapper.Instance.Invoke<ITCMSVE00028, PFMDTO00042>(x => x.GetReportData(DataDTO, workStation));
                    if (reportData.ClearingPostStatus == isServiceFalse)
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI00039");// No Data for Print  C:\Users\Haymar\Desktop\CBS V1.6\Src\Tcm\Ace.Cbs.Tcm.Ptr\TCMCTL00028.cs
                    }
                    else
                    {                        
                        if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00014,DataDTO.StartDate) == DialogResult.No)  //There is no cash opening balance for {date}.Do you want to continue?MC00014  /MC30004
                        {
                            return;
                        }
                        else
                        {
                            string header = string.Empty;
                            string tranType = string.Empty;
                            string blText = string.Empty;
                            decimal balance = 0;

                            #region "Credit Data"

                            PrintDataList = CXClientWrapper.Instance.Invoke<ITCMSVE00028, IList<PFMDTO00042>>(x => x.GetDayBookSummaryReport(this.View.Date, "C", workStation, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, DataDTO.SourceCur));  //Credit Side                                                          
                            if (PrintDataList.Count <= 0 || PrintDataList == null)
                            {
                                CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No data for Report.
                                return;
                            }
                            tranType = "Credits";
                            blText = "Opening Balance";
                            balance = Convert.ToDecimal((reportData.ClosingBalance + reportData.Credit) - reportData.Debit);
                            CXUIScreenTransit.Transit("frmTCMDayBookSummaryReport", true, new object[] { PrintDataList, view.Date,this.view.Currency, tranType, balance, blText });

                            #endregion "Credit Data"

                            #region "Debit Data"

                            PrintDataList = CXClientWrapper.Instance.Invoke<ITCMSVE00028, PFMDTO00042>(x => x.GetDayBookSummaryReport(this.View.Date, "D", workStation, CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, DataDTO.SourceCur));  //Debit Side                    
                            if (PrintDataList.Count <= 0 || PrintDataList == null)
                            {
                                CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No data for Report.
                                return;
                            }

                            #endregion "Debit Data"

                            tranType = "Debits";
                            blText = "Closing Balance";
                            balance = Convert.ToDecimal(reportData.ClosingBalance);
                            CXUIScreenTransit.Transit("frmTCMDayBookSummaryReport", true, new object[] { PrintDataList, view.Date, this.view.Currency, tranType, balance, blText });
                        }
                    }
                }
                catch (Exception ex)
                {
                    CXUIMessageUtilities.ShowMessageByCode(ex.Message);
                }
                #endregion
            }

        }

        #endregion
     
       
    }
}
