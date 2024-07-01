using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Service;
//using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Gl.Ctr.Dao;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Mnm.Dmd;

//need to add new refrence
using Ace.Cbs.Mnm.Ctr.Dao;

namespace Ace.Cbs.Gl.Sve
{
    public class GLMSVE00023 : BaseService, IGLMSVE00023
    {
        #region Properties

        IList<string> MessageList = new List<string>();
        private IPFMDAO00056 sys001DAO;
        public IPFMDAO00056 Sys001DAO
        {
            get { return this.sys001DAO; }
            set { this.sys001DAO = value; }
        }
        private IGLMDAO00023 monthlyccoaDAO;
        public IGLMDAO00023 MonthlyccoaDAO
        {
            get { return this.monthlyccoaDAO; }
            set { this.monthlyccoaDAO = value; }
        }
        private IMNMDAO00030 reporttlfDAO;
        public IMNMDAO00030 ReporttlfDAO
        {
            get { return this.reporttlfDAO; }
            set { this.reporttlfDAO = value; }
        }
        private ICXDAO00014 ccoaDAO;
        public ICXDAO00014 CcoaDAO
        {
            get { return this.ccoaDAO; }
            set { this.ccoaDAO = value; }
        }
        public ICXSVE00010 DataGenerateService { get; set; }//for inserting report tlf
        IList<GLMDTO00023> Monthly_coaDataList { get; set; }
        private GLMORM00023 monthly_coaORM;
        string namepost = "Monthly_Posting";
        #endregion

        #region Save
        [Transaction(TransactionPropagation.Required)]
        public void Save(GLMDTO00023 gLMDTO00023)
        {
            try
            {
                if (gLMDTO00023.DCode != "All")
                    this.MonthlyccoaDAO.SaveAll(gLMDTO00023);
                else
                {
                    IList<GLMDTO00023> branchcodelst= this.SelectAllBranchCode().Where(x=>x.BranchCode != "All").ToList<GLMDTO00023>();

                    for (int i = 0; i < branchcodelst.Count; i++)
                    {
                        gLMDTO00023.DCode = branchcodelst[i].BranchCode;
                        this.MonthlyccoaDAO.SaveAll(gLMDTO00023);
                    }
                }

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";                           

            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000";
                throw;
            }
        }
        #endregion

        #region Update
       [Transaction(TransactionPropagation.Required)]
        public void Update(GLMDTO00023 gLMDTO00023, List<GLMDTO00023> TitleOrderList, List<GLMDTO00023> SubTitleOrderList )
        {
            try
            {
                if (gLMDTO00023.DCode != "All")
                {
                    this.MonthlyccoaDAO.Update_All(gLMDTO00023);

                    #region TitleOrder
                    if (TitleOrderList.Count > 0)
                    {
                        for (int j = 0; j < TitleOrderList.Count; j++)
                        {
                            this.MonthlyccoaDAO.Update_Title_ItemOrder(TitleOrderList[j]);
                        }
                    }
                    #endregion

                    #region SubTitleOrder
                    if (SubTitleOrderList.Count > 0)
                    {
                        for (int k = 0; k < SubTitleOrderList.Count; k++)
                        {
                            this.MonthlyccoaDAO.Update_SubTitle_SubItemOrder(SubTitleOrderList[k]);
                        }
                    }
                    #endregion
                }
                else
                {
                    IList<GLMDTO00023> branchcodelst = this.SelectAllBranchCode().Where(x => x.BranchCode != "All").ToList<GLMDTO00023>();

                    for (int i = 0; i < branchcodelst.Count; i++)
                    {
                        gLMDTO00023.DCode = branchcodelst[i].BranchCode;
                        this.MonthlyccoaDAO.Update_All(gLMDTO00023);

                        #region TitleOrder
                        if (TitleOrderList.Count > 0)
                        {
                            for (int j = 0; j < TitleOrderList.Count; j++)
                            {
                                TitleOrderList[j].DCode = branchcodelst[i].BranchCode;
                                this.MonthlyccoaDAO.Update_Title_ItemOrder(TitleOrderList[j]);
                            }
                        }
                        #endregion

                        #region SubTitleOrder
                        if (SubTitleOrderList.Count > 0)
                        {
                            for (int k = 0; k < SubTitleOrderList.Count; k++)
                            {
                                SubTitleOrderList[k].DCode = branchcodelst[i].BranchCode;
                                this.MonthlyccoaDAO.Update_SubTitle_SubItemOrder(SubTitleOrderList[k]);
                            }
                        }
                        #endregion
                    }
                }

                

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";                           

            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90000";
                throw;
            }
        }
        #endregion

        #region Delete
       [Transaction(TransactionPropagation.Required)]
       public void Delete(GLMDTO00023 gLMDTO00023)
       {
           try
           {
               if (gLMDTO00023.DCode != "All")
                   this.MonthlyccoaDAO.DeleteAll(gLMDTO00023);
               else
               {
                   IList<GLMDTO00023> branchcodelst = this.SelectAllBranchCode().Where(x => x.BranchCode != "All").ToList<GLMDTO00023>();

                   for (int i = 0; i < branchcodelst.Count; i++)
                   {
                       gLMDTO00023.DCode = branchcodelst[i].BranchCode;
                       this.MonthlyccoaDAO.DeleteAll(gLMDTO00023);
                   }
               }

               this.ServiceResult.ErrorOccurred = false;
               this.ServiceResult.MessageCode = "MI90003";

           }
           catch (Exception ex)
           {
               this.ServiceResult.ErrorOccurred = true;
               this.ServiceResult.MessageCode = "ME90002";
               throw;
           }
       }
       #endregion

        #region Methods
        //public virtual string CheckDate(DateTime Dailydate, string sourcebr)
        //{
        //    //string selectdate = this.SyspostDAO.SelectbyYearpost(namepost, sourcebr);
        //    //if (String.IsNullOrEmpty(selectdate))
        //    //{
        //    //    this.ServiceResult.ErrorOccurred = true;
        //    //    return this.ServiceResult.MessageCode = "ME30011";// Data Not Found in SysPost {0}.
        //    //}
        //    //string selectvalue = this.NewsetupDAO.SelectBudDate("BUDEDATE").ToString();
        //    //DateTime selectdate2 = Convert.ToDateTime(selectdate);

        //    //int post_Day = selectdate2.Day;

        //    //int lastyear = selectdate2.Year;
        //    //int nextyear = lastyear + 1;
        //    //int datetxtyear = Dailydate.Year;

        //    //int lastmonth = selectdate2.Month;
        //    //int datetxtmonth = Dailydate.Month;

        //    //string nextdate = selectvalue + "/" + nextyear;

        //    string nextdatestr = "03";
        //    int nextmonth = Convert.ToInt32(nextdatestr);

        //    string lastdaystr = "31";
        //    int lastday = Convert.ToInt32(lastdaystr);
        //    int datetxtday = Dailydate.Day;

        //    string nextdaystr = "31";
        //    int nextday = Convert.ToInt32(nextdaystr);

        //    string message = "31/03/" + nextyear;

        //    if (lastmonth <= datetxtmonth && lastyear < datetxtyear && (datetxtyear - lastyear) != 1)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        return this.ServiceResult.MessageCode = "MI30012," + message;// Please post balances for the year {0} first.
        //    }

        //    else if (lastyear > datetxtyear)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        return this.ServiceResult.MessageCode = "ME30005";//Yearly posting is already finished.Please contact your administrator.
        //    }

        //    else if (nextyear < datetxtyear)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        return this.ServiceResult.MessageCode = "MI30010";// No need to run yearly posting.Please contact your system administrator.
        //    }

        //    else
        //    {
        //        if (nextyear == datetxtyear)
        //        {
        //            if (nextmonth < datetxtmonth)
        //            {
        //                this.ServiceResult.ErrorOccurred = true;
        //                return this.ServiceResult.MessageCode = "MI30010";// Need to run Yearly Posting.

        //            }
        //        }

        //    }
        //    if (lastyear > datetxtyear && nextyear < datetxtyear)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        return this.ServiceResult.MessageCode = "ME30005";// finished yearly posting
        //    }
        //    else
        //    {
        //        if (lastyear == datetxtyear)
        //        {
        //            if (lastmonth > datetxtmonth && nextmonth < datetxtmonth)
        //            {
        //                this.ServiceResult.ErrorOccurred = true;
        //                return this.ServiceResult.MessageCode = "ME30005";// finished yearly posting

        //            }
        //            else if (nextmonth == datetxtmonth && post_Day == datetxtday)
        //            {
        //                this.ServiceResult.ErrorOccurred = true;
        //                return this.ServiceResult.MessageCode = "ME30005";//Yearly posting is already finished.Please contact your administrator.
        //            }
        //        }
        //        else if (nextyear == datetxtyear)
        //        {
        //            if (lastmonth > datetxtmonth && nextmonth < datetxtmonth)
        //            {
        //                this.ServiceResult.ErrorOccurred = true;
        //                return this.ServiceResult.MessageCode = "ME30005";// finished yearly posting

        //            }
        //            else if (nextmonth > datetxtmonth && post_Day == datetxtday)
        //            {
        //                this.ServiceResult.ErrorOccurred = true;
        //                return this.ServiceResult.MessageCode = "ME30005";//Yearly posting is already finished.Please contact your administrator.
        //            }
        //        }
        //    }
        //    //if (datetxtday - lastday <= 0)
        //    //{
        //    //    this.ServiceResult.ErrorOccurred = true;
        //    //    this.ServiceResult.MessageCode = "MI30004";// finished yearly posting
        //    //    return;
        //    //}
        //    //if (datetxtday - nextday > 0)
        //    //{
        //    //    this.ServiceResult.ErrorOccurred = true;
        //    //    this.ServiceResult.MessageCode = "MI30004";// finished yearly posting
        //    //    return;
        //    //}
        //    return null;
        //}
        #endregion

        #region Insert Report_TLF

        [Transaction(TransactionPropagation.Required)]
        public void GetDataForInsert(DateTime StartDate, DateTime EndDate, int createdUserId, string workStation, string branchCode)
        {
            CXDTO00006 parameters = new CXDTO00006();
            PFMDTO00042 DataGenerateDTO = new PFMDTO00042();
            parameters.StartDate = StartDate;
            parameters.EndDate = EndDate;
            parameters.ForCheck_Or_ForReturn = CXDMD00009.ForReturn;
            parameters.BDateType = "T";
            parameters.UserNo = workStation;
            parameters.CreatedUserId = createdUserId;
            parameters.SpecialCondition = "SourceBr = " + "'" + branchCode + "'";
            DataGenerateDTO = DataGenerateService.GetReportDataGenerateInSQL(parameters);
        }
        [Transaction(TransactionPropagation.Required)]
        public void DataInsertForAll(string sourcebr)
        {
            IList<PFMDTO00042> reporttlflist = this.GetAllRTLF(sourcebr);
        }
        public virtual IList<PFMDTO00042> GetAllRTLF(string sourcebr)
        {
            return this.ReporttlfDAO.SelectAll(sourcebr);
        }
        #endregion

        #region Posting
        public virtual void Posting(DateTime startDate, DateTime endDate, string workstation, int createdUserId, string branchCode)
        {
            try
            {               
                // Modified by ZMS (2018/09/18) for Budget Month Flexible
                //int initialMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, startDate));
                string Return = string.Empty;
                string month = CcoaDAO.GetBudget_Month_Year_Quarter(3, startDate, branchCode, Return); // For 2018/09/17 => 6
                int initialMonth = Convert.ToInt32(month);

                string currentMonth = "M" + Convert.ToString(initialMonth);
                string currentMonth_OB = "M" + Convert.ToString(initialMonth - 1);

                // Modified by ZMS (2018/09/18) for Budget Month Flexible
                //string Budget = CXCOM00010.Instance.GetBudgetYear_For_PreviousBudget(C1XCOM00009.BudgetYearCode, endDate);
                string Budget = CcoaDAO.GetBudget_Month_Year_Quarter(2, startDate, branchCode, Return);  // For 2018/09/17 => 2018/2018

                if (currentMonth == "M0")
                {
                    currentMonth = "Cbal";
                }
                //Get Data From report_tlf 
                this.GetDataForInsert(startDate, endDate, createdUserId, workstation, branchCode);

                #region Process Data

                //    decimal OpeningdblBalance, ClosingdblBalance, tempOpeningBalance, tempClosingBal;
                //    decimal DebitAmt, CreditAmt, DebitHomeOAmt, CreditHomeOAmt;
                //    int intCounter;
                //    string strAccountNo, strAccountNo1;

                //    //IList<PFMDTO00042> reporttlfList = ReporttlfDAO.SelectAll(branchCode); /// get all data from ReportTLF
                //    IList<PFMDTO00042> Rset_TableName = ReporttlfDAO.SelectDistinctACodeFromReportTLF(branchCode); // get distinct ACODE from ReportTLF
                //    IList<GLMDTO00023> allMonthlyCOAList = MonthlyccoaDAO.SelectAllMonthlyCOA(branchCode); /// get all data from monthly_coa [ORIGINAL]
                //    IList<GLMDTO00023> Rset_Coa = MonthlyccoaDAO.SelectACodeAndBal(currentMonth, Budget, branchCode); //M11,2016/2017,001(Mothly_coa join vw_ccoa)
                //    IList<MNMDTO00010> TotalBalfromVwccoa = MonthlyccoaDAO.SelectTotalBalAndAcodeFromVWCCOA(currentMonth, Budget, branchCode);//SelectTotalBalAndAcodeFromVWCCOA
                //    IList<GLMDTO00024> vwLedgerMonthlyPosting = MonthlyccoaDAO.SelectFromVWLedgerListingMonthlyPosting(startDate,endDate,branchCode,workstation);

                //    //// For Zero to Monthly_Coa Table ////
                //    for (int i = 0; i < allMonthlyCOAList.Count; i++)
                //    {
                //            allMonthlyCOAList[i].Closing_bal = 0;
                //            allMonthlyCOAList[i].Opening_bal = 0;
                //    }
                //    //// set ClosingBalance=Closing_bal AND OpeningBalance=Opening_bal ////
                //    foreach (GLMDTO00023 acodedto in Rset_Coa)
                //    {
                //        for (int i = 0; i < allMonthlyCOAList.Count; i++)
                //        {
                //            if (allMonthlyCOAList[i].SUBITEM == acodedto.ACODE)
                //            {
                //                allMonthlyCOAList[i].Closing_bal = acodedto.Closing_bal;
                //                //allMonthlyCOAList[i].Opening_bal = acodedto.Opening_bal;
                //                allMonthlyCOAList[i].Opening_bal = acodedto.Closing_bal;
                //            }
                //        }
                //    }
                //    foreach (PFMDTO00042 RsetTableNameitemdto in Rset_TableName)
                //    {
                //        ///Start Calculate Opening Amount
                //        DebitAmt = 0;
                //        CreditAmt = 0;
                //        OpeningdblBalance = 0;
                //        ClosingdblBalance = 0;
                //        strAccountNo = string.Empty;
                //        strAccountNo1 = string.Empty;
                //        intCounter = 0;
                //        tempOpeningBalance = 0;
                //        tempClosingBal = 0;
                //        DebitHomeOAmt = 0;
                //        CreditHomeOAmt = 0;
                //        string Filter = "";

                //        while (intCounter < (RsetTableNameitemdto.ACode.ToString().Length))   ///AKB101       
                //        {
                //            int result;
                //            if (Int32.TryParse(RsetTableNameitemdto.ACode.Substring(intCounter, 1).ToString(), out result) == false) //if the first letter of ACODE is not numeric
                //            {
                //                string a = result.ToString();
                //                strAccountNo = strAccountNo + RsetTableNameitemdto.ACode.Substring(intCounter, 1);
                //                intCounter = intCounter + 1;
                //            }
                //            else intCounter = 7;
                //        }
                //        //Check headCode or not 
                //        //if (RsetTableNameitemdto.ACode.Substring(0, strAccountNo.Length).ToString() == strAccountNo) // ABK001 => (ABK001,0,3) ==>ABK
                //        //{
                //        //    if (RsetTableNameitemdto.ACode.Substring(RsetTableNameitemdto.ACode.Length, strAccountNo.Length).All(char.IsDigit) && RsetTableNameitemdto.ACode.Substring(RsetTableNameitemdto.ACode.Length, strAccountNo.Length) == "0")
                //        //    {
                //        //        Filter = "Like '" + strAccountNo + " %' and acode not like '" + strAccountNo + "%000'"; //headCode
                //        //    }
                //        //    else
                //        //    {
                //        //        Filter = "=" + RsetTableNameitemdto.ACode;//not head code
                //        //    }
                //        //}

                //        string str_Head_Acode = Convert.ToString(RsetTableNameitemdto.ACode.Substring(0, 1) + "00000"); ///A00000
                //        strAccountNo1 = Convert.ToString(RsetTableNameitemdto.ACode.Substring(0, 3) + "00");  //ABK000

                //        //if (RsetTableNameitemdto.ACode.Substring(0,3).ToString() == strAccountNo) /// ABK 
                //        if (RsetTableNameitemdto.ACode.Substring(0, strAccountNo.Length).ToString() == strAccountNo) //ABK = ABK or CA = CA
                //        {
                //            #region old
                //            // ABK001 => (ABK001,3,6)
                //            //if (RsetTableNameitemdto.ACode.Substring(RsetTableNameitemdto.ACode.Length-1, RsetTableNameitemdto.ACode.Length).ToString() == "0") //ABK000 if head code
                //            //{
                //            //    foreach (MNMDTO00010 TotalBalfromVwccoaitemdto in TotalBalfromVwccoa)
                //            //    {
                //            //        // ABK=ABK and 000=000
                //            //        if (TotalBalfromVwccoaitemdto.ACODE.Substring(0, strAccountNo.Length).ToString() == strAccountNo && TotalBalfromVwccoaitemdto.ACODE.Substring(3, 3).ToString() != "000")//if headcode then sum all
                //            //        { 
                //            //                tempOpeningBalance = tempOpeningBalance + Convert.ToDecimal(TotalBalfromVwccoaitemdto.TotalBal);
                //            //                tempClosingBal = tempClosingBal + tempOpeningBalance;
                //            //        }
                //            //        //else if (TotalBalfromVwccoaitemdto.ACODE.ToString().Substring(3,3).ToString() != "000") // if not headcode//
                //            //        //{
                //            //        //    tempOpeningBalance = tempOpeningBalance + Convert.ToDecimal(TotalBalfromVwccoaitemdto.Balance);
                //            //        //    tempClosingBal = tempClosingBal + tempOpeningBalance;
                //            //        //}
                //            //    }
                //            //}
                //            //else if (RsetTableNameitemdto.ACode.Substring(2, 3).ToString() != "0") //ABK000  //not head code//
                //            //{
                //            //    foreach (MNMDTO00010 TotalBalfromVwccoaitemdto in TotalBalfromVwccoa)
                //            //    {
                //            //        // ABK=ABK and 101!=000
                //            //        if (RsetTableNameitemdto.ACode.ToString()==TotalBalfromVwccoaitemdto.ACODE.ToString() && TotalBalfromVwccoaitemdto.ACODE.ToString().Substring(0, 3).ToString() == strAccountNo && TotalBalfromVwccoaitemdto.ACODE.ToString().Substring(3, 3).ToString() != "000")//if headcode then sum all
                //            //        {
                //            //            tempOpeningBalance = tempOpeningBalance + Convert.ToDecimal(TotalBalfromVwccoaitemdto.TotalBal);
                //            //            tempClosingBal = tempClosingBal + tempOpeningBalance;
                //            //        }
                //            //    }
                //            //}
                //            //    OpeningdblBalance = tempOpeningBalance;
                //            //    ClosingdblBalance = tempClosingBal;
                //            #endregion
                //            //// "Like ABK%' and acode not like 'ABK%00' //headCode
                //            string temp = RsetTableNameitemdto.ACode.Length.ToString();
                //            decimal startCount = Convert.ToDecimal(temp) - 1;
                //            decimal endCount = Convert.ToDecimal(temp);
                //            string TempAcode = RsetTableNameitemdto.ACode.ToString();
                //            //string restCode = TempAcode.Substring(Convert.ToInt32(startCount),Convert.ToInt32(endCount));

                //            temp = strAccountNo.Length.ToString();
                //            decimal startCount1 = Convert.ToDecimal(temp) - 1;
                //            temp = RsetTableNameitemdto.ACode.Length.ToString();
                //            decimal endCount1 = Convert.ToDecimal(temp);
                //            string TempAcode1 = RsetTableNameitemdto.ACode.ToString();
                //            //string restCode1 = TempAcode1.Substring(Convert.ToInt32(startCount1), Convert.ToInt32(endCount1));

                //            if (RsetTableNameitemdto.ACode.Substring(5,1).ToString() == "0")
                //            // if (restCode.ToString() == "0") //ABK000 if head code
                //            //if (RsetTableNameitemdto.ACode.Substring(RsetTableNameitemdto.ACode.Length - 1, RsetTableNameitemdto.ACode.Length).ToString() == "0") //ABK000 if head code
                //            {
                //                //foreach (MNMDTO00010 TotalBalfromVwccoaitemdto in TotalBalfromVwccoa)
                //                //{
                //                //    // ABK=ABK and 000=000
                //                //    if (TotalBalfromVwccoaitemdto.ACODE.Substring(0, strAccountNo.Length).ToString() == strAccountNo && TotalBalfromVwccoaitemdto.ACODE.Substring(3, 3).ToString() != "000")//if headcode then sum all
                //                //    {
                //                //        tempOpeningBalance = tempOpeningBalance + Convert.ToDecimal(TotalBalfromVwccoaitemdto.TotalBal);
                //                //        tempClosingBal = tempClosingBal + tempOpeningBalance;
                //                //    }
                //                //    //    //else if (TotalBalfromVwccoaitemdto.ACODE.ToString().Substring(3,3).ToString() != "000") // if not headcode//
                //                //    //    //{
                //                //    //    //    tempOpeningBalance = tempOpeningBalance + Convert.ToDecimal(TotalBalfromVwccoaitemdto.Balance);
                //                //    //    //    tempClosingBal = tempClosingBal + tempOpeningBalance;
                //                //    //    //}
                //                //}
                //            }

                //            //else if (RsetTableNameitemdto.ACode.Substring(strAccountNo.Length - 1, RsetTableNameitemdto.ACode.Length).ToString() != "0") //ABK000  //not head code//
                //            //else if (restCode1 != "0") //ABK000  //not head code//
                //            else if (RsetTableNameitemdto.ACode.Substring(5, 1).ToString() != "0")
                //            {
                //                foreach (MNMDTO00010 TotalBalfromVwccoaitemdto in TotalBalfromVwccoa)
                //                {
                //                    // ABK=ABK and 101!=000
                //                    //if (RsetTableNameitemdto.ACode.ToString() == TotalBalfromVwccoaitemdto.ACODE.ToString() && TotalBalfromVwccoaitemdto.ACODE.ToString().Substring(0, 3).ToString() == strAccountNo && TotalBalfromVwccoaitemdto.ACODE.ToString().Substring(3, 3).ToString() != "000")//if headcode then sum all
                //                    if (RsetTableNameitemdto.ACode.ToString() == TotalBalfromVwccoaitemdto.ACODE.ToString() && TotalBalfromVwccoaitemdto.ACODE.ToString().Substring(0, 3).ToString() == strAccountNo)//if headcode then sum all
                //                    {
                //                        //tempOpeningBalance = Convert.ToDecimal(TotalBalfromVwccoaitemdto.TotalBal);
                //                        //tempClosingBal =  tempOpeningBalance;
                //                        for (int i = 0; i < allMonthlyCOAList.Count; i++)
                //                        {
                //                            if (allMonthlyCOAList[i].SUBITEM == RsetTableNameitemdto.ACode)
                //                            {
                //                                allMonthlyCOAList[i].Opening_bal = Convert.ToDecimal(TotalBalfromVwccoaitemdto.TotalBal);
                //                                //allMonthlyCOAList[i].Opening_bal = acodedto.Opening_bal;
                //                                allMonthlyCOAList[i].Opening_bal = allMonthlyCOAList[i].Opening_bal;
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //        }

                //        #region old
                //        /////'Start Calculate Closing,Debit,Credit Amount
                //        //if (RsetTableNameitemdto.ACode.Substring(0, 3).ToString() == "AAA")
                //        //{
                //        //    foreach (GLMDTO00024 vwLedgerMonthlyPostingitemdto in vwLedgerMonthlyPosting)
                //        //    {
                //        //        if (vwLedgerMonthlyPostingitemdto.Cash == 1 && vwLedgerMonthlyPostingitemdto.ACode.ToString().Substring(0, 3) == "AAA")
                //        //        {
                //        //            ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                //        //            ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                //        //        }
                //        //        CreditAmt = CreditAmt + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                //        //        DebitAmt = DebitAmt + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);

                //        //        ///Start///
                //        //        ///'Start Insert into Opening,Closing,Credti,Debit Amount for Sub Head and Sub Code     
                //        //        foreach (GLMDTO00023 monthlycoaitemdto in allMonthlyCOAList)
                //        //        {
                //        //            decimal monthlyCreditAmt = 0, monthlyDebitAmt = 0, monthlyOB = 0, monthlyCB = 0;
                //        //            monthlyCreditAmt = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //            monthlyDebitAmt = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //            monthlyOB = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //            monthlyCB = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //            if (monthlycoaitemdto.SUBITEM == RsetTableNameitemdto.ACode.ToString())
                //        //            {
                //        //                monthlycoaitemdto.Credit_Amount = CreditAmt;
                //        //                monthlycoaitemdto.Debit_Amount = DebitAmt;
                //        //                monthlycoaitemdto.Closing_bal = ClosingdblBalance;
                //        //                monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //        //            }
                //        //            if (strAccountNo1.Substring(1, 1) == "A" || strAccountNo1.Substring(1, 1) == "E")
                //        //            {
                //        //                if (monthlycoaitemdto.SUBITEM == strAccountNo1) ///ABK100
                //        //                {
                //        //                    monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //        //                    monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //        //                    monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                //        //                    //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //        //                }
                //        //                if (monthlycoaitemdto.SUBITEM == str_Head_Acode) ///ABK000
                //        //                {
                //        //                    monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //        //                    monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //        //                    monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                //        //                }
                //        //            }
                //        //            else if (strAccountNo1.Substring(1, 1) == "I" || strAccountNo1.Substring(1, 1) == "L")
                //        //            {
                //        //                if (monthlycoaitemdto.SUBITEM == strAccountNo1)
                //        //                {
                //        //                    monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //        //                    monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //        //                    monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                //        //                    //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //        //                }
                //        //                if (monthlycoaitemdto.SUBITEM == str_Head_Acode)
                //        //                {
                //        //                    monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //        //                    monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //        //                    monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                //        //                }
                //        //            }
                //        //        }
                //        //    }//end of foreach

                //        //    //Update Monthly_Coa

                //        //    PFMDTO00042 reportTLFHomeoAmt = monthlyccoaDAO.SelectReportTLfHomeOAmt_Of_Monthly_Posting(startDate, endDate, branchCode, workstation);
                //        //    PFMDTO00042 ledgerlistingMPList = monthlyccoaDAO.LEDGERLISTINGOfMonthlyPostingProc("ACB001", startDate, endDate, branchCode, workstation);

                //        //    IList<GLMDTO00024> mpCashAcclist = monthlyccoaDAO.MonthlyPostingofCashAccProc(startDate, endDate, workstation, branchCode); //Need to Open

                //        //    foreach (GLMDTO00023 monthlycoaitemdto in allMonthlyCOAList)
                //        //    {
                //        //        ///You can add 'LAE%' Account to the OverDraff Account(AAH000)
                //        //        if (monthlycoaitemdto.SUBITEM == "ALA000")
                //        //        {
                //        //            monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(reportTLFHomeoAmt.HomeOAmt_Credit);
                //        //            monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + Convert.ToDecimal(reportTLFHomeoAmt.HomeOAmt_Debit);
                //        //            monthlycoaitemdto.Closing_bal = (monthlycoaitemdto.Opening_bal - monthlycoaitemdto.Credit_Amount
                //        //                                            - Convert.ToDecimal(reportTLFHomeoAmt.HomeOAmt_Credit))
                //        //                                            + (monthlycoaitemdto.Debit_Amount + reportTLFHomeoAmt.HomeOAmt_Debit);
                //        //        }

                //        //        ///Change Credit Amount to Debit Amount and Debit Amount to Credit Amount.
                //        //        if (monthlycoaitemdto.SUBITEM == "AAA000")
                //        //        {
                //        //            monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Debit_Amount;
                //        //            monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Credit_Amount;
                //        //        }
                //        //        if (monthlycoaitemdto.SUBITEM == "ACB000")
                //        //        {
                //        //            monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(ledgerlistingMPList.Credit);
                //        //            monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + Convert.ToDecimal(ledgerlistingMPList.Debit);
                //        //            monthlycoaitemdto.Closing_bal = (monthlycoaitemdto.Opening_bal + monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(ledgerlistingMPList.Credit))
                //        //                                            - (monthlycoaitemdto.Debit_Amount + ledgerlistingMPList.Debit);
                //        //        }

                //        //        // For AAA  {Need to Open}
                //        //        CreditAmt = 0;
                //        //        DebitAmt = 0;
                //        //        foreach (GLMDTO00024 mpCashAcclistitemdto in mpCashAcclist)
                //        //        {
                //        //            if (mpCashAcclistitemdto.Credit_Debit == "C")
                //        //            {
                //        //                DebitAmt = Convert.ToDecimal(mpCashAcclistitemdto.CREDIT);
                //        //            }
                //        //            else if (mpCashAcclistitemdto.Credit_Debit == "D")
                //        //            {
                //        //                CreditAmt = Convert.ToDecimal(mpCashAcclistitemdto.DEBIT);
                //        //            }
                //        //        }
                //        //        if (monthlycoaitemdto.SUBITEM == "AAA000")
                //        //        {
                //        //            monthlycoaitemdto.Credit_Amount = Convert.ToDecimal(CreditAmt);
                //        //            monthlycoaitemdto.Debit_Amount = Convert.ToDecimal(DebitAmt);
                //        //            monthlycoaitemdto.Closing_bal = (monthlycoaitemdto.Opening_bal + monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(DebitAmt))
                //        //                                            - (monthlycoaitemdto.Debit_Amount + CreditAmt);
                //        //        }

                //        //        ///End///
                //        //        /// ///updating of Monthly_COA
                //        //        /// ReportFormatEntryDAO.Save(ConvertToORM(formatFileData));  
                //        //        //monthlyccoaDAO.Update(ConvertToORM(monthlycoaitemdto));
                //        //        monthlyccoaDAO.UpdateAll(monthlycoaitemdto);
                //        //    }
                //        //}
                //        //else if (RsetTableNameitemdto.ACode.Substring(0, 3).ToString() != "AAA")
                //        //{
                //        //    foreach (GLMDTO00024 vwLedgerMonthlyPostingitemdto in vwLedgerMonthlyPosting)
                //        //    {
                //        //        if (vwLedgerMonthlyPostingitemdto.Cash != 1 && vwLedgerMonthlyPostingitemdto.ACode.ToString().Substring(0, 3) != "AAA" )
                //        //        {
                //        //            if (vwLedgerMonthlyPostingitemdto.ACType == "A" || vwLedgerMonthlyPostingitemdto.ACType == "E")
                //        //            { 
                //        //                 ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                //        //                 ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                //        //            }
                //        //            else if (vwLedgerMonthlyPostingitemdto.ACType == "I" || vwLedgerMonthlyPostingitemdto.ACType == "L")
                //        //            {
                //        //                ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                //        //                ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                //        //            }
                //        //        }
                //        //        CreditAmt = CreditAmt + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                //        //        DebitAmt = DebitAmt + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);

                //        //        ///Start ///
                //        //        ///'Start Insert into Opening,Closing,Credti,Debit Amount for Sub Head and Sub Code     
                //        //        foreach (GLMDTO00023 monthlycoaitemdto in allMonthlyCOAList)
                //        //        {
                //        //            decimal monthlyCreditAmt = 0, monthlyDebitAmt = 0, monthlyOB = 0, monthlyCB = 0;
                //        //            monthlyCreditAmt = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //            monthlyDebitAmt = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //            monthlyOB = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //            monthlyCB = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //            if (monthlycoaitemdto.SUBITEM == RsetTableNameitemdto.ACode.ToString())
                //        //            {
                //        //                monthlycoaitemdto.Credit_Amount = CreditAmt;
                //        //                monthlycoaitemdto.Debit_Amount = DebitAmt;
                //        //                monthlycoaitemdto.Closing_bal = ClosingdblBalance;
                //        //                monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //        //            }
                //        //            if (strAccountNo1.Substring(1, 1) == "A" || strAccountNo1.Substring(1, 1) == "E")
                //        //            {
                //        //                if (monthlycoaitemdto.SUBITEM == strAccountNo1) ///ABK100
                //        //                {
                //        //                    monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //        //                    monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //        //                    monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                //        //                    //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //        //                }
                //        //                if (monthlycoaitemdto.SUBITEM == str_Head_Acode) ///ABK000
                //        //                {
                //        //                    monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //        //                    monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //        //                    monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                //        //                }
                //        //            }
                //        //            else if (strAccountNo1.Substring(1, 1) == "I" || strAccountNo1.Substring(1, 1) == "L")
                //        //            {
                //        //                if (monthlycoaitemdto.SUBITEM == strAccountNo1)
                //        //                {
                //        //                    monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //        //                    monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //        //                    monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                //        //                    //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //        //                }
                //        //                if (monthlycoaitemdto.SUBITEM == str_Head_Acode)
                //        //                {
                //        //                    monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //        //                    monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //        //                    monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                //        //                }
                //        //            }
                //        //        }
                //        //    }//end of foreach

                //        //    //Update Monthly_Coa

                //        //    PFMDTO00042 reportTLFHomeoAmt = monthlyccoaDAO.SelectReportTLfHomeOAmt_Of_Monthly_Posting(startDate, endDate, branchCode, workstation);
                //        //    PFMDTO00042 ledgerlistingMPList = monthlyccoaDAO.LEDGERLISTINGOfMonthlyPostingProc("ACB001", startDate, endDate, branchCode, workstation);

                //        //    IList<GLMDTO00024> mpCashAcclist = monthlyccoaDAO.MonthlyPostingofCashAccProc(startDate, endDate, workstation, branchCode); //Need to Open

                //        //    foreach (GLMDTO00023 monthlycoaitemdto in allMonthlyCOAList)
                //        //    {
                //        //        ///You can add 'LAE%' Account to the OverDraff Account(AAH000)
                //        //        if (monthlycoaitemdto.SUBITEM == "ALA000")
                //        //        {
                //        //            monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(reportTLFHomeoAmt.HomeOAmt_Credit);
                //        //            monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + Convert.ToDecimal(reportTLFHomeoAmt.HomeOAmt_Debit);
                //        //            monthlycoaitemdto.Closing_bal = (monthlycoaitemdto.Opening_bal - monthlycoaitemdto.Credit_Amount
                //        //                                            - Convert.ToDecimal(reportTLFHomeoAmt.HomeOAmt_Credit))
                //        //                                            + (monthlycoaitemdto.Debit_Amount + reportTLFHomeoAmt.HomeOAmt_Debit);
                //        //        }

                //        //        ///Change Credit Amount to Debit Amount and Debit Amount to Credit Amount.
                //        //        if (monthlycoaitemdto.SUBITEM == "AAA000")
                //        //        {
                //        //            monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Debit_Amount;
                //        //            monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Credit_Amount;
                //        //        }
                //        //        if (monthlycoaitemdto.SUBITEM == "ACB000")
                //        //        {
                //        //            monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(ledgerlistingMPList.Credit);
                //        //            monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + Convert.ToDecimal(ledgerlistingMPList.Debit);
                //        //            monthlycoaitemdto.Closing_bal = (monthlycoaitemdto.Opening_bal + monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(ledgerlistingMPList.Credit))
                //        //                                            - (monthlycoaitemdto.Debit_Amount + ledgerlistingMPList.Debit);
                //        //        }

                //        //        // For AAA  {Need to Open}
                //        //        CreditAmt = 0;
                //        //        DebitAmt = 0;
                //        //        foreach (GLMDTO00024 mpCashAcclistitemdto in mpCashAcclist)
                //        //        {
                //        //            if (mpCashAcclistitemdto.Credit_Debit == "C")
                //        //            {
                //        //                DebitAmt = Convert.ToDecimal(mpCashAcclistitemdto.CREDIT);
                //        //            }
                //        //            else if (mpCashAcclistitemdto.Credit_Debit == "D")
                //        //            {
                //        //                CreditAmt = Convert.ToDecimal(mpCashAcclistitemdto.DEBIT);
                //        //            }
                //        //        }
                //        //        if (monthlycoaitemdto.SUBITEM == "AAA000")
                //        //        {
                //        //            monthlycoaitemdto.Credit_Amount = Convert.ToDecimal(CreditAmt);
                //        //            monthlycoaitemdto.Debit_Amount = Convert.ToDecimal(DebitAmt);
                //        //            monthlycoaitemdto.Closing_bal = (monthlycoaitemdto.Opening_bal + monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(DebitAmt))
                //        //                                            - (monthlycoaitemdto.Debit_Amount + CreditAmt);
                //        //        }
                //        //        ///updating of Monthly_COA
                //        //        /// ReportFormatEntryDAO.Save(ConvertToORM(formatFileData));  
                //        //        //monthlyccoaDAO.Update(ConvertToORM(monthlycoaitemdto));
                //        //        monthlyccoaDAO.UpdateAll(monthlycoaitemdto);
                //        //        ///End///
                //        //     }
                //        //}
                //        #endregion

                //        ///'Start Calculate Closing,Debit,Credit Amount
                //        //if (RsetTableNameitemdto.ACode.Substring(0, 3).ToString() == "AAA")//cash Account
                //        //{
                //        foreach (GLMDTO00024 vwLedgerMonthlyPostingitemdto in vwLedgerMonthlyPosting)
                //        {
                //            if (RsetTableNameitemdto.ACode == vwLedgerMonthlyPostingitemdto.ACode)
                //            {
                //                if (vwLedgerMonthlyPostingitemdto.Cash == 1 && vwLedgerMonthlyPostingitemdto.ACode.ToString().Substring(0, 3) == "AAA")
                //                {
                //                    ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                //                    ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                //                }
                //                else
                //                {
                //                    if (vwLedgerMonthlyPostingitemdto.ACType == "A" || vwLedgerMonthlyPostingitemdto.ACType == "E")
                //                    {
                //                        ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                //                        ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                //                    }
                //                    else if (vwLedgerMonthlyPostingitemdto.ACType == "I" || vwLedgerMonthlyPostingitemdto.ACType == "L")
                //                    {
                //                        ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                //                        ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                //                    }
                //                }
                //                CreditAmt = CreditAmt + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                //                DebitAmt = DebitAmt + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                //            }//end of foreach

                //            foreach (GLMDTO00023 monthlycoaitemdto in allMonthlyCOAList)
                //            {

                //                decimal monthlyCreditAmt = 0, monthlyDebitAmt = 0, monthlyOB = 0, monthlyCB = 0;
                //                monthlyCreditAmt = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //                monthlyDebitAmt = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //                monthlyOB = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //                monthlyCB = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);

                //                //for general updating
                //                if (monthlycoaitemdto.SUBITEM == RsetTableNameitemdto.ACode.ToString())
                //                {
                //                    monthlycoaitemdto.Credit_Amount = CreditAmt;
                //                    monthlycoaitemdto.Debit_Amount = DebitAmt;
                //                    monthlycoaitemdto.Closing_bal = ClosingdblBalance;
                //                    monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //                }

                //                if (strAccountNo1.Substring(1, 1) == "A" || strAccountNo1.Substring(1, 1) == "E")
                //                {
                //                    if (monthlycoaitemdto.SUBITEM == strAccountNo1) ///ABK100
                //                    {
                //                        monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //                        monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //                        monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                //                        //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //                    }
                //                    if (monthlycoaitemdto.SUBITEM == str_Head_Acode) ///ABK000
                //                    {
                //                        monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //                        monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //                        monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                //                    }
                //                }
                //                else if (strAccountNo1.Substring(1, 1) == "I" || strAccountNo1.Substring(1, 1) == "L")
                //                {
                //                    if (monthlycoaitemdto.SUBITEM == strAccountNo1)
                //                    {
                //                        monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //                        monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //                        monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyCreditAmt + CreditAmt) - (monthlyDebitAmt + DebitAmt);
                //                        //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //                    }
                //                    if (monthlycoaitemdto.SUBITEM == str_Head_Acode)
                //                    {
                //                        monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                //                        monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                //                        monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyCreditAmt + CreditAmt) - (monthlyDebitAmt + DebitAmt);
                //                    }
                //                }                        
                //            }
                //        //PFMDTO00042 reportTLFHomeoAmt = monthlyccoaDAO.SelectReportTLfHomeOAmt_Of_Monthly_Posting(startDate, endDate, branchCode, workstation);

                //        ////PFMDTO00042 ledgerlistingMPList = monthlyccoaDAO.LEDGERLISTINGOfMonthlyPostingProc("ACB001", startDate, endDate, branchCode, workstation);

                //        //IList<GLMDTO00024> mpCashAcclist = monthlyccoaDAO.MonthlyPostingofCashAccProc(startDate, endDate, workstation, branchCode); //Need to Open

                //        ///'End Calculate Closing,Debit,Credit Amount
                //        #region old

                //        //    ///'Start Insert into Opening,Closing,Credti,Debit Amount for Sub Head and Sub Code     
                //        //    foreach (GLMDTO00023 monthlycoaitemdto in allMonthlyCOAList)
                //        //    {
                //        //        decimal monthlyCreditAmt=0, monthlyDebitAmt=0, monthlyOB=0, monthlyCB=0;
                //        //        monthlyCreditAmt = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //        monthlyDebitAmt = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //        monthlyOB = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //        monthlyCB = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                //        //        if (monthlycoaitemdto.SUBITEM == RsetTableNameitemdto.ACode.ToString())
                //        //        {
                //        //            monthlycoaitemdto.Credit_Amount = CreditAmt;
                //        //            monthlycoaitemdto.Debit_Amount = DebitAmt;
                //        //            monthlycoaitemdto.Closing_bal =  ClosingdblBalance;
                //        //            monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //        //        }
                //        //        if (strAccountNo1.Substring(1, 1) == "A" || strAccountNo1.Substring(1, 1) == "E" )
                //        //        {
                //        //             if(monthlycoaitemdto.SUBITEM == strAccountNo1) ///ABK100
                //        //            {
                //        //                monthlycoaitemdto.Credit_Amount = monthlyCreditAmt+CreditAmt;
                //        //                monthlycoaitemdto.Debit_Amount = monthlyDebitAmt+DebitAmt;
                //        //                monthlycoaitemdto.Closing_bal = (monthlyOB+monthlyDebitAmt+DebitAmt)-(monthlyCreditAmt+CreditAmt);
                //        //                //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //        //            }
                //        //             if (monthlycoaitemdto.SUBITEM == str_Head_Acode) ///ABK000
                //        //            {
                //        //                monthlycoaitemdto.Credit_Amount = monthlyCreditAmt+CreditAmt;
                //        //                monthlycoaitemdto.Debit_Amount = monthlyDebitAmt+DebitAmt;
                //        //                monthlycoaitemdto.Closing_bal = (monthlyOB+monthlyDebitAmt+DebitAmt)-(monthlyCreditAmt+CreditAmt);
                //        //            }
                //        //        }
                //        //        else if (strAccountNo1.Substring(1, 1) == "I" || strAccountNo1.Substring(1, 1) == "L")
                //        //        {
                //        //            if(monthlycoaitemdto.SUBITEM == strAccountNo1)
                //        //            {
                //        //                monthlycoaitemdto.Credit_Amount = monthlyCreditAmt+CreditAmt;
                //        //                monthlycoaitemdto.Debit_Amount = monthlyDebitAmt+DebitAmt;
                //        //                monthlycoaitemdto.Closing_bal = (monthlyOB+monthlyDebitAmt+DebitAmt)-(monthlyCreditAmt+CreditAmt);
                //        //                //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                //        //            }
                //        //            if(monthlycoaitemdto.SUBITEM == str_Head_Acode)
                //        //            {
                //        //                monthlycoaitemdto.Credit_Amount = monthlyCreditAmt+CreditAmt;
                //        //                monthlycoaitemdto.Debit_Amount = monthlyDebitAmt+DebitAmt;
                //        //                monthlycoaitemdto.Closing_bal = (monthlyOB+monthlyDebitAmt+DebitAmt)-(monthlyCreditAmt+CreditAmt);
                //        //            }
                //        //        }
                //        //    }
                //        //}//end of foreach

                //        ////Update Monthly_Coa

                //        //PFMDTO00042 reportTLFHomeoAmt = monthlyccoaDAO.SelectReportTLfHomeOAmt_Of_Monthly_Posting(startDate, endDate, branchCode, workstation);
                //        //PFMDTO00042 ledgerlistingMPList = monthlyccoaDAO.LEDGERLISTINGOfMonthlyPostingProc("ACB001", startDate, endDate, branchCode, workstation);

                //        //IList<GLMDTO00024> mpCashAcclist = monthlyccoaDAO.MonthlyPostingofCashAccProc(startDate, endDate, workstation, branchCode); //Need to Open

                //        //foreach (GLMDTO00023 monthlycoaitemdto in allMonthlyCOAList)
                //        //{
                //        //    ///You can add 'LAE%' Account to the OverDraff Account(AAH000)
                //        //    if (monthlycoaitemdto.SUBITEM == "ALA000")
                //        //    {
                //        //        monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(reportTLFHomeoAmt.HomeOAmt_Credit);
                //        //        monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + Convert.ToDecimal(reportTLFHomeoAmt.HomeOAmt_Debit);
                //        //        monthlycoaitemdto.Closing_bal = (monthlycoaitemdto.Opening_bal - monthlycoaitemdto.Credit_Amount
                //        //                                        - Convert.ToDecimal(reportTLFHomeoAmt.HomeOAmt_Credit)) 
                //        //                                        + (monthlycoaitemdto.Debit_Amount + reportTLFHomeoAmt.HomeOAmt_Debit);
                //        //    }

                //        //    ///Change Credit Amount to Debit Amount and Debit Amount to Credit Amount.
                //        //    if (monthlycoaitemdto.SUBITEM == "AAA000")
                //        //    {
                //        //        monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Debit_Amount;
                //        //        monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Credit_Amount;
                //        //    }
                //        //    if (monthlycoaitemdto.SUBITEM == "ACB000")
                //        //    {
                //        //        monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(ledgerlistingMPList.Credit);
                //        //        monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + Convert.ToDecimal(ledgerlistingMPList.Debit);
                //        //        monthlycoaitemdto.Closing_bal = (monthlycoaitemdto.Opening_bal + monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(ledgerlistingMPList.Credit))
                //        //                                        - (monthlycoaitemdto.Debit_Amount + ledgerlistingMPList.Debit);
                //        //    }

                //        //    // For AAA  {Need to Open}
                //        //    CreditAmt = 0;
                //        //    DebitAmt = 0;
                //        //    foreach (GLMDTO00024 mpCashAcclistitemdto in mpCashAcclist)
                //        //    {
                //        //        if (mpCashAcclistitemdto.Credit_Debit == "C")
                //        //        {
                //        //            DebitAmt = Convert.ToDecimal(mpCashAcclistitemdto.CREDIT);
                //        //        }
                //        //        else if (mpCashAcclistitemdto.Credit_Debit == "D")
                //        //        {
                //        //            CreditAmt = Convert.ToDecimal(mpCashAcclistitemdto.DEBIT);
                //        //        }
                //        //    }
                //        //    if (monthlycoaitemdto.SUBITEM == "AAA000")
                //        //    {
                //        //        monthlycoaitemdto.Credit_Amount = Convert.ToDecimal(CreditAmt);
                //        //        monthlycoaitemdto.Debit_Amount = Convert.ToDecimal(DebitAmt);
                //        //        monthlycoaitemdto.Closing_bal = (monthlycoaitemdto.Opening_bal + monthlycoaitemdto.Credit_Amount + Convert.ToDecimal(DebitAmt))
                //        //                                        - (monthlycoaitemdto.Debit_Amount + CreditAmt);
                //        //    }

                //        /////updating of Monthly_COA
                //        ///// ReportFormatEntryDAO.Save(ConvertToORM(formatFileData));  
                //        //monthlyccoaDAO.Update(ConvertToORM(monthlycoaitemdto));
                //        #endregion
                //        }
                //    }
                #endregion


                #region New Process Data

                decimal OpeningdblBalance, ClosingdblBalance;
                decimal DebitAmt, CreditAmt;
                int intCounter;
                string strAccountNo, strAccountNo1, str_Head_Acode;
                decimal CashOpeningdblBalance, CashClosingdblBalance, CashDebitAmt, CashCreditAmt;

                //IList<PFMDTO00042> reporttlfList = ReporttlfDAO.SelectAll(branchCode); /// get all data from ReportTLF
                IList<PFMDTO00042> Rset_TableName = ReporttlfDAO.SelectDistinctACodeFromReportTLF(branchCode); // get distinct ACODE from ReportTLF
                IList<GLMDTO00023> allMonthlyCOAList = MonthlyccoaDAO.SelectAllMonthlyCOA(branchCode); /// get all data from monthly_coa [ORIGINAL]
                IList<GLMDTO00023> Rset_Coa = MonthlyccoaDAO.SelectACodeAndBal(currentMonth, Budget, branchCode); //M11,2016/2017,001(Mothly_coa join vw_ccoa)
                IList<MNMDTO00010> TotalBalfromVwccoa = MonthlyccoaDAO.SelectTotalBalAndAcodeFromVWCCOA(currentMonth_OB, Budget, branchCode);//SelectTotalBalAndAcodeFromVWCCOA
                IList<GLMDTO00024> vwLedgerMonthlyPosting = MonthlyccoaDAO.SelectFromVWLedgerListingMonthlyPosting(startDate, endDate, branchCode, workstation);

                //// For Zero to Monthly_Coa Table ////
                for (int i = 0; i < allMonthlyCOAList.Count; i++)
                {
                    allMonthlyCOAList[i].Closing_bal = 0;
                    allMonthlyCOAList[i].Opening_bal = 0;
                    allMonthlyCOAList[i].Credit_Amount = 0;
                    allMonthlyCOAList[i].Debit_Amount = 0;
                }
                //// set ClosingBalance=Closing_bal AND OpeningBalance=Opening_bal ////
                foreach (GLMDTO00023 acodedto in Rset_Coa)
                {
                    for (int i = 0; i < allMonthlyCOAList.Count; i++)
                    {
                        if (allMonthlyCOAList[i].SUBITEM == acodedto.ACODE)
                        {
                            allMonthlyCOAList[i].Closing_bal = acodedto.Closing_bal;
                            //allMonthlyCOAList[i].Opening_bal = acodedto.Opening_bal;
                            allMonthlyCOAList[i].Opening_bal = acodedto.Closing_bal;
                        }
                    }
                }
                foreach (GLMDTO00023 monthlycoaitemdto in allMonthlyCOAList)//(PFMDTO00042 RsetTableNameitemdto in Rset_TableName)
                {
                    ///Start Calculate Opening Amount
                    DebitAmt = 0;
                    CreditAmt = 0;
                    OpeningdblBalance = 0;
                    ClosingdblBalance = 0;
                    strAccountNo = string.Empty;
                    intCounter = 0;

                    string Filter = "";

                    while (intCounter < (monthlycoaitemdto.SUBITEM.ToString().Length))   ///AKB101       
                    {
                        int result;
                        if (Int32.TryParse(monthlycoaitemdto.SUBITEM.Substring(intCounter, 1).ToString(), out result) == false) //if the first letter of ACODE is not numeric
                        {
                            string a = result.ToString();
                            strAccountNo = strAccountNo + monthlycoaitemdto.SUBITEM.Substring(intCounter, 1);
                            intCounter = intCounter + 1;
                        }
                        else intCounter = 7;
                    }

                    str_Head_Acode = Convert.ToString(monthlycoaitemdto.SUBITEM.Substring(0, 1) + "00000"); ///A00000
                    strAccountNo1 = Convert.ToString(monthlycoaitemdto.SUBITEM.Substring(0, 3) + "00");  //ABK000

                    //if (RsetTableNameitemdto.ACode.Substring(0,3).ToString() == strAccountNo) /// ABK                       
                    foreach (MNMDTO00010 TotalBalfromVwccoaitemdto in TotalBalfromVwccoa)
                    {
                        // ABK=ABK and 101!=000
                        if (monthlycoaitemdto.SUBITEM.ToString() == TotalBalfromVwccoaitemdto.ACODE.ToString())//if headcode then sum all
                        {
                            monthlycoaitemdto.Opening_bal = Convert.ToDecimal(TotalBalfromVwccoaitemdto.TotalBal);
                            //monthlycoaitemdto.Opening_bal = monthlycoaitemdto.Opening_bal;
                        }
                    }
                    if (monthlycoaitemdto.SUBITEM == "AAA001") //For Cash Account ?
                    {
                        foreach (GLMDTO00024 vwLedgerMonthlyPostingitemdto in vwLedgerMonthlyPosting)
                        {
                            if (vwLedgerMonthlyPostingitemdto.cash == 1)
                            {
                                ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                                ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);

                                CreditAmt = Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                                DebitAmt = Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);

                                monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + DebitAmt;
                                monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + CreditAmt;
                            }
                            //monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + CreditAmt;
                            //monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + DebitAmt;
                        }//end of foreach
                    }
                    else if (monthlycoaitemdto.SUBITEM.Substring(3, 3) == "000") // HEAD CODE ?
                    {
                        foreach (GLMDTO00024 vwLedgerMonthlyPostingitemdto in vwLedgerMonthlyPosting)
                        {
                            if (monthlycoaitemdto.SUBITEM.Substring(0, strAccountNo.Length) == vwLedgerMonthlyPostingitemdto.ACode.Substring(0, strAccountNo.Length)) // EC0000 
                            {
                                if ((vwLedgerMonthlyPostingitemdto.ACType == "A" || vwLedgerMonthlyPostingitemdto.ACType == "E"))
                                {
                                    ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                                    ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                                }
                                if (vwLedgerMonthlyPostingitemdto.ACType == "I" || vwLedgerMonthlyPostingitemdto.ACType == "L")
                                {
                                    ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                                    ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                                }
                                CreditAmt = Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                                DebitAmt = Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                            }

                            if (monthlycoaitemdto.SUBITEM.Substring(0, strAccountNo.Length) == vwLedgerMonthlyPostingitemdto.ACode.Substring(0, strAccountNo.Length)) // EC0000 
                            {
                                if ((vwLedgerMonthlyPostingitemdto.ACType == "A" || vwLedgerMonthlyPostingitemdto.ACType == "E"))
                                //if (monthlycoaitemdto.SUBITEM == vwLedgerMonthlyPostingitemdto.ACode) ///ABK100
                                {
                                    monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + CreditAmt;
                                    monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + DebitAmt;
                                    //monthlycoaitemdto.Closing_bal = (monthlyOB + DebitAmt) - CreditAmt;
                                    //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                                }
                            }
                            if (monthlycoaitemdto.SUBITEM.Substring(0, strAccountNo.Length) == vwLedgerMonthlyPostingitemdto.ACode.Substring(0, strAccountNo.Length)) // EC0000 

                            //else if (monthlycoaitemdto.SUBITEM.Substring(0, strAccountNo.Length) == vwLedgerMonthlyPostingitemdto.ACode.Substring(0, strAccountNo.Length)) // EC0000 
                            {
                                if (vwLedgerMonthlyPostingitemdto.ACType == "I" || vwLedgerMonthlyPostingitemdto.ACType == "L")
                                //if (monthlycoaitemdto.SUBITEM == vwLedgerMonthlyPostingitemdto.ACode)
                                {
                                    monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + CreditAmt;
                                    monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + DebitAmt;
                                    //monthlycoaitemdto.Closing_bal = (monthlyOB +CreditAmt) -  DebitAmt;
                                    //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                                }
                            }
                        }//end of foreach
                    }
                    ///'Start Calculate Closing,Debit,Credit Amount 
                    else if (monthlycoaitemdto.SUBITEM.Substring(5, 1) != "0" || monthlycoaitemdto.SUBITEM.Substring(4, 2) != "00") // NOT HEAD CODE ?
                    {
                        foreach (GLMDTO00024 vwLedgerMonthlyPostingitemdto in vwLedgerMonthlyPosting)
                        {
                            if (monthlycoaitemdto.SUBITEM == vwLedgerMonthlyPostingitemdto.ACode)
                            {
                                if ((vwLedgerMonthlyPostingitemdto.ACType == "A" || vwLedgerMonthlyPostingitemdto.ACType == "E"))
                                {
                                    ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                                    ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                                }
                                //if (vwLedgerMonthlyPostingitemdto.ACType == "I" || vwLedgerMonthlyPostingitemdto.ACType == "L")
                                //{
                                //    ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                                //    ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                                //}
                                //CreditAmt = Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                                //DebitAmt = Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);

                                else if (vwLedgerMonthlyPostingitemdto.ACType == "I" || vwLedgerMonthlyPostingitemdto.ACType == "L")
                                {
                                    ClosingdblBalance = ClosingdblBalance + Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                                    ClosingdblBalance = ClosingdblBalance - Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);
                                }
                                CreditAmt = Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.CreditAmt);
                                DebitAmt = Convert.ToDecimal(vwLedgerMonthlyPostingitemdto.DebitAmt);

                            }
                            if ((vwLedgerMonthlyPostingitemdto.ACType == "A" || vwLedgerMonthlyPostingitemdto.ACType == "E"))
                            {
                                if (monthlycoaitemdto.SUBITEM == vwLedgerMonthlyPostingitemdto.ACode) ///ABK100
                                {
                                    monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + CreditAmt;
                                    monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + DebitAmt;
                                    //monthlycoaitemdto.Closing_bal = (monthlyOB + DebitAmt) - CreditAmt;
                                    //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                                }
                            }
                            else if (vwLedgerMonthlyPostingitemdto.ACType == "I" || vwLedgerMonthlyPostingitemdto.ACType == "L")
                            {
                                if (monthlycoaitemdto.SUBITEM == vwLedgerMonthlyPostingitemdto.ACode)
                                {
                                    monthlycoaitemdto.Credit_Amount = monthlycoaitemdto.Credit_Amount + CreditAmt;
                                    monthlycoaitemdto.Debit_Amount = monthlycoaitemdto.Debit_Amount + DebitAmt;
                                    //monthlycoaitemdto.Closing_bal = (monthlyOB +CreditAmt) -  DebitAmt;
                                    //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                                }
                            }
                        }//end of foreach
                    }

                    #region old
                    //////foreach (GLMDTO00023 monthlycoaitemdto in allMonthlyCOAList)
                    //////{

                    //////decimal monthlyCreditAmt = 0, monthlyDebitAmt = 0, monthlyOB = 0, monthlyCB = 0;
                    //////monthlyCreditAmt = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                    //////monthlyDebitAmt = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                    //////monthlyOB = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);
                    //////monthlyCB = Convert.ToDecimal(monthlycoaitemdto.Credit_Amount);

                    ////////for general updating
                    //////if (monthlycoaitemdto.SUBITEM == RsetTableNameitemdto.ACode.ToString())
                    //////{
                    //////    monthlycoaitemdto.Credit_Amount = CreditAmt;
                    //////    monthlycoaitemdto.Debit_Amount = DebitAmt;
                    //////    monthlycoaitemdto.Closing_bal = ClosingdblBalance;
                    //////    monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                    //////}

                    //////if ((vwLedgerMonthlyPostingitemdto.ACType == "A" || vwLedgerMonthlyPostingitemdto.ACType == "E") && (vwLedgerMonthlyPostingitemdto.ACode.ToString().Substring(0, 3) != "AAA" || vwLedgerMonthlyPostingitemdto.ACode.ToString().Substring(0, 3) != "AAB"))
                    //////{
                    //////    if (monthlycoaitemdto.SUBITEM == strAccountNo1) ///ABK100
                    //////    {
                    //////        monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                    //////        monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                    //////        monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                    //////        //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                    //////    }
                    //////    if (monthlycoaitemdto.SUBITEM == str_Head_Acode) ///ABK000
                    //////    {
                    //////        monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                    //////        monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                    //////        monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyDebitAmt + DebitAmt) - (monthlyCreditAmt + CreditAmt);
                    //////    }
                    //////}
                    //////else if (strAccountNo1.Substring(1, 1) == "I" || strAccountNo1.Substring(1, 1) == "L")
                    //////{
                    //////    if (monthlycoaitemdto.SUBITEM == strAccountNo1)
                    //////    {
                    //////        monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                    //////        monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                    //////        monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyCreditAmt + CreditAmt) - (monthlyDebitAmt + DebitAmt);
                    //////        //monthlycoaitemdto.Opening_bal = OpeningdblBalance;
                    //////    }
                    //////    if (monthlycoaitemdto.SUBITEM == str_Head_Acode)
                    //////    {
                    //////        monthlycoaitemdto.Credit_Amount = monthlyCreditAmt + CreditAmt;
                    //////        monthlycoaitemdto.Debit_Amount = monthlyDebitAmt + DebitAmt;
                    //////        monthlycoaitemdto.Closing_bal = (monthlyOB + monthlyCreditAmt + CreditAmt) - (monthlyDebitAmt + DebitAmt);
                    //////    }
                    //////}

                    //////}


                    //PFMDTO00042 reportTLFHomeoAmt = monthlyccoaDAO.SelectReportTLfHomeOAmt_Of_Monthly_Posting(startDate, endDate, branchCode, workstation);

                    ////PFMDTO00042 ledgerlistingMPList = monthlyccoaDAO.LEDGERLISTINGOfMonthlyPostingProc("ACB001", startDate, endDate, branchCode, workstation);

                    //IList<GLMDTO00024> mpCashAcclist = monthlyccoaDAO.MonthlyPostingofCashAccProc(startDate, endDate, workstation, branchCode); //Need to Open

                    ///'End Calculate Closing,Debit,Credit Amount                      
                }
                //}
                //}
                    #endregion
                #endregion

                foreach (GLMDTO00023 monthlycoaitemdto in allMonthlyCOAList)
                {
                    /// ///updating of Monthly_COA
                    monthlyccoaDAO.UpdateAll(monthlycoaitemdto);
                }
                this.UpdateStatus(endDate, branchCode, createdUserId);

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI30014";   //Posting Finished successfully.
            }

            catch (Exception e)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = e.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }
        #endregion

        public GLMORM00023 ConvertToORM(GLMDTO00023 monthly_coaData)
        {
            if (this.monthly_coaORM == null)
                monthly_coaORM = new GLMORM00023();
            monthly_coaORM.Id = monthly_coaData.Id;
            monthly_coaORM.TYPE = Convert.ToChar(monthly_coaData.TYPE);
            monthly_coaORM.ITEM = monthly_coaData.ITEM;
            monthly_coaORM.SUBITEM = monthly_coaData.SUBITEM;
            monthly_coaORM.ACODE = monthly_coaData.ACODE;
            monthly_coaORM.TITLE = monthly_coaData.TITLE;
            monthly_coaORM.SUBTITLE = monthly_coaData.SUBTITLE;
            monthly_coaORM.Opening_bal = monthly_coaData.Opening_bal;
            monthly_coaORM.Closing_bal = monthly_coaData.Closing_bal;
            monthly_coaORM.Credit_Amount = monthly_coaData.Credit_Amount;
            monthly_coaORM.Debit_Amount = monthly_coaData.Debit_Amount;
            monthly_coaORM.DCode = monthly_coaData.DCode;
            monthly_coaORM.Active = monthly_coaData.Active;
            monthly_coaORM.TS = monthly_coaData.TS;
            monthly_coaORM.CreatedUserId = monthly_coaData.CreatedUserId;
            monthly_coaORM.CreatedDate = monthly_coaData.CreatedDate;
            monthly_coaORM.UpdatedUserId = monthly_coaData.UpdatedUserId;
            monthly_coaORM.UpdatedDate = monthly_coaData.UpdatedDate;

            return monthly_coaORM;
        }

        #region Updating status to Sys001

        [Transaction(TransactionPropagation.Required)]
        public void UpdateStatus(DateTime date, string sourcebr, int createdUserId)
        {
            string name = "";
            if (sourcebr == "")
            {
                name = "ConMonthly_Posting";
            }
            else
            {
                name = "Monthly_Posting";
            }


            bool UpdateStatus = Sys001DAO.UpdateDateDailyPosting(name, date, sourcebr, createdUserId);
        }
        #endregion

        #region convert data From Dto to Orm
        private PFMORM00042 GetType(PFMDTO00042 rptlfdto)
        {
            PFMORM00042 rptlfInfo = new PFMORM00042();
            rptlfInfo.Eno = rptlfdto.Eno;
            rptlfInfo.AcctNo = rptlfdto.AcctNo;
            rptlfInfo.Amount = rptlfdto.Amount;
            rptlfInfo.ACode = (string.IsNullOrEmpty(rptlfdto.ACode)) ? string.Empty : rptlfdto.ACode;
            rptlfInfo.HomeAmount = rptlfdto.HomeAmount;
            rptlfInfo.HomeAmt = rptlfdto.HomeAmt;
            rptlfInfo.HomeOAmt = rptlfdto.HomeOamt;
            rptlfInfo.LocalAmount = rptlfdto.LocalAmount;
            rptlfInfo.LocalAmt = rptlfdto.LocalAmt;
            rptlfInfo.LocalOAmt = rptlfdto.LocalOamt;
            rptlfInfo.SourceCur = rptlfdto.SourceCur;
            rptlfInfo.CurCode = rptlfdto.CurCode;
            rptlfInfo.Cheque = rptlfdto.CurCode;
            rptlfInfo.PONo = rptlfdto.PaymentOrderNo;
            rptlfInfo.DRegisterNo = rptlfdto.DrawingRegisterNo;
            rptlfInfo.ERegisterNo = rptlfdto.EncashRegisterNo;
            rptlfInfo.LgNo = rptlfdto.LGNo;
            rptlfInfo.LNo = rptlfdto.LoanNo;
            rptlfInfo.Desp = rptlfdto.Description;
            rptlfInfo.Narration = rptlfdto.Narration;
            if (rptlfInfo.DATE_TIME == default(DateTime))
            {
                rptlfInfo.DATE_TIME = null;
            }
            else
            {
                rptlfInfo.DATE_TIME = rptlfdto.DATE_TIME;
            }

            rptlfInfo.Status = rptlfdto.Status;
            rptlfInfo.TranCode = rptlfdto.TransactionCode;
            rptlfInfo.ACSign = rptlfdto.AccountSign;
            rptlfInfo.DomBankPost = rptlfdto.DomBankPost;
            rptlfInfo.ClrPostStatus = rptlfdto.ClearingPostStatus;
            rptlfInfo.OrgnEno = rptlfdto.OrgnENo;
            rptlfInfo.OrgnTranCode = rptlfdto.OrgnTranCode;
            rptlfInfo.OrgnCheque = rptlfdto.OrgnCheque;
            rptlfInfo.OrgnPONo = rptlfdto.OrgnPoNo;
            rptlfInfo.OrgnDReg = rptlfdto.OrgnDReg;
            rptlfInfo.OrgnEReg = rptlfdto.OrgnEReg;
            rptlfInfo.OrgnLgNo = rptlfdto.OrgnLgNo;
            rptlfInfo.OrgnLno = rptlfdto.OrgnLNo;
            rptlfInfo.UserNo = rptlfdto.UserNo;
            rptlfInfo.ContraEno = rptlfdto.ConTraEno;
            rptlfInfo.ContraLno = rptlfdto.ConTraLno;
            if (rptlfdto.Contra_Date != default(DateTime))
            {
                rptlfInfo.ContraDate = rptlfdto.Contra_Date;

            }
            else
            {
                rptlfInfo.ContraDate = null;
            }
            rptlfInfo.OtherBank = rptlfdto.OtherBank;
            rptlfInfo.DeliverReturn = rptlfdto.Deliver_Return;
            rptlfInfo.ReceiptNo = rptlfdto.ReceiptNo;
            rptlfInfo.OtherBankChq = rptlfdto.OtherBankChq;
            rptlfInfo.OtherBankAcctNo = rptlfdto.OtherBankAccountNo;
            rptlfInfo.CustId = rptlfdto.CustId;
            rptlfInfo.GChqNo = rptlfdto.GChequeNo;
            if (rptlfdto.ChkTime == default(DateTime))
            {
                rptlfInfo.ChkTime = null;
            }
            else
            {
                rptlfInfo.ChkTime = rptlfdto.ChkTime;
            }
            rptlfInfo.WorkStation = rptlfdto.WorkStation;
            rptlfInfo.SourceBr = rptlfdto.SourceBranch;
            rptlfInfo.Rate = rptlfdto.Rate;
            if (rptlfInfo.SettlementDate == default(DateTime))
            {
                rptlfInfo.SettlementDate = null;
            }
            else
            {
                rptlfInfo.SettlementDate = rptlfdto.SettlementDate;
            }

            rptlfInfo.Channel = rptlfdto.Channel;
            rptlfInfo.RefVNo = rptlfdto.RefVNo;
            rptlfInfo.RefType = rptlfdto.RefType;
            rptlfInfo.UId = rptlfdto.UniqueIdentifier;

            return rptlfInfo;

        }
        #endregion

        //#region check status for update dcode null

        //public bool CheckStatusAndUpdate(DateTime date, string sourcebr, string currentMonth, string currentMSRC, int createdUserId)
        //{
        //    string name = "Monthly_Posting";
        //    string getdate = date.ToShortDateString();

        //    PFMDTO00056 sys001dto = this.Sys001DAO.SelectAllByName(name, sourcebr);
        //    if (sys001dto == null)
        //    {
        //        return false;
        //    }

        //    else
        //    {
        //        string sysdate = sys001dto.SysDate.ToString().Substring(0, 10);

        //        if (sys001dto.Status == "Y" && sysdate == getdate)
        //        {
        //            IList<CurrencyChargeOfAccountDTO> selectCCOA = CcoaDAO.SelectAllByDcodeandCurrentmth(currentMonth, currentMSRC, sourcebr);

        //            foreach (CurrencyChargeOfAccountDTO itemdto in selectCCOA)
        //            {
        //                decimal currentMonthAmt = itemdto.TotalM;
        //                decimal MSRCAmt = itemdto.TotalMSRC;
        //                string acode = itemdto.ACODE;
        //                string cur = itemdto.CUR;

        //                if (CcoaDAO.UpdateDcodeNullForCheckStatus(currentMonth, currentMSRC, currentMonthAmt, MSRCAmt, acode, cur, createdUserId) == false)
        //                {
        //                    throw new Exception(CXMessage.MI30050); //update error
        //                }
        //            }

        //            return true;
        //        }
        //    }

        //    return true;
        //}

        //#endregion 

        #region Monthly Report Setup
        public GLMDTO00023 SelectAllByAccountCode(string ACode)
        {
            return this.MonthlyccoaDAO.SelectAllByAccountCode(ACode);            
        }

        public GLMDTO00023 SelectAllMonthlyCOAByAccountCode(string ACode)
        {
            //return this.MonthlyccoaDAO.SelectAllByAccountCode(ACode);
            return this.MonthlyccoaDAO.SelectAllMonthlyCOAByAccountCode(ACode);//Added by HMW (24-11-2022) : For Deleteing issue in "Monthly Report Setup Edit" (Wrong data select logic from COA)
        }

        public IList<GLMDTO00023> SelectAllAccountType()
        {
            return this.MonthlyccoaDAO.SelectAllAccountType();
        }

        public IList<GLMDTO00023> SelectAllBranchCode()
        {
            return this.MonthlyccoaDAO.SelectAllBranchCode();
        }

        public IList<GLMDTO00023> SelectAllTITLE()
        {
            return this.MonthlyccoaDAO.SelectAllTITLE();
        }

        public IList<GLMDTO00023> SelectAllTITLE_By_Type(string Type)
        {
            return this.MonthlyccoaDAO.SelectAllTITLE_By_Type(Type);
        }

        public IList<GLMDTO00023> SelectAllSUBTITLE_by_TITLE(string TITLE)
        {
            return this.MonthlyccoaDAO.SelectAllSUBTITLE_by_TITLE(TITLE);
        }

        public IList<GLMDTO00023> SelectAllOtherBankGroupTitle(string ACode)
        {
            return this.MonthlyccoaDAO.SelectAllOtherBankGroupTitle(ACode);
        }
        #endregion
    }
}
