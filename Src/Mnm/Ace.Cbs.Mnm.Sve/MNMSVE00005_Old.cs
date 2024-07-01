//----------------------------------------------------------------------
// <copyright file="MNMSVE00005.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Khin Swe Win</CreatedUser>
// <CreatedDate>13/11/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.Contracts.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Mnm.Dmd;


namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00005 : BaseService, IMNMSVE00005
    {
        #region Propertity
        IList<string> MessageList = new List<string>();

        private IMNMDAO00005 tod_ScharedDAO;
        public IMNMDAO00005 Tod_ScharedDAO
        {
            get { return this.tod_ScharedDAO; }
            set { this.tod_ScharedDAO = value; }
        }

        private IMNMDAO00001 syspostDAO;
        public IMNMDAO00001 SyspostDAO
        {
            get { return this.syspostDAO; }
            set { this.syspostDAO = value; }
        }

        private IPFMDAO00057 newsetupDAO;
        public IPFMDAO00057 NewsetupDAO
        {
            get { return this.newsetupDAO; }
            set { this.newsetupDAO = value; }
        }

        private ICurrencyDAO curDAO;
        public ICurrencyDAO CurDAO
        {
            get { return this.curDAO; }
            set { this.curDAO = value; }
        }

        private IMNMDAO00030 reporttlfDAO;
        public IMNMDAO00030 ReporttlfDAO
        {
            get { return this.reporttlfDAO; }
            set { this.reporttlfDAO = value; }
        }

        private ICXDAO00009 vw_postingDAO;
        public ICXDAO00009 VW_PostingDAO
        {
            get { return this.vw_postingDAO; }
            set { this.vw_postingDAO = value; }
        }

        //private ICurrencyChargeOfAccountDAO ccoaDAO;
        //public ICurrencyChargeOfAccountDAO CcoaDAO
        //{

        //    get { return this.ccoaDAO; }
        //    set { this.ccoaDAO = value; }
        //}

        private ICXDAO00014 ccoaDAO;
        public ICXDAO00014 CcoaDAO
        {
            get { return this.ccoaDAO; }
            set { this.ccoaDAO = value; }
        }

        private IPFMDAO00056 sys001DAO;
        public IPFMDAO00056 Sys001DAO
        {
            get { return this.sys001DAO; }
            set { this.sys001DAO = value; }
        }

        public ICXSVE00010 DataGenerateService { get; set; }

        string namepost = "YEARLYPOST";


        #endregion

        #region Method

        #region OldCode
        //Old Code
        [Transaction(TransactionPropagation.Required)]
        //public virtual string CheckDate(DateTime Dailydate,string sourcebr)
        //{
        //    string selectdate = this.SyspostDAO.SelectbyYearpost(namepost, sourcebr);
        //    if (String.IsNullOrEmpty(selectdate))
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        return this.ServiceResult.MessageCode = "ME30011";// Data Not Found in SysPost {0}.
        //    }
        //    string selectvalue = this.NewsetupDAO.SelectBudDate("BUDEDATE").ToString();

        //    //string postdate = selectdate.Substring(6, 4);
        //    DateTime selectdate2 = Convert.ToDateTime(selectdate);
        //    //string postdate = selectdate2.ToShortDateString();
        //    //string postdate = "2014";
        //    //string postMonth="03";
        //    string postdate = selectdate2.Year.ToString();
        //    string postMonth = selectdate2.Month.ToString();
        //    string postDay = selectdate2.Day.ToString();
        //   // string postMonth = selectdate.Substring(0, 2);
        //   // string postDay = selectdate.Substring(3, 2);
        //    int post_Day = Convert.ToInt32(postDay);

        //   // string datetxt = Dailydate.ToShortDateString().Substring(6, 4);
        //    string datetxt = Dailydate.Year.ToString();
        //    //string datetxt = "2014";
        //    string datemonth = Dailydate.Month.ToString();
        //    //string datemonth = "11";
        //    string dateday = Dailydate.Day.ToString();
        //    //string dateday = "04";

        //    int lastyear = Convert.ToInt32(postdate);
        //    int nextyear = lastyear + 1;
        //    int datetxtyear = Convert.ToInt32(datetxt);

        //    int lastmonth=Convert.ToInt32(postMonth);
        //    int datetxtmonth=Convert.ToInt32(datemonth);

        //    string nextdate=selectvalue+"/"+nextyear;
        //    //string nextdatestr=selectvalue.Substring(3,2);
        //    string nextdatestr = "03";
        //    int nextmonth=Convert.ToInt32(nextdatestr);

        //    //string lastdaystr = selectdate.Substring(3, 2);
        //    string lastdaystr ="31";
        //    int lastday = Convert.ToInt32(lastdaystr);
        //    int datetxtday = Convert.ToInt32(dateday);
        //    //string nextdaystr = selectvalue.Substring(0, 2);
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

        //New Code
        public virtual string CheckDate(DateTime Dailydate, string sourcebr)
        {
            string selectdate = this.SyspostDAO.SelectbyYearpost(namepost, sourcebr);
            if (String.IsNullOrEmpty(selectdate))
            {
                this.ServiceResult.ErrorOccurred = true;
                return this.ServiceResult.MessageCode = "ME30011";// Data Not Found in SysPost {0}.
            }
            string selectvalue = this.NewsetupDAO.SelectBudDate("BUDEDATE").ToString();
            DateTime selectdate2 = Convert.ToDateTime(selectdate);

            int post_Day = selectdate2.Day;

            int lastyear = selectdate2.Year;
            int nextyear = lastyear + 1;
            int datetxtyear = Dailydate.Year;

            int lastmonth = selectdate2.Month;
            int datetxtmonth = Dailydate.Month;

            string nextdate = selectvalue + "/" + nextyear;

            string nextdatestr = "03";
            int nextmonth = Convert.ToInt32(nextdatestr);

            string lastdaystr = "31";
            int lastday = Convert.ToInt32(lastdaystr);
            int datetxtday = Dailydate.Day;

            string nextdaystr = "31";
            int nextday = Convert.ToInt32(nextdaystr);

            string message = "31/03/" + nextyear;

            if (lastmonth <= datetxtmonth && lastyear < datetxtyear && (datetxtyear - lastyear) != 1)
            {
                this.ServiceResult.ErrorOccurred = true;
                return this.ServiceResult.MessageCode = "MI30012," + message;// Please post balances for the year {0} first.
            }

            else if (lastyear > datetxtyear && datetxtmonth <= lastmonth) //(lastyear > datetxtyear)
            {
                this.ServiceResult.ErrorOccurred = true;
                return this.ServiceResult.MessageCode = "ME30005";//Yearly posting is already finished.Please contact your administrator.
            }

            else if (nextyear < datetxtyear)
            {
                this.ServiceResult.ErrorOccurred = true;
                return this.ServiceResult.MessageCode = "MI30010";// No need to run yearly posting.Please contact your system administrator.
            }

            else
            {
                if (nextyear == datetxtyear)
                {
                    if (nextmonth < datetxtmonth)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        return this.ServiceResult.MessageCode = "MI30010";// Need to run Yearly Posting.

                    }
                }

            }
            if (lastyear > datetxtyear && nextyear < datetxtyear)
            {
                this.ServiceResult.ErrorOccurred = true;
                return this.ServiceResult.MessageCode = "ME30005";// finished yearly posting
            }
            else
            {
                if (lastyear == datetxtyear)
                {
                    if (lastmonth > datetxtmonth && nextmonth < datetxtmonth)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        return this.ServiceResult.MessageCode = "ME30005";// finished yearly posting

                    }
                    else if (nextmonth == datetxtmonth && post_Day == datetxtday)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        return this.ServiceResult.MessageCode = "ME30005";//Yearly posting is already finished.Please contact your administrator.
                    }
                }
                else if (nextyear == datetxtyear)
                {
                    if (lastmonth > datetxtmonth && nextmonth < datetxtmonth)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        return this.ServiceResult.MessageCode = "ME30005";// finished yearly posting

                    }
                    else if (nextmonth > 4 && post_Day == datetxtday) //(nextmonth > datetxtmonth && post_Day == datetxtday) Modified by AAM (01-Feb-2018)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        return this.ServiceResult.MessageCode = "ME30005";//Yearly posting is already finished.Please contact your administrator.
                    }
                }
            }
            //if (datetxtday - lastday <= 0)
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    this.ServiceResult.MessageCode = "MI30004";// finished yearly posting
            //    return;
            //}
            //if (datetxtday - nextday > 0)
            //{
            //    this.ServiceResult.ErrorOccurred = true;
            //    this.ServiceResult.MessageCode = "MI30004";// finished yearly posting
            //    return;
            //}
            return null;
        }
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
            parameters.BDateType = "S";
            parameters.UserNo = workStation;
            parameters.CreatedUserId = createdUserId;
            parameters.SpecialCondition = "SourceBr = " + "'" + branchCode + "'";
            DataGenerateDTO = DataGenerateService.GetReportDataGenerateInSQL(parameters);

        }

        #endregion

        #region insert report_tlf for cash/OD/CLH by cur

        public virtual IList<CurrencyDTO> GetAll()
        {
            return this.CurDAO.SelectAll();
        }

        public virtual IList<PFMDTO00042> GetAllRTLF(string sourcebr)
        {
            return this.ReporttlfDAO.SelectAll(sourcebr);
        }

        public void DataInsertCash(IList<CurrencyDTO> itemList, IList<PFMDTO00042> reporttlflist, string branchcode)
        {
            //IList<CurrencyDTO> itemList = this.GetAll();
            //IList<PFMDTO00042> reporttlflist = this.GetAllRTLF(branchcode);

            foreach (CurrencyDTO item in itemList)
            {
                string CashAcode = null;
                // CashAcode = CXCOM00010.Instance.GetCoaSetupAccountNo("CASH", CXCOM00007.Instance.BranchCode, item.Cur);
                CashAcode = this.Tod_ScharedDAO.GetCoaSetupAccountNo("CASH", branchcode, item.Cur);

                IList<PFMDTO00042> InsertlistCC = null;
                IList<PFMDTO00042> InsertlistCD = null;

                InsertlistCC = (from x in reporttlflist
                                where x.SourceCur == item.Cur && x.SourceBranch == branchcode && x.Status.Substring(0, 2) == "CC" && x.LocalOamt == 0
                                select x).ToList();

                InsertlistCD = (from x in reporttlflist
                                where x.SourceCur == item.Cur && x.SourceBranch == branchcode && x.Status.Substring(0, 2) == "CD" && x.LocalOamt == 0
                                select x).ToList();


                foreach (PFMDTO00042 rptlfdto in InsertlistCC)
                {

                    rptlfdto.Status = "CDV";
                    rptlfdto.ACode = CashAcode; //Updated by HWKO (24-Oct-2017) with sis AMMK's permission.
                    this.ReporttlfDAO.Save(GetType(rptlfdto));

                }

                foreach (PFMDTO00042 rptlfdto in InsertlistCD)
                {

                    rptlfdto.Status = "CCV";
                    rptlfdto.ACode = CashAcode; //Updated by HWKO (24-Oct-2017) with sis AMMK's permission.
                    this.ReporttlfDAO.Save(GetType(rptlfdto));

                }
            }

        }

        public void DataInsertClear(IList<CurrencyDTO> itemList, IList<PFMDTO00042> reporttlflist, string branchCode)
        {
            //IList<CurrencyDTO> itemList = this.GetAll();
            //IList<PFMDTO00042> reporttlflist = this.GetAllRTLF(branchcode);

            foreach (CurrencyDTO item in itemList)
            {
                string ClhAcode;
                ClhAcode = this.Tod_ScharedDAO.GetCoaSetupAccountNo("CLH", branchCode, item.Cur);
                //ClhAcode = CXCOM00010.Instance.GetCoaSetupAccountNo("CLH", CXCOM00007.Instance.BranchCode, item.Cur);

                IList<PFMDTO00042> InsertlistLC = (from x in reporttlflist
                                                   where x.SourceCur == item.Cur && x.SourceBranch == branchCode && x.Status.Substring(0, 2) == "LC" && x.LocalOamt == 0
                                                   select x).ToList();

                IList<PFMDTO00042> InsertlistLD = (from x in reporttlflist
                                                   where x.SourceCur == item.Cur && x.SourceBranch == branchCode && x.Status.Substring(0, 2) == "LD" && x.LocalOamt == 0
                                                   select x).ToList();

                foreach (PFMDTO00042 rptlfdto in InsertlistLC)
                {
                    rptlfdto.Status = "LDV";
                    rptlfdto.ACode = ClhAcode; //Updated by HWKO (24-Oct-2017) with sis AMMK's permission.
                    this.ReporttlfDAO.Save(GetType(rptlfdto));
                }

                foreach (PFMDTO00042 rptlfdto in InsertlistLD)
                {
                    rptlfdto.Status = "LCV";
                    rptlfdto.ACode = ClhAcode; //Updated by HWKO (24-Oct-2017) with sis AMMK's permission.
                    this.ReporttlfDAO.Save(GetType(rptlfdto));
                }


            }
        }

        public void DataInsertOD(IList<CurrencyDTO> itemList, IList<PFMDTO00042> reporttlflist, string branchCode)
        {
            //IList<CurrencyDTO> itemList = this.GetAll();
            //IList<PFMDTO00042> reporttlflist = this.GetAllRTLF(branchcode);

            foreach (CurrencyDTO item in itemList)
            {
                string ODAcode;
                string status;
                string frst;
                string secnd;
                string thrd;

                ODAcode = this.Tod_ScharedDAO.GetCoaSetupAccountNo("OD", branchCode, item.Cur);
                // ODAcode = CXCOM00010.Instance.GetCoaSetupAccountNo("OD", CXCOM00007.Instance.BranchCode, item.Cur);

                IList<PFMDTO00042> InsertlistOD = (from x in reporttlflist
                                                   where x.SourceCur == item.Cur && x.SourceBranch == branchCode && x.LocalOamt > 0
                                                   select x).ToList();


                foreach (PFMDTO00042 rptlfdto in InsertlistOD)
                {
                    string a = rptlfdto.Status.Substring(1, 1);
                    if (rptlfdto.Status.Substring(1, 1) == "C")
                    {
                        secnd = "D";
                    }
                    else
                    {
                        secnd = "C";
                    }
                    frst = rptlfdto.Status.Substring(0, 1);
                    thrd = rptlfdto.Status.Substring(2, 1);
                    status = frst + secnd + thrd;

                    rptlfdto.Status = status;
                    rptlfdto.ACode = ODAcode; //Updated by HWKO (24-Oct-2017) with sis AMMK's permission.
                    this.ReporttlfDAO.Save(GetType(rptlfdto));
                }
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void DataInsertForAll(string sourcebr)
        {
            IList<CurrencyDTO> itemList = this.GetAll();
            IList<PFMDTO00042> reporttlflist = this.GetAllRTLF(sourcebr);
            string branchCode = sourcebr;

            this.DataInsertCash(itemList, reporttlflist, branchCode);
            this.DataInsertClear(itemList, reporttlflist, branchCode);
            this.DataInsertOD(itemList, reporttlflist, branchCode);
        }

        #endregion

        #region Posting

        public virtual void Posting(DateTime startDate, DateTime endDate, string workstation, int createdUserId, string branchCode)
        {
            try
            {
                string checkDateMessage = this.CheckDate(endDate, branchCode);

                if (checkDateMessage != null)
                {
                    //try
                    //{
                    switch (checkDateMessage.Trim())
                    {
                        case "MI30012":
                            this.ServiceResult.ErrorOccurred = true;
                            //Please post balances for the year {0} first.
                            break;
                        case "MI30010":
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "MI30010"; // Need to run Yearly Posting.
                            break;

                        case "ME30005":
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "ME30005"; // finished yearly posting
                            break;
                        case "ME30011":
                            this.ServiceResult.ErrorOccurred = true;
                            this.ServiceResult.MessageCode = "ME30011," + namepost; // Data Not Found in SysPost {0}.
                            break;
                    }
                    // }
                    //catch (Exception expe)
                    //{
                    //    System.IO.File.WriteAllText(@"D:\Update1.txt", expe.Message + expe.StackTrace.ToString());
                    // }
                    return;
                }


                //int initialMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, DateTime.Now));
                int initialMonth = Convert.ToInt32(CXCOM00010.Instance.GetBudgetYear2(CXCOM00009.BudgetYearCode, endDate));
                string currentMonth = "M" + Convert.ToString(initialMonth);
                string currentHomemonth = "MSRC" + Convert.ToString(initialMonth);
                string prevMonth = "M" + Convert.ToString(initialMonth - 1);
                string prevHomemonth = "MSRC" + Convert.ToString(initialMonth - 1);


                if (this.CheckStatusAndUpdate(endDate, branchCode, currentMonth, currentHomemonth, createdUserId) == false)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MI30028"; //Data Not found Sys001

                    return;
                }

                //Get Data From report_tlf 
                this.GetDataForInsert(startDate, endDate, createdUserId, workstation, branchCode);

                //this.DataInsertForAll(branchCode); //Commented by HWKO (15-Nov-2017)

                IList<MNMDTO00023> postingList = vw_postingDAO.SelectAll(startDate, endDate, branchCode, workstation);

                if (initialMonth == 1)
                {
                    if (CcoaDAO.UpdateBalanceEqualM1ForDailyPost(currentMonth, currentHomemonth, branchCode, createdUserId) == false)
                    {
                        throw new Exception(CXMessage.ME90001); //update error
                    }
                }
                else
                {
                    if (CcoaDAO.UpdateBlanceNotM1ForDailyPost(currentMonth, currentHomemonth, prevMonth, prevHomemonth, branchCode, createdUserId) == false)
                    {
                        throw new Exception(CXMessage.ME90001); //update error
                    }
                }

                //Updated by HWKO (15-Nov-2017)
                string sourceCur = postingList.Select(p => p.SOURCECUR).FirstOrDefault();                 
                string CashAcode = this.Tod_ScharedDAO.GetCoaSetupAccountNo("CASH", branchCode, sourceCur);
                string ClhAcode = this.Tod_ScharedDAO.GetCoaSetupAccountNo("CLH", branchCode, sourceCur);
                string ODAcode = this.Tod_ScharedDAO.GetCoaSetupAccountNo("OD", branchCode, sourceCur);

                string CashHeadACode = Convert.ToString(CashAcode.Substring(0, 3) + "000");
                string ClhHeadACode = Convert.ToString(ClhAcode.Substring(0, 3) + "000");
                string ODHeadACode = Convert.ToString(ODAcode.Substring(0, 3) + "000");

                foreach (MNMDTO00023 itemdto in postingList)
                {

                    string acode = itemdto.ACODE;
                    //if (!string.IsNullOrEmpty(acode))

                    //{

                    string headacode = Convert.ToString(itemdto.ACODE.Substring(0, 3) + "000");
                    string midcode = Convert.ToString(itemdto.ACODE.Substring(2, 1));
                    string group = Convert.ToString(itemdto.ACODE.Substring(0, 1));
                    string groupacode;

                    if (midcode == "0")
                    {
                        groupacode = group + "00000";
                    }
                    else
                    {
                        groupacode = "";
                    }

                    string dcode = itemdto.SOURCEBR;
                    string cur = itemdto.SOURCECUR;
                    decimal localAmt = itemdto.LocalAmt;
                    decimal homeAmt = itemdto.HomeAmt;
                    decimal localOamt = (-1 * itemdto.LocalOAmt);
                    decimal homeOamt = (-1 * itemdto.HomeOAmt);
                    decimal clearingamt = itemdto.Clearing_Amount;
                    decimal clearingHomeamt = itemdto.Clearing_HomeAmount;
                    decimal cashlocalamt, cashhomeamt, cashlocalOamt, cashHomeOamt;

                    if (itemdto.Status_Letter_One == "C")
                    {
                        cashlocalamt = itemdto.Cash_LocalAmt;
                        cashhomeamt = itemdto.Cash_HomeAmt;
                        cashlocalOamt = itemdto.LocalOAmt;
                        cashHomeOamt = itemdto.HomeOAmt;
                    }
                    else
                    {
                        cashlocalamt = 0;
                        cashhomeamt = 0;
                        cashlocalOamt = 0;
                        cashHomeOamt = 0;
                    }

                    #region old Code

                    //try
                    //{
                    //    if (this.CcoaDAO.UpdateDailyPostingForAcode(acode, dcode, cur, currentMonth, currentHomemonth, localAmt, homeAmt, createdUserId) == false)
                    //    {
                    //        throw new Exception(CXMessage.MI30049); //update error
                    //    }
                    //}
                    //catch (Exception exxp)
                    //{
                    //    System.IO.File.WriteAllText(@"D:\Update2.txt", exxp.Message + exxp.StackTrace.ToString());
                    //}
                    //try
                    //{
                    //    if (this.CcoaDAO.UpdateDailyPostingForHeadAcode(headacode, dcode, cur, currentMonth, currentHomemonth, localAmt, homeAmt, createdUserId) == false)
                    //    {
                    //        throw new Exception(CXMessage.MI30049); //update error
                    //    }
                    //}
                    //catch (Exception exxx)
                    //{
                    //    System.IO.File.WriteAllText(@"D:\Update3.txt", exxx.Message + exxx.StackTrace.ToString());
                    //}

                    #endregion

                    //To update ccoa for detail acode 
                    if (this.CcoaDAO.UpdateDailyPostingForAcode(acode, dcode, cur, currentMonth, currentHomemonth, localAmt, homeAmt, createdUserId) == false)
                    {
                        throw new Exception(CXMessage.MI30049); //update error
                    }

                    //Added by HWKO (15-Nov-2017) 
                    //For Cash Account
                    if (this.CcoaDAO.UpdateDailyPostingForAcode(CashAcode, dcode, cur, currentMonth, currentHomemonth, cashlocalamt, cashhomeamt, createdUserId) == false)
                    {
                        throw new Exception(CXMessage.MI30049); //update error
                    }
                    //For Clearing Account
                    if(this.CcoaDAO.UpdateDailyPostingForAcode(ClhAcode,dcode,cur,currentMonth,currentHomemonth,clearingamt,clearingHomeamt,createdUserId) == false)
                    {
                        throw new Exception(CXMessage.MI30049); //update error
                    }
                    //For OD Account
                    if (this.CcoaDAO.UpdateDailyPostingForAcode(ODAcode, dcode, cur, currentMonth, currentHomemonth, cashlocalOamt, cashHomeOamt, createdUserId) == false)
                    {
                        throw new Exception(CXMessage.MI30049); //update error
                    }
                    //End Region

                    // Commented by HWKO (11-Oct-2017)
                    ////Added by HWKO (28-Aug-2017)
                    //else
                    //{
                    //    string result = this.Tod_ScharedDAO.SaveUpdateHistoryOfCCOA(acode, dcode, cur);
                    //    if (result.Equals("-3"))
                    //    {
                    //        throw new Exception(CXMessage.MI30049); //update error
                    //    }
                    //}
                    //End Region


                    //To Update ccoa for head of the acodes
                    if (this.CcoaDAO.UpdateDailyPostingForHeadAcode(headacode, dcode, cur, currentMonth, currentHomemonth, localAmt, homeAmt, createdUserId) == false)
                    {
                        throw new Exception(CXMessage.MI30049); //update error
                    }

                    //Added by HWKO (15-Nov-2017) 
                    //For Cash Account
                    if (this.CcoaDAO.UpdateDailyPostingForHeadAcode(CashHeadACode, dcode, cur, currentMonth, currentHomemonth, cashlocalamt, cashhomeamt, createdUserId) == false)
                    {
                        throw new Exception(CXMessage.MI30049); //update error
                    }
                    //For Clearing Account
                    if (this.CcoaDAO.UpdateDailyPostingForHeadAcode(ClhHeadACode, dcode, cur, currentMonth, currentHomemonth, clearingamt, clearingHomeamt, createdUserId) == false)
                    {
                        throw new Exception(CXMessage.MI30049); //update error
                    }
                    //For OD Account
                    if (this.CcoaDAO.UpdateDailyPostingForHeadAcode(ODHeadACode, dcode, cur, currentMonth, currentHomemonth, cashlocalOamt, cashHomeOamt, createdUserId) == false)
                    {
                        throw new Exception(CXMessage.MI30049); //update error
                    }
                    //End Region

                    // Commented by HWKO (11-Oct-2017)
                    ////Added by HWKO (28-Aug-2017)
                    //else
                    //{
                    //    string result = this.Tod_ScharedDAO.SaveUpdateHistoryOfCCOA(headacode, dcode, cur);
                    //    if (result.Equals("-3"))
                    //    {
                    //        throw new Exception(CXMessage.MI30049); //update error
                    //    }
                    //}//End Region
                    //To Update ccoa for group of the acodes
                    if (!String.IsNullOrEmpty(groupacode))
                    {
                        if (this.CcoaDAO.UpdateDailyPostingForGroupAcode(groupacode, dcode, cur, currentMonth, currentHomemonth, localAmt, homeAmt, createdUserId) == false)
                        {
                            throw new Exception(CXMessage.MI30049); //update error
                        }
                        // Commented by HWKO (11-Oct-2017)
                        ////Added by HWKO (28-Aug-2017)
                        //else
                        //{
                        //    string result = this.Tod_ScharedDAO.SaveUpdateHistoryOfCCOA(groupacode, dcode, cur);
                        //    if (result.Equals("-3"))
                        //    {
                        //        throw new Exception(CXMessage.MI30049); //update error
                        //    }
                        //}//End Region
                    }
                }

                this.GroupPosting(currentMonth, currentHomemonth, createdUserId, branchCode);

                this.UpdateStatus(endDate, branchCode, createdUserId);

                //Added by HWKO (11-Oct-2017)
                this.Tod_ScharedDAO.SaveUpdateHistoryOfCCOA(branchCode);

                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI30014";   //success post
            }
            catch (Exception e)
            {
                //System.IO.File.WriteAllText(@"D:\Posting.txt", e.Message + Environment.NewLine + e.StackTrace.ToString());
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = e.Message;
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void GroupPosting(string currentMonth, string currentMSRC, int createdUserId, string branchcode)
        {
            //Not need to update zero bec only one branch posing
            //if (CcoaDAO.UpdateZeroForNullDcode(currentMonth, currentMSRC, createdUserId) == false)
            //{
            //    throw new Exception(CXMessage.ME90001); //update error

            //}

            IList<CurrencyChargeOfAccountDTO> ccoaDTOList = CcoaDAO.SelectSumAllDcode(currentMonth, currentMSRC, branchcode);

            foreach (CurrencyChargeOfAccountDTO ccoaDTO in ccoaDTOList)
            {
                decimal TotalM = ccoaDTO.TotalM;
                decimal TotalMSRC = ccoaDTO.TotalMSRC;
                string Acode = ccoaDTO.ACODE;
                string Cur = ccoaDTO.CUR;

                if (CcoaDAO.UpdateGroupAcode(currentMonth, currentMSRC, TotalM, TotalMSRC, Acode, Cur, createdUserId) == false)
                {
                    throw new Exception(CXMessage.MI30050); //update error
                }
                // Commented by HWKO (11-Oct-2017)
                ////Added by HWKO (28-Aug-2017)
                //else
                //{
                //    string result = this.Tod_ScharedDAO.SaveUpdateHistoryOfCCOA(Acode, "", Cur);
                //    if (result.Equals("-3"))
                //    {
                //        throw new Exception(CXMessage.MI30049); //update error
                //    }
                //}//End Region
            }

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

        #region Updating status to Sys001

        [Transaction(TransactionPropagation.Required)]
        public void UpdateStatus(DateTime date, string sourcebr, int createdUserId)
        {
            string name = "Last_trial_date";

            bool UpdateStatus = Sys001DAO.UpdateDateDailyPosting(name, date, sourcebr, createdUserId);

        }

        #endregion

        #region check status for update dcode null

        public bool CheckStatusAndUpdate(DateTime date, string sourcebr, string currentMonth, string currentMSRC, int createdUserId)
        {
            string name = "Last_trial_date";
            string getdate = date.ToShortDateString();

            PFMDTO00056 sys001dto = this.Sys001DAO.SelectAllByName(name, sourcebr);
            if (sys001dto == null)
            {
                return false;
            }

            else
            {
                string sysdate = sys001dto.SysDate.ToString().Substring(0, 10);

                if (sys001dto.Status == "Y" && sysdate == getdate)
                {
                    IList<CurrencyChargeOfAccountDTO> selectCCOA = CcoaDAO.SelectAllByDcodeandCurrentmth(currentMonth, currentMSRC, sourcebr);

                    foreach (CurrencyChargeOfAccountDTO itemdto in selectCCOA)
                    {
                        decimal currentMonthAmt = itemdto.TotalM;
                        decimal MSRCAmt = itemdto.TotalMSRC;
                        string acode = itemdto.ACODE;
                        string cur = itemdto.CUR;

                        if (CcoaDAO.UpdateDcodeNullForCheckStatus(currentMonth, currentMSRC, currentMonthAmt, MSRCAmt, acode, cur, createdUserId) == false)
                        {
                            throw new Exception(CXMessage.MI30050); //update error
                        }
                    }

                    return true;
                }
            }

            return true;
        }

        #endregion
    }
}
