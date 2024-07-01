using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00057 : AbstractPresenter , IMNMCTL00057
    {
        #region Properties

        private IMNMVEW00057 view;
        public IMNMVEW00057 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        IList<PFMDTO00017> List { get; set; }
        #endregion

        #region Helper Method
        private void WireTo(IMNMVEW00057 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetValidateData());
            }
        }
        public PFMDTO00017 GetValidateData()
        {
            PFMDTO00017 ViewData = new PFMDTO00017();
            ViewData.StartDate = this.view.StartDate;
            ViewData.EndDate = this.view.EndDate;
            return ViewData;
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetValidateData());
        }

        #endregion

        #region Main Method
        public void Print()
        {
            string acSign = string.Empty;
            switch (this.view.FormName)
            {
                case "Current Account All": acSign = "C";
                    break;

                case "Current Account Individual": acSign = "CI";
                    break;

                case "Current Account Joint": acSign = "CJ";
                    break;

                case "Current Account Company": acSign = "CC";
                    break;

                case "Current Account Private Firm": acSign = "CS";
                    break;

                case "Current Account Partnership": acSign = "CP";
                    break;

                case "Current Account Association": acSign = "CA";
                    break;

                case "Saving Account All": acSign = "S";
                    break;

                case "Saving Account Individual": acSign = "SI";
                    break;

                case "Saving Account Joint": acSign = "SJ";
                    break;

                case "Saving Account Organization": acSign = "SO";
                    break;

                case "Saving Account Minor": acSign = "SM";
                    break;

                #region Added By HWKO (23-Jun-2017) For PRISTINE 
                case "Business Loan Account All": acSign = "B";
                    break;

                case "Business Loan Account Individual": acSign = "BI";
                    break;

                case "Business Loan Account Joint": acSign = "BJ";
                    break;

                case "Business Loan Account Company": acSign = "BC";
                    break;

                case "Hire Purchase Loan Account All": acSign = "H";
                    break;

                case "Hire Purchase Loan Account Individual": acSign = "HI";
                    break;

                case "Hire Purchase Loan Account Joint": acSign = "HJ";
                    break;

                case "Hire Purchase Loan Account Company": acSign = "HC";
                    break;

                case "Personal Loan Account All": acSign = "P";
                    break;

                case "Personal Loan Account Individual": acSign = "PI";
                    break;

                case "Personal Loan Account Joint": acSign = "PJ";
                    break;

                case "Personal Loan Account Company": acSign = "PC";
                    break;
                #endregion

                #region Added by HWKO (04-Aug-2017) For PRISTINE
                case "Dealer Account All": acSign = "D";
                    break;

                case "Dealer Account Individual": acSign = "DI";
                    break;

                case "Dealer Account Joint": acSign = "DJ";
                    break;

                case "Dealer Account Company": acSign = "DC";
                    break;
                #endregion
            }

            if (acSign.Substring(0, 1) == "C")
            {
                List = CXClientWrapper.Instance.Invoke<IMNMSVE00057, IList<PFMDTO00017>>(x => x.GetCurrentAccountAll(this.view.StartDate, this.view.EndDate, acSign, CurrentUserEntity.BranchCode));
            }
            else if (acSign.Substring(0, 1) == "S")
            {
                List = CXClientWrapper.Instance.Invoke<IMNMSVE00057, IList<PFMDTO00017>>(x => x.GetSavingAccountAll(this.view.StartDate, this.view.EndDate, acSign, CurrentUserEntity.BranchCode));
            }
            else if (acSign.Substring(0, 1) == "B") // Added By HWKO (23-Jun-2017)
            {
                List = CXClientWrapper.Instance.Invoke<IMNMSVE00057, IList<PFMDTO00017>>(x => x.GetBusinessLoanAccountAll(this.view.StartDate, this.view.EndDate, acSign, CurrentUserEntity.BranchCode));
            }
            else if (acSign.Substring(0, 1) == "H") // Added By HWKO (23-Jun-2017)
            {
                List = CXClientWrapper.Instance.Invoke<IMNMSVE00057, IList<PFMDTO00017>>(x => x.GetHirePurchaseLoanAccountAll(this.view.StartDate, this.view.EndDate, acSign, CurrentUserEntity.BranchCode));
            }
            else if (acSign.Substring(0, 1) == "P") // Added By HWKO (23-Jun-2017)
            {
                List = CXClientWrapper.Instance.Invoke<IMNMSVE00057, IList<PFMDTO00017>>(x => x.GetPersonalLoanAccountAll(this.view.StartDate, this.view.EndDate, acSign, CurrentUserEntity.BranchCode));
            }
            else if (acSign.Substring(0, 1) == "D") // Added By HWKO (04-Aug-2017)
            {
                List = CXClientWrapper.Instance.Invoke<IMNMSVE00057, IList<PFMDTO00017>>(x => x.GetDealerAccountAll(this.view.StartDate, this.view.EndDate, acSign, CurrentUserEntity.BranchCode));
            }
            if (List.Count > 0)
            {
                int j=0;                      
                IList<PFMDTO00017> PrintDataList = new List<PFMDTO00017>();
                PrintDataList.Add(List[0]);
                if (List.Count > 1)
                {
                    do
                    {
                        string accountNo = List[j].CledgerAccountNo;
                        j++;
                        if (accountNo != List[j].CledgerAccountNo)
                            PrintDataList.Add(List[j]);


                    } while (j != List.Count - 1);
                }
               
                if (this.view.FormName.Contains("Current"))
                {
                    if (this.view.FormName.Contains("All") || this.view.FormName.Contains("Association"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00106", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Individual") || this.view.FormName.Contains("Joint"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00135", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Partnership"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00132", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Company"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00133", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Private Firm"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00134", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                }
                else if (this.view.FormName.Contains("Saving"))
                {
                    if (this.view.FormName.Contains("All") || this.view.FormName.Contains("Organization"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00106", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Individual") || this.view.FormName.Contains("Joint"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00135", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Minor"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00136", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    } 
                }
                else if (this.view.FormName.Contains("Business Loan")) // Added By HWKO (23-Jun-2017)
                {
                    if (this.view.FormName.Contains("All"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00106", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Individual") || this.view.FormName.Contains("Joint"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00135", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }                    
                    else if (this.view.FormName.Contains("Company"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00133", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                }
                else if (this.view.FormName.Contains("Hire Purchase Loan")) // Added By HWKO (23-Jun-2017)
                {
                    if (this.view.FormName.Contains("All"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00106", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Individual") || this.view.FormName.Contains("Joint"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00135", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Company"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00133", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                }
                else if (this.view.FormName.Contains("Personal Loan")) // Added By HWKO (23-Jun-2017)
                {
                    if (this.view.FormName.Contains("All"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00106", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Individual") || this.view.FormName.Contains("Joint"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00135", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Company"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00133", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                }
                else if (this.view.FormName.Contains("Dealer")) // Added By HWKO (04-Aug-2017)
                {
                    if (this.view.FormName.Contains("All"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00106", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Individual") || this.view.FormName.Contains("Joint"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00135", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                    else if (this.view.FormName.Contains("Company"))
                    {
                        CXUIScreenTransit.Transit("frmMNMVEW00133", true, new object[] { PrintDataList, this.view.StartDate, this.view.EndDate, this.view.FormName });
                    }
                }

            }
            //else 
            //{
            //    CXUIMessageUtilities.ShowMessageByCode("MI00039");
            //}
        }

        #endregion
    }
}
