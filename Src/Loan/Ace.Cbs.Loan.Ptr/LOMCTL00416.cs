using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00416 : AbstractPresenter, ILOMCTL00416
    {
        #region Properties
        private ILOMVEW00416 view;
        public ILOMVEW00416 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00416 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }
        #endregion

        #region Helper Method
        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public LOMDTO00406 GetViewData()
        {
            LOMDTO00406 viewData = new LOMDTO00406();
            viewData.StartDate = this.view.StartDate;
            viewData.EndDate = this.view.EndDate;
            viewData.SourceBr = this.view.SourceBranch;
            viewData.Cur = this.view.Currency;
            viewData.BLType = this.view.BusinessLoansTypes;
            return viewData;
        }
        public IList<LOMDTO00001> BindLoansBType()
        {
            IList<LOMDTO00001> LoansBTypeDto = CXClientWrapper.Instance.Invoke<ILOMSVE00011, IList<LOMDTO00001>>(x => x.BindLoansBType());
            return LoansBTypeDto;
        }
        #endregion

        #region Methods
        public void Print()
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
                        LOMDTO00406 DTO = this.GetViewData();
                        IList<LOMDTO00406> DTOList = new List<LOMDTO00406>();
                        DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<LOMDTO00406>>(x => x.SelectBLNPLlistingByNPLDate(DTO));
                        if (DTOList.Count > 0)
                        {
                            string startDate = this.view.StartDate.ToShortDateString();
                            string endDate = this.view.EndDate.ToShortDateString();
                            string currency = this.view.Currency.ToString();
                            string sourcebranch = this.view.SourceBranch.ToString();
                            string BLType = this.view.BusinessLoansTypes;
                            string header = "Business Loans NPL Listing";
                            CXUIScreenTransit.Transit("frmLOMVEW00417.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header, BLType, this.view.rptname });
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
        #endregion
    }
}
