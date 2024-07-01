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
    public class LOMCTL00323 : AbstractPresenter, ILOMCTL00323
    {
        #region Properties
        private ILOMVEW00323 view;
        public ILOMVEW00323 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00323 view)
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

        public LOMDTO00316 GetViewData()
        {
            LOMDTO00316 viewData = new LOMDTO00316();
            viewData.StartDate = this.view.StartDate;
            viewData.EndDate = this.view.EndDate;
            viewData.SourceBr = this.view.SourceBranch;
            viewData.Cur = this.view.Currency;
            return viewData;
        }
        #endregion

        #region Methods
        public void Print()
        {
            if (this.Validate_Form())
            {
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.StartDate))
                {
                    if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.EndDate))
                    {
                        if (this.view.StartDate > this.view.EndDate)
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
                        }
                        else
                        {
                            LOMDTO00316 DTO = this.GetViewData();
                            IList<LOMDTO00316> DTOList = new List<LOMDTO00316>();
                            DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00316, IList<LOMDTO00316>>(x => x.SelectPLRepaymentListing(DTO));
                            if (DTOList.Count > 0)
                            {
                                string startDate = this.view.StartDate.ToShortDateString();
                                string endDate = this.view.EndDate.ToShortDateString();
                                string currency = this.view.Currency.ToString();
                                string sourcebranch = this.view.SourceBranch.ToString();
                                string header = "Personal Loans Repayment Listing";
                                CXUIScreenTransit.Transit("frmLOMVEW00324.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header });
                            }
                            else
                            {
                                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                            }
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00130");//End Date must not be greater than today. 
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV00129");//Start Date must not be greater than today.
                }
            }
        }
        #endregion
    }
}
