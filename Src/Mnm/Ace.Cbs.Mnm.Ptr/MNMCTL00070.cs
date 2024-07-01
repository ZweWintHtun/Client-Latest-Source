using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00070 : AbstractPresenter, IMNMCTL00070
    {
        #region Properties
        private IMNMVEW00070 view;
        public IMNMVEW00070 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00070 view)
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
        public MNMDTO00039 GetEntity()
        {
            MNMDTO00039 entity = new MNMDTO00039();
            entity.StartDate = this.view.StartDate;
            entity.EndDate = this.view.EndDate;
            entity.SourceBr = this.view.SourceBranch;
            entity.Cur = this.view.Currency;
            entity.TransactionStatus = this.view.ParentFormName;
            entity.TownShipDesp = this.view.Township;       

            return entity;
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
                            MNMDTO00039 DTO = this.GetEntity();
                            bool IsByDateform = false; //To send Report Form Name
                            if (this.view.ParentFormName == "CustomerIDListing(ByDate)")
                            {
                                IsByDateform = true;
                            }
                            IList<MNMDTO00039> DTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00070, IList<MNMDTO00039>>(x => x.GetReportData(DTO, IsByDateform));
                            if (DTOList.Count > 0)
                            {
                                string startDate = this.view.StartDate.ToShortDateString();
                                string endDate = this.view.EndDate.ToShortDateString();
                                string currency = this.view.Currency.ToString();
                                string sourcebranch = this.view.SourceBranch.ToString();
                                string header = string.Empty;

                                if (IsByDateform == true)
                                {
                                    header = "Customer ID Listing (By Date)";
                                    CXUIScreenTransit.Transit("frmMNMVEW000119.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header });
                                }
                                else
                                {
                                    header = "Customer ID Listing (By Township)";
                                    CXUIScreenTransit.Transit("frmMNMVEW000119.ReportViewer", true, new object[] { DTOList, startDate, endDate, currency, sourcebranch, header });
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
