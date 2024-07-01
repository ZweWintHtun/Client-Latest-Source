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
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00330 : AbstractPresenter, ILOMCTL00330
    {

        #region Properties
        private ILOMVEW00330 view;
        public ILOMVEW00330 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00330 view)
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

        public TLMDTO00018 GetViewData()
        {
            TLMDTO00018 viewData = new TLMDTO00018();
            viewData.SourceBranchCode = this.view.SourceBranch;
            viewData.Currency = this.view.Currency;
            return viewData;
        }
        #endregion

        #region Methods
        public void Print()
        {
            if (this.Validate_Form())
            {
                TLMDTO00018 DTO = this.GetViewData();
                IList<TLMDTO00018> DTOList = new List<TLMDTO00018>();
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<TLMDTO00018>>(x => x.GetBLVrOutstandingListing(DTO));
                if (DTOList.Count > 0)
                {
                    string currency = this.view.Currency.ToString();
                    string sourcebranch = this.view.SourceBranch.ToString();
                    string header = "Business Loans Voucher Outstanding Listing";
                    CXUIScreenTransit.Transit("frmLOMVEW00331.ReportViewer", true, new object[] { DTOList, currency, sourcebranch, header });
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
