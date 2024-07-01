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
    public class MNMCTL00073 : AbstractPresenter, IMNMCTL00073
    {
        #region Properties   
    
        private IMNMVEW00073 _view;
        public IMNMVEW00073 View
        {
            get{return _view;}
            set{this.WireTo(value);}
        }

        IList<PFMDTO00042> PrintDataList { get; set; }
        
        #endregion

        #region Helper Method
        private void WireTo(IMNMVEW00073 view)
        {
            if(this._view == null)
            {
                this._view = view;
                this.Initialize(this._view,this.GetViewData());
            }
        }

        private PFMDTO00042 GetViewData()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();
            ViewData.StartDate = this._view.StartDate;
            ViewData.EndDate = this._view.EndDate;            
            return ViewData;   
        }
        #endregion     

        public void Print()
        {
            string sourceBranchCode = CurrentUserEntity.BranchCode;
            PrintDataList = CXClientWrapper.Instance.Invoke<IMNMSVE00073, IList<PFMDTO00042>>(x => x.GetReportDataListForPOAndIR(this.View.StartDate, this.View.EndDate, this.View.FormName, this.View.IsTransactionDate, sourceBranchCode));

            if (PrintDataList != null && PrintDataList.Count > 0)
            {

                if (this.View.FormName.Contains("Payment Order Register"))
                {
                    CXUIScreenTransit.Transit("frmMNMVEW00122", new object[] { PrintDataList, this.View.StartDate, this.View.EndDate, this.View.FormName, this.View.IsTransactionDate });
                }
                else if (this.View.FormName.Contains("Payment Order Withdrawal"))
                {
                    CXUIScreenTransit.Transit("frmMNMVEW00123", new object[] { PrintDataList, this.View.StartDate, this.View.EndDate, this.View.FormName, this.View.IsTransactionDate });
                }
                else if (this.View.FormName.Contains("Internal Remittance"))
                {
                    CXUIScreenTransit.Transit("frmMNMVEW00124", new object[] { PrintDataList, this.View.StartDate, this.View.EndDate, this.View.FormName, this.View.IsTransactionDate });
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data for Report
            }
        }
    }
}
