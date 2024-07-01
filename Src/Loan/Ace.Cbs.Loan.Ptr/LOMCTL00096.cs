using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00096 : AbstractPresenter, ILOMCTL00096
    {
        #region Properties
        private ILOMVEW00096 view;
        public ILOMVEW00096 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00096 view)
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
        public LOMDTO00096 GetEntity()
        {
            LOMDTO00096 entity = new LOMDTO00096();
            entity.SourceBr = this.view.SourceBr;
            entity.Cur = this.view.Currency;
            entity.StartDate = this.view.StartDate;
            entity.EndDate = this.view.EndDate;
            return entity;
        }
        #endregion

        public void Print(string rptName, string sourceBr, string currency, DateTime startDate, DateTime endDate,string stockGroup)
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
                            LOMDTO00096 DTO = this.GetEntity();
                            IList<LOMDTO00096> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00096>>(x => x.GetAllHPRegisterLists(sourceBr, currency, startDate, endDate,stockGroup));
                            if (DTOList.Count > 0)
                            {
                                string sourcebranch = this.view.SourceBr.ToString();
                                string header = "Hire Purchase Register Listing";
                                if (stockGroup == "")
                                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, "ALL" });
                                else
                                {
                                    stockGroup = DTOList[0].StockGroup;
                                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, startDate.ToString("dd/MM/yyyy"), endDate.ToString("dd/MM/yyyy"), rptName, stockGroup }); 
                                }
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
