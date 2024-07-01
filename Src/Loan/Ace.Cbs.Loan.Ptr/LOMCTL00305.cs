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
    public class LOMCTL00305 : AbstractPresenter, ILOMCTL00305
    {
        #region Properties
        private ILOMVEW00305 view;
        public ILOMVEW00305 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00305 view)
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

        public LOMDTO00305 GetViewData()
        {
            LOMDTO00305 viewData = new LOMDTO00305();
            viewData.SourceBr = this.view.SourceBranch;
            viewData.Cur = this.view.Currency;
            viewData.VillageCode = this.view.Village;
            viewData.TownshipCode = this.view.Township;
            viewData.WithdrawDate = this.view.WithdrawDate;
            return viewData;
        }
        #endregion

        #region Methods
        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00305 DTO = this.GetViewData(); 
                IList<LOMDTO00305> DTOList = new List<LOMDTO00305>();
                IList<LOMDTO00305> DTOList_Report = new List<LOMDTO00305>();
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00305, IList<LOMDTO00305>>(x => x.SelectAll(DTO));
                if (DTOList.Count > 0)
                {
                    int count = DTOList.Count;
                    for (int i = 0; i < DTOList.Count; i++)
                    {
                        LOMDTO00305 DtoForCompare1 = new LOMDTO00305();
                        LOMDTO00305 DtoForCompare2 = new LOMDTO00305();
                        if (i < count - 1)
                        {
                            DtoForCompare1 = DTOList[i];
                            DtoForCompare2 = DTOList[i + 1];
                            if (DtoForCompare1.Lno == DtoForCompare2.Lno)
                            {
                                DtoForCompare2.PrincipalAmount = 0;
                                DtoForCompare1.SAmt = 0;
                            }
                            //else
                            //{
                            //    //DtoForCompare1.OSTInterest = Convert.ToDecimal(CXClientWrapper.Instance.Invoke<ILOMSVE00303, object>(x => x.CalculateFarmLoanInterest(DtoForCompare1)));
                            //    DtoForCompare1.OSTPenalFee = Convert.ToDecimal(CXClientWrapper.Instance.Invoke<ILOMSVE00303, object>(x => x.CalculateFarmLoanPenalFee(DtoForCompare1)));
                            //}
                            DTOList_Report.Add(DtoForCompare1);
                        }
                        else
                        {
                            LOMDTO00305 DtoNotCompare = new LOMDTO00305();
                            DtoNotCompare = DTOList[count - 1];
                            //DtoNotCompare.OSTInterest = Convert.ToDecimal(CXClientWrapper.Instance.Invoke<ILOMSVE00303, object>(x => x.CalculateFarmLoanInterest(DtoNotCompare)));
                            //DtoNotCompare.OSTPenalFee = Convert.ToDecimal(CXClientWrapper.Instance.Invoke<ILOMSVE00303, object>(x => x.CalculateFarmLoanPenalFee(DtoNotCompare)));
                            DTOList_Report.Add(DtoNotCompare);
                        }
                    }
                    string village = DTOList.Select(d => d.VillageDesp).FirstOrDefault();
                    string township = DTOList.Select(d => d.TownshipDesp).FirstOrDefault();
                    string withdrawDate = this.view.WithdrawDate.ToShortDateString();
                    string currency = this.view.Currency.ToString();
                    string sourcebranch = this.view.SourceBranch.ToString();
                    string header = "Monsoon,Winter,Premonsoon,Individual Loan Outstanding";
                    CXUIScreenTransit.Transit("frmLOMVEW00306.ReportViewer", true, new object[] { DTOList_Report, village, township, withdrawDate, currency, sourcebranch, header });

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
