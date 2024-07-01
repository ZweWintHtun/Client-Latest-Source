using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00314 : AbstractPresenter, ILOMCTL00314
    {
        #region Properties
        private ILOMVEW00314 view;
        public ILOMVEW00314 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00314 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }
        #endregion

        #region Helper Method
        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetViewData());
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public LOMDTO00314 GetViewData()
        {
            LOMDTO00314 viewData = new LOMDTO00314();
            viewData.SelectedDate = this.view.SelectedDate;
            viewData.IsExpiredDate = this.view.SelectedDate;
            viewData.SourceBr = this.view.SourceBranch;
            //viewData.Cur = this.view.Currency;
            return viewData;
        }
        #endregion

        #region Methods
        public void Print()
        {
            if (this.Validate_Form())
            {
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.SelectedDate))
                {
                    LOMDTO00314 DTO = this.GetViewData();
                    IList<LOMDTO00314> DTOList = new List<LOMDTO00314>();
                    DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00314, IList<LOMDTO00314>>(x => x.SelectAll(DTO));
                    if (DTOList.Count > 0)
                    {
                        string selectedDate = this.view.SelectedDate.ToShortDateString();
                        string sourcebranch = this.view.SourceBranch.ToString();                        
                        string header = "Expired Land Lease Listing";
                        CXUIScreenTransit.Transit("frmLOMVEW00315.ReportViewer", true, new object[] { DTOList, selectedDate, sourcebranch, header });
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV90169");//Date must not be greater than today. 
                }
            }
        }
        #endregion
    }
}
