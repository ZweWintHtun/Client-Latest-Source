using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Gl.Ctr.Sve;
//using NHibernate;
//using Spring.Data.NHibernate.Support;


namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00008 : AbstractPresenter, IGLMCTL00008
    {
        #region Properties
        private IGLMVEW00008 view;
        public IGLMVEW00008 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        MNMDTO00010 CCOAandCOAInfo { get; set; }

        #endregion

        #region Helper Method
        private void WireTo(IGLMVEW00008 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetValidateData());
            }
        }
        public MNMDTO00010 GetValidateData()
        {
            MNMDTO00010 ViewData = new MNMDTO00010();
            ViewData.ACODE = this.View.AccountNo;
            ViewData.CUR = this.View.Currency;
            ViewData.Sourcebranch = CurrentUserEntity.BranchCode;
            return ViewData;
        }

        //public bool Validate_Form()
        //{
        //    return this.ValidateForm(this.GetValidateData());
        //}

        public void cboCurrency_CustomValiding(object sender, ValidationEventArgs e)
        {
                     
            if (e.HasXmlBaseError == true)
            {
                return;
            }
            else
            {
                this.DisplayData();
            }
        }

        public void DisplayData()
        {
            //if(this.ValidateForm(this.GetValidateData()))
            //{
                Nullable<decimal> amt;
                string budgetMonth = "M" + CXCOM00010.Instance.GetBudgetMonth();

                MNMDTO00010 DataDTO = this.GetValidateData();
                CCOAandCOAInfo = CXClientWrapper.Instance.Invoke<IGLMSVE00008, MNMDTO00010>(x => x.GetCCOAandCOA_ByACodeAndCurrency(DataDTO));

                if (CCOAandCOAInfo != null)     
                {
                    switch (budgetMonth)
                    {
                        case "M1": Nullable<decimal> M1 = CCOAandCOAInfo.M1;
                            amt = M1;
                            break;

                        case "M2": Nullable<decimal> M2 = CCOAandCOAInfo.M2;
                            amt = M2;
                            break;

                        case "M3": Nullable<decimal> M3 = CCOAandCOAInfo.M3;
                            amt = M3;
                            break;

                        case "M4": Nullable<decimal> M4 = CCOAandCOAInfo.M4;
                            amt = M4;
                            break;

                        case "M5": Nullable<decimal> M5 = CCOAandCOAInfo.M5;
                            amt = M5;
                            break;

                        case "M6": Nullable<decimal> M6 = CCOAandCOAInfo.M6;
                            amt = M6;
                            break;

                        case "M7": Nullable<decimal> M7 = CCOAandCOAInfo.M7;
                            amt = M7;
                            break;

                        case "M8": Nullable<decimal> M8 = CCOAandCOAInfo.M8;
                            amt = M8;
                            break;

                        case "M9": Nullable<decimal> M9 = CCOAandCOAInfo.M9;
                            amt = M9;
                            break;

                        case "M10": Nullable<decimal> M10 = CCOAandCOAInfo.M10;
                            amt = M10;
                            break;

                        case "M11": Nullable<decimal> M11 = CCOAandCOAInfo.M11;
                            amt = M11;
                            break;

                        case "M12": Nullable<decimal> M12 = CCOAandCOAInfo.M12;
                            amt = M12;
                            break;

                        case "M13": Nullable<decimal> M13 = CCOAandCOAInfo.M13;
                            amt = M13;
                            break;

                        default:
                            amt = 0;
                             break;
                    }

                    this.view.AccountName = CCOAandCOAInfo.ACNAME;
                    this.view.Balance = amt.ToString() ;
                }
                else
                {
                    CXClientWrapper.Instance.ServiceResult.ErrorOccurred = true;
                    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
            //}
        }
        //public string GetBudgetMonth()
        //{
        //    string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);  //MbudSmth
        //    string currentMonth = DateTime.Now.Month.ToString();            
        //    int result;
        //    if (Convert.ToInt16(currentMonth) < Convert.ToInt16(value))
        //    {
        //        result = Convert.ToInt16(currentMonth) + 12;
        //    }
        //    else
        //    {
        //        result = Convert.ToInt16(currentMonth);
        //    }

        //    string returnValue = Convert.ToString(result + 1 - Convert.ToInt16(value));

        //    return returnValue;
        //}

        #endregion
    }
}
