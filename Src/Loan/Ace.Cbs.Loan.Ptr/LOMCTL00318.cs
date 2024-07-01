using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00318 : AbstractPresenter, ILOMCTL00318
    {
        #region Properties
        private ILOMVEW00318 view;
        public ILOMVEW00318 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00318 view)
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

            //Added By AAM (08-Dec-2017)
            viewData.CompanyName = this.view.CompanyName;
            viewData.Status = this.view.InterestPaidStatus;

            return viewData;
        }
        #endregion

        #region Methods

        // Added By AAM (08-Dec-2017)
        public IList<string> GetAllPersonalLoansCompanyName(string sourceBr)
        {
            return CXClientWrapper.Instance.Invoke<ILOMSVE00080, IList<string>>(x => x.GetAllPersonalLoansCompanyName(sourceBr));
        }

        public void Print(string companyName,string interestPaidStatus) // Added two parameters by AAM (08-Dec-2017) 
        {
            if (this.Validate_Form())
            {
                //if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.StartDate))
                //{
                    //if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.EndDate))
                    //{
                        //if (this.view.StartDate > this.view.EndDate)
                        //{
                        //    CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
                        //}
                        //else
                        //{
                            LOMDTO00316 DTO = this.GetViewData();
                            IList<LOMDTO00316> DTOList = new List<LOMDTO00316>();
                            DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00316, IList<LOMDTO00316>>(x => x.SelectByDueDateForPLIntDuePreListing(DTO));
                            
                            // start Added By AAM (08-Dec-2017)
                            if (companyName.Length>0)
                                DTOList = DTOList.Where(a => a.CompanyName.ToUpper() == companyName.ToUpper()).ToList();

                            if (interestPaidStatus!="-1")
                            {
                                if (interestPaidStatus == "Paid")
                                    DTOList = DTOList.Where(a => a.Status == "A".ToString()).ToList();
                                else if (interestPaidStatus == "Absent")
                                    DTOList = DTOList.Where(a => a.Status == "".ToString()).ToList();
                                else if (interestPaidStatus == "Need To Pay")
                                    DTOList = DTOList.Where(a => a.Status == null).ToList();
                            }
                            // end Added By AAM (08-Dec-2017)
                            
                            if (DTOList.Count > 0)
                            {
                                string startDate = this.view.StartDate.ToShortDateString();
                                string endDate = this.view.EndDate.ToShortDateString();
                                string currency = this.view.Currency.ToString();
                                string sourcebranch = this.view.SourceBranch.ToString();
                                string header = "Personal Loans Interest Due Pre Listing";

                                if (companyName == "")//Added By AAM (08-Dec-2017)
                                {
                                    if (interestPaidStatus == "" || interestPaidStatus == "-1")//Added By AAM (08-Dec-2017)                                    
                                        CXUIScreenTransit.Transit("frmLOMVEW00319.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header, "ALL", "ALL" });//Added By AAM (08-Dec-2017)                                        
                                    
                                    else
                                        CXUIScreenTransit.Transit("frmLOMVEW00319.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header, "ALL", interestPaidStatus });//Added By AAM (08-Dec-2017)
                                }
                                else
                                {
                                    companyName = DTOList[0].CompanyName; //Added By AAM (08-Dec-2017)
                                    if (interestPaidStatus == ""|| interestPaidStatus == "-1") //Added By AAM (08-Dec-2017)
                                        CXUIScreenTransit.Transit("frmLOMVEW00319.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header, companyName, "ALL" });//Added By AAM (08-Dec-2017)
                                    else
                                        CXUIScreenTransit.Transit("frmLOMVEW00319.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header, companyName, interestPaidStatus });//Added By AAM (08-Dec-2017)
                                }
                                
                            }
                            else
                            {
                                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                            }
                        //}
                    //}
                    //else
                    //{
                    //    CXUIMessageUtilities.ShowMessageByCode("MV00130");//End Date must not be greater than today. 
                    //}
                //}
                //else
                //{
                //    CXUIMessageUtilities.ShowMessageByCode("MV00129");//Start Date must not be greater than today.
                //}
            }
        }
        #endregion
    }
}
