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
    public class LOMCTL00040 : AbstractPresenter, ILOMCTL00040
    {
        #region Properties
        private ILOMVEW00040 view;
        public ILOMVEW00040 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00040 view)
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
            entity.Loans_Type = this.view.ParentFormName;

            return entity;
        }

        public string GetLoansType(string parentFormName)
        {
            if (!String.IsNullOrEmpty(parentFormName))
            {
                switch (parentFormName)
                {
                    case "LB":
                        return "Lands and Building";
                    case "PG":
                        return "Personal Guarantee";
                    case "PL":
                        return "Pledge";
                    case "HP":
                        return "Hypothecation";
                    case "GJ":
                        return "Gold and Jewellery";
                    case "All":
                        return "All";
                }
            }
            return null;
        }
        #endregion

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
                            LOMDTO00035 DTO = this.GetEntity();
                            string loansType = this.GetLoansType(this.view.ParentFormName);

                            IList<LOMDTO00035> DTOList = new List<LOMDTO00035>();

                            if (loansType == "All")
                            {
                                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00035, IList<LOMDTO00035>>(x => x.SelectAllData(DTO));
                            }
                            else
                            {
                                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00035, IList<LOMDTO00035>>(x => x.SelectAllDataByLoansType(DTO));
                            }
                            if (DTOList.Count > 0)
                            {
                                string startDate = this.view.StartDate.ToShortDateString();
                                string endDate = this.view.EndDate.ToShortDateString();
                                string currency = this.view.Currency.ToString();
                                string sourcebranch = this.view.SourceBranch.ToString();
                                string header = "Loans And Overdraft Listing";
                                CXUIScreenTransit.Transit("frmLOMVEW00037.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header, loansType });

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
    }
}