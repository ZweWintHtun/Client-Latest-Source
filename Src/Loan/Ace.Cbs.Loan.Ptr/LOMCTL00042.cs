﻿using System;
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
    public class LOMCTL00042 : AbstractPresenter, ILOMCTL00042
    {
        #region Properties
        private ILOMVEW00042 view;
        public ILOMVEW00042 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00042 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetEntity());
        }
        #endregion

        #region Helper Method
        public LOMDTO00035 GetEntity()
        {
            LOMDTO00035 entity = new LOMDTO00035();
            entity.StartDate = this.view.StartDate;
            entity.EndDate = this.view.EndDate;
            entity.SourceBr = this.view.SourceBranch;
            entity.Cur = this.view.Currency;

            return entity;
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
                            if (this.view.ParentFormName == "Loans Account Close Listing (All)")
                            {
                                LOMDTO00035 DTO = this.GetEntity();
                                IList<LOMDTO00035> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00042, IList<LOMDTO00035>>(x => x.SelectAll(DTO));
                                if (DTOList.Count > 0)
                                {
                                    string startDate = this.view.StartDate.ToShortDateString();
                                    string endDate = this.view.EndDate.ToShortDateString();
                                    string currency = this.view.Currency.ToString();
                                    string sourcebranch = this.view.SourceBranch.ToString();
                                    string header = this.view.ParentFormName.ToString();
                                    CXUIScreenTransit.Transit("frmLOMVEW00043.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header });

                                }
                                else
                                {
                                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                                }
                            }
                            else if (this.view.ParentFormName == "Loans Account Close Listing (Loans Only)")
                            {
                                LOMDTO00035 DTO = this.GetEntity();
                                IList<LOMDTO00035> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00042, IList<LOMDTO00035>>(x => x.SelectLoansOnly(DTO));
                                if (DTOList.Count > 0)
                                {
                                    string startDate = this.view.StartDate.ToShortDateString();
                                    string endDate = this.view.EndDate.ToShortDateString();
                                    string currency = this.view.Currency.ToString();
                                    string sourcebranch = this.view.SourceBranch.ToString();
                                    string header = this.view.ParentFormName.ToString();
                                    CXUIScreenTransit.Transit("frmLOMVEW00043.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header });

                                }
                                else
                                {
                                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                                }
                            }
                            else if (this.view.ParentFormName == "Loans Account Close Listing (OD Only)")
                            {
                                LOMDTO00035 DTO = this.GetEntity();
                                IList<LOMDTO00035> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00042, IList<LOMDTO00035>>(x => x.SelectODOnly(DTO));
                                if (DTOList.Count > 0)
                                {
                                    string startDate = this.view.StartDate.ToShortDateString();
                                    string endDate = this.view.EndDate.ToShortDateString();
                                    string currency = this.view.Currency.ToString();
                                    string sourcebranch = this.view.SourceBranch.ToString();
                                    string header = this.view.ParentFormName.ToString();
                                    CXUIScreenTransit.Transit("frmLOMVEW00043.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header });

                                }
                                else
                                {
                                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                                }
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