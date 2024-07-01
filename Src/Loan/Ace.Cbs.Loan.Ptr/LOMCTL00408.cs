using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00408 : AbstractPresenter, ILOMCTL00408
    {
        #region Properties
        private ILOMVEW00408 view;
        public ILOMVEW00408 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00408 view)
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
            viewData.MinimumAmount = this.view.MinimumAmount;
            viewData.MaximumAmount = this.view.MaximumAmount;
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
                        DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<LOMDTO00405>>(x => x.SelectBLlistingByGrade(DTO));
                        if (DTOList.Count > 0)
                        {
                            string startDate = this.view.StartDate.ToShortDateString();
                            string endDate = this.view.EndDate.ToShortDateString();
                            string currency = this.view.Currency.ToString();
                            string sourcebranch = this.view.SourceBranch.ToString();
                            decimal minAmt = this.view.MinimumAmount;
                            decimal maxAmt = this.view.MaximumAmount;
                            string header = "Business Loans listing by Grade";
                            string BLType = this.view.BusinessLoansTypes;
                            CXUIScreenTransit.Transit("frmLOMVEW00409.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, minAmt, maxAmt, header, BLType,this.view.rptname});
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
