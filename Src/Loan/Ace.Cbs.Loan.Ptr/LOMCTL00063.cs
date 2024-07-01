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
    public class LOMCTL00063 : AbstractPresenter, ILOMCTL00063
    {
        #region Properties
        private ILOMVEW00063 view;
        public ILOMVEW00063 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00063 view)
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
            entity.SourceBr = this.view.SourceBranch;
            entity.Cur = this.view.Currency;

            return entity;
        }
        #endregion

        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00013 DTO = this.GetEntity();
                IList<LOMDTO00013> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00063, IList<LOMDTO00013>>(x => x.SelectNonPerformanceLoansCase(DTO));
                if (DTOList.Count > 0)
                {
                    string currency = this.view.Currency.ToString();
                    string sourcebranch = this.view.SourceBranch.ToString();
                    string header = "Non Performance Loans Case";
                    CXUIScreenTransit.Transit("frmLOMVEW00064.ReportViewer", true, new object[] { DTOList, currency, sourcebranch, header });
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.                            
                }
            }
        }
    }
}
