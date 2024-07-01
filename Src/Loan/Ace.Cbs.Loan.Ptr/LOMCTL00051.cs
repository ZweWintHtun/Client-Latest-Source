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
    public class LOMCTL00051 : AbstractPresenter, ILOMCTL00051
    {
        #region Properties
        private ILOMVEW00051 view;
        public ILOMVEW00051 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00051 view)
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
            entity.SourceBr = this.view.SourceBranch;
            entity.Cur = this.view.Currency;
            entity.RequiredYear = this.view.RequiredYear;
            entity.RequiredMonth = this.view.RequiredMonth;

            return entity;
        }
        #endregion

        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00035 DTO = this.GetEntity();
                IList<LOMDTO00035> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00051, IList<LOMDTO00035>>(x => x.SelectExpireLoansByCur(DTO));
                if (DTOList.Count > 0)
                {
                    string currency = this.view.Currency.ToString();
                    string sourcebranch = this.view.SourceBranch.ToString();
                    string header = "Expire Loans Listing";
                    string year = this.view.RequiredYear.ToString();
                    string month = this.view.RequiredMonth.ToString();
                    CXUIScreenTransit.Transit("frmLOMVEW00052.ReportViewer", true, new object[] { DTOList, currency, sourcebranch, header, year, month });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
            }
        }
    }
}
