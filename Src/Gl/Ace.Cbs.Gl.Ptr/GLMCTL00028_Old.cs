using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Gl.Ctr.Sve;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00028 : AbstractPresenter, IGLMCTL00028
    {
        #region Properties
        private IGLMVEW00028 view;
        public IGLMVEW00028 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IGLMVEW00028 view)
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

        public GLMDTO00028 GetViewData()
        {
            GLMDTO00028 viewData = new GLMDTO00028();
            viewData.RequireMonth = this.view.RequireMonth;
            viewData.RequireYear = this.view.RequireYear;
            viewData.SourceBr = this.view.SourceBranch;
            viewData.Cur = this.view.Currency;
            return viewData;
        }
        #endregion

        #region Methods

        public void Print()
        {
            if (this.Validate_Form())
            {
                string[] budgetyear = this.view.BudgetYear.Split('/');
                if (Convert.ToInt32(this.view.RequireYear) <= 2017 && Convert.ToInt32(this.view.RequireMonth) < 7)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                }
                else if (Convert.ToInt32(this.view.RequireYear) > DateTime.Now.Year)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI90126");//Selected year and month cannot greater than current year and month.
                }
                else if (Convert.ToInt32(this.view.RequireYear) == DateTime.Now.Year && Convert.ToInt32(this.view.RequireMonth) > DateTime.Now.Month)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI90126");//Selected year and month cannot greater than current year and month.
                }
                else if(this.view.RequireYear != budgetyear[0] && this.view.RequireYear != budgetyear[1])
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV00144");//Invalid Budget Year!
                }
                else
                {
                    #region OldCode
                    //GLMDTO00028 DTO = this.GetViewData();
                    ////Property, plant & equipment
                    //object PPEAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetPropertyPlanAndEquipment(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.PPEAmt = Convert.ToDecimal(PPEAmt);

                    ////Software & Network Equipment
                    //object SNEAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetSoftwareAndNetworkEquipment(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.SNEAmt = Convert.ToDecimal(SNEAmt);

                    ////Loans //Added by HWKO (22-Dec-2017)
                    //object LAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetLoansAmount(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.LAmt = Convert.ToDecimal(LAmt);

                    ////Hire Purchase //Added by HWKO (22-Dec-2017)
                    //object HPAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetHPAmount(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.HPAmt = Convert.ToDecimal(HPAmt);

                    ////Other Assets
                    //object OSAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetOtherAssets(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.OSAmt = Convert.ToDecimal(OSAmt);

                    ////Cash & Cash Equivalent
                    //object CCEAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetCashAndCashEquivalent(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.CCEAmt = Convert.ToDecimal(CCEAmt);

                    ////Inter Company Receivable
                    //object ICRAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetInterCompanyReceivable(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.ICRAmt = Convert.ToDecimal(ICRAmt);

                    ////Paid Up Capital
                    //object PUCAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetPaidUpCapital(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.PUCAmt = Convert.ToDecimal(PUCAmt);

                    ////Other reserves
                    //object ORAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetOtherReserves(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.ORAmt = Convert.ToDecimal(ORAmt);

                    ////Retained Earnings
                    //object REAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetRetainedEarnings(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.REAmt = Convert.ToDecimal(REAmt);

                    ////Profit/(Loss)
                    //object ProfitAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetProfit(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //object LossAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetLoss(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.PLAmt = Convert.ToDecimal(ProfitAmt) - Convert.ToDecimal(LossAmt);

                    ////Sundry Deposit and other payables
                    //object SDAOPAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetSundryDepositAndOtherPayables(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.SDAOPAmt = Convert.ToDecimal(SDAOPAmt);

                    ////Overdraft //Added by HWKO (01-Dec-2017)
                    //object ODAmt = CXClientWrapper.Instance.Invoke<IGLMSVE00028, object>(x => x.GetOverdraft(DTO.RequireMonth, DTO.Cur, DTO.SourceBr));
                    //DTO.ODAmt = Convert.ToDecimal(ODAmt);

                    //string header = "Statement of Financial Position";
                    //IList<GLMDTO00028> DTOList = new List<GLMDTO00028>();
                    //DTOList.Add(DTO);
                    //CXUIScreenTransit.Transit("frmGLMVEW00029.ReportViewer", true, new object[] { DTOList, header });
                    #endregion 

                    GLMDTO00028 DTO = this.GetViewData();
                    IList<GLMDTO00028> lst = CXClientWrapper.Instance.Invoke<IGLMSVE00028, IList<GLMDTO00028>>(x => x.Get_SFP_Report_Data(DTO.RequireMonth, DTO.SourceBr));
                    //IList<GLMDTO00028> lst_NCA_PPE = lst.Where(a => a.ACType == "NCA" && a.SubACType == "PPE").ToList();
                    //IList<GLMDTO00028> lst_NCA_SNE = lst.Where(a => a.ACType == "NCA" && a.SubACType == "SNE").ToList();

                    //DTO.PPEAmt = lst_NCA_PPE[0].Amount;
                    //DTO.SNEAmt = lst_NCA_SNE[0].Amount;


                    //IList<GLMDTO00028> lst_LOH_LOANS = lst.Where(a => a.ACType == "LOH" && a.SubACType == "LOANS").ToList();
                    //IList<GLMDTO00028> lst_LOH_OD = lst.Where(a => a.ACType == "LOH" && a.SubACType == "OD").ToList();
                    //IList<GLMDTO00028> lst_LOH_HP = lst.Where(a => a.ACType == "LOH" && a.SubACType == "HP").ToList();
                    //DTO.LAmt = lst_LOH_LOANS[0].Amount;
                    //DTO.ODAmt = lst_LOH_OD[0].Amount;
                    //DTO.HPAmt = lst_LOH_HP[0].Amount;

                    //IList<GLMDTO00028> lst_CA_OA = lst.Where(a => a.ACType == "CA" && a.SubACType == "OA").ToList();
                    //IList<GLMDTO00028> lst_CA_CCE = lst.Where(a => a.ACType == "CA" && a.SubACType == "CCE").ToList();
                    //IList<GLMDTO00028> lst_CA_ICR = lst.Where(a => a.ACType == "CA" && a.SubACType == "ICR").ToList();
                    //IList<GLMDTO00028> lst_CA_LHI = lst.Where(a => a.ACType == "CA" && a.SubACType == "LHI").ToList();

                    //DTO.OSAmt = lst_CA_OA[0].Amount;
                    //DTO.CCEAmt = lst_CA_CCE[0].Amount;
                    //DTO.ICRAmt = lst_CA_ICR[0].Amount;
                    //DTO.LHIAmt = lst_CA_LHI[0].Amount;

                    //IList<GLMDTO00028> lst_EAL_PUPCAP = lst.Where(a => a.ACType == "EAL" && a.SubACType == "PUPCAP").ToList();
                    //IList<GLMDTO00028> lst_EAL_ORES = lst.Where(a => a.ACType == "EAL" && a.SubACType == "ORES").ToList();
                    //IList<GLMDTO00028> lst_EAL_REAR = lst.Where(a => a.ACType == "EAL" && a.SubACType == "REAR").ToList();
                    //IList<GLMDTO00028> lst_EAL_PNL = lst.Where(a => a.ACType == "EAL" && a.SubACType == "PNL").ToList();
                    //DTO.PUCAmt = lst_EAL_PUPCAP[0].Amount;
                    //DTO.ORAmt = lst_EAL_ORES[0].Amount;
                    //DTO.REAmt = lst_EAL_REAR[0].Amount;
                    //DTO.PLAmt = lst_EAL_PNL[0].Amount;

                    //IList<GLMDTO00028> lst_NCL = lst.Where(a => a.ACType == "NCL").ToList();

                    //IList<GLMDTO00028> lst_CL_SDNOP = lst.Where(a => a.ACType == "CL" && a.SubACType == "SDNOP").ToList();
                    //DTO.SDAOPAmt = lst_CL_SDNOP[0].Amount;

                    string header = "Statement of Financial Position";
                    //IList<GLMDTO00028> DTOList = new List<GLMDTO00028>();
                    //DTOList.Add(DTO);
                    //CXUIScreenTransit.Transit("frmGLMVEW00029.ReportViewer", true, new object[] { DTOList, header });

                    string requiredDate=DateTime.DaysInMonth(Convert.ToInt32(DTO.RequireYear),Convert.ToInt32(DTO.RequireMonth)).ToString();
                    CXUIScreenTransit.Transit("frmGLMVEW00029.ReportViewer", true, new object[] { lst, header, 
                        requiredDate + "th" + " " + this.GetMonthName(DTO.RequireMonth).Substring(0, 3) + "'" +" "+DTO.RequireYear,
                        this.GetMonthName(DTO.RequireMonth).Substring(0, 3) + "'" +" "+ DTO.RequireYear});

                }
            }
        }

        public string GetMonthName(string month)
        {
            if (!String.IsNullOrEmpty(month))
            {
                int monthNo = Convert.ToInt32(month);
                switch (monthNo)
                {
                    case 1:
                        return "January";
                    case 2:
                        return "February";
                    case 3:
                        return "March";
                    case 4:
                        return "April";
                    case 5:
                        return "May";
                    case 6:
                        return "June";
                    case 7:
                        return "July";
                    case 8:
                        return "August";
                    case 9:
                        return "September";
                    case 10:
                        return "October";
                    case 11:
                        return "November";
                    case 12:
                        return "December";
                }
            }
            return String.Empty;
        }

        #endregion

    }
}
