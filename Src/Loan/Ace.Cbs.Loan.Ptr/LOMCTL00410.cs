using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00410 : AbstractPresenter, ILOMCTL00410
    {
        #region Properties
        private ILOMVEW00410 view;
        public ILOMVEW00410 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00410 view)
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

        public LOMDTO00405 GetViewData()
        {
            LOMDTO00405 viewData = new LOMDTO00405();
            viewData.StartDate = this.view.StartDate;
            viewData.EndDate = this.view.EndDate;
            viewData.SourceBranchCode = this.view.SourceBranch;
            viewData.Currency = this.view.Currency;
            viewData.BusinessLoansTypes = this.view.BusinessLoansTypes;
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
                        LOMDTO00405 DTO = this.GetViewData();
                        IList<LOMDTO00405> DTOList = new List<LOMDTO00405>();
                        DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<LOMDTO00405>>(x => x.SelectBLServiceChargeslistingByDate(DTO));
                        if (DTOList.Count > 0)
                        {
                            string startDate = this.view.StartDate.ToShortDateString();
                            string endDate = this.view.EndDate.ToShortDateString();
                            string currency = this.view.Currency.ToString();
                            string sourcebranch = this.view.SourceBranch.ToString();
                            string header = "Service Charges Payment Listing";
                            string BLType = this.view.BusinessLoansTypes;
                            CXUIScreenTransit.Transit("frmLOMVEW00411.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header,BLType,this.view.rptname});
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
