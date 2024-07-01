using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Dmd;

using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00034 : AbstractPresenter, ILOMCTL00034
    {

        private ILOMVEW00034 loanview;
        public ILOMVEW00034 View
        {
            get { return this.loanview; }
            set { this.WireTo(value); }
        }
        private void WireTo(ILOMVEW00034 view)
        {
            if (this.loanview == null)
            {
                this.loanview = view;
                //this.Initialize(this.loanview, this.GetEntity());
            }
        }
        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetEntity());
        }
        #region Helper Methods
        private LOMDTO00034 GetEntity()
        {
            LOMDTO00034 entity = new LOMDTO00034();
            entity.StartDate = this.loanview.StartDate;
            entity.EndDate = this.loanview.EndDate;
            entity.SourceBr = this.loanview.SourceBranch;
            entity.CUR = this.loanview.Currency;
            //entity.TransactionStatus = this.view.ParentFormName;

            return entity;
        }
        #endregion

        public void Print(string LoanType,string formname)
        {            
            IList<LOMDTO00034> ReportList = new List<LOMDTO00034>();
            IList<LOMDTO00204> BLInfoReportList = new List<LOMDTO00204>();
            //if (this.Validate_Form())
            //{
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.loanview.StartDate))
                {
                    if (!CXCOM00006.Instance.IsExceedTodayDate(this.loanview.EndDate))
                    {
                        if (this.loanview.StartDate > this.loanview.EndDate)
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
                        }
                        else
                        {
                            //if (LoanType == "All")
                            //{
                            //    //ReportList = CXClientWrapper.Instance.Invoke<ILOMSVE00034, IList<LOMDTO00034>>(x => x.SelectLoanListingAll(this.loanview.StartDate, this.loanview.EndDate, this.loanview.SourceBranch, this.loanview.Currency));                                                                                  
                            //}
                            //else
                            //{
                            //    //ReportList = CXClientWrapper.Instance.Invoke<ILOMSVE00034, IList<LOMDTO00034>>(x => x.SelectLoanListing(LoanType, this.loanview.StartDate, this.loanview.EndDate, this.loanview.SourceBranch, this.loanview.Currency));                                                                                  
                            //    BLInfoReportList = CXClientWrapper.Instance.Invoke<ILOMSVE00034, IList<LOMDTO00204>>(x => x.GetBLInfoListingByDateRange(this.loanview.StartDate, this.loanview.EndDate, this.loanview.SourceBranch));
                            //}
                            BLInfoReportList = CXClientWrapper.Instance.Invoke<ILOMSVE00034, IList<LOMDTO00204>>(x => x.GetBLInfoListingByDateRange(this.loanview.StartDate, this.loanview.EndDate, this.loanview.SourceBranch, LoanType));
                            if (BLInfoReportList != null)//ReportList !
                            {
                                if (BLInfoReportList.Count > 0)
                                {
                                    string startDate = this.loanview.StartDate.ToShortDateString();
                                    string endDate = this.loanview.EndDate.ToShortDateString();
                                    //CXUIScreenTransit.Transit("frmLOMVEW00038", true, new object[] { ReportList, startDate, endDate, loanview.Currency, loanview.SourceBranch, "Loans Registration Listing (" + formname + ")" });
                                    CXUIScreenTransit.Transit("frmLOMVEW00038", true, new object[] { BLInfoReportList, startDate, endDate, loanview.Currency, loanview.SourceBranch, "Business Loans Information Listing With Currency (" + this.loanview.Currency + ") From " + this.loanview.StartDate.ToString("dd/MM/yyyy") + " To " + this.loanview.EndDate.ToString("dd/MM/yyyy") + "", LoanType });
                                }
                                else
                                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report.
                            }
                            else
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report.
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
            //}
        }
    }
}
