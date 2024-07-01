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
    public class LOMCTL00328 : AbstractPresenter, ILOMCTL00328
    {
        #region Properties
        private ILOMVEW00328 view;
        public ILOMVEW00328 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00328 view)
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

        public LOMDTO00311 GetViewData()
        {
            LOMDTO00311 viewData = new LOMDTO00311();
            viewData.SourceBr = this.view.SourceBranch;
            viewData.Cur = this.view.Currency;
            return viewData;
        }
        #endregion

        #region Methods
        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00311 DTO = this.GetViewData();
                IList<LOMDTO00311> DTOList = new List<LOMDTO00311>();
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00311, IList<LOMDTO00311>>(x => x.GetPLVrOutstandingListing(DTO));
                if (DTOList.Count > 0)
                {
                    string currency = this.view.Currency.ToString();
                    string sourcebranch = this.view.SourceBranch.ToString();
                    string header = "Personal Loans Voucher Outstanding Listing";
                    CXUIScreenTransit.Transit("frmLOMVEW00329.ReportViewer", true, new object[] { DTOList, currency, sourcebranch, header });
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