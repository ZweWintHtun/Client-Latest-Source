using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd.DTO;

namespace Ace.Cbs.Loan.Ptr
{
    class LOMCTL00100 : AbstractPresenter, ILOMCTL00100
    {
        #region Properties
        private ILOMVEW00100 view;
        public ILOMVEW00100 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00100 view)
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
        public LOMDTO00100 GetEntity()
        {
            LOMDTO00100 entity = new LOMDTO00100();
            entity.SourceBr = this.view.SourceBr;
            entity.Cur = this.view.Currency;
            entity.Year = this.view.Year;
            return entity;
        }
        #endregion

        public void Print(string rptName,string month,string year)
        {
            if (this.Validate_Form())
            {
                string str1 = month.Substring(0, 2);
                string str2 = month.Substring(2, month.Length - 2);

                IList<LOMDTO00100> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00096, IList<LOMDTO00100>>(x => x.GetHPPaymentSchedule(this.view.SourceBr, this.view.Currency, str1, year));
                if (DTOList.Count > 0)
                {
                    string currency = this.view.Currency.ToString();
                    string header = "Hire Purchase Payment Schedule";
                    string sourcebranch = this.view.SourceBr.ToString();
                    CXUIScreenTransit.Transit("frmLOMVEW00097", true, new object[] { DTOList, currency, header, sourcebranch, str2,rptName });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
            }
        }
    }
}
