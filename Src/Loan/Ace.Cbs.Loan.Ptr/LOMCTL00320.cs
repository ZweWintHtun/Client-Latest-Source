using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00320 : AbstractPresenter, ILOMCTL00320
    {
        public string showDate;
        #region Properties
        private ILOMVEW00320 view;
        public ILOMVEW00320 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00320 view)
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
            viewData.SourceBr = this.view.SourceBranch;
            viewData.Cur = this.view.Currency;
            viewData.StartDate = this.view.StartDate;
            viewData.EndDate = this.view.EndDate;
            return viewData;
        }
        #endregion

        #region Methods
        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00316 DTO = this.GetViewData();
                IList<LOMDTO00316> DTOList = new List<LOMDTO00316>();
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00316, IList<LOMDTO00316>>(x => x.SelectPLOverdrawnListing(DTO));
                if (DTOList.Count > 0)
                {
                    string currency = this.view.Currency.ToString();
                    string sourcebranch = this.view.SourceBranch.ToString();
                    string header = "Personal Loans Overdrawn A/C Listing For " + DateTime.Now.ToString("MMMM");
                    
                    // Added Date Filter By AAM (28-Feb-2018)
                    if (DTO.StartDate.ToString("yyyyMMdd") == DTO.EndDate.ToString("yyyyMMdd"))
                        showDate = "At " + DTO.StartDate.ToString("dd/MM/yyyy");
                    else
                        showDate = "From " + DTO.StartDate.ToString("dd/MM/yyyy") + " To " + DTO.EndDate.ToString("dd/MM/yyyy");

                    CXUIScreenTransit.Transit("frmLOMVEW00321.ReportViewer", true, new object[] { DTOList, currency, sourcebranch, header,showDate });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
            }
        }
        #endregion
    }
}
