﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00405 : AbstractPresenter, ILOMCTL00405
    {
        #region Properties
        private ILOMVEW00405 view;
        public ILOMVEW00405 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00405 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }
        #endregion

        #region Helper Method
        //public bool Validate_Form()
        //{
        //    return this.ValidateForm(this.GetViewData());
        //}

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
            viewData.InterestStatusDesp = this.view.InterestPaidStatus;
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
            //if (this.Validate_Form())
            //{
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
                            LOMDTO00406 DTO = this.GetViewData();
                            IList<LOMDTO00406> DTOList = new List<LOMDTO00406>();
                            DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00405, IList<LOMDTO00406>>(x => x.SelectBLInterestDuePrelistingByDueDate(DTO));

                            #region
                            //// start Added By AAM (11-Dec-2017)
                            //if (businessTypes.Length > 0)
                            //    DTOList = DTOList.Where(a => a.BLType.ToUpper() == businessTypes.ToUpper()).ToList();

                            //if (interestPaidStatus != "-1")
                            //{
                            //    if (interestPaidStatus == "Paid")
                            //        DTOList = DTOList.Where(a => a.InterestStatusDesp == "Paid".ToString()).ToList();
                            //    else if (interestPaidStatus == "Absent")
                            //        DTOList = DTOList.Where(a => a.InterestStatusDesp == "Absent".ToString()).ToList();
                            //    else if (interestPaidStatus == "Need To Pay")
                            //        DTOList = DTOList.Where(a => a.InterestStatusDesp == "Need To Pay".ToString()).ToList();
                            //}
                            //// end Added By AAM (11-Dec-2017)
                            #endregion

                            if (DTOList.Count > 0)
                            {
                                string startDate = this.view.StartDate.ToShortDateString();
                                string endDate = this.view.EndDate.ToShortDateString();
                                string currency = this.view.Currency.ToString();
                                string sourcebranch = this.view.SourceBranch.ToString();
                                string header = "Business Loans Interest Due Pre Listing";
                                string BLType = this.view.BusinessLoansTypes;

                                //Added By AAM (11-Dec-2017)
                                if (DTO.BLType == "")
                                {
                                    if (DTO.InterestStatusDesp == "" || DTO.InterestStatusDesp == "-1")
                                        CXUIScreenTransit.Transit("frmLOMVEW00406.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header, BLType, this.view.rptname, "ALL", "ALL" });
                                    else
                                        CXUIScreenTransit.Transit("frmLOMVEW00406.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header, BLType, this.view.rptname, "ALL", DTO.InterestStatusDesp });
                                }
                                else
                                {
                                    DTO.BLType = DTOList[0].BLType;
                                    if (DTO.InterestStatusDesp == "" || DTO.InterestStatusDesp == "-1")
                                        CXUIScreenTransit.Transit("frmLOMVEW00406.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header, BLType, this.view.rptname, DTO.BLType, "ALL" });
                                    else
                                        CXUIScreenTransit.Transit("frmLOMVEW00406.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header, BLType, this.view.rptname, DTO.BLType, DTO.InterestStatusDesp });
                                }

                            }
                            else
                            {
                                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                            }
                        }
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
            //}
        //}
        #endregion
    }
}
