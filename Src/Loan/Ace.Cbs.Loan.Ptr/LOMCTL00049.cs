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
    public class LOMCTL00049 : AbstractPresenter, ILOMCTL00049
    {
        #region Properties
        private ILOMVEW00049 view;
        public ILOMVEW00049 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00049 view)
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

            return entity;
        }
        #endregion

        public void Print()
        {
            if (this.Validate_Form())
            {
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.RequiredDate))
                {
                    LOMDTO00035 DTO = this.GetEntity();
                    IList<LOMDTO00035> DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00035, IList<LOMDTO00035>>(x => x.SelectAllLoansDailyPositionByCur(DTO));
                    if (DTOList.Count > 0)
                    {
                        string currency = this.view.Currency.ToString();
                        string sourcebranch = this.view.SourceBranch.ToString();
                        string header = "Loans Daily Position Listing";
                        CXUIScreenTransit.Transit("frmLOMVEW00050.ReportViewer", true, new object[] { DTOList, currency, sourcebranch, header });
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
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
