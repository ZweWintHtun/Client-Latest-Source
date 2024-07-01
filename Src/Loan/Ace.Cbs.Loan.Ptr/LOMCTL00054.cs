using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;

namespace Ace.Cbs.Loan.Ptr
{
    public class LOMCTL00054 : AbstractPresenter, ILOMCTL00054
    {
        #region Properties
        private ILOMVEW00054 view;
        public ILOMVEW00054 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00054 view)
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
        public LOMDTO00054 GetEntity()
        {
            LOMDTO00054 entity = new LOMDTO00054();
            entity.SourceBr = this.view.SourceBranch;
            entity.Cur = this.view.Currency;
            entity.MonthNo = this.GetMonthNo(this.view.Quater);
            entity.Budget = this.GetBudgetYear(this.view.RequiredYear);
            return entity;
        }

        public string GetMonthNo(string quater)
        {
            if (!String.IsNullOrEmpty(quater))
            {
                switch (quater)
                {
                    case "Q1":
                        return "M4+M5+M6";
                    case "Q2":
                        return "M7+M8+M9";
                    case "Q3":
                        return "M10+M11+M12";
                    case "Q4":
                        return "M1+M2+M3";
                }
            }
            return string.Empty;
        }

        public string GetBudgetYear(string requiredYear)
        {
            if (!String.IsNullOrEmpty(requiredYear))
            {
                string BYear = "{0}/{1}";
                int EYear = Convert.ToInt32(requiredYear);
                int SYear = EYear - 1;
                return String.Format(BYear, SYear.ToString(), EYear.ToString());
            }
            return string.Empty;
        }
        #endregion

        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00054 DTO = this.GetEntity();
                //string sqtrTotal = this.GetSQTRTOTAL(DTO.QuaterNo, DTO.Budget, DTO.SourceBr, DTO.Cur);
                IList<LOMDTO00054> DTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00002, IList<LOMDTO00054>>(x => x.SelectODInterestByQuater(DTO));
                if (DTOList.Count > 0)
                {
                    string currency = this.view.Currency.ToString();
                    string sourcebranch = this.view.SourceBranch.ToString();
                    string header = "Loans Interest Listing";
                    string qno = this.view.Quater;
                    CXUIScreenTransit.Transit("frmLOMVEW00056.ReportViewer", true, new object[] { DTOList, currency, sourcebranch, header, qno });

                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
            }
        }
    }
}
