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
    public class LOMCTL00045 : AbstractPresenter, ILOMCTL00045
    {
        #region Properties
        private ILOMVEW00045 view;
        public ILOMVEW00045 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00045 view)
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
        public LOMDTO00021 GetEntity()
        {
            LOMDTO00021 entity = new LOMDTO00021();
            entity.SourceBr = this.view.SourceBranch;
            entity.Cur = this.view.Currency;
            entity.QuaterNo = this.view.Quater;
            entity.Budget = this.GetBudgetYear(this.view.RequiredYear);
            return entity;
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

        public string GetSQTRTOTAL(string qNo, string budget, string sourceBr, string cur)
        {
            string query = "({0})> 0 and Budget = ''{1}'' and LOANS.SourceBr = ''{2}'' and LOANS.Cur =''{3}''";
            string sqtrTotal = string.Empty;
            sqtrTotal = String.Format(query, qNo, budget, sourceBr, cur);
            return sqtrTotal;
        }
        #endregion       

        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00021 DTO = this.GetEntity();
                //string sqtrTotal = this.GetSQTRTOTAL(DTO.QuaterNo, DTO.Budget, DTO.SourceBr, DTO.Cur);
                IList<LOMDTO00021> DTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00002, IList<LOMDTO00021>>(x => x.SelectLoansInterestByQuater(DTO));
                if (DTOList.Count > 0)
                {
                    string currency = this.view.Currency.ToString();
                    string sourcebranch = this.view.SourceBranch.ToString();
                    string header = "Loans Interest Listing";
                    string qno = this.view.Quater;
                    CXUIScreenTransit.Transit("frmLOMVEW00053.ReportViewer", true, new object[] { DTOList, currency, sourcebranch, header, qno });

                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
            }
        }
    }
}
