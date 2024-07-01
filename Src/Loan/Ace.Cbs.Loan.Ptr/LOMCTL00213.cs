using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00213 : AbstractPresenter, ILOMCTL00213
    {
        private ILOMVEW00213 view;
        public ILOMVEW00213 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00213 view)
        {
            if (this.view == null)
            {
                this.view = view;
            }
        }

        public void Print(string rptName, DateTime startDate, DateTime endDate, string currency, string sourceBr,string stockGroup,string interestPaidStatus)
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
                        IList<LOMDTO00212> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00212>>(x => x.GetHPInterest_Due_PreListing(startDate, endDate, currency, sourceBr, stockGroup, interestPaidStatus));
                        if (DTOList.Count > 0)
                        {
                            string header = "Hire Purchase Interest Due PreListing";
                            if (stockGroup == "")
                            {
                                if (interestPaidStatus == "")
                                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, "ALL", "ALL" });
                                else
                                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, "ALL", interestPaidStatus });
                            }
                            else
                            {
                                stockGroup = DTOList[0].StockGroup;
                                if (interestPaidStatus == "")
                                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, stockGroup, "ALL" });
                                else
                                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourceBr, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, stockGroup, interestPaidStatus });
                            }
                        }
                        else
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                        }
                    //}
                //}
            //}
        }

    }
}
