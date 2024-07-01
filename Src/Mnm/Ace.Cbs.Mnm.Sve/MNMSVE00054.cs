using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Cx.Com.Ctr;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Dmd.DTO;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00054 : BaseService, IMNMSVE00054
    {
        #region DAO
        public ICXSVE00010 DataGenerateService { get; set; }
        public IPFMDAO00042 ReportTlfDAO { get; set; }
        public ICXDAO00009 ViewDAO { get; set; }
        private IList<MNMDTO00054> PrintDataLists = new List<MNMDTO00054>();

        private ICXDAO00014 blfDAO;
        public ICXDAO00014 BLFDAO
        {
            get { return this.blfDAO; }
            set { this.blfDAO = value; }
        }

        #endregion

        #region MainMethod

        [Transaction(TransactionPropagation.Required)]
        public IList<MNMDTO00054> GetReportData(PFMDTO00042 dataDTO, int workStationId, int createdUserId, string sourceBr)
        {
            IList<MNMDTO00054> PrintDataLists = new List<MNMDTO00054>();
            PFMDTO00042 ReportTlfData = this.GetDataForReportTLF(dataDTO, workStationId, createdUserId);
            MNMDTO00010 GetHOBalAndCBal = this.GetHOBaLAndCBalForSubLedger_DomesticSVE(dataDTO, sourceBr);
            if (GetHOBalAndCBal == null)
            {
                return null;
            }
            string date1 = dataDTO.StartDate.ToString("yyyy/MM/dd").Substring(0, 7) + "/01";
            string date2 = this.SubtractDays(dataDTO.StartDate, 1).ToString("yyyy/MM/dd");
            string sourcebr = dataDTO.SourceBranch;
            string workstation = workStationId.ToString();


            MNMDTO00054 item = new MNMDTO00054();
            int SrNo = 0;
            string DateTime = string.Empty;

            string Desp = string.Empty;

            if (dataDTO.StartDate.Day > 1)
            {//' For cash transaction but it not made with cash account
                if (dataDTO.Status == "Cash")
                {
                    if (dataDTO.IsHomeCurrency == true)
                    {
                        if (dataDTO.TransactionStatus == "T")
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListingByDateTime(date1, date2, workstation, sourcebr);
                        }
                        else if (dataDTO.TransactionStatus == "S")
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListingBySettlementDate(date1, date2, workstation, sourcebr);
                        }
                    }
                    else
                    {
                        if (dataDTO.TransactionStatus == "T")
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListingByDateTimeAndCurrency(date1, date2, dataDTO.CurrencyType, workstation, sourcebr);
                        }
                        else if (dataDTO.TransactionStatus == "S")
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListingBySettlementDateAndCurrency(date1, date2, dataDTO.CurrencyType, workstation, sourcebr);
                        }
                    }
                    if (PrintDataLists.Count > 0)
                    {
                        foreach (MNMDTO00054 printdata in PrintDataLists)
                        {
                            if (printdata.ACODE.ToUpper() != dataDTO.ACode.ToUpper())
                            {
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount + Convert.ToDecimal(printdata.CREDIT);
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount - Convert.ToDecimal(printdata.DEBIT);
                            }
                            else
                            {
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount - Convert.ToDecimal(printdata.CREDIT);
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount + Convert.ToDecimal(printdata.DEBIT);
                            }
                        }
                    }
                }
                else if (dataDTO.Status == "OD")
                {
                    if (dataDTO.IsHomeCurrency == true)
                    {
                        if (dataDTO.TransactionStatus == "T")
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListingByDateTime(date1, date2, workstation, sourcebr);
                        }
                        else if (dataDTO.TransactionStatus == "S")
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListingBySettlementDate(date1, date2, workstation, sourcebr);
                        }
                    }
                    else
                    {
                        if (dataDTO.TransactionStatus == "T")
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListingByDateTimeAndCurrency(date1, date2, dataDTO.CurrencyType, workstation, sourcebr);
                        }
                        else if (dataDTO.TransactionStatus == "S")
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListingBySettlementDateAndCurrency(date1, date2, dataDTO.CurrencyType, workstation, sourcebr);
                        }
                    }
                    if (PrintDataLists.Count > 0)
                    {
                        foreach (MNMDTO00054 printdata in PrintDataLists)
                        {
                            if (printdata.ACODE.ToUpper() != dataDTO.ACode.ToUpper())
                            {
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount + Convert.ToDecimal(printdata.ODEBIT);
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount - Convert.ToDecimal(printdata.OCREDIT);
                            }
                            else
                            {
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount - Convert.ToDecimal(printdata.CREDIT);
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount + Convert.ToDecimal(printdata.DEBIT);
                            }
                        }
                    }
                }
                else  //dataDTO.Status == "A"
                {
                    if (dataDTO.TransactionStatus == "T")
                    {
                        if (dataDTO.IsHomeCurrency)
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListing_ByACtypeAndDateTime(dataDTO.ACode, date1, date2, workstation, sourcebr);
                        }
                        else
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListing_ByACtypeAndDateTimeAndCur(dataDTO.ACode, date1, date2, dataDTO.CurrencyType, workstation, sourcebr);
                        }
                    }
                    else   //BySettlementDate
                    {
                        if (dataDTO.IsHomeCurrency)
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListing_ByACtypeAndSettlementDate(dataDTO.ACode, date1, date2, workstation, sourcebr);
                        }
                        else
                        {
                            PrintDataLists = ViewDAO.SelectLedgerListing_ByACtypeAndSettlementDateAndCur(dataDTO.ACode, date1, date2, dataDTO.CurrencyType, workstation, sourcebr);
                        }
                    }
                    if (PrintDataLists.Count > 0)
                    {
                        foreach (MNMDTO00054 printdata in PrintDataLists)
                        {
                            if (printdata.ACTYPE.Trim() == "A" || printdata.ACTYPE.Trim() == "E")
                            {
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount - Convert.ToDecimal(printdata.CREDIT);
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount + Convert.ToDecimal(printdata.DEBIT);
                            }
                            else if (printdata.ACTYPE.Trim() == "I" || printdata.ACTYPE.Trim() == "L")
                            {
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount + Convert.ToDecimal(printdata.CREDIT);
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount - Convert.ToDecimal(printdata.DEBIT);
                            }
                        }
                    }
                }
            }
            SrNo = 1;
            item.SrNo = SrNo;
            item.DATE_TIME = dataDTO.StartDate;
            item.CREDIT = 0;
            item.DEBIT = 0;
            item.DESP = "Opening Balance";
            item.Balance = GetHOBalAndCBal.CCOAAmount;
            PrintDataLists.Add(item);

            //GetLedgerListing for closing balance          
            if (PrintDataLists.Count > 0)
            {
                IList<MNMDTO00054> LedgerListing = this.GetLedgerListing(dataDTO, workStationId);

                if (LedgerListing.Count > 0)
                {
                    foreach (MNMDTO00054 printdata in LedgerListing)
                    {
                        MNMDTO00054 Ledgeritem = new MNMDTO00054();
                        SrNo = SrNo + 1;
                        Ledgeritem.SrNo = SrNo;
                        Ledgeritem.DATE_TIME = printdata.DATE_TIME;
                        Ledgeritem.DESP = printdata.DESP;
                        Ledgeritem.NARRATION = printdata.NARRATION;

                        //' July 17 Cash Transaction will be display inverse wtih transaction which made with not cash account
                        if (dataDTO.Status == "Cash")
                        {
                            //if (printdata.ACODE != dataDTO.ACode)
                            //{
                            Ledgeritem.CREDIT = printdata.HOMECREDIT;
                            Ledgeritem.DEBIT = printdata.HOMEDEBIT;
                            //}
                            //else
                            //{
                            GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount - printdata.HOMECREDIT;
                            GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount + printdata.HOMEDEBIT;
                            //}
                        }
                        else if (dataDTO.Status == "OD")
                        {
                            //if (printdata.ACODE != dataDTO.ACode)
                            //{
                            Ledgeritem.CREDIT = printdata.HOMEOCREDIT;
                            Ledgeritem.DEBIT = printdata.HOMEODEBIT;
                            //}
                            //else
                            //{
                            GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount - printdata.HOMEOCREDIT;
                            GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount + printdata.HOMEODEBIT;
                            //}
                        }
                        else
                        {
                            //if (printdata.ACODE != dataDTO.ACode)
                            //{
                            Ledgeritem.CREDIT = printdata.HOMECREDIT;
                            Ledgeritem.DEBIT = printdata.HOMEDEBIT;
                            //}
                            //else
                            //{
                            if (printdata.ACTYPE == "A" || printdata.ACTYPE == "E")
                            {
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount - printdata.HOMECREDIT;
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount + printdata.HOMEDEBIT;
                            }
                            else if (printdata.ACTYPE == "I" || printdata.ACTYPE == "L")
                            {
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount + printdata.HOMECREDIT;
                                GetHOBalAndCBal.CCOAAmount = GetHOBalAndCBal.CCOAAmount - printdata.HOMEDEBIT;
                            }
                            //}
                        }
                        Ledgeritem.Balance = GetHOBalAndCBal.CCOAAmount;
                        PrintDataLists.Add(Ledgeritem);
                    }


                }

                MNMDTO00054 Closingitem = new MNMDTO00054();
                Closingitem.SrNo = SrNo + 1;
                Closingitem.DATE_TIME = dataDTO.EndDate;
                Closingitem.CREDIT = 0;
                Closingitem.DEBIT = 0;
                Closingitem.DESP = "Closing Balance";
                Closingitem.Balance = GetHOBalAndCBal.CCOAAmount;
                PrintDataLists.Add(Closingitem);
            }

            return PrintDataLists;
        }

        public MNMDTO00010 GetHOBaLAndCBalForSubLedger_DomesticSVE(PFMDTO00042 dataDTO,string sourceBr)
        {
            MNMDTO00010 ccoadto = new MNMDTO00010();
            IList<MNMDTO00010> ccoa = new List<MNMDTO00010>();

            string strOpeningField = string.Empty;
            string strAccountNo = string.Empty;
            string numAccountNo = string.Empty;
            string strSQLFilter = string.Empty;
            //string strSQLFilter1 = string.Empty;
            string dblBalance = string.Empty;

            // Modified By ZMS For Budget End Flexible 2018/09/21
            //string budInfo3 = CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, dataDTO.StartDate).ToString();
            string Return = String.Empty;
            string budInfo3 = BLFDAO.GetBudget_Month_Year_Quarter(3, dataDTO.StartDate, sourceBr, Return); // For 2018/09/17 => 6

            if (dataDTO.IsHomeCurrency == true)
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
                    strOpeningField = "Cbal";
                }
            }

            // Modified By ZMS For Budget End Flexible 2018/09/21
            //string budYear = CXCOM00010.Instance.GetBudgetYear_For_PreviousBudget(CXCOM00009.BudgetYearCode, dataDTO.StartDate);  // Added By AAM (29-Jan-2018)         
            string budYear = BLFDAO.GetBudget_Month_Year_Quarter(2, dataDTO.StartDate, sourceBr, Return); // For 2018/09/17 => 2018/2018

            for (int counter = 0; counter < dataDTO.ACode.Length; counter++)
            {
                if (!Char.IsNumber(dataDTO.ACode.Substring(counter, 1), 0))
                {
                    strAccountNo = strAccountNo + dataDTO.ACode.Substring(counter, 1).ToString();
                }
            }
            if (dataDTO.ACode.Substring(0, strAccountNo.Length) == strAccountNo)
            {
                if (Char.IsNumber(strAccountNo, strAccountNo.Length - 1) && dataDTO.ACode.Substring((dataDTO.ACode.Length - 1), 1) == "0")
                {
                    strSQLFilter = "like " + strAccountNo + "'%' and c.ACODE Not like " + strAccountNo + "'%000'";
                }
                else
                {
                    strSQLFilter = dataDTO.ACode;
                }
            }
            //'Yearly Closing Modify
            if (dataDTO.IsHomeCurrency == true)
            {
                //ccoa = this.ViewDAO.GetHOBaLAndCBalForSubLedger_Domestic(strSQLFilter, budYear, CurrentUserEntity.BranchCode);
                ccoa = this.ViewDAO.GetHOBaLAndCBalForSubLedger_Domestic(strSQLFilter, budYear, dataDTO.SourceBranch);
            }
            else
            {
                //ccoa = this.ViewDAO.GetHOBaLAndCBalForSubLedger_DomesticByCur(dataDTO.CurrencyType,strSQLFilter, budYear, CurrentUserEntity.BranchCode);
                ccoa = this.ViewDAO.GetHOBaLAndCBalForSubLedger_DomesticByCur(dataDTO.CurrencyType, strSQLFilter, budYear, dataDTO.SourceBranch);
            }
            if (ccoa.Count > 0)
            {
                switch (strOpeningField)
                {
                    case "M1": decimal m1 = (from value in ccoa
                                             select value.M1.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m1;
                        break;

                    case "M2": decimal m2 = (from value in ccoa
                                             select value.M2.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m2;
                        break;
                    case "M3": decimal m3 = (from value in ccoa
                                             select value.M3.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m3;
                        break;
                    case "M4": decimal m4 = (from value in ccoa
                                             select value.M4.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m4;
                        break;
                    case "M5": decimal m5 = (from value in ccoa
                                             select value.M5.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m5;
                        break;
                    case "M6": decimal m6 = (from value in ccoa
                                             select value.M6.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m6;
                        break;
                    case "M7": decimal m7 = (from value in ccoa
                                             select value.M7.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m7;
                        break;
                    case "M8": decimal m8 = (from value in ccoa
                                             select value.M8.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m8;
                        break;
                    case "M9": decimal m9 = (from value in ccoa
                                             select value.M9.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m9;
                        break;
                    case "M10": decimal m10 = (from value in ccoa
                                               select value.M10.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m10;
                        break;
                    case "M11": decimal m11 = (from value in ccoa
                                               select value.M11.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m11;
                        break;

                    case "M12": decimal m12 = (from value in ccoa
                                               select value.M12.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m12;
                        break;

                    case "M13": decimal m13 = (from value in ccoa
                                               select value.M13.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = m13;
                        break;

                    case "MSRC1": decimal MSRC1 = (from value in ccoa
                                                   select value.M1.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC1;
                        break;

                    case "MSRC2": decimal MSRC2 = (from value in ccoa
                                                   select value.M2.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC2;
                        break;
                    case "MSRC3": decimal MSRC3 = (from value in ccoa
                                                   select value.M3.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC3;
                        break;
                    case "MSRC4": decimal MSRC4 = (from value in ccoa
                                                   select value.M4.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC4;
                        break;
                    case "MSRC5": decimal MSRC5 = (from value in ccoa
                                                   select value.M5.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC5;
                        break;
                    case "MSRC6": decimal MSRC6 = (from value in ccoa
                                                   select value.M6.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC6;
                        break;
                    case "MSRC7": decimal MSRC7 = (from value in ccoa
                                                   select value.M7.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC7;
                        break;
                    case "MSRC8": decimal MSRC8 = (from value in ccoa
                                                   select value.M8.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC8;
                        break;
                    case "MSRC9": decimal MSRC9 = (from value in ccoa
                                                   select value.M9.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC9;
                        break;
                    case "MSRC10": decimal MSRC10 = (from value in ccoa
                                                     select value.M10.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC10;
                        break;
                    case "MSRC11": decimal MSRC11 = (from value in ccoa
                                                     select value.M11.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC11;
                        break;

                    case "MSRC12": decimal MSRC12 = (from value in ccoa
                                                     select value.M12.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC12;
                        break;

                    case "MSRC13": decimal MSRC13 = (from value in ccoa
                                                     select value.M13.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = MSRC13;
                        break;

                    case "HOBAL": decimal hoBal = (from value in ccoa
                                                   select value.HOBAL.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = hoBal;
                        break;

                    case "CBAL": decimal Cbal = (from value in ccoa
                                                 select value.CBAL.Value).SingleOrDefault();
                        ccoadto.CCOAAmount = Cbal;
                        break;
                }
            }
            else
            {
                ServiceResult.ErrorOccurred = true;
                ServiceResult.MessageCode = "ME00069";  //Error occured while calculating opening balance for selected account.
                return null;
            }
            return ccoadto;
        }

        public DateTime SubtractDays(DateTime time, int days)
        {
            return time - new TimeSpan(days, 0, 0, 0);
        }

        public string Right(string str, int length)
        {
            return str.Substring(str.Length - length);
        }

        public PFMDTO00042 GetDataForReportTLF(PFMDTO00042 DataDTO, int workStationId, int createdUserId)
        {
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();

            CXDTO00006 reportparameters = new CXDTO00006();
            reportparameters.ACode = DataDTO.ACode;
            reportparameters.StartDate = DataDTO.StartDate;
            reportparameters.EndDate = DataDTO.EndDate;
            reportparameters.CurrencyCode = DataDTO.CurrencyType;
            reportparameters.BDateType = DataDTO.TransactionStatus;
            reportparameters.CreatedUserId = createdUserId;
            reportparameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            reportparameters.WorkStationId = workStationId;
            reportparameters.UserNo = workStationId.ToString();

            if (DataDTO.Status == "Cash")
            {
                reportparameters.SpecialCondition = "Status Like 'C%'";
            }
            else if (DataDTO.Status == "OD")
            {
                reportparameters.SpecialCondition = "LocalOAmt > 0 Or ACode = '" + DataDTO.ACode + "'";
            }
            else
            {
                reportparameters.SpecialCondition = "ACode = '" + DataDTO.ACode + "' and sourceBr = '" + DataDTO.SourceBranch + "'";
            }

            DataGenerateDTO = this.DataGenerateService.GetReportDataGenerateInSQL(reportparameters);
            return DataGenerateDTO;
        }

        public IList<MNMDTO00054> GetLedgerListing(PFMDTO00042 dataDTO, int workStatiionId)
        {
            //string sourcebr = CurrentUserEntity.BranchCode;
            //string workstation = CurrentUserEntity.WorkStationId.ToString() ;
            string sourcebr = dataDTO.SourceBranch;
            string workstation = workStatiionId.ToString();
            if (dataDTO.IsHomeCurrency)
            {
                if (dataDTO.TransactionStatus == "T" && dataDTO.Status == "Cash")
                {   
                    //PrintDataLists = ViewDAO.GetLedgerListingRptByTDate(dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr); // Commented By AAM(27-Feb-2018)

                    // Added By By AAM(27-Feb-2018)
                    PrintDataLists = ViewDAO.GetLedgerListingRptByTDate_ForCashInHands(dataDTO.ACode, dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr);               

                }
                else if (dataDTO.TransactionStatus == "T" && dataDTO.Status == "OD")
                {
                   PrintDataLists = ViewDAO.GetLedgerListingRptByTDate1(dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr);
                }
                // For Pristine Version ZMS (28.11.2017) ///
                else if (dataDTO.TransactionStatus == "T" && dataDTO.Status == "LOANSTOD")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptByTDate1(dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr);
                }
                else if (dataDTO.TransactionStatus == "T" && dataDTO.Status == "HPTOD")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptByTDate1(dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr);
                }
                // For Pristine Version ZMS (28.11.2017) ///
                else if (dataDTO.TransactionStatus == "T" && dataDTO.Status == "A")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptByTDate2(dataDTO.ACode, dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr);
                }
                else if (dataDTO.TransactionStatus == "S" && dataDTO.Status == "Cash")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySDate(dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr);
                }
                else if (dataDTO.TransactionStatus == "S" && dataDTO.Status == "OD")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySDate1(dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr);
                }
                // For Pristine Version ZMS (28.11.2017) ///
                else if (dataDTO.TransactionStatus == "S" && dataDTO.Status == "LOANSTOD")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySDate1(dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr);
                }
                else if (dataDTO.TransactionStatus == "S" && dataDTO.Status == "HPTOD")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySDate1(dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr);
                }
                // For Pristine Version ZMS (28.11.2017) ///
                else if (dataDTO.TransactionStatus == "S" && dataDTO.Status == "A")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySDate2(dataDTO.ACode, dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr);
                }
            }
            else
            {
                if (dataDTO.TransactionStatus == "T" && dataDTO.Status == "Cash")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySourceCurAndTdate(dataDTO.StartDate, dataDTO.EndDate, dataDTO.CurrencyType, workstation, sourcebr);
                }
                else if (dataDTO.TransactionStatus == "T" && dataDTO.Status == "OD")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySourceCurAndTdate(dataDTO.StartDate, dataDTO.EndDate, dataDTO.CurrencyType, workstation, sourcebr);
                }
                // For Pristine Version ZMS (28.11.2017) ///
                else if (dataDTO.TransactionStatus == "T" && dataDTO.Status == "LOANSTOD")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySourceCurAndTdate(dataDTO.StartDate, dataDTO.EndDate, dataDTO.CurrencyType, workstation, sourcebr);
                }
                else if (dataDTO.TransactionStatus == "T" && dataDTO.Status == "HPTOD")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySourceCurAndTdate(dataDTO.StartDate, dataDTO.EndDate, dataDTO.CurrencyType, workstation, sourcebr);
                }
                // For Pristine Version ZMS (28.11.2017) ///
                else if (dataDTO.TransactionStatus == "T" && dataDTO.Status == "A")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySourceCurAndTdate2(dataDTO.ACode, dataDTO.StartDate, dataDTO.EndDate, dataDTO.CurrencyType, workstation, sourcebr);
                }
                else if (dataDTO.TransactionStatus == "S" && dataDTO.Status == "Cash")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySourceCurAndSdate(dataDTO.StartDate, dataDTO.EndDate, dataDTO.CurrencyType, workstation, sourcebr);
                }
                else if (dataDTO.TransactionStatus == "S" && dataDTO.Status == "OD")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySourceCurAndSdate1(dataDTO.StartDate, dataDTO.EndDate, dataDTO.CurrencyType, workstation, sourcebr);
                }
                // For Pristine Version ZMS (28.11.2017) ///
                else if (dataDTO.TransactionStatus == "S" && dataDTO.Status == "LOANSTOD")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySourceCurAndSdate1(dataDTO.StartDate, dataDTO.EndDate, dataDTO.CurrencyType, workstation, sourcebr);
                }
                else if (dataDTO.TransactionStatus == "S" && dataDTO.Status == "HPTOD")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySourceCurAndSdate1(dataDTO.StartDate, dataDTO.EndDate, dataDTO.CurrencyType, workstation, sourcebr);
                }
                // For Pristine Version ZMS (28.11.2017) ///
                else if (dataDTO.TransactionStatus == "S" && dataDTO.Status == "A")
                {
                    PrintDataLists = ViewDAO.GetLedgerListingRptBySourceCurAndSdate2(dataDTO.ACode, dataDTO.StartDate, dataDTO.EndDate, dataDTO.CurrencyType, workstation, sourcebr);
                }
            }
            return PrintDataLists;
        }

        //public IList<MNMDTO00082> GetLedgerListing_ForCashInHands(PFMDTO00042 dataDTO, int workStatiionId)
        //{
        //    // Added By AAM (23-Feb-2018)
        //    string sourcebr = dataDTO.SourceBranch;
        //    string workstation = workStatiionId.ToString();

        //    PrintDataLists_ForCASH = ViewDAO.GetLedgerListingRptByTDate_ForCashInHands(dataDTO.StartDate, dataDTO.EndDate, workstation, sourcebr);
        //    return PrintDataLists_ForCASH;
        //}
        #endregion


    }
}
