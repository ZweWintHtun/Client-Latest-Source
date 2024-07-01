using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Ser;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00009 : AbstractPresenter, IGLMCTL00009
    {
        string strOpeningField = string.Empty;
        DateTime formatDate;

        IList<MNMDTO00054> LedgerListingDTOList {get;set;}
        IList<MNMDTO00037> ReportDataList { get; set; }

        private IGLMVEW00009 view;
        public IGLMVEW00009 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
                
        private void WireTo(IGLMVEW00009 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        public MNMDTO00037 GetEntity()
        {
            MNMDTO00037 ViewData = new MNMDTO00037();
            ViewData.StartDate = this.View.StartDate;
            ViewData.EndDate = this.View.EndDate;
            ViewData.Cur = this.View.Currency;
            ViewData.IsHomeCurrency = this.View.IsCheckHomeCurrency;
            ViewData.IsTransactionDate = this.View.IsTransactionDate;
            return ViewData;
        }

        public override bool ValidateForm(object validationContext)
        {
            return base.ValidateForm(validationContext);
        }

        #region OldCode by NNL
        //public void Preview()
        //{
        //    if (this.ValidateForm(GetEntity()))
        //    {
        //        if (this.view.StartDate <= DateTime.Now)
        //        {
        //            if (this.view.EndDate <= DateTime.Now)
        //            {
        //                if (this.view.StartDate <= this.view.EndDate)
        //                {
        //                    string CurBudYear = CXCOM00010.Instance.GetBudgetYear1(""); //2014/2015
        //                    string Year = CurBudYear.Substring(0, 4);
        //                    MNMDTO00037 getBudDateList = CXClientWrapper.Instance.Invoke<IGLMSVE00009, MNMDTO00037>(x => x.NewSetup_SelectSDateEDate(Year));

        //                    if (this.view.StartDate < getBudDateList.getStartDate)
        //                    {
        //                        CXUIMessageUtilities.ShowMessageByCode("MV30021", new object[] { "Start" });
        //                    }
        //                    else
        //                    {
        //                        if (this.view.EndDate < getBudDateList.getStartDate)
        //                        {
        //                            CXUIMessageUtilities.ShowMessageByCode("MV30021", new object[] { "End" });
        //                        }
        //                        else
        //                        {
        //                            IList<ChargeOfAccountDTO> DTOList = CXClientWrapper.Instance.Invoke<IGLMSVE00009, IList<ChargeOfAccountDTO>>(x => x.ChargeOfAccountSelectByPCEAccount(CurrentUserEntity.BranchCode));
                                    
        //                            MNMDTO00054 LedgerListingDTO = new MNMDTO00054();

        //                            IList<MNMDTO00037> ReportDTO = new List<MNMDTO00037>();

        //                            foreach (ChargeOfAccountDTO COADTO in DTOList)
        //                            {
        //                                MNMDTO00037 DTOClosing = new MNMDTO00037();

        //                                if (COADTO.ACode.Substring(3, 3) != "000")
        //                                {
        //                                    DTOClosing.ACode = COADTO.ACode;
        //                                    DTOClosing.ACName = COADTO.DCODE;
        //                                    IList<MNMDTO00054> LedgerListingDTOList = new List<MNMDTO00054>();

        //                                    string budMonth = DateTime.Now.Month < 4 ? "M" + (DateTime.Now.Month + 9).ToString() : "M" + (DateTime.Now.Month - 3).ToString();

        //                                    MNMDTO00010 openingBalance = CXClientWrapper.Instance.Invoke<IGLMSVE00009, MNMDTO00010>(x => x.VW_CCOA_SumMonthByACode(DTOClosing.ACode,this.View.Currency,budMonth));
        //                                    DTOClosing.closingBalance = openingBalance.AMOUNT;

        //                                    if (this.view.IsCheckHomeCurrency == true)
        //                                    {
        //                                        LedgerListingDTOList = CXClientWrapper.Instance.Invoke<IGLMSVE00009, IList<MNMDTO00054>>(x => x.VW_LedgerListingByHomeCurrency(DTOClosing.ACode, this.view.StartDate, this.view.EndDate, CurrentUserEntity.BranchCode, CurrentUserEntity.WorkStationId));
        //                                    }
        //                                    else
        //                                    {
        //                                        LedgerListingDTOList = CXClientWrapper.Instance.Invoke<IGLMSVE00009, IList<MNMDTO00054>>(x => x.VW_LedgerListingBySourceCurrency(DTOClosing.ACode, this.view.StartDate, this.view.EndDate, CurrentUserEntity.BranchCode, CurrentUserEntity.WorkStationId));
        //                                    }

        //                                    if (ReportDTO.Count > 0)
        //                                    {
        //                                        foreach (MNMDTO00054 dto in LedgerListingDTOList)
        //                                        {
        //                                            LedgerListingDTO.ACODE = dto.ACODE;
        //                                            LedgerListingDTO.ACTYPE = dto.ACTYPE;
        //                                            LedgerListingDTO.DATE_TIME = dto.DATE_TIME;
        //                                            LedgerListingDTO.DESP = dto.DESP;

        //                                            if (this.view.IsCheckHomeCurrency == true)
        //                                            {
        //                                                LedgerListingDTO.HOMECREDIT = dto.HOMECREDIT;
        //                                                LedgerListingDTO.HOMEDEBIT = dto.HOMEDEBIT;

        //                                                if (LedgerListingDTO.ACTYPE == "A" || LedgerListingDTO.ACTYPE == "E")
        //                                                {
        //                                                    DTOClosing.closingBalance = DTOClosing.closingBalance - LedgerListingDTO.HOMECREDIT;
        //                                                    DTOClosing.closingBalance = DTOClosing.closingBalance + LedgerListingDTO.HOMEDEBIT;
        //                                                }
        //                                                else if (LedgerListingDTO.ACTYPE == "I" || LedgerListingDTO.ACTYPE == "L")
        //                                                {
        //                                                    DTOClosing.closingBalance = DTOClosing.closingBalance + LedgerListingDTO.HOMECREDIT;
        //                                                    DTOClosing.closingBalance = DTOClosing.closingBalance - LedgerListingDTO.HOMEDEBIT;
        //                                                }
        //                                            }
        //                                            else
        //                                            {
        //                                                LedgerListingDTO.CREDIT = dto.CREDIT;
        //                                                LedgerListingDTO.DEBIT = dto.DEBIT;

        //                                                if (LedgerListingDTO.ACTYPE == "A" || LedgerListingDTO.ACTYPE == "E")
        //                                                {
        //                                                    DTOClosing.closingBalance = DTOClosing.closingBalance - LedgerListingDTO.CREDIT;
        //                                                    DTOClosing.closingBalance = DTOClosing.closingBalance + LedgerListingDTO.DEBIT;
        //                                                }
        //                                                else if (LedgerListingDTO.ACTYPE == "I" || LedgerListingDTO.ACTYPE == "L")
        //                                                {
        //                                                    DTOClosing.closingBalance = DTOClosing.closingBalance + LedgerListingDTO.CREDIT;
        //                                                    DTOClosing.closingBalance = DTOClosing.closingBalance - LedgerListingDTO.DEBIT;
        //                                                }
        //                                            }

        //                                        }
        //                                    }

        //                                    ReportDTO.Add(DTOClosing);
        //                                }
        //                            }

        //                            CXUIScreenTransit.Transit("frmGLMVEW00014.ReportViewer", true, new object[] { ReportDTO, this.view.StartDate, this.view.EndDate, this.view.Currency });                  
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    CXUIMessageUtilities.ShowMessageByCode("MV00131"); //Start Date must not be greater than End Date.
        //                }
        //            }
        //            else
        //            {
        //                CXUIMessageUtilities.ShowMessageByCode("MV00130"); //End Date must not be greater than today.
        //            }
        //        }
        //        else
        //        {
        //            CXUIMessageUtilities.ShowMessageByCode("MV00129"); //Start Date must not be greater than today.
        //        }
        //    }            
        //} //
        #endregion


        //modify By ASDA
        public void Preview()
        {
            if (this.ValidateForm(GetEntity()))
            {
                if (this.view.StartDate <= DateTime.Now)
                {
                    if (this.view.EndDate <= DateTime.Now)
                    {
                        if (this.view.StartDate <= this.view.EndDate)
                        {
                            string budInfo3 = CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, DateTime.Now).ToString();
                            if (this.view.IsCheckHomeCurrency)
                            {                                
                                strOpeningField = "MSRC" + (Convert.ToInt16(budInfo3) - 1).ToString();
                                if (strOpeningField == "MSRC0")
                                {
                                    strOpeningField = "HOBAL";
                                }                                
                            }
                            else
                            {
                                strOpeningField = "M" + (Convert.ToInt16(budInfo3) - 1).ToString();
                                if (strOpeningField == "M0")
                                {
                                    strOpeningField = "CBAL";
                                }
                            }
                            string CurBudYear = CXCOM00010.Instance.GetBudgetYear1(""); //2014/2015
                            string Year = CurBudYear.Substring(0, 4);   //2014
                            MNMDTO00037 getBudDateList = CXClientWrapper.Instance.Invoke<IGLMSVE00009, MNMDTO00037>(x => x.NewSetup_SelectSDateEDate(Year));

                            if (this.view.StartDate < getBudDateList.getStartDate)
                            {
                                CXUIMessageUtilities.ShowMessageByCode("MV30021", new object[] { "Start" });
                            }
                            else
                            {
                                if (this.view.EndDate < getBudDateList.getStartDate)
                                {
                                    CXUIMessageUtilities.ShowMessageByCode("MV30021", new object[] { "End" });
                                }
                                else
                                {
                                    IList<MNMDTO00037> ReportDataList = new List<MNMDTO00037>();
                                    IList<ChargeOfAccountDTO> DTOList = CXClientWrapper.Instance.Invoke<IGLMSVE00009, IList<ChargeOfAccountDTO>>(x => x.ChargeOfAccountSelectByPCEAccount(CurrentUserEntity.BranchCode));

                                    foreach (ChargeOfAccountDTO COADTO in DTOList)
                                    {
                                        MNMDTO00037 DTOClosing = new MNMDTO00037();
                                        if (COADTO.ACode.Substring(3, 3) != "000")
                                        {
                                            DTOClosing.ACode = COADTO.ACode;
                                            DTOClosing.ACName = COADTO.DCODE;

                                            formatDate = Convert.ToDateTime(this.view.StartDate.Year + "-" + this.view.StartDate.Month + "-01");

                                            CXClientWrapper.Instance.Invoke<IGLMSVE00009>(x => x.GetReportData(COADTO.ACode, formatDate, this.view.EndDate, this.view.IsTransactionDate, CurrentUserEntity.WorkStationId, CurrentUserEntity.CurrentUserID));
                                            
                                            MNMDTO00010 openingBalance = CXClientWrapper.Instance.Invoke<IGLMSVE00009, MNMDTO00010>(x => x.VW_CCOA_SumMonthByACode(strOpeningField, COADTO.ACode, this.View.Currency, CurBudYear));
                                            DTOClosing.closingBalance = openingBalance.AMOUNT;
                                            //if(this.view.StartDate.Day > 1)
                                            //{
                                            if (this.view.IsCheckHomeCurrency == true)
                                            {
                                                if (this.view.IsTransactionDate == true)
                                                {
                                                    LedgerListingDTOList = CXClientWrapper.Instance.Invoke<IGLMSVE00009, IList<MNMDTO00054>>(x => x.VW_LedgerListingByHomeCurrency(COADTO.ACode, formatDate, this.view.EndDate, true, CurrentUserEntity.BranchCode, CurrentUserEntity.WorkStationId));  //end date == startDate - 1 in VB  (in CBS , endDate parameter didn't change - confirmed by ma KSWin)
                                                }
                                                else
                                                {
                                                    LedgerListingDTOList = CXClientWrapper.Instance.Invoke<IGLMSVE00009, IList<MNMDTO00054>>(x => x.VW_LedgerListingByHomeCurrency(COADTO.ACode, formatDate, this.view.EndDate, false, CurrentUserEntity.BranchCode, CurrentUserEntity.WorkStationId));  //(in VB, endDate parameter == startDate - 1) (in CBS , endDate parameter didn't change - confirmed by ma KSWin)
                                                }
                                            }
                                            else
                                            {
                                                if (this.view.IsTransactionDate == true)
                                                {
                                                    LedgerListingDTOList = CXClientWrapper.Instance.Invoke<IGLMSVE00009, IList<MNMDTO00054>>(x => x.VW_LedgerListingBySourceCurrency(COADTO.ACode, formatDate, this.view.EndDate, this.view.Currency, true, CurrentUserEntity.BranchCode, CurrentUserEntity.WorkStationId));  //end date == startDate - 1 in VB  (in CBS , endDate parameter didn't change - confirmed by ma KSWin)
                                                }
                                                else
                                                {
                                                    LedgerListingDTOList = CXClientWrapper.Instance.Invoke<IGLMSVE00009, IList<MNMDTO00054>>(x => x.VW_LedgerListingBySourceCurrency(COADTO.ACode, formatDate, this.view.EndDate, this.view.Currency, false, CurrentUserEntity.BranchCode, CurrentUserEntity.WorkStationId));  //(in VB, endDate parameter == startDate - 1) (in CBS , endDate parameter didn't change - confirmed by ma KSWin)
                                                }
                                            }
                                            //}
                                            if (LedgerListingDTOList.Count > 0)
                                            {
                                                foreach (MNMDTO00054 dto in LedgerListingDTOList)
                                                {
                                                    if (dto.ACTYPE == "A" || dto.ACTYPE == "E")
                                                    {
                                                        DTOClosing.closingBalance = DTOClosing.closingBalance - dto.HOMECREDIT;
                                                        DTOClosing.closingBalance = DTOClosing.closingBalance + dto.HOMEDEBIT;
                                                    }
                                                    else if (dto.ACTYPE == "I" || dto.ACTYPE == "L")
                                                    {
                                                        DTOClosing.closingBalance = DTOClosing.closingBalance + dto.HOMECREDIT;
                                                        DTOClosing.closingBalance = DTOClosing.closingBalance - dto.HOMEDEBIT;
                                                    }
                                                }
                                            }
                                            ReportDataList.Add(DTOClosing);
                                        }                                        
                                    } 
                                    CXUIScreenTransit.Transit("frmGLMVEW00014.ReportViewer", true, new object[] { ReportDataList, this.view.StartDate, this.view.EndDate, this.view.Currency });
                                }
                            }
                        }
                        else
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MV00131"); //Start Date must not be greater than End Date.
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00130"); //End Date must not be greater than today.
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV00129"); //Start Date must not be greater than today.
                }
            }
        }
    }
}
