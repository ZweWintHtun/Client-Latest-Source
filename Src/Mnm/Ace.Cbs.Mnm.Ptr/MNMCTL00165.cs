using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.PTR;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00165 : AbstractPresenter, IMNMCTL00165
    {
        private IMNMVEW00165 view;
        public IMNMVEW00165 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00165 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetVlaidateData());
            }
        }

        public MNMDTO00010 GetVlaidateData()
        {
            MNMDTO00010 ValidateDto = new MNMDTO00010();
            ValidateDto.CUR = this.view.CurrencyNo;
            ValidateDto.Sourcebranch = this.view.BranchCode;
            ValidateDto.SelectedDate = this.view.SelectedDate;
            ValidateDto.BUDGET = this.view.SelectedDate.Year.ToString();
            ValidateDto.Month = this.view.SelectedDate.Month.ToString();
            return ValidateDto;
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public bool Validate_Form()
        {
            if (String.IsNullOrEmpty(this.view.CurrencyNo))
            {
                return false;
            }
            if (String.IsNullOrEmpty(this.view.BranchCode))
            {
                return false;
            }
            if (this.view.SelectedDate.Equals(DateTime.MinValue))
            {
                return false;
            }
            return true;
        }

        public void Print()
        {
            if (!CXCOM00006.Instance.IsExceedTodayDate(this.view.SelectedDate))
            {
                MNMDTO00010 DTO = this.GetVlaidateData();
                IList<MNMDTO00010> DTOList = new List<MNMDTO00010>();
                IList<MNMDTO00010> FinalDTOList = new List<MNMDTO00010>();
                if (this.view.Title.Contains("Group"))
                {
                    DTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00092, IList<MNMDTO00010>>(x => x.SelectTriGroupForBackDate(this.View.CurrencyNo, this.View.BranchCode, this.View.SelectedDate));
                }
                else
                {
                    DTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00091, IList<MNMDTO00010>>(x => x.SelectTriDetailForBackDate(this.View.CurrencyNo, this.View.BranchCode, this.View.SelectedDate));
                }
                if (DTOList.Count > 0)
                {
                    foreach (MNMDTO00010 data in DTOList)
                    {
                        MNMDTO00010 finalData = new MNMDTO00010();
                        if (Convert.ToDouble(data.AMOUNT) != 0.0) //Convert.ToInt32 to Convert.ToDouble // Modified By AAM(25-08-2017)
                        {
                            finalData.ACODE = data.ACODE;
                            finalData.ACNAME = data.ACNAME;
                            finalData.COAamount = data.AMOUNT;
                            finalData.ACTYPE = data.ACTYPE;
                            FinalDTOList.Add(finalData);
                        }
                    }
                    if (this.view.Title.Contains("Group"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00092TriBalanceGroupReport", true, new object[] { FinalDTOList, this.View.BranchCode, this.View.CurrencyNo, "Trial Balance Group Listing For Date ("+ this.View.SelectedDate.ToString("dd MMMM,yyyy") +")", this.View.SelectedDate.Month.ToString() });
                    }
                    else if (this.view.Title.Contains("Detail"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00091TriBalanceDetailReport", true, new object[] { FinalDTOList, this.View.BranchCode, this.View.CurrencyNo, "Trial Balance Detail Listing For Date (" + this.View.SelectedDate.ToString("dd MMMM,yyyy") + ")", this.View.SelectedDate.Month.ToString() });
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MV90169");//Date must not be greater than today. 
            }

        }
    }
}
