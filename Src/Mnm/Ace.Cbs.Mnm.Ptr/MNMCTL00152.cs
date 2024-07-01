using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00152 : AbstractPresenter, IMNMCTL00152
    {
        #region "Constructor"

     
     
        private string BranchCode { get; set; }

        IList<MNMDTO00077> PrintDataList { get; set; }


        private IMNMVEW00152 view;
        public IMNMVEW00152 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
      
        
          #endregion 
        #region Helper Methods


        private void WireTo(IMNMVEW00152 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }


        private MNMDTO00077 GetViewData()
        {
            MNMDTO00077 ViewData = new MNMDTO00077();
            ViewData.CurrencyCode = this.view.CurrencyCode;
             ViewData.StartDate = this.view.StartDate;
            ViewData.EndDate = this.view.EndDate;
           

            return ViewData;
        }


        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetViewData());
        }

        #endregion

        public void Print(string status)
        { 
           string sourceBr = CurrentUserEntity.BranchCode;


           IList<MNMDTO00077> PrintDataList = CXClientWrapper.Instance.Invoke<IMNMSVE00152, IList<MNMDTO00077>>(x => x.GetReportFixedAutoRenewalOnlyPrinciple(this.View.StartDate, this.View.EndDate, this.View.CurrencyCode, status, sourceBr, this.view.ReportFormName));

          if (PrintDataList != null && PrintDataList.Count > 0)
          {
              if (this.View.ReportFormName.Contains("Fixed Auto Renewal Status Only Principle Listing"))  //status = 12
             {

                 CXUIScreenTransit.Transit("frmMNMVEW00153", new object[] { PrintDataList, this.View.StartDate, this.View.EndDate, this.view.CurrencyCode, status, sourceBr, this.View.ReportFormName });
             }

              else if (this.View.ReportFormName.Contains("Fixed Auto Renewal Status Principle And Interest Listing")) //status = 11
              {
                  CXUIScreenTransit.Transit("frmMNMVEW00153", new object[] { PrintDataList, this.View.StartDate, this.View.EndDate, this.view.CurrencyCode, status, sourceBr, this.View.ReportFormName });
              }
              else if (this.View.ReportFormName.Contains("Fixed Auto Renewal Status Not Auto Renewal Listing"))
              {
                  CXUIScreenTransit.Transit("frmMNMVEW00153", new object[] { PrintDataList, this.View.StartDate, this.View.EndDate, this.view.CurrencyCode, status, sourceBr, this.View.ReportFormName });
              }

              else if (this.View.ReportFormName.Contains("Fixed Auto Renewal All Listing"))
              {
                  CXUIScreenTransit.Transit("frmMNMVEW00153", new object[] { PrintDataList, this.View.StartDate, this.View.EndDate, this.view.CurrencyCode,sourceBr, this.View.ReportFormName });
              }
          }

          else
          {
              CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data for Report
          }
        }

      }
}
