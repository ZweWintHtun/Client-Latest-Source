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
    public class LOMCTL00303 : AbstractPresenter,ILOMCTL00303
    {
        #region Properties
        private ILOMVEW00303 view;
        public ILOMVEW00303 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ILOMVEW00303 view)
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

        public LOMDTO00303 GetViewData()
        {
            LOMDTO00303 viewData = new LOMDTO00303();
            viewData.SourceBr = this.view.SourceBranch;
            viewData.Cur = this.view.Currency;
            viewData.VillageCode = this.view.Village;
            viewData.TownshipCode = this.view.Township;
            viewData.ExpireDate = this.view.DueDate;
            return viewData;
        }
        #endregion

        #region Methods
        public void Print()
        {
            if (this.Validate_Form())
            {
                LOMDTO00303 DTO = this.GetViewData();
                IList<LOMDTO00303> DTOList = new List<LOMDTO00303>();
                IList<LOMDTO00303> DTOList_Report = new List<LOMDTO00303>();
                DTOList = CXClientWrapper.Instance.Invoke<ILOMSVE00303, IList<LOMDTO00303>>(x => x.SelectAll(DTO));
                if (DTOList.Count > 0)
                {
                    int count = DTOList.Count;
                    for(int i = 0;i < DTOList.Count ; i++)
                    {
                        LOMDTO00303 DtoForCompare1 = new LOMDTO00303();
                        LOMDTO00303 DtoForCompare2 = new LOMDTO00303();
                        if (i < count - 1)
                        {
                            DtoForCompare1 = DTOList[i];
                            DtoForCompare2 = DTOList[i + 1];
                            if (DtoForCompare1.Lno == DtoForCompare2.Lno)
                            {
                                DtoForCompare1.SAmt = 0;
                            }
                            else
                            {
                                DtoForCompare1.OSTInterest = Convert.ToDecimal(CXClientWrapper.Instance.Invoke<ILOMSVE00303, object>(x => x.CalculateFarmLoanInterest(DtoForCompare1)));
                                DtoForCompare1.OSTPenalFee = Convert.ToDecimal(CXClientWrapper.Instance.Invoke<ILOMSVE00303, object>(x => x.CalculateFarmLoanPenalFee(DtoForCompare1)));
                            }
                            DTOList_Report.Add(DtoForCompare1);
                        }
                        else
                        {
                            LOMDTO00303 DtoNotCompare = new LOMDTO00303();
                            DtoNotCompare = DTOList[count - 1];
                            DtoNotCompare.OSTInterest = Convert.ToDecimal(CXClientWrapper.Instance.Invoke<ILOMSVE00303, object>(x => x.CalculateFarmLoanInterest(DtoNotCompare)));
                            DtoNotCompare.OSTPenalFee = Convert.ToDecimal(CXClientWrapper.Instance.Invoke<ILOMSVE00303, object>(x => x.CalculateFarmLoanPenalFee(DtoNotCompare)));
                            DTOList_Report.Add(DtoNotCompare); 
                        }                       
                    }
                    string village = DTOList.Select(d => d.VillageDesp).FirstOrDefault();
                    string township = DTOList.Select(d => d.TownshipDesp).FirstOrDefault();
                    string dueDate = this.view.DueDate.ToShortDateString();
                    string currency = this.view.Currency.ToString();
                    string sourcebranch = this.view.SourceBranch.ToString();
                    string header = "Ourstanding Register (Monsoon,Winter,Premonsoon)";
                    CXUIScreenTransit.Transit("frmLOMVEW00304.ReportViewer", true, new object[] { DTOList,village,township,dueDate, currency, sourcebranch, header });
                     
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
