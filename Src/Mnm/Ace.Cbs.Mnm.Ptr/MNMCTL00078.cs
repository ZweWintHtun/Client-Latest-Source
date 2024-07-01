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



namespace Ace.Cbs.Mnm.Ptr
{
   public class MNMCTL00078 : AbstractPresenter, IMNMCTL00078
    {
        #region Properties

        private IMNMVEW00078 view;
        public IMNMVEW00078 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        IList<PFMDTO00042> PrintDataList { get; set; }


        #endregion



        #region Helper Method
        private void WireTo(IMNMVEW00078 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }


        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }
        private PFMDTO00042 GetViewData()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();
            ViewData.StartDate = this.view.StartDate;
            ViewData.EndDate = this.view.EndDate;
            //ViewData.SourceCur = this.view.CurrencyCode;
           
            return ViewData;
        }

        //private string workstation = Convert.ToString(CurrentUserEntity.WorkStationId);

        #endregion     
   
       public void Print()
        {
            //string workstation = CurrentUserEntity.WorkStationId;
             string sourceBranchCode = CurrentUserEntity.BranchCode;

             IList<PFMDTO00042> PrintDataList = CXClientWrapper.Instance.Invoke<IMNMSVE00078, IList<PFMDTO00042>>(x => x.GetReportDataListForPORegisterEncash(this.View.StartDate, this.View.EndDate,sourceBranchCode));

              if (PrintDataList != null && PrintDataList.Count > 0)
               {
                   CXUIScreenTransit.Transit("frmMNMVEW00148", true, new object[] { PrintDataList,this.view.StartDate, this.view.EndDate,this.view.FormName});    
               }
            else
             {
               CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data for Report
              }


        }

    }

   }