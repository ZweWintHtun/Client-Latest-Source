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
    public class LOMCTL00065 : AbstractPresenter, ILOMCTL00065
    {
        #region Properties
        private ILOMVEW00065 view;
        public ILOMVEW00065 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00065 view)
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
        public LOMDTO00013 GetEntity()
        {
            LOMDTO00013 entity = new LOMDTO00013();
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
                            if (this.view.ParentFormName == "Legal Sue Case List")
                            {
                                LOMDTO00013 DTO = this.GetEntity();
                                IList<LOMDTO00013> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00063, IList<LOMDTO00013>>(x => x.SelectLegalSueCaseList(DTO));
                                if (DTOList.Count > 0)
                                {
                                    string startDate = this.view.StartDate.ToShortDateString();
                                    string endDate = this.view.EndDate.ToShortDateString();
                                    string currency = this.view.Currency.ToString();
                                    string sourcebranch = this.view.SourceBranch.ToString();
                                    string header = this.view.ParentFormName.ToString();
                                    CXUIScreenTransit.Transit("frmLOMVEW00066.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header });
                                }
                                else
                                {
                                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                                }
                            }
                            else if (this.view.ParentFormName == "Legal Sue Case Close")
                            {
                                LOMDTO00013 DTO = this.GetEntity();
                                IList<LOMDTO00013> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00063, IList<LOMDTO00013>>(x => x.SelectLegalSueCaseClose(DTO));
                                if (DTOList.Count > 0)
                                {
                                    string startDate = this.view.StartDate.ToShortDateString();
                                    string endDate = this.view.EndDate.ToShortDateString();
                                    string currency = this.view.Currency.ToString();
                                    string sourcebranch = this.view.SourceBranch.ToString();
                                    string header = this.view.ParentFormName.ToString();
                                    CXUIScreenTransit.Transit("frmLOMVEW00066.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header });
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
